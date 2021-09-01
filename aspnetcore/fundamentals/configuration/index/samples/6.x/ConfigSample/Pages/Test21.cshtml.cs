using ConfigSample.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace ConfigSample.Pages
{
    #region snippet
    public class Test21Model : PageModel
    {
        private readonly IConfiguration Configuration;
        public PositionOptions positionOptions { get; private set; }

        public Test21Model(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public ContentResult OnGet()
        {            
            positionOptions = Configuration.GetSection(PositionOptions.Position)
                                                         .Get<PositionOptions>();

            return Content($"Title: {positionOptions.Title} \n" +
                           $"Name: {positionOptions.Name}");
        }
    }
    #endregion
}
