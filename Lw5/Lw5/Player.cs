using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Lw5
{
    public class Player
    {
        public LitCube Collider;
        public Camera fpsCamera { get; private set; }
        public Light light { get; private set; }
        public float Speed { get; set; } = 3.5f;
        public float MouseSensitivity { get; set; } = 0.2f;
        //public Vector3 pulling = Vector3.Zero;

        public Player(Vector3 position, float aspectRatio)
        {
            fpsCamera = new(position, aspectRatio);
            light = new();
            light.Scale = Vector3.Zero;
            light.Position = position;
            Collider = new(light);
            Collider.Transform.Position = position - Vector3.UnitY * 0.5f;
            Collider.Transform.Scale = Vector3.One * 0.4f;
            CollisionManager.SubObject(Collider);
        }

        public void GoForward(float frameTime)
        {
            var direction = fpsCamera.Front;
            direction.Y = 0;
            var oldPos = fpsCamera.Posion;
            var nextPos = fpsCamera.Posion + (direction).Normalized() * Speed * frameTime;
            Collider.Transform.Position = nextPos;
            var act = CollisionManager.OnCollision(Collider);

            if (act.Normal != Vector3.Zero)
            {
                act.Normal *= new Vector3(1f / act.Normal.X, 0, 1f / act.Normal.Z);
                //act.Normal.Normalize();

                if (MathF.Acos(act.Normal.X) == 0 ||
                    MathF.Acos(act.Normal.X) == MathF.PI)
                    nextPos.X = oldPos.X;
                if (MathF.Acos(act.Normal.Z) == 0 ||
                    MathF.Acos(act.Normal.Z) == MathF.PI)
                    nextPos.Z = oldPos.Z;
            }

            Collider.Transform.Position = nextPos;
            fpsCamera.Posion = nextPos;
            light.Position = nextPos;
        }

        public void GoBack(float frameTime)
        {
            var direction = -fpsCamera.Front;
            direction.Y = 0;
            var oldPos = fpsCamera.Posion;
            var nextPos = fpsCamera.Posion + (direction).Normalized() * Speed * frameTime;
            Collider.Transform.Position = nextPos;
            var act = CollisionManager.OnCollision(Collider);
            if (act.Normal != Vector3.Zero)
            {
                act.Normal *= new Vector3(1f / act.Normal.X, 0, 1f / act.Normal.Z);
                //act.Normal.Normalize();

                if (MathF.Acos(act.Normal.X) == 0 ||
                    MathF.Acos(act.Normal.X) == MathF.PI)
                    nextPos.X = oldPos.X;
                if (MathF.Acos(act.Normal.Z) == 0 ||
                    MathF.Acos(act.Normal.Z) == MathF.PI)
                    nextPos.Z = oldPos.Z;
            }

            Collider.Transform.Position = nextPos;
            fpsCamera.Posion = nextPos;
            light.Position = nextPos;
        }

        public void GoLeft(float frameTime)
        {
            var direction = -fpsCamera.Right;
            direction.Y = 0;
            var oldPos = fpsCamera.Posion;
            var nextPos = fpsCamera.Posion + (direction).Normalized() * Speed * frameTime;
            Collider.Transform.Position = nextPos;
            var act = CollisionManager.OnCollision(Collider);
            if (act.Normal != Vector3.Zero)
            {
                act.Normal *= new Vector3(1f / act.Normal.X, 0, 1f / act.Normal.Z);
                //act.Normal.Normalize();

                if (MathF.Acos(act.Normal.X) == 0 ||
                    MathF.Acos(act.Normal.X) == MathF.PI)
                    nextPos.X = oldPos.X;
                if (MathF.Acos(act.Normal.Z) == 0 ||
                    MathF.Acos(act.Normal.Z) == MathF.PI)
                    nextPos.Z = oldPos.Z;
            }

            Collider.Transform.Position = nextPos;
            fpsCamera.Posion = nextPos;
            light.Position = nextPos;

        }

        public void GoRight(float frameTime)
        {
            var direction = fpsCamera.Right;
            direction.Y = 0;
            var oldPos = fpsCamera.Posion;
            var nextPos = fpsCamera.Posion + (direction).Normalized() * Speed * frameTime;
            Collider.Transform.Position = nextPos;
            var act = CollisionManager.OnCollision(Collider);
            if (act.Normal != Vector3.Zero)
            {
                act.Normal *= new Vector3(1f / act.Normal.X, 0, 1f / act.Normal.Z);
                //act.Normal.Normalize();

                if (MathF.Acos(act.Normal.X) == 0 ||
                    MathF.Acos(act.Normal.X) == MathF.PI)
                    nextPos.X = oldPos.X;
                if (MathF.Acos(act.Normal.Z) == 0 ||
                    MathF.Acos(act.Normal.Z) == MathF.PI)
                    nextPos.Z = oldPos.Z;
            }

            Collider.Transform.Position = nextPos;
            fpsCamera.Posion = nextPos;
            light.Position = nextPos;
        }

        public void HandleMouse(MouseState mouse)
        {
            fpsCamera.Yaw += mouse.Delta.X * MouseSensitivity;
            fpsCamera.Pitch -= mouse.Delta.Y * MouseSensitivity;
        }
    }
}
