using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace PageFilter.Pages
{
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

        public override async Task OnPageHandlerSelectionAsync(
            PageHandlerSelectedContext context)
        {
            _logger.LogDebug("ContactModel/OnPageHandlerSelectionAsync called.");
            await Task.CompletedTask;
        }

        public override async Task OnPageHandlerExecutionAsync(
            PageHandlerExecutingContext context,
           PageHandlerExecutionDelegate next)
        {
            _logger.LogDebug("ContactModel/OnPageHandlerExecutionAsync called.");
            await next.Invoke();
        }
    }
}
