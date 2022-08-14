using FogEnvironment.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FogEnvironment.Domain.Model
{
    public class Intermediary : BaseNode
    {
        public Intermediary()
        {
            NodeType = NodeType.Intermediary;
            Id = Guid.NewGuid();
            IsAvaliable = true;
        }
    }
}
