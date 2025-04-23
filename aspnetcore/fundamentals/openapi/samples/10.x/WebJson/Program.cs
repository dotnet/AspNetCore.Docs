using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.Converters.Add(
        new JsonStringEnumConverter<DayOfTheWeekAsString>());
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter<DayOfTheWeekAsString>());
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/", () =>
{
    var day = DayOfTheWeekAsString.Friday;
    return Results.Json(day);
});

app.MapPost("/", (DayOfTheWeekAsString day) =>
{
    return Results.Json($"Received: {day}");
});

app.UseRouting();
app.MapControllers();

app.Run();
