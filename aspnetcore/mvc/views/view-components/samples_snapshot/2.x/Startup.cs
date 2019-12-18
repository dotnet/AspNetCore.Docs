using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace SampleApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            #region snippet_ViewLocationFormats
            services.AddMvc()
                .AddRazorOptions(options =>
                {
                    options.ViewLocationFormats.Add("/{0}.cshtml");
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            #endregion
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();
        }
    }
}
