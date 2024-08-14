namespace AnonymousForumz.Models;

public class Quiz
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public int UserId { get; set; }
    public User? Creator { get; set; }
    public int CreatorId { get; set; }
    public DateTime CreationDate { get; set; }

    public ICollection<Question>? Questions { get; set; }
    public ICollection<UserQuizResult>? UserQuizResults { get; set; }
}
