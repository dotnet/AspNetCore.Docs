#region snippet
using Microsoft.AspNetCore.Mvc;
using Microsoft.Docs.Samples;

namespace MVCareas.Areas.Products.Controllers;

#region snippet2
[Area("Products")]
public class ManageController : Controller
{
    #endregion
    public IActionResult Index()
    {
        ViewData["routeInfo"] = ControllerContext.MyDisplayRouteInfo();
        return View();
    }

    public IActionResult About()
    {
        ViewData["routeInfo"] = ControllerContext.MyDisplayRouteInfo();
        return View();
    }
}
#endregion
