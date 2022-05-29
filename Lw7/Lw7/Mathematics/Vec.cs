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

        public static Vec3d Zero => new Vec3d(0, 0, 0);
        public static Vec3d One => new Vec3d(1, 1, 1);
        public static Vec3d UnitX => new Vec3d(1, 0, 0);
        public static Vec3d UnitY => new Vec3d(0, 1, 0);
        public static Vec3d UnitZ => new Vec3d(0, 0, 1);
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
            get => _vector[2];
            set => _vector[2] = value;
        }

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
    }
}
