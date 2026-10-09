
using Microsoft.AspNetCore.Http;

namespace HttpResultInterfaces;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        // <snippet_filter>
        app.MapGet("/weatherforecast", (int days) =>
        {
            if (days <= 0)
            {
                return Results.BadRequest();
            }

            var forecast = Enumerable.Range(1, days).Select(index =>
               new WeatherForecast(DateTime.Now.AddDays(index), Random.Shared.Next(-20, 55), "Cool"))
                .ToArray();
            return Results.Ok(forecast);
        }).
        AddEndpointFilter(async (context, next) =>
        {
            var result = await next(context);

            return result switch
            {
                IValueHttpResult<WeatherForecast[]> weatherForecastResult => new WeatherHttpResult(weatherForecastResult.Value),
                _ => result
            };
        });
        // </snippet_filter>
        app.Run();
    }
}

internal class WeatherHttpResult : IResult
{
    private WeatherForecast[]? value;

    public WeatherHttpResult(WeatherForecast[]? value)
    {
        this.value = value;
    }

    public Task ExecuteAsync(HttpContext httpContext)
    {
        ArgumentNullException.ThrowIfNull(httpContext);

        httpContext.Response.StatusCode = 200;

        return httpContext.Response.WriteAsJsonAsync<WeatherForecast[]?>(this.value);
    }
}

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary);

