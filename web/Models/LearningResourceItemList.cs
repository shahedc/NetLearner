namespace NetLearnerWeb.Models
{
    public class LearningResourceItemList
    {
        public int LearningResourceId { get; set; }
        public LearningResource LearningResource { get; set; }
        public int ItemListId { get; set; }
        public ItemList ItemList { get; set; }
    }
}