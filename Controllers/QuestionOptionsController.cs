using Microsoft.AspNetCore.Mvc;
using AnonymousForumz.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AnonymousForumz.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionOptionsController : ControllerBase
    {
        private readonly QuizDbContext _context;

        public QuestionOptionsController(QuizDbContext context)
        {
            _context = context;
        }

        // GET: api/QuestionOptions
        [HttpGet]
        public async Task<IActionResult> GetQuestionOptions()
        {
            var options = await _context.Choices.ToListAsync();
            return Ok(options);
        }

        // GET: api/QuestionOptions/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestionOption(int id)
        {
            var option = await _context.Choices.FindAsync(id);
            if (option == null)
            {
                return NotFound();
            }

            return Ok(option);
        }

        // POST: api/QuestionOptions
        [HttpPost]
        public async Task<IActionResult> CreateQuestionOption([FromBody] Choice option)
        {
            if (ModelState.IsValid)
            {
                _context.Choices.Add(option);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetQuestionOption), new { id = option.Id }, option);
            }

            return BadRequest(ModelState);
        }

        // PUT: api/QuestionOptions/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestionOption(int id, [FromBody] Choice option)
        {
            if (id != option.Id)
            {
                return BadRequest();
            }

            _context.Entry(option).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionOptionExists(id))
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

        // DELETE: api/QuestionOptions/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestionOption(int id)
        {
            var option = await _context.Choices.FindAsync(id);
            if (option == null)
            {
                return NotFound();
            }

            _context.Choices.Remove(option);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuestionOptionExists(int id)
        {
            return _context.Choices.Any(e => e.Id == id);
        }
    }
}
