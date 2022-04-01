using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Task1.DialogService;
using Task1.Model;


namespace Task1.ViewModel
{
    public class MainVM : BaseVM
    {
        public ICommand OpenImage { get; private set; }

        private ImageViewerModel _imageViewerModel;
        private IDialogService _dialogService = new DefaultDiologService();

        public MainVM()
        {
            _imageViewerModel = new ImageViewerModel();
            OpenImage = new Command(OpenImageAction);
        }

        private BitmapSource CopyImage(string filePath)
        {
            BitmapImage image = new BitmapImage(new Uri(filePath, UriKind.Absolute));

            byte[] pixels = new byte[image.PixelHeight * image.PixelWidth * 4];
            image.CopyPixels(pixels, image.PixelWidth * 4, 0);

            

            return BitmapSource
                .Create(
                image.PixelHeight,
                image.PixelHeight,
                image.DpiX,
                image.DpiY,
                image.Format,
                image.Palette,
                pixels, image.PixelWidth * 4);
        }

        private void OpenImageAction(object? sender)
        {
            try
            {
                if (_dialogService.OpenFileDialog("Files|*.jpg;*.png;"))
                    ImageData = CopyImage(_dialogService.FilePath);
            }
            catch (Exception ex)
            {
                _dialogService.ShowMessage(ex.Message);
            }
            GC.Collect();
        }

        public BitmapSource? ImageData
        {
            get => _imageViewerModel.ImageData;
            set
            {
                _imageViewerModel.ImageData = value;
                NotifyPropertyChange(nameof(ImageData));
            }
        }

    }
}
