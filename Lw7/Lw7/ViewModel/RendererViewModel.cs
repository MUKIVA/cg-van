using Lw7.Core;
using System.Windows.Media.Imaging;
using System.Threading.Tasks;
using Lw7.Model;
using System.Windows.Media;
using System;
using Lw7.Mathematics;

namespace Lw7.ViewModel
{
    public class RendererViewModel : BaseViewModel
    {
        private Renderer _rendererModel;
        private FrameBuffer _frameBufferModel;
        private RenderContext _contextModel = new();
        private Scene _sceneModel = new();

        private CheckerShader _planeShader = new();
        private LightShader _sph1Shader = new();
        private LightShader _sph2Shader = new();
        private LightShader _tor1Shader = new();
        private LightShader _tor2Shader = new();
        private LightShader _tor3Shader = new();
        private LightShader _tor4Shader = new();
        private ReflectShader _reflShader = new();

        private Plane _planeModel = new(0, 1, 0, 1);
        private Sphere _sphere1 = new(1.5, new(0, 0, 0), Mat4d.Identity);
        private Sphere _sphere2 = new(0.5, new(0, 0, 0), Mat4d.Identity);
        private Sphere _sphere3 = new(0.5, new(0, 0, 0), Mat4d.Identity);
        private Torus _tor1 = new(1.0, 0.4, new(0, 0, 0), Mat4d.Identity);
        private Torus _tor2 = new(0.9, 0.3, new(0, 0.5, 0), Mat4d.Identity);
        private Torus _tor3 = new(0.8, 0.2, new(0, 1, 0), Mat4d.Identity);
        private Torus _tor4 = new(0.7, 0.15, new(0, 1.32, 0), Mat4d.Identity);

        public RendererViewModel(Renderer renderer, FrameBuffer frameBuffer)
        {

            _rendererModel = renderer;
            _frameBufferModel = frameBuffer;

            _sceneModel.SetBackdropColor(new(0.52, 0.8, 0.9, 1));

            Mat4d planeTransform = Mat4d.CreateRotationX((-0d * Math.PI) / 180d);
            _planeModel.SetTransform(planeTransform);

            Mat4d checkerShaderTransform = Mat4d.CreateTranslation(0.25, 0.25, 0.25);
            _planeShader.SetTextureTransform(checkerShaderTransform);


            LightShaderMaterial planeMaterial = new();
            //planeMaterial.AmbientColor  = new(0.5, 0.5, 0.5, 1);
            //planeMaterial.SpecularColor = new(0, 0, 0, 0);
            //planeMaterial.DiffuseColor = new(0.5, 0.5, 0.5, 1);
            //_planeShader.SetMaterial(planeMaterial);

            _sceneModel.AddObject(new SceneObject(_planeModel, _planeShader));
            //tor
            {
                LightShaderMaterial material1 = new();
                material1.DiffuseColor = new(0.0, 0.50980392, 0.50980392, 1);
                material1.SpecularColor = new(0.50196078, 0.50196078, 0.50196078, 1);
                material1.AmbientColor = new(0.0, 0.3, 0.3, 1);
                material1.Shinines = 32;

                _tor1Shader.SetMaterial(material1);
                _sceneModel.AddObject(new SceneObject(_tor1, _tor1Shader));
                material1 = new();
                material1.DiffuseColor = new(0.1, 0.35, 0.1, 1);
                material1.SpecularColor = new(0.45, 0.55, 0.45, 1);
                material1.AmbientColor = new(0.05, 0.2, 0.05, 1);
                material1.Shinines = 32;
                _tor2Shader.SetMaterial(material1);
                _sceneModel.AddObject(new SceneObject(_tor2, _tor2Shader));
                material1 = new();
                material1.DiffuseColor = new(0.5, 0.0, 0.0, 1);
                material1.SpecularColor = new(0.7, 0.6, 0.6, 1);
                material1.AmbientColor = new(0.2, 0.0, 0.0, 1);
                material1.Shinines = 32;
                _tor3Shader.SetMaterial(material1);
                _sceneModel.AddObject(new SceneObject(_tor3, _tor3Shader));
                material1 = new();
                material1.DiffuseColor = new(0.55, 0.55, 0.55, 1);
                material1.SpecularColor = new(0.70, 0.70, 0.70, 1);
                material1.AmbientColor = new(0.3, 0.3, 0.3, 1);
                material1.Shinines = 32;
                _tor4Shader.SetMaterial(material1);
                _sceneModel.AddObject(new SceneObject(_tor4, _tor4Shader));

                //_sceneModel.AddObject(new SceneObject(_tor3, _tor1Shader));
                //_sceneModel.AddObject(new SceneObject(_tor4, _tor1Shader));
            }

            // Sphere 1
            { 
                Mat4d sphereTransform = Mat4d.Identity;
                sphereTransform *= Mat4d.CreateScale(0.4, 0.4, 0.4);
                sphereTransform *= Mat4d.CreateTranslation(0, 1.5, -0);
                _sphere1.SetTransform(sphereTransform);

                LightShaderMaterial material1 = new();
                material1.DiffuseColor = new(0.3, 0.5, 0.4, 1);
                material1.SpecularColor = new(1, 0, 1, 1);
                material1.AmbientColor = new(0.2, 0, 0.2, 1);

                _sph1Shader.SetMaterial(material1);
                _sceneModel.AddObject(new SceneObject(_sphere1, _sph1Shader));
            }

            // Sphere 2
            {
                Mat4d sphereTransform = Mat4d.Identity;
                sphereTransform *= Mat4d.CreateTranslation(0, 0, -3.5);
                _sphere2.SetTransform(sphereTransform);

                LightShaderMaterial material2 = new();
                material2.AmbientColor = new(0.0, 0.05, 0.0, 1);
                material2.SpecularColor = new(0.04, 0.7, 0.04, 1);
                material2.DiffuseColor = new(0.4, 0.4, 0.4, 1);
                material2.Shinines = 3.6;

                _sph2Shader.SetMaterial(material2);
                //_sceneModel.AddObject(new SceneObject(_sphere2, _sph2Shader));
            }

            // Sphere 3
            {
                Mat4d sphereTransform = Mat4d.Identity;
                sphereTransform *= Mat4d.CreateTranslation(1.7, 1.2, 0);
                _sphere3.SetTransform(sphereTransform);

                _sceneModel.AddObject(new SceneObject(_sphere3, _reflShader));
            }

            {
                OmniLightSource light = new(new(3, 5, -3), Mat4d.Identity);
                light.DiffuseIntensity = new Vec4d(1, 1, 1, 1);
                light.SpecularIntensity = new Vec4d(1, 1, 1, 1);
                light.AmbientIntensity = new Vec4d(1, 1, 1, 1);
                _sceneModel.AddLightSource(light);
            }

            _contextModel.SetViewPort(new ViewPort(0, 0, (int)_frameBufferModel.Width, (int)_frameBufferModel.Height));

            double aspect = (double)_frameBufferModel.Width / _frameBufferModel.Height;

            Mat4d proj = Mat4d.Perspective(60, aspect, 0.1, 10);
            _contextModel.SetProjectionMatrix(proj);
            _contextModel.SetModelViewMatrix(Mat4d.LookAtRH(
                new(0, 2, -5), 
                new(0, 1, 0), 
                new(0, 1, 0)));

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
                _rendererModel.Render(_sceneModel, _contextModel, _frameBufferModel);
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
