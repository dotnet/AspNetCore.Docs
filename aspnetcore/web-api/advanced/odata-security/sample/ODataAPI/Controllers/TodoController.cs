using Microsoft.AspNetCore.Mvc;
using ODataAPI.Models;
using ODataAPI.ODataAttribute;
using System.Linq;
using System.Threading.Tasks;

namespace ODataAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext context;
        public TodoController(TodoContext context)
        {
            this.context = context;
        }

        #region snippet_eq
        [HttpGet]
        [MyEnableQuery()]
        public ActionResult<IQueryable<TodoItem>> GetTodoItems()
        {
            return this.context.TodoItems;
        }
        #endregion

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
        {
            var todoItem = await this.context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem item)
        {
            this.context.TodoItems.Add(item);
            await this.context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTodoItem), new { id = item.Id }, item);
        }
    }
}