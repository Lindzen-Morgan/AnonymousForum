namespace AnonymousForum.Models
{
    public class Reply
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        

        public int ThreadId { get; set; }
        public Thread Thread { get; set; }
        public string Author { get; set; }
    }
}
