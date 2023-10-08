using RGE.Lib.Abstractions.Renderers;
using RGE.Lib.Objects.Config;

namespace RGE.Renderer.BasicSnd
{
    public class BasicSndRenderer : BaseSoundRenderer
    {
        public override string Name => "Basic Sound";

        public override bool Init(Configuration config)
        {
            return true;
        }

        public override void Shutdown()
        {
            throw new NotImplementedException();
        }

        public override Guid PlaySound(Stream audioStream, bool onLoop = false)
        {
            return Guid.Empty;
        }

        public override void StopSound(Guid soundGuid)
        {
            throw new NotImplementedException();
        }
    }
}