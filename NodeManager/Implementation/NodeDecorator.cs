using FogEnvironment.Domain.Enum;
using FogEnvironment.Domain.Model;
using FogEnvironment.Domain.Model.TaskModels;
using FogEnvironment.NodeManager.Abstraction;
using FogEnvironment.NodeManager.BaseServices;

namespace FogEnvironment.NodeManager.Implementation
{
    public class NodeDecorator : INodeDecorator
    {
        private readonly AppSettings _appSettings;
        private readonly IFitnessService _fitnessService;
        private readonly ITaskManager _taskManager;
        private List<BaseNode> _nodes;
        private List<UserTask> _userTasks;
        private List<UserTaskRequest> _taskRequests;

        public NodeDecorator(IFitnessService fitnessService, ITaskManager taskManager)
        {
            _fitnessService = fitnessService;
            _taskManager = taskManager;
            _appSettings = new AppSettings();
            _nodes = new List<BaseNode>();
            _userTasks = new List<UserTask>();
            _taskRequests = new List<UserTaskRequest>();

            CreateAndSeedNodes();
        }

        public void CreateAndSeedNodes()
        {
            _nodes.AddRange(_appSettings.FogEnvironmentModel.Edges ?? new List<Edge>());
            _nodes.AddRange(_appSettings.FogEnvironmentModel.Clouds ?? new List<Cloud>());

            foreach (var node in _nodes)
            {
                node.TaskFailedEvent += Node_TaskFailedEvent;
                node.NodeFailedEvent += Node_NodeFailedEvent;
                node.AssignTheFaildTask += Node_FaildTaskAssignment;
            }

            _nodes = _taskManager.OffloadFunctionsToNodes(_nodes);
        }

        private async Task Node_FaildTaskAssignment(Guid nodeId, NodeType nodeType, UserTask userTask)
        {
            try
            {
                var userFailedTask = _userTasks.SingleOrDefault(q => q.ID == userTask.ID);

                if (userFailedTask != null)
                    if (userFailedTask.State == TaskState.AwaitForFreeNode)
                    {
                        var reasignedTask = await _taskManager.ExecutFailedUserTask(userTask);

                        _userTasks.SingleOrDefault(q => q.ID == userTask.ID).IsTaskDone = true;
                        _userTasks.SingleOrDefault(q => q.ID == userTask.ID).State = TaskState.Done;
                        _userTasks.SingleOrDefault(q => q.ID == userTask.ID).TaskStates.Add(TaskState.Done);
                    }
            }
            catch
            {
            }
        }

        public async Task ManageAndExecuteTasksAsync(List<UserTaskRequest> userTaskRequests)
        {
            try
            {
                _taskRequests = userTaskRequests;
                (_userTasks, _nodes) = _fitnessService.CreateUserTaskList(_nodes, userTaskRequests);
                (_nodes, _userTasks) = await _taskManager.ExecutUserTasks(_nodes, _userTasks);
            }
            catch
            {
            }
        }

        private async Task Node_NodeFailedEvent(Guid obj, NodeType nodeType)
        {
            var nodeRemainedTasksReassign = _fitnessService.FailedNodeRemainedTasksReassign(_nodes, _nodes.SingleOrDefault(q => q.Id == obj));

            foreach (var remaindTask in nodeRemainedTasksReassign.Item1)
                remaindTask.AssignedNode.FailedOfloadedTasks.Add(remaindTask);
        }

        private async Task Node_TaskFailedEvent(Guid nodeId, Guid taskId, NodeType nodeType, TaskType task, Exception exception)
        {
            var userTaskReassign = _fitnessService.ReassignsFailedUserTaskToAvailableNode(_nodes, _userTasks.SingleOrDefault(q => q.ID == taskId));
            _nodes = userTaskReassign.Item1;
            userTaskReassign.Item2.AssignedNode.FailedOfloadedTasks.Add(userTaskReassign.Item2);
        }
    }
}
