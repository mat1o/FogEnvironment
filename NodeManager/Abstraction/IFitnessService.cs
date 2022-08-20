using FogEnvironment.Domain.Model;
using FogEnvironment.Domain.Model.TaskModels;

namespace FogEnvironment.NodeManager.Abstraction
{
    public interface IFitnessService
    {
        (List<UserTask>, List<BaseNode>) CreateUserTaskList(List<BaseNode> baseNodes,List<UserTaskRequest> userTaskRequest);
        List<UserTask> AssigneTasksToNodeByFitnessFunction(BaseNode node, List<UserTask> userTaskRequest);
        (List<BaseNode>, UserTask) ReassignsFailedUserTaskToAvailableNode(List<BaseNode> baseNodes, UserTask userTask);
        (List<UserTask>, BaseNode) FailedNodeRemainedTasksReassign(List<BaseNode> baseNodes,BaseNode failedNode);
    }
}
