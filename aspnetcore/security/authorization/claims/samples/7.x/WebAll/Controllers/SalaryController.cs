using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAll.Controllers
{
    #region snippet
    [Authorize(Policy = "EmployeeOnly")]
    public class SalaryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Payslip()
        {
            return View();
        }

        [Authorize(Policy = "HumanResources")]
        public IActionResult UpdateSalary()
        {
            return View();
        }
    }
    #endregion
}
