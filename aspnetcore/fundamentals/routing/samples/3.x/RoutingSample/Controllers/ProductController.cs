using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;


namespace RoutingSample.Controllers
{
    #region snippet
    [Host("contoso.com", "adventure-works.com")]
    public class ProductController : Controller
    {
        public IActionResult Index() =>
            ControllerContext.MyDisplayRouteInfo();

        [Host("example.com:8080")]
        public IActionResult Privacy() =>
            ControllerContext.MyDisplayRouteInfo();
    }
    #endregion
}