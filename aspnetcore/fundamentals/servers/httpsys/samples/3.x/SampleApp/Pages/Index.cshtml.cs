using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HttpSysSample.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IServerAddressesFeature _serverAddressesFeature;
        public IndexModel(IServer server)
        {
            _serverAddressesFeature = server.Features.Get<IServerAddressesFeature>();
        }

        public string ServerAddresses { get; set; }
        public void OnGet()
        {
            ServerAddresses = string.Join(", ", _serverAddressesFeature?.Addresses);
        }
    }
}
