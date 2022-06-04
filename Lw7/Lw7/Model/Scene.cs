using Lw7.Mathematics;
using System.Collections.Generic;

namespace Lw7.Model
{
    public class Scene
    {
        private List<SceneObject> _sceneObjects = new();
        private List<ILightSource> _lightSources = new();
        private Vec4d _backdropColor;

        public Scene()
        {   

        }

        public void SetBackdropColor(Vec4d color)
        {
            _backdropColor = color;
        }

        public Vec4d GetBackdropColor()
        {
            return _backdropColor;
        }

        public void AddObject(SceneObject obj)
        {
            _sceneObjects.Add(obj);
        }

        public void AddLightSource(ILightSource lightSource)
        {
            _lightSources.Add(lightSource);   
        }

        public ILightSource GetLight(int index)
        {
            return _lightSources[index];
        }

        public int GetLightCount()
        {
            return _lightSources.Count;
        }

        public Vec4d Shade(Ray ray)
        {
            Intersection bestIntersection = new();
            SceneObject? sceneObject = null;

            if (GetFirstHit(ray, ref bestIntersection, ref sceneObject))
            {
                if (sceneObject != null && sceneObject.HasShader())
                {
                    IShader shader = sceneObject.GetShader();

                    HitInfo hit = bestIntersection.GetHit(0);

                    ShadeContext shadeContext = new ShadeContext(
                        this,
                        hit.GetHitPoint(),
                        hit.GetHitPointInObjectSpace(),
                        hit.GetNormal(),
                        ray.Direction
                        );

                    return shader.Shade(shadeContext);
                }
            }

            return _backdropColor;
        }

        public bool GetFirstHit(Ray ray, ref Intersection bestIntersection, ref SceneObject? intersectionObject)
        {
            bestIntersection.Clear();

            int n = _sceneObjects.Count;

            for (int i = 0; i < n; ++i)
            {
                Intersection intersection = new();

                SceneObject sceneObject = _sceneObjects[i];

                IGeometryObject geometryObject = sceneObject.GetGeometryObject();

                if (geometryObject.Hit(ray, intersection))
                {
                    if (
                        (bestIntersection.GetHitsCount() == 0) ||
                        (intersection.GetHit(0).GetHitTime() < bestIntersection.GetHit(0).GetHitTime())
                        )
                    {
                        bestIntersection = intersection;
                        intersectionObject = sceneObject;
                    }
                }
            }

            return bestIntersection.GetHitsCount() > 0;
        }
    }
}
