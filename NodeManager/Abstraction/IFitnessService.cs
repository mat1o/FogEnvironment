using FogEnvironment.Domain.Model;
using FogEnvironment.Domain.Model.AppSettingModels;
using FogEnvironment.Domain.Model.TaskModels;

namespace FogEnvironment.NodeManager.Abstraction
{
    public interface IFitnessService
    {
        void ManageTasksAndNodes(List<BaseNode> baseNodes,List<UserTaskRequest> userTaskRequest, TasksVolume tasksVolume);
        List<UserTask> FunctionsAssignedToNode(BaseNode node, List<UserTask> userTaskRequest);
    }
}
