using RGE.Lib.Abstractions.Base;
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

        private static string BuildPath(string fileName)
        {
            return Path.Combine(AppContext.BaseDirectory, fileName);
        }

        private bool LoadGraphicsRenderer()
        {
            var graphicsRenderers = GraphicsRendererManager.LoadRenderers(AppContext.BaseDirectory);

            if (graphicsRenderers.Count == 0)
            {
                return false;
            }

            var gfxRenderer = graphicsRenderers.FirstOrDefault(a => a.Name == Config.vid_ref);

            if (gfxRenderer is not null)
            {
                graphicsRenderer = gfxRenderer;

                return true;
            }

            graphicsRenderer = graphicsRenderers.First();

            return true;
        }

        public async Task<bool> InitializeAsync()
        {
            Config = await ConfigManager.LoadConfigAsync(BuildPath(EngineConstants.FILENAME_CONFIG));

            var gfxInit = LoadGraphicsRenderer();

            if (!gfxInit)
            {
                return false;
            }

            graphicsRenderer.Init(Config);

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