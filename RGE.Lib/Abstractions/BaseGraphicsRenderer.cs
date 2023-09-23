using RGE.Lib.Abstractions.Base;
using RGE.Lib.Enums;

namespace RGE.Lib.Abstractions
{
    public abstract class BaseGraphicsRenderer : BaseRGEObject
    {
        public override ObjectTypes ObjectType => ObjectTypes.GraphicsRenderer;
    }
}