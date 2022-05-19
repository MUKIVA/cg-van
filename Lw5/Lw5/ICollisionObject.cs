using OpenTK.Mathematics;

namespace Lw5
{
    public interface ICollisionObject
    {
        public CollisionAction EnumeratePoints(Func<Vector3, Vector3, Vector3> call);
        public Vector3 Intersect(Vector3 bottomLeft, Vector3 topRight);
        public bool CollisionEnable { get; set; }   
    }
}
