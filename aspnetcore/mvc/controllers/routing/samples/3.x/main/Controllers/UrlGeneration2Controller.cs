#define First
#if First

// This is the ultimate greedy route
using Microsoft.AspNetCore.Mvc;
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
            return Content($"Url.RouteUrl('Destination_Route') = {url}");
        }
        #endregion

        [HttpGet("custom/url/to/destination2", Name = "Destination_Route")]
        public IActionResult Destination()
        {
            var template = ControllerContext.ActionDescriptor.AttributeRouteInfo.Template;
            var routeName = ControllerContext.ActionDescriptor.AttributeRouteInfo.Name;
            var actionName = ControllerContext.ActionDescriptor.ActionName;
            var controllerName = ControllerContext.ActionDescriptor.ControllerName;

            return Content($"route name:{routeName}  template:{template} " +
                $" controller:{controllerName}  action name: {actionName}");
        }
    }
    #endregion
}
#endif