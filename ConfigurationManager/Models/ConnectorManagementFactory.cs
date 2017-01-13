using ConfigurationManager.Interfaces;
using Microsoft.Extensions.Configuration;

namespace ConfigurationManager.Models
{
    public class ConnectorManagementFactory:IFactory
    {
        private IConfiguration m_config;
        public IConfiguration Config => m_config ?? (m_config = new AppSet());
        public IConfigManager ConfigManager => new ConfigManager();
        public IApplicationPhysicalPathProvider ApplicationPhysicalPathProvider => new ApplicationPhysicalPathProvider();
        public IIPLValidator IPLValidator => new IPLValidator();
    }
}
