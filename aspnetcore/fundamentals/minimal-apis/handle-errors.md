---
title: Handle errors in minimal APIs
author: brunolins16
description: Learn about error handling in minimal APIs in ASP.NET Core.
ms.author: wpickett
monikerRange: '>= aspnetcore-7.0'
ms.date: 05/30/2024
uid: fundamentals/minimal-apis/handle-errors
---

# How to handle errors in Minimal API apps

[!INCLUDE[](~/includes/not-latest-version.md)]

With contributions by [David Acker](https://github.com/david-acker)

 :::moniker range=">= aspnetcore-8.0"

This article describes how to handle errors in Minimal API apps. For information about error handling in controller-based APIs, see <xref:fundamentals/error-handling> and <xref:web-api/handle-errors>.

## Exceptions

In a Minimal API app, there are two different built-in centralized mechanisms to handle unhandled exceptions:

* [Developer Exception Page middleware](#developer-exception-page) (For use in the **Development environment only**.)
* [Exception handler middleware](#exception-handler)

This section refers to the following sample app to demonstrate ways to handle exceptions in a Minimal API. It throws an exception when the endpoint `/exception` is requested:

:::code language="csharp" source="~/fundamentals/minimal-apis/handle-errors/sample8/Program.cs" id="snippet_ThrowExceptions" highlight="4-7":::

### Developer Exception Page

[!INCLUDE [](~/includes/developer-exception-page.md)]

To see the Developer Exception Page:

* Run the sample app in the [Development environment](xref:fundamentals/environments).
* Go to the `/exception` endpoint.

### Exception handler

In non-development environments, use the [Exception Handler Middleware](xref:fundamentals/error-handling#exception-handler-page) to produce an error payload. To configure the `Exception Handler Middleware`, call <xref:Microsoft.AspNetCore.Builder.ExceptionHandlerExtensions.UseExceptionHandler%2A>.

For example, the following code changes the app to respond with an [RFC 7807](https://tools.ietf.org/html/rfc7807)-compliant payload to the client. For more information, see the [Problem Details](#problem-details) section later in this article.

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

Minimal API apps can be configured to generate problem details response for all HTTP client and server error responses that ***don't have body content yet*** by using the `AddProblemDetails` extension method.

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
