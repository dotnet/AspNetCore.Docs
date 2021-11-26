using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAll.Controllers
{
    #region snippet
    [Authorize(Roles = "PowerUser")]
    [Authorize(Roles = "ControlPanelUser")]
    public class ControlPanelController : Controller
    {
        public IActionResult Index() =>
            Content("PowerUser && ControlPanelUser");
    }
    #endregion
}
