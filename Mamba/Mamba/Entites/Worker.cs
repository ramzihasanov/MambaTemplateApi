namespace Mamba.Entites
{
    public class Worker:BaseEntity
    {
        public string FullName { get; set; }
        public string ImgUrl { get; set; }
        public string InstaUrl { get; set; }
        public string FaceUrl { get; set; }
        public string TwitUrl { get; set; }
        public string LinkUrl { get; set; }

        public List<WorkerPosition> WorkerPosition { get; set; }
    }
}
