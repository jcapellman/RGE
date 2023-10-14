using RGE.Lib.Abstractions.Renderers;
using RGE.Lib.Enums;
using RGE.Lib.Managers.Base;

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

        public void LoadSound(string name, string filePath, SoundFlags flags = SoundFlags.None)
        {
            if (!File.Exists(filePath))
            {
                // Log Error

                return;
            }

            var stream = File.OpenRead(filePath);

            var guid = _soundRenderer.LoadSound(stream, flags);

            _soundSources.Add(name, guid);
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