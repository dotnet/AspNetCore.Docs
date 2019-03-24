namespace PoliciesAuthApp1.Controllers
{
    #region snippet_AlcoholPurchaseControllerClass
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Policy = "AtLeast21")]
    public class AlcoholPurchaseController : Controller
    {
        public IActionResult Index() => View();
    }
    #endregion
}
