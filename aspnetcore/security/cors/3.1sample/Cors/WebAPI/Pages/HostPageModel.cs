using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace WebAPI
{
    public class HostPageModel : PageModel
    {
        public string Host { get; set; }

        public void SetHost(IConfiguration configuration)
        {
            Host = configuration["host1"];
            var theHost = HttpContext.Request.Host.Value;
            if (Host.Contains(theHost))
            {
                Host = configuration["host3"];
            }
        }
    }
}
