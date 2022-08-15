using FogEnvironment.Domain.Enum;

namespace FogEnvironment.Domain.Model
{
    public class Edge : BaseNode
    {
        public Edge()
        {
            NodeType = NodeType.Edge;
            Id = Guid.NewGuid();
            CastCalculationType = CastCalculationType.ConstantPerDevice;
            IsAvaliable = true;
        }
    }
}
