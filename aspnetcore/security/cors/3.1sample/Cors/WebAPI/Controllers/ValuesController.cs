using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    #region snippet
    [EnableCors(MyGC.MyAllowSpecificOrigins)]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ContentResult Get()
        {
            return Content("GET api/values");
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ContentResult Get(int id)
        {
            return Content($"GET ID: ID = {id}");
        }

        // GET: api/values/GetValues2
        [DisableCors]
        [HttpGet("{action}")]
        public ContentResult GetValues2()
        {
            return Content("GetValues2");
        }
    }
    #endregion
}
