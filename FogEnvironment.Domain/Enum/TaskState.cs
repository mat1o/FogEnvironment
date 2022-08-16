using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FogEnvironment.Domain.Enum
{
    public enum TaskState
    {
        AwaitForFreeNode,
        Assigned,
        InProgress,
        Canceld,
        Done,
    }
}
