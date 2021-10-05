#define MIN  // First  Second Third FF AAS MIN
#if First
#region snippet1
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
#endregion
#elif Second
#region snippet2
var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

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
#endregion
#elif Third
#region snippet3
var builder = WebApplication.CreateBuilder();
builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});
#endregion

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
#elif FF
#region snippet_FF
var builder = WebApplication.CreateBuilder();
builder.Host.ConfigureLogging(logging =>
{
    logging.AddFilter((provider, category, logLevel) =>
    {
        if (provider.Contains("ConsoleLoggerProvider")
            && category.Contains("Controller")
            && logLevel >= LogLevel.Information)
        {
            return true;
        }
        else if (provider.Contains("ConsoleLoggerProvider")
            && category.Contains("Microsoft")
            && logLevel >= LogLevel.Information)
        {
            return true;
        }
        else
        {
            return false;
        }
    });
});
#endregion

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
#elif AAS
#region snippet_AAS
using Microsoft.Extensions.Logging.AzureAppServices;

var builder = WebApplication.CreateBuilder();
builder.Host.ConfigureLogging(logging => logging.AddAzureWebAppDiagnostics())
                .ConfigureServices(serviceCollection => serviceCollection
                    .Configure<AzureFileLoggerOptions>(options =>
                    {
                        options.FileName = "azure-diagnostics-";
                        options.FileSizeLimit = 50 * 1024;
                        options.RetainedFileCountLimit = 5;
                    })
                    .Configure<AzureBlobLoggerOptions>(options =>
                    {
                        options.BlobName = "log.txt";
                    }));
#endregion

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
#elif MIN
#region snippet_MIN
var builder = WebApplication.CreateBuilder();
builder.Host.ConfigureLogging(logging => logging.SetMinimumLevel(LogLevel.Warning));
#endregion

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
#endif