using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Docs.Samples;

// Used in both the MD file and the RP Test.cshtml

namespace WebAPI.Controllers
{
    #region snippet2
    #region snippet
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItems2Controller : ControllerBase
    {
        // OPTIONS: api/TodoItems2/5
        [HttpOptions("{id}")]
        public IActionResult PreflightRoute(int id)
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

        // [EnableCors] // Not needed as OPTIONS path provided
        [HttpDelete("{id}")]
        public IActionResult MyDelete(int id) =>
            ControllerContext.MyDisplayRouteInfo(id);

        [EnableCors]  // Rquired for this path
        [HttpGet]
        public IActionResult GetTodoItems() =>
            ControllerContext.MyDisplayRouteInfo();

        [HttpGet("{action}")]
        public IActionResult GetTodoItems2() =>
            ControllerContext.MyDisplayRouteInfo();

        [EnableCors]  // Rquired for this path
        [HttpDelete("{action}/{id}")]
        public IActionResult MyDelete2(int id) =>
            ControllerContext.MyDisplayRouteInfo(id);
    }
    #endregion
}