using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using SampleApp.Models;

namespace SampleApp.Pages
{
    #region snippet
    public class Test11Model : PageModel
    {
        private readonly IConfiguration Configuration;

        public Test11Model(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public ContentResult OnGet()
        {
            var myOpts = new MyOptions();
            Configuration.GetSection("MyOptions").Bind(myOpts);

            return Content($"Option1: {myOpts.Option1} \n" +
                           $"Option2: {myOpts.Option2}");
        }
    }
    #endregion
}