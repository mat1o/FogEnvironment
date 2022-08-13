using FogEnvironment.Domain.Enum;

namespace FogEnvironment.Domain.Model
{
    public class Cloud : BaseNode
    {
        public Cloud()
        {
            NodeType = NodeType.Cloud;
            Id = Guid.NewGuid();
        }
    }
}
