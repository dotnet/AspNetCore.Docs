using Microsoft.AspNetCore.Mvc;

namespace WebMvcRouting.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Article()
        {
            var path = Request.Path.Value;
            var actionName = ControllerContext.ActionDescriptor.ActionName;
            var controllerName = ControllerContext.ActionDescriptor.ControllerName;

            return Content($"Path: {path}" +
                $" controller:{controllerName}  action name: {actionName}");
        }

        public IActionResult Index()
        {
            var path = Request.Path.Value;
            var actionName = ControllerContext.ActionDescriptor.ActionName;
            var controllerName = ControllerContext.ActionDescriptor.ControllerName;

            return Content($"Path: {path}" +
                $" controller:{controllerName}  action name: {actionName}");
        }

        public IActionResult Xyz()
        {
            var path = Request.Path.Value;
            var actionName = ControllerContext.ActionDescriptor.ActionName;
            var controllerName = ControllerContext.ActionDescriptor.ControllerName;

            return Content($"Path: {path}" +
                $" controller:{controllerName}  action name: {actionName}");
        }
    }
}