using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace RoutingSample.Controllers
{
    #region snippet
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        // GET /api/test/3
        [HttpGet("{id:customName}")]
        public ActionResult<string> Get(string id)
        {
            return new CCAD().GetADinfo(ControllerContext, id);
        }

        // GET /api/test/my/3
        [HttpGet("my/{id:customName}")]
        public ActionResult<string> Get(int id)
        {
            return new CCAD().GetADinfo(ControllerContext, id);
        }
    }
    #endregion

    [Route("api/[controller]")]
    [ApiController]
    public class Test2Controller : ControllerBase
    {
        // GET /api/test2/3
        #region snippet2
        [HttpGet("{id}")]
        public ActionResult<string> Get(string id)
        {
            if (id.Contains('0'))
            {
                return StatusCode(StatusCodes.Status406NotAcceptable);
            }

            return new CCAD().GetADinfo(ControllerContext, id);
        }
        #endregion
    }
}