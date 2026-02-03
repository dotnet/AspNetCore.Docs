#region snippet
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthScheme.Controllers;
[Authorize(Policy = "Over18")]
public class RegistrationController : Controller
{
    // Do Registration
    #endregion
    public IActionResult Index()
    {
        return View();
    }
}

