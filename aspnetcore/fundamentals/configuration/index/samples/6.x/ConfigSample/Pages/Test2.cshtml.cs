using ConfigSample.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace ConfigSample.Pages
{
    #region snippet
    public class Test2Model : PageModel
    {
        private readonly PositionOptions _options;

        public Test2Model(IOptions<PositionOptions> options)
        {
            _options = options.Value;
        }

        public ContentResult OnGet()
        {
            return Content($"Title: {_options.Title} \n" +
                           $"Name: {_options.Name}");
        }
    }
    #endregion
}
