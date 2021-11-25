using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using static System.Net.Mime.MediaTypeNames;

namespace HandleErrorsSample.Snippets;

public static class Program
{
    public static void ConsistentEnvironments(WebApplication app)
    {
        // <snippet_ConsistentEnvironments>
        if (app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/error-development");
        }
        else
        {
            app.UseExceptionHandler("/error");
        }
        // </snippet_ConsistentEnvironments>
    }

    public static void AddHttpResponseExceptionFilter(WebApplicationBuilder builder)
    {
        // <snippet_AddHttpResponseExceptionFilter>
        builder.Services.AddControllers(options =>
        {
            options.Filters.Add<HttpResponseExceptionFilter>();
        });
        // </snippet_AddHttpResponseExceptionFilter>
    }

    public static void ConfigureInvalidModelStateResponseFactory(WebApplicationBuilder builder)
    {
        // <snippet_ConfigureInvalidModelStateResponseFactory>
        builder.Services.AddControllers()
            .ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                    new BadRequestObjectResult(context.ModelState)
                    {
                        ContentTypes =
                        {
                            // using static System.Net.Mime.MediaTypeNames;
                            Application.Json,
                            Application.Xml
                        }
                    };
            })
            .AddXmlSerializerFormatters();
        // </snippet_ConfigureInvalidModelStateResponseFactory>
    }

    public static void ReplaceProblemDetailsFactory(WebApplicationBuilder builder)
    {
        // <snippet_ReplaceProblemDetailsFactory>
        builder.Services.AddControllers();
        builder.Services.AddTransient<ProblemDetailsFactory, SampleProblemDetailsFactory>();
        // </snippet_ReplaceProblemDetailsFactory>
    }

    public static void ClientErrorMapping(WebApplicationBuilder builder)
    {
        // <snippet_ClientErrorMapping>
        builder.Services.AddControllers()
            .ConfigureApiBehaviorOptions(options =>
            {
                options.ClientErrorMapping[StatusCodes.Status404NotFound].Link =
                    "https://httpstatuses.com/404";
            });
        // </snippet_ClientErrorMapping>
    }
}
