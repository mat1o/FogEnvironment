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
                .OrderBy(q => q.StorageCapacity)
                .ThenBy(q => q.NodeType);

            foreach (var node in nodesOrderByCapacity)
                if (node.NodeType != NodeType.Cloud && node.IsAvaliable && !node.AssignedTasks.IsAnyTaskAssigned())
                    AssigneTasksToNodeByFitnessFunction(node, _userTasks);
                else AssigneTasksToNodeDirectly(node, _userTasks);

            return (_userTasks, _baseNodes);
        }

        public List<UserTask> AssigneTasksToNodeByFitnessFunction(BaseNode node, List<UserTask> userTasks)
        {
            Thread.Sleep(node.LatancyToUser);
            userTasks = userTasks.Where(q => q.IsTaskAssignedToNode is false && !q.IsNodeAssigend()).ToList();

            var costOfRequestsByThisNode = CalculateCostOfTasksByNode(userTasks, node);
            var selectedTaskForThisNode = UtilitieFunctions.KnapSackResolver(node.StorageCapacity, userTasks.Select(q => (int)q.TaskType).ToArray(), costOfRequestsByThisNode.Select(q => q.TaskCast).ToArray());


            foreach (var selectedNodeIndex in selectedTaskForThisNode?.NominatedRows)
            {
                userTasks.ElementAt(selectedNodeIndex).IsTaskAssignedToNode = true;
                userTasks.ElementAt(selectedNodeIndex).AssignedNode = node;
                userTasks.ElementAt(selectedNodeIndex).State = TaskState.Assigned;
                node.AssignedTasks.Add(userTasks.ElementAt(selectedNodeIndex));
            }

            node.StorageCapacity = node.StorageCapacity - selectedTaskForThisNode.MaxValue;
            node.IsAvaliable = false;

            return userTasks;
        }

        public List<UserTask> AssigneTasksToNodeDirectly(BaseNode node, List<UserTask> userTasks)
        {
            Thread.Sleep(node.LatancyToUser);
            userTasks = userTasks.Where(q => q.IsTaskAssignedToNode is false && q.IsNodeAssigend()).ToList();
            var taskCasts = 0;

            foreach (var userTask in userTasks)
            {
                userTask.IsTaskAssignedToNode = true;
                userTask.AssignedNode = node;
                userTask.State = TaskState.Assigned;
                node.AssignedTasks.Add(userTask);
                taskCasts += userTask.TaskCast;
            }

            node.StorageCapacity = node.StorageCapacity - taskCasts;
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
                userTask.TaskCast = (int)((((double)(int)userTask.TaskType) / (double)1024) * (int)(node.CastPerGb * Math.Pow(10, 5))) + (int)(node.CastOfExecution * Math.Pow(10, 7));

            return userTasks;
        }

        public (List<BaseNode>, UserTask) ReassignsFailedUserTaskToAvailableNode(List<BaseNode> baseNodes, UserTask userTask)
        {
            foreach (var node in baseNodes)
            {
                if (node.ExecutableFunctions.Select(q => q.TaskType).Contains(userTask.TaskType)
                    && node.IsAvaliable
                    && node.StorageCapacity > (int)userTask.TaskType
                    && node.Id != userTask.AssignedNode.Id)
                {
                    userTask.AssignedNode = node;
                    userTask.State = TaskState.AwaitForFreeNode;
                    userTask.TaskStates.Add(TaskState.AwaitForFreeNode);
                    Thread.Sleep(node.LatancyToOther);

                    break;
                }
            }

            return (baseNodes, userTask);
        }

        public (List<UserTask>, BaseNode) FailedNodeRemainedTasksReassign(List<BaseNode> baseNodes, BaseNode failedNode)
        {
            var remainedTasks = failedNode.AssignedTasks.Where(q => q.State == TaskState.Canceld).ToList();

            foreach (var remainedTask in remainedTasks)
            {
                foreach (var node in baseNodes)
                {
                    if (node.ExecutableFunctions.Select(q => q.TaskType).Contains(remainedTask.TaskType)
                        && node.IsAvaliable
                        && node.StorageCapacity > (int)remainedTask.TaskType
                        && node.Id != remainedTask.AssignedNode.Id)
                    {
                        remainedTask.AssignedNode = node;
                        remainedTask.State = TaskState.AwaitForFreeNode;
                        remainedTask.TaskStates.Add(TaskState.AwaitForFreeNode);
                        Thread.Sleep(node.LatancyToOther);

                        break;
                    }
                }
            }
            return (remainedTasks, failedNode);
        }
    }
}
