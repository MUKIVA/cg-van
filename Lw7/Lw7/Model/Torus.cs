using Lw7.Mathematics;
using System;
using System.Numerics;
using System.Collections.Generic;

namespace Lw7.Model
{
    public class Torus : GeometryObjectImpl
    {
        private Mat4d _initialTransform = Mat4d.Identity;
        private Mat4d _inverseTransform = Mat4d.Identity;
        private double _distanceFromCenter;
        private double _pipeRadius;

        public double R
        {
            get => _distanceFromCenter;
        }

        public double r
        {
            get => _pipeRadius;
        }

        public override Mat4d GetInverseTransform()
        {
            return _inverseTransform;
        }

        public Torus()
        {
            _initialTransform *=
                //Mat4d.CreateTranslation(center.X, center.Y, center.Z) *
                Mat4d.CreateScale(1, 1, 1);

            _pipeRadius = 0.5;
            _distanceFromCenter = 1.0;
            OnUpdateTransform();
        }

        public Torus(double R, double r, Vec3d center, Mat4d transform)
            : base(transform)
        {
            _initialTransform *=
                Mat4d.CreateTranslation(center.X, center.Y, center.Z) *
                Mat4d.CreateScale(1, 1, 1);

            _pipeRadius = r;
            _distanceFromCenter = R;
            OnUpdateTransform();
        }

        public override bool Hit(Ray ray, Intersection intersection)
        {
            Ray invRay = ray;
            invRay.Transform(GetInverseTransform());

            Vec3d squaredD = invRay.Direction * invRay.Direction;
            Vec3d squaredS = invRay.Start * invRay.Start;
            double sumD = squaredD.X + squaredD.Y + squaredD.Z;
            double e = squaredS.X + squaredS.Y + squaredS.Z - R * R - r * r;
            double f = invRay.Direction.X * invRay.Start.X +
                       invRay.Direction.Y * invRay.Start.Y +
                       invRay.Direction.Z * invRay.Start.Z;
            double fourRadiusSqrd = 4.0 * R * R;

            var a = (2.0 * sumD * e + 4.0 * f * f + fourRadiusSqrd * invRay.Direction.Y * invRay.Direction.Y);

            Complex[] roots = SolvedEquation(
                (sumD * sumD),
                (4.0 * sumD * f),
                (2.0 * sumD * e + 4.0 * f * f + fourRadiusSqrd * invRay.Direction.Y * invRay.Direction.Y),
                (4.0 * f * e + 2.0 * fourRadiusSqrd * invRay.Start.Y * invRay.Direction.Y),
                (e * e - fourRadiusSqrd * (r * r - invRay.Start.Y * invRay.Start.Y))
                );

            double[] realNums = GetRealNums(roots);

            double HIT_TIME_EPSILON = 1e-8;
            double t = double.MaxValue;
            bool intersected = false;
            for (int i = 0; i < realNums.Length; ++i)
            {
                if (realNums[i] > HIT_TIME_EPSILON)
                {
                    intersected = true;
                    if (realNums[i] < t)
                        t = realNums[i];
                }
            }

            if (!intersected)
            {
                return false;
            }

            Vec3d hitPoint = ray.GetPointAtTime(t);
            Vec3d hitPointInObjectSpace = invRay.GetPointAtTime(t);
            Vec3d hitNormalInObjectSpace = GetNormalAtPoint(hitPointInObjectSpace);
            Vec3d hitNormal = hitNormalInObjectSpace * GetNormalMatrix();

            intersection.AddHit(new HitInfo(t, this,
                hitPoint, hitPointInObjectSpace,
                hitNormal, hitNormalInObjectSpace
                ));
            return true;
        }

        private Vec3d GetNormalAtPoint(Vec3d point)
        {
            double paramSquared = R * R + r * r;

            double sumSquared = Vec3d.Dot(point, point);
            return new Vec3d(
                4.0 * point.X * (sumSquared - paramSquared),
                4.0 * point.Y * (sumSquared - paramSquared + 2.0 * r * r),
                4.0 * point.Z * (sumSquared - paramSquared)
                ).Normalized();
        }

        private double[] GetRealNums(Complex[] roots)
        {
            List<double> result = new();
            for (int i = 0; i < roots.Length; ++i)
            {
                if (Math.Abs(roots[i].Imaginary) < 1.0e-8)
                {
                    result.Add(roots[i].Real);
                }
            }
            return result.ToArray();
        }

        private Complex[] SolvedEquation(double a, double b, double c, double d, double e)
        {
            b /= a;
            c /= a;
            d /= a;
            e /= a;

            double b2 = b * b;
            double b3 = b * b2;
            double b4 = b2 * b2;

            double alpha = (-3.0 / 8.0) * b2 + c;
            double beta = b3 / 8.0 - b * c / 2.0 + d;
            double gamma = (-3.0 / 256.0) * b4 + b2 * c / 16.0 - b * d / 4.0 + e;

            double alpha2 = alpha * alpha;
            double alpha3 = alpha * alpha2;
            double t = -b / 4.0;

            Complex[] roots = new Complex[4];
            if (beta == 0)
            {
                Complex rad = Math.Sqrt(alpha2 - 4.0 * gamma);
                Complex r1 = Complex.Sqrt((-alpha + rad) / 2.0);
                Complex r2 = Complex.Sqrt((-alpha - rad) / 2.0);

                roots[0] = t + r1;
                roots[1] = t - r1;
                roots[2] = t + r2;
                roots[3] = t - r2;
                return roots;
            }

            Complex P = -(alpha2 / 12.0 + gamma);
            Complex Q = -alpha3 / 108.0 + alpha * gamma / 3.0 - beta * beta / 8.0;
            Complex R = -Q / 2.0 + Complex.Sqrt(Q * Q / 4.0 + P * P * P / 27.0);
            Complex U = Complex.Pow(R, 1.0 / 3.0);
            Complex y = (-5.0 / 6.0) * alpha + U;
            if (U == Complex.Zero)
            {
                y -= Complex.Pow(Q, 1.0 / 3.0);
            }
            else
            {
                y -= P / (3.0 * U);
            }

            {
                Complex W = Complex.Sqrt(alpha + 2.0 * y);
                Complex r1 = Complex.Sqrt(-(3.0 * alpha + 2.0 * y + 2.0 * beta / W));
                Complex r2 = Complex.Sqrt(-(3.0 * alpha + 2.0 * y - 2.0 * beta / W));
                
                roots[0] = t + (W - r1) / 2.0;
                roots[1] = t + (W + r1) / 2.0;
                roots[2] = t + (-W - r2) / 2.0;
                roots[3] = t + (-W + r2) / 2.0;
            }


            return roots;
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
