namespace FogEnvironment.Domain.DTO
{
    public class KnapSackDTO
    {
        public KnapSackDTO()
        {
            NominatedRows = new List<int>();
        }

        public int MaxValue { get; set; }
        public List<int> NominatedRows { get; set; }
    }
}
