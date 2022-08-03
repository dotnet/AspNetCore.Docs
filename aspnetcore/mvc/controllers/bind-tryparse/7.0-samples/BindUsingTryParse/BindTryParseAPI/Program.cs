using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

app.UseAuthorization();

app.MapControllers(); 

app.MapGet("/{locale}", (string locale) => LDR.LocaleDateRange(locale, app.Logger));

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
        var localeDateRange = $"/{locale}/WeatherForecast/ByLocaleRange?range={now},{fiveDays}";

        return localeDateRange;
    }
}
