using Lw7.Mathematics;
using System;

namespace Lw7.Model
{
    public class Plane : GeometryObjectImpl
    {
        private Vec4d _planeEquation;

        public Plane(double a, double b, double c, double d)
        {
            _planeEquation = new(a, b, c, d);
        }

        public Plane(double a, double b, double c, double d, Mat4d transform)
            :base(transform)
        {
            _planeEquation = new(a, b, c, d);
        }

        public override bool Hit(Ray ray, Intersection intersection)
        {
            double epsilon = 1e-10;

            Ray invRay = ray;
            invRay.Transform(GetInverseTransform());

            Vec3d normalInObjectSpace = _planeEquation.XYZ;

            double normalDotDirection = Vec3d.Dot(invRay.Direction, normalInObjectSpace);

            if (Math.Abs(normalDotDirection) < epsilon)
            {
                return false;
            }

            double hitTime = -Vec4d.Dot(new(invRay.Start, 1), _planeEquation) / normalDotDirection;

            if (hitTime <= epsilon)
            {
                return false;
            }

            Vec3d hitPoint = ray.GetPointAtTime(hitTime);
            Vec3d hitPointInObjectSpace = invRay.GetPointAtTime(hitTime);
            Vec3d normalWorldSpace = GetNormalMatrix() * normalInObjectSpace;

            intersection.AddHit(new HitInfo(
                hitTime,
                this,
                hitPoint, hitPointInObjectSpace,
                normalWorldSpace, normalInObjectSpace
                ));

            return true;
        }
    }
}
