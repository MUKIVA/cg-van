using Lw7.Mathematics;
using System;

namespace Lw7.Model
{
    public class HitInfo
    {
        private Vec3d _hitPoint;
        private Vec3d _hitPointInObjectSpace;
        private Vec3d _normal;
        private Vec3d _normalInObjectSpace;
        private double _hitTime;
        private IGeometryObject? _hitObject;

        public HitInfo()
        {
            _hitTime = -1;
            _hitObject = null;
        }

        public HitInfo(
            double hitTime,
            IGeometryObject? hitObject,
            Vec3d hitPoint,
            Vec3d hitPointInObjectSpace,
            Vec3d normal,
            Vec3d normalInObjectSpace)
        {
            _hitTime = hitTime;
            _hitObject = hitObject;
            _hitPoint = hitPoint;
            _hitPointInObjectSpace = hitPointInObjectSpace;
            _normal = normal;
            _normalInObjectSpace = normalInObjectSpace;
        }

        public bool IsInitialized()
        {
            return _hitObject != null;
        }

        public double GetHitTime()
        {
            Assert();
            return _hitTime;
                
        }

        public Vec3d GetHitPoint()
        {
            Assert();
            return _hitPoint;
        }

        public Vec3d GetHitPointInObjectSpace()
        {
            Assert();
            return _hitPointInObjectSpace;
        }

        public IGeometryObject GetHitObject()
        {
            Assert();
            return _hitObject!;
        }

        public Vec3d GetNormal()
        {
            Assert();
            return _normal;
        }

        public Vec3d GetNormalInObjectSpace()
        {
            Assert();
            return _normalInObjectSpace;
        }

        private void Assert()
        {
            if (!IsInitialized())
                throw new Exception("Hit is not initialized");
        }
    }
}
