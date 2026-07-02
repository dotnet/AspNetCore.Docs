using Microsoft.AspNetCore.Authentication;
using Google.Apis.Auth.AspNetCore3;
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
            GoogleOpenIdConnectDefaults.AuthenticationScheme, "access_token");

        // ...
    }
    // </snippet_OnGetAsync>
}
