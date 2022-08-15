using FogEnvironment.Domain.Enum;
using FogEnvironment.Domain.Model;
using FogEnvironment.Domain.Model.AppSettingModels;
using Microsoft.Extensions.Configuration;

namespace FogEnvironment.NodeManager.BaseServices
{
    public class AppSettings
    {
        internal protected FogEnvironmentConfigurationModel FogEnvironmentModel { get; private set; }
        internal protected TasksVolume TasksVolume { get; private set; }

        public AppSettings()
        {
            var builder = new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("appsettings.json", optional: false);

            IConfiguration config = builder.Build();

            FogEnvironmentModel = config.GetSection("FogEnvironment").Get<FogEnvironmentConfigurationModel>();
            TasksVolume = config.GetSection("TasksVolume").Get<TasksVolume>();

        }

        public List<BaseNode> CreateAndSeedNodes()
        {
            var nodes = new List<BaseNode>();


            nodes.AddRange(FogEnvironmentModel.Edges);
            nodes.AddRange(FogEnvironmentModel.Clouds);

            foreach (var node in nodes)
            {
                node.TaskFailedEvent += Node_TaskFailedEvent;
                node.NodeFailedEvent += Node_NodeFailedEvent;
            }

            return nodes;
        }

        private void Node_NodeFailedEvent(Guid obj, NodeType nodeType)
        {
            throw new NotImplementedException();
        }

        private Task Node_TaskFailedEvent(Guid arg, NodeType nodeType)
        {
            throw new NotImplementedException();
        }
    }
}
