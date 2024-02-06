namespace AnonymousForum.Models
{
    public class Reply
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        // Other properties as needed

        public int ThreadId { get; set; }
        public Thread Thread { get; set; }
    }
}
