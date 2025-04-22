//#define MinApi // MinApi MVCctrl

#if MinApi
// <snippet_minApi>
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;

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

app.Run();

// </snippet_minApi>
#elif  MVCctrl

// <snippet_mvc>
using Microsoft.AspNetCore.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

//builder.Services.Configure<JsonOptions>(options =>
//{
//    // Specific converter for DayOfTheWeekAsString enum
//    options.SerializerOptions.Converters.Add(
//        new JsonStringEnumConverter<DayOfTheWeekAsString>());

//    // Generic JsonStringEnumConverter for all enums 
//    options.SerializerOptions.Converters.Add(
//        new JsonStringEnumConverter());

//    options.SerializerOptions.PropertyNamingPolicy =
//                             JsonNamingPolicy.CamelCase;
//});

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

// </snippet_mvc>

#else
// Everything
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

});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Specific converter for DayOfTheWeekAsString enum
        options.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter<DayOfTheWeekAsString>());

        // Generic JsonStringEnumConverter for all enums 
        options.JsonSerializerOptions.Converters.Add(
                new JsonStringEnumConverter());
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

#endif
