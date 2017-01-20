using ConfigurationManager.Interfaces;
using Microsoft.Extensions.Configuration;

namespace ConfigurationManager.Models
{
    public class ConfigManager:IConfigManager
    {
        private IConfigurationRoot configuration;

        public ConfigManager()
        {
            configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json.config", optional: true)
                .Build();
        }
        public T ReadConfiguration<T>(string key) where T : new()
        {
            var instance = new T();
            configuration.GetSection(key).Bind(instance);
            return instance;
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
