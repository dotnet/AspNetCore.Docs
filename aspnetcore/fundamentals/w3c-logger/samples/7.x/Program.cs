using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Extensions.DependencyInjection;

// <snippet_AddW3CLogging>
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddW3CLogging(logging =>
{
    // Log all W3C fields
    logging.LoggingFields = W3CLoggingFields.All;

    logging.AdditionalRequestHeaders.Add("x-forwarded-for");
    logging.AdditionalRequestHeaders.Add("x-client-ssl-protocol");
    logging.FileSizeLimit = 5 * 1024 * 1024;
    logging.RetainedFileCountLimit = 2;
    logging.FileName = "MyLogFile";
    logging.LogDirectory = @"C:\logs";
    logging.FlushInterval = TimeSpan.FromSeconds(2);
});
// </snippet_AddW3CLogging>

// <snippet_UseW3CLogging>
var app = builder.Build();

app.UseW3CLogging();

app.UseRouting();
// </snippet_UseW3CLogging>

app.MapGet("/", () => "Hello World!");

app.Run();
