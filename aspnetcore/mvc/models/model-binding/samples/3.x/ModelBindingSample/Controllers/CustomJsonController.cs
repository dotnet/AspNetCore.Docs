using Microsoft.AspNetCore.Mvc;
using ModelBindingSample.Models;

namespace ModelBindingSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomJsonController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(ModelWithObjectId model) =>
            Ok(model);
    }
}
