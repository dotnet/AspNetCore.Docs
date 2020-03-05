using Microsoft.AspNetCore.Mvc;

namespace WebMvcRouting.Controllers
{
    // requires   webBuilder.UseStartup<Startup>();
    #region snippet
    public class BlogController : Controller
    {
        public IActionResult Article() =>
            ControllerContext.MyDisplayRouteInfo();

        public IActionResult Index() =>
            ControllerContext.MyDisplayRouteInfo();
    }
    #endregion
}