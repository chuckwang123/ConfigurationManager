using Microsoft.Extensions.Configuration;

namespace ConfigurationManager.Interfaces
{
    public interface IConfigManager
    {
        ConfigurationRoot ReadConfiguration(string path);
        void SaveConfig(ConfigurationRoot configuration);
        void ClearConnectionStrings(ConfigurationRoot configuration);
    }
}
