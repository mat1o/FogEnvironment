using FogEnvironment.Domain.Model;
namespace FogEnvironment.Service.BaseServices
{
    public class EnvironmentDecorator
    {
        public List<Edge> _edges = new List<Edge>();
        public List<Cloud> _clouds = new List<Cloud>();
        public Random _picker = new Random();

        public EnvironmentDecorator(int cloudsCount = 1, int edgeCount = 3)
        {
            for (int i = 1; i <= cloudsCount; i++)
            {
                _clouds.Add(new Cloud
                {
                    Id = new Guid(),
                    Name = $"Cloud {i.ToString()}",
                    Latancy = 100,
                    StorageCapacity = 2000
                });
            }

            for (int i = 1; i <= edgeCount; i++)
            {
                _edges.Add(new Edge
                {
                    Id = new Guid(),
                    Name = $"Edge {i.ToString()}",
                    Latancy = _picker.Next(50,100),
                    StorageCapacity = _picker.Next(100,500)
                });
            }
        }
    }
}
