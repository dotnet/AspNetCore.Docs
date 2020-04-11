using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase {
        private readonly TodoContext _context;

        public TodoItemsController (TodoContext context) {
            _context = context;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemDTO>>> GetTodoItems () {
            return await _context.TodoItems
                .Select (x => ItemToDTO (x))
                .ToListAsync ();
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<TodoItemDTO>> GetTodoItem (string id) {
            var todoItem = await _context.TodoItems.FindAsync (id);

            if (todoItem == null) {
                return NotFound ();
            }

            return ItemToDTO (todoItem);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTodoItem (TodoItemDTO todoItemDTO) {
            var todoItem = await _context.TodoItems.FindAsync (todoItemDTO.Id);
            if (todoItem == null) {
                return NotFound ();
            }

            todoItem.Name = todoItemDTO.Name;
            todoItem.Notes = todoItemDTO.Notes;
            todoItem.Done = todoItemDTO.Done;

            try {
                await _context.SaveChangesAsync ();
            } catch (DbUpdateConcurrencyException) when (!TodoItemExists (todoItemDTO.Id)) {
                return NotFound ();
            }

            return NoContent ();
        }

        [HttpPost]
        public async Task<ActionResult<TodoItemDTO>> CreateTodoItem (TodoItemDTO todoItemDTO) {
            if (TodoItemExists (todoItemDTO.Id)) {
                return StatusCode (StatusCodes.Status409Conflict);
            }

            var todoItem = new TodoItem {
                Id = todoItemDTO.Id,
                Name = todoItemDTO.Name,
                Notes = todoItemDTO.Notes,
                Done = todoItemDTO.Done
            };

            _context.TodoItems.Add (todoItem);
            await _context.SaveChangesAsync ();

            return CreatedAtAction (
                nameof (GetTodoItem),
                new { id = todoItem.Id },
                ItemToDTO (todoItem));
        }

        [HttpDelete ("{id}")]
        public async Task<IActionResult> DeleteTodoItem (string id) {
            var todoItem = await _context.TodoItems.FindAsync (id);

            if (todoItem == null) {
                return NotFound ();
            }

            _context.TodoItems.Remove (todoItem);
            await _context.SaveChangesAsync ();

            return NoContent ();
        }

        private bool TodoItemExists (string id) =>
            _context.TodoItems.Any (e => e.Id == id);

        private static TodoItemDTO ItemToDTO (TodoItem todoItem) =>
            new TodoItemDTO {
                Id = todoItem.Id,
                Name = todoItem.Name,
                Notes = todoItem.Notes,
                Done = todoItem.Done
            };
    }
}