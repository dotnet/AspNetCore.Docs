#region snippet1
[assembly: HostingStartup(typeof(StartupEnhancement.StartupEnhancementHostingStartup))]
#endregion

#region snippet2
namespace StartupEnhancement
{
    public class StartupEnhancementHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            // Use the IWebHostBuilder to add app enhancements.
        }
    }
}
#endregion
