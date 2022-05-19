using OpenTK.Mathematics;
namespace Lw5
{
    public class Transform
    {
        public Vector3 Position { get; set; } = Vector3.Zero;
        public Vector3 Scale { get; set; } = Vector3.One;
        public Vector3 Rotation { get; set; } = Vector3.Zero;

        public Matrix4 GetModelMatrix()
        {
            return Matrix4.Identity *
                Matrix4.CreateScale(Scale) *
                Matrix4.CreateRotationZ(Rotation.Z) *
                Matrix4.CreateRotationY(Rotation.Y) *
                Matrix4.CreateRotationX(Rotation.X) *
                Matrix4.CreateTranslation(Position);
        }
    }
}
