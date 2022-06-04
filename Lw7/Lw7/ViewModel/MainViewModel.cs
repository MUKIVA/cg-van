using Lw7.Core;
using System.Windows.Input;
using Lw7.Model;
using Lw7.Mathematics;

namespace Lw7.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private RendererViewModel _rendererViewModel;
        private Renderer _rendererModel;
        private FrameBuffer _frameBufferModel;

        public MainViewModel()
        {
            //var a = Mat4d.Identity;

            _rendererModel = new Renderer();
            _frameBufferModel = new FrameBuffer(800, 600);

            _rendererViewModel = new(_rendererModel, _frameBufferModel);
        }

        public RendererViewModel RenderVM
        {
            get => _rendererViewModel;
        }





















        public ICommand ClickCommand { get; private set; }
        public string ClickCount
        {
            get
            {
                return "";
            }
        }

        //public MainViewModel()
        //{
        //    ClickCommand = new Command(OnButtonClick); 
        //}

        private void OnButtonClick(object? sender)
        { 
        }
    }
}
