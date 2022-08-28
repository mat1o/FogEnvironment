using FogEnvironment.Domain.Model.AppSettingModels;
using FogEnvironment.Domain.Model.TaskModels;

namespace FogEnvironment.NodeManager.Abstraction
{
    public interface INodeDecorator
    {
        void CreateAndSeedNodes();
        Task<ExecutionStatistics> ManageAndExecuteTasksAsync(List<UserTaskRequest> userTaskRequests);
    }
}
