using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;
using OpenTK.Graphics;


namespace Task2
{
    public class Triangle : IDrawable, IDragDrop
    {
        public Vector2 P1 { get; set; }
        public Vector2 P2 { get; set; }
        public Vector2 P3 { get; set; }
        public Color4 Color { get; set; } = Color4.Black;

        public Triangle(Vector2 p1, Vector2 p2, Vector2 p3, Color4? color = null)
        { 
            (P1, P2, P3) = (p1, p2, p3);
            if (color != null)
                Color = (Color4)color;
        }

        public void Draw(Window canvas)
        {
            canvas.DrawTriangle(P1, P2, P3, Color);
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
