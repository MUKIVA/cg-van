using Lw7.Mathematics;

namespace Lw7.Model
{
    public struct Ray
    {
        private Vec3d _start;
        private Vec3d _direction;

        public Ray(Vec3d start, Vec3d direction)
        {
            _start = start;
            _direction = direction;
        }

        public Vec3d GetPointAtTime(double time)
        {
            return _start + _direction * time;
        }

        public void Transform(Mat4d matrix)
        {
            _start = (new Vec4d(Start.X, _start.Y, _start.Z, 1.0d) * matrix).Project();
            _direction = (new Vec4d(Direction.X, Direction.Y, Direction.Z, 0) * matrix).XYZ;
        }

        public Vec3d Start => _start;
        public Vec3d Direction => _direction;
    }
}
