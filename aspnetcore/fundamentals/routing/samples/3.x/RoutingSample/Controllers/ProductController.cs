using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Docs.Samples;

namespace RoutingSample.Controllers
{
    // <snippet>
    [Host("contoso.com", "adventure-works.com")]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return ControllerContext.MyDisplayRouteInfo();
        }

        [Host("example.com:8080")]
        public IActionResult Privacy()
        {
            return ControllerContext.MyDisplayRouteInfo();
        }
    }
    // </snippet>
}