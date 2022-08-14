using FogEnvironment.Domain.Model;
using FogEnvironment.Domain.Model.TaskModels;

namespace FogEnvironment.NodeManager.Abstraction
{
    public interface IFitnessService
    {
        void AssignTasksToNodes(List<BaseNode> baseNodes, UserTaskRequest userTaskRequest);
        List<UserTask> FunctionsAssignedToNode(BaseNode node,UserTaskRequest userTaskRequest);
    }
}
