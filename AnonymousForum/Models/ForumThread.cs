using System;
using System.ComponentModel.DataAnnotations;

public class ForumThread
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public string Text { get; set; }

    [DataType(DataType.Date)]
    public DateTime DateCreated { get; set; }
}
