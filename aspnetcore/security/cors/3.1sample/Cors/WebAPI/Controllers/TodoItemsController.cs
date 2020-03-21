using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        // PUT: api/TodoItems/5
        [HttpOptions("api/[controller]/{id}")]
        [HttpPut("{id}")]
        public IActionResult PutTodoItem(long id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
        
            return NoContent();
        }

        // Delete: api/TodoItems/5
        [HttpOptions("api/[controller]/{id}")]
        [HttpDelete("{id}")]
        public IActionResult MyDelete(long id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            return NoContent();
        }

        // GET: api/TodoItems
        [HttpGet]
        public ContentResult GetTodoItems()
        {
            return Content("Get TO DO ");
        }
    }
}