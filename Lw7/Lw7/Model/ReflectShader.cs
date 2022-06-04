using Lw7.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lw7.Model
{
    public class ReflectShader : IShader
    {
        public ReflectShader()
        { 
        }

        public Vec4d Shade(ShadeContext shadeContext)
        {
            var position = shadeContext.GetSurfacePoint();
            var normal = shadeContext.GetSurfaceNormal();
            var rayDirection = shadeContext.GetRayDirection();
            var scene = shadeContext.GetScene();

            var reflectDirection = Vec3d.Reflect(rayDirection, normal);
            Ray reflectRay = new(position, reflectDirection.Normalized());

            Intersection bestIntersect = new();
            SceneObject? sceneObject = null;

            scene.GetFirstHit(reflectRay, ref bestIntersect, ref sceneObject);

            if (sceneObject != null)
            {
                var hit = bestIntersect.GetHit(0);

                ShadeContext context = new(
                    scene, 
                    hit.GetHitPoint(), hit.GetHitPointInObjectSpace(),
                    hit.GetNormal(), rayDirection
                    );

                return sceneObject.GetShader().Shade(context);
            }

            return scene.GetBackdropColor();
        }
    }
}
