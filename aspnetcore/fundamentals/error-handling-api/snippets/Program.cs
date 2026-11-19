#!/usr/bin/env -S dotnet --
#:sdk Microsoft.NET.Sdk.Web
#:property PublishAot=false

// <snippet>
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

bool IsSupportedProvider(string provider) => provider is "google" or "github";

app.MapGet("/login-provider",
    Results<RedirectHttpResult, ProblemHttpResult> (string? provider) =>
{
    if (string.IsNullOrEmpty(provider))
    {
        return TypedResults.Problem(
            title: "Provider not specified",
            detail: "A login provider is required.",
            statusCode: StatusCodes.Status400BadRequest);
    }

    if (!IsSupportedProvider(provider))
    {
        return TypedResults.Problem(
            title: "Provider not supported",
            detail: $"The provider '{provider}' is not supported.",
            statusCode: StatusCodes.Status400BadRequest);
    }

    return TypedResults.Redirect($"/auth/{provider}");
})
.Produces(StatusCodes.Status302Found)
.ProducesProblem(StatusCodes.Status400BadRequest);

app.Run();
// </snippet>
