using Microsoft.AspNetCore.Mvc;
using System.Linq;
using AnonymousForum.Models;
using Microsoft.EntityFrameworkCore;

namespace AnonymousForum.Controllers
{
    public class ThreadController : Controller
    {
        private readonly ForumDbContext _context;

        public ThreadController(ForumDbContext context)
        {
            _context = context;
        }

        // Action method to display threads
        public IActionResult Index(int topicId)
        {
            // Retrieve list of threads related to the selected topic from the database
            var threads = _context.Threads
                .Where(t => t.TopicId == topicId)
                .Include(t => t.Topic) //to include topic for each thread
                .ToList(); // Pass the list of threads to the view

            return View(threads);
        }
    }
}
