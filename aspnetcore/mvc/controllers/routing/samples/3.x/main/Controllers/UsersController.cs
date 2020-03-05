using Microsoft.AspNetCore.Mvc;

// TODO remove, not used. zz
namespace My.Application.Admin.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index() =>
            ControllerContext.MyDisplayRouteInfo();

        public IActionResult List(int? id) =>
             ControllerContext.MyDisplayRouteInfo(id);
    }
}