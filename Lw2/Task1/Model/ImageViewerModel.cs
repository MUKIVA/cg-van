using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Task1.Model
{
    public class ImageViewerModel
    {
        private BitmapSource? _imageData = null;

        public BitmapSource? ImageData
        {
            get => _imageData;
            set => _imageData = value;
        }
    }
}
