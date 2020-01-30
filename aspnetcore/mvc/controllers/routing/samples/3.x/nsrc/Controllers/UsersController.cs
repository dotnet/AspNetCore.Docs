using Microsoft.AspNetCore.Mvc;

namespace My.Application.Admin.Controllers
{
    public class UsersController : Controller
    {
        // /admin/controllers/users/index
        public IActionResult Index()
        {
            //controller.ControllerTypeInfo
            var fullname = typeof(UsersController).FullName;
            var template = 
                ControllerContext.ActionDescriptor.AttributeRouteInfo?.Template;
            return Content($"Index- fullname: {fullname}  template:{template}");
        }

        public IActionResult List(int? id)
        {
            var path = Request.Path.Value;
            return Content($"List- Path:{path}");
        }
    }
}