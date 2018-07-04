using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesProject.Services;

namespace RazorPagesProject.Pages
{
    public class GithubProfileModel : PageModel
    {
        public GithubProfileModel(IGithubClient client)
        {
            Client = client;
        }

        public class InputModel
        {
            [Required]
            public string UserName { get; set; }
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IGithubClient Client { get; }

        public GithubUser GithubUser { get; private set; }

        public async Task<IActionResult> OnGetAsync([FromRoute] string userName)
        {
            if (userName != null)
            {
                GithubUser = await Client.GetUserAsync(userName);
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(Input.UserName))
            {
                return Page();
            }

            return RedirectToPage(new { Input.UserName });
        }
    }
}
