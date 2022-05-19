using OpenTK.Mathematics;

namespace Lw5
{
    public struct CollisionAction
    {
        public bool Result { get; set; } = false;
        public Vector3 Normal { get; set; } = Vector3.Zero;

        public CollisionAction()
        { 
        }

    }

    public static class CollisionManager
    {
        private static List<ICollisionObject> collisionObjects = new();

        public static void SubObject(ICollisionObject obj)
        {
            collisionObjects.Add(obj);
        }

        public static void UnsubObject(ICollisionObject obj)
        {
            collisionObjects.Remove(obj);
        }

        public static CollisionAction OnCollision(ICollisionObject obj)
        {
            CollisionAction result = new();
            foreach (var collider in collisionObjects)
            {
                if (collider == obj) continue;
                var collision = IsCollision(collider, obj);
                if (collision.Result)
                    result.Normal += collision.Normal;
            }
            //result.Normal.Normalize();
            return result;
        }

        public static CollisionAction IsCollision(ICollisionObject a, ICollisionObject b)
        {
            return b.EnumeratePoints(a.Intersect);
        }
        
    }
}
