using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

// GET /en-GB
// returns an endpoint string for /WeatherForecast/RangeWithCulture
app.MapGet("/{culture}", (string culture) => DRC.DateRangeCulture(culture, app.Logger));

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
    name: "culture",
    pattern: "{culture=en-US}/{controller=WeatherForecast}/{action=Index}/{id?}");

app.Run();

public static class DRC
{
    public static string DateRangeCulture(string culture, ILogger logger)
    {
        DateTimeFormatInfo dtfi;

        try
        {
            dtfi = CultureInfo.CreateSpecificCulture(culture).DateTimeFormat;
        }
        catch (Exception ex)
        {
            logger.LogError("{Culture} is not a valid culture.", culture);
            logger.LogError("{Error}", ex.Message);
            dtfi = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name).DateTimeFormat;
        }
        
        var now = DateTime.Now.ToString("d", dtfi);
        var fiveDays = DateTime.Now.AddDays(5).ToString("d", dtfi);
        var dateRangeCulture = $"/{culture}/WeatherForecast/RangeWithCulture?range={now}-{fiveDays}";
        
        return dateRangeCulture;
    }
}
