namespace AnonymousForumz.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public string? MediaUrl { get; set; }
        public bool IsVideo { get; set; }
        public int TimeLimit { get; set; } // in seconds
        public List<QuestionOption>? Options { get; set; }
        public string? CorrectAnswer { get; set; }
        public int QuizId { get; set; }
        public Quiz? Quiz { get; set; }
    }
}
