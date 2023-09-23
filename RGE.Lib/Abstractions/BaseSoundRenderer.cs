using RGE.Lib.Abstractions.Base;
using RGE.Lib.Enums;

namespace RGE.Lib.Abstractions
{
    public abstract class BaseSoundRenderer : BaseRGEObject
    {
        public override ObjectTypes ObjectType => ObjectTypes.SoundRenderer;
    }
}