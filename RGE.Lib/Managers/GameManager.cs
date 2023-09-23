using RGE.Lib.Abstractions;
using RGE.Lib.Managers.Base;

namespace RGE.Lib.Managers
{
    public class GameManager : BaseManager
    {
        public static List<BaseGame> LoadGames(string basePath) => LoadFromDisk<BaseGame>(basePath);
    }
}