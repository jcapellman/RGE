using RGE.Lib.Abstractions.Renderers;
using RGE.Lib.Enums;
using RGE.Lib.Objects.Config;

using Vortice.Multimedia;
using Vortice.XAudio2;

namespace RGE.Renderer.Xaudio
{
    public class XAudio : BaseSoundRenderer
    {
        public struct AudioContainer
        {
            public IXAudio2SourceVoice Voice { get; set; }

            public SoundFlags Flags { get; set; }
        }

        public override string Name => "XAudio";

        private IXAudio2 _audio;
        private IXAudio2MasteringVoice _masteringVoice;

        private WaveFormatExtensible _soundFormat;

        private readonly Dictionary<Guid, AudioContainer> _voices = new();

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
                voice.Voice.Stop();

                voice.Voice.Dispose(); 
            }

            _masteringVoice.Dispose();
            _audio.Dispose();
        }

        public override void PlaySound(Guid soundGuid)
        {
            if (!_voices.TryGetValue(soundGuid, out var value))
            {
                return;
            }

            value.Voice.Start();
        }

        public override void StopSound(Guid soundGuid)
        {
            if (!_voices.TryGetValue(soundGuid, out var value))
            {
                return;
            }

            value.Voice.Stop();

            if (value.Flags.HasFlag(SoundFlags.Reoccurring))
            {
                return;
            }

            _voices.Remove(soundGuid);
        }

        public override Guid LoadSound(Stream audioStream, SoundFlags flags = SoundFlags.None)
        {
            var guid = Guid.NewGuid();

            SoundStream soundStream = new(audioStream);

            using AudioBuffer effectBuffer = new(soundStream.ToDataStream());

            var voice = _audio.CreateSourceVoice(_soundFormat, true);

            voice.SubmitSourceBuffer(effectBuffer, null);
            voice.Start(0);

            _voices.Add(guid, new AudioContainer { Flags = flags, Voice = voice });

            return guid;
        }
    }
}