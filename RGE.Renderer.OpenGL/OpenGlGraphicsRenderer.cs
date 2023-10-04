using RGE.Lib.Abstractions.Renderers;
using RGE.Lib.Objects.Config;

namespace RGE.Renderer.OpenGL
{
    public class OpenGlGraphicsRenderer : BaseGraphicsRenderer
    {
        public override string Name => "OpenGL";

        public override bool Init(Configuration config)
        {
            using var game = new OGLGame(config);

            game.Run();

            return true;
        }

        public override void Shutdown()
        {
            throw new NotImplementedException();
        }
    }
}