using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CookieAuthWithIdentity.Startup))]
namespace CookieAuthWithIdentity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
