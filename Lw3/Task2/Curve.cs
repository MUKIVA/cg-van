using OpenTK.Mathematics;

namespace Task2
{
    public class Curve : IDrawable, IDragDrop, IPointsCollection
    {
        private List<Vector2> _points = new();
        public Color4 Color { get; set; } = Color4.Black;
        public Color4? FillColor { get; set; } = null;
        public float LineWidth { get; set; }

        public Curve(List<Vector2> points, Color4 color, Color4? fillColor = null, float width = 0)
        {
            _points = points;
            Color = color;
            FillColor = fillColor;
            LineWidth = width;
        }

        public void AddPoint(Vector2 point)
        {
            _points.Add(point);
        }

        public void Draw(Window canvas)
        {
            canvas.DrawCurve(_points, Color, FillColor, LineWidth);
        }

        public Vector2 GetPoint(int index)
        {
            return _points[index];
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

        public void RemovePoint(int index)
        {
            _points.RemoveAt(index);
        }
    }
}
