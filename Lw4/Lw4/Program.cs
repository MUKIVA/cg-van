using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.Common;
using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL;

namespace Lw4
{
    public static class Program
    {
        public const int MAJOR_VER = 4;
        public const int MINOR_VER = 6;
        public const int DEFAULT_WIDTH = 1280;
        public const int DEFAULT_HEIGHT = 720;

        public static NativeWindowSettings WindowCfg = new()
        {
            Profile = ContextProfile.Compatability,
            APIVersion = new Version(MAJOR_VER, MINOR_VER),
            Title = "Lw4",
            WindowState = WindowState.Normal,
            WindowBorder = WindowBorder.Resizable,
            Size = new Vector2i(DEFAULT_WIDTH, DEFAULT_HEIGHT)
        };

        static void Main()
        {
            Game game = new(WindowCfg);
            game.Run();
        }
    }
}