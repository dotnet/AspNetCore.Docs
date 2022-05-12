#define FIRST // FIRST REQ
#if NEVER
#elif FIRST
#region snippet
public class WeatherForecast<T>
{
    public string TestRequired { get; set; } = null!;
    public T? Inner { get; set; }
}
#endregion
#elif REQ
#region snippet2
using System.ComponentModel.DataAnnotations;

public class WeatherForecast<T>
{
    [Required]
    public string TestRequired { get; set; } = null!;
    public T? Inner { get; set; }
}
#endregion
#endif