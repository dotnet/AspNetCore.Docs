using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    #region snippet
    [Route("api/[controller]")]
    [ApiController]
    public class WidgetController : ControllerBase
    {
        // GET api/values
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "green widget", "red widget" };
        }

        #region snippet2
        // GET api/values/5
        [EnableCors]        // Default policy.
        [HttpGet("{id}")]
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
        #endregion
    }
    #endregion
}
