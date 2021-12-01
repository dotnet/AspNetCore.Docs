using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAll.Controllers
{
    #region snippet
    [Authorize(Roles = "Administrator, PowerUser")]
    public class ControlAllPanelController : Controller
    {
        public IActionResult SetTime() =>
            Content("Administrator || PowerUser");

        [Authorize(Roles = "Administrator")]
        public IActionResult ShutDown() =>
            Content("Administrator only");
    }
    #endregion
}
