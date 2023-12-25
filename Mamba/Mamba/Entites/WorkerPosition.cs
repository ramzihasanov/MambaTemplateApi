namespace Mamba.Entites
{
    public class WorkerPosition:BaseEntity
    {
        public int workerId { get; set; }
        public int positionId { get; set; }
        public Position position { get; set; }
        public Worker worker { get; set; }
    }
}
