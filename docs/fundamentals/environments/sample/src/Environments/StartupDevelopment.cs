using Microsoft.AspNet.Builder;


namespace Environments
{
    public class StartupDevelopment
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseWelcomePage();
        }
    }
}
