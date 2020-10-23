using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication86.Pages
{
    public class PrivacyModel : PageModel
    {
        public void OnGet()
        {
            #region snippet
            var cookieOptions = new CookieOptions
            {
                // Set the secure flag, which Chrome's changes will require for SameSite none.
                // Note this will also require you to be running on HTTPS.
                Secure = true,

                // Set the cookie to HTTP only which is good practice unless you really do need
                // to access it client side in scripts.
                HttpOnly = true,

                // Add the SameSite attribute, this will emit the attribute with a value of none.
                // To not emit the attribute at all set
                // SameSite = (SameSiteMode)(-1)
                SameSite = SameSiteMode.None
            };

            // Add the cookie to the response cookie collection
            Response.Cookies.Append("MyCookie", "cookieValue", cookieOptions);
            #endregion
        }
    }
}
