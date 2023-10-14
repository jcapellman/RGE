using RGE.Lib.Abstractions.Renderers;
using RGE.Lib.Enums;
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

        public override void PlaySound(Guid soundGuid)
        {
        }

        public override void StopSound(Guid soundGuid)
        {
            throw new NotImplementedException();
        }

        public override void UnloadSound(Guid soundGuid)
        {
            throw new NotImplementedException();
        }

        public override Guid LoadSound(Stream audioStream, SoundFlags flags = SoundFlags.None)
        {
            return Guid.Empty;
        }
    }
}