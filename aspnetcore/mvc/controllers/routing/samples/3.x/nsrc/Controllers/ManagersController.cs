using Microsoft.AspNetCore.Mvc;

namespace My.Application.Admin.Controllers
{
    #region snippet
    [Route("[controller]/[action]/{id?}")]
    public class ManagersController : Controller
    {
        // /managers/index
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
    #endregion
}