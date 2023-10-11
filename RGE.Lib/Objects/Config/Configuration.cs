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

        #region Sound Options
        public string snd_ref { get; set; } = "XAudio";

        public int snd_khz { get; set; } = 44;

        public int snd_bits { get; set; } = 16;

        public int snd_channels { get; set; } = 2;
        #endregion

        #region Graphics Options
        public string vid_ref { get; set; } = "OpenGL";

        public int vid_xres { get; set; } = 800;

        public int vid_yres { get; set; } = 600;

        public bool vid_fullscreen { get; set; } = false;
        #endregion
    }
}