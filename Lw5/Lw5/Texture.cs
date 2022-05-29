using OpenTK.Graphics.OpenGL4;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.PixelFormats;

namespace Lw5
{
    public class Texture
    {
        public int Handle { get; private set; } = 0;
        public int Height { get; private set; } = 0;
        public int Width { get; private set; } = 0;

        public TextureUnit TexBlock { get; set; } = TextureUnit.Texture0;
        public Texture(string path, bool invert = false)
        {
            Handle = GL.GenTexture();

            Use();

            Image<Rgba32> image = Image.Load<Rgba32>(path);
            image.Mutate(x => x.Flip(FlipMode.Vertical));
            if (invert)
                image.Mutate(x => x.Invert());

            Height = image.Height;
            Width = image.Width;

            var pixels = new List<byte>(4 * Width * Height);

            for (int y = 0; y < image.Height; y++)
                for (int x = 0; x < image.Width; x++)
                {
                    pixels.Add(image[x, y].R);
                    pixels.Add(image[x, y].G);
                    pixels.Add(image[x, y].B);
                    pixels.Add(image[x, y].A);
                }

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba,
                Width, Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, pixels.ToArray());
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

            GL.BindTexture(TextureTarget.Texture2D, 0);

        }

        public void Use()
        {
            GL.ActiveTexture(TexBlock);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (float)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (float)TextureWrapMode.Repeat);
            GL.BindTexture(TextureTarget.Texture2D, Handle);
        }
    }
}
