using FogEnvironment.Domain.Model;
using FogEnvironment.Domain.Model.AppSettingModels;
using FogEnvironment.Domain.Model.TaskModels;

namespace FogEnvironment.NodeManager.Abstraction
{
    public interface IFitnessService
    {
        (List<UserTask>, List<BaseNode>) CreateUserTaskList(List<BaseNode> baseNodes,List<UserTaskRequest> userTaskRequest);
        List<UserTask> AssigneFunctionsToNodeByFitnessFunction(BaseNode node, List<UserTask> userTaskRequest);
    }
}
