using RGE.Lib.Abstractions;
using RGE.Lib.Managers.Base;

namespace RGE.Lib.Managers
{
    public class GraphicsRendererManager : BaseManager
    {
        public static List<BaseGraphicsRenderer> LoadRenderers(string basePath) => LoadFromDisk<BaseGraphicsRenderer>(basePath).OrderBy(a => a.Name).ToList();
    }
}