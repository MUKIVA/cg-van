using Lw7.Mathematics;
using System;

namespace Lw7.Model
{
    public class Sphere : GeometryObjectImpl
    {
        private Mat4d _initialTransform = Mat4d.Identity;
        private Mat4d _inverseTransform = Mat4d.Identity;

        public Sphere()
        {
            _initialTransform *=
                //Mat4d.CreateTranslation(center.X, center.Y, center.Z) *
                Mat4d.CreateScale(1, 1, 1);
            OnUpdateTransform();
        }

        public Sphere(double radius, Vec3d center, Mat4d transform)
            :base(transform)
        {
            _initialTransform *= 
                Mat4d.CreateTranslation(center.X, center.Y, center.Z) * 
                Mat4d.CreateScale(radius, radius, radius);

            OnUpdateTransform();
        }

        public override Mat4d GetInverseTransform()
        {
            return _inverseTransform;
        }

        public override bool Hit(Ray ray, Intersection intersection)
        {
            Ray invRay = ray;
            invRay.Transform(GetInverseTransform());

            double a = Vec3d.Dot(invRay.Direction, invRay.Direction);
            double b = Vec3d.Dot(invRay.Start, invRay.Direction);
            double c = Vec3d.Dot(invRay.Start, invRay.Start) - 1;

            double d = b * b - a * c;

            if (d < 0)
            {
                return false;
            }

            double HIT_TIME_EPSILON = 1e-8;

            double invA = 1 / a;
            double discRoot = Math.Sqrt(d);
            {
                double t0 = (-b - discRoot) * invA;

                if (t0 > HIT_TIME_EPSILON)
                {
                    Vec3d hitPoint0 = ray.GetPointAtTime(t0);
                    Vec3d hitPoint0InObjectSpace = invRay.GetPointAtTime(t0);

                    Vec3d hitNormal0InObjectSpace = hitPoint0InObjectSpace;
                    Vec3d hitNormal0 = GetNormalMatrix() * hitNormal0InObjectSpace;

                    intersection.AddHit(new HitInfo(
                        t0, this,
                        hitPoint0, hitPoint0InObjectSpace,
                        hitNormal0, hitNormal0InObjectSpace
                        ));
                }
            }

            {
                double t1 = (-b + discRoot) * invA;
                if (t1 > HIT_TIME_EPSILON)
                {
                    Vec3d hitPoint1 = ray.GetPointAtTime(t1);
                    Vec3d hitPoint1InObjectSpace = invRay.GetPointAtTime(t1);

                    Vec3d hitNormal1InObjectSpace = hitPoint1InObjectSpace;
                    Vec3d hitNormal1 = GetNormalMatrix() * hitNormal1InObjectSpace;

                    intersection.AddHit(new HitInfo(
                        t1, this,
                        hitPoint1, hitPoint1InObjectSpace,
                        hitNormal1, hitNormal1InObjectSpace
                        ));
                }
            }
            return intersection.GetHitsCount() > 0;
        }

        protected override void OnUpdateTransform()
        {
            base.OnUpdateTransform();

            Mat4d inverseInitialTransform = _initialTransform.GetInverseMatrix();
            Mat4d inverseGeomObjectTransform = base.GetInverseTransform();

            _inverseTransform = inverseGeomObjectTransform * inverseInitialTransform;
        }


    }
}
