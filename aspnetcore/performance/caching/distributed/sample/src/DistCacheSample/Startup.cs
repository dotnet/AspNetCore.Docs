using System;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace DistCacheSample
{
    public class Startup
    {
        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
        }

        #region snippet2
        public void ConfigureStagingServices(IServiceCollection services)
        {
            services.AddDistributedRedisCache(options =>
            {
                options.Configuration = "localhost";
                options.InstanceName = "SampleInstance";
            });
        }
        #endregion

        #region snippet3
        public void ConfigureProductionServices(IServiceCollection services)
        {
            services.AddDistributedSqlServerCache(options =>
            {
                options.ConnectionString = 
                    @"Data Source=(localdb)\v11.0;Initial Catalog=DistCache;" +
                    @"Integrated Security=True;";
                options.SchemaName = "dbo";
                options.TableName = "TestCache";
            });
        }
        #endregion

        #region snippet1
        public void Configure(IApplicationBuilder app,
            IDistributedCache cache)
        {
            var serverStartTimeString = DateTime.Now.ToString();
            byte[] val = Encoding.UTF8.GetBytes(serverStartTimeString);
            var cacheEntryOptions = new DistributedCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(30));
            cache.Set("lastServerStartTime", val, cacheEntryOptions);
        #endregion

            app.UseStartTimeHeader();

            app.Run(async (context) =>
            {
                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
