using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HtmlHelpers.Startup))]
namespace HtmlHelpers
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
