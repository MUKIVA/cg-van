using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Lw2.DialogService;
using System.Windows.Media.Imaging;
using System.IO;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows;

namespace Lw2.ViewModel
{
    public class MainVM : BaseVM
    {
        public ICommand CreateNew { get; private set; }
        public ICommand LoadPicture { get; private set; }
        public ICommand SavePicture { get; private set; }
        public ICommand SetNewColor { get; private set; }
        
        public CanvasVM CanvasContext { get; private set; }

        private double _scaleX = 1;
        private double _scaleY = 1;

        private const int BASE_WIDTH = 800;
        private const int BASE_HEIGHT = 600;

        private double _dpiX = 96;
        private double _dpiY = 96;

        private Action _clearAction;
        private Func<RenderTargetBitmap> _getRenderTargetBitmap;

        private IDialogService _dialogService = new DefaultDiologService();

        public double ScaleX
        {
            get => _scaleX;
            set
            {
                _scaleX = value;
                NotifyPropertyChange(nameof(ScaleX));
            }
        }

        public double ScaleY
        {
            get => _scaleY;
            set
            {
                _scaleY = value;
                NotifyPropertyChange(nameof(ScaleY));
            }
        }

        public MainVM(InkCanvas canvas)
        {
            _clearAction = canvas.Strokes.Clear;
            CanvasContext = new CanvasVM(canvas); 
            LoadPicture = new Command(LoadPictureAction);
            SavePicture = new Command(SavePictureAction, x => CanvasContext.VisibleMode == Visibility.Visible);
            CreateNew = new Command(CreateNewAction);
            SetNewColor = new Command(SetNewColorAction);
            _getRenderTargetBitmap = () => GetRenderTarget(canvas);
        }

        private RenderTargetBitmap GetRenderTarget(InkCanvas canvas)
        {
            RenderTargetBitmap bitmap
                        = new RenderTargetBitmap(
                            (int)(CanvasContext.Width / _scaleX), 
                            (int)(CanvasContext.Height / _scaleY),
                            _dpiX, 
                            _dpiY, 
                            PixelFormats.Default);
            bitmap.Render(canvas);

            return bitmap;
        }

        public void SetNewColorAction(object? sender)
        {
            Button? btn = sender as Button;
            if (btn == null) return;

            Brush color = btn.Background;

            if (color is SolidColorBrush)
            {
                CanvasContext.Style.Color = ((SolidColorBrush)color).Color;
            }
        }

        public void CreateNewAction(object? sender)
        {
            _clearAction();
            CanvasContext.Width = 800;
            CanvasContext.Height = 600;
            (_dpiX, _dpiY) = (96, 96);
            CanvasContext.VisibleMode = Visibility.Visible;
        }

        public void SavePictureAction(object? sender)
        {
            try
            {
                if (_dialogService.SaveFileDialog("Files|*.jpg;*.png;"))
                {
                    string filePath = _dialogService.FilePath;

                    PngBitmapEncoder encoder = new PngBitmapEncoder();

                    encoder.Frames.Add(BitmapFrame.Create(_getRenderTargetBitmap()));

                    using (FileStream sw = new FileStream(filePath, FileMode.Create))
                    { 
                        encoder.Save(sw);
                    }

                }
            }
            catch (Exception ex)
            {
                _dialogService.ShowMessage(ex.Message);
            }
        }

        public void LoadPictureAction(object? sender)
        {
            _clearAction();
            try
            {
                if (_dialogService.OpenFileDialog("Files|*.jpg;*.png;"))
                {
                    string filePath = _dialogService.FilePath;

                    ImageBrush brush = new ImageBrush();
                    brush.ImageSource = new BitmapImage(new Uri(filePath, UriKind.Absolute));

                    var image = new BitmapImage();
                    image.BeginInit();
                    image.UriSource = new Uri(filePath);
                    image.EndInit();

                    byte[] pixels = new byte[image.PixelHeight * image.PixelWidth * 4];

                    ScaleX = BASE_WIDTH / image.Width;
                    ScaleY = BASE_HEIGHT / image.Height;

                    _dpiX = image.DpiX;
                    _dpiY = image.DpiY;

                    CanvasContext.Width = (int)(image.Width * ScaleX);
                    CanvasContext.Height = (int)(image.Height * ScaleY);
                    CanvasContext.LoadImage = brush;
                    CanvasContext.VisibleMode = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                _dialogService.ShowMessage(ex.Message);
            }
        }
    }   
}
