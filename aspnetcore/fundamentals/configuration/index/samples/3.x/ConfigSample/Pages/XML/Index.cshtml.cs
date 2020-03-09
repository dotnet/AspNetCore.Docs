using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace ConfigSample.Pages.JSON
{
    #region snippet
    public class IndexModel : PageModel
    {
        private readonly IConfiguration Configuration;

        public IndexModel(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public ContentResult OnGet()
        {
            var key00 = "section:section0:key:key0";
            var key01 = "section:section0:key:key1";
            var key10 = "section:section1:key:key0";
            var key11 = "section:section1:key:key1";

            var ss0kk0 = Configuration[key00];
            var ss0kk1 = Configuration[key01];
            var ss1kk0 = Configuration[key10];
            var ss1kk1 = Configuration[key11];

            return Content($"{key00} value: {ss0kk0} \n" +
                           $"{key01} value: {ss0kk1} \n" +
                           $"{key10} value: {ss1kk0} \n" +
                           $"{key10} value: {ss1kk1} \n"
                           );
        }
    }
    #endregion
}
