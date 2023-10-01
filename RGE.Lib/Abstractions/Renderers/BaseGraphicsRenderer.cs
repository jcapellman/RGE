using RGE.Lib.Abstractions.Base;
using RGE.Lib.Abstractions.Renderers.Base;
using RGE.Lib.Enums;

namespace RGE.Lib.Abstractions.Renderers
{
    public abstract class BaseGraphicsRenderer : BaseRenderer
    {
        public override ObjectTypes ObjectType => ObjectTypes.GraphicsRenderer;
    }
}