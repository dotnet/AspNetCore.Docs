[assembly: HostingStartup(typeof(OpeniddictServer.Areas.Identity.IdentityHostingStartup))]
namespace OpeniddictServer.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}
