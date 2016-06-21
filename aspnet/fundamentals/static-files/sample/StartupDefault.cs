//#define StartupDefault
#if StartupDefault
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace empty
{
    public class StartupEmpty
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app)
        {
            // Serve my app-specific default file, if present.
            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("mydefault.html");
            app.UseDefaultFiles(options);
            app.UseStaticFiles();
        }
    }
}

#endif