using Lw7.Mathematics;

namespace Lw7.Model
{
    public class OmniLightSource : LightSourceImpl
    {
        private Vec3d _position = Vec3d.Zero;

        private double _constantAttenuation = 1;
        private double _linearAttenuation = 0;
        private double _quadraticAttenuation = 0;

        private Vec3d _positionInWorldSpace;

        public OmniLightSource()
        {
            UpdatePositionInWorldSpace();
        }

        public OmniLightSource(Vec3d position, Mat4d transform)
            : base(transform)
        {
            _position = position;
            UpdatePositionInWorldSpace();
        }

        public override void SetTransform(Mat4d transform)
        {
            base.SetTransform(transform);
            UpdatePositionInWorldSpace();
        }

        public override Vec3d GetDirectionFromPoint(Vec3d point)
        {
            return GetPositionInWorldSpace() - point;
        }

        public override double GetIntensityInDirection(Vec3d direction)
        {
            double distance = direction.Length;
            return 1.0 / (distance * distance * _quadraticAttenuation + distance * _linearAttenuation + _constantAttenuation);
        }

        public void SetAttenuation(
            double constantAttenuation,
            double linearAttenuation,
            double quadraticAttenuation)
        { 
        }

        private Vec3d GetPositionInWorldSpace()
        {
            return _positionInWorldSpace;
        }

        private void UpdatePositionInWorldSpace()
        {
            _positionInWorldSpace = (new Vec4d(_position, 1) * GetTransform()).XYZ;
        }

    }
}
