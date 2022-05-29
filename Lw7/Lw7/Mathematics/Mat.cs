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

        public static Mat4d CreateTranslation(double x, double y, double z)
        {
            Mat4d mat = Identity;
            mat.M14 = x;
            mat.M24 = y;
            mat.M34 = z;
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
    }
}
