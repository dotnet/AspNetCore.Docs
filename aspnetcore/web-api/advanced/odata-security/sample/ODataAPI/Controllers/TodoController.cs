using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ODataAPI.Models;
using ODataAPI.ODataAttribute;

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

        [HttpGet]
        [MyEnableQuery()]
        public ActionResult<IQueryable<TodoItem>> GetTodoItems()
        {
            return this.context.TodoItems;
        }

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