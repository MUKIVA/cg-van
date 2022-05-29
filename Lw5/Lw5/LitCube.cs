using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;

namespace Lw5
{
    public class LitCube : UnlitCube, ICollisionObject
    {
        private float _shininess = 32.0f;
        public Light _light;

        private Texture? _diffuseMap;
        private Texture? _specularMap;
        private Texture? _normalMap;

        public bool CollisionEnable { get; set; } = true;

        public LitCube(Light light, Texture? diffuseMap = null, Texture? specularMap = null, Texture? normalMap = null)
            : base(new Shader($@"{Common.ShaderDir}\shader.vert", $@"{Common.ShaderDir}\lit.frag"))
        {
            _light = light;
            _diffuseMap = diffuseMap;
            _specularMap = specularMap;
            _normalMap = normalMap;
            if (_specularMap != null)
                _specularMap.TexBlock = TextureUnit.Texture1;
            if (_normalMap != null)
                _normalMap.TexBlock = TextureUnit.Texture2;
        }

        public override void Draw(Camera camera)
        {

            _material.Use();
            if (_diffuseMap != null)
                _diffuseMap.Use();
            if (_specularMap != null)
                _specularMap.Use();
            if (_normalMap != null)
                _normalMap.Use();
            _material.SetInt("material.diffuse", 0);
            _material.SetInt("material.specular", 1);
            _material.SetInt("material.normal", 2);
            _material.SetFloat("material.shininess", _shininess);

            _material.SetVector3("light.position", _light.Position);
            _material.SetVector3("light.ambient", _light.Ambient);
            _material.SetVector3("light.diffuse", _light.Diffuse);
            _material.SetVector3("light.specular", _light.Specular);
            _material.SetFloat("light.constant", _light.Constant);
            _material.SetFloat("light.linear", _light.Linear);
            _material.SetFloat("light.quadratic", _light.Quadratic);

            _material.SetVector3("uViewPos", camera.Posion);
            base.Draw(camera);
        }

        public CollisionAction EnumeratePoints(Func<Vector3, Vector3, Vector3> call)
        {
            CollisionAction result = new();

            Vector3 norm = call(BackLeftTopPoint, FrontRightTopPoint);
            result.Result = (norm != Vector3.Zero);
            result.Normal = norm;

            return result;
        }

        public Vector3 Intersect(Vector3 topLeft, Vector3 bottomRight)
        {

            if (!CollisionEnable) return Vector3.Zero;

            bool isIntesect = !(topLeft.Z > FrontRightTopPoint.Z || bottomRight.Z < BackLeftTopPoint.Z ||
                bottomRight.X < BackLeftTopPoint.X || topLeft.X > FrontRightTopPoint.X);

            if (!isIntesect) return Vector3.Zero;

            Vector3 result = Vector3.Zero;

            if ((IntersectPointZoX(topLeft) && IntersectPointZoX(new(bottomRight.X, 0, topLeft.Z))) || IntersectPointZoY(topLeft))
                result += Vector3.UnitZ;
            if ((IntersectPointZoX(bottomRight) && IntersectPointZoX(new(topLeft.X, 0, bottomRight.Z))) || IntersectPointZoY(bottomRight))
                result -= Vector3.UnitZ;
            if ((IntersectPointZoX(topLeft) && IntersectPointZoX(new(topLeft.X, 0, bottomRight.Z))) || IntersectPointYoX(topLeft))
                result += Vector3.UnitX;
            if ((IntersectPointZoX(bottomRight) && IntersectPointZoX(new(bottomRight.X, 0, topLeft.Z))) || IntersectPointYoX(bottomRight))
                result -= Vector3.UnitX;

            return result;
        }

        public bool IntersectPointZoX(Vector3 point)
        {
            return !(point.X > FrontRightTopPoint.X || point.X < BackLeftTopPoint.X || 
                point.Z > FrontRightTopPoint.Z || point.Z < BackLeftTopPoint.Z);
        }

        public bool IntersectPointZoY(Vector3 point)
        {
            return !(point.Y > FrontRightTopPoint.Y || point.Y < BackRightBottomPoint.Y ||
                point.Z > FrontRightTopPoint.Z || point.Z < BackRightBottomPoint.Z);
        }

        public bool IntersectPointYoX(Vector3 point)
        {
            return !(point.Y > FrontLeftTopPoint.Y || point.Y < FrontRightBottomPoint.Y ||
                point.X > FrontRightBottomPoint.X || point.X < FrontLeftTopPoint.X);
        }

        public bool LerpIntersection(Vector3 s, Vector3 e)
        {
            for (float t = 0; t <= 1; t += 0.1f)
                if (IntersectPointZoX(Vector3.Lerp(s, e, t)))
                    return true;
            return false;
        }
    }
}
