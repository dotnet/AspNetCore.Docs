using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PageFilter.Filters;
using System.Threading.Tasks;

namespace PageFilter.Pages
{
    #region snippet1
    [AddHeader("Author", "Rick")]
    public class ContactModel : PageModel
    {
        private readonly ILogger _logger;

        public ContactModel(ILogger<ContactModel> logger)
        {
            _logger = logger;
        }
        public string Message { get; set; }

        public async Task OnGetAsync()
        {
            Message = "Your contact page.";
            _logger.LogDebug("Contact/OnGet");
            await Task.CompletedTask;
        }
    }
    #endregion
}
