using RGE.Lib.Abstractions.Base;
using RGE.Lib.Enums;

namespace RGE.Lib.Objects.Config
{
    public class Configuration : BaseRGEObject
    {
        public override string Name => nameof(Configuration);

        public override ObjectTypes ObjectType => ObjectTypes.JsonObject;

        public string vid_ref { get; set; }

        public int vid_xres { get; set; }

        public int vid_yres { get; set; }

        public bool vid_fullscreen { get; set; }
    }
}