using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAll.Pages
{
    // /x/salary?handler=paystub
    // /x/salary/paystub
    // /x/salary?handler=Salary
    #region snippet
    [Authorize(Policy = "EmployeeOnly")]
    [Authorize(Policy = "HumanResources")]
    public class SalaryModel : PageModel
    {
        public ContentResult OnGetPayStub()
        {
            return Content("OnGetPayStub");
        }

        public ContentResult OnGetSalary()
        {
            return Content("OnGetSalary");
        }
    }
    #endregion
}
