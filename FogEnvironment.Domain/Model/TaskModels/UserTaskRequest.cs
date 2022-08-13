using FogEnvironment.Domain.Enum;

namespace FogEnvironment.Domain.Model.TaskModels
{
    public class UserTaskRequest
    {
        public UserTaskRequest()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public byte[] Image { get; set; }
        public List<UserTask> UserTask { get; set; }
    }
}
