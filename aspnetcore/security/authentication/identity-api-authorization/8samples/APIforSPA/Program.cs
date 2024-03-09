#define Version1 // Version1 / Version2 / Version3 / Version4
// Version2 = require email confirmation
// Version3 = require admin role
// Version4 = require authorization for Swagger
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
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

        // <snippetAddAuthorization>
        builder.Services.AddAuthorization();
        // </snippetAddAuthorization>

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

#if Version2
        // <snippetConfigureEmail>
        builder.Services.Configure<IdentityOptions>(options =>
        {
            options.SignIn.RequireConfirmedEmail = true;
        });

        builder.Services.AddTransient<IEmailSender, EmailSender>();
        // </snippetConfigureEmail>
#endif

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

#if Version1 || Version2 || Version4
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
        // </snippetRequireAuthorization>
#endif
#if Version3
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
        // <snippetRequireAdmin>
        .RequireAuthorization("Admin");
        // </snippetRequireAdmin>
#endif

#if Version4
        // <snippetSwaggerAuth>
        app.MapSwagger().RequireAuthorization();
        // </snippetSwaggerAuth>
#endif

        // <snippetLogout>
        app.MapPost("/logout", async (SignInManager<IdentityUser> signInManager,
            [FromBody] object empty) =>
        {
            if (empty != null)
            {
                await signInManager.SignOutAsync();
                return Results.Ok();
            }
            return Results.Unauthorized();
        })
        .WithOpenApi()
        .RequireAuthorization();
        // </snippetLogout>

        app.Run();
    }
}
