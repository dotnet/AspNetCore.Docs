using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItems1Controller : ControllerBase
    {
        // PUT: api/TodoItems1/5
        [HttpPut("{id}")]
        public ContentResult PutTodoItem(long id)
        {
            if (id < 1)
            {
                return Content($"ID = {id}");
            }

            return Content($"PutTodoItem: ID = {id}");
        }

        // Delete: api/TodoItems1/5
        [HttpDelete("{id}")]
        public ContentResult MyDelete(long id)
        {
            return Content($"MyDelete: ID = {id}");
        }

        // GET: api/TodoItems1
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

        // Delete: api/TodoItems1/MyDelete2/5
        [EnableCors()]
        [HttpDelete("{action}/{id}")]
        public ContentResult MyDelete2(long id)
        {
            return Content($"MyDelete2: ID = {id}");
        }
    }
}