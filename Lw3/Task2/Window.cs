using System.Text.RegularExpressions;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.Common;
using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL;


namespace Task2
{
    public class Window : GameWindow
    {
        private readonly Action<object?> _debugCallback
            = (object? message) => Console.WriteLine(message);

        private List<IDrawable> _shapes = new();

        public Window(
            NativeWindowSettings nwCfg,
            Action<object?>? debugCallback = null) :
            base(GameWindowSettings.Default, nwCfg)
        {
            if (debugCallback != null)
                _debugCallback = debugCallback;

            GL.ClearColor(Color4.White);
            GL.Enable(EnableCap.PolygonStipple);
            GL.Enable(EnableCap.PointSmooth);
            GL.Enable(EnableCap.LineSmooth);
            GL.Hint(HintTarget.LineSmoothHint, HintMode.Nicest);
            GL.Enable(EnableCap.Blend);
            GL.Enable(EnableCap.Texture2D);

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
        public void DrawPolygon(List<Vector2> points, Color4 color)
        {
            float[] pointBuffer = VertexToPointBuffer(points);

            GL.VertexPointer(2, VertexPointerType.Float, 0, pointBuffer);
            GL.EnableClientState(ArrayCap.VertexArray);
                GL.Color4(color);
                GL.DrawArrays(PrimitiveType.Polygon, 0, points.Count);
            GL.DisableClientState(ArrayCap.VertexArray);
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
        public void DrawBrokenLine(List<Vector2> vertexes, Color4 color, float width = 5)
        {
            float[] pointBuffer = VertexToPointBuffer(vertexes); 

            GL.PushMatrix();
            GL.VertexPointer(2, VertexPointerType.Float, 0, pointBuffer);
            GL.EnableClientState(ArrayCap.VertexArray);
                GL.Color4(color);
                GL.LineWidth(width);
                GL.DrawArrays(PrimitiveType.LineStrip, 0, vertexes.Count / 2);
            GL.DisableClientState(ArrayCap.VertexArray);
            GL.PopMatrix();
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
        public void DrawCurve(List<Vector2> points, Color4 color, Color4? fillColor = null, float width = 5)
        {
            float t = 0.0f; float vertexFrequency = 0.00625f;
            List<float> vertexBuffer = new();
            while (MathF.Round(t, 2) <= 1.00f)
            {
                List<Vector2> _1 = points.ToList();
                List<Vector2> _2 = new();
                while (_1.Count != 1)
                {
                    for (int i = 0, j = 1; j < _1.Count; i++, j++)
                        _2.Add(Vector2.Lerp(_1[i], _1[j], t));
                    _1 = _2;
                    _2 = new();
                }

                vertexBuffer.Add(_1[0].X);
                vertexBuffer.Add(_1[0].Y);

                t += vertexFrequency;
            }

            GL.VertexPointer(2, VertexPointerType.Float, 0, vertexBuffer.ToArray());
            GL.EnableClientState(ArrayCap.VertexArray);
                GL.LineWidth(width);
                GL.PointSize(width);
                GL.Color4(color);
                GL.DrawArrays(PrimitiveType.LineStrip, 0, vertexBuffer.Count / 2);
            if (fillColor != null)
            {
                GL.Color4((Color4)fillColor);
                GL.DrawArrays(PrimitiveType.Polygon, 0, vertexBuffer.Count / 2);
            }
                
            GL.DisableClientState(ArrayCap.VertexArray);
        }
        public void DrawEllipse(Vector2 center, float rx, float ry, Color4 color)
        {
            int step = 24;
            float[] vertexBuffer = new float[4 * step];
            for (float i = 0f, j = 0; j < 4 * step - 1; i += MathF.PI / step, j += 2)
            {
                vertexBuffer[(int)j] = rx * MathF.Sin(i);
                vertexBuffer[(int)j + 1] = ry * MathF.Cos(i);
            }

            GL.PushMatrix();
            GL.Translate(center.X, center.Y, 0);
            GL.VertexPointer(2, VertexPointerType.Float, 0, vertexBuffer);
            GL.EnableClientState(ArrayCap.VertexArray);
                GL.Color4(color);
                GL.DrawArrays(PrimitiveType.Polygon, 0, vertexBuffer.Length / 2);
            GL.DisableClientState(ArrayCap.VertexArray);
            GL.PopMatrix();
        }
        protected override void OnLoad()
        {
            GL.Scale(1f / Size.X, 1f / Size.Y, 1);

            //Ноги
            _shapes.Add(new Polygon(new() 
            {
                new(160, -450),
                new(160, -650),
                new(240, -650),
                new(240, -450),
            }, new(80, 30, 112, 255)));
            _shapes.Add(new Polygon(new()
            {
                new(200, -550),
                new(100, -665),
                new(115, -725),
                new(200, -630),
                new(285, -725),
                new(300, -665),
                new(200, -550)
            }, new(80, 30, 112, 255)));
            _shapes.Add(new Polygon(new()
            {
                new(-160, -450),
                new(-160, -650),
                new(-240, -650),
                new(-240, -450),
            }, new(80, 30, 112, 255)));
            _shapes.Add(new Polygon(new()
            {
                new(-200, -550),
                new(-100, -665),
                new(-115, -725),
                new(-200, -630),
                new(-285, -725),
                new(-300, -665),
                new(-200, -550)
            }, new(80, 30, 112, 255)));
            _shapes.Add(new Polygon(new()
            {
                new(-180, -650),
                new(-220, -650),
                new(-270, -725),
                new(-130, -725)
            }, new(80, 30, 112, 255)));
            _shapes.Add(new Polygon(new()
            {
                new(180, -650),
                new(220, -650),
                new(270, -725),
                new(130, -725)
            }, new(80, 30, 112, 255)));
            // Тело
            _shapes.Add(new Ellipse(new(0, 0), 525, 525, new(80, 30, 112, 255))); 
            _shapes.Add(new Ellipse(new(0, 0), 500, 500, new(148, 96, 165, 255))); 
            _shapes.Add(new Curve(new() // Тень
            {
                new(-500, 0),
                new(-500, -500),
                new(100, -590),
                new(250, -425),
            }, new(126, 72, 148, 255), new(126, 72, 148, 255)));
            _shapes.Add(new Curve(new()
            {
                new(-500, 0),
                new(-375, -325),
                new(-75, -525),
                new(250, -425),
            }, new(126, 72, 148, 255), new(148, 96, 165, 255)));
            _shapes.Add(new Ellipse(new(0, 400), 300, 100, new(80, 30, 112, 255)));
            _shapes.Add(new Curve(new()
            {
                new(-325, 375),
                new(-100, 500),
                new(50, 200)
            }, new(148, 96, 165, 255), new(148, 96, 165, 255)));
            _shapes.Add(new Curve(new()
            {
                new(325, 375),
                new(100, 500),
                new(-50, 200)
            }, new(148, 96, 165, 255), new(148, 96, 165, 255)));
            // Глаза
            _shapes.Add(new Ellipse(new(100, 100), 125, 175, new(80, 30, 112, 255))); 
            _shapes.Add(new Ellipse(new(-100, 100), 125, 175, new(80, 30, 112, 255)));
            _shapes.Add(new Ellipse(new(-100, 100), 100, 150, Color4.White)); 
            _shapes.Add(new Ellipse(new(100, 100), 100, 150, Color4.White));
            _shapes.Add(new Curve(new()
            {
                new(-200, 100),
                new(-200, 300),
                new(-0, 300),
                new(0, 100),
            }, new(126, 72, 148, 255), new(148, 96, 165, 255)));
            _shapes.Add(new Curve(new()
            {
                new(-200, 100),
                new(-200, 200),
                new(-0, 200),
                new(0, 100),
            }, new(126, 72, 148, 255), Color4.White));
            _shapes.Add(new Curve(new()
            {
                new(200, 100),
                new(200, 300),
                new(0, 300),
                new(0, 100),
            }, new(126, 72, 148, 255), new(148, 96, 165, 255)));
            _shapes.Add(new Curve(new()
            {
                new(200, 100),
                new(200, 200),
                new(0, 200),
                new(0, 100),
            }, new(126, 72, 148, 255), Color4.White));
            _shapes.Add(new Ellipse(new(30, 100), 25, 40, Color4.Black));
            _shapes.Add(new Ellipse(new(-30, 100), 25, 40, Color4.Black));
            //Клюв
            _shapes.Add(new Ellipse(new(0, -30), 60, 100, new(160, 3, 91, 255)));
            _shapes.Add(new Ellipse(new(0, -30), 45, 85, new(234, 102, 8, 255)));
            _shapes.Add(new LineSegment(new(-45, -40), new(-20, -20), new(160, 3, 91, 255), 5));
            _shapes.Add(new LineSegment(new(20, -20), new(45, -40), new(160, 3, 91, 255), 5));
            _shapes.Add(new Curve(new() 
            {
                new(-20, -20),
                new(0, -40),
                new(20, -20),
            }, new(160, 3, 91, 255), null, 5));
            //Уши
            _shapes.Add(new Triangle(new(325, 400), new(650, 550), new(475, 200), new(80, 30, 112, 255)));
            _shapes.Add(new Triangle(new(-325, 400), new(-650, 550), new(-475, 200), new(80, 30, 112, 255)));
            _shapes.Add(new Triangle(new(300, 350), new(625, 525), new(450, 200), new(148, 96, 165, 255)));
            _shapes.Add(new Triangle(new(-300, 350), new(-625, 525), new(-450, 200), new(148, 96, 165, 255)));
            //Руки
            _shapes.Add(new Curve(new() 
            {
                new(520, 0),
                new(400, -450),
                new(530, -600),
                new(800, -450),
                new(600, -400),
                new(520, 0)
            }, new(80, 30, 112, 255), new(148, 96, 165, 255), 0));
            _shapes.Add(new Curve(new()
            {
                new(-520, 0),
                new(-400, -450),
                new(-530, -600),
                new(-800, -450),
                new(-600, -400),
                new(-520, 0)
            }, new(80, 30, 112, 255), new(148, 96, 165, 255), 0));

            base.OnLoad();
        }
        protected override void OnResize(ResizeEventArgs e)
        {
            GL.Viewport(0, 0, e.Width, e.Height);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.LoadIdentity();
            GL.Scale(1f / Size.X, 1f / Size.Y, 1);

            DrawShapeData();

            SwapBuffers();
            base.OnResize(e);
        }
        protected override void OnRenderFrame(FrameEventArgs args)
        {
            GL.Viewport(0, 0, Size.X, Size.Y);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.LoadIdentity();
            GL.Scale(1f / Size.X, 1f / Size.Y, 1);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            DrawShapeData();

            SwapBuffers();
            base.OnRenderFrame(args);
        }
        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
        }
        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            _debugCallback(MousePosition);
            

            base.OnMouseDown(e);    
        }
        protected override void OnMouseMove(MouseMoveEventArgs e)
        {
            //_debugCallback(nameof(OnMouseMove));
            base.OnMouseMove(e);
        }
        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            _debugCallback(nameof(OnMouseUp));
            base.OnMouseUp(e);
        }

        [Obsolete]
        protected override void OnMonitorConnected(MonitorEventArgs e)
        {
            GL.Viewport(0, 0, Size.X, Size.Y);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.LoadIdentity();
            GL.Scale(1f / Size.X, 1f / Size.Y, 1);

            DrawShapeData();

            base.OnMonitorConnected(e);
        }
        private float[] VertexToPointBuffer(List<Vector2> vectors)
        {
            float[] buffer = new float[vectors.Count * 2];
            for (int i = 0, j = 1, vector = 0; vector < vectors.Count; vector++, i += 2, j += 2)
            {
                buffer[i] = vectors[vector].X;
                buffer[j] = vectors[vector].Y;
            }
            return buffer;
        }
        private void DrawShapeData()
        {
            _shapes.ForEach(shape => shape.Draw(this));
        }
    }
}
