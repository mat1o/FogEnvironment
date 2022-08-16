using FogEnvironment.Domain.Model;
using FogEnvironment.Domain.Model.AppSettingModels;
using FogEnvironment.Domain.Model.TaskModels;

namespace FogEnvironment.NodeManager.Abstraction
{
    public interface IFitnessService
    {
        void CreateUserTaskList(List<BaseNode> baseNodes,List<UserTaskRequest> userTaskRequest);
        List<UserTask> AssigneFunctionsToNode(BaseNode node, List<UserTask> userTaskRequest);
    }
}
