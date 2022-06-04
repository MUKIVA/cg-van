using System;

namespace Lw7.Model
{
    public class SceneObject
    {
        private IGeometryObject _object;
        private IShader? _shader;

        public SceneObject(IGeometryObject obj, IShader? shader = null)
        {
            _object = obj;
            _shader = shader;
        }

        public IGeometryObject GetGeometryObject()
        {
            return _object;
        }

        public bool HasShader()
        {
            return _shader != null;
        }

        public IShader GetShader()
        {
            if (!HasShader())
                throw new Exception("Object has no shader");

            return _shader!; 
        }
    }
}
