#define SECOND // FIRST SECOND
#if NEVER
#elif FIRST
#region snippet_Addservices
using Microsoft.AspNetCore.HttpLogging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("My-Request-Header");
    logging.ResponseHeaders.Add("My-Response-Header");
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;

});

var app = builder.Build();

// Code removed for brevity.
#endregion

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseHttpLogging(); 

app.UseRouting();

app.MapGet("/", () => "Hello World!");

app.Run();
#elif SECOND
#region snippet2
using Microsoft.AspNetCore.HttpLogging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpLogging();

var app = builder.Build();

// Code removed for brevity.
#endregion

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseHttpLogging(); 

app.UseRouting();

app.MapGet("/", () => "Hello World!");

app.Run();
#endif