using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAll.Controllers
{
    #region snippet
    [Authorize(Roles = "Administrator")]
    public class AdministrationController : Controller
    {
        public IActionResult Index() =>
            Content("Administrator");
    }
    #endregion
}
