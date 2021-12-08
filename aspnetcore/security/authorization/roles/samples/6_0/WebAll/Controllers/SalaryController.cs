using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAll.Controllers
{
    #region snippet
    [Authorize(Roles = "HRManager,Finance")]
    public class SalaryController : Controller
    {
        public IActionResult Payslip() =>
                        Content("HRManager || Finance");
    }
    #endregion
}
