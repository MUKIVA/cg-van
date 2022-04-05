using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.Common;
using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL;

namespace Lw3
{
    public class Window : GameWindow
    {
        private readonly Action<object?> _debugCallback
            = (object? message) => Console.WriteLine(message);

        private Matrix2 _lineScale;
        private float _graphScale = 20.0f;

        public Window(
            NativeWindowSettings nwCfg,
            Action<object?>? debugCallback = null) :
            base(GameWindowSettings.Default, nwCfg)
        {
            if (debugCallback != null)
                _debugCallback = debugCallback;

            GL.ClearColor(Color4.White);
            GL.Enable(EnableCap.PointSprite);
            GL.Hint(HintTarget.LineSmoothHint, HintMode.Nicest);
            GL.Enable(EnableCap.Blend);

            PrintDeviceInfo();
        }
        private void PrintDeviceInfo()
        {
            _debugCallback(GL.GetString(StringName.Version));
            _debugCallback(GL.GetString(StringName.Vendor));
            _debugCallback(GL.GetString(StringName.Renderer));
            _debugCallback(GL.GetString(StringName.ShadingLanguageVersion));
        }
        public void PrintDeviceInfo(Action<string> printCallback)
        {
            printCallback(GL.GetString(StringName.Version));
            printCallback(GL.GetString(StringName.Vendor));
            printCallback(GL.GetString(StringName.Renderer));
            printCallback(GL.GetString(StringName.ShadingLanguageVersion));
        }
        public void DrawLine(Vector2 from, Vector2 to, Color4 color, float width = 5)
        {
            var _ = new float[] { from.X, from.Y, to.X, to.Y };

            GL.VertexPointer(2, VertexPointerType.Float, 0, _);
            GL.EnableClientState(ArrayCap.VertexArray);
                GL.LineWidth(width);
                GL.Color4(color);
                GL.DrawArrays(PrimitiveType.Lines, 0, 2);
            GL.DisableClientState(ArrayCap.VertexArray);
            GC.SuppressFinalize(_);
        }
        public void DrawBrokenLine(float[] vertexes, Color4 color, float width = 5)
        {
            GL.PushMatrix();
            GL.VertexPointer(2, VertexPointerType.Float, 0, vertexes);
            GL.EnableClientState(ArrayCap.VertexArray);
                GL.Color4(color);
                GL.LineWidth(width);
                GL.DrawArrays(PrimitiveType.LineStrip, 0, vertexes.Length / 2);
            GL.DisableClientState(ArrayCap.VertexArray);
            GL.PopMatrix();
        }
        protected override void OnLoad()
        {
            GL.MatrixMode(MatrixMode.Modelview0Ext);
            GL.Scale(1f / Size.X, 1f / Size.Y, 1);
            base.OnLoad();
        }
        public void DrawPoint(Vector2 point, Color4 color, float size = 5)
        {
            var _ = new float[] { point.X, point.Y };
            GL.VertexPointer(2, VertexPointerType.Float, 0, _);
            GL.EnableClientState(ArrayCap.VertexArray);
                GL.PointSize(size);
                GL.Color4(color);
                GL.DrawArrays(PrimitiveType.Points, 0, 1);
            GL.DisableClientState(ArrayCap.VertexArray);
            GC.SuppressFinalize(_);
        }
        public void DrawTriangle(Vector2 p1, Vector2 p2, Vector2 p3, Color4 color)
        {
            var _ = new float[] { p1.X, p1.Y, p2.X, p2.Y, p3.X, p3.Y };

            GL.VertexPointer(2, VertexPointerType.Float, 0, _);
            GL.EnableClientState(ArrayCap.VertexArray);
                GL.Color4(color);
                GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
            GL.DisableClientState(ArrayCap.VertexArray);
            GC.SuppressFinalize(_);
        }
        private void DrawCoordsLine()
        {
            DrawLine(new(0f, -Size.Y + 50), new(0f, Size.Y - 50), Color4.Black);
            DrawTriangle(
                new(0, Size.Y),
                new(-25, Size.Y - 50),
                new(25, Size.Y - 50),
                Color4.Black
            );

            DrawLine(new(-Size.X + 50, 0f), new(Size.X - 50, 0f), Color4.Black);
            DrawTriangle(
                new(Size.X, 0f),
                new(Size.X - 50, -25),
                new(Size.X - 50, 25),
                Color4.Black
            );
        }
        private void DrawSpiral()
        {
            float radius = 0;
            List<float> vertexes = new List<float>();

            while (radius < MathF.PI * 10)
            {
                Vector4 point = new(radius, 0, 0, 1);

                point *= Matrix4.CreateScale(_graphScale, _graphScale, 1);
                point *= Matrix4.CreateRotationZ(radius);

                vertexes.Add(point.X);
                vertexes.Add(point.Y);

                radius += MathF.PI / 24;
            }

            DrawBrokenLine(vertexes.ToArray(), Color4.Red, 5);
        }
        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            //if (_graphScale > 1f || e.OffsetY > 0)   
                _graphScale += e.OffsetY;

            base.OnMouseWheel(e);
        }
        private float GetOffset()
        {
            return MathF.PI / (6 * ((int)_graphScale / 100));
        }
        private void DrawCoordsPoint(float height = 10f)
        {
            var offset = GetOffset();
            for (float x = 0; x * _graphScale < Size.X - 50; x += offset)
            {
                if (x == float.PositiveInfinity)
                    break;
                DrawLine(
                    new Vector2(x, height) * Matrix2.CreateScale(_graphScale, 1), 
                    new Vector2(x, -height) * Matrix2.CreateScale(_graphScale, 1), Color4.Black, 2 / _graphScale);
                DrawLine(
                    new Vector2(-x, height) * Matrix2.CreateScale(_graphScale, 1), 
                    new Vector2(-x, -height) * Matrix2.CreateScale(_graphScale, 1), Color4.Black, 2 / _graphScale);
            }
            for (float y = 0; y * _graphScale < Size.Y - 50; y += offset)
            {
                if (y == float.PositiveInfinity)
                    break;
                DrawLine(
                    new Vector2(height, y) * Matrix2.CreateScale(1, _graphScale), 
                    new Vector2(-height, y) * Matrix2.CreateScale(1, _graphScale), Color4.Black, 2 / _graphScale);
                DrawLine(
                    new Vector2(height, -y) * Matrix2.CreateScale(1, _graphScale), 
                    new Vector2(-height, -y) * Matrix2.CreateScale(1, _graphScale), Color4.Black, 2 / _graphScale);
            }
        }
        private void Draw()
        {
            DrawCoordsLine();
            DrawCoordsPoint();
            DrawSpiral();
        }
        protected override void OnRenderFrame(FrameEventArgs args)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            Draw();

            SwapBuffers();
            base.OnRenderFrame(args);
        }
        protected override void OnResize(ResizeEventArgs e)
        {
            GL.Viewport(0, 0, e.Width, e.Height);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.LoadIdentity();
            GL.Scale(1f / Size.X, 1f / Size.Y, 1);


            Draw();

            SwapBuffers();
            base.OnResize(e);
        }
    }
}
