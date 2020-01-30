using Microsoft.AspNetCore.Mvc;

// To test
// create a new MVC web app and add this controller.
// Copy code from StartupNamespaceRoutingConvention.cs to Startup.cs 
// When testing here you get as RoutePatternException: The route parameter name 'id' appears more than one time in the route template.
#region snippet
namespace My.Application.Admin.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            var template = ControllerContext.ActionDescriptor.AttributeRouteInfo?.Template;
            return Content($"Index- template:{template}");
        }

        public IActionResult List(int? id)
        {
            var path = Request.Path.Value;
            return Content($"List- Path:{path}");
        }
    }
}
#endregion