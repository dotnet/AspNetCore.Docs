using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    #region snippet
    [EnableCors("MyAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class WidgetController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "green widget", "red widget" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [EnableCors("AnotherPolicy")]
        public ActionResult<string> Get(int id)
        {
            switch (id)
            {
                case 1:
                    return "green widget";
                case 2:
                    return "red widget";
                default:
                    return NotFound();
            }
        }
       
    }
    #endregion
}
