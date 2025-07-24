using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HttpSysSample.Pages;

public sealed class IndexModel : PageModel
{
    private readonly IServerAddressesFeature _serverAddressesFeature;

    public IndexModel(IServer server)
    {
        _serverAddressesFeature = server.Features.GetRequiredFeature<IServerAddressesFeature>();
    }

    public string? ServerAddresses { get; set; }

    public void OnGet()
    {
        ServerAddresses = string.Join(", ", _serverAddressesFeature.Addresses);
    }
}
