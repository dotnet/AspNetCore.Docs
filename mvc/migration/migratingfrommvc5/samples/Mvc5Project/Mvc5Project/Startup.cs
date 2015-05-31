using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mvc5Project.Startup))]
namespace Mvc5Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
