using Microsoft.AspNetCore.Mvc;


namespace RoutingSample.Controllers
{
    #region snippet
    public class HomeController : Controller
    {
        public IActionResult Index() =>
            ControllerContext.MyDisplayRouteInfo();

        public IActionResult Privacy() =>
            ControllerContext.MyDisplayRouteInfo();

        #endregion

        public IActionResult Subscribe(int id) =>
            ControllerContext.MyDisplayRouteInfo(id);
    }
}
