using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.AspNetCore.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace ErrorHandlingSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            //<snippet_lambda>
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddProblemDetails();
            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler(new ExceptionHandlerOptions
                {
                    StatusCodeSelector = ex => ex is TimeoutException
                        ? StatusCodes.Status503ServiceUnavailable
                        : StatusCodes.Status500InternalServerError
                });
            }
            //</snippet_lambda>
            app.MapGet("/", () => "Hello World!");

            app.MapGet("/timeout", () =>
            {
                throw new TimeoutException();
            });

            app.MapGet("/exception", () =>
            {
                throw new Exception();
            });

            app.Run();
        }
    }
}
