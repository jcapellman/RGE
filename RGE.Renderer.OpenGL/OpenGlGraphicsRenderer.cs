using RGE.Lib.Abstractions.Renderers;
using RGE.Lib.Objects.Config;

namespace RGE.Renderer.OpenGL
{
    public class OpenGlGraphicsRenderer : BaseGraphicsRenderer
    {
        public override string Name => "OpenGL";

        public override void Init(Configuration config)
        {
            using var game = new OGLGame(config.vid_xres, config.vid_yres, "RGE");

            game.Run();
        }
    }
}