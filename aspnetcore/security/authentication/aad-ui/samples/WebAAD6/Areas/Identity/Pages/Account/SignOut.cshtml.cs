using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAAD6.Areas.Identity.Pages.Account
{
    public class SignOutModel : PageModel
    {
        public void OnGet()
        {
        }

        public void OnPost()
        {
            // SignOut is done in this order to ensue that we log out locally
            // even if the remote logout fails.
            SignOut(AzureADDefaults.CookieScheme, AzureADDefaults.OpenIdScheme);
        }
    }
}
