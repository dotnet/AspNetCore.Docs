using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAll.Controllers
{
    #region snippet
    [Authorize(Roles = "Administrator, PowerUser")]
    public class ControlAllPanelController : Controller
    {
        public IActionResult SetTime()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult ShutDown()
        {
            return View();
        }
    }
    #endregion
}
