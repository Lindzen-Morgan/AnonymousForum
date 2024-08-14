using AnonymousForumz.Models;
using Microsoft.EntityFrameworkCore;

namespace AnonymousForumz
{
    public class QuizDbContext(DbContextOptions<QuizDbContext> options) : DbContext(options)
    {
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<UserQuizResult> UserQuizResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Additional configuration can be done here
        }
    }
}
