using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

namespace Task2
{
    public class LineSegment : IDrawable, IDragDrop
    {
        public Vector2 P1         { get; set; }
        public Vector2 P2         { get; set; }
        public float LineWidth    { get; set; } = 5f;
        public Color4 Color       { get; set; } = Color4.Black;

        public LineSegment(Vector2 p1, Vector2 p2, Color4? color = null, float width = 10)
        { 
            (P1, P2, LineWidth) = (p1, p2, width);
            if (color != null)
                Color = (Color4)color;
        }

        public LineSegment(Vector2 p1, Vector2 p2, Color4 color, float width = 10)
            => (P1, P2, LineWidth, Color) = (p1, p2, width, color);

        public void Draw(Window canvas)
        {
            canvas.DrawLine(P1, P2, Color, LineWidth);      
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
