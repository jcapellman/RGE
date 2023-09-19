using System.Reflection;

using NLog;

using RGE.Lib.Abstractions;

namespace RGE.Lib.Managers
{
    public class GameManager
    {
        public static List<BaseGame> LoadGames(string basePath)
        {
            var games = new List<BaseGame>();

            var potentialGames = Directory.GetFiles(basePath, "*.dll");

            foreach (var file in potentialGames)
            {
                try
                {
                    var assembly = Assembly.LoadFile(file);

                    var gameType = assembly.GetTypes().FirstOrDefault(a => a.BaseType == typeof(BaseGame));

                    if (gameType is null)
                    {
                        LogManager.GetCurrentClassLogger()
                            .Debug($"{file} had no BaseGame implementations");

                        continue;
                    }

                    if (Activator.CreateInstance(gameType) is not BaseGame game)
                    {
                        continue;
                    }

                    LogManager.GetCurrentClassLogger()
                        .Debug($"{file} was loaded and included {game.GameHeaderStr}");

                    games.Add(game);
                }
                catch (Exception ex)
                {
                    LogManager.GetCurrentClassLogger().Warn($"{file} threw the following exception when attempting to load: {ex}");
                }
            }

            return games;
        }
    }
}