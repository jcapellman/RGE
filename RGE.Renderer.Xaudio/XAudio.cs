using RGE.Lib.Abstractions.Renderers;
using RGE.Lib.Objects.Config;

using Vortice.Multimedia;
using Vortice.XAudio2;

namespace RGE.Renderer.Xaudio
{
    public class XAudio : BaseSoundRenderer
    {
        public override string Name => "XAudio";

        private IXAudio2 _audio;
        private IXAudio2SourceVoice _voice;

        public override bool Init(Configuration config)
        {
            _audio = XAudio2.XAudio2Create(ProcessorSpecifier.DefaultProcessor);

            using var masterVoice = _audio.CreateMasteringVoice();

            WaveFormatExtensible format = new(config.snd_khz, config.snd_bits, config.snd_channels);

            _voice = _audio.CreateSourceVoice(format, false);

            return true;
        }

        public override void Shutdown()
        {
            _voice.Dispose();
            _audio.Dispose();
        }

        public override void PlaySound(Stream audioStream, bool onLoop = false)
        {
            SoundStream soundStream = new(audioStream);

            using AudioBuffer effectBuffer = new(soundStream.ToDataStream());

            _voice.SubmitSourceBuffer(effectBuffer, null);
            _voice.Start(0);
        }
    }
}