using RGE.Lib.Enums;

namespace RGE.Lib.Abstractions.Base
{
    public abstract class BaseRGEObject
    {
        public abstract string Name { get; }

        public abstract ObjectTypes ObjectType { get; }
    }
}