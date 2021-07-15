using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAAD6.Areas.Identity.Pages.Account
{
    public class SignOutModel : PageModel
    {
        public void OnGet()
        {
        }
        #region snippet
        public void OnPost()
        {
            // SignOut is done in this order to ensure local log out
            // even if the remote logout fails.
            SignOut(AzureADDefaults.CookieScheme, AzureADDefaults.OpenIdScheme);
        }
        #endregion
    }
}
