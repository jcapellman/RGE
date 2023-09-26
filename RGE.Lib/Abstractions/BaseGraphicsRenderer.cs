using RGE.Lib.Abstractions.Base;
using RGE.Lib.Enums;
using RGE.Lib.Objects.Config;

namespace RGE.Lib.Abstractions
{
    public abstract class BaseGraphicsRenderer : BaseRGEObject
    {
        public override ObjectTypes ObjectType => ObjectTypes.GraphicsRenderer;

        public abstract void Init(Configuration config);
    }
}