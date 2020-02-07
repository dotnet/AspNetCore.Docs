using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace WebMvcRouting.Controllers
{
    // requires   webBuilder.UseStartup<Startup>();
    #region snippet
    public class BlogController : Controller
    {
        public IActionResult Article()
        {
            return GetData(Request, ControllerContext.ActionDescriptor);
        }

        public IActionResult Index()
        {
            return GetData(Request, ControllerContext.ActionDescriptor);
        }

        private ContentResult GetData(HttpRequest request, ControllerActionDescriptor actionDesc)
        {
            var path = request.Path.Value;
            var actionName = actionDesc.ActionName;
            var controllerName = actionDesc.ControllerName;

            return Content($"Path: {path} - {controllerName}.{actionName}");
        }
    }
    #endregion
}