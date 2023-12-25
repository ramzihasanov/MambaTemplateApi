namespace Mamba.Entites
{
    public class Position:BaseEntity
    {
        public string Name { get; set; }
        public List<WorkerPosition> WorkerPosition { get; set; }
    }
}
