using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

namespace Lw3
{
    public class LineSegment : IDrawable
    {
        public Point P1         { get; set; }
        public Point P2         { get; set; }
        public float LineWidth  { get; set; }
        public Color4 Color     { get; set; } = Color4.Black;

        public LineSegment(Point p1, Point p2, float width = 10)
            => (P1, P2, LineWidth) = (p1, p2, width);

        public void Draw(Window canvas)
        {
            //canvas.DrawLine(P1, P2, Color, LineWidth);       
        }
    }
}
