using System;
using OpenTK;
using System.Collections.Generic;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.Common;
using OpenTK.Mathematics;

namespace Lw3
{
    public class Programm
    {
        public const int MAJOR_VER = 4;
        public const int MINOR_VER = 6;
        public const int DEFAULT_WIDTH = 1280;
        public const int DEFAULT_HEIGHT = 720;

        public static NativeWindowSettings WindowCfg = new()
        {
            Profile = ContextProfile.Compatability,
            APIVersion = new Version(MAJOR_VER, MINOR_VER),
            Title = "Lw3",
            WindowState = WindowState.Normal,
            WindowBorder = WindowBorder.Resizable,
            Size = new Vector2i(DEFAULT_WIDTH, DEFAULT_HEIGHT)
        };

        static void Main()
        {
            Window window = new(WindowCfg);
            window.Run();
        }
    }
}

