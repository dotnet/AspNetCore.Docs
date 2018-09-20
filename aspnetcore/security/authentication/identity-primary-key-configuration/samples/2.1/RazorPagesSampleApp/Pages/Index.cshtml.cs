using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesSampleApp.Data;

namespace RazorPagesSampleApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<Guid> OnGetCurrentUserId()
        {
            ApplicationUser user =
                await _userManager.GetUserAsync(HttpContext.User);

            // Casting is unnecessary, since user.Id is already a Guid.
            return user.Id;
        }

        public void OnGet()
        {
        }
    }
}
