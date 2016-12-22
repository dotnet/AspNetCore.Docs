[assembly: OwinStartup(typeof(ResourceServer.Startup))]

namespace ResourceServer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            ConfigureWebApi(app);
        }
    }
}