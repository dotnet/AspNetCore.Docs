using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAll.Controllers
{
    #region snippet2
    #region snippet
    [Authorize(Roles = "HRManager,Finance")]
    public class SalaryController : Controller
    {
        public IActionResult Payslip()
        {
            return View();
        }
        #endregion

        [Authorize(Policy = "HumanResources")]
        public IActionResult UpdateSalary()
        {
            return View();
        }
    }
    #endregion
}
