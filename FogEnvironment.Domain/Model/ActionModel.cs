using FogEnvironment.Domain.Enum;

namespace FogEnvironment.Domain.Model
{
    public class ActionModel
    {
        public Action<object> ExecutableFunction { get; set; }
        public TaskType TaskType { get; set; }
    }
}
