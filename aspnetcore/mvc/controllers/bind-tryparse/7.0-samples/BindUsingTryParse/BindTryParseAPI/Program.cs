using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

app.UseAuthorization();

app.MapControllers(); 

app.MapGet("/{culture}", (string culture) => DRC.DateRangeCulture(culture, app.Logger));

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
        var dateRangeCulture = $"/WeatherForecast/ByCulturalRange?culture={culture}&range={now},{fiveDays}";

        return dateRangeCulture;
    }
}
