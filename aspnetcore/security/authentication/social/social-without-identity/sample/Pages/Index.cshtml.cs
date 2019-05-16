using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp1.Pages
{
    public class IndexModel : PageModel
    {
        public IActionResult OnGetLogin()
        {
            return Challenge(new AuthenticationProperties
            {
                RedirectUri = Url.Page("/Index")
            });
        }

        public async Task<IActionResult> OnPostLogoutAsync()
        {
            await HttpContext.SignOutAsync();
            return RedirectToPage();
        }
    }
}
