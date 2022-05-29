using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lw7.Model
{
    using RowPixelSpan = Span<UInt32>;
    public class FrameBuffer
    {
        public UInt32 Width { get; private set; }     // Ширина буфера в пикселях
        public UInt32 Height { get; private set; }    // Высота буфера в пикселях
        private RowPixelSpan[] _pixels; 

        public FrameBuffer(UInt32 width, UInt32 height)
        {
            Width = width;
            Height = height;

            _pixels = new RowPixelSpan[height];//new((int)height);
            for (int i = 0; i < height; ++i)
                _pixels[i] = new RowPixelSpan(width);
            //_pixels.ForEach(span => new RowPixelSpan(width));

        }

        // Отчистка содержимого буфера заданным цветом
        public void Clear(UInt32 color = 0x00000000)
        {
            for (int i = 0; i < Height; ++i)
                _pixels[i].Fill(color);
        }

        // Получение адреса соотв. строки пикселей
        public RowPixelSpan GetPixels(UInt32 row = 0)
        {
            return _pixels[(int)row];
        }
        
        // Получение цвета пикселя с заданными координатами
        public UInt32 GetPixel(UInt32 x, UInt32 y)
        {
            return _pixels[(int)y][x];
        }

        // Установка цвета пикселя с заданными координатами
        public void SetPixel(UInt32 x, UInt32 y, UInt32 color = 0x00000000)
        {
            _pixels[(int)y][x] = color;
        }

        public byte[] GetPixelData()
        {
            byte[] data = new byte[(int)(Width * Height * 4)];
            for (uint y = 0; y < Height; y++)
            {
                for (uint x = 0; x < Width; ++x)
                {
                    data[(4 * x + Width * 4 * y) + 0] = (byte)(_pixels[(int)y][x] >> 0 & 0xff);
                    data[(4 * x + Width * 4 * y) + 1] = (byte)(_pixels[(int)y][x] >> 8 & 0xff);
                    data[(4 * x + Width * 4 * y) + 2] = (byte)(_pixels[(int)y][x] >> 16 & 0xff);
                    data[(4 * x + Width * 4 * y) + 3] = (byte)(_pixels[(int)y][x] >> 24 & 0xff);
                }
            }
            return data.ToArray();
        }
    }
}
