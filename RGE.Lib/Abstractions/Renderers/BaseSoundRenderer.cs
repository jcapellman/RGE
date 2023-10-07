using RGE.Lib.Abstractions.Renderers.Base;
using RGE.Lib.Enums;

namespace RGE.Lib.Abstractions.Renderers
{
    public abstract class BaseSoundRenderer : BaseRenderer
    {
        public override ObjectTypes ObjectType => ObjectTypes.SoundRenderer;

        public abstract Guid PlaySound(Stream audioStream,  bool onLoop = false);

        public abstract void StopSound(Guid soundGuid);
    }
}