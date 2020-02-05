using Microsoft.AspNetCore.Mvc;
namespace WebMvcRouting.Controllers
{
    #region snippet_1

    public class UrlGenerationController : Controller
    {
        public IActionResult Source()
        {
            // Generates /UrlGeneration/Destination
            var url = Url.Action("Destination");
            return Content($"Url.RouteUrl('Destination_Route') = {url}");
        }

        public IActionResult Destination()
        {
            var actionName = ControllerContext.ActionDescriptor.ActionName;
            var controllerName = ControllerContext.ActionDescriptor.ControllerName;

            return Content($"Controller:{controllerName}  action name: {actionName}");
        }
    }
    #endregion
}