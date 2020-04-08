using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Docs.Samples;

namespace WebAPI.Controllers
{
    #region snippet
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public IActionResult Get() =>
            ControllerContext.MyDisplayRouteInfo();

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id) =>
            ControllerContext.MyDisplayRouteInfo(id);

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id) =>
            ControllerContext.MyDisplayRouteInfo(id);


        // GET: api/values/GetValues2
        [DisableCors]
        [HttpGet("{action}")]
        public IActionResult GetValues2() =>
            ControllerContext.MyDisplayRouteInfo();

    }
    #endregion
}
