using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SpaServicesSampleApp.Data;

namespace SpaServicesSampleApp.Controllers
{
    [Route("api/blogs/{blogId}/posts")]
    public class PostsController : Controller
    {
        [HttpGet()]
        public IActionResult Get(int blogId)
        {
            var posts = SampleData.Posts().Where(p => p.BlogId == blogId);

            return Ok(posts);
        }
    }
}
