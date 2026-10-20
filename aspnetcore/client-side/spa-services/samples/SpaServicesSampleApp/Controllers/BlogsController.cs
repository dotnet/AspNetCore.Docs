using Microsoft.AspNetCore.Mvc;
using SpaServicesSampleApp.Data;

namespace SpaServicesSampleApp.Controllers
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