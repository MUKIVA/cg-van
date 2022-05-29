using Lw7.Core;
using System.Windows.Media.Imaging;
using System.Threading.Tasks;
using Lw7.Model;
using System.Windows.Media;
using System;

namespace Lw7.ViewModel
{
    public class RendererViewModel : BaseViewModel
    {
        private Renderer _rendererModel;
        private FrameBuffer _frameBufferModel;

        public RendererViewModel(Renderer renderer, FrameBuffer frameBuffer)
        {
            _rendererModel = renderer;
            _frameBufferModel = frameBuffer;
            RenderFrameBuffer();
        }

        public uint FrameBufferWidth
        {
            get => _frameBufferModel.Width;
        }

        public uint FrameBufferHeight
        {
            get => _frameBufferModel.Height;
        }

        public BitmapSource PixelsData
        {
            get
            {
                return BitmapSource.Create(
                    (int)FrameBufferWidth,
                    (int)FrameBufferHeight,
                    96,
                    96,
                    PixelFormats.Bgra32,
                    null,
                    _frameBufferModel.GetPixelData(),
                    (int)FrameBufferWidth * PixelFormats.Bgra32.BitsPerPixel / 8);
            }
        }

        private async void RenderFrameBuffer()
        {
            await Task.Run(() => 
            {
                double time = 0.0d;
                var oldTime = DateTime.Now;
                _rendererModel.Render(_frameBufferModel);
                while (_rendererModel.IsRenderig)
                {
                    time += (DateTime.Now - oldTime).TotalSeconds;
                    oldTime = DateTime.Now;
                    if (time >= 0.5d)
                    {
                        time = 0.0d;
                        NotyfyPropertyChanged(nameof(PixelsData));
                    }
                }
                NotyfyPropertyChanged(nameof(PixelsData));
            });

            
        }
    }
}
