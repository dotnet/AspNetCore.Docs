using Microsoft.AspNetCore.Mvc;

namespace My.Application.Admin.Controllers
{
    #region snippet
    [NamespaceRoutingConvention("My.Application")]
    public class TestController : Controller
    {
        // /admin/controllers/test/index
        public IActionResult Index()
        {
            var template = ControllerContext.ActionDescriptor.AttributeRouteInfo?.Template;
            var actionname = ControllerContext.ActionDescriptor.ActionName;
            return Content($"Action- {actionname} template:{template}");
        }

        public IActionResult List(int? id)
        {
            var path = Request.Path.Value;
            return Content($"List- Path:{path}");
        }
    }
    #endregion
}