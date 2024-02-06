using Microsoft.EntityFrameworkCore;

namespace AnonymousForum
{
    public class ForumDbContext : DbContext
    {
        public ForumDbContext(DbContextOptions<ForumDbContext> options) : base(options)
        {
        }

        // DbSet properties models 
        public DbSet<Models.Topic> Topics { get; set; }
        public DbSet<Models.Thread> Threads { get; set; }
        public DbSet<Models.Reply> Replies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Topics or init data
            modelBuilder.Entity<Models.Topic>().HasData(
                new Models.Topic { Id = 1, Name = "School" },
                new Models.Topic { Id = 2, Name = "Sports" },
                new Models.Topic { Id = 3, Name = "Movies" }
            );

            

            base.OnModelCreating(modelBuilder);
        }
    }
}
