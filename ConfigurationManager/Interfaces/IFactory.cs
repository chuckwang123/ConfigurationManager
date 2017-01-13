using Microsoft.Extensions.Configuration;

namespace ConfigurationManager.Interfaces
{
    public interface IFactory
    {
        IConfiguration Config { get; }
        IConfigManager ConfigManager { get; }
        IApplicationPhysicalPathProvider ApplicationPhysicalPathProvider { get; }
        IIPLValidator IPLValidator { get; }
    }
}
