using System.Globalization;

namespace BindTryParseMVC;

public static class LDR
{
    // <snippet_1>
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
// </snippet_1>
