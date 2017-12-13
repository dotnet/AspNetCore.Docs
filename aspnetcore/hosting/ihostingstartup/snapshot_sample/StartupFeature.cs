#region snippet1
[assembly: HostingStartup(typeof(StartupFeature.StartupFeatureHostingStartup))]
#endregion

#region snippet2
namespace StartupFeature
{
    public class StartupFeatureHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            // Use the IWebHostBuilder to add app features.
        }
    }
}
#endregion
