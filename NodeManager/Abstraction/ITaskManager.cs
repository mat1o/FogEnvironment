using FogEnvironment.Domain.Model;
using FogEnvironment.Domain.Model.TaskModels;

namespace FogEnvironment.NodeManager.Abstraction
{
    public interface ITaskManager
    {
        List<BaseNode> OffloadFunctionsToNodes(List<BaseNode> baseNodes);
        (List<BaseNode>, List<UserTask>) ExecutUserTasks(List<BaseNode> baseNodes, List<UserTask> userTasks);
    }
}
