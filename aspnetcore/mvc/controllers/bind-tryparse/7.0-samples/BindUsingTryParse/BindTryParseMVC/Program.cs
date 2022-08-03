using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

// GET /en-GB
// returns an endpoint string for /WeatherForecast/ByLocaleRange
app.MapGet("/{locale}", (string locale) => LDR.LocaleDateRange(locale, app.Logger));

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

public static class LDR
{
    public static string LocaleDateRange(string locale, ILogger logger)
    {
        DateTimeFormatInfo dtfi;

        try
        {
            dtfi = CultureInfo.CreateSpecificCulture(locale).DateTimeFormat;
        }
        catch (Exception ex)
        {
            logger.LogError("{Locale} is not a valid locale.", locale);
            logger.LogError("{Error}", ex.Message);
            dtfi = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name).DateTimeFormat;
        }
        
        var now = DateTime.Now.ToString("d", dtfi);
        var fiveDays = DateTime.Now.AddDays(5).ToString("d", dtfi);
        var dateRangeLocale = $"/{locale}/WeatherForecast/RangeByLocale?range={now},{fiveDays}";
        
        return dateRangeLocale;
    }
}
