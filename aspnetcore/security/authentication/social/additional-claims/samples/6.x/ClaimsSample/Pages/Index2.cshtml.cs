using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebGoogOauth.Pages
{
    public class Index2Model : PageModel
    {
        private readonly ILogger<Index2Model> _logger;

        public Index2Model(ILogger<Index2Model> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}