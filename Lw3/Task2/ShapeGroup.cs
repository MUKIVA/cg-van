using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class ShapeGroup : IDragDrop, IDrawable
    {
        public readonly List<IDrawable> Shapes = new();

        public void Draw(Window canvas)
        {
            Shapes.ForEach(shape => shape.Draw(canvas));
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
