using FogEnvironment.Domain.Enum;

namespace FogEnvironment.Domain.Model
{
    public abstract class BaseNode
    {
        //raise this event when a task fail.
        public event Func<Guid,Task> TaskFailedEvent;
        public event Action<Guid> NodeFailedEvent;

        //prop count in progress task
        //prop how much free space

        public Guid Id { get; set; }
        public int StorageCapacity { get; set; }
        public int ParallelRequestCapacity { get; set; }
        public int Latancy { get; set; }
        public string Name { get; set; }
        public List<Func<object, object>> FunctionExecutionDelegetList { get; set; }
        public NodeType NodeType { get; set; }


        public void RaiseTaskFailureEvent()
        {
            TaskFailedEvent(Guid.NewGuid());
        }
        ~BaseNode()
        {
            NodeFailedEvent(Id);
        }
    }
}
