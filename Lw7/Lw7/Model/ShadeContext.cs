using Lw7.Mathematics;

namespace Lw7.Model
{
    public class ShadeContext
    {
        private Vec3d _surfacePoint;
        private Vec3d _surfacePointInObjectSpace;
        private Vec3d _surfaceNormal;
        private Vec3d _rayDirection;
        private Scene _scene;

        public ShadeContext(
            Scene scene,
            Vec3d surfacePoint,
            Vec3d surfacepointInObjectSpace,
            Vec3d surfaceNormal,
            Vec3d rayDirection)
        {
            _surfacePoint = surfacePoint;
            _surfacePointInObjectSpace = surfacepointInObjectSpace;
            _surfaceNormal = surfaceNormal;
            _rayDirection = rayDirection;
            _scene = scene;
        }

        public Vec3d GetSurfacePoint()
        {
            return _surfacePoint;
        }

        public Vec3d GetSurfacePointInObjectSpace()
        {
            return _surfacePointInObjectSpace;
        }

        public Vec3d GetSurfaceNormal()
        {
            return _surfaceNormal;
        }

        public Vec3d GetRayDirection()
        {
            return _rayDirection;
        }

        public Scene GetScene()
        {
            return _scene; 
        }
    }
}
