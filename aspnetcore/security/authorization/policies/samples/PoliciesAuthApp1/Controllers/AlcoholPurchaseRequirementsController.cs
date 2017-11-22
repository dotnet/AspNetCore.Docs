namespace PoliciesAuthApp1.Controllers
{
    #region snippet_AlcoholPurchaseRequirementsControllerClass
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Policy = "AtLeast21")]
    public class AlcoholPurchaseRequirementsController : Controller
    {
        public IActionResult Login() => View();

        public IActionResult Logout() => View();
    }
    #endregion
}