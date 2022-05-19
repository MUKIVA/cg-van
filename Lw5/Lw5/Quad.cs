using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace Lw5
{
    public class Quad
    {
        protected List<float> _vert = new()
        {
            //Pos                   // Normal           // Tex
            -0.5f, -0.0f, -0.5f,  0.0f,  1.0f, 0.0f,  0.0f, 0.0f,
             0.5f, -0.0f, -0.5f,  0.0f,  1.0f, 0.0f,  1.0f, 0.0f,
             0.5f,  0.0f,  0.5f,  0.0f,  1.0f, 0.0f,  1.0f, 1.0f,
             0.5f,  0.0f,  0.5f,  0.0f,  1.0f, 0.0f,  1.0f, 1.0f,
            -0.5f,  0.0f,  0.5f,  0.0f,  1.0f, 0.0f,  0.0f, 1.0f,
            -0.5f, -0.0f, -0.5f,  0.0f,  1.0f, 0.0f,  0.0f, 0.0f
        };

        private Texture _ambientMap;
        private Texture _specularMap;
        public Transform Transform = new();
        private Shader _material;

        private float _shininess = 32.0f;
        private Light _light;

        private int _vbo;
        private int _vao;

        public Quad(Light light, Texture ambient, Texture specular, Vector2 texScale)
        {
            _vert = new()
            {
                //Pos                   // Normal           // Tex
                -0.5f, -0.0f, -0.5f,  0.0f,  1.0f, 0.0f,  0.0f, 0.0f,
                 0.5f, -0.0f, -0.5f,  0.0f,  1.0f, 0.0f,  texScale.X, 0.0f,
                 0.5f,  0.0f,  0.5f,  0.0f,  1.0f, 0.0f,  texScale.X, texScale.Y,
                 0.5f,  0.0f,  0.5f,  0.0f,  1.0f, 0.0f,  texScale.X, texScale.Y,
                -0.5f,  0.0f,  0.5f,  0.0f,  1.0f, 0.0f,  0.0f, texScale.Y,
                -0.5f, -0.0f, -0.5f,  0.0f,  1.0f, 0.0f,  0.0f, 0.0f
            };

            _vao = GL.GenVertexArray();
            _vbo = GL.GenBuffer();
            _material = new($@"{Common.ShaderDir}\shader.vert", $@"{Common.ShaderDir}\lit.frag");

            GL.BindVertexArray(_vao);
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vbo);
            GL.BufferData(BufferTarget.ArrayBuffer, _vert.Count * sizeof(float), _vert.ToArray(), BufferUsageHint.StaticDraw);


            var pos = _material.GetAttribLocation("aPos");
            GL.EnableVertexAttribArray(pos);
            GL.VertexAttribPointer(pos, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), 0);

            var normal = _material.GetAttribLocation("aNormal");
            GL.EnableVertexAttribArray(normal);
            GL.VertexAttribPointer(normal, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), 3 * sizeof(float));

            var tex = _material.GetAttribLocation("aTexCoord");
            GL.EnableVertexAttribArray(tex);
            GL.VertexAttribPointer(tex, 2, VertexAttribPointerType.Float, false, 8 * sizeof(float), 6 * sizeof(float));

            _light = light;

            _ambientMap = ambient;
            _specularMap = specular;
            _specularMap.TexBlock = TextureUnit.Texture1;
        }

        public void Draw(Camera camera)
        {
            GL.BindVertexArray(_vao);
            _material.Use();
            _ambientMap.Use();
            _specularMap.Use();
            _material.SetInt("material.diffuse", 0);
            _material.SetInt("material.specular", 1);

            _material.SetFloat("material.shininess", _shininess);

            _material.SetVector3("light.position", _light.Position);
            _material.SetVector3("light.ambient", _light.Ambient);
            _material.SetVector3("light.diffuse", _light.Diffuse);
            _material.SetVector3("light.specular", _light.Specular);
            _material.SetFloat("light.constant", _light.Constant);
            _material.SetFloat("light.linear", _light.Linear);
            _material.SetFloat("light.quadratic", _light.Quadratic);

            _material.SetVector3("uViewPos", camera.Posion);
            _material.SetMat4("uView", camera.GetViewMatrix());
            _material.SetMat4("uProj", camera.GetProjectionMatrix());
            _material.SetMat4("uModel", Transform.GetModelMatrix());
            GL.DrawArrays(PrimitiveType.Triangles, 0, 6);
        }
    }
}
