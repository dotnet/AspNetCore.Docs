using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SocialWithoutIdentitySample.Snippets.Pages;

[Authorize]
public class PrivacyModel : PageModel
{
    // <snippet_OnGetAsync>
    public async Task OnGetAsync()
    {
        var accessToken = await HttpContext.GetTokenAsync(
            GoogleDefaults.AuthenticationScheme, "access_token");

        // ...
    }
    // </snippet_OnGetAsync>
}
