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

        [HttpPut("{id}")]
        public IActionResult PutTodoItem(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            return ControllerContext.MyDisplayRouteInfo(id);
        }
        #endregion

        [HttpDelete("{id}")]
        public IActionResult MyDelete(int id) =>
            ControllerContext.MyDisplayRouteInfo(id);

        [HttpGet]
        public IActionResult GetTodoItems() =>
            ControllerContext.MyDisplayRouteInfo();

        [EnableCors]
        [HttpGet("{action}")]
        public IActionResult GetTodoItems2() =>
            ControllerContext.MyDisplayRouteInfo();

        [EnableCors]
        [HttpDelete("{action}/{id}")]
        public IActionResult MyDelete2(int id) =>
            ControllerContext.MyDisplayRouteInfo(id);
    }
}