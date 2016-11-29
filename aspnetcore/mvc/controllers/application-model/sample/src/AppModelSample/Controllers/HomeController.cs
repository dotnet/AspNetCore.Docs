using AppModelSample.Conventions;
using Microsoft.AspNetCore.Mvc;

namespace AppModelSample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        #region ActionModelConvention
        // Route: /Home/MyCoolAction
        [CustomActionName("MyCoolAction")]
        public string SomeName()
        {
            return ControllerContext.ActionDescriptor.ActionName;
        }
        #endregion
    }
}
