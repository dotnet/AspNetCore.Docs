using Microsoft.AspNetCore.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.Configure<JsonOptions>(options =>
{
    // Specific converter for DayOfTheWeekAsString enum
    options.SerializerOptions.Converters.Add(
        new JsonStringEnumConverter<DayOfTheWeekAsString>());

    // Generic JsonStringEnumConverter for all enums 
    options.SerializerOptions.Converters.Add(
        new JsonStringEnumConverter());

    options.SerializerOptions.PropertyNamingPolicy =
                             JsonNamingPolicy.CamelCase;
    options.SerializerOptions.DefaultIgnoreCondition =
                             JsonIgnoreCondition.WhenWritingNull;
    options.SerializerOptions.WriteIndented = true;
});

builder.Services.AddControllers();

//builder.Services.AddControllers()
//    .AddJsonOptions(options =>
//    {
//        options.JsonSerializerOptions.Converters.Add(
//            new JsonStringEnumConverter<DayOfTheWeekAsString>());

//        options.JsonSerializerOptions.Converters.Add(
//                new JsonStringEnumConverter());

//        options.JsonSerializerOptions.PropertyNamingPolicy =
//                         JsonNamingPolicy.CamelCase;
//        options.JsonSerializerOptions.DefaultIgnoreCondition =
//                         JsonIgnoreCondition.WhenWritingNull;
//        options.JsonSerializerOptions.WriteIndented = true;
//    });


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

public enum DayOfTheWeekAsString
{
    Sunday,
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday
}
