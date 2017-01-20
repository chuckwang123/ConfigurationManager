using Microsoft.Extensions.Configuration;

namespace ConfigurationManager.Interfaces
{
    public interface IConfigManager
    {
        T ReadConfiguration<T>(string key) where T : new();
        void SaveConfig(ConfigurationRoot configuration);
        void ClearConnectionStrings(ConfigurationRoot configuration);
    }
}
