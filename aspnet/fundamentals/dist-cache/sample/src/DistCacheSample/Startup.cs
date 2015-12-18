using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Redis;
using Microsoft.Extensions.Caching.SqlServer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.OptionsModel;
using System;
using System.Text;

namespace DistCacheSample
{
    public class Startup
    {
        /// <summary>
        /// Use LocalCache (Memory) in Development
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            services.AddSingleton<IMemoryCache>(serviceProvider =>  new MemoryCache(new MemoryCacheOptions()));
            services.AddSingleton<IDistributedCache, LocalCache>();
        }

        /// <summary>
        /// Use Redis Cache in Staging
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureStagingServices(IServiceCollection services)
        {
            // use Redis
            services.AddSingleton<IDistributedCache>(serviceProvider => 
                new RedisCache(new RedisCacheOptions
                {
                    Configuration = "localhost",
                    InstanceName = "SampleInstance"
                }));
        }

        /// <summary>
        /// Use SQL Server Cache in Production
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureProductionServices(IServiceCollection services)
        {
            // Use SQL Server
            services.AddSingleton<IDistributedCache>(serviceProvider =>
            new SqlServerCache(new CacheOptions(new SqlServerCacheOptions()
            {
                ConnectionString = @"Data Source=(localdb)\v11.0;Initial Catalog=DistCache;Integrated Security=True;",
                SchemaName = "dbo",
                TableName = "TestCache"
            })));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseIISPlatformHandler();

            var serverStartTimeString = DateTime.Now.ToString();
            byte[] val = Encoding.UTF8.GetBytes(serverStartTimeString);

            var cache = app.ApplicationServices.GetService(typeof(IDistributedCache)) as IDistributedCache;
            cache.Set("serverStartTime", val);


            app.UseStartTimeFooter();

            app.Use(next => async context =>
            {
                await next.Invoke(context);
            });

            app.Run(async (context) =>
            {
                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync("Hello World! The current time is " + DateTime.Now.ToString());
            });
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }

    public  class CacheOptions : IOptions<SqlServerCacheOptions>
    {
        private readonly SqlServerCacheOptions _innerOptions;

        public CacheOptions(SqlServerCacheOptions innerOptions)
        {
            _innerOptions = innerOptions;
        }

        public SqlServerCacheOptions Value
        {
            get
            {
                return _innerOptions;
            }
        }
    }
}
