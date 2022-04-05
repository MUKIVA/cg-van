using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;

namespace Task2
{
    public class Point : IDrawable, IDragDrop
    {
        public Vector2 P        { get; set; }
        public Color4 Color     { get; set; } = Color4.Black;
        public float Size       { get; set; } = 5f;


        public Point(Vector2 point, float size = 10)
            => (P, Size) = (point, size);

        public void Draw(Window canvas)
        {
            canvas.DrawPoint(P, Color, Size);
        }

        public void OnMouseDown()
        {
            throw new NotImplementedException();
        }

        public void OnMouseMove()
        {
            throw new NotImplementedException();
        }

        public void OnMouseUp()
        {
            throw new NotImplementedException();
        }
    }
}
