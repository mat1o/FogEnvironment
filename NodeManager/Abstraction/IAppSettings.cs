using FogEnvironment.Domain.Enum;
using FogEnvironment.Domain.Model;
using FogEnvironment.Domain.Model.AppSettingModels;

namespace FogEnvironment.NodeManager.Abstraction
{
    public interface IAppSettings
    {
        FogEnvironmentConfigurationModel FogEnvironmentModel { get; }
        TasksVolume TasksVolume { get; }
        static double SientificNotationPower { get; set; }

        List<BaseNode> CreateAndSeedNodes();

        Task Node_NodeFailedEvent(Guid obj, NodeType nodeType);
        Task Node_TaskFailedEvent(Guid arg, NodeType nodeType);
    }
}
