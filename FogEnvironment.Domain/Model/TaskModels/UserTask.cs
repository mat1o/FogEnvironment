using FogEnvironment.Domain.Enum;

namespace FogEnvironment.Domain.Model.TaskModels
{
    public class UserTask
    {
        public UserTask() => ID = Guid.NewGuid();
        

        public Guid ID { get; set; }
        public Guid UserRequestID { get; set; }
        public bool IsTaskAssignedToNode { get; set; }
        public bool IsTaskDone { get; set; }
        public int TaskCast { get; set; }
        public TaskType TaskType { get; set; }
        public TaskState State { get; set; }
        public BaseNode AssignedNode { get; set; }
        public byte[] Image { get; set; }
        public List<TaskState> TaskStates { get; set; }
    }
}
