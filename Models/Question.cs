using AnonymousForumz;
using AnonymousForumz.Models;

public class Question
{
    public int Id { get; set; }
    public string? Text { get; set; }
    public string? MediaUrl { get; set; } // Stores the URL of the uploaded image or video
    public bool IsVideo { get; set; } // Indicates if the media is a video
    public int TimeLimitInSeconds { get; set; }
    public bool IsMultipleChoice { get; set; } // True if the question is multiple choice, false if it's free text
    public int QuizId { get; set; }
    public Quiz? Quiz { get; set; }

    public ICollection<Choice>? Choices { get; set; }
}
