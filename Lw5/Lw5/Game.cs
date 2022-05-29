using OpenTK.Windowing.Desktop;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;


namespace Lw5
{
    public class Game : GameWindow
    {
        public const int mazeHeight = 15;
        public const int mazeWidth = 23;

        private Texture[] _diffuse = new Texture[6];
        private Texture[] _specular = new Texture[6];
        private Texture[] _normal = new Texture[6];

        private Random _rnd = new(DateTime.Now.Millisecond);
        private Player _player;
        

        private Cell[,] _cells = new Cell[mazeWidth + 1, mazeHeight + 1];

        private Ground _ground;
        private Ground _ground1;


        public Game(NativeWindowSettings cfg)
            : base(GameWindowSettings.Default, cfg)
        {
            float zOffset = mazeHeight / 2f - 0.5f;
            float xOffset = mazeWidth / 2f - 0.5f;
            _player = new(
                -Vector3.UnitX * (xOffset) +
                Vector3.UnitY +
                Vector3.UnitZ * (zOffset), Size.X / (float)Size.Y);

            _diffuse[0] = new(Common.TexDir + @"\container2.png");
            _specular[0] = new(Common.TexDir + @"\container2_specular.png");
            _normal[0] = new(Common.TexDir + @"\container2_normal.png");
            _diffuse[1] = new(Common.TexDir + @"\brick-1.png");
            _specular[1] = new(Common.TexDir + @"\brick-1_specular.png");
            _normal[1] = new(Common.TexDir + @"\brick-1_normal.png");
            _diffuse[2] = new(Common.TexDir + @"\brick-2.png");
            _specular[2] = new(Common.TexDir + @"\brick-2_specular.png");
            _normal[2] = new(Common.TexDir + @"\brick-2_normal.png");
            _diffuse[3] = new(Common.TexDir + @"\brick-3.jpg");
            _specular[3] = new(Common.TexDir + @"\brick-3_specular.png");
            _normal[3] = new(Common.TexDir + @"\brick-3_normal.png");
            _diffuse[4] = new(Common.TexDir + @"\bricks-4.png");
            _specular[4] = new(Common.TexDir + @"\bricks-4_specular.png");
            _normal[4] = new(Common.TexDir + @"\bricks-4_normal.png");
            _diffuse[5] = new(Common.TexDir + @"\patch-1.png");
            _specular[5] = new(Common.TexDir + @"\patch-1_specular.png");
            _normal[5] = new(Common.TexDir + @"\patch-1_normal.png");


            _ground = new(_player.light, _diffuse[0], _specular[0], mazeHeight, mazeWidth);
             
            _ground.Transform.Scale = new(mazeWidth, 0, mazeHeight);

            _ground1 = new(_player.light, _diffuse[0], _specular[0], mazeHeight, mazeWidth);

            _ground1.Transform.Scale = new(mazeWidth, 0, mazeHeight);
            _ground1.Transform.Position = Vector3.UnitY * 2f;



            for (int i = 0; i <= mazeWidth; i++)
            { 
                for (int j = 0; j <= mazeHeight; j++)
                {
                    var index = _rnd.Next(1, 6);
                    var cell = new Cell(_player.light, _diffuse[index], _specular[index], _normal[index]);
                    cell.Index = new(i, j);
                    cell.SetPos(i - xOffset, -j + zOffset);
                    _cells[i, j] = cell;

                    if (i == mazeWidth)
                        cell.EnableBottom(false);
                    if (j == mazeHeight)
                        cell.EnableLeft(false);
                }
            }

            RemoveWallsWithBacktracker();
        }

        private void RemoveWallsWithBacktracker()
        {
            Cell current = _cells[0, 0];
            HashSet<Cell> visitedCell = new();
            visitedCell.Add(current);

            Stack<Cell> way = new();
            way.Push(current);

            do
            {
                List<Cell> unvisitedCell = new(4);

                int x = current.Index.X;
                int y = current.Index.Y;

                if (x > 0 && !visitedCell.Contains(_cells[x - 1, y])) unvisitedCell.Add(_cells[x - 1, y]);
                if (y > 0 && !visitedCell.Contains(_cells[x, y - 1])) unvisitedCell.Add(_cells[x, y - 1]);
                if (x < mazeWidth - 1 && !visitedCell.Contains(_cells[x + 1, y])) unvisitedCell.Add(_cells[x + 1, y]);
                if (y < mazeHeight - 1 && !visitedCell.Contains(_cells[x, y + 1])) unvisitedCell.Add(_cells[x, y + 1]);

                if (unvisitedCell.Count > 0)
                {
                    Cell chosen = unvisitedCell[_rnd.Next(0, unvisitedCell.Count)];
                    RemoveWall(current, chosen);
                    visitedCell.Add(chosen);
                    current = chosen;
                    way.Push(chosen);
                }
                else
                {
                    current = way.Pop();
                }
            } while (way.Count > 0);
        }

        private void RemoveWall(Cell a, Cell b)
        {
            if (a.Index.X == b.Index.X)
            {
                if (a.Index.Y > b.Index.Y)
                    a.EnableBottom(false);
                else
                    b.EnableBottom(false);
            }
            else 
            {
                if (a.Index.X > b.Index.X)
                    a.EnableLeft(false);
                else
                    b.EnableLeft(false);
            }
        }

        protected override void OnLoad()
        {
            base.OnLoad();

            GL.Enable(EnableCap.DepthTest);
            GL.ClearColor(Color4.Indigo);

            CursorState = CursorState.Grabbed;
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);

            if (!IsFocused) return;

            if (KeyboardState.IsKeyDown(Keys.Escape))
                Close();


            _player.Collider.Draw(_player.fpsCamera);
            if (KeyboardState.IsKeyDown(Keys.W))
                _player.GoForward((float)args.Time);
            if (KeyboardState.IsKeyDown(Keys.S))
                _player.GoBack((float)args.Time);
            if (KeyboardState.IsKeyDown(Keys.A))
                _player.GoLeft((float)args.Time);
            if (KeyboardState.IsKeyDown(Keys.D))
                _player.GoRight((float)args.Time);

            _player.HandleMouse(MouseState);

        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            _ground.Draw(_player.fpsCamera);
            _ground1.Draw(_player.fpsCamera);
            foreach (var cell in _cells)
                cell.Draw(_player.fpsCamera);

            SwapBuffers();
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, e.Width, e.Height);
        }
    }
}
