using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using RoutingSample.Extensions;

namespace RoutingSample.Controllers
{
    #region snippet
    [Host("contoso.com", "adventure-works.com")]
    public class ProductController : Controller
    {
        public IActionResult Index() =>
            ControllerContext.ToActionResult();

        [Host("example.com:8080")]
        public IActionResult Privacy() =>
            ControllerContext.ToActionResult();
    }
    #endregion
}