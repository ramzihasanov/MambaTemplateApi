namespace Mamba.Entites
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public List<Worker> workers { get; set; }
    }
}
