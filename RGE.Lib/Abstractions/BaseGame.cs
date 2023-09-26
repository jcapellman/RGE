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

        public Configuration Config;

        private static string BuildPath(string fileName)
        {
            return Path.Combine(AppContext.BaseDirectory, fileName);
        }

        public async Task<bool> InitializeAsync()
        {
            Config = await ConfigManager.LoadConfigAsync(BuildPath(EngineConstants.FILENAME_CONFIG));

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