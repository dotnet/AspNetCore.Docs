namespace JSON.Models;

public class WeatherForecast {
    public int  Id { get; set; }
    public DateTime Date { get; set; }
    public double TemperatureC { get; set; }
    public string? Summary { get; set; }
}

public class WeatherForecastModel
{
        
    public DateTime Date { get; set; }
    public string? Summary { get; set; }
    public IDictionary<string, double>? Temperatures { get; set; }
}
