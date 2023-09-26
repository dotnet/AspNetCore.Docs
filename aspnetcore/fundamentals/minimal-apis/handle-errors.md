---
title: Handle errors in Minimal API apps
author: brunolins16
description: Learn about error handling with minimal APIs in ASP.NET Core.
ms.author: brolivei
monikerRange: '>= aspnetcore-7.0'
ms.date: 5/2/2023
uid: fundamentals/minimal-apis/handle-errors
---

<!-- Can't add this until 8 is released and not-latest-version.md is updated to 8.0
[!INCLUDE[](~/includes/not-latest-version.md)]
--> 

# How to handle errors in Minimal API apps

With contributions by [David Acker](https://github.com/david-acker)

 :::moniker range=">= aspnetcore-8.0"

This article describes how to handle errors in Minimal API apps.

## Exceptions

In a Minimal API app, there are two different built-in centralized mechanisms to handle unhandled exceptions:

* [Developer Exception Page middleware](#developer-exception-page) (For use in the **Development environment only**.)
* [Exception handler middleware](#exception-handler)

This section refers to the following Minimal API app to demonstrate ways to handle exceptions. It throws an exception when the endpoint `/exception` is requested:

:::code language="csharp" source="~/fundamentals/minimal-apis/handle-errors/sample8/Program.cs" id="snippet_ThrowExceptions" highlight="4-7":::

### Developer Exception Page

The [Developer Exception Page](xref:fundamentals/error-handling#developer-exception-page) shows detailed stack traces for server errors. It uses <xref:Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware> to capture synchronous and asynchronous exceptions from the HTTP pipeline and to generate error responses.

ASP.NET Core apps enable the developer exception page by default when both:

* Running in the [Development environment](xref:fundamentals/environments).
* App is using [WebApplication.CreateBuilder](/dotnet/api/microsoft.aspnetcore.builder.webapplication.createbuilder).

For more information on configuring middleware, see [Middleware in Minimal API apps](/aspnet/core/fundamentals/minimal-apis/middleware).

Using the preceding Minimal API app, when the `Developer Exception Page` detects an unhandled exception, it generates a default plain-text response similar to the following example:

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

In non-development environments, use the [Exception Handler Middleware](xref:fundamentals/error-handling#exception-handler-page) to produce an error payload. To configure the `Exception Handler Middleware`, call <xref:Microsoft.AspNetCore.Builder.ExceptionHandlerExtensions.UseExceptionHandler%2A>.

For example, the following code changes the app to respond with an [RFC 7807](https://tools.ietf.org/html/rfc7807)-compliant payload to the client. For more information, see [Problem Details](#problem-details) section.

:::code language="csharp" source="~/fundamentals/minimal-apis/handle-errors/sample8/Program.cs" id="snippet_WithUseExceptionHandler" highlight="4-7":::

## Client and Server error responses

Consider the following Minimal API app.

:::code language="csharp" source="~/fundamentals/minimal-apis/handle-errors/sample8/Program.cs" id="snippet_ClientAndServerErrorResponses":::

The `/users` endpoint produces `200 OK` with a `json` representation of `User` when `id` is greater than `0`, otherwise a `400 BAD REQUEST` status code without a response body. For more information about creating a response, see [Create responses in Minimal API apps](/aspnet/core/fundamentals/minimal-apis/responses).

The [`Status Code Pages middleware`](xref:fundamentals/error-handling#sestatuscodepages) can be configured to produce a common body content, **when empty**, for all HTTP client (`400`-`499`) or server (`500` -`599`) responses. The middleware is configured by calling the 
[UseStatusCodePages](<xref:Microsoft.AspNetCore.Builder.StatusCodePagesExtensions.UseStatusCodePages%2A>) extension method.

For example, the following example changes the app to respond with an [RFC 7807](https://tools.ietf.org/html/rfc7807)-compliant payload to the client for all client and server responses, including routing errors (for example, `404 NOT FOUND`). For more information, see the [Problem Details](#problem-details) section.

:::code language="csharp" source="~/fundamentals/minimal-apis/handle-errors/sample8/Program.cs" id="snippet_ClientAndServerErrorResponsesWithUseStatusCodePages" highlight="4-7":::

## Problem details

[!INCLUDE[](~/includes/problem-details-service.md)]

Minimal API apps can be configured to generate problem details response for all HTTP client and server error responses that ***don't have a body content yet*** by using the `AddProblemDetails` extension method.

The following code configures the app to generate problem details:

:::code language="csharp" source="~/fundamentals/minimal-apis/handle-errors/sample8/Program.cs" id="snippet_ProblemDetails" highlight="2":::


For more information on using `AddProblemDetails`, see [Problem Details](/aspnet/core/fundamentals/error-handling?view=aspnetcore-7.0&preserve-view=true#pds7)

## IProblemDetailsService fallback

In the following code, `httpContext.Response.WriteAsync("Fallback: An error occurred.")` returns an error if the <xref:Microsoft.AspNetCore.Http.IProblemDetailsService> implementation isn't able to generate a <xref:Microsoft.AspNetCore.Mvc.ProblemDetails>:

:::code language="csharp" source="~/fundamentals/minimal-apis/handle-errors/sample8/Program.cs" id="snippet_IProblemDetailsServiceWithExceptionFallback" highlight="15":::

The preceding code:

* Writes an error message with the fallback code if the `problemDetailsService` is unable to write a `ProblemDetails`. For example, an endpoint where the [Accept request header](https://developer.mozilla.org/docs/Web/HTTP/Headers/Accept) specifies a media type that the `DefaulProblemDetailsWriter` does not support.
* Uses the [Exception Handler Middleware](xref:fundamentals/error-handling#exception-handler-page).

The following sample is similar to the preceding except that it calls the [`Status Code Pages middleware`](xref:fundamentals/error-handling#usestatuscodepages).

:::code language="csharp" source="~/fundamentals/minimal-apis/handle-errors/sample8/Program.cs" id="snippet_IProblemDetailsServiceWithStatusCodePageFallback" highlight="15":::

:::moniker-end

[!INCLUDE[](~/fundamentals/minimal-apis/handle-errors/includes/handle-errors7.md)]
