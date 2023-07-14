using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAll.Controllers
{
    #region snippet
    [Authorize(Roles = "Administrator")]
    public class ControlAllPanelController2 : Controller
    {
        public IActionResult SetTime() =>
            Content("Administrator only");

        [Authorize(Roles = "PowerUser")]
        public IActionResult ShutDown() =>
            Content("Administrator && PowerUser");
    }
    #endregion
}
