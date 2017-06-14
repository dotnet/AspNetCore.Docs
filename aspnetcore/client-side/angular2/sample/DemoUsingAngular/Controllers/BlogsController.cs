using Microsoft.AspNetCore.Mvc;
using DemoUsingAngular.Data;

namespace DemoUsingAngular.Controllers
{
    [Route("api/[controller]")]
    public class BlogsController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            var blogs = SampleData.Blogs();

            return Ok(blogs);
        }
    }
}
