using JSON.Data;
using JSON.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ForecastsDatabase")));

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/weatherforecast/{from}/{to}", async (DateTime from, DateTime to, HttpContext context, AppDbContext db) =>
    {
        var forecasts = await db.Forecasts.Where(f => f.Date >= from && f.Date <= to).ToListAsync();
        await context.Response.WriteAsJsonAsync<IEnumerable<WeatherForecast>>(forecasts);
    });
    
    endpoints.MapPost("/weatherforecast", async (HttpContext context, AppDbContext db) =>
    {
        if (!context.Request.HasJsonContentType()) return Results.BadRequest();
        var forecasts = await context.Request.ReadFromJsonAsync<IEnumerable<WeatherForecast>>();
        await db.Forecasts.AddRangeAsync(forecasts);
        return await db.SaveChangesAsync() > 0 ? Results.Ok() : Results.BadRequest();
    });

    endpoints.MapControllers();
});

app.Run();