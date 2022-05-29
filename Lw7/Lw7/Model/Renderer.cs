using System;
using System.Threading;

namespace Lw7.Model
{

    /// <summary>
    /// Класс, выполняющий визуализацию сцены в буфере кадра.
    /// Работа по построению изображения в буфере кадра выполняется в отдельном потоке,
    /// дабы не замедлять работу основного приложения
    /// </summary>
    public class Renderer : IDisposable
    {
        // Выполняется ли в данный момент построение изображения в буфере кадра?
        public bool IsRenderig 
        {
            get => _rendering; 
        }

        private Thread? _thread;         // Поток в котором выполняется построение изображения
        private Mutex _mutex = new();    // Для обеспечения доступа к переменным _totalChunks и _renderedChunks
        private bool _rendering = false; // Идет ли в данныймомент построение изображения
        private bool _stopping = false;  // Сигнал рабочему потоку о необходимости остановить работу
        private UInt32 _totalChuncks = 0;
        private UInt32 _renderedChunks = 0;

        /// <summary>
        /// Сообщает о прогрессе выполнения работы
        /// </summary>
        /// <param name="renderedChunks">Количество обработанных блоков изображения</param>
        /// <param name="totalChunks">Общее количество блоков изображения</param>
        /// <returns>true - работа выполнена; false - работа не выполнена</returns>
        public bool GetProgress(out UInt32 renderedChunks, out UInt32 totalChunks)
        {
            lock (_mutex)
            {
                renderedChunks = _renderedChunks;
                totalChunks = _totalChuncks;

                return (totalChunks > 0) && (renderedChunks == totalChunks);
            }
        }

        /// <summary>
        /// Запускает фоновый поток для визуализации сцены в заданном буфере кадра
        /// Возвращает true, если поток был запущен и false, если поток запущен не был,
        /// т.к. не завершилась текущая операция по построению изображения в буфере кадра
        /// </summary>
        public bool Render(FrameBuffer frameBuffer)
        {
            if (!SetRendering(true))
            {
                return false;
            }

            lock (_mutex)
            {
                frameBuffer.Clear();

                _totalChuncks = 0;
                _renderedChunks = 0;

                if (SetStopping(false))
                {
                    SetRendering(false);
                    return false;
                }

                _thread = new(() => { RenderFrame(frameBuffer); });
                _thread.Start();

                return true; 
            }
        }

        /// <summary>
        /// Выполняет принудительную остановку фонового построения изображения
        /// </summary>
        public void Stop()
        {
            if (IsRenderig)
            {
                SetStopping(true);

                _thread?.Join();

                SetStopping(false);
            }
        }

        // Визуализация кадра, выполняемая в фоновом потоке
        private void RenderFrame(FrameBuffer frameBuffer)
        {
            uint width = frameBuffer.Width;
            uint height = frameBuffer.Height;

            _totalChuncks = height;

            for (uint y = 0; y < height; ++y)
            {
                Span<uint>? rowPixels = frameBuffer.GetPixels(y);

                if (!IsStopping())
                {
                    for (uint x = 0; x < width; ++x)
                    {
                        rowPixels[x] = CalculatePixelColor(x, y, width, height);
                    }

                    ++_renderedChunks;
                }
            }

            SetStopping(false);
            SetRendering(false);

        }

        // Устанавливаем потокобезопасным образом флаг о том, что идет построение изображения
        // Возвращаем true, если значение флага изменилось, и false, если нет
        private bool SetRendering(bool rendering)
        {
            bool result = _rendering != rendering;
            _rendering = rendering;
            return result;
        }
        
        // Устанавливаем флаг, сообщающий о необходимости завершения работы
        // Возвращаем true, если значение флага изменилось, и false, если нет
        private bool SetStopping(bool stopping)
        {
            bool result = _stopping != stopping;
            _stopping = stopping;
            return result;
        }

        // Установлен ли флаг, сообщающий о необходимости завершения работы
        private bool IsStopping()
        {
            return _stopping;
        }

        // Вычисляет цвет пикселя буфера кадра в координатах (х, у)
        private UInt32 CalculatePixelColor(UInt32 x, UInt32 y, UInt32 frameWidth, UInt32 frameHeight)
        {
            double x0 = 2.0 * x / frameWidth - 1.5;
            double y0 = 2.0 * y / frameHeight - 1.0;

            double rho = Math.Sqrt((x0 - 0.25) * (x0 - 0.25) + y0 * y0);
            double theta = Math.Atan2(y0, x0 - 0.25);
            double rhoC = 0.5 - 0.5 * Math.Cos(theta);
            if (rho <= rhoC)
            {
                return 0x000000;
            }

            double re = 0, im = 0;

            int iterCount = 10000;

            while ((iterCount > 0) && re * re + im * im < 1e18)
            {
                double re1 = re * re - im * im + x0;
                im = 2 * re * im + y0;
                re = re1;
                --iterCount;
            }

            UInt32 r = (UInt32)(iterCount / 3) & 0xff;
            UInt32 g = (UInt32)(iterCount) & 0xff;
            UInt32 b = (UInt32)(iterCount / 2) & 0xff;
            UInt32 a = 0xff;

            return (a << 24) | (r << 16) | (g << 8) | b;
        }

        public void Dispose()
        {
            // Останавливаем работу фонового потока, если он еще не закончился
            Stop();
        }
    }
}
