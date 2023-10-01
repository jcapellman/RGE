using RGE.Lib.Abstractions.Base;
using RGE.Lib.Objects.Config;

namespace RGE.Lib.Abstractions.Renderers.Base
{
    public abstract class BaseRenderer : BaseRGEObject
    {
        public abstract bool Init(Configuration config);
    }
}