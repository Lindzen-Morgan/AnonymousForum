namespace AnonymousForum.Models
{
    public class Thread
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        // Other properties as needed

        public int TopicId { get; set; }
        public Topic Topic { get; set; }
    }
}
