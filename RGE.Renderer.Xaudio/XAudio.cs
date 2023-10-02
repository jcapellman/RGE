using RGE.Lib.Abstractions.Renderers;
using RGE.Lib.Objects.Config;

namespace RGE.Renderer.Xaudio
{
    public class XAudio : BaseSoundRenderer
    {
        public override string Name => "XAudio";

        public override bool Init(Configuration config)
        {
            return true;
        }
    }
}