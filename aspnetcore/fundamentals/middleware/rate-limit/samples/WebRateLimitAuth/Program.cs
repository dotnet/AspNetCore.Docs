#define ADMIN // FIRST ADMIN
#if NEVER
#elif FIRST
// <snippet_1>
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading.RateLimiting;
using WebRateLimitAuth.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// <snippet>
app.UseAuthentication();
app.UseAuthorization();

var userPolicyName = "user";

var options = new RateLimiterOptions()
    .AddPolicy<string>(userPolicyName, context =>
    {
        if (!context.User?.Identity?.IsAuthenticated ?? false)
        {
            var username = "anonymous user";

            return RateLimitPartition.CreateSlidingWindowLimiter<string>(username,
                  key => new SlidingWindowRateLimiterOptions(
                  permitLimit: 2,
                  queueProcessingOrder: QueueProcessingOrder.OldestFirst,
                  queueLimit: 0,
                  window: TimeSpan.FromSeconds(30),
                  segmentsPerWindow: 1
                ));
        }
        else
        {
            return RateLimitPartition.CreateNoLimiter<string>(string.Empty);
        }
    });

options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, IPAddress>(context =>
{
    IPAddress? remoteIPaddress = context?.Connection?.RemoteIpAddress;

    if (!IPAddress.IsLoopback(remoteIPaddress!))
    {
        return RateLimitPartition.CreateTokenBucketLimiter<IPAddress>
           (remoteIPaddress!, key =>
                 new TokenBucketRateLimiterOptions(tokenLimit: 5,
                     queueProcessingOrder: QueueProcessingOrder.OldestFirst,
                     queueLimit: 1, replenishmentPeriod: TimeSpan.FromSeconds(5),
                     tokensPerPeriod: 1, autoReplenishment: true));
    }
    else
    {
        return RateLimitPartition.CreateNoLimiter<IPAddress>(IPAddress.Loopback);
    }
});

app.UseRateLimiter(options);

app.MapRazorPages().RequireRateLimiting(userPolicyName);

static string GetUserEndPoint(HttpContext context) =>
    $"Hello {context.User?.Identity?.Name ?? "Anonymous"}  {context.Request.Path}";

app.MapGet("/a", (HttpContext context) => $"{GetUserEndPoint(context)}")
    .RequireRateLimiting(userPolicyName);

app.MapGet("/b", (HttpContext context) => $"{GetUserEndPoint(context)}")
    .RequireRateLimiting(userPolicyName);

app.MapGet("/c", (HttpContext context) => $"{GetUserEndPoint(context)}");

app.Run();
// </snippet>
// </snippet_1>
#elif ADMIN
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using System.Threading.RateLimiting;
using WebRateLimitAuth.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(o => o.AddPolicy("AdminsOnly",
                                  b => b.RequireClaim("admin", "true")));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => 
                  options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// <snippet_adm>
app.UseAuthentication();
app.UseAuthorization();

var getPolicyName = "get";
var adminPolicyName = "admin";
var postPolicyName = "post";

app.UseRateLimiter(new RateLimiterOptions()
    .AddConcurrencyLimiter(policyName: getPolicyName,
          new ConcurrencyLimiterOptions(permitLimit: 2,
          queueProcessingOrder: QueueProcessingOrder.OldestFirst, queueLimit: 2))
    .AddNoLimiter(policyName: adminPolicyName)
    .AddPolicy(policyName: postPolicyName, partitioner: httpContext =>
    {
        var myToken = httpContext.Request.Headers["my-token"].ToString();
        if (!StringValues.IsNullOrEmpty(myToken))
        {
            return RateLimitPartition.CreateTokenBucketLimiter( myToken, key =>
                new TokenBucketRateLimiterOptions(tokenLimit: 5,
                    queueProcessingOrder: QueueProcessingOrder.OldestFirst,
                    queueLimit: 1, replenishmentPeriod: TimeSpan.FromSeconds(5),
                    tokensPerPeriod: 1, autoReplenishment: true));
        }
        else
        {
            return RateLimitPartition.CreateNoLimiter<string>(string.Empty);
        }
    }));

static string GetUserEndPointMethod(HttpContext context) =>
    $"Hello {context.User?.Identity?.Name ?? "Anonymous"} " +
    $"Endpoint:{context.Request.Path} Method: {context.Request.Method}";


app.MapGet("/test", (HttpContext context) => $"{GetUserEndPointMethod(context)}")
                                        .RequireRateLimiting(getPolicyName);

app.MapGet("/admin", context => context.Response.WriteAsync("/admin"))
                          .RequireRateLimiting(adminPolicyName)
                          .RequireAuthorization("AdminsOnly");

app.MapPost("/post", () => Results.Ok("/post"))
                           .RequireRateLimiting(postPolicyName);

app.MapRazorPages().RequireRateLimiting(getPolicyName)
                   .RequireRateLimiting(postPolicyName);

app.Run();
// </snippet_adm>
#endif
