// Use this startup in Program.cs to use a distributed Redis cache,
// For more information, see: 
// https://docs.microsoft.com/aspnet/core/introduction-to-aspnet-core#preprocessor-directives-in-sample-code

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Text;

namespace SampleApp
{
    public class StartupRedis
    {
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _hostContext;

        public StartupRedis(IConfiguration config, IWebHostEnvironment hostContext)
        {
            _config = config;
            _hostContext = hostContext;
        }

        #region snippet_AddStackExchangeRedisCache
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
                services.AddStackExchangeRedisCache(options =>
                {
                    options.Configuration = _config["MyRedisConStr"];
                    options.InstanceName = "SampleInstance";
                });
            }

            services.AddRazorPages();
        }
        #endregion

        #region snippet_Configure
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            IHostApplicationLifetime lifetime, IDistributedCache cache)
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
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
