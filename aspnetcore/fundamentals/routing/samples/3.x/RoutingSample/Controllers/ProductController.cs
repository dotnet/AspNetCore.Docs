using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace RoutingSample.Controllers
{
    #region snippet
    [Host("contoso.com", "adventure-works.com")]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return new CCAD().GetADinfo(ControllerContext);
        }

        [Host("example.com:8080")]
        public IActionResult Privacy()
        {
            return new CCAD().GetADinfo(ControllerContext);
        }
    }
    #endregion
}