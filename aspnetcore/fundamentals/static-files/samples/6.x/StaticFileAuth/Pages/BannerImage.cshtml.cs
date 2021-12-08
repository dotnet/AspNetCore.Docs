using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StaticFileAuth.Pages
{
    #region snippet
    [Authorize]
    public class BannerImageModel : PageModel
    {
        private readonly IWebHostEnvironment _env;

        public BannerImageModel(IWebHostEnvironment env) =>
            _env = env;

        public PhysicalFileResult OnGet()
        {
            var filePath = Path.Combine(
                    _env.ContentRootPath, "MyStaticFiles", "images", "red-rose.jpg");

            return PhysicalFile(filePath, "image/jpeg");
        }
    }
    #endregion
}
