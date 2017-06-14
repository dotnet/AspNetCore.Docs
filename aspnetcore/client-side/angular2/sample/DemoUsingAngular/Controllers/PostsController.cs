using DemoUsingAngular.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoUsingAngular.Controllers
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
