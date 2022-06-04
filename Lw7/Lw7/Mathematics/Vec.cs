using System;

namespace Lw7.Mathematics
{
    public struct Vec<T>
    {
        private T[] _values;

        public Vec(int count)
        {
            _values = new T[count];
        }

        public T this[int index]
        {
            get => _values[index];
            set => _values[index] = value;
        }
    }
    public struct Vec2d
    { 
        private Vec<double> _vector = new Vec<double>(2);

        public Vec2d(double x, double y)
        {
            _vector[0] = x;
            _vector[1] = y;
        }

        public double X
        {
            get => _vector[0];
            set => _vector[0] = value;
        }

        public double Y
        {
            get => _vector[1];
            set => _vector[1] = value;
        }

        public static Vec2d operator /(Vec2d left, double scalar)
        {
            return new Vec2d(left.X / scalar, left.Y / scalar);
        }
        public static Vec2d operator *(Vec2d left, double scalar)
        {
            return new Vec2d(left.X * scalar, left.Y * scalar);
        }
        public static Vec2d operator *(double scalar, Vec2d right)
        {
            return new Vec2d(right.X * scalar, right.Y * scalar);
        }
        public static Vec2d operator -(Vec2d left, Vec2d right)
        {
            return new Vec2d(left.X - right.X, left.Y - right.Y);
        }
        public static Vec2d operator-(Vec2d v)
        {
            return new Vec2d(-v.X, -v.Y);
        }
        public static Vec2d operator +(Vec2d v)
        {
            return v;
        }
        public static Vec2d operator *(Vec2d left, Vec2d Right)
        {
            return new Vec2d(left.X * Right.X, left.Y * Right.Y);
        }
        public static Vec2d operator /(Vec2d left, Vec2d Right)
        {
            return new Vec2d(left.X / Right.X, left.Y / Right.Y);
        }
        public static Vec2d operator +(Vec2d left, Vec2d Right)
        {
            return new Vec2d(left.X + Right.X, left.Y + Right.Y);
        }

        public double Length
        {
            get => Math.Sqrt(X * X + Y * Y);
        }

        public void Normalize()
        {
            double invLength = 1 / Length;
            X *= invLength;
            Y *= invLength;
        }

        public static Vec2d Zero => new Vec2d(0, 0);
        public static Vec2d One => new Vec2d(1, 1);
        public static Vec2d UnitX => new Vec2d(1, 0);
        public static Vec2d UnitY => new Vec2d(0, 1);

        public static double Dot(Vec2d left, Vec2d right)
        {
            return left.X * right.X + left.Y * right.Y;
        }
    }
    public struct Vec3d
    {
        private Vec<double> _vector = new Vec<double>(3);

        public Vec3d(double x, double y, double z)
        {
            _vector[0] = x;
            _vector[1] = y;
            _vector[2] = z;
        }

        public double X
        {
            get => _vector[0];
            set => _vector[0] = value;
        }

        public double Y
        {
            get => _vector[1];
            set => _vector[1] = value;
        }

        public double Z
        {
            get => _vector[2];
            set => _vector[2] = value;
        }

