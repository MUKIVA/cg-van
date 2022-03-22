using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Ink;

namespace Lw2.Model
{
    public class CanvasModel
    {
        private int _height;
        private int _width;
        private int _lineWidth;
        private Visibility _VisibleMode = Visibility.Hidden;
        private ImageBrush _bg = new ImageBrush();
        private DrawingAttributes _style = new DrawingAttributes();

        public DrawingAttributes Style
        {
            get => _style;
            set => _style = value;
        }

        public ImageBrush LoadImage
        {
            get => _bg;
            set => _bg = value;
        }

        public Visibility IsVisible
        {
            get => _VisibleMode;
            set => _VisibleMode = value;
        }

        public int LineWidth
        {
            get => _lineWidth;
            set => _lineWidth = value;
        }

        public int Height
        {
            get => _height;
            set => _height = value;
        }

        public int Width
        {
            get => _width;
            set => _width = value;
        }

        public void Init(InkCanvas canvas)
        {
            _height = (int)canvas.ActualHeight;
            _width = (int)canvas.ActualWidth;
        }
        
    }
}
