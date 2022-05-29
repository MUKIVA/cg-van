using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;

namespace Lw6
{

    public static class Program
    {

        public static NativeWindowSettings config = new NativeWindowSettings()
        {
            Title = "Lw6",
            Size = new Vector2i(1280, 720)

        };

        public static void Main()
        {
            using (Game g = new(config))
            {
                g.Run();
            }
        }
    }
}