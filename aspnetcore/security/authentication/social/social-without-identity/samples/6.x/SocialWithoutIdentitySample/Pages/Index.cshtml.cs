using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SocialWithoutIdentitySample.Pages;

// <snippet_Class>
public class IndexModel : PageModel
{
    public async Task<IActionResult> OnPostLogoutAsync()
    {
        // using Microsoft.AspNetCore.Authentication;
        await HttpContext.SignOutAsync();
        return RedirectToPage();
    }
}
// </snippet_Class>
