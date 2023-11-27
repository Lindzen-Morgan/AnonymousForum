using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AnonymousForum.Data
{
    public class AnonymousForumContext : DbContext
    {
        public AnonymousForumContext(DbContextOptions<AnonymousForumContext> options)
            : base(options)
        {
        }

        public DbSet<ForumThread> ForumThread { get; set; } = default!;

        public DbSet<Reply> Reply { get; set; } = default!;
    }
}
