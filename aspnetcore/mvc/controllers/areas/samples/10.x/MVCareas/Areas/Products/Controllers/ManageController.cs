// <snippet>
using Microsoft.AspNetCore.Mvc;
using Microsoft.Docs.Samples;

namespace MVCareas.Areas.Products.Controllers;

// <snippet2>
[Area("Products")]
public class ManageController : Controller
{
    // </snippet2>
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
// </snippet>
