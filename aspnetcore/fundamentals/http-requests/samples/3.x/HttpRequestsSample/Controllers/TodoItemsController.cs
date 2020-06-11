using System.Collections.Generic;
using System.Threading.Tasks;
using HttpRequestsSample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HttpRequestsSample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoItemsController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoItemsController(TodoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<TodoItem>> Get() =>
             await _context.TodoItems.AsNoTracking().ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> Get(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
                return NotFound();

            return todoItem;
        }

        [HttpPost]
        public async Task<IActionResult> Post(TodoItem todoItem)
        {
            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = todoItem.Id, todoItem });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, TodoItem todoItem)
        {
            if (todoItem.Id != id)
                return BadRequest();

            _context.Update(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
                return NotFound();

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
