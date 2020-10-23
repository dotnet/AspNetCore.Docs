using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace WebAPI
{
    public class HostPageModel : PageModel
    {
        public string Host { get; set; }

        public void SetHost(IConfiguration configuration, bool changeOrder=false)
        {
            var h1 = "host1";
            var h3 = "host3";
            if (changeOrder == true)
            {
                h1 = "host3";
                h3 = "host1";
            }
            Host = configuration[h1];
            var theHost = HttpContext.Request.Host.Value;
            if (Host.Contains(theHost))
            {
                Host = configuration[h3];
            }
        }
    }
}
