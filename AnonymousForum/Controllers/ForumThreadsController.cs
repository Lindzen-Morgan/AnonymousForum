using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AnonymousForum.Data;

namespace AnonymousForum.Controllers
{
    public class ForumThreadsController : Controller
    {
        private readonly AnonymousForumContext _context;

        public ForumThreadsController(AnonymousForumContext context)
        {
            _context = context;
        }

        // GET: ForumThreads
        public async Task<IActionResult> Index()
        {
              return _context.ForumThread != null ? 
                          View(await _context.ForumThread.ToListAsync()) :
                          Problem("Entity set 'AnonymousForumContext.ForumThread'  is null.");
        }

        // GET: ForumThreads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ForumThread == null)
            {
                return NotFound();
            }

            var forumThread = await _context.ForumThread
                .FirstOrDefaultAsync(m => m.Id == id);
            if (forumThread == null)
            {
                return NotFound();
            }

            return View(forumThread);
        }

        // GET: ForumThreads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ForumThreads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Text,DateCreated")] ForumThread forumThread)
        {
            if (ModelState.IsValid)
            {
                _context.Add(forumThread);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(forumThread);
        }

        // GET: ForumThreads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ForumThread == null)
            {
                return NotFound();
            }

            var forumThread = await _context.ForumThread.FindAsync(id);
            if (forumThread == null)
            {
                return NotFound();
            }
            return View(forumThread);
        }

        // POST: ForumThreads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Text,DateCreated")] ForumThread forumThread)
        {
            if (id != forumThread.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(forumThread);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ForumThreadExists(forumThread.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(forumThread);
        }

        // GET: ForumThreads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ForumThread == null)
            {
                return NotFound();
            }

            var forumThread = await _context.ForumThread
                .FirstOrDefaultAsync(m => m.Id == id);
            if (forumThread == null)
            {
                return NotFound();
            }

            return View(forumThread);
        }

        // POST: ForumThreads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ForumThread == null)
            {
                return Problem("Entity set 'AnonymousForumContext.ForumThread'  is null.");
            }
            var forumThread = await _context.ForumThread.FindAsync(id);
            if (forumThread != null)
            {
                _context.ForumThread.Remove(forumThread);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ForumThreadExists(int id)
        {
          return (_context.ForumThread?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
