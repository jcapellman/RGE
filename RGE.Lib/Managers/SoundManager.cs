using RGE.Lib.Abstractions.Renderers;
using RGE.Lib.Managers.Base;
using RGE.Lib.Objects.Assets;

namespace RGE.Lib.Managers
{
    public class SoundManager : BaseManager
    {
        private Dictionary<string, Guid> _soundSources = new();

        private readonly BaseSoundRenderer _soundRenderer;

        public SoundManager(BaseSoundRenderer soundRenderer)
        {
            _soundRenderer = soundRenderer;
        }

        public void LoadSounds(IEnumerable<Sounds> sounds)
        {
            foreach (var sound in sounds)
            {
                LoadSound(sound);
            }
        }

        public void LoadSound(Sounds sound)
        {
            if (!File.Exists(sound.FileName))
            {
                // Log Error

                return;
            }

            var stream = File.OpenRead(sound.FileName);

            var guid = _soundRenderer.LoadSound(stream, sound.Flags);

            _soundSources.Add(sound.Name, guid);
        }

        public void PlaySound(string name)
        {
            _soundRenderer.PlaySound(_soundSources[name]);
        }

        public void UnloadSound(string name)
        {
            _soundRenderer.UnloadSound(_soundSources[name]);

            _soundSources.Remove(name);
        }
    }
}