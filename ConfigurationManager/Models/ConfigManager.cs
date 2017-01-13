using ConfigurationManager.Interfaces;
using Microsoft.Extensions.Configuration;

namespace ConfigurationManager.Models
{
    public class ConfigManager:IConfigManager
    {
        public ConfigurationRoot ReadConfiguration(string path)
        {
            var map = new ExeConfigurationFileMap {ExeConfigFilename = path};

            return ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
        }

        public void SaveConfig(ConfigurationRoot configuration)
        {
            configuration.Save(ConfigurationSaveMode.Minimal);
        }

        public void ClearConnectionStrings(ConfigurationRoot configuration)
        {
            configuration.ConnectionStrings.ConnectionStrings.Clear();
        }
    }
}
