using Lw7.Mathematics;
using System;

namespace Lw7.Model
{
    public class CheckerShader : IShader
    {
        private Mat4d _textureTransform = Mat4d.Identity;

        public CheckerShader()
        {
            
        }

        public CheckerShader(Mat4d textureTransform)
        {
            _textureTransform = textureTransform;
        }

        public void SetTextureTransform(Mat4d textureTransform)
        {
            _textureTransform = textureTransform;
        }

        public Vec4d Shade(ShadeContext shadeContext)
        {
            Vec4d pt = new(shadeContext.GetSurfacePointInObjectSpace(), 1.0);
            Vec3d transformPoint = (pt * _textureTransform).Project();
            Vec3d frac = MathHelper.Fract(transformPoint);
            Vec3d s = MathHelper.Step(0.5, frac);

            Scene scene = shadeContext.GetScene();
            int lightCount = scene.GetLightCount();

            Vec4d shadedColor = new(0.5, 0.5, 0.5, 0.5);

            for (int i = 0; i < lightCount; ++i)
            {
                // Получаем источник света
                ILightSource light = scene.GetLight(i);
                // Вычисляем вектор направления на источник света из текущей точке
                Vec3d lightDirection = light.GetDirectionFromPoint(shadeContext.GetSurfacePoint());
                // Вычисляем интенсивность света в направлении от источника к текущей точке
                double lightIntensity = light.GetIntensityInDirection(-lightDirection);
                // Получаем нормаль к поверхности в обрабатываемой точке
                Vec3d n = shadeContext.GetSurfaceNormal();
                // Вычисляем скалярное произведение нормали и орт-вектора направления на источник света
                double nDotL = MathHelper.Max(Vec3d.Dot(n, lightDirection.Normalized()), 0.0);
                // Вычисляем диффузный цвет точки
                Vec4d diffuseColor = (nDotL * lightIntensity) * light.DiffuseIntensity;
                // К результирующему цвету прибавляется вычисленный диффузный цвет

                Intersection inter = new();
                SceneObject? firstObj = null;

                scene.GetFirstHit(
                    new Ray(shadeContext.GetSurfacePoint(), lightDirection),
                    ref inter,
                    ref firstObj
                    );

                Vec4d shadow;
                if (inter.GetHitsCount() > 0 &&
                    lightDirection.Length >= (inter.GetHit(0).GetHitPoint() - shadeContext.GetSurfacePoint()).Length)
                    shadow = Vec4d.One * 0.8;
                else
                    shadow = new(0, 0, 0, 0);

                shadedColor += diffuseColor;
                shadedColor -= shadow;

            }

            if ((((int)s.X) ^ ((int)s.Y) ^ ((int)s.Z)) != 0)
            {
                return Vec4d.One * shadedColor;
            }
            else
            {
                return new(Vec3d.Zero, 1);
            }
        }
    }
}
