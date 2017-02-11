using Microsoft.Owin;
using Owin;
using WebRole1.PersistentConnections;

// Marks this class for automatic OWIN startup
[assembly: OwinStartup(typeof(WebRole1.Startup))]
namespace WebRole1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            // Only needed if "No Authentication" was not selected for the project
            app.MapSignalR();
            app.MapSignalR<MyPersistentConnection>("/echo");
        }
    }
}
