using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;


namespace Lw3
{
    public class Triangle : IDrawable
    {
        public Point P1 { get; set; }
        public Point P2 { get; set; }
        public Point P3 { get; set; }
        public Color4 Color { get; set; } = Color4.Black;

        public Triangle(Point p1, Point p2, Point p3) =>
            (P1, P2, P3) = (p1, p2, p3);

        public void Draw(Window canvas)
        {
            //canvas.DrawTriangle(P1, P2, P3, Color);       
        }
    }
}
