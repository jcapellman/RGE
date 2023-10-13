using RGE.Lib.Abstractions.Renderers.Base;
using RGE.Lib.Enums;

namespace RGE.Lib.Abstractions.Renderers
{
    public abstract class BaseSoundRenderer : BaseRenderer
    {
        public override ObjectTypes ObjectType => ObjectTypes.SoundRenderer;

        public abstract void PlaySound(Guid soundGuid);

        public abstract void StopSound(Guid soundGuid);

        public abstract Guid LoadSound(Stream audioStream, SoundFlags flags = SoundFlags.None);
    }
}