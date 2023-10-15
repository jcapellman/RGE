using RGE.Lib.Abstractions.Base;
using RGE.Lib.Enums;

namespace RGE.Lib.Objects.Assets
{
    public class Sounds : BaseRGEObject
    {
        public override string Name => "Sound";

        public override ObjectTypes ObjectType => ObjectTypes.Sound;

        public SoundFlags Flags { get; set; }

        public required string ActionName { get; set; }

        public required string FileName { get; set; }
    }
}