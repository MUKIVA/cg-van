using Lw7.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lw7.Model
{
    public class LightShader : IShader
    {
        private LightShaderMaterial _material = new();

        public void SetMaterial(LightShaderMaterial material)
        {
            _material = material;
        }

        public Vec4d Shade(ShadeContext shadeContext)
        {
            Scene scene = shadeContext.GetScene();

            Vec4d shadedColor = Vec4d.Zero;

            int numLights = scene.GetLightCount();

            for (int i = 0; i < numLights; ++i)
            {
                ILightSource light = scene.GetLight(i);

                // Вычисляем вектор направления на источник света из текущей точки
                Vec3d lightDirection = light.GetDirectionFromPoint(shadeContext.GetSurfacePoint());
                // Вычисляем интенсивность света в направлении от источника к текущей точке
                double lightIntensity = light.GetIntensityInDirection(-lightDirection);
                // Получаем нормаль к поверхности в обрабатываемой точке
                Vec3d n = shadeContext.GetSurfaceNormal();
                // diffuse
                double nDotL = MathHelper.Max(Vec3d.Dot(n, lightDirection.Normalized()), 0.0);
                // Вычисляем диффузный цвет точки
                Vec4d diffuseColor = (nDotL * lightIntensity) * light.DiffuseIntensity * _material.DiffuseColor;

                //specular
                Vec3d reflect = Vec3d.Reflect(shadeContext.GetRayDirection().Normalized(), n.Normalized());
                double spec = Math.Pow(MathHelper.Max(Vec3d.Dot(lightDirection.Normalized(), reflect), 0.0), _material.Shinines);
                Vec4d specular = (lightIntensity * spec) * light.SpecularIntensity * _material.SpecularColor;

                //ambient
                Vec4d ambient = (lightIntensity * (light.AmbientIntensity * _material.AmbientColor));

                Ray shadowRay = new(shadeContext.GetSurfacePoint(), reflect.Normalized());
                Intersection shadowIntersection = new();
                SceneObject? obj = null;
                if (scene.GetFirstHit(shadowRay, ref shadowIntersection, ref obj))
                {
                    var hit = shadowIntersection.GetHit(0).GetHitPoint();
                    var castLength = (hit - shadeContext.GetSurfacePoint()).Length;
                    var lightDirLength = lightDirection.Length;
                    if (castLength >= lightDirLength)
                    {
                        shadedColor += diffuseColor + specular + ambient;
                    }
                    else
                    {
                        shadedColor += ambient;
                    }
                }
                else
                { 
                    shadedColor += diffuseColor + specular + ambient;
                }
            }
            return shadedColor;
        }
    }
}
