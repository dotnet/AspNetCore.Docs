using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using JSON.Data;
using JSON.Models;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ForecastsDatabase")));

/*
 *  builder.Services.Configure<JsonOptions>(options =>
 *  {
 *     options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
 *     options.SerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
 *     options.SerializerOptions.WriteIndented = true;
 *  });
*/

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.SerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
    options.SerializerOptions.WriteIndented = true;
});

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

// https://localhost:44315/weatherforecast/10/1
app.MapGet("/weatherforecast/{pageIndex:int}/{pageSize:int}", async (int pageIndex, int pageSize , HttpContext context, AppDbContext db) =>
{
    var forecasts = await db.Forecasts.Skip(pageIndex).Take(pageSize).ToListAsync();
    await context.Response.WriteAsJsonAsync<IEnumerable<WeatherForecast>>(forecasts);
});

// https://localhost:44315/weatherforecast/2022-01-01
app.MapGet("/weatherforecast/{date:datetime}", async (DateTime date, AppDbContext db) =>
{
    var forecast = await db.Forecasts.SingleOrDefaultAsync(f => f.Date.Equals(date));
    return TypedResults.Json(forecast);
});

// https://localhost:44315/weatherforecast/2022-01-01/2022-12-31
app.MapGet("/weatherforecast/{from:datetime}/{to:datetime}", async (DateTime from, DateTime to, HttpContext context, AppDbContext db) =>
{
    var forecasts = await db.Forecasts.Where(f => f.Date >= from && f.Date <= to)
        .Select(f => new WeatherForecastModel
        {
            Date = f.Date,
            Summary = f.Summary,
            Temperatures = new Dictionary<string, double>
            {
                {"TemperatureC", f.TemperatureC},
                {"TemperatureF", f.TemperatureC * 9 / 5 + 32}
            }
        }).ToListAsync();
    
    await context.Response.WriteAsJsonAsync<IEnumerable<WeatherForecastModel>>(forecasts, new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DictionaryKeyPolicy = JsonNamingPolicy.KebabCaseLower
    });
});

/*
 * https://localhost:44315/weatherforecast
 * Header: application/json
 * Upload: forecast_1_1_1990_1_1_2023.json
 */
app.MapPost("/weatherforecast", async (HttpContext context, AppDbContext db) =>
{
    if (!context.Request.HasJsonContentType()) return Results.BadRequest();
    var forecasts = await context.Request.ReadFromJsonAsync<IEnumerable<WeatherForecast>>();
    if (forecasts != null) await db.Forecasts.AddRangeAsync(forecasts);
    return await db.SaveChangesAsync() > 0 ? Results.Ok() : Results.BadRequest();
});

/*
 * https://localhost:44315/weatherforecast/11759
 * {
 *	"id": 11759,
 *  "date": "2022-03-12T00:00:00",
 *  "temperatureC": 45,
 *  "summary": "Scorching"
 * }
 */
app.MapPut("/weatherforecast/{id:int}", async (int id, HttpContext context, AppDbContext db) =>
{
    try
    {
        if (!context.Request.HasJsonContentType()) return Results.BadRequest();

        var forecast = await context.Request.ReadFromJsonAsync<WeatherForecast>(new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            NumberHandling = JsonNumberHandling.Strict
        });

        var forecastInDb = await db.Forecasts.FindAsync(id);

        if (forecastInDb != null)
        {
            forecastInDb.Date = forecast.Date;
            forecastInDb.TemperatureC = forecast.TemperatureC;
            forecastInDb.Summary = forecast.Summary;

            db.Forecasts.Update(forecastInDb);
        }

        return await db.SaveChangesAsync() > 0 ? Results.Ok() : Results.BadRequest();
    }
    catch (JsonException ex)
    {
        return Results.Problem(ex.Message);
    }
});

/* https://localhost:44315/weatherforecast/formatter?units=kelvin,fahrenheit
 * [
 *	{
 *		"date": "2022-03-12T00:00:00",
 *		"temperatureC": 40,
 *		"summary": "Scorching"
 *	},
 *	{
 *		"date": "2022-03-13T00:00:00",
 *		"temperatureC": -20,
 *		"summary": "Chilling"
 *	}
 * ]
 */
app.MapPost("/weatherforecast/formatter", async (HttpContext context) =>
{
    if (!context.Request.HasJsonContentType()) return Results.BadRequest();
    var forecasts = await context.Request.ReadFromJsonAsync<JsonArray>();

    string units = context.Request.Query["units"];

    var response = new JsonArray();
    
    foreach (var jsonNode in forecasts)
    {
        DateTime date = (DateTime)jsonNode["date"];
        string summary = (string)jsonNode["summary"];
        float temperatureC = (float)jsonNode["temperatureC"];
        
        var jsonObject = new JsonObject
        {
            ["date"] = date.ToString("yyyy-MM-dd"),
            ["summary"] = summary,
            ["temperatures"] = new JsonObject
            {
                ["celsius"] = double.Round(temperatureC,2)
            }
        };

        if (units.Contains("kelvin"))
            jsonObject["temperatures"]["kelvin"] = double.Round(temperatureC + 273.15, 2);
        if(units.Contains("fahrenheit"))
            jsonObject["temperatures"]["fahrenheit"] = double.Round(temperatureC * 9 / 5 + 32, 2);
        
        response.Add(jsonObject);
    }
    
    return Results.Json(response);
});

app.Run();
