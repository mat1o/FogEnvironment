using FogEnvironment.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FogEnvironment.Domain.Model
{
    public class Cloud : BaseNode
    {
        public Cloud()
        {
            NodeType = NodeType.Cloud;
        }

        public NodeType NodeType { get; set; }
    }
}
