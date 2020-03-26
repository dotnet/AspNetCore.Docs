using Microsoft.AspNetCore.Mvc;

namespace WebMvcRouting.Controllers
{
    #region snippet
    public class SubscriptionManagementController : Controller
    {
        [HttpGet("[controller]/[action]")]
        public IActionResult ListAll()
        {
            return ControllerContext.MyDisplayRouteInfo();
        }
    }
    #endregion
}