using Microsoft.AspNetCore.Mvc;

namespace TagHelpersBuiltInAspNetCore.Areas.Blogs.Controllers
{
    [Area("Blogs")]
    public class HomeController : Controller
    {
        // need route and attribute on controller: [Area("Blogs")]
        //[Area("Blogs")]
        public IActionResult Index() => View();

        //[Area("Blogs")]
        public IActionResult AboutBlog() => View();
    }
}
