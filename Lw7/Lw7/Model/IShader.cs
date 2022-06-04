using Lw7.Mathematics;

namespace Lw7.Model
{
    public interface IShader
    {
        public Vec4d Shade(ShadeContext shadeContext);
    }
}
