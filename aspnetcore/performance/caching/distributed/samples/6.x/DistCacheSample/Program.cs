#define SQLServer //NCache, // Redis
using Alachisoft.NCache.Caching.Distributed;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.SqlServer;
using Microsoft.Extensions.Caching.StackExchangeRedis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

if (builder.Environment.IsDevelopment())
{
    #region snippet_AddDistributedMemoryCache
    builder.Services.AddDistributedMemoryCache();
    #endregion
}
else
{
#if SQLServer
    #region snippet_AddDistributedSqlServerCache
    builder.Services.AddDistributedSqlServerCache(options =>
    {
        options.ConnectionString = builder.Configuration.GetConnectionString(
            "DistCache_ConnectionString");
        options.SchemaName = "dbo";
        options.TableName = "TestCache";
    });
    #endregion

#elif Redis
    #region snippet_AddStackExchangeRedisCache
    builder.Services.AddStackExchangeRedisCache(options =>
     {
         options.Configuration = builder.Configuration.GetConnectionString("MyRedisConStr");
         options.InstanceName = "SampleInstance";
     });
    #endregion
#else
    #region snippet_AddNCache_Cache
    builder.Services.AddNCacheDistributedCache(configuration =>
    {
        configuration.CacheName = "democache";
        configuration.EnableLogs = true;
        configuration.ExceptionsEnabled = true;
    });
    #endregion
#endif
}

var app = builder.Build();

#region snippet_Configure
app.Lifetime.ApplicationStarted.Register(() =>
{
    var currentTimeUTC = DateTime.UtcNow.ToString();
    byte[] encodedCurrentTimeUTC = System.Text.Encoding.UTF8.GetBytes(currentTimeUTC);
    var options = new DistributedCacheEntryOptions()
        .SetSlidingExpiration(TimeSpan.FromSeconds(20));
    app.Services.GetService<IDistributedCache>()
                              .Set("cachedTimeUTC", encodedCurrentTimeUTC, options);
});
#endregion

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
