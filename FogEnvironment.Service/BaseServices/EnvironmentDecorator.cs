using FogEnvironment.Domain.Model;

namespace FogEnvironment.Service.BaseServices
{
    public class EnvironmentDecorator
    {
        public List<Edge> _edges = new List<Edge>();
        public List<Cloud> _clouds = new List<Cloud>();

        public EnvironmentDecorator(List<Edge> edges, List<Cloud> cloudes)
        {
            _edges.AddRange(edges);
            _clouds.AddRange(cloudes);
        }
    }
}
