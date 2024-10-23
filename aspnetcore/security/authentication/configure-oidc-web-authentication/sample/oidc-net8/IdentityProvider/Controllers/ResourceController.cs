using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Validation.AspNetCore;
using OpeniddictServer.Data;

namespace OpeniddictServer.Controllers;

[Route("api")]
public class ResourceController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;

    public ResourceController(UserManager<ApplicationUser> userManager)
        => _userManager = userManager;

    [Authorize(AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme)]
    [HttpGet("message")]
    public async Task<IActionResult> GetMessage()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return BadRequest();
        }

        return Content($"{user.UserName} has been successfully authenticated.");
    }
}
