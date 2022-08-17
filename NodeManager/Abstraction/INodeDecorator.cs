using FogEnvironment.Domain.Model.TaskModels;

namespace FogEnvironment.NodeManager.Abstraction
{
    public interface INodeDecorator
    {
        void CreateAndSeedNodes();
        Task ManageAndExecuteTasksAsync(List<UserTaskRequest> userTaskRequests);
    }
}
