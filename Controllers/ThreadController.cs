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
        // GET: Thread/Create
        public IActionResult Create(int topicId)
        {
            // topicID to view
            ViewBag.TopicId = topicId;
            return View();
        }
        // POST: Thread/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AnonymousForum.Models.Thread thread)
        {
            if (ModelState.IsValid)
            {
                // Add the new thread to the database
                _context.Threads.Add(thread);
                _context.SaveChanges();

                // Redirect to the topic view after creating the thread
                return RedirectToAction("Index", "Thread", new { topicId = thread.TopicId });
            }

            // If the model state is not valid, return the view with validation errors
            return View(thread);
        }
        //action method to display Details within a thread
        public IActionResult Details(int id)
        {
            // Retrieve the thread from the database based on its id
            var thread = _context.Threads
                .Include(t => t.Replies) // Include replies associated with the thread
                .FirstOrDefault(t => t.Id == id);

            if (thread == null)
            {
                return NotFound(); // Return 404 Not Found if the thread is not found
            }

            return View(thread); // Pass the thread to the view
        }
        //Action method to hjandlee the submission of replies
        [HttpPost]
        public IActionResult PostReply(int threadId, string content)
        {
            if (ModelState.IsValid)
            {
                var thread = _context.Threads.Include(t => t.Replies).FirstOrDefault(t => t.Id == threadId);
                if (thread == null)
                {
                    return NotFound(); // Return 404 Not Found if the thread is not found
                }

                var reply = new Reply
                {
                    Content = content,
                };

                thread.Replies.Add(reply);
                _context.SaveChanges();

                // Redirect to the thread details page after posting the reply
                return RedirectToAction("Details", new { id = threadId });
            }
            //Return to details views
            return View("Details", threadId);
        }
    }
}
