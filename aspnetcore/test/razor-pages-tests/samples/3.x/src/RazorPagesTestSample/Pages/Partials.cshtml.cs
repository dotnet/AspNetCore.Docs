using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesTestSample.Pages
{
    public class PartialsModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnGetPartial() => Partial("_Partial");
    }
}
