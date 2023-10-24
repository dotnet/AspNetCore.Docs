#define THIRD // FIRST SECOND THIRD
#if NEVER
#elif FIRST
// <snippet_Addservices>
using Microsoft.AspNetCore.HttpLogging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("sec-ch-ua");
    logging.ResponseHeaders.Add("MyResponseHeader");
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
    logging.CombineLogs = true;
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseHttpLogging(); 

app.Use(async (context, next) =>
{
    context.Response.Headers["MyResponseHeader"] =
        new string[] { "My Response Header Value" };

    await next();
});

app.MapGet("/", () => "Hello World!");

app.Run();
// </snippet_Addservices>
#elif SECOND
// <snippet2>
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpLogging(o => { });

var app = builder.Build();

app.UseHttpLogging();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.MapGet("/", () => "Hello World!");

app.Run();
// </snippet2>
#elif THIRD
// <snippet3>
using HttpLoggingSample;
using Microsoft.AspNetCore.HttpLogging;

// <snippet4>
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.Duration;
});
//builder.Services.AddHttpLoggingInterceptor<SampleHttpLoggingInterceptor>();
// </snippet4>
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseHttpLogging(); 

app.Use(async (context, next) =>
{
    context.Response.Headers["MyResponseHeader"] =
        new string[] { "My Response Header Value" };

    await next();
});

// <snippet5>
app.MapGet("/", () => "Hello World!");

app.MapGet("/duration", [HttpLogging(loggingFields: HttpLoggingFields.Duration)]
    () => "Hello World! (attribute)");

app.MapGet("/request", [HttpLogging(loggingFields: HttpLoggingFields.RequestPropertiesAndHeaders)]
    () => "Hello World! (attribute)");
// </snippet5>

app.Run();
// </snippet3>
#endif
