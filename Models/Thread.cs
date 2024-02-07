using System.ComponentModel.DataAnnotations;

namespace AnonymousForum.Models
{
    public class Thread
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public int TopicId { get; set; }
        public Topic Topic { get; set; }

        
    }
}
