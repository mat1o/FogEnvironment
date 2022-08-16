using FogEnvironment.Domain.Enum;
using FogEnvironment.Domain.Model;
using FogEnvironment.Domain.Model.TaskModels;
using FogEnvironment.NodeManager.Abstraction;

namespace FogEnvironment.NodeManager.Implementation
{
    public class FitnessService : IFitnessService
    {
        public void CreateUserTaskList(List<BaseNode> baseNodes, List<UserTaskRequest> userTaskRequest)
        {
            var nodesOrderByCapacity = baseNodes
                .OrderByDescending(q => q.StorageCapacity)
                .ThenBy(q => q.NodeType);

            List<UserTask> _userTasks = new List<UserTask>();

            _userTasks = GenerateUserTasks(userTaskRequest);

            foreach (var node in nodesOrderByCapacity)
                AssigneFunctionsToNode(node, _userTasks);
        }

        public List<UserTask> AssigneFunctionsToNode(BaseNode node, List<UserTask> userTaskRequest)
        {
            var costOfRequestsByThisNode = CalculateCostOfTasksByNode(userTaskRequest, node);
            var selectedTaskForThisNode = UtilitieFunctions.KnapSackResolver(node.StorageCapacity, userTaskRequest.Select(q => (int)q.TaskType).ToArray(), costOfRequestsByThisNode.Select(q => q.TaskCast).ToArray());

            foreach (var selectedNodeIndex in selectedTaskForThisNode.NominatedRows)
            {
                userTaskRequest.ElementAt(selectedNodeIndex).IsTaskAssignedToNode = true;
                userTaskRequest.ElementAt(selectedNodeIndex).AssignedNode = node;
                userTaskRequest.ElementAt(selectedNodeIndex).State = TaskState.Assigned;
            }

            return userTaskRequest;
        }

        public List<UserTask> GenerateUserTasks(List<UserTaskRequest> userTaskRequest)
        {
            var userTasks = new List<UserTask>();

            foreach (var userRequest in userTaskRequest)
                foreach (var userTask in userRequest.UserTask)
                    userTasks.Add(new UserTask
                    {
                        State = TaskState.AwaitForFreeNode,
                        TaskType = userTask,
                        UserRequestID = userRequest.Id,
                        IsTaskAssignedToNode = false,
                        Image = userRequest.Image
                    });

            return userTasks;
        }

        public List<UserTask> CalculateCostOfTasksByNode(List<UserTask> userTasks, BaseNode node)
        {
            foreach (var userTask in userTasks)
                userTask.TaskCast = ((int)userTask.TaskType / 1024 * (int)(node.CastPerGb * Math.Pow(10, 5))) + (int)(node.CastOfExecution * Math.Pow(10, 5));

            return userTasks;
        }
    }
}
