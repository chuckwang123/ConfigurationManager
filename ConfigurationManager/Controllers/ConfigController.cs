using System;
using ConfigurationManager.Interfaces;
using ConfigurationManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ConfigurationManager.Controllers
{
    [Route("api/[controller]")]
    public class ConfigController : Controller
    {
        private readonly IConfiguration m_config;
        private readonly ConfigHelper configHelper;

        public ConfigController() : this(new ConnectorManagementFactory()) { }

        public ConfigController(IFactory factory)
        {
            if (factory == null) { throw new ArgumentNullException(nameof(factory)); }

            m_config = factory.Config;
            configHelper = new ConfigHelper(factory);
        }

        [HttpGet]
        public WebConfigData GetWebConfigData()
        {
            //get the IPLNextgen Web.config path
            var configPath = m_config.GetAppSettingOrThrowException("IPLNGConfig");

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
