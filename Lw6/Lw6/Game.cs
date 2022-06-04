using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Graphics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Lw6
{
    public class Game : GameWindow
    {
        private float[] _vert = new float[] 
        {
            //pos              
            -1.0f, -1.0f, 1.0f,
             1.0f,  1.0f, 1.0f,
            -1.0f,  1.0f, 1.0f,
            -1.0f, -1.0f, 1.0f,
             1.0f, -1.0f, 1.0f,
             1.0f,  1.0f, 1.0f,
        };

        private int _vbo = 0;
        private int _vao = 0;
        private Shader _shader;
        private Texture _color;
        private double _scale = 3;
        private Vector2d _offset = Vector2.Zero;
        private double _moveSpeed = 1f;
        private double _resolution = 25;
        private double _colorOffset = 0;
        private double _iterationColorOffset = 0;


        public Game(NativeWindowSettings cfg)
            : base(GameWindowSettings.Default, cfg)
        {
            var _ = Matrix4.CreateRotationY(3);
            _shader = new(@"C:\DEV\CG\cg-van\Lw6\Lw6\Shaders\shader.vert", @"C:\DEV\CG\cg-van\Lw6\Lw6\Shaders\shader.frag");
            _color = Texture.LoadFromFile(@"C:\DEV\CG\cg-van\Lw6\Lw6\Textures\color.png");
        }

        protected override void OnLoad()
        {
            GL.ClearColor(Color4.Indigo);

            _vbo = GL.GenBuffer();
            _vao = GL.GenVertexArray();

            GL.BindVertexArray(_vao);

            GL.BindBuffer(BufferTarget.ArrayBuffer, _vbo);
            GL.BufferData(BufferTarget.ArrayBuffer, _vert.Length * sizeof(float), _vert, BufferUsageHint.StaticDraw);

            int posLocation = _shader.GetAttribLocation("aPos");
            GL.EnableVertexAttribArray(posLocation);
            GL.VertexAttribPointer(posLocation, 3, VertexAttribPointerType.Float, false, 0 * sizeof(float), 0);

            base.OnLoad();
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            GL.BindVertexArray(_vao);
            _shader.Use();
            _color.Use(TextureUnit.Texture0);
            _shader.SetInt("uColor", 0);
            _shader.SetInt("uIterCount", (int)_resolution);
            _shader.SetDouble("uXOffset", _offset.X);
            _shader.SetDouble("uYOffset", _offset.Y);
            _shader.SetDouble("uScale", _scale);
            _shader.SetDouble("uColorOffset", _colorOffset);
            _shader.SetDouble("uIterationColorOffset", _iterationColorOffset);
            GL.DrawArrays(PrimitiveType.Triangles, 0, 6);

            SwapBuffers();
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
            if (KeyboardState.IsKeyDown(Keys.LeftAlt)
                && KeyboardState.IsKeyDown(Keys.Up))
                _iterationColorOffset += 0.1f;
            if (KeyboardState.IsKeyDown(Keys.LeftAlt)
                && KeyboardState.IsKeyDown(Keys.Down))
                _iterationColorOffset -= 0.1f;

            if (KeyboardState.IsKeyDown(Keys.W))
                _offset.Y += _moveSpeed * _scale * args.Time;
            if (KeyboardState.IsKeyDown(Keys.S))
                _offset.Y -= _moveSpeed * _scale * args.Time;
            if (KeyboardState.IsKeyDown(Keys.D))
                _offset.X += _moveSpeed * _scale * args.Time;
            if (KeyboardState.IsKeyDown(Keys.A))
                _offset.X -= _moveSpeed * _scale * args.Time;

            if (KeyboardState.IsKeyDown(Keys.Left))
                _colorOffset -= 0.001f;
            if (KeyboardState.IsKeyDown(Keys.Right))
                _colorOffset += 0.001f;

            if (KeyboardState.IsKeyDown(Keys.LeftAlt))
                return;


            if (KeyboardState.IsKeyDown(Keys.Up))
                _resolution += 5;
            if (KeyboardState.IsKeyDown(Keys.Down))
                _resolution -= 5;




        }

        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            _scale -= e.OffsetY * _scale;
            Console.WriteLine(_scale);
            base.OnMouseWheel(e);
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            GL.Viewport(0, 0, e.Width, e.Height );

            base.OnResize(e);
        }
    }
}
