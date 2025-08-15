---
title: Handle errors in ASP.NET Core APIs
author: brunolins16
description: Learn about error handling in ASP.NET Core APIs with Minimal APIs and controller-based approaches.
ai-usage: ai-assisted
ms.author: wpickett
monikerRange: '>= aspnetcore-7.0'
ms.date: 08/15/2025
uid: fundamentals/handle-errors
---

# Handle errors in ASP.NET Core APIs

[!INCLUDE[](~/includes/not-latest-version.md)]

With contributions by [David Acker](https://github.com/david-acker) and [Tom Dykstra](https://github.com/tdykstra/)

This article describes how to handle errors in ASP.NET Core APIs. For Blazor error handling guidance, see <xref:blazor/fundamentals/handle-errors>.

## Developer Exception Page

[!INCLUDE [](../includes/developer-exception-page.md)]

#### [Minimal APIs](#tab/minimal-apis)

To see the Developer Exception Page in a Minimal API:

* Run the sample app in the [Development environment](xref:fundamentals/environments).
* Go to the `/exception` endpoint.

This section refers to the following sample app to demonstrate ways to handle exceptions in a Minimal API. It throws an exception when the endpoint `/exception` is requested:

:::code language="csharp" source="~/fundamentals/minimal-apis/handle-errors/sample8/Program.cs" id="snippet_ThrowExceptions" highlight="4-7":::

#### [Controllers](#tab/controllers)

To see the Developer Exception Page in a controller-based API:

* Add the following controller action to a controller-based API. The action throws an exception when the endpoint is requested.

  :::code language="csharp" source="~/web-api/handle-errors/samples/6.x/HandleErrorsSample/Controllers/ErrorsController.cs" id="snippet_Throw":::

* Run the app in the [development environment](xref:fundamentals/environments).
* Go to the endpoint defined by the controller action.

---

## Exception handler

In non-development environments, use the [Exception Handler Middleware](xref:fundamentals/error-handling#exception-handler-page) to produce an error payload.

#### [Minimal APIs](#tab/minimal-apis)

To configure the `Exception Handler Middleware`, call <xref:Microsoft.AspNetCore.Builder.ExceptionHandlerExtensions.UseExceptionHandler%2A>. For example, the following code changes the app to respond with an [RFC 7807](https://tools.ietf.org/html/rfc7807)-compliant payload to the client. For more information, see the [Problem Details](#problem-details) section later in this article.

:::code language="csharp" source="~/fundamentals/minimal-apis/handle-errors/sample8/Program.cs" id="snippet_WithUseExceptionHandler" highlight="4-7":::

#### [Controllers](#tab/controllers)

1. In `Program.cs`, call <xref:Microsoft.AspNetCore.Builder.ExceptionHandlerExtensions.UseExceptionHandler%2A> to add the Exception Handling Middleware:

    :::code language="csharp" source="~/web-api/handle-errors/samples/6.x/HandleErrorsSample/Program.cs" id="snippet_Middleware" highlight="7":::

1. Configure a controller action to respond to the `/error` route:

    :::code language="csharp" source="~/web-api/handle-errors/samples/6.x/HandleErrorsSample/Controllers/ErrorsController.cs" id="snippet_HandleError":::

The preceding `HandleError` action sends an [RFC 7807](https://tools.ietf.org/html/rfc7807)-compliant payload to the client.

> [!WARNING]
> Don't mark the error handler action method with HTTP method attributes, such as `HttpGet`. Explicit verbs prevent some requests from reaching the action method.
>
> For web APIs that use [Swagger / OpenAPI](xref:tutorials/web-api-help-pages-using-swagger), mark the error handler action with the [[ApiExplorerSettings]](xref:Microsoft.AspNetCore.Mvc.ApiExplorerSettingsAttribute) attribute and set its <xref:Microsoft.AspNetCore.Mvc.ApiExplorerSettingsAttribute.IgnoreApi%2A> property to `true`. This attribute configuration excludes the error handler action from the app's OpenAPI specification:
>
> ```csharp
> [ApiExplorerSettings(IgnoreApi = true)]
> ```
>
> Allow anonymous access to the method if unauthenticated users should see the error.

---

## Client and Server error responses

#### [Minimal APIs](#tab/minimal-apis)

Consider the following Minimal API app.

:::code language="csharp" source="~/fundamentals/minimal-apis/handle-errors/sample8/Program.cs" id="snippet_ClientAndServerErrorResponses":::

The `/users` endpoint produces `200 OK` with a `json` representation of `User` when `id` is greater than `0`, otherwise a `400 BAD REQUEST` status code without a response body. For more information about creating a response, see [Create responses in Minimal API apps](/aspnet/core/fundamentals/minimal-apis/responses).

The [`Status Code Pages middleware`](#client-and-server-error-responses) can be configured to produce a common body content, **when empty**, for all HTTP client (`400`-`499`) or server (`500` -`599`) responses. The middleware is configured by calling the 
[UseStatusCodePages](<xref:Microsoft.AspNetCore.Builder.StatusCodePagesExtensions.UseStatusCodePages%2A>) extension method.

For example, the following example changes the app to respond with an [RFC 7807](https://tools.ietf.org/html/rfc7807)-compliant payload to the client for all client and server responses, including routing errors (for example, `404 NOT FOUND`). For more information, see the [Problem Details](#problem-details) section.

:::code language="csharp" source="~/fundamentals/minimal-apis/handle-errors/sample8/Program.cs" id="snippet_ClientAndServerErrorResponsesWithUseStatusCodePages" highlight="4-7":::

#### [Controllers](#tab/controllers)

For controller-based APIs, the error response can be configured in one of the following ways:

1. Use the [problem details service](#problem-details-service)
1. [Implement ProblemDetailsFactory](#implement-problemdetailsfactory)
1. [Use ApiBehaviorOptions.ClientErrorMapping](#use-apibehavioroptionsclienterrormapping)

An *error result* is defined as a result with an HTTP status code of 400 or higher. For web API controllers, MVC transforms an error result to produce a <xref:Microsoft.AspNetCore.Mvc.ProblemDetails>.

The automatic creation of a `ProblemDetails` for error status codes is enabled by default.

---

## Problem details

[!INCLUDE[](~/includes/problem-details-service.md)]

#### [Minimal APIs](#tab/minimal-apis)

Minimal API apps can be configured to generate problem details response for all HTTP client and server error responses that ***don't have body content yet*** by using the `AddProblemDetails` extension method.

The following code configures the app to generate problem details:

:::code language="csharp" source="~/fundamentals/minimal-apis/handle-errors/sample8/Program.cs" id="snippet_ProblemDetails" highlight="2":::

For more information on using `AddProblemDetails`, see [Problem Details](#problem-details)

### IProblemDetailsService fallback

In the following code, `httpContext.Response.WriteAsync("Fallback: An error occurred.")` returns an error if the <xref:Microsoft.AspNetCore.Http.IProblemDetailsService> implementation isn't able to generate a <xref:Microsoft.AspNetCore.Mvc.ProblemDetails>:

:::code language="csharp" source="~/fundamentals/minimal-apis/handle-errors/sample8/Program.cs" id="snippet_IProblemDetailsServiceWithExceptionFallback" highlight="15":::

The preceding code:

* Writes an error message with the fallback code if the `problemDetailsService` is unable to write a `ProblemDetails`. For example, an endpoint where the [Accept request header](https://developer.mozilla.org/docs/Web/HTTP/Headers/Accept) specifies a media type that the `DefaulProblemDetailsWriter` does not support.
* Uses the [Exception Handler Middleware](#exception-handler).

The following sample is similar to the preceding except that it calls the [`Status Code Pages middleware`](#client-and-server-error-responses).

:::code language="csharp" source="~/fundamentals/minimal-apis/handle-errors/sample8/Program.cs" id="snippet_IProblemDetailsServiceWithStatusCodePageFallback" highlight="15":::

#### [Controllers](#tab/controllers)

### Problem details service

ASP.NET Core supports creating [Problem Details for HTTP APIs](https://www.rfc-editor.org/rfc/rfc9457) using the <xref:Microsoft.AspNetCore.Http.IProblemDetailsService>.

The following code configures the app to generate a problem details response for all HTTP client and server error responses that ***don't have body content yet***:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/problem-details-service/Program.cs" id="snippet_apishort" highlight="4,8-9,13":::

Consider the API controller from the preceding section, which returns <xref:Microsoft.AspNetCore.Http.HttpResults.BadRequest> when the input is invalid:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/problem-details-service/Controllers/ValuesController.cs" id="snippet_1":::

A problem details response is generated with the preceding code when any of the following conditions apply:

* An invalid input is supplied.
* The URI has no matching endpoint.
* An unhandled exception occurs.

#### Customize problem details with `CustomizeProblemDetails`

The following code uses <xref:Microsoft.AspNetCore.Http.ProblemDetailsOptions> to set <xref:Microsoft.AspNetCore.Http.ProblemDetailsOptions.CustomizeProblemDetails>:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/problem-details-service/Program.cs" id="snippet_api_controller" highlight="6":::

### Implement `ProblemDetailsFactory`

MVC uses <xref:Microsoft.AspNetCore.Mvc.Infrastructure.ProblemDetailsFactory?displayProperty=fullName> to produce all instances of <xref:Microsoft.AspNetCore.Mvc.ProblemDetails> and <xref:Microsoft.AspNetCore.Mvc.ValidationProblemDetails>. This factory is used for:

* Client error responses
* Validation failure error responses
* <xref:Microsoft.AspNetCore.Mvc.ControllerBase.Problem%2A?displayProperty=nameWithType> and <xref:Microsoft.AspNetCore.Mvc.ControllerBase.ValidationProblem%2A?displayProperty=nameWithType>

To customize the problem details response, register a custom implementation of <xref:Microsoft.AspNetCore.Mvc.Infrastructure.ProblemDetailsFactory> in `Program.cs`:

:::code language="csharp" source="~/web-api/handle-errors/samples/6.x/HandleErrorsSample/Snippets/Program.cs" id="snippet_ReplaceProblemDetailsFactory":::

### Use `ApiBehaviorOptions.ClientErrorMapping`

Use the <xref:Microsoft.AspNetCore.Mvc.ApiBehaviorOptions.ClientErrorMapping%2A> property to configure the contents of the `ProblemDetails` response. For example, the following code in `Program.cs` updates the <xref:Microsoft.AspNetCore.Mvc.ClientErrorData.Link%2A> property for 404 responses:

:::code language="csharp" source="~/web-api/handle-errors/samples/6.x/HandleErrorsSample/Snippets/Program.cs" id="snippet_ClientErrorMapping":::

---

## Additional error handling features

#### [Minimal APIs](#tab/minimal-apis)

### Migration from controllers to Minimal APIs

If you're migrating from controller-based APIs to Minimal APIs:

1. **Replace action filters** with endpoint filters or middleware
2. **Replace model validation** with manual validation or custom binding
3. **Replace exception filters** with exception handling middleware
4. **Configure problem details** using `AddProblemDetails()` for consistent error responses

### When to use controller-based error handling

Consider controller-based APIs if you need:

* Complex model validation scenarios
* Centralized exception handling across multiple controllers
* Fine-grained control over error response formatting
* Integration with MVC features like filters and conventions

For detailed information about controller-based error handling, including validation errors, problem details customization, and exception filters, see the [Controllers](#tab/controllers) tab sections.

#### [Controllers](#tab/controllers)

### Validation failure error response

For web API controllers, MVC responds with a <xref:Microsoft.AspNetCore.Mvc.ValidationProblemDetails> response type when model validation fails. MVC uses the results of <xref:Microsoft.AspNetCore.Mvc.ApiBehaviorOptions.InvalidModelStateResponseFactory> to construct the error response for a validation failure. The following example replaces the default factory with an implementation that also supports formatting responses as XML, in `Program.cs`:

:::code language="csharp" source="~/web-api/handle-errors/samples/6.x/HandleErrorsSample/Snippets/Program.cs" id="snippet_ConfigureInvalidModelStateResponseFactory":::

### Use exceptions to modify the response

The contents of the response can be modified from outside of the controller using a custom exception and an action filter:

1. Create a well-known exception type named `HttpResponseException`:

    :::code language="csharp" source="~/web-api/handle-errors/samples/6.x/HandleErrorsSample/Snippets/HttpResponseException.cs" id="snippet_Class":::

1. Create an action filter named `HttpResponseExceptionFilter`:

    :::code language="csharp" source="~/web-api/handle-errors/samples/6.x/HandleErrorsSample/Snippets/HttpResponseExceptionFilter.cs" id="snippet_Class":::

    The preceding filter specifies an `Order` of the maximum integer value minus 10. This `Order` allows other filters to run at the end of the pipeline.

1. In `Program.cs`, add the action filter to the filters collection:

    :::code language="csharp" source="~/web-api/handle-errors/samples/6.x/HandleErrorsSample/Snippets/Program.cs" id="snippet_AddHttpResponseExceptionFilter":::

### Key differences for controllers

* **Automatic model validation**: Controllers automatically validate model state and return `400 Bad Request` responses for validation failures
* **Exception filters**: Use action filters and exception filters for centralized error handling
* **Built-in problem details**: Configure `ApiBehaviorOptions` for standardized error responses
* **Custom error responses**: Override `InvalidModelStateResponseFactory` for custom validation error formatting

---

## Additional resources

* [How to Use ModelState Validation in ASP.NET Core Web API](https://code-maze.com/aspnetcore-modelstate-validation-web-api/)
* [View or download sample code](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/fundamentals/middleware/problem-details-service)
* [Hellang.Middleware.ProblemDetails](https://www.nuget.org/packages/Hellang.Middleware.ProblemDetails/)