using Microsoft.AspNetCore.Mvc;

namespace WebMvcRouting.Controllers
{
    #region snippet
    public class SubscriptionManagementController : Controller
    {

        [HttpGet("[controller]/[action]")] // Matches '/subscription-management/list-all'
        public IActionResult ListAll()
        {
            return Content("SubscriptionManagementController");
        }
    }
    #endregion
}