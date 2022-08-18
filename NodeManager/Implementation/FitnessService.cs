using FogEnvironment.Domain.Enum;
using FogEnvironment.Domain.Model;
using FogEnvironment.Domain.Model.TaskModels;
using FogEnvironment.NodeManager.Abstraction;
using FogEnvironment.NodeManager.BaseServices;

namespace FogEnvironment.NodeManager.Implementation
{
    public class FitnessService : IFitnessService
    {
        private List<UserTask> _userTasks;
        private List<BaseNode> _baseNodes;

        public FitnessService()
        {
            _userTasks = new List<UserTask>();
            _baseNodes = new List<BaseNode>();

        }

        public (List<UserTask>, List<BaseNode>) CreateUserTaskList(List<BaseNode> baseNodes, List<UserTaskRequest> userTaskRequest)
        {
            _userTasks = GenerateUserTasks(userTaskRequest);
            _baseNodes = baseNodes;

            var nodesOrderByCapacity = _baseNodes
                .OrderByDescending(q => q.StorageCapacity)
                .ThenBy(q => q.NodeType);

            foreach (var node in nodesOrderByCapacity)
                if (node.NodeType != NodeType.Cloud && node.IsAvaliable && node.AssignedTasks.IsAnyTaskAssigned())
                    AssigneFunctionsToNodeByFitnessFunction(node, _userTasks);
                else AssigneFunctionsToNodeDirectly(node, _userTasks);

            return (_userTasks,_baseNodes);
        }

        public List<UserTask> AssigneFunctionsToNodeByFitnessFunction(BaseNode node, List<UserTask> userTasks)
        {
            userTasks = userTasks.Where(q => q.IsTaskAssignedToNode is false && q.IsNodeAssigend()).ToList();

            var costOfRequestsByThisNode = CalculateCostOfTasksByNode(userTasks, node);
            var selectedTaskForThisNode = UtilitieFunctions.KnapSackResolver(node.StorageCapacity, userTasks.Select(q => (int)q.TaskType).ToArray(), costOfRequestsByThisNode.Select(q => q.TaskCast).ToArray());


            foreach (var selectedNodeIndex in selectedTaskForThisNode.NominatedRows)
            {
                userTasks.ElementAt(selectedNodeIndex).IsTaskAssignedToNode = true;
                userTasks.ElementAt(selectedNodeIndex).AssignedNode = node;
                userTasks.ElementAt(selectedNodeIndex).State = TaskState.Assigned;
                node.AssignedTasks.Add(userTasks.ElementAt(selectedNodeIndex));
            }

            node.IsAvaliable = false;
            return userTasks;
        }

        public List<UserTask> AssigneFunctionsToNodeDirectly(BaseNode node, List<UserTask> userTasks)
        {
            userTasks = userTasks.Where(q => q.IsTaskAssignedToNode is false && q.IsNodeAssigend()).ToList();

            foreach (var userTask in userTasks)
            {
                userTask.IsTaskAssignedToNode = true;
                userTask.AssignedNode = node;
                userTask.State = TaskState.Assigned;
                node.AssignedTasks.Add(userTask);
            }

            node.IsAvaliable = false;
            return userTasks;
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
