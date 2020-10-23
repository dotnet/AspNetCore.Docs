using Microsoft.AspNetCore.Mvc;
using Microsoft.Docs.Samples;

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