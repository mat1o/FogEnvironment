using FaceDetectionApp;
using FogEnvironment.Domain.Model;
using FogEnvironment.NodeManager.Abstraction;

namespace FogEnvironment.NodeManager.Implementation
{
    public class TaskManager : ITaskManager
    {
        private readonly FaceDetector _faceDetector;
        public void OffloadFunctionsToNodes(List<BaseNode> baseNodes)
        {
            foreach (var node in baseNodes)
            {
                 
            }
        }
    }
}
