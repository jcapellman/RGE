using System.Reflection;

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
                        continue;
                    }

                    if (Activator.CreateInstance(gameType) is BaseGame game)
                    {
                        games.Add(game);
                    }
                }
                catch (Exception) { }
            }

            return games;
        }
    }
}