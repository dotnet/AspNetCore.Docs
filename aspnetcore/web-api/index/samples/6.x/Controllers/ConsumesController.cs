using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WebApiSample.Controllers
{
    #region snippet_Class
    [ApiController]
    [Route("api/[controller]")]
    public class ConsumesController : ControllerBase
    {
        [HttpPost]
        [Consumes("application/json")]
        public IActionResult PostJson(IEnumerable<int> values) =>
            Ok(new { Consumes = "application/json", Values = values });

        [HttpPost]
        [Consumes("application/x-www-form-urlencoded")]
        public IActionResult PostForm([FromForm] IEnumerable<int> values) =>
            Ok(new { Consumes = "application/x-www-form-urlencoded", Values = values });
    }
    #endregion
}
