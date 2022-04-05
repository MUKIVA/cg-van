using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;


namespace Task2
{
    public class BrokenLine : IDrawable, IPointsCollection, IDragDrop
    {
        private List<Vector2> _points = new();
        public Color4 Color { get; set; } = Color4.Black;
        public float LineWidth { get; set; } = 5f;

        public BrokenLine(List<Vector2> points, float lineWidth = 5)
            => (_points, LineWidth) = (points, lineWidth);

        public void Draw(Window canvas)
        {
            canvas.DrawBrokenLine(_points, Color, LineWidth);
        }

        public Vector2 GetPoint(int index)
        {
            return _points[index];
        }

        public void AddPoint(Vector2 point)
        {
            _points.Add(point);
        }

        public void RemovePoint(int index)
        {
            _points.RemoveAt(index);
        }

        public void InsertPoint(Vector2 point, int index)
        {
            _points.Insert(index, point);
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
