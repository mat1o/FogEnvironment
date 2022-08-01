using FogEnvironment.Domain.Enum;

namespace FogEnvironment.Domain.Model
{
    public class Edge : BaseNode
    {
        public Edge()
        {
            NodeType = NodeType.Edge;
        }

        public NodeType NodeType { get; set; }
    }
}
