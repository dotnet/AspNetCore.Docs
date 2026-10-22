var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Try /weatherforecast");
// Map the /weatherforecast endpoint to a custom action.
app.MapWeatherApi();
app.Run();

public static class WeatherApi
{
    public static string[] summaries =
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

    public static WebApplication MapWeatherApi(this WebApplication routes)
    {
        routes.MapGet("/weatherforecast", GetAllWeathers);

        return routes;
    }
    public static IResult GetAllWeathers()
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
      new WeatherForecast
      (
          DateTime.Now.AddDays(index),
          Random.Shared.Next(-20, 55),
          summaries[Random.Shared.Next(summaries.Length)]
      ))
      .ToArray();
        return TypedResults.Ok(forecast); ;
    }
}

public record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
