using FogEnvironment.Domain.Enum;

namespace FogEnvironment.Domain.Model.TaskModels
{
    public class UserTask
    {
        public Guid ID { get; set; }
        public bool IsTaskAssignedToNode { get; set; }
        public bool IsTaskDone { get; set; }
        public int TaskVolume { get; set; }
        public int TaskCast { get; set; }
        public TaskType TaskType { get; set; }
        public TaskState State { get; set; }
        public BaseNode AssignedNode { get; set; }
    }
}
