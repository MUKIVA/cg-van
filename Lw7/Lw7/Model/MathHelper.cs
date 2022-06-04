using System;
using Lw7.Mathematics;

namespace Lw7.Model
{
    public static class MathHelper
    {
        public static double Fract(double value)
        {
            return value - Math.Floor(value);
        }

        public static Vec2d Fract(Vec2d value)
        {
            return new(Fract(value.X), Fract(value.Y));
        }

        public static Vec3d Fract(Vec3d value)
        {
            return new(Fract(value.X), Fract(value.Y), Fract(value.Z));
        }

        public static Vec4d Fract(Vec4d value)
        {
            return new(Fract(value.X), Fract(value.Y), Fract(value.Z), Fract(value.W));
        }

        public static double Step(double edge, double x)
        {
            return x < edge ? 0 : 1;
        }

        public static Vec2d Step(double edge, Vec2d x)
        {
            return new(Step(edge, x.X), Step(edge, x.Y));
        }

        public static Vec3d Step(double edge, Vec3d x)
        {
            return new(Step(edge, x.X), Step(edge, x.Y), Step(edge, x.Z));
        }

        public static Vec4d Step(double edge, Vec4d x)
        {
            return new(Step(edge, x.X), Step(edge, x.Y), Step(edge, x.Z), Step(edge, x.W));
        }

        public static double Min(double x, double y)
        {
            return x < y ? x : y;
        }

        public static Vec2d Min(Vec2d vec, double scalar)
        {
            return new(Min(vec.X, scalar), Min(vec.Y, scalar));
        }

        public static Vec3d Min(Vec3d vec, double scalar)
        {
            return new(Min(vec.X, scalar), Min(vec.Y, scalar), Min(vec.Z, scalar));
        }

        public static Vec4d Min(Vec4d vec, double scalar)
        {
            return new(Min(vec.X, scalar), Min(vec.Y, scalar), Min(vec.Z, scalar), Min(vec.W, scalar));
        }

        public static double Max(double x, double y)
        {
            return x > y ? x : y;
        }

        public static Vec2d Max(Vec2d vec, double scalar)
        {
            return new(Max(vec.X, scalar), Max(vec.Y, scalar));
        }

        public static Vec3d Max(Vec3d vec, double scalar)
        {
            return new(Max(vec.X, scalar), Max(vec.Y, scalar), Max(vec.Z, scalar));
        }

        public static Vec4d Max(Vec4d vec, double scalar)
        {
            return new(Max(vec.X, scalar), Max(vec.Y, scalar), Max(vec.Z, scalar), Max(vec.W, scalar));
        }

        public static Vec2d Clamp(Vec2d vec, double min, double max)
        {
            return Max(Min(vec, max), min);
        }

        public static Vec3d Clamp(Vec3d vec, double min, double max)
        {
            return Max(Min(vec, max), min);
        }

        public static Vec4d Clamp(Vec4d vec, double min, double max)
        {
            return Max(Min(vec, max), min);
        }
    }
}
