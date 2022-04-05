using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;

namespace Task2
{
    public interface IPointsCollection
    {
        public Vector2 GetPoint(int index);
        public void AddPoint(Vector2 point);
        public void RemovePoint(int index);
        public void InsertPoint(Vector2 point, int index);
    }
}
