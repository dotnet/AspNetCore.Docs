#define AzureRedis
using Microsoft.Extensions.Caching.Distributed;

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
#if AzureRedis
    #region snippet_AddStackExchangeRedisCache_AzureRedis
    builder.Services.AddStackExchangeRedisCache(options =>
    {
        options.Configuration = builder.Configuration.GetConnectionString("MyAzureRedisConStr");
        options.InstanceName = "SampleInstance";
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
    app.Services.GetService<IDistributedCache>()?.Set("cachedTimeUTC", encodedCurrentTimeUTC, options);
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
