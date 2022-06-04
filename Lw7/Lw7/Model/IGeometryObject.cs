using Lw7.Mathematics;

namespace Lw7.Model
{
    public interface IGeometryObject
    {
        public Mat4d GetTransform();
        public void SetTransform(Mat4d transform);
        public bool Hit(Ray ray, Intersection intersection);
    }
}
