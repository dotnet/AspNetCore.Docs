---
title: Handle errors in Minimal API apps
author: brunolins16
description: Learn about error handling with minimal APIs in ASP.NET Core.
ms.author: brolivei
monikerRange: '>= aspnetcore-7.0'
ms.date: 10/24/2022
uid: fundamentals/minimal-apis/handle-errors
---

# How to handle errors in Minimal API apps

## Exceptions

TODO:

* [Developer Exception Page middleware **Development environment only**](#developer-exception-page)
* [Exception handler middleware](#exception-handler)

### Developer Exception Page

The [Developer Exception Page](xref:fundamentals/error-handling) shows detailed stack traces for server errors. It uses <xref:Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware> to capture synchronous and asynchronous exceptions from the HTTP pipeline and to generate error responses. 

ASP.NET Core apps enable the developer exception page by default when both:

* Running in the [Development environment](xref:fundamentals/environments).
* App created with the current templates, that is, using [WebApplication.CreateBuilder](/dotnet/api/microsoft.aspnetcore.builder.webapplication.createbuilder).

For more information on configuring middleware see, [Middleware in Minimal API apps](/aspnet/core/fundamentals/minimal-apis/middleware).

For example, consider the following route handler, which throws an exception:

``` csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Map("exception", () => { throw new InvalidOperationException("Sample Exception"); });

app.Run();
```

When the Developer Exception Page detects an unhandled exception, it generates a default plain-text response similar to the following example:

```console
HTTP/1.1 500 Internal Server Error
Content-Type: text/plain; charset=utf-8
Date: Thu, 27 Oct 2022 18:00:59 GMT
Server: Kestrel
Transfer-Encoding: chunked
 
    System.InvalidOperationException: Sample Exception
    at Program.<>c.<<Main>$>b__0_1() in ....:line 17
    at lambda_method2(Closure, Object, HttpContext)
    at Microsoft.AspNetCore.Routing.EndpointMiddleware.Invoke(HttpContext httpContext)
    --- End of stack trace from previous location ---
    at Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddlewareImpl.Invoke(HttpContext context)
HEADERS
=======
Accept: */*
Connection: keep-alive
Host: localhost:5239
Accept-Encoding: gzip, deflate, br
```

> [!WARNING]
> Don't enable the Developer Exception Page **unless the app is running in the Development environment**. Don't share detailed exception information publicly when the app runs in production. For more information on configuring environments, see <xref:fundamentals/environments>.

### Exception handler

## Client and Server error responses

TODO: UseStatusCodePages

## Problem details

[Problem Details](https://www.rfc-editor.org/rfc/rfc7807.html) are not the only response format to describe a HTTP API error, however, they are commonly used to report errors for HTTP APIs.

Minimal API apps can be configured to generate problem details response for all HTTP client and server error responses that ***don't have a body content yet*** using the [`AddProblemDetails`](/dotnet/api/microsoft.extensions.dependencyinjection.problemdetailsservicecollectionextensions.addproblemdetails?view=aspnetcore-7.0&preserve-view=true) extension method on <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection>.

The following code configures the app to generate a problem details:

``` csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseExceptionHandler();
app.UseStatusCodePages();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Route handler endpoints goes here


app.Run();
```

TODO: Explain changes in the middleware

For more information on using [`AddProblemDetails`](/dotnet/api/microsoft.extensions.dependencyinjection.problemdetailsservicecollectionextensions.addproblemdetails?view=aspnetcore-7.0&preserve-view=true), see [Problem Details](/aspnet/core/fundamentals/error-handling#pds7)
