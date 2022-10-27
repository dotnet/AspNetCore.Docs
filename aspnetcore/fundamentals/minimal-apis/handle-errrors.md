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

This article describes how to handle errors in Minimal API apps.

## Exceptions

In a Minimal API app, there are two different built-in centralized mechanism to handle unhandled exceptions:

* [Developer Exception Page middleware](#developer-exception-page)  **Development environment only**
* [Exception handler middleware](#exception-handler)

Consider the following Minimal API app, which throws an exception when the endpoint `/exception` is requested:

``` csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Map("/exception", () 
    => { throw new InvalidOperationException("Sample Exception"); });

app.Run();
```

### Developer Exception Page

The [Developer Exception Page](xref:fundamentals/error-handling#developer-exception-page) shows detailed stack traces for server errors. It uses <xref:Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware> to capture synchronous and asynchronous exceptions from the HTTP pipeline and to generate error responses. 

ASP.NET Core apps enable the developer exception page by default when both:

* Running in the [Development environment](xref:fundamentals/environments).
* App created with the current templates, that is, using [WebApplication.CreateBuilder](/dotnet/api/microsoft.aspnetcore.builder.webapplication.createbuilder).

For more information on configuring middleware see, [Middleware in Minimal API apps](/aspnet/core/fundamentals/minimal-apis/middleware).

Using the preceding Minimal API app, when the Developer Exception Page detects an unhandled exception, it generates a default plain-text response similar to the following example:

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

In non-development environments, use [Exception Handler Middleware](xref:fundamentals/error-handling#exception-handler-page) to produce an error payload. To configure the `Exception Handler Middleware` in the preceding Minimal API app, call <xref:Microsoft.AspNetCore.Builder.ExceptionHandlerExtensions.UseExceptionHandler%2A>. 

For example, the following code change the app to respond an [RFC 7807](https://tools.ietf.org/html/rfc7807)-compliant payload to the client. For more information, see [Problem Details](#problem-details) section.


``` csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseExceptionHandler(exceptionHandlerApp 
    => exceptionHandlerApp.Run(async context 
        => await Results.Problem()
                     .ExecuteAsync(context)));

app.Map("/exception", () 
    => { throw new InvalidOperationException("Sample Exception"); });

app.Run();
```

## Client and Server error responses

Consider the following Minimal API app.

``` csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Map("/users/{id:int}", (int id) 
    => id <= 0 ? Results.BadRequest() : Results.Ok(new User(id)) );

app.Run();

public record User(int Id);
```

The `/users` endpoint produces `200 OK` with a `json` representation of `User` when `id` greater than `0`, or, `400 BAD REQUEST` status code without a response body. For more information about creating response, see [Create responses in Minimal API apps](aspnet/core/fundamentals/minimal-apis/responses).

The [`Status Code Pages middleware`](xref:fundamentals/error-handling#sestatuscodepages) can be configure to produce a common body content, **when empty**, for all client (`400`-`499`) or server (`500` -`599`) responses. The middleware is configure by calling 
[UseStatusCodePages](<xref:Microsoft.AspNetCore.Builder.StatusCodePagesExtensions.UseStatusCodePages%2A>) extension method.

For example, the following example change the app to respond an [RFC 7807](https://tools.ietf.org/html/rfc7807)-compliant payload to the client for all client and server responses, including routing errors (eg. `404 NOT FOUND`). For more information, see [Problem Details](#problem-details) section.

``` csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStatusCodePages(async statusCodeContext 
    =>  await Results.Problem(statusCode: statusCodeContext.HttpContext.Response.StatusCode)
                 .ExecuteAsync(statusCodeContext.HttpContext));

app.Map("/users/{id:int}", (int id) 
    => id <= 0 ? Results.BadRequest() : Results.Ok(new User(id)) );

app.Run();

public record User(int Id);
```

## Problem details

[Problem Details](https://www.rfc-editor.org/rfc/rfc7807.html) are not the only response format to describe a HTTP API error, however, they are commonly used to report errors for HTTP APIs.

Minimal API apps can be configured to generate problem details response for all HTTP client and server error responses that ***don't have a body content yet*** using the [`AddProblemDetails`](/dotnet/api/microsoft.extensions.dependencyinjection.problemdetailsservicecollectionextensions.addproblemdetails?view=aspnetcore-7.0&preserve-view=true) extension method on <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection>.

The following middleware generates problem details HTTP responses when [`AddProblemDetails`](/dotnet/api/microsoft.extensions.dependencyinjection.problemdetailsservicecollectionextensions.addproblemdetails?view=aspnetcore-7.0&preserve-view=true) is called, except when not accepted by the client:

* <xref:Microsoft.AspNetCore.Diagnostics.ExceptionHandlerMiddleware>: Generates a problem details response when a custom handler is not defined.
* <xref:Microsoft.AspNetCore.Diagnostics.StatusCodePagesMiddleware>: Generates a problem details response by default.
* <xref:Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware>: Generates a problem details response in development when `text/html` is not accepted.


The following code configures the app to generate a problem details:

``` csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseExceptionHandler();
app.UseStatusCodePages();

app.Map("/users/{id:int}", (int id) 
    => id <= 0 ? Results.BadRequest() : Results.Ok(new User(id)) );

app.Map("/exception", () 
    => { throw new InvalidOperationException("Sample Exception"); });

app.Run();
```

For more information on using `AddProblemDetails`, see [Problem Details](/aspnet/core/fundamentals/error-handling?view=aspnetcore-7.0&preserve-view=true#pds7)
