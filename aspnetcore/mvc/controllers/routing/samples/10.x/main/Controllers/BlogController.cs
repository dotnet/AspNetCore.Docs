using Microsoft.AspNetCore.Mvc;
using Microsoft.Docs.Samples;

namespace WebMvcRouting.Controllers
{
    // requires   webBuilder.UseStartup<Startup>();
    // <snippet>
    public class BlogController : Controller
    {
        public IActionResult Article()
        {
            return ControllerContext.MyDisplayRouteInfo();
        }

        public IActionResult Index()
        {
            return ControllerContext.MyDisplayRouteInfo();
        }
    }
    // </snippet>
}
