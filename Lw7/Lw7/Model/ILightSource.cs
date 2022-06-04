using Lw7.Mathematics;

namespace Lw7.Model
{
    public interface ILightSource
    {
        public Vec4d DiffuseIntensity  { get; set; }
        public Vec4d SpecularIntensity { get; set; }
        public Vec4d AmbientIntensity  { get; set; }

        public void SetTransform(Mat4d transform);
        public Mat4d GetTransform();
        public double GetIntensityInDirection(Vec3d direction);
        public Vec3d GetDirectionFromPoint(Vec3d point);
    }
}
