using Microsoft.AspNetCore.Mvc;
using AnonymousForumz.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AnonymousForumz.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserQuizResultsController : ControllerBase
    {
        private readonly QuizDbContext _context;

        public UserQuizResultsController(QuizDbContext context)
        {
            _context = context;
        }

        // GET: api/UserQuizResults
        [HttpGet]
        public async Task<IActionResult> GetUserQuizResults()
        {
            var results = await _context.UserQuizResults
                .Include(r => r.Quiz) // Include related Quiz
                .Include(r => r.User) // Include related User
                .ToListAsync();
            return Ok(results);
        }

        // GET: api/UserQuizResults/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserQuizResult(int id)
        {
            var result = await _context.UserQuizResults
                .Include(r => r.Quiz) // Include related Quiz
                .Include(r => r.User) // Include related User
                .FirstOrDefaultAsync(r => r.Id == id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST: api/UserQuizResults
        [HttpPost]
        public async Task<IActionResult> CreateUserQuizResult([FromBody] UserQuizResult result)
        {
            if (ModelState.IsValid)
            {
                _context.UserQuizResults.Add(result);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetUserQuizResult), new { id = result.Id }, result);
            }

            return BadRequest(ModelState);
        }

        // PUT: api/UserQuizResults/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserQuizResult(int id, [FromBody] UserQuizResult result)
        {
            if (id != result.Id)
            {
                return BadRequest();
            }

            _context.Entry(result).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserQuizResultExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/UserQuizResults/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserQuizResult(int id)
        {
            var result = await _context.UserQuizResults.FindAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            _context.UserQuizResults.Remove(result);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserQuizResultExists(int id)
        {
            return _context.UserQuizResults.Any(e => e.Id == id);
        }
    }
}
