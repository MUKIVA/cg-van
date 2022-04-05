using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;

namespace Task2
{
    public class Ellipse : IDrawable, IDragDrop
    {
        public float RadiusX { get; set; } = 5;
        public float RadiusY { get; set; } = 5;
        public Color4 Color { get; set; } = Color4.Black;
        public Vector2 Center { get; set; }

        public Ellipse(Vector2 center, float radiusX, float radiusY, Color4? color = null)
        {
            RadiusX = radiusX;
            RadiusY = radiusY;
            Center = center;
            if (color != null)
                Color = (Color4)color;
        }

        public void Draw(Window canvas)
        {
            canvas.DrawEllipse(Center, RadiusX, RadiusY, Color);
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
