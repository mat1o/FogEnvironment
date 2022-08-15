using FogEnvironment.Domain.Model;
using FogEnvironment.Domain.Model.AppSettingModels;
using FogEnvironment.Domain.Model.TaskModels;
using FogEnvironment.NodeManager.Abstraction;
using FogEnvironment.NodeManager.BaseServices;

namespace FogEnvironment.NodeManager.Implementation
{
    public class FitnessService : IFitnessService
    {
        private readonly List<BaseNode> _baseNodes = new List<BaseNode>();
        private List<UserTask> _userTasks = new List<UserTask>();

        public void ManageTasksAndNodes(List<BaseNode> baseNodes, List<UserTaskRequest> userTaskRequest, TasksVolume tasksVolume)
        {
            var nodesOrderByCapacity = baseNodes
                .OrderByDescending(q => q.StorageCapacity)
                .ThenBy(q => q.NodeType);

            _userTasks = GenerateUserTasks(userTaskRequest, tasksVolume);

            foreach (var node in nodesOrderByCapacity)
                FunctionsAssignedToNode(node, _userTasks);
        }

        public List<UserTask> FunctionsAssignedToNode(BaseNode node, List<UserTask> userTaskRequest)
        {
            var costOfRequestsByThisNode = userTaskRequest.CalculateCostOfTasksByNode(node);
            var selectedTaskForThisNode = UtilitieFunctions.KnapSackResolver(node.StorageCapacity, userTaskRequest.Select(q => q.TaskVolume).ToArray(), costOfRequestsByThisNode.Select(q => q.TaskCast).ToArray())


        }

        public List<UserTask> GenerateUserTasks(List<UserTaskRequest> userTaskRequest, TasksVolume tasksVolume)
        {
            var userTasks = new List<UserTask>();

            foreach (var userRequest in userTaskRequest)
                foreach (var userTask in userRequest.UserTask)
                    userTasks.Add(new UserTask
                    {
                        State = Domain.Enum.TaskState.AwaitForFreeNode,
                        TaskType = userTask,
                        UserRequestID = userRequest.Id,
                        IsTaskAssignedToNode = false,
                        TaskVolume = (int)userTask,
                        Image = userRequest.Image
                    });

            return userTasks;
        }
    }
}
