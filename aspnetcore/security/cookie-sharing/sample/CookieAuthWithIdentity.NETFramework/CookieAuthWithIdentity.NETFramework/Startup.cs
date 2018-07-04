using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CookieAuthWithIdentity.NETFramework.Startup))]
namespace CookieAuthWithIdentity.NETFramework
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
