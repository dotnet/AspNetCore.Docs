using DemoUsingAngular.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
