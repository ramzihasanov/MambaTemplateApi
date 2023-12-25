namespace Mamba.Entites
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool Isdeleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
