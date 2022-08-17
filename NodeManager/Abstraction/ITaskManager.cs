using FogEnvironment.Domain.Model;

namespace FogEnvironment.NodeManager.Abstraction
{
    public interface ITaskManager
    {
        void OffloadFunctionsToNodes(List<BaseNode> baseNodes);
    }
}
