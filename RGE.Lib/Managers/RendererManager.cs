using RGE.Lib.Abstractions.Renderers.Base;
using RGE.Lib.Managers.Base;

namespace RGE.Lib.Managers
{
    public class RendererManager : BaseManager
    {
        public static List<T> LoadRenderers<T>(string basePath) where T : BaseRenderer => LoadFromDisk<T>(basePath);
    }
}