using OpenTK.Windowing.Desktop;

namespace Lw5
{
    public static class Program
    {
        static NativeWindowSettings _cfg = new()
        {
            Size = new(1280, 720),
            Title = "Lw5"
        };

        public static void Main()
        {
            using (Game g = new Game(_cfg))
            {
                g.Run();
            }
        }
    }
}