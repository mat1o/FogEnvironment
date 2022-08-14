using FogEnvironment.Domain.Model;
using FogEnvironment.Domain.Model.AppSettingModels;
using Microsoft.Extensions.Configuration;

namespace FogEnvironment.NodeManager.BaseServices
{
    public class AppSettings
    {
        internal protected FogEnvironmentConfigurationModel FogEnvironmentModel { get; private set; }

        public AppSettings()
        {
            var builder = new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("appsettings.json", optional: false);

            IConfiguration config = builder.Build();

            FogEnvironmentModel = config.GetSection("FogEnvironment").Get<FogEnvironmentConfigurationModel>();

        }

        public List<BaseNode> CreateAndSeedNodes() 
        {
            var nodes = new List<BaseNode>();

            nodes.AddRange(FogEnvironmentModel.Edges);
            nodes.AddRange(FogEnvironmentModel.Clouds);
            nodes.AddRange(FogEnvironmentModel.Intermediaries);

            foreach (var node in nodes)
            {
                node.TaskFailedEvent += Node_TaskFailedEvent;
                node.NodeFailedEvent += Node_NodeFailedEvent; 
            }
        }

        private void Node_NodeFailedEvent(Guid obj)
        {
            throw new NotImplementedException();
        }

        private Task Node_TaskFailedEvent(Guid arg)
        {
            throw new NotImplementedException();
        }
    }
}
