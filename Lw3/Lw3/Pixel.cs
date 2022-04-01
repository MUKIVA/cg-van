using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;

namespace Lw3
{
    public class Pixel : IDrawable
    {
        public Point P      { get; set; }
        public Color4 Color { get; set; } = Color4.Black;
        public float Size   { get; set; }


        public Pixel(Point point, float size = 10)
            => (P, Size) = (point, size);

        public void Draw(Window canvas)
        {
            //canvas.DrawPoint(P, Color, Size);
        }
    }
}
