using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TagHelpersBuiltInAspNetCore.Pages
{
    public class SpeakerModel : PageModel
    {
        public void OnGet()
        {
            ViewData["SpeakerId"] = null;
        }

        #region snippet_OnGetProfileHandler
        public void OnGetProfile(int speakerId)
        {
            ViewData["SpeakerId"] = speakerId;

            // code omitted for brevity
        }
        #endregion
    }
}