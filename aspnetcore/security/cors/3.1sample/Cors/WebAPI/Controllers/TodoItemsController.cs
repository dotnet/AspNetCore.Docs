using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    #region snippet
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        // PUT: api/TodoItems/5
        [HttpPut("{id}")]
        public ContentResult PutTodoItem(int id)
        {
            if (id < 1)
            {
                return Content($"ID = {id}");
            }

            return Content($"PutTodoItem: ID = {id}");
        }

        // Delete: api/TodoItems/5
        [HttpDelete("{id}")]
        public ContentResult MyDelete(int id)
        {
            return Content($"MyDelete: ID = {id}");
        }
        #endregion

        // GET: api/TodoItems
        [HttpGet]
        public ContentResult GetTodoItems()
        {
            return Content("Get TO DO ");
        }
    }
}