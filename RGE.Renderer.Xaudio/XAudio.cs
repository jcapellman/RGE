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
        private IXAudio2MasteringVoice _masteringVoice;

        private WaveFormatExtensible _soundFormat;

        private readonly Dictionary<Guid, IXAudio2SourceVoice> _voices = new();

        public override bool Init(Configuration config)
        {
            _audio = XAudio2.XAudio2Create(ProcessorSpecifier.DefaultProcessor);

            _masteringVoice = _audio.CreateMasteringVoice();

            _soundFormat = new WaveFormatExtensible(config.snd_khz, config.snd_bits, config.snd_channels);

            return true;
        }

        public override void Shutdown()
        {
            foreach (var voice in _voices.Values)
            {
                voice.Stop();

                voice.Dispose(); 
            }

            _masteringVoice.Dispose();
            _audio.Dispose();
        }

        public override Guid PlaySound(Stream audioStream, bool onLoop = false)
        {
            var guid = Guid.NewGuid();

            SoundStream soundStream = new(audioStream);

            using AudioBuffer effectBuffer = new(soundStream.ToDataStream());

            var voice = _audio.CreateSourceVoice(_soundFormat, false);

            voice.SubmitSourceBuffer(effectBuffer, null);
            voice.Start(0);
            
            _voices.Add(guid, voice);

            return guid;
        }

        public override void StopSound(Guid soundGuid)
        {
            if (!_voices.TryGetValue(soundGuid, out var value))
            {
                return;
            }

            value.Stop();
        }
    }
}