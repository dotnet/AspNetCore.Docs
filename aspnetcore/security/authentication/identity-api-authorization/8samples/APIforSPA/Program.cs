
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace APIforSPA;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        // <snippetActivateAPIs>
        builder.Services.AddIdentityApiEndpoints<IdentityUser>()
            .AddEntityFrameworkStores<ApplicationDbContext>();
        // </snippetActivateAPIs>
        // <snippetAppDbContext>
        builder.Services.AddDbContext<ApplicationDbContext>(
            options => options.UseInMemoryDatabase("AppDb"));
        // </snippetAppDbContext>
        // <snippetAddAuthentication>
        builder.Services.AddAuthorization();
        // </snippetAddAuthentication>
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // <snippetMapEndpoints>
        app.MapIdentityApi<IdentityUser>();
        // </snippetMapEndpoints>
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

        // <snippetRequireAuthorization>
        app.MapGet("/weatherforecast", (HttpContext httpContext) =>
        {
            var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = summaries[Random.Shared.Next(summaries.Length)]
                })
                .ToArray();
            return forecast;
        })
        .WithName("GetWeatherForecast")
        .WithOpenApi()
        .RequireAuthorization();
        // <snippetRequireAuthorization>
        
        app.Run();
    }
}
