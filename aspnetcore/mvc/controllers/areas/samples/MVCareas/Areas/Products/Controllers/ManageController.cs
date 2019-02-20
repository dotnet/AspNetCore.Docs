#region snippet
using Microsoft.AspNetCore.Mvc;

namespace MVCareas.Areas.Products.Controllers
{
    #region snippet2
    [Area("Products")]
    public class ManageController : Controller
    {
    #endregion
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
#endregion