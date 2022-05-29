using OpenTK.Graphics.OpenGL4;
using OpenTK.Graphics;
using OpenTK.Mathematics;

namespace Lw6
{


    public class Shader
    {
        public int Handle { get; private set; } = 0;

        public Shader(string vert, string frag)
        {
            string vertSource = File.ReadAllText(vert);
            string fragSource = File.ReadAllText(frag);

            var vertShader = GL.CreateShader(ShaderType.VertexShader);
            var fragShader = GL.CreateShader(ShaderType.FragmentShader);

            GL.ShaderSource(vertShader, vertSource);
            GL.ShaderSource(fragShader, fragSource);

            GL.CompileShader(vertShader);
            GL.GetShaderInfoLog(vertShader, out string vertShaderLog);
            if (vertShaderLog != string.Empty)
                Console.WriteLine($"VertShader:\n {vertShader}");

            GL.CompileShader(fragShader);
            GL.GetShaderInfoLog(fragShader, out string fragShaderLog);
            if (fragShaderLog != string.Empty)
                Console.WriteLine($"FragShader:\n {fragShaderLog}");

            Handle = GL.CreateProgram();

            GL.AttachShader(Handle, vertShader);
            GL.AttachShader(Handle, fragShader);

            GL.LinkProgram(Handle);

            GL.DetachShader(Handle, vertShader);
            GL.DetachShader(Handle, fragShader);
            GL.DeleteShader(vertShader);
            GL.DeleteShader(fragShader);
        }

        public void Use()
        {
            GL.UseProgram(Handle);
        }

        public void SetVector3(string name, Vector3 value)
        {
            int location = GL.GetUniformLocation(Handle, name);
            if (location == -1)
                throw new Exception("Location not found");
            GL.Uniform3(location, value);
        }

        public void SetVector2(string name, Vector2 value)
        {
            int location = GL.GetUniformLocation(Handle, name);
            if (location == -1)
                throw new Exception("Location not found");
            GL.Uniform2(location, value);
        }

        public void SetFloat(string name, float value)
        {
            int location = GL.GetUniformLocation(Handle, name);
            if (location == -1)
                throw new Exception("Location not found");
            GL.Uniform1(location, value);
        }

        public void SetMat4(string name, Matrix4 value)
        {
            int location = GL.GetUniformLocation(Handle, name);
            if (location == -1)
                throw new Exception("Location not found");
            GL.UniformMatrix4(location, false, ref value);
        }

        public void SetInt(string name, int value)
        {
            int location = GL.GetUniformLocation(Handle, name);
            if (location == -1)
                throw new Exception("Location not found");
            GL.Uniform1(location, value);
        }

        public void SetDouble(string name, double value)
        {
            int location = GL.GetUniformLocation(Handle, name);
            if (location == -1)
                throw new Exception("Location not found");
            GL.Uniform1(location, value);
        }

        public int GetAttribLocation(string name)
        {
            return GL.GetAttribLocation(Handle, name);
        }

    }
}
