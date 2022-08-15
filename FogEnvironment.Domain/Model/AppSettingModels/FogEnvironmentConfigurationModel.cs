using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FogEnvironment.Domain.Model.AppSettingModels
{
    public class FogEnvironmentConfigurationModel
    {
        public List<Edge> Edges { get; set; }
        public List<Cloud> Clouds { get; set; }
    }
}
