using FogEnvironment.Domain.Enum;
using FogEnvironment.Domain.Model.TaskModels;

namespace FogEnvironment.Domain.Model
{
    public abstract class BaseNode
    {
        public Guid Id { get; set; }
        public int StorageCapacity { get; set; }
        public int ParallelRequestCapacity { get; set; }
        public int Latancy { get; set; }
        public string Name { get; set; }
        public bool IsAvaliable { get; set; }
        public NodeType NodeType { get; set; } 
        public List<UserTask> AssignedTasks { get; set; }


        public event Func<Guid, NodeType, Task> TaskFailedEvent;
        public event Action<Guid, NodeType> NodeFailedEvent;


        public void RaiseTaskFailureEvent()
        {
            TaskFailedEvent(Guid.NewGuid(),NodeType);
        }

        ~BaseNode()
        {
            NodeFailedEvent(Id,NodeType);
        }
    }
}
