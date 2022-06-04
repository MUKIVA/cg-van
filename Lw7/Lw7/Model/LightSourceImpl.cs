using Lw7.Mathematics;

namespace Lw7.Model
{
    public class LightSourceImpl : ILightSource
    {
        public Vec4d DiffuseIntensity  { get; set; } = Vec4d.Zero;
        public Vec4d SpecularIntensity { get; set; } = Vec4d.Zero;
        public Vec4d AmbientIntensity  { get; set; } = Vec4d.Zero;
        private Mat4d _transform;

        protected LightSourceImpl(Mat4d transform)
        {
            _transform = transform;
        }

        protected LightSourceImpl()
        {
            _transform = Mat4d.Identity;
        }

        public virtual void SetTransform(Mat4d transform)
        {
            _transform = transform;
        }

        public Mat4d GetTransform()
        {
            return _transform;
        }

        public virtual double GetIntensityInDirection(Vec3d direction)
        {
            return 0;
        }

        public virtual Vec3d GetDirectionFromPoint(Vec3d point)
        {
            return Vec3d.Zero;
        }
    }
}
