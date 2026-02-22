using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAll.Controllers
{
    #region snippet
    [Authorize]
    public class Control3PanelController : Controller
    {
        public IActionResult SetTime() =>
            Content("[Authorize]");

        [AllowAnonymous]
        public IActionResult Login() =>
            Content("[AllowAnonymous]");
    }
    #endregion
}
