namespace AnonymousForumz.Models
{
    public class UserQuizResult
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public int QuizId { get; set; }
        public Quiz? Quiz { get; set; }
        public int Score { get; set; }
        public DateTime CompletedOn { get; set; }
    }
}
