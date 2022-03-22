using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lw2.Model;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using System.Windows.Ink;

namespace Lw2.ViewModel
{
    public class CanvasVM : BaseVM
    {
        private CanvasModel _model;

        public DrawingAttributes Style
        {
            get => _model.Style;
            set
            {
                _model.Style = value;
                NotifyPropertyChange(nameof(Style));
            }
        }

        public ImageBrush LoadImage
        {
            get => _model.LoadImage;
            set
            {
                _model.LoadImage = value; 
                NotifyPropertyChange(nameof(LoadImage));
            }
        }

        public Visibility VisibleMode
        {
            get => _model.IsVisible;
            set
            {
                _model.IsVisible = value;
                NotifyPropertyChange(nameof(VisibleMode));
            }
        }

        public int Width
        {
            get => _model.Width;
            set
            {
                _model.Width = value;
                NotifyPropertyChange(nameof(Width));
            }
        }

        public int Height
        {
            get => _model.Height;
            set
            {
                _model.Height = value;
                NotifyPropertyChange(nameof(Height));
            }
        }

        public CanvasVM(InkCanvas canvas)
        {
            _model = new CanvasModel();
        }
    }
}
