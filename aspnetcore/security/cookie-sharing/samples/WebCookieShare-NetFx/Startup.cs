using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebCookieShare_NetFx.Startup))]
namespace WebCookieShare_NetFx
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
