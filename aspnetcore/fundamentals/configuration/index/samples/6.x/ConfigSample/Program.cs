#define Second // CONFIG DEFAULT Second Third SWITCH
#if DEFAULT
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var app = builder.Build();

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
#elif CONFIG
#region snippet
using ConfigSample.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    var Configuration = hostingContext.Configuration;
    builder.Services.Configure<PositionOptions>(Configuration.GetSection(
                                            PositionOptions.Position));
});

var app = builder.Build();

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
#elif Second
#region snippet2
using ConfigSample.Options;
using Microsoft.Extensions.DependencyInjection.ConfigSample.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    var Configuration = hostingContext.Configuration;
    builder.Services.Configure<PositionOptions>(
            Configuration.GetSection(PositionOptions.Position));
    builder.Services.Configure<ColorOptions>(
            Configuration.GetSection(ColorOptions.Color));
});

builder.Services.AddScoped<IMyDependency, MyDependency>();
builder.Services.AddScoped<IMyDependency2, MyDependency2>();

var app = builder.Build();

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
#elif Third
#region snippet3
using Microsoft.Extensions.DependencyInjection.ConfigSample.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    var Configuration = hostingContext.Configuration;
    builder.Services.AddConfig(Configuration)
             .AddMyDependencyGroup();
});

builder.Services.AddRazorPages();

var app = builder.Build();
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
#elif ENV
#region snippet_env
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
// TO DO
// config.AddEnvironmentVariables(prefix: "MyCustomPrefix_");

var app = builder.Build();
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
#elif SWITCH
#region snippet_sw

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var switchMappings = new Dictionary<string, string>()
         {
             { "-k1", "key1" },
             { "-k2", "key2" },
             { "--alt3", "key3" },
             { "--alt4", "key4" },
             { "--alt5", "key5" },
             { "--alt6", "key6" },
         };

builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    var x = hostingContext.Configuration;
    config.AddCommandLine(args, switchMappings);
});

var app = builder.Build();

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
#endif
