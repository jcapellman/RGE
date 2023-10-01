using RGE.Lib.Abstractions.Base;
using RGE.Lib.Abstractions.Renderers;
using RGE.Lib.Abstractions.Renderers.Base;
using RGE.Lib.Common;
using RGE.Lib.Enums;
using RGE.Lib.Managers;
using RGE.Lib.Objects.Config;

namespace RGE.Lib.Abstractions
{
    public abstract class BaseGame : BaseRGEObject
    {
        public override ObjectTypes ObjectType => ObjectTypes.Game;

        public abstract string GameVersionStr { get; }

        public string TitleBarStr => $"{Name} (Version {GameVersionStr})";

        protected Configuration Config;

        protected BaseGraphicsRenderer graphicsRenderer;

        protected BaseSoundRenderer soundRenderer;

        private static string BuildPath(string fileName)
        {
            return Path.Combine(AppContext.BaseDirectory, fileName);
        }

        private T? LoadRenderer<T>(string configOption) where T: BaseRenderer
        {
            var renderers = RendererManager.LoadRenderers<T>(AppContext.BaseDirectory);

            if (renderers.Count == 0)
            {
                return null;
            }

            var renderer = renderers.FirstOrDefault(a => a.Name == configOption);

            return renderer ?? renderers.First();
        }

        private bool InitGraphicsRenderer()
        {
            var gfxRenderer = LoadRenderer<BaseGraphicsRenderer>(Config.vid_ref);

            if (gfxRenderer is null)
            {
                return false;
            }

            graphicsRenderer = gfxRenderer;

            return graphicsRenderer.Init(Config);
        }

        private bool InitSoundRenderer()
        {
            var sndRenderer = LoadRenderer<BaseSoundRenderer>(Config.snd_ref);

            if (sndRenderer is null)
            {
                return false;
            }

            soundRenderer = sndRenderer;

            return soundRenderer.Init(Config);
        }

        public async Task<bool> InitializeAsync()
        {
            Config = await ConfigManager.LoadConfigAsync(BuildPath(EngineConstants.FILENAME_CONFIG));

            if (!InitGraphicsRenderer())
            {
                // TODO: LOG

                return false;
            }

            if (!InitSoundRenderer())
            {
                // TODO: LOG

                return false;
            }

            return true;
        }

        public void Run()
        {

        }

        public void Shutdown()
        {

        }
    }
}