using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageOidc.Pages;

[AllowAnonymous]
public class LoginModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public string? ReturnUrl { get; set; }

    public async Task OnGetAsync()
    {
        // ReturnUrl comes from the query string, so only redirect to local URLs to prevent open redirects.
        var redirectUri = Url.IsLocalUrl(ReturnUrl) ? Url.Content(ReturnUrl) : Url.Content("~/");
        await HttpContext.ChallengeAsync(new AuthenticationProperties { RedirectUri = redirectUri });
    }
}
