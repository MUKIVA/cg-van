using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace Lw5
{
    public class UnlitCube
    {
        protected readonly float[] _vertices =
        {
             // positions          // normals           // texture coords
            -0.5f, -0.5f, -0.5f,  0.0f,  0.0f, -1.0f,  0.0f, 0.0f,
             0.5f, -0.5f, -0.5f,  0.0f,  0.0f, -1.0f,  1.0f, 0.0f,
             0.5f,  0.5f, -0.5f,  0.0f,  0.0f, -1.0f,  1.0f, 1.0f,
             0.5f,  0.5f, -0.5f,  0.0f,  0.0f, -1.0f,  1.0f, 1.0f,
            -0.5f,  0.5f, -0.5f,  0.0f,  0.0f, -1.0f,  0.0f, 1.0f,
            -0.5f, -0.5f, -0.5f,  0.0f,  0.0f, -1.0f,  0.0f, 0.0f,

            -0.5f, -0.5f,  0.5f,  0.0f,  0.0f, 1.0f,   0.0f, 0.0f,
             0.5f, -0.5f,  0.5f,  0.0f,  0.0f, 1.0f,   1.0f, 0.0f,
             0.5f,  0.5f,  0.5f,  0.0f,  0.0f, 1.0f,   1.0f, 1.0f,
             0.5f,  0.5f,  0.5f,  0.0f,  0.0f, 1.0f,   1.0f, 1.0f,
            -0.5f,  0.5f,  0.5f,  0.0f,  0.0f, 1.0f,   0.0f, 1.0f,
            -0.5f, -0.5f,  0.5f,  0.0f,  0.0f, 1.0f,   0.0f, 0.0f,

            -0.5f,  0.5f,  0.5f, -1.0f,  0.0f,  0.0f,  1.0f, 1.0f,
            -0.5f,  0.5f, -0.5f, -1.0f,  0.0f,  0.0f,  0.0f, 1.0f,
            -0.5f, -0.5f, -0.5f, -1.0f,  0.0f,  0.0f,  0.0f, 0.0f,
            -0.5f, -0.5f, -0.5f, -1.0f,  0.0f,  0.0f,  0.0f, 0.0f,
            -0.5f, -0.5f,  0.5f, -1.0f,  0.0f,  0.0f,  1.0f, 0.0f,
            -0.5f,  0.5f,  0.5f, -1.0f,  0.0f,  0.0f,  1.0f, 1.0f,

             0.5f,  0.5f,  0.5f,  1.0f,  0.0f,  0.0f,  0.0f, 1.0f,
             0.5f,  0.5f, -0.5f,  1.0f,  0.0f,  0.0f,  1.0f, 1.0f,
             0.5f, -0.5f, -0.5f,  1.0f,  0.0f,  0.0f,  1.0f, 0.0f,
             0.5f, -0.5f, -0.5f,  1.0f,  0.0f,  0.0f,  1.0f, 0.0f,
             0.5f, -0.5f,  0.5f,  1.0f,  0.0f,  0.0f,  0.0f, 0.0f,
             0.5f,  0.5f,  0.5f,  1.0f,  0.0f,  0.0f,  0.0f, 1.0f,

            -0.5f, -0.5f, -0.5f,  0.0f, -1.0f,  0.0f,  0.0f, 1.0f,
             0.5f, -0.5f, -0.5f,  0.0f, -1.0f,  0.0f,  1.0f, 1.0f,
             0.5f, -0.5f,  0.5f,  0.0f, -1.0f,  0.0f,  1.0f, 0.0f,
             0.5f, -0.5f,  0.5f,  0.0f, -1.0f,  0.0f,  1.0f, 0.0f,
            -0.5f, -0.5f,  0.5f,  0.0f, -1.0f,  0.0f,  0.0f, 0.0f,
            -0.5f, -0.5f, -0.5f,  0.0f, -1.0f,  0.0f,  0.0f, 1.0f,

            -0.5f,  0.5f, -0.5f,  0.0f,  1.0f,  0.0f,  0.0f, 1.0f,
             0.5f,  0.5f, -0.5f,  0.0f,  1.0f,  0.0f,  1.0f, 1.0f,
             0.5f,  0.5f,  0.5f,  0.0f,  1.0f,  0.0f,  1.0f, 0.0f,
             0.5f,  0.5f,  0.5f,  0.0f,  1.0f,  0.0f,  1.0f, 0.0f,
            -0.5f,  0.5f,  0.5f,  0.0f,  1.0f,  0.0f,  0.0f, 0.0f,
            -0.5f,  0.5f, -0.5f,  0.0f,  1.0f,  0.0f,  0.0f, 1.0f
        };

        private int _vao;
        private int _vbo;
        protected Shader _material;
 

        public readonly Transform Transform = new Transform();

        public Vector3 FrontRightTopPoint    => new(new Vector4 ( 0.5f,   0.5f,   0.5f, 1f) * Transform.GetModelMatrix());
        public Vector3 FrontLeftTopPoint     => new(new Vector4 (-0.5f,   0.5f,   0.5f, 1f) * Transform.GetModelMatrix());
        public Vector3 BackLeftTopPoint      => new(new Vector4 (-0.5f,   0.5f,  -0.5f, 1f) * Transform.GetModelMatrix());
        public Vector3 BackRightTopPoint     => new(new Vector4 ( 0.5f,   0.5f,  -0.5f, 1f) * Transform.GetModelMatrix());
        public Vector3 FrontRightBottomPoint => new(new Vector4 ( 0.5f,  -0.5f,   0.5f, 1f) * Transform.GetModelMatrix());
        public Vector3 FrontLeftBottomPoint  => new(new Vector4 (-0.5f,  -0.5f,   0.5f, 1f) * Transform.GetModelMatrix());
        public Vector3 BackLeftBottomPoint   => new(new Vector4 (-0.5f,  -0.5f,  -0.5f, 1f) * Transform.GetModelMatrix());
        public Vector3 BackRightBottomPoint  => new(new Vector4 ( 0.5f,  -0.5f,  -0.5f, 1f) * Transform.GetModelMatrix());

        public UnlitCube(Shader? shader = null)
        {
            _material = (shader == null)
                ? new Shader($@"{Common.ShaderDir}\shader.vert", $@"{Common.ShaderDir}\unlit.frag")
                : shader;

            _vao = GL.GenVertexArray();
            _vbo = GL.GenBuffer();

            GL.BindVertexArray(_vao);
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vbo);
            GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);


            var pos = _material.GetAttribLocation("aPos");
            GL.EnableVertexAttribArray(pos);
            GL.VertexAttribPointer(pos, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), 0);

            var normal = _material.GetAttribLocation("aNormal");
            GL.EnableVertexAttribArray(normal);
            GL.VertexAttribPointer(normal, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), 3 * sizeof(float));

            var tex = _material.GetAttribLocation("aTexCoord");
            GL.EnableVertexAttribArray(tex);
            GL.VertexAttribPointer(tex, 2, VertexAttribPointerType.Float, false, 8 * sizeof(float), 6 * sizeof(float));
        }

        public virtual void Draw(Camera camera)
        {
            GL.BindVertexArray(_vao);

            _material.Use();
            _material.SetMat4("uView", camera.GetViewMatrix());
            _material.SetMat4("uProj", camera.GetProjectionMatrix());
            _material.SetMat4("uModel", Transform.GetModelMatrix());
            GL.DrawArrays(PrimitiveType.Triangles, 0, 36);
        }
    }
}
