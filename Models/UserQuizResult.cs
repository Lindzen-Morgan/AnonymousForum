﻿using AnonymousForumz;
using AnonymousForumz.Models;
namespace AnonymousForumz.Models
{
    public class UserQuizResult
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int QuizId { get; set; }
        public Quiz? Quiz { get; set; }
        public int Score { get; set; }
    }
}
