using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lw7.Mathematics
{
    public struct Mat<T>
    {
        private T[,] _values;

        public Mat(int count)
        {
            _values = new T[count, count];
        }

        public T this[int y, int x]
        {
            get => _values[y, x];
            set => _values[y, x] = value;
        }
    }
    public struct Mat3d
    {
        private Mat<double> _values = new Mat<double>(3);

        public Mat3d(
            double m11, double m12, double m13,
            double m21, double m22, double m23,
            double m31, double m32, double m33)
        {
            (_values[0, 0], _values[0, 1], _values[0, 2]) = (m11, m12, m13);
            (_values[1, 0], _values[1, 1], _values[1, 2]) = (m21, m22, m23);
            (_values[2, 0], _values[2, 1], _values[2, 2]) = (m31, m32, m33);
        }
        public static Mat3d Identity
        {
            get => new Mat3d(
                1, 0, 0,
                0, 1, 0,
                0, 0, 1);
        }
        public static Mat3d Zero
        {
            get => new Mat3d(
                0, 0, 0,
                0, 0, 0,
                0, 0, 0);
        }
        public static Mat3d One
        {
            get => new Mat3d(
                1, 1, 1,
                1, 1, 1,
                1, 1, 1);
        }
        public double M11 { get => _values[0, 0]; set => _values[0, 0] = value; }
        public double M12 { get => _values[0, 1]; set => _values[0, 1] = value; }
        public double M13 { get => _values[0, 2]; set => _values[0, 2] = value; }
        public double M21 { get => _values[1, 0]; set => _values[1, 0] = value; }
        public double M22 { get => _values[1, 1]; set => _values[1, 1] = value; }
        public double M23 { get => _values[1, 2]; set => _values[1, 2] = value; }
        public double M31 { get => _values[2, 0]; set => _values[2, 0] = value; }
        public double M32 { get => _values[2, 1]; set => _values[2, 1] = value; }
        public double M33 { get => _values[2, 2]; set => _values[2, 2] = value; }
        public double Determinant
        {
            get =>
                M11 * (M22 * M33 - M23 * M32) -
                M12 * (M21 * M33 - M23 * M31) +
                M13 * (M21 * M32 - M22 * M31);
        }
        public Vec3d GetRow(int index)
        {
            return new Vec3d(
                _values[index, 0], 
                _values[index, 1], 
                _values[index, 2]);
        }
        public Vec3d GetColumn(int index)
        {
            return new Vec3d(
                _values[0, index],
                _values[1, index],
                _values[2, index]);
        }
        public void SetRow(int index, Vec3d v)
        {
            _values[index, 0] = v.X;
            _values[index, 1] = v.Y;
            _values[index, 2] = v.Z;
        }
        public void SetColumn(int index, Vec3d v)
        {
            _values[0, index] = v.X;
            _values[1, index] = v.Y;
            _values[2, index] = v.Z;
        }
    }
    public struct Mat3f
    {
        private Mat<float> _values = new Mat<float>(3);

        public Mat3f(
            float m11, float m12, float m13,
            float m21, float m22, float m23,
            float m31, float m32, float m33)
        {
            (_values[0, 0], _values[0, 1], _values[0, 2]) = (m11, m12, m13);
            (_values[1, 0], _values[1, 1], _values[1, 2]) = (m21, m22, m23);
            (_values[2, 0], _values[2, 1], _values[2, 2]) = (m31, m32, m33);
        }
        public static Mat3f Identity
        {
            get => new Mat3f(
                1, 0, 0,
                0, 1, 0,
                0, 0, 1);
        }
        public static Mat3f Zero
        {
            get => new Mat3f(
                0, 0, 0,
                0, 0, 0,
                0, 0, 0);
        }
        public static Mat3f One
        {
            get => new Mat3f(
                1, 1, 1,
                1, 1, 1,
                1, 1, 1);
        }
        public float M11 { get => _values[0, 0]; set => _values[0, 0] = value; }
        public float M12 { get => _values[0, 1]; set => _values[0, 1] = value; }
        public float M13 { get => _values[0, 2]; set => _values[0, 2] = value; }
        public float M21 { get => _values[1, 0]; set => _values[1, 0] = value; }
        public float M22 { get => _values[1, 1]; set => _values[1, 1] = value; }
        public float M23 { get => _values[1, 2]; set => _values[1, 2] = value; }
        public float M31 { get => _values[2, 0]; set => _values[2, 0] = value; }
        public float M32 { get => _values[2, 1]; set => _values[2, 1] = value; }
        public float M33 { get => _values[2, 2]; set => _values[2, 2] = value; }
        public float Determinant
        {
            get =>
                M11 * (M22 * M33 - M23 * M32) -
                M12 * (M21 * M33 - M23 * M31) +
                M13 * (M21 * M32 - M22 * M31);
        }
        public Vec3f GetRow(int index)
        {
            return new Vec3f(
                _values[index, 0],
                _values[index, 1],
                _values[index, 2]);
        }
        public Vec3f GetColumn(int index)
        {
            return new Vec3f(
                _values[0, index],
                _values[1, index],
                _values[2, index]);
        }
        public void SetRow(int index, Vec3f v)
        {
            _values[index, 0] = v.X;
            _values[index, 1] = v.Y;
            _values[index, 2] = v.Z;
        }
        public void SetColumn(int index, Vec3f v)
        {
            _values[0, index] = v.X;
            _values[1, index] = v.Y;
            _values[2, index] = v.Z;
        }
    }
    public struct Mat4d
    {
        private Mat<double> _values = new Mat<double>(4);

        public Mat4d(
            double m11, double m12, double m13, double m14,
            double m21, double m22, double m23, double m24,
            double m31, double m32, double m33, double m34,
            double m41, double m42, double m43, double m44)
        {
            (_values[0, 0], _values[0, 1], _values[0, 2], _values[0, 3]) = (m11, m12, m13, m14);
            (_values[1, 0], _values[1, 1], _values[1, 2], _values[1, 3]) = (m21, m22, m23, m24);
            (_values[2, 0], _values[2, 1], _values[2, 2], _values[2, 3]) = (m31, m32, m33, m34);
            (_values[3, 0], _values[3, 1], _values[3, 2], _values[3, 3]) = (m41, m42, m43, m44);
        }
        public static Mat4d Identity
        {
            get => new Mat4d(
                1, 0, 0, 0,
                0, 1, 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1);
        }
        public static Mat4d Zero
        {
            get => new Mat4d(
                0, 0, 0, 0,
                0, 0, 0, 0,
                0, 0, 0, 0,
                0, 0, 0, 0);
        }
        public static Mat4d One
        {
            get => new Mat4d(
                1, 1, 1, 1,
                1, 1, 1, 1,
                1, 1, 1, 1,
                1, 1, 1, 1);
        }
        public double M11 { get => _values[0, 0]; set => _values[0, 0] = value; }
        public double M12 { get => _values[0, 1]; set => _values[0, 1] = value; }
        public double M13 { get => _values[0, 2]; set => _values[0, 2] = value; }
        public double M14 { get => _values[0, 3]; set => _values[0, 3] = value; }
        public double M21 { get => _values[1, 0]; set => _values[1, 0] = value; }
        public double M22 { get => _values[1, 1]; set => _values[1, 1] = value; }
        public double M23 { get => _values[1, 2]; set => _values[1, 2] = value; }
        public double M24 { get => _values[1, 3]; set => _values[1, 3] = value; }
        public double M31 { get => _values[2, 0]; set => _values[2, 0] = value; }
        public double M32 { get => _values[2, 1]; set => _values[2, 1] = value; }
        public double M33 { get => _values[2, 2]; set => _values[2, 2] = value; }
        public double M34 { get => _values[2, 3]; set => _values[2, 3] = value; }
        public double M41 { get => _values[3, 0]; set => _values[3, 0] = value; }
        public double M42 { get => _values[3, 1]; set => _values[3, 1] = value; }
        public double M43 { get => _values[3, 2]; set => _values[3, 2] = value; }
        public double M44 { get => _values[3, 3]; set => _values[3, 3] = value; }

        public static Mat4d operator +(Mat4d l, Mat4d r)
        {
            return new(
                l.M11 + r.M11, l.M12 + r.M12, l.M13 + r.M13, l.M14 + r.M14,
                l.M21 + r.M21, l.M22 + r.M22, l.M23 + r.M23, l.M24 + r.M24,
                l.M31 + r.M31, l.M32 + r.M32, l.M33 + r.M33, l.M34 + r.M34,
                l.M41 + r.M41, l.M42 + r.M42, l.M43 + r.M43, l.M44 + r.M44);
        }
        public static Mat4d operator -(Mat4d l, Mat4d r)
        {
            return new(
                l.M11 - r.M11, l.M12 - r.M12, l.M13 - r.M13, l.M14 - r.M14,
                l.M21 - r.M21, l.M22 - r.M22, l.M23 - r.M23, l.M24 - r.M24,
                l.M31 - r.M31, l.M32 - r.M32, l.M33 - r.M33, l.M34 - r.M34,
                l.M41 - r.M41, l.M42 - r.M42, l.M43 - r.M43, l.M44 - r.M44);
        }
        public static Mat4d operator *(Mat4d l, double r)
        {
            return new(
                l.M11 * r, l.M12 * r, l.M13 * r, l.M14 * r,
                l.M21 * r, l.M22 * r, l.M23 * r, l.M24 * r,
                l.M31 * r, l.M32 * r, l.M33 * r, l.M34 * r,
                l.M41 * r, l.M42 * r, l.M43 * r, l.M44 * r);
        }
        public static Mat4d operator *(Mat4d l, Mat4d r)
        {
            var m11 = l.M11 * r.M11 + l.M12 * r.M21 + l.M13 * r.M31 + l.M14 * r.M41;
            var m12 = l.M11 * r.M12 + l.M12 * r.M22 + l.M13 * r.M32 + l.M14 * r.M42;
            var m13 = l.M11 * r.M13 + l.M12 * r.M23 + l.M13 * r.M33 + l.M14 * r.M43;
            var m14 = l.M11 * r.M14 + l.M12 * r.M24 + l.M13 * r.M34 + l.M14 * r.M44;

            var m21 = l.M21 * r.M11 + l.M22 * r.M21 + l.M23 * r.M31 + l.M24 * r.M41;
            var m22 = l.M21 * r.M12 + l.M22 * r.M22 + l.M23 * r.M32 + l.M24 * r.M42;
            var m23 = l.M21 * r.M13 + l.M22 * r.M23 + l.M23 * r.M33 + l.M24 * r.M43;
            var m24 = l.M21 * r.M14 + l.M22 * r.M24 + l.M23 * r.M34 + l.M24 * r.M44;

            var m31 = l.M31 * r.M11 + l.M32 * r.M21 + l.M33 * r.M31 + l.M34 * r.M41;
            var m32 = l.M31 * r.M12 + l.M32 * r.M22 + l.M33 * r.M32 + l.M34 * r.M42;
            var m33 = l.M31 * r.M13 + l.M32 * r.M23 + l.M33 * r.M33 + l.M34 * r.M43;
            var m34 = l.M31 * r.M14 + l.M32 * r.M24 + l.M33 * r.M34 + l.M34 * r.M44;

            var m41 = l.M41 * r.M11 + l.M42 * r.M21 + l.M43 * r.M31 + l.M44 * r.M41;
            var m42 = l.M41 * r.M12 + l.M42 * r.M22 + l.M43 * r.M32 + l.M44 * r.M42;
            var m43 = l.M41 * r.M13 + l.M42 * r.M23 + l.M43 * r.M33 + l.M44 * r.M43;
            var m44 = l.M41 * r.M14 + l.M42 * r.M24 + l.M43 * r.M34 + l.M44 * r.M44;

            return new(
                m11, m12, m13, m14,
                m21, m22, m23, m24,
                m31, m32, m33, m34,
                m41, m42, m43, m44);
        }

        public static Mat4d CreateTranslation(double x, double y, double z)
        {
            Mat4d mat = Identity;
            mat.M41 = x;
            mat.M42 = y;
            mat.M43 = z;
            return mat;
        }
        public static Mat4d CreateScale(double x, double y, double z)
        {
            Mat4d mat = Identity;
            mat.M11 = x;
            mat.M22 = y;
            mat.M33 = z;
            return mat;
        }
        public static Mat4d CreateRotationX(double angle) // radians
        {
            Mat4d mat = Identity;
            mat.M22 = Math.Cos(angle);
            mat.M23 = -Math.Sin(angle);
            mat.M32 = Math.Sin(angle);
            mat.M33 = Math.Cos(angle);
            return mat;
        }
        public static Mat4d CreateRotationY(double angle) // radians
        {
            Mat4d mat = Identity;
            mat.M11 = Math.Cos(angle);
            mat.M13 = Math.Sin(angle);
            mat.M31 = -Math.Sin(angle);
            mat.M33 = Math.Cos(angle);
            return mat;
        }
        public static Mat4d CreateRotationZ(double angle) // radians
        {
            Mat4d mat = Identity;
            mat.M11 = Math.Cos(angle);
            mat.M12 = -Math.Sin(angle);
            mat.M21 = Math.Sin(angle);
            mat.M22 = Math.Cos(angle);
            return mat;
        }
        public Vec4d GetRow(int index)
        {
            return new Vec4d(
                _values[index, 0],
                _values[index, 1],
                _values[index, 2], 
                _values[index, 3]);
        }
        public Vec4d GetColumn(int index)
        {
            return new Vec4d(
                _values[0, index],
                _values[1, index],
                _values[2, index],
                _values[3, index]);
        }
        public void SetRow(int index, Vec4d v)
        {
            _values[index, 0] = v.X;
            _values[index, 1] = v.Y;
            _values[index, 2] = v.Z;
            _values[index, 3] = v.W;
        }
        public void SetColumn(int index, Vec4d v)
        {
            _values[0, index] = v.X;
            _values[1, index] = v.Y;
            _values[2, index] = v.Z;
            _values[3, index] = v.W;
        }
        public static Mat4d Frustum(double left, double right, double bottom, double top, double zNear, double zFar)
        {
            Mat4d mat = Identity;
            double n2 = zNear + zNear;
            double invRminusL = 1 / (right - left);
            double invFminusN = 1 / (zFar - zNear);
            double invTminusB = 1 / (top - bottom);

            mat.M11 = n2 * invRminusL;
            mat.M12 = mat.M13 = mat.M14 = mat.M21 = 0;
            mat.M22 = n2 * invTminusB;
            mat.M23 = mat.M24 = 0;
            mat.M31 = (right + left) * invRminusL;
            mat.M32 = (top + bottom) * invTminusB;
            mat.M33 = -(zFar + zNear) * invFminusN;
            mat.M34 = -1;
            mat.M41 = mat.M42 = 0;
            mat.M43 = -n2 * zFar * invFminusN;
            mat.M44 = 0;

            return mat;
        }
        public static Mat4d Perspective(double fovY, double aspect, double zNear, double zFar)
        {
            fovY = fovY * Math.PI / 180;
            double top = zNear * Math.Tan(fovY * 0.5);
            double right = aspect * top;
            return Frustum(-right, right, -top, top, zNear, zFar);
        }
        public double Determinant
        {
            get =>  M14 * M23 * M32 * M41 -
                    M13 * M24 * M32 * M41 -
                    M14 * M22 * M33 * M41 +
                    M12 * M24 * M33 * M41 +

                    M13 * M22 * M34 * M41 -
                    M12 * M23 * M34 * M41 -
                    M14 * M23 * M31 * M42 +
                    M13 * M24 * M31 * M42 +

                    M14 * M21 * M33 * M42 -
                    M11 * M24 * M33 * M42 -
                    M13 * M21 * M34 * M42 +
                    M11 * M23 * M34 * M42 +

                    M14 * M22 * M31 * M43 -
                    M12 * M24 * M13 * M43 -
                    M14 * M21 * M32 * M43 +
                    M11 * M24 * M32 * M43 +

                    M12 * M21 * M34 * M43 -
                    M11 * M22 * M34 * M43 -
                    M13 * M22 * M31 * M44 +
                    M12 * M23 * M31 * M44 +

                    M13 * M21 * M32 * M44 -
                    M11 * M23 * M32 * M44 -
                    M12 * M21 * M33 * M44 +
                    M11 * M22 * M33 * M44;
        }
        public Mat4d GetInverseMatrix()
        {
            double invDet = 1d / Determinant;
            return new Mat4d(
                invDet * (M23 * M34 * M42 - M24 * M33 * M42 + M24 * M32 * M43 - M22 * M34 * M43 - M23 * M32 * M44 + M22 * M33 * M44), //1
                invDet * (M14 * M33 * M42 - M13 * M34 * M42 - M14 * M32 * M43 + M12 * M34 * M43 + M13 * M32 * M44 - M12 * M33 * M44), //1
                invDet * (M13 * M24 * M42 - M14 * M23 * M42 + M14 * M22 * M43 - M12 * M24 * M43 - M13 * M22 * M44 + M12 * M23 * M44), //1
                invDet * (M14 * M23 * M32 - M13 * M24 * M32 - M14 * M22 * M33 + M12 * M24 * M33 + M13 * M22 * M34 - M12 * M23 * M34), //1

                invDet * (M24 * M33 * M41 - M23 * M34 * M41 - M24 * M31 * M43 + M21 * M34 * M43 + M23 * M31 * M44 - M21 * M33 * M44), //2
                invDet * (M13 * M34 * M41 - M14 * M33 * M41 + M14 * M31 * M43 - M11 * M34 * M43 - M13 * M31 * M44 + M11 * M33 * M44), //2
                invDet * (M14 * M23 * M41 - M13 * M24 * M41 - M14 * M21 * M43 + M11 * M24 * M43 + M13 * M21 * M44 - M11 * M23 * M44), //2
                invDet * (M13 * M24 * M31 - M14 * M23 * M31 + M14 * M21 * M33 - M11 * M24 * M33 - M13 * M21 * M34 + M11 * M23 * M34), //2

                invDet * (M22 * M34 * M41 - M24 * M32 * M41 + M24 * M31 * M42 - M21 * M34 * M42 - M22 * M31 * M44 + M21 * M32 * M44), //3
                invDet * (M14 * M32 * M41 - M12 * M34 * M41 - M14 * M31 * M42 + M11 * M34 * M42 + M12 * M31 * M44 - M11 * M32 * M44), //3
                invDet * (M12 * M24 * M41 - M14 * M22 * M41 + M14 * M21 * M42 - M11 * M24 * M42 - M12 * M21 * M44 + M11 * M22 * M44), //3
                invDet * (M14 * M22 * M31 - M12 * M24 * M31 - M14 * M21 * M32 + M11 * M24 * M32 + M12 * M21 * M34 - M11 * M22 * M34), //3

                invDet * (M23 * M32 * M41 - M22 * M33 * M41 - M23 * M31 * M42 + M21 * M33 * M42 + M22 * M31 * M43 - M21 * M32 * M43), //4
                invDet * (M12 * M33 * M41 - M13 * M32 * M41 + M13 * M31 * M42 - M11 * M33 * M42 - M12 * M31 * M43 + M11 * M32 * M43), //4
                invDet * (M13 * M22 * M41 - M12 * M23 * M41 - M13 * M21 * M42 + M11 * M23 * M42 + M12 * M21 * M43 - M11 * M22 * M43), //4
                invDet * (M12 * M23 * M31 - M13 * M22 * M31 + M13 * M21 * M32 - M11 * M23 * M32 - M12 * M21 * M33 + M11 * M22 * M33));//4
        }
        public static Mat4d LookAtRH(Vec3d eye, Vec3d target, Vec3d up)
        {
            Mat4d mat = Zero;
            Vec3d zaxis = (eye - target);
            zaxis.Normalize();
            Vec3d xaxis = Vec3d.Cross(up, zaxis);
            xaxis.Normalize();
            Vec3d yaxis = Vec3d.Cross(zaxis, xaxis);
            yaxis.Normalize();

            return new(
                xaxis.X, yaxis.X, zaxis.X, 0,
                xaxis.Y, yaxis.Y, zaxis.Y, 0,
                xaxis.Z, yaxis.Z, zaxis.Z, 0,
                -Vec3d.Dot(xaxis, eye), -Vec3d.Dot(yaxis, eye), -Vec3d.Dot(zaxis, eye), 1);

        }
        public void ClearColumn(int index)
        {
            _values[0, index] = 0;
            _values[1, index] = 0;
            _values[2, index] = 0;
            _values[3, index] = 0;
        }
        public void ClearRow(int index)
        {
            _values[index, 0] = 0;
            _values[index, 1] = 0;
            _values[index, 2] = 0;
            _values[index, 3] = 0;
        }
        public void Normalize()
        {
            Vec3d xAxis = new(M11, M21, M31);
            xAxis.Normalize();
            Vec3d yAxis = new(M12, M22, M32);
            yAxis.Normalize();

            var zAxis = Vec3d.Cross(xAxis, yAxis);
            zAxis.Normalize();

            xAxis = Vec3d.Cross(yAxis, zAxis);
            xAxis.Normalize();

            yAxis = Vec3d.Cross(zAxis, xAxis);
            yAxis.Normalize();

            M11 = xAxis.X; M21 = xAxis.Y; M31 = xAxis.Z;
            M12 = yAxis.X; M22 = yAxis.Y; M32 = yAxis.Z;
            M13 = zAxis.X; M23 = zAxis.Y; M33 = zAxis.Z;
        }
    }
    public struct Mat4f
    {
        private Mat<float> _values = new Mat<float>(4);

        public Mat4f(
            float m11, float m12, float m13, float m14,
            float m21, float m22, float m23, float m24,
            float m31, float m32, float m33, float m34,
            float m41, float m42, float m43, float m44)
        {
            (_values[0, 0], _values[0, 1], _values[0, 2], _values[0, 3]) = (m11, m12, m13, m14);
            (_values[1, 0], _values[1, 1], _values[1, 2], _values[1, 3]) = (m21, m22, m23, m24);
            (_values[2, 0], _values[2, 1], _values[2, 2], _values[2, 3]) = (m31, m32, m33, m34);
            (_values[3, 0], _values[3, 1], _values[3, 2], _values[3, 3]) = (m41, m42, m43, m44);
        }
        public static Mat4f Identity
        {
            get => new Mat4f(
                1, 0, 0, 0,
                0, 1, 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1);
        }
        public static Mat4f Zero
        {
            get => new Mat4f(
                0, 0, 0, 0,
                0, 0, 0, 0,
                0, 0, 0, 0,
                0, 0, 0, 0);
        }
        public static Mat4f One
        {
            get => new Mat4f(
                1, 1, 1, 1,
                1, 1, 1, 1,
                1, 1, 1, 1,
                1, 1, 1, 1);
        }
        public float M11 { get => _values[0, 0]; set => _values[0, 0] = value; }
        public float M12 { get => _values[0, 1]; set => _values[0, 1] = value; }
        public float M13 { get => _values[0, 2]; set => _values[0, 2] = value; }
        public float M14 { get => _values[0, 3]; set => _values[0, 3] = value; }
        public float M21 { get => _values[1, 0]; set => _values[1, 0] = value; }
        public float M22 { get => _values[1, 1]; set => _values[1, 1] = value; }
        public float M23 { get => _values[1, 2]; set => _values[1, 2] = value; }
        public float M24 { get => _values[1, 3]; set => _values[1, 3] = value; }
        public float M31 { get => _values[2, 0]; set => _values[2, 0] = value; }
        public float M32 { get => _values[2, 1]; set => _values[2, 1] = value; }
        public float M33 { get => _values[2, 2]; set => _values[2, 2] = value; }
        public float M34 { get => _values[2, 3]; set => _values[2, 3] = value; }
        public float M41 { get => _values[3, 0]; set => _values[3, 0] = value; }
        public float M42 { get => _values[3, 1]; set => _values[3, 1] = value; }
        public float M43 { get => _values[3, 2]; set => _values[3, 2] = value; }
        public float M44 { get => _values[3, 3]; set => _values[3, 3] = value; }

        public static Mat4f operator +(Mat4f l, Mat4f r)
        {
            return new(
                l.M11 + r.M11, l.M12 + r.M12, l.M13 + r.M13, l.M14 + r.M14,
                l.M21 + r.M21, l.M22 + r.M22, l.M23 + r.M23, l.M24 + r.M24,
                l.M31 + r.M31, l.M32 + r.M32, l.M33 + r.M33, l.M34 + r.M34,
                l.M41 + r.M41, l.M42 + r.M42, l.M43 + r.M43, l.M44 + r.M44);
        }
        public static Mat4f operator -(Mat4f l, Mat4f r)
        {
            return new(
                l.M11 - r.M11, l.M12 - r.M12, l.M13 - r.M13, l.M14 - r.M14,
                l.M21 - r.M21, l.M22 - r.M22, l.M23 - r.M23, l.M24 - r.M24,
                l.M31 - r.M31, l.M32 - r.M32, l.M33 - r.M33, l.M34 - r.M34,
                l.M41 - r.M41, l.M42 - r.M42, l.M43 - r.M43, l.M44 - r.M44);
        }
        public static Mat4f operator *(Mat4f l, float r)
        {
            return new(
                l.M11 * r, l.M12 * r, l.M13 * r, l.M14 * r,
                l.M21 * r, l.M22 * r, l.M23 * r, l.M24 * r,
                l.M31 * r, l.M32 * r, l.M33 * r, l.M34 * r,
                l.M41 * r, l.M42 * r, l.M43 * r, l.M44 * r);
        }
        public static Mat4f operator *(Mat4f l, Mat4f r)
        {
            var m11 = l.M11 * r.M11 + l.M12 * r.M21 + l.M13 * r.M31 + l.M14 * r.M41;
            var m12 = l.M11 * r.M12 + l.M12 * r.M22 + l.M13 * r.M32 + l.M14 * r.M42;
            var m13 = l.M11 * r.M13 + l.M12 * r.M23 + l.M13 * r.M33 + l.M14 * r.M43;
            var m14 = l.M11 * r.M14 + l.M12 * r.M24 + l.M13 * r.M34 + l.M14 * r.M44;

            var m21 = l.M21 * r.M11 + l.M22 * r.M21 + l.M23 * r.M31 + l.M24 * r.M41;
            var m22 = l.M21 * r.M12 + l.M22 * r.M22 + l.M23 * r.M32 + l.M24 * r.M42;
            var m23 = l.M21 * r.M13 + l.M22 * r.M23 + l.M23 * r.M33 + l.M24 * r.M43;
            var m24 = l.M21 * r.M14 + l.M22 * r.M24 + l.M23 * r.M34 + l.M24 * r.M44;

            var m31 = l.M31 * r.M11 + l.M32 * r.M21 + l.M33 * r.M31 + l.M34 * r.M41;
            var m32 = l.M31 * r.M12 + l.M32 * r.M22 + l.M33 * r.M32 + l.M34 * r.M42;
            var m33 = l.M31 * r.M13 + l.M32 * r.M23 + l.M33 * r.M33 + l.M34 * r.M43;
            var m34 = l.M31 * r.M14 + l.M32 * r.M24 + l.M33 * r.M34 + l.M34 * r.M44;

            var m41 = l.M41 * r.M11 + l.M42 * r.M21 + l.M43 * r.M31 + l.M44 * r.M41;
            var m42 = l.M41 * r.M12 + l.M42 * r.M22 + l.M43 * r.M32 + l.M44 * r.M42;
            var m43 = l.M41 * r.M13 + l.M42 * r.M23 + l.M43 * r.M33 + l.M44 * r.M43;
            var m44 = l.M41 * r.M14 + l.M42 * r.M24 + l.M43 * r.M34 + l.M44 * r.M44;


            return new(
                m11, m12, m13, m14,
                m21, m22, m23, m24,
                m31, m32, m33, m34,
                m41, m42, m43, m44);
        }

        public static Mat4f CreateTranslation(float x, float y, float z)
        {
            Mat4f mat = Identity;
            mat.M14 = x;
            mat.M24 = y;
            mat.M34 = z;
            return mat;
        }
        public static Mat4f CreateScale(float x, float y, float z)
        {
            Mat4f mat = Identity;
            mat.M11 = x;
            mat.M22 = y;
            mat.M33 = z;
            return mat;
        }
        public static Mat4f CreateRotationX(float angle) // radians
        {
            Mat4f mat = Identity;
            mat.M22 = MathF.Cos(angle);
            mat.M23 = -MathF.Sin(angle);
            mat.M32 = MathF.Sin(angle);
            mat.M33 = MathF.Cos(angle);
            return mat;
        }
        public static Mat4f CreateRotationY(float angle) // radians
        {
            Mat4f mat = Identity;
            mat.M11 = MathF.Cos(angle);
            mat.M13 = MathF.Sin(angle);
            mat.M31 = -MathF.Sin(angle);
            mat.M33 = MathF.Cos(angle);
            return mat;
        }
        public static Mat4f CreateRotationZ(float angle) // radians
        {
            Mat4f mat = Identity;
            mat.M11 = MathF.Cos(angle);
            mat.M12 = -MathF.Sin(angle);
            mat.M21 = MathF.Sin(angle);
            mat.M22 = MathF.Cos(angle);
            return mat;
        }
        public Vec4f GetRow(int index)
        {
            return new Vec4f(
                _values[index, 0],
                _values[index, 1],
                _values[index, 2],
                _values[index, 3]);
        }
        public Vec4f GetColumn(int index)
        {
            return new Vec4f(
                _values[0, index],
                _values[1, index],
                _values[2, index],
                _values[3, index]);
        }
        public void SetRow(int index, Vec4f v)
        {
            _values[index, 0] = v.X;
            _values[index, 1] = v.Y;
            _values[index, 2] = v.Z;
            _values[index, 3] = v.W;
        }
        public void SetColumn(int index, Vec4f v)
        {
            _values[0, index] = v.X;
            _values[1, index] = v.Y;
            _values[2, index] = v.Z;
            _values[3, index] = v.W;
        }
        public Mat4f Frustum(float left, float right, float bottom, float top, float zNear, float zFar)
        {
            Mat4f mat = Identity;
            float n2 = zNear + zNear;
            float invRminusL = 1 / (right - left);
            float invFminusN = 1 / (zFar - zNear);
            float invTminusB = 1 / (top - bottom);

            mat.M11 = n2 * invRminusL;
            mat.M21 = mat.M31 = mat.M41 = mat.M12 = 0;
            mat.M22 = n2 * invTminusB;
            mat.M32 = mat.M42 = 0;
            mat.M13 = (right + left) * invRminusL;
            mat.M23 = (top + bottom) * invTminusB;
            mat.M33 = -(zFar + zNear) * invFminusN;
            mat.M43 = -1;
            mat.M14 = mat.M24 = 0;
            mat.M34 = -n2 * zFar * invFminusN;
            mat.M44 = 0;

            return mat;
        }
        public Mat4f Perspective(float fovY, float aspect, float zNear, float zFar)
        {
            fovY = fovY * MathF.PI / 180;
            float top = zNear * MathF.Tan(fovY * 0.5f);
            float right = aspect * top;
            return Frustum(-right, right, -top, top, zNear, zFar);
        }
        public float Determinant
        {
            get => M14 * M23 * M32 * M41 -
                    M13 * M24 * M32 * M41 -
                    M14 * M22 * M33 * M41 +
                    M12 * M24 * M33 * M41 +

                    M13 * M22 * M34 * M41 -
                    M12 * M23 * M34 * M41 -
                    M14 * M23 * M31 * M42 +
                    M13 * M24 * M31 * M42 +

                    M14 * M21 * M33 * M42 -
                    M11 * M24 * M33 * M42 -
                    M13 * M21 * M34 * M42 +
                    M11 * M23 * M34 * M42 +

                    M14 * M22 * M31 * M43 -
                    M12 * M24 * M13 * M43 -
                    M14 * M21 * M32 * M43 +
                    M11 * M24 * M32 * M43 +

                    M12 * M21 * M34 * M43 -
                    M11 * M22 * M34 * M43 -
                    M13 * M22 * M31 * M44 +
                    M12 * M23 * M31 * M44 +

                    M13 * M21 * M32 * M44 -
                    M11 * M23 * M32 * M44 -
                    M12 * M21 * M33 * M44 +
                    M11 * M22 * M33 * M44;
        }
        public Mat4f GetInverseMatrix()
        {
            float invDet = 1 / Determinant;
            return new Mat4f(
                invDet * (M23 * M34 * M42 - M24 * M33 * M42 + M24 * M32 * M43 - M22 * M34 * M43 - M23 * M32 * M44 + M22 * M33 * M44), //1
                invDet * (M14 * M33 * M42 - M13 * M34 * M42 - M14 * M32 * M43 + M12 * M34 * M43 + M13 * M32 * M44 - M12 * M33 * M44), //1
                invDet * (M13 * M24 * M42 - M14 * M23 * M42 + M14 * M22 * M43 - M12 * M24 * M43 - M13 * M22 * M44 + M12 * M23 * M44), //1
                invDet * (M14 * M23 * M32 - M13 * M24 * M32 - M14 * M22 * M33 + M12 * M24 * M33 + M13 * M22 * M34 - M12 * M23 * M34), //1

                invDet * (M24 * M33 * M41 - M23 * M34 * M41 - M24 * M31 * M43 + M21 * M34 * M43 + M23 * M31 * M44 - M21 * M33 * M44), //2
                invDet * (M13 * M34 * M41 - M14 * M33 * M41 + M14 * M31 * M43 - M11 * M34 * M43 - M13 * M31 * M44 + M11 * M33 * M44), //2
                invDet * (M14 * M23 * M41 - M13 * M24 * M41 - M14 * M21 * M43 + M11 * M24 * M43 + M13 * M21 * M44 - M11 * M23 * M44), //2
                invDet * (M13 * M24 * M31 - M14 * M23 * M31 + M14 * M21 * M33 - M11 * M24 * M33 - M13 * M21 * M34 + M11 * M23 * M34), //2

                invDet * (M22 * M34 * M41 - M24 * M32 * M41 + M24 * M31 * M42 - M21 * M34 * M42 - M22 * M31 * M44 + M21 * M32 * M44), //3
                invDet * (M14 * M32 * M41 - M12 * M34 * M41 - M14 * M31 * M42 + M11 * M34 * M42 + M12 * M31 * M44 - M11 * M32 * M44), //3
                invDet * (M12 * M24 * M41 - M14 * M22 * M41 + M14 * M21 * M42 - M11 * M24 * M42 - M12 * M21 * M44 + M11 * M22 * M44), //3
                invDet * (M14 * M22 * M31 - M12 * M24 * M31 - M14 * M21 * M32 + M11 * M24 * M32 + M12 * M21 * M34 - M11 * M22 * M34), //3

                invDet * (M23 * M32 * M41 - M22 * M33 * M41 - M23 * M31 * M42 + M21 * M33 * M42 + M22 * M31 * M43 - M21 * M32 * M43), //4
                invDet * (M12 * M33 * M41 - M13 * M32 * M41 + M13 * M31 * M42 - M11 * M33 * M42 - M12 * M31 * M43 + M11 * M32 * M43), //4
                invDet * (M13 * M22 * M41 - M12 * M23 * M41 - M13 * M21 * M42 + M11 * M23 * M42 + M12 * M21 * M43 - M11 * M22 * M43), //4
                invDet * (M12 * M23 * M31 - M13 * M22 * M31 + M13 * M21 * M32 - M11 * M23 * M32 - M12 * M21 * M33 + M11 * M22 * M33));//4
        }
        public Mat4f LookAtRH(Vec3f eye, Vec3f target, Vec3f up)
        {
            Mat4f mat = Zero;
            Vec3f zaxis = (eye - target);
            zaxis.Normalize();
            Vec3f xaxis = Vec3f.Cross(up, zaxis);
            xaxis.Normalize();
            Vec3f yaxis = Vec3f.Cross(zaxis, xaxis);
            yaxis.Normalize();

            return new(
                xaxis.X, yaxis.X, zaxis.X, 0,
                xaxis.Y, yaxis.Y, zaxis.Y, 0,
                xaxis.Z, yaxis.Z, zaxis.Z, 0,
                -Vec3f.Dot(xaxis, eye), -Vec3f.Dot(yaxis, eye), -Vec3f.Dot(zaxis, eye), 1);

        }
        public void ClearColumn(int index)
        {
            _values[0, index] = 0;
            _values[1, index] = 0;
            _values[2, index] = 0;
            _values[3, index] = 0;
        }
        public void ClearRow(int index)
        {
            _values[index, 0] = 0;
            _values[index, 1] = 0;
            _values[index, 2] = 0;
            _values[index, 3] = 0;
        }
        public void Normalize()
        {
            Vec3f xAxis = new(M11, M21, M31);
            xAxis.Normalize();
            Vec3f yAxis = new(M12, M22, M32);
            yAxis.Normalize();

            var zAxis = Vec3f.Cross(xAxis, yAxis);
            zAxis.Normalize();

            xAxis = Vec3f.Cross(yAxis, zAxis);
            xAxis.Normalize();

            yAxis = Vec3f.Cross(zAxis, xAxis);
            yAxis.Normalize();

            M11 = xAxis.X; M21 = xAxis.Y; M31 = xAxis.Z;
            M12 = yAxis.X; M22 = yAxis.Y; M32 = yAxis.Z;
            M13 = zAxis.X; M23 = zAxis.Y; M33 = zAxis.Z;
        }
    }
}
