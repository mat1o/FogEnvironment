﻿using FogEnvironment.Domain.Enum;
using FogEnvironment.Domain.Model;
using FogEnvironment.NodeManager.Abstraction;
using FogEnvironment.NodeManager.BaseServices;

namespace FogEnvironment.NodeManager.Implementation
{
    public class NodeDecorator : INodeDecorator
    {
        private readonly AppSettings _appSettings;
        private readonly IFitnessService _fitnessService;

        public NodeDecorator(IFitnessService fitnessService)
        {
            _appSettings = new AppSettings();
            _fitnessService = fitnessService;

            CreateAndSeedNodes();
        }

        public void CreateAndSeedNodes()
        {
            var nodes = new List<BaseNode>();

            nodes.AddRange(_appSettings.FogEnvironmentModel.Edges);
            nodes.AddRange(_appSettings.FogEnvironmentModel.Clouds);

            foreach (var node in nodes)
            {
                node.TaskFailedEvent += Node_TaskFailedEvent;
                node.NodeFailedEvent += Node_NodeFailedEvent;
            }
        }

        public async Task ManageAndExecuteTasksAsync(List<>) 
        {

        }

        private Task Node_NodeFailedEvent(Guid obj, NodeType nodeType)
        {
            throw new NotImplementedException();
        }

        private Task Node_TaskFailedEvent(Guid arg, NodeType nodeType)
        {
            throw new NotImplementedException();
        }

        ////base node should contain a method to get a CustomUserTask
        //private readonly List<BaseNode> _nodes;

        //private List<UserTask> _tasks { get; set; }

        //public NodeDecorator(List<BaseNode> nodes)
        //{
        //    _nodes = nodes;
        //    //todo read config and create nodes
        //    foreach (var node in _nodes)
        //    {
        //        node.TaskFailedEvent += Node_TaskFailedEvent;
        //        node.NodeFailedEvent += Node_NodeFailedEvent;
        //    }
        //}

        //private async Task Node_TaskFailedEvent(Guid arg)
        //{
        //    var failedTask = _tasks.SingleOrDefault(q => q.ID == arg);
        //    failedTask.State = TaskState.Canceld;

        //    //check for available node
        //    var availableNode = _nodes.Where(q => q.NodeType == failedTask.AssignedNode.NodeType && failedTask.TaskVolume < q.StorageCapacity);
        //}

        //private void Node_NodeFailedEvent(Guid obj)
        //{
        //    throw new NotImplementedException();
        //}

        //private void Edge_TaskFailedEvent(Guid obj)
        //{
        //    var faildTask = _tasks.FirstOrDefault(x => x.ID == obj);
        //    //assign the faild task to free node


        //    throw new NotImplementedException();
        //}

        //public async Task NewReuqest(UserTaskRequest userTask)
        //{
        //    var node = _tasks.FirstOrDefault();

        //    try
        //    {

        //    }
        //    catch (Exception)
        //    {
        //        node.AssignedNode.RaiseTaskFailureEvent();
        //    }
        //    //divide take between nodes (based on those which are free
        //    // privice a method to detect the nodes which are free.
        //    foreach (var item in userTask.OrderTasks)
        //    {
        //        //create a new UserTask
        //        //and if assigned to a node update its state as in progress, and so on...
        //    }
        //}
    }
}
