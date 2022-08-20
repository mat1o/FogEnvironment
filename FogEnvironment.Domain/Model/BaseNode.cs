using FogEnvironment.Domain.Enum;
using FogEnvironment.Domain.Model.TaskModels;
using System.Collections.ObjectModel;

namespace FogEnvironment.Domain.Model
{
    public abstract class BaseNode
    {
        public BaseNode()
        {
            FailedOfloadedTasks.CollectionChanged += FailedOfloadedTasks_CollectionChanged;
        }

        public Guid Id { get; set; }
        public int StorageCapacity { get; set; }
        public int ParallelRequestCapacity { get; set; }
        public int LatancyToUser { get; set; }
        public int LatancyToOther { get; set; }
        public int ExectionLatancy { get; set; }
        public string Name { get; set; }
        public bool IsAvaliable { get; set; }
        public NodeType NodeType { get; set; }
        public List<UserTask> AssignedTasks { get; set; }
        public List<ActionModel> ExecutableFunctions { get; set; }
        public ObservableCollection<UserTask> FailedOfloadedTasks { get; set; }
        public double CastOfExecution { get; set; }
        public double CastPerGb { get; set; }

        public event Func<Guid,Guid, NodeType,TaskType,Exception, Task> TaskFailedEvent;
        public event Func<Guid, NodeType, Task> NodeFailedEvent;
        public event Func<Guid, NodeType, UserTask, Task> AssignTheFaildTask;


        public void RaiseTaskFailureEvent(Guid id ,Guid taskId, NodeType nodeType, TaskType taskType,Exception exception) =>
             TaskFailedEvent(id, taskId, nodeType, taskType, exception);

        public void FailedOfloadedTasks_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action is System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                AssignTheFaildTask(Id, NodeType, e.NewItems[0] as UserTask);
        }

        public void RasieNodeFailureEvent(Guid nodeId, NodeType nodeType) => NodeFailedEvent(nodeId, nodeType);
    }
}
