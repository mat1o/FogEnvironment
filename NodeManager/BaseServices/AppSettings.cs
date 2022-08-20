using FogEnvironment.Domain.Enum;
using FogEnvironment.Domain.Model;
using FogEnvironment.Domain.Model.AppSettingModels;
using FogEnvironment.NodeManager.Abstraction;
using Microsoft.Extensions.Configuration;

namespace FogEnvironment.NodeManager.BaseServices
{
    public class AppSettings : IAppSettings
    {
        public FogEnvironmentConfigurationModel FogEnvironmentModel { get; private set; } = new FogEnvironmentConfigurationModel();

        public TasksVolume TasksVolume { get; private set; } = new TasksVolume();

        public AppSettings()
        {
            var builder = new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("appsettings.json", optional: false);

            IConfiguration config = builder.Build();

            FogEnvironmentModel = config.GetSection("FogEnvironment").Get<FogEnvironmentConfigurationModel>();
            TasksVolume = config.GetSection("TasksVolume").Get<TasksVolume>();
            IAppSettings.SientificNotationPower = config.GetSection("SientificNotationPower").Get<double>();
        }
    }
}
