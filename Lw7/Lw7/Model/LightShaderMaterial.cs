using Lw7.Mathematics;

namespace Lw7.Model
{
    public class LightShaderMaterial
    {
        public Vec4d DiffuseColor  { get; set; } = Vec4d.Zero;
        public Vec4d SpecularColor { get; set; } = Vec4d.Zero;
        public Vec4d AmbientColor  { get; set; } = Vec4d.Zero;
        public double Shinines { get; set; } = 32d;

        public LightShaderMaterial()
        { 
        }
    }
}
