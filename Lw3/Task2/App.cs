using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.Common;
using OpenTK.Mathematics;

namespace Task2
{
    public class App
    {
        public const int MAJOR_VER = 4;
        public const int MINOR_VER = 6;
        public const int DEFAULT_WIDTH = 1280;
        public const int DEFAULT_HEIGHT = 1280;


        public static NativeWindowSettings WindowCfg = new()
        {
            Profile = ContextProfile.Compatability,
            APIVersion = new Version(MAJOR_VER, MINOR_VER),
            Title = "Lw3",
            WindowState = WindowState.Normal,
            WindowBorder = WindowBorder.Resizable,
            Size = new Vector2i(DEFAULT_WIDTH, DEFAULT_HEIGHT)
        };

        private Window _mainWindow;

        public App()
        {
            _mainWindow = new Window(WindowCfg);
            _mainWindow.Run();
        }
    }
}
