using FogEnvironment.Domain.Model;
using FogEnvironment.Domain.Model.TaskModels;

namespace FogEnvironment.NodeManager.Abstraction
{
    public interface ITaskManager
    {
        List<BaseNode> OffloadFunctionsToNodes(List<BaseNode> baseNodes);
        Task<(List<BaseNode>, List<UserTask>)> ExecutUserTasks(List<BaseNode> baseNodes, List<UserTask> userTasks);
        Task<UserTask> ExecutFailedUserTask(UserTask userTask);
    }
}
