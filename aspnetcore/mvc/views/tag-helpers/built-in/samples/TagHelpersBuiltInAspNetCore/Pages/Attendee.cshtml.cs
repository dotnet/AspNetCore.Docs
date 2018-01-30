using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TagHelpersBuiltInAspNetCore.Pages
{
    public class AttendeeModel : PageModel
    {
        public void OnGet(int attendeeId)
        {
            ViewData["AttendeeId"] = attendeeId;
        }
    }
}