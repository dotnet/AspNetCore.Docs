using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    #region snippet
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItems2Controller : ControllerBase
    {
        // OPTIONS: api/TodoItems2/5
        [HttpOptions("{id}")]
        public IActionResult PreflightRouteID()
        {
            return NoContent();
        }

        // OPTIONS: api/TodoItems2 
        [HttpOptions]
        public IActionResult PreflightRoute()
        {
            return NoContent();
        }

        // PUT: api/TodoItems2/5
        [HttpPut("{id}")]
        public ContentResult PutTodoItem(long id)
        {
            if (id < 1)
            {
                return Content($"ID = {id}");
            }

            return Content($"PutTodoItem: ID = {id}");
        }
        #endregion

        // Delete: api/TodoItems2/5
        [HttpDelete("{id}")]
        public ContentResult MyDelete(long id)
        {
            return Content($"MyDelete: ID = {id}");
        }

        // GET: api/TodoItems2
        [HttpGet]
        public ContentResult GetTodoItems()
        {
            return Content("Get TO DO ");
        }

        [EnableCors()]
        [HttpGet("{action}")]
        public ContentResult GetTodoItems2()
        {
            return Content("GetTodoItems2");
        }

        #region snippet2
        // Delete: api/TodoItems2/MyDelete2/5
        [EnableCors()]
        [HttpDelete("{action}/{id}")]
        public ContentResult MyDelete2(long id)
        {
            return Content($"MyDelete2: ID = {id}");
        }
        #endregion
    }
}