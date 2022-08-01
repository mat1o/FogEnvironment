namespace FogEnvironment.Domain.Model
{
    public class BaseNode
    {
        public Guid Id { get; set; }
        public int StorageCapacity { get; set; }
        public int ParallelRequestCapacity { get; set; }
        public int Latancy { get; set; }
        public string Name { get; set; }
    }
}
