using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClaimsSample.Pages
{
    public class IndexModel : PageModel
    {
        public Claim GivenNameClaim { get; set; }
        public Claim LocaleClaim { get; set; }
        public Claim PictureUrlClaim { get; set; }

        public void OnGet()
        {
            GivenNameClaim = HttpContext.User.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.GivenName);
            LocaleClaim = HttpContext.User.Claims
                .FirstOrDefault(c => c.Type == "urn:google:locale");
            PictureUrlClaim = HttpContext.User.Claims
                .FirstOrDefault(c => c.Type == "urn:google:picture");
        }
    }
}
