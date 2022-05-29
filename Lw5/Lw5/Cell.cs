using OpenTK.Mathematics;


namespace Lw5
{
    public class Cell
    {
        private LitCube _leftWall;
        private LitCube _bottomWall;
        private bool _leftIsEnable = true;
        private bool _bottomIsEnable = true;

        public Vector2i Index { get; set; } = Vector2i.Zero;

        public Cell(Light light, Texture ambient, Texture specular, Texture normal)
        {
            _leftWall = new(light, ambient, specular, normal);

            _leftWall.Transform.Scale = new(0.1f, 2, 1);
            _leftWall.Transform.Position = new(-0.5f, 1, 0);

            _bottomWall = new(light, ambient, specular, normal);

            _bottomWall.Transform.Scale = new(1f, 2, 0.1f);
            _bottomWall.Transform.Position = new(0, 1, 0.5f);
            CollisionManager.SubObject(_leftWall);
            CollisionManager.SubObject(_bottomWall);
        }

        public void SetPos(float x, float y)
        {
            _leftWall.Transform.Position = new(-0.5f + x, 1, y);
            _bottomWall.Transform.Position = new(x, 1, 0.5f + y);
        }

        public void EnableBottom(bool isEnable)
        {
            _bottomIsEnable = isEnable;
            _bottomWall.CollisionEnable = isEnable;
        }

        public void EnableLeft(bool isEnable)
        {
            _leftIsEnable = isEnable;
            _leftWall.CollisionEnable = isEnable;
        }

        public void Draw(Camera camera)
        {
            if (_leftIsEnable)
                _leftWall.Draw(camera);
            if (_bottomIsEnable)
                _bottomWall.Draw(camera);
        }
    }
}
