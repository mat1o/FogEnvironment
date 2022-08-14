using FogEnvironment.Domain.Model;
using FogEnvironment.Domain.Model.TaskModels;
using FogEnvironment.NodeManager.Abstraction;

namespace FogEnvironment.NodeManager.Implementation
{
    public class FitnessService : IFitnessService
    {
        public void AssignTasksToNodes(List<BaseNode> baseNodes, UserTaskRequest userTaskRequest)
        {
            var nodesOrderByCapacity = baseNodes
                .OrderBy(q => q.NodeType)
                .ThenByDescending(q => q.NodeType);

        }

        //public List<UserTask> FunctionsAssignedToNode(BaseNode node, UserTaskRequest userTaskRequest)
        //{
        //    var nodeAvailableCapacity = node.StorageCapacity - userTaskRequest.ImageSizeOnDisk;

        //    var selectedTaskForThisNode = UtilitieFunctions.KnapSackResolver(nodeAvailableCapacity,)
        //}
    }
}