        public static Vec3d operator /(Vec3d left, double scalar)
        {
            return new Vec3d(left.X / scalar, left.Y / scalar, left.Z / scalar);
        }
        public static Vec3d operator *(Vec3d left, double scalar)
        {
            return new Vec3d(left.X * scalar, left.Y * scalar, left.Z * scalar);
        }
        public static Vec3d operator *(double scalar, Vec3d right)
        {
            return new Vec3d(right.X * scalar, right.Y * scalar, right.Z * scalar);
        }
        public static Vec3d operator -(Vec3d left, Vec3d right)
        {
            return new Vec3d(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
        }
        public static Vec3d operator -(Vec3d v)
        {
            return new Vec3d(-v.X, -v.Y, -v.Z);
        }
        public static Vec3d operator +(Vec3d v)
        {
            return v;
        }
        public static Vec3d operator *(Vec3d left, Vec3d Right)
        {
            return new Vec3d(left.X * Right.X, left.Y * Right.Y, left.Z * Right.Z);
        }
        public static Vec3d operator /(Vec3d left, Vec3d Right)
        {
            return new Vec3d(left.X / Right.X, left.Y / Right.Y, left.Z / Right.Z);
        }
        public static Vec3d operator +(Vec3d left, Vec3d Right)
        {
            return new Vec3d(left.X + Right.X, left.Y + Right.Y, left.Z + Right.Z);
        }
        public static Vec3d operator *(Mat3d l, Vec3d r)
        {
            return new Vec3d(
                l.M11 * r.X + l.M12 * r.Y + l.M13 * r.Z,
                l.M21 * r.X + l.M22 * r.Y + l.M23 * r.Z,
                l.M31 * r.X + l.M32 * r.Y + l.M33 * r.Z);
        }
        public static Vec3d operator *(Vec3d l, Mat3d r)
        {
            return new Vec3d(
                l.X * r.M11 + l.Y * r.M21 + l.Z * r.M31,
                l.X * r.M12 + l.Y * r.M22 + l.Z * r.M32,
                l.X * r.M13 + l.Y * r.M23 + l.Z * r.M33);
        }
        public static bool operator ==(Vec3d l, Vec3d r)
        {
            return (l.X == r.X && l.Y == r.Y && l.Z == r.Z);
        }

        public static bool operator !=(Vec3d l, Vec3d r)
        {
            return !(l.X == r.X && l.Y == r.Y && l.Z == r.Z);
        }

        public double Length
        {
            get => Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public void Normalize()
        {
            double invLength = 1 / Length;
            X *= invLength;
            Y *= invLength;
            Z *= invLength;
        }
        public Vec3d Normalized()
        {
            Vec3d tmp = this;  
            double invLength = 1 / Length;
            tmp.X *= invLength;
            tmp.Y *= invLength;
            tmp.Z *= invLength;
            return tmp;
        }

        public static Vec3d Zero => new Vec3d(0, 0, 0);
        public static Vec3d One => new Vec3d(1, 1, 1);
        public static Vec3d UnitX => new Vec3d(1, 0, 0);
        public static Vec3d UnitY => new Vec3d(0, 1, 0);
        public static Vec3d UnitZ => new Vec3d(0, 0, 1);

        public static Vec3d Cross(Vec3d left, Vec3d right)
        {
            return new Vec3d(
                left.Y * right.Z - left.Z * right.Y,
                left.Z * right.X - left.X * right.Z,
                left.X * right.Y - left.Y * right.X);
        }

        public static double Dot(Vec3d left, Vec3d right)
        {
            return left.X * right.X + left.Y * right.Y + left.Z * right.Z;
        }

        public static Vec3d Reflect(Vec3d inDirection, Vec3d inNormal)
        {
            double num = -2f * Vec3d.Dot(inNormal, inDirection);
            return new Vec3d(num * inNormal.X + inDirection.X, num * inNormal.Y + inDirection.Y, num * inNormal.Z + inDirection.Z);
        }
    }
    public struct Vec4d
    {
        private Vec<double> _vector = new Vec<double>(4);

        public Vec4d(double x, double y, double z, double w)
        {
            _vector[0] = x;
            _vector[1] = y;
            _vector[2] = z;
            _vector[3] = w;
        }

        public Vec4d(Vec3d v, double w)
        {
            _vector[0] = v.X;
            _vector[1] = v.Y;
            _vector[2] = v.Z;
            _vector[3] = w;
        }

        public double X
        {
            get => _vector[0];
            set => _vector[0] = value;
        }

        public double Y
        {
            get => _vector[1];
            set => _vector[1] = value;
        }

        public double Z
        {
            get => _vector[2];
            set => _vector[2] = value;
        }

        public double W
        {
            get => _vector[3];
            set => _vector[3] = value;
        }

        public Vec3d XYZ => new Vec3d(X, Y, Z);

        public static Vec4d operator /(Vec4d left, double scalar)
        {
            return new Vec4d(left.X / scalar, left.Y / scalar, left.Z / scalar, left.W / scalar);
        }
        public static Vec4d operator *(Vec4d left, double scalar)
        {
            return new Vec4d(left.X * scalar, left.Y * scalar, left.Z * scalar, left.W * scalar);
        }
        public static Vec4d operator *(double scalar, Vec4d right)
        {
            return new Vec4d(right.X * scalar, right.Y * scalar, right.Z * scalar, right.W * scalar);
        }
        public static Vec4d operator -(Vec4d left, Vec4d right)
        {
            return new Vec4d(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);
        }
        public static Vec4d operator -(Vec4d v)
        {
            return new Vec4d(-v.X, -v.Y, -v.Z, -v.W);
        }
        public static Vec4d operator +(Vec4d v)
        {
            return v;
        }
        public static Vec4d operator *(Vec4d left, Vec4d Right)
        {
            return new Vec4d(left.X * Right.X, left.Y * Right.Y, left.Z * Right.Z, left.W * Right.W);
        }
        public static Vec4d operator /(Vec4d left, Vec4d Right)
        {
            return new Vec4d(left.X / Right.X, left.Y / Right.Y, left.Z / Right.Z, left.W / Right.W);
        }
        public static Vec4d operator +(Vec4d left, Vec4d Right)
        {
            return new Vec4d(left.X + Right.X, left.Y + Right.Y, left.Z + Right.Z, left.W + Right.W);
        }
        public static Vec4d operator *(Mat4d l, Vec4d r)
        {
            return new Vec4d(
                l.M11 * r.X + l.M12 * r.Y + l.M13 * r.Z + l.M14 * r.W,
                l.M21 * r.X + l.M22 * r.Y + l.M23 * r.Z + l.M24 * r.W, 
                l.M31 * r.X + l.M32 * r.Y + l.M33 * r.Z + l.M34 * r.W,
                l.M41 * r.X + l.M42 * r.Y + l.M43 * r.Z + l.M44 * r.W);
        }
        public static Vec4d operator *(Vec4d l, Mat4d r)
        {
            return new Vec4d(
                l.X * r.M11 + l.Y * r.M21 + l.Z * r.M31 + l.W * r.M41,
                l.X * r.M12 + l.Y * r.M22 + l.Z * r.M32 + l.W * r.M42,
                l.X * r.M13 + l.Y * r.M23 + l.Z * r.M33 + l.W * r.M43,
                l.X * r.M14 + l.Y * r.M24 + l.Z * r.M34 + l.W * r.M44);
        }

        public double Length
        {
            get => Math.Sqrt(X * X + Y * Y + Z * Z + W * W);
        }

        public void Normalize()
        {
            double invLength = 1.0d / Length;
            X *= invLength;
            Y *= invLength;
            Z *= invLength;
            W *= invLength;
        }

        public static Vec4d Zero => new Vec4d(0, 0, 0, 0);
        public static Vec4d One => new Vec4d(1, 1, 1, 1);
        public static Vec4d UnitX => new Vec4d(1, 0, 0, 0);
        public static Vec4d UnitY => new Vec4d(0, 1, 0, 0);
        public static Vec4d UnitZ => new Vec4d(0, 0, 1, 0);
        public static Vec4d UnitW => new Vec4d(0, 0, 0, 1);

        public static double Dot(Vec4d left, Vec4d right)
        {
            return left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;
        }


        public Vec3d Project()
        {
            double invW = 1 / W;
            return new(X * invW, Y * invW, Z * invW);
        }
    }
    public struct Vec2f
    {
        private Vec<float> _vector = new Vec<float>(2);

        public Vec2f(float x, float y)
        {
            _vector[0] = x;
            _vector[1] = y;
        }

        public float X
        {
            get => _vector[0];
            set => _vector[0] = value;
        }

        public float Y
        {
            get => _vector[1];
            set => _vector[1] = value;
        }

        public static Vec2f operator /(Vec2f left, float scalar)
        {
            return new Vec2f(left.X / scalar, left.Y / scalar);
        }
        public static Vec2f operator *(Vec2f left, float scalar)
        {
            return new Vec2f(left.X * scalar, left.Y * scalar);
        }
        public static Vec2f operator *(float scalar, Vec2f right)
        {
            return new Vec2f(right.X * scalar, right.Y * scalar);
        }
        public static Vec2f operator -(Vec2f left, Vec2f right)
        {
            return new Vec2f(left.X - right.X, left.Y - right.Y);
        }
        public static Vec2f operator -(Vec2f v)
        {
            return new Vec2f(-v.X, -v.Y);
        }
        public static Vec2f operator +(Vec2f v)
        {
            return v;
        }
        public static Vec2f operator *(Vec2f left, Vec2f Right)
        {
            return new Vec2f(left.X * Right.X, left.Y * Right.Y);
        }
        public static Vec2f operator /(Vec2f left, Vec2f Right)
        {
            return new Vec2f(left.X / Right.X, left.Y / Right.Y);
        }
        public static Vec2f operator +(Vec2f left, Vec2f Right)
        {
            return new Vec2f(left.X + Right.X, left.Y + Right.Y);
        }

        public float Length
        {
            get => MathF.Sqrt(X * X + Y * Y);
        }

        public void Normalize()
        {
            float invLength = 1 / Length;
            X *= invLength;
            Y *= invLength;
        }

        public static Vec2f Zero => new Vec2f(0, 0);
        public static Vec2f One => new Vec2f(1, 1);
        public static Vec2f UnitX => new Vec2f(1, 0);
        public static Vec2f UnitY => new Vec2f(0, 1);

        public static float Dot(Vec2f left, Vec2f right)
        {
            return left.X * right.X + left.Y * right.Y;
        }
    }
    public struct Vec3f
    {
        private Vec<float> _vector = new Vec<float>(3);

        public Vec3f(float x, float y, float z)
        {
            _vector[0] = x;
            _vector[1] = y;
            _vector[2] = z;
        }

        public float X
        {
            get => _vector[0];
            set => _vector[0] = value;
        }

        public float Y
        {
            get => _vector[1];
            set => _vector[1] = value;
        }

        public float Z
        {
            get => _vector[2];
            set => _vector[2] = value;
        }

        public static Vec3f operator /(Vec3f left, float scalar)
        {
            return new Vec3f(left.X / scalar, left.Y / scalar, left.Z / scalar);
        }
        public static Vec3f operator *(Vec3f left, float scalar)
        {
            return new Vec3f(left.X * scalar, left.Y * scalar, left.Z * scalar);
        }
        public static Vec3f operator *(float scalar, Vec3f right)
        {
            return new Vec3f(right.X * scalar, right.Y * scalar, right.Z * scalar);
        }
        public static Vec3f operator -(Vec3f left, Vec3f right)
        {
            return new Vec3f(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
        }
        public static Vec3f operator -(Vec3f v)
        {
            return new Vec3f(-v.X, -v.Y, -v.Z);
        }
        public static Vec3f operator +(Vec3f v)
        {
            return v;
        }
        public static Vec3f operator *(Vec3f left, Vec3f Right)
        {
            return new Vec3f(left.X * Right.X, left.Y * Right.Y, left.Z * Right.Z);
        }
        public static Vec3f operator /(Vec3f left, Vec3f Right)
        {
            return new Vec3f(left.X / Right.X, left.Y / Right.Y, left.Z / Right.Z);
        }
        public static Vec3f operator +(Vec3f left, Vec3f Right)
        {
            return new Vec3f(left.X + Right.X, left.Y + Right.Y, left.Z + Right.Z);
        }

        public float Length
        {
            get => MathF.Sqrt(X * X + Y * Y + Z * Z);
        }

        public void Normalize()
        {
            float invLength = 1.0f / Length;
            X *= invLength;
            Y *= invLength;
            Z *= invLength;
        }

        public static Vec3f Zero =>  new Vec3f(0, 0, 0);
        public static Vec3f One =>   new Vec3f(1, 1, 1);
        public static Vec3f UnitX => new Vec3f(1, 0, 0);
        public static Vec3f UnitY => new Vec3f(0, 1, 0);
        public static Vec3f UnitZ => new Vec3f(0, 0, 1);

        public static Vec3f Cross(Vec3f left, Vec3f right)
        {
            return new Vec3f(
                left.Y * right.Z - left.Z * right.Y,
                left.Z * right.X - left.X * right.Z,
                left.X * right.Y - left.Y * right.X);
        }
        public static float Dot(Vec3f left, Vec3f right)
        {
            return left.X * right.X + left.Y * right.Y + left.Z * right.Z;
        }
    }
    public struct Vec4f
    {
        private Vec<float> _vector = new Vec<float>(4);

        public Vec4f(float x, float y, float z, float w)
        {
            _vector[0] = x;
            _vector[1] = y;
            _vector[2] = z;
            _vector[3] = w;
        }

        public float X
        {
            get => _vector[0];
            set => _vector[0] = value;
        }

        public float Y
        {
            get => _vector[1];
            set => _vector[1] = value;
        }

        public float Z
        {
            get => _vector[2];
            set => _vector[2] = value;
        }

        public float W
        {
            get => _vector[2];
            set => _vector[2] = value;
        }

        public Vec3f XYZ => new Vec3f(X, Y, Z);

        public static Vec4f operator /(Vec4f left, float scalar)
        {
            return new Vec4f(left.X / scalar, left.Y / scalar, left.Z / scalar, left.W / scalar);
        }
        public static Vec4f operator *(Vec4f left, float scalar)
        {
            return new Vec4f(left.X * scalar, left.Y * scalar, left.Z * scalar, left.W * scalar);
        }
        public static Vec4f operator *(float scalar, Vec4f right)
        {
            return new Vec4f(right.X * scalar, right.Y * scalar, right.Z * scalar, right.W * scalar);
        }
        public static Vec4f operator -(Vec4f left, Vec4f right)
        {
            return new Vec4f(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);
        }
        public static Vec4f operator -(Vec4f v)
        {
            return new Vec4f(-v.X, -v.Y, -v.Z, -v.W);
        }
        public static Vec4f operator +(Vec4f v)
        {
            return v;
        }
        public static Vec4f operator *(Vec4f left, Vec4f Right)
        {
            return new Vec4f(left.X * Right.X, left.Y * Right.Y, left.Z * Right.Z, left.W * Right.W);
        }
        public static Vec4f operator /(Vec4f left, Vec4f Right)
        {
            return new Vec4f(left.X / Right.X, left.Y / Right.Y, left.Z / Right.Z, left.W / Right.W);
        }
        public static Vec4f operator +(Vec4f left, Vec4f Right)
        {
            return new Vec4f(left.X + Right.X, left.Y + Right.Y, left.Z + Right.Z, left.W + Right.W);
        }
        public static Vec4f operator *(Mat4f l, Vec4f r)
        {
            return new Vec4f(
                l.M11 * r.X + l.M12 * r.Y + l.M13 * r.Z + l.M14 * r.W,
                l.M21 * r.X + l.M22 * r.Y + l.M23 * r.Z + l.M24 * r.W,
                l.M31 * r.X + l.M32 * r.Y + l.M33 * r.Z + l.M34 * r.W,
                l.M41 * r.X + l.M42 * r.Y + l.M43 * r.Z + l.M44 * r.W);
        }
        public static Vec4f operator *(Vec4f l, Mat4f r)
        {
            return new Vec4f(
                l.X * r.M11 + l.Y * r.M21 + l.Z * r.M31 + l.W * r.M41,
                l.X * r.M12 + l.Y * r.M22 + l.Z * r.M32 + l.W * r.M42,
                l.X * r.M13 + l.Y * r.M23 + l.Z * r.M33 + l.W * r.M43,
                l.X * r.M14 + l.Y * r.M24 + l.Z * r.M34 + l.W * r.M44);
        }

        public float Length
        {
            get => MathF.Sqrt(X * X + Y * Y + Z * Z + W * W);
        }

        public void Normalize()
        {
            float invLength = 1.0f / Length;
            X *= invLength;
            Y *= invLength;
            Z *= invLength;
            W *= invLength;
        }
        public static Vec4f Zero =>  new Vec4f(0, 0, 0, 0);
        public static Vec4f One =>   new Vec4f(1, 1, 1, 1);
        public static Vec4f UnitX => new Vec4f(1, 0, 0, 0);
        public static Vec4f UnitY => new Vec4f(0, 1, 0, 0);
        public static Vec4f UnitZ => new Vec4f(0, 0, 1, 0);
        public static Vec4f UnitW => new Vec4f(0, 0, 0, 1);

        public static float Dot(Vec4f left, Vec4f right)
        {
            return left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;
        }

        public Vec3f Project()
        {
            float invW = 1 / W;
            return new(X * invW, Y * invW, Z * invW);
        }
    }
}
