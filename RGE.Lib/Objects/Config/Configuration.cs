using System.ComponentModel;
using System.Text.Json.Serialization;

using RGE.Lib.Abstractions.Base;
using RGE.Lib.Enums;

namespace RGE.Lib.Objects.Config
{
    public class Configuration : BaseRGEObject
    {
        [JsonIgnore]
        public override string Name => nameof(Configuration);

        [JsonIgnore]
        public override ObjectTypes ObjectType => ObjectTypes.JsonObject;

        [DefaultValue("OpenGL")]
        public string vid_ref { get; set; }

        [DefaultValue(800)]
        public int vid_xres { get; set; }

        [DefaultValue(600)]
        public int vid_yres { get; set; }

        [DefaultValue(false)]
        public bool vid_fullscreen { get; set; }
    }
}