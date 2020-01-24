using Microsoft.AspNetCore.Mvc;

namespace WebMvcRouting.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Article()
        {
            return Content("Article");
        }

        public IActionResult Index()
        {
            return Content("Index");
        }

        public IActionResult Xyz()
        {
            return Content("Xyz");
        }
    }
}