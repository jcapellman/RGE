using System.Text.Json;

using NLog;

using RGE.Lib.Managers.Base;
using RGE.Lib.Objects.Config;

namespace RGE.Lib.Managers
{
    public class ConfigManager : BaseManager
    {
        private static Configuration CreateDefaultConfig(string configPath)
        {
            var config = new Configuration();

            SaveConfigAsync(configPath, config);

            return config;
        }

        public static async Task<Configuration> LoadConfigAsync(string configPath)
        {
            if (!File.Exists(configPath))
            {
                LogManager.GetCurrentClassLogger().Warn($"{configPath} does not exist, creating with defaults");

                return CreateDefaultConfig(configPath);
            }

            var configText = await File.ReadAllTextAsync(configPath);

            try
            {
                var config = JsonSerializer.Deserialize<Configuration>(configText);

                return config ?? CreateDefaultConfig(configPath);
            }
            catch (JsonException jex)
            {
                LogManager.GetCurrentClassLogger().Error($"{configPath} threw the following Json exception when attempting to load (using the default values instead): {jex}");

                return CreateDefaultConfig(configPath);
            }
        }

        public static async void SaveConfigAsync(string configPath, Configuration config)
        {
            await File.WriteAllTextAsync(configPath, System.Text.Json.JsonSerializer.Serialize(config));
        }
    }
}
