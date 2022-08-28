using System.Text.Json.Serialization;

namespace FogEnvironment.Domain.Model.AppSettingModels
{
    public class ExecutionStatistics
    {
        public ExecutionStatistics(short SientificNotationPower)
        {
            this.SientificNotationPower = SientificNotationPower;
        }

        public short SientificNotationPower { get; set; }
        public TimeSpan ElepsedTime { get; set; }

        public double TotalExecutionCost { get; set; }
        public int TotalExecutionLatancy { get; set; }
        public string ExecutionDetails { get; set; }

    }
}
