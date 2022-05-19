using OpenTK.Mathematics;

namespace Lw5
{
    public class Ground : Quad
    {
        private const int stride = 8;
        private const int texOffset = 6;

        private readonly int _width;
        private readonly int _height;



        public Ground(Light light, Texture ambientPath, Texture specularPath, int width, int height)
            :base(light, ambientPath, specularPath, new(height, width))
        {
            _width = width;
            _height = height;

            for (int i = texOffset; i < _vert.Count; i += stride)
            {
                _vert[i] = _height;
                _vert[i + 1] = _width;
            }
        }

       
    }
}
