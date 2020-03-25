using Microsoft.AspNetCore.Mvc;
using ModelBindingSample.Models;

namespace ModelBindingSample.Controllers
{
    #region snippet_Class
    [ApiController]
    [Route("[controller]")]
    public class CustomJsonController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(ModelWithObjectId model) =>
            Ok(model);
    }
    #endregion
}
