namespace NetLearnerWeb.Models
{
    public abstract class InternetResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}