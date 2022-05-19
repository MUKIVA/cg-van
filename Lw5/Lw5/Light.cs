using OpenTK.Mathematics;

namespace Lw5
{
    public class Light
    {
        private UnlitCube _cube;

        public Vector3 Ambient { get; set; } = new Vector3(0.2f);
        public Vector3 Diffuse { get; set; } = new Vector3(0.5f);
        public Vector3 Specular { get; set; } = new Vector3(1.0f);

        public float Constant { get; set; } = 1.0f;
        public float Linear { get; set; } = 0.35f;
        public float Quadratic { get; set; } = 0.44f;

        public Light()
        {
            _cube = new UnlitCube();
        }

        public Vector3 Position
        {
            get => _cube.Transform.Position;
            set
            {
                _cube.Transform.Position = value;
            }
        }

        public Vector3 Scale
        {
            get => _cube.Transform.Scale;
            set => _cube.Transform.Scale = value;
        }

        public void Draw(Camera camera) => _cube.Draw(camera);
    }
}
