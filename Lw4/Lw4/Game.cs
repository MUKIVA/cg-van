using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Lw4
{
    public class Game : GameWindow
    {
        private const float FIELD_OF_VIEW = 60f * (float)Math.PI / 180f;
        private const float CUBE_SIZE = 1;

        private const float Z_NEAR = 0.1f;
        private const float Z_FAR = 10f;

        private bool _leftMouseBtnPressed = false;

        private static float _ = 0;

        private Matrix4 _cameraMatrix = Matrix4.LookAt(
            new(0, 0, 2),
            new(0, 0, 0),
            new(0, 2, 0));

        private Cube _shape = new Cube();

        public Game(NativeWindowSettings cfg)
            : base(GameWindowSettings.Default, cfg)
        {
            _shape.SetSideColor(CubeSide.NEGATIVE_X, new(1, 0, 0, 1));
            _shape.SetSideColor(CubeSide.POSITIVE_X, new(0, 1, 0, 1));
            _shape.SetSideColor(CubeSide.NEGATIVE_Y, new(0, 0, 1, 1));
            _shape.SetSideColor(CubeSide.POSITIVE_Y, new(1, 1, 0, 1));
            _shape.SetSideColor(CubeSide.NEGATIVE_Z, new(0, 1, 1, 1));
            _shape.SetSideColor(CubeSide.POSITIVE_Z, new(1, 0, 1, 1));
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            GL.ClearColor(1, 1, 1, 1);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            GL.PushMatrix();
            Draw();
            GL.PopMatrix();

            SwapBuffers();

            base.OnRenderFrame(args);
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            GL.Viewport(0, 0, e.Width, e.Height);

            float aspect = (float)e.Width / (float)e.Height;
            GL.MatrixMode(MatrixMode.Projection);
            var proj = Matrix4.CreatePerspectiveFieldOfView(FIELD_OF_VIEW, aspect, Z_NEAR, Z_FAR);
            GL.LoadMatrix(ref proj);
            GL.MatrixMode(MatrixMode.Modelview);

            base.OnResize(e);
        }

        protected override void OnLoad()
        {
            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.Light1);
            GL.Enable(EnableCap.CullFace);
            GL.CullFace(CullFaceMode.Back);
            GL.FrontFace(FrontFaceDirection.Ccw);
            GL.Enable(EnableCap.DepthTest);

            DirectLight light = new(new(0, 0, 1));
            light.SetDiffuseIntensity(new(0.5f, 0.5f, 0.5f, 1f));
            light.SetAmbientIntensity(new(0.3f, 0.3f, 0.3f, 1.0f));
            light.SetSpecularIntensity(new(1.0f, 1.0f, 1.0f, 1.0f));
            light.Apply(LightName.Light1);
            
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButton.Button1)
            {
                _leftMouseBtnPressed = true;
            }
        }

        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButton.Button1)
            {
                _leftMouseBtnPressed = false;
            }
        }

        protected override void OnMouseLeave()
        {
            base.OnMouseLeave();
            _leftMouseBtnPressed = false;
        }

        protected override void OnMouseMove(MouseMoveEventArgs e)
        {
            base.OnMouseMove(e);
            if (_leftMouseBtnPressed)
            {
                float xAngle = e.DeltaY * MathF.PI / Size.Y;
                float yAngle = e.DeltaX * MathF.PI / Size.X;
                RotateCamera(xAngle, yAngle);
            }
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
        }

        private void RotateCamera(float xAngle, float yAngle)
        {
            Vector3 xAxis = new(_cameraMatrix.M11, _cameraMatrix.M21, _cameraMatrix.M31);
            Vector3 yAxis = new(_cameraMatrix.M12, _cameraMatrix.M22, _cameraMatrix.M32);

            _cameraMatrix = _cameraMatrix.Rotate(xAngle, xAxis);
            _cameraMatrix = _cameraMatrix.Rotate(yAngle, yAxis);

            _cameraMatrix = Orthonormalize(_cameraMatrix);
        }

        private void Draw()
        {
            GL.ClearColor(Color4.White);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            SetupCameraMatrix();

            _shape.Draw();
        }

        private void SetupCameraMatrix()
        {
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref _cameraMatrix);
        }

        private Matrix4 Orthonormalize(Matrix4 m)
        {
            Matrix3 normalizedMatrix = new Matrix3(m).Orthonormalize();
            Matrix4 result = new Matrix4(normalizedMatrix);
            result.Row3 = m.Row3;
            result.Column3 = m.Column3;
            return result;
        }
    }
}
