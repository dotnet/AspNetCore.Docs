// To configure the app to use a distributed Redis cache,
// change the preprocessor directive to 'Redis'.
// For more information, see: 
// https://docs.microsoft.com/aspnet/core/introduction-to-aspnet-core#preprocessor-directives-in-sample-code
#define  SQLServer // Redis

using System;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SampleApp
{
    public class Startup
    {
        private readonly IConfiguration _config;
        private readonly IHostingEnvironment _hostContext;

        public Startup(IConfiguration config, IHostingEnvironment hostContext)
        {
            _config = config;
            _hostContext = hostContext;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            if (_hostContext.IsDevelopment())
            {
                #region snippet_AddDistributedMemoryCache
                services.AddDistributedMemoryCache();
                #endregion
            }
            else
            {
#if SQLServer
                #region snippet_AddDistributedSqlServerCache
                services.AddDistributedSqlServerCache(options =>
                {
                    options.ConnectionString = 
                        _config["DistCache_ConnectionString"];
                    options.SchemaName = "dbo";
                    options.TableName = "TestCache";
                });
                #endregion
#else
                #region snippet_AddStackExchangeRedisCache
                services.AddStackExchangeRedisCache(options =>
                {
                    options.Configuration = "localhost";
                    options.InstanceName = "SampleInstance";
                });
                #endregion
#endif
            }

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        #region snippet_Configure
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
            IApplicationLifetime lifetime, IDistributedCache cache)
        {
            lifetime.ApplicationStarted.Register(() =>
            {
                var currentTimeUTC = DateTime.UtcNow.ToString();
                byte[] encodedCurrentTimeUTC = Encoding.UTF8.GetBytes(currentTimeUTC);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(20));
                cache.Set("cachedTimeUTC", encodedCurrentTimeUTC, options);
            });
        #endregion

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
