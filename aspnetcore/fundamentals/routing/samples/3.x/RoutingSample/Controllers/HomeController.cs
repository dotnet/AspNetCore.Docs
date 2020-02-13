using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace RoutingSample.Controllers
{
    #region snippet
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return new CCAD().GetADinfo(ControllerContext);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        #endregion

        public IActionResult Subscribe(int id)
        {
            return new CCAD().GetADinfo(ControllerContext);
        }
    }
}
