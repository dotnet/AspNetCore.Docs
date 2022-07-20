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
            logger.LogError($"{culture} is not a valid culture.");
            logger.LogError(ex.Message);
            dtfi = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name).DateTimeFormat;
        }
        var now = DateTime.Now.ToString("d", dtfi);
        var fiveDays = DateTime.Now.AddDays(5).ToString("d", dtfi);
        var dateRangeCulture = $"/WeatherForecast/RangeWithCulture?range={now}" +
                                $"-{fiveDays}" +
                                $"&culture={culture}";
        return dateRangeCulture;
    }
}
