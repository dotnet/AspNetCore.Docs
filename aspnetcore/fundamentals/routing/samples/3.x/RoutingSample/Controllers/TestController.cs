using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Docs.Samples;

namespace RoutingSample.Controllers
{
    // <snippet>
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        // GET /api/test/3
        [HttpGet("{id:customName}")]
        public IActionResult Get(string id)
        {
            return ControllerContext.MyDisplayRouteInfo(id);
        }

        // GET /api/test/my/3
        [HttpGet("my/{id:customName}")]
        public IActionResult Get(int id)
        {
            return ControllerContext.MyDisplayRouteInfo(id);
        }
    }
    // </snippet>

    [Route("api/[controller]")]
    [ApiController]
    public class Test2Controller : ControllerBase
    {
        // GET /api/test2/3
        // <snippet2>
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            if (id.Contains('0'))
            {
                return StatusCode(StatusCodes.Status406NotAcceptable);
            }

            return ControllerContext.MyDisplayRouteInfo(id);
        }
        // </snippet2>
    }
}