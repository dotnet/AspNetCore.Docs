using Microsoft.AspNetCore.Mvc;
using Microsoft.Docs.Samples;

namespace WebMvcRouting.Controllers
{
    #region snippet_1
    public class UrlGenerationController : Controller
    {
        public IActionResult Source()
        {
            // Generates /UrlGeneration/Destination
            var url = Url.Action("Destination");
            return ControllerContext.MyDisplayRouteInfo("", $" URL = {url}");
        }

        public IActionResult Destination()
        {
            return ControllerContext.MyDisplayRouteInfo();
        }
    }
    #endregion
}