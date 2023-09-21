using NLog;

using System.Reflection;

namespace RGE.Lib.Managers.Base
{
    public class BaseManager
    {
        protected static List<T> LoadFromDisk<T>(string basePath, string extension = "dll")
        {
            var loadedObjects = new List<T>();

            var files = Directory.GetFiles(basePath, $"*.{extension}");

            foreach (var file in files)
            {
                try
                {
                    var assembly = Assembly.LoadFrom(file);

                    var assumedTypes = assembly.GetTypes().Where(a => a.BaseType == typeof(T));

                    foreach (var assumedType in assumedTypes)
                    {
                        if (Activator.CreateInstance(assumedType) is not T aType)
                        {
                            continue;
                        }

                        LogManager.GetCurrentClassLogger()
                            .Debug($"{file} was loaded and included it");

                        loadedObjects.Add(aType);
                    }
                }
                catch (Exception ex)
                {
                    LogManager.GetCurrentClassLogger().Warn($"{file} threw the following exception when attempting to load: {ex}");
                }
            }

            return loadedObjects;
        }
    }
}