using Microsoft.AspNetCore.Mvc;
using Microsoft.Docs.Samples;

namespace RoutingSample.Controllers
{
    #region snippet
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return ControllerContext.MyDisplayRouteInfo();
        }

        public IActionResult Privacy()
        {
            return ControllerContext.MyDisplayRouteInfo();
        }

        #endregion

        public IActionResult Subscribe(int id)
        {
            return ControllerContext.MyDisplayRouteInfo(id);
        }
    }
}
