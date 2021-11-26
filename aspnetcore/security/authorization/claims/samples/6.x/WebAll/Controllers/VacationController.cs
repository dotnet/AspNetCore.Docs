using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAll.Controllers
{
    #region snippet
    #region snippet2
    [Authorize(Policy = "EmployeeOnly")]
    public class VacationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult VacationBalance()
        {
            return View();
        }
        #endregion

        [AllowAnonymous]
        public ActionResult VacationPolicy()
        {
            return View();
        }
    }
    #endregion
}
