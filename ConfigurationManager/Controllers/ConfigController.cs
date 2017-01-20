using System;
using System.Runtime.CompilerServices;
using ConfigurationManager.Interfaces;
using ConfigurationManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ConfigurationManager.Controllers
{
    [Route("api/[controller]")]
    public class ConfigController : Controller
    {
        private readonly IPLAuth iplAuth;
        
        public ConfigController(IOptions<IPLAuth> appSettings) : this(new ConnectorManagementFactory())
        {
            iplAuth = appSettings.Value;
        }

        public ConfigController(IFactory factory)
        {
            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }
        }

        [HttpGet]
        public WebConfigData GetWebConfigData()
        {
            //get the IPLNextgen Web.config path
            var configPath = 

            //Get the file Content0
            var configFile = configHelper.ReadWebConfig(configPath);

            //Parse it
            return configHelper.ParseConfiguration(configFile);

        }


        // POST: api/Config
        [HttpGet]
        public void PostWebConfigData(WebConfigData data)
        {
            var appSettingConfigPath = m_config.GetAppSettingOrThrowException("IPLNGAppSettingsSource");
            var connectionStringConfigPath = m_config.GetAppSettingOrThrowException("IPLNGConnectionStringsSource");
            configHelper.PutIPLAuth(appSettingConfigPath, data.IPLAuth);
            configHelper.PutConnectionString(connectionStringConfigPath, data.ConnectionStrings);
        }
        
    }
}
