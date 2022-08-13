using FogEnvironment.Domain.Enum;

namespace NodeManager
{
    //this is user request
    public class UserTaskRequest
    {
        public byte[] Image { get; set; }
        public List<TaskType> OrderTasks { get; set; }
    }

    //return to user immediatly 
    public class UserRequestReturn
    {
        public List<CustomJob> Jobs { get; set; }
    }

    public class CustomJob
    {
        public Guid ID { get; set; }
        public TaskType Type { get; set; }
        public DateTime AssignDateTime { get; set; }
    }
}
