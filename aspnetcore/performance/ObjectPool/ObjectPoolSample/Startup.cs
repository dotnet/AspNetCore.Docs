using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.ObjectPool;

namespace ObjectPoolSample
{
    #region snippet
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.TryAddSingleton<ObjectPoolProvider, DefaultObjectPoolProvider>();

            services.TryAddSingleton<ObjectPool<StringBuilder>>(serviceProvider =>
            {
                var provider = serviceProvider.GetRequiredService<ObjectPoolProvider>();
                var policy = new StringBuilderPooledObjectPolicy();
                return provider.Create(policy);
            });

            services.AddWebEncoders();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            // Test using /?firstname=Steve&lastName=Gordon&day=28&month=9
            app.UseMiddleware<BirthdayMiddleware>(); 
        }
    }
    #endregion
}
