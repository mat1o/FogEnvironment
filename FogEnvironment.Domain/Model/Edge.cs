using FogEnvironment.Domain.Enum;
using System.Runtime.InteropServices;

namespace FogEnvironment.Domain.Model
{
    public class Edge : BaseNode
    {
        public Edge()
        {
            NodeType = NodeType.Edge;
            Id = Guid.NewGuid();
            IsAvaliable = true;
        }
    }
}
