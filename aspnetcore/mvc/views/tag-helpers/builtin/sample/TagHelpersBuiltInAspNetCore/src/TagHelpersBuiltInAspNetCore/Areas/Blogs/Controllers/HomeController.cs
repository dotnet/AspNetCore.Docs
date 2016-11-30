using Microsoft.AspNetCore.Mvc;
namespace TagHelpersBuiltInAspNetCore.Areas.Blogs.Controllers
{
    [Area("Blogs")]
    public class HomeController : Controller
    {
        // GET: /<controller>/
        // need route and attribute on controller:  [Area("Blogs")]
        //[Area("Blogs")]
        public IActionResult Index()
        {
            return View();
        }

        //[Area("Blogs")]
        public IActionResult AboutBlog()
        {
            return View();
        }
    }
}
