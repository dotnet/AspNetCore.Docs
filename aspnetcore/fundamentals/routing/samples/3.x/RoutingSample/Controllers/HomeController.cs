using Microsoft.AspNetCore.Mvc;
using RoutingSample.Extensions;

namespace RoutingSample.Controllers
{
    #region snippet
    public class HomeController : Controller
    {
        public IActionResult Index() =>
            ControllerContext.ToActionResult();

        public IActionResult Privacy() =>
            ControllerContext.ToActionResult();

        #endregion

        public IActionResult Subscribe(int id) =>
            ControllerContext.ToActionResult(id);
    }
}
