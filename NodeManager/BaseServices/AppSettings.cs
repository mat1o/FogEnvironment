using FogEnvironment.Domain.Model.AppSettingModels;
using Microsoft.Extensions.Configuration;

namespace FogEnvironment.NodeManager.BaseServices
{
    public class AppSettings
    {
        internal protected static FogEnvironmentConfigurationModel FogEnvironmentModel { get; private set; }

        public AppSettings()
        {
            var builder = new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("appsettings.json", optional: false);

            IConfiguration config = builder.Build();

            FogEnvironmentModel = config.GetSection("FogEnvironment").Get<FogEnvironmentConfigurationModel>();

        }
    }
}
