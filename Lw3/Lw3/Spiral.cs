using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;


namespace Lw3
{
    public static class Spiral
    {
        private static unsafe void DrawPolyline(float[] vertexes, Color4 color, float width = 5)
        {
            GL.VertexPointer(2, VertexPointerType.Float, 0, vertexes);
            GL.EnableClientState(ArrayCap.VertexArray);
            GL.Color4(color);
            GL.LineWidth(width);
            GL.DrawArrays(PrimitiveType.LineStrip, 0, vertexes.Length / 2);
            GL.DisableClientState(ArrayCap.VertexArray);
        }

        public unsafe static void Draw()
        {
            float radius = 0;
            List<float> vertexes = new List<float>();

            while (radius < MathF.PI * 10)
            {
                Vector4 point = new(
                    MathF.Cos(radius) * radius,
                    MathF.Sin(radius) * radius, 0, 1);

                vertexes.Add(point.X);
                vertexes.Add(point.Y);

                radius += MathF.PI / 24;
            }

            DrawPolyline(vertexes.ToArray(), Color4.Red, 5);
        }
    }
}
