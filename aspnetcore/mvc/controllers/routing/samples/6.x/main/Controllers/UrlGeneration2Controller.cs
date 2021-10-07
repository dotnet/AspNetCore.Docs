//#define First
#if First

// This is the ultimate greedy route
using Microsoft.AspNetCore.Mvc;
using Microsoft.Docs.Samples;

namespace WebMvcRouting.Controllers
{
#region snippet_1
#region snippet_2
    public class UrlGeneration2Controller : Controller
    {
        [HttpGet("")]
        public IActionResult Source()
        {
            var url = Url.RouteUrl("Destination_Route");
            return ControllerContext.MyDisplayRouteInfo("", $" URL = {url}");
        }
#endregion

        [HttpGet("custom/url/to/destination2", Name = "Destination_Route")]
        public IActionResult Destination()
        {
            return ControllerContext.MyDisplayRouteInfo();
        }
#endregion
    }
}
#endif
