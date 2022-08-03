using System.Globalization;
using BindTryParseMVC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

// GET /en-GB
// returns an endpoint string for /WeatherForecast/ByLocaleRange
app.MapGet("/{locale}", (string locale) => LDR.LocaleDateRange(locale, app.Logger));

// GET /culture/en-GB
// /en-GB/WeatherForecast/RangeByLocale?range=01/08/2022,06/08/2022
app.MapGet("/culture/{cultureID}", (string cultureID) =>
{
    var cultureRange = $"/{cultureID}/WeatherForecast/RangeByLocale?range=" +
                      $"{DateTime.Now.ToString("d", new CultureInfo(cultureID))}" +
                      $",{DateTime.Now.AddDays(5).ToString("d", new CultureInfo(cultureID))}";
    return cultureRange;
});

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=WeatherForecast}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "locale",
    pattern: "{locale=en-US}/{controller=WeatherForecast}/{action=Index}/{id?}");

app.Run();

