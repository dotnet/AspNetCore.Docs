---
title: Handle errors in ASP.NET Core web APIs
author: tdykstra
description: Learn about error handling with ASP.NET Core web APIs.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 10/14/2022
uid: web-api/handle-errors
---
# Handle errors in ASP.NET Core web APIs

:::moniker range=">= aspnetcore-7.0"

This article describes how to handle errors and customize error handling with ASP.NET Core web APIs.

<a name="dep7"></a>

## Developer Exception Page

The [Developer Exception Page](xref:fundamentals/error-handling) shows detailed stack traces for server errors. It uses <xref:Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware> to capture synchronous and asynchronous exceptions from the HTTP pipeline and to generate error responses. For example, consider the following controller action, which throws an exception:

:::code language="csharp" source="handle-errors/samples/6.x/HandleErrorsSample/Controllers/ErrorsController.cs" id="snippet_Throw":::

When the Developer Exception Page detects an unhandled exception, it generates a default plain-text response similar to the following example:

```console
HTTP/1.1 500 Internal Server Error
Content-Type: text/plain; charset=utf-8
Server: Kestrel
Transfer-Encoding: chunked

System.Exception: Sample exception.
   at HandleErrorsSample.Controllers.ErrorsController.Get() in ...
   at lambda_method1(Closure , Object , Object[] )
   at Microsoft.AspNetCore.Mvc.Infrastructure.ActionMethodExecutor.SyncActionResultExecutor.Execute(IActionResultTypeMapper mapper, ObjectMethodExecutor executor, Object controller, Object[] arguments)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.InvokeActionMethodAsync()
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.InvokeNextActionFilterAsync()

...
```

If the client requests an HTML-formatted response, the Developer Exception Page generates a response similar to the following example:

```console
HTTP/1.1 500 Internal Server Error
Content-Type: text/html; charset=utf-8
Server: Kestrel
Transfer-Encoding: chunked

<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <meta charset="utf-8" />
        <title>Internal Server Error</title>
        <style>
            body {
    font-family: 'Segoe UI', Tahoma, Arial, Helvetica, sans-serif;
    font-size: .813em;
    color: #222;
    background-color: #fff;
}

h1 {
    color: #44525e;
    margin: 15px 0 15px 0;
}

...
```

To request an HTML-formatted response, set the `Accept` HTTP request header to `text/html`.

> [!WARNING]
> Don't enable the Developer Exception Page **unless the app is running in the Development environment**. Don't share detailed exception information publicly when the app runs in production. For more information on configuring environments, see <xref:fundamentals/environments>.

## Exception handler

In non-development environments, use [Exception Handling Middleware](xref:fundamentals/error-handling) to produce an error payload:

1. In `Program.cs`, call <xref:Microsoft.AspNetCore.Builder.ExceptionHandlerExtensions.UseExceptionHandler%2A> to add the Exception Handling Middleware:

    :::code language="csharp" source="handle-errors/samples/6.x/HandleErrorsSample/Program.cs" id="snippet_Middleware" highlight="7":::

1. Configure a controller action to respond to the `/error` route:

    :::code language="csharp" source="handle-errors/samples/6.x/HandleErrorsSample/Controllers/ErrorsController.cs" id="snippet_HandleError":::

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

Exception Handling Middleware can also be used in the Development environment to produce a consistent payload format across all environments:

1. In `Program.cs`, register environment-specific Exception Handling Middleware instances:

    :::code language="csharp" source="handle-errors/samples/6.x/HandleErrorsSample/Snippets/Program.cs" id="snippet_ConsistentEnvironments":::

    In the preceding code, the middleware is registered with:

    * A route of `/error-development` in the Development environment.
    * A route of `/error` in non-Development environments.
    
    <a name="pd"></a>
1. Add controller actions for both the Development and non-Development routes:

    :::code language="csharp" source="handle-errors/samples/6.x/HandleErrorsSample/Controllers/ErrorsController.cs" id="snippet_ConsistentEnvironments":::

## Use exceptions to modify the response

The contents of the response can be modified from outside of the controller using a custom exception and an action filter:

1. Create a well-known exception type named `HttpResponseException`:

    :::code language="csharp" source="handle-errors/samples/6.x/HandleErrorsSample/Snippets/HttpResponseException.cs" id="snippet_Class":::

1. Create an action filter named `HttpResponseExceptionFilter`:

    :::code language="csharp" source="handle-errors/samples/6.x/HandleErrorsSample/Snippets/HttpResponseExceptionFilter.cs" id="snippet_Class":::

    The preceding filter specifies an `Order` of the maximum integer value minus 10. This `Order` allows other filters to run at the end of the pipeline.

1. In `Program.cs`, add the action filter to the filters collection:

    :::code language="csharp" source="handle-errors/samples/6.x/HandleErrorsSample/Snippets/Program.cs" id="snippet_AddHttpResponseExceptionFilter":::

## Validation failure error response

For web API controllers, MVC responds with a <xref:Microsoft.AspNetCore.Mvc.ValidationProblemDetails> response type when model validation fails. MVC uses the results of <xref:Microsoft.AspNetCore.Mvc.ApiBehaviorOptions.InvalidModelStateResponseFactory> to construct the error response for a validation failure. The following example replaces the default factory with an implementation that also supports formatting responses as XML, in `Program.cs`:

:::code language="csharp" source="handle-errors/samples/6.x/HandleErrorsSample/Snippets/Program.cs" id="snippet_ConfigureInvalidModelStateResponseFactory":::

## Client error response

An *error result* is defined as a result with an HTTP status code of 400 or higher. For web API controllers, MVC transforms an error result to produce a <xref:Microsoft.AspNetCore.Mvc.ProblemDetails>.

The automatic creation of a `ProblemDetails` for error status codes is enabled by default, but error responses can be configured in one of the following ways:

1. Use the [problem details service](#pds7)
1. [Implement ProblemDetailsFactory](#implement-problemdetailsfactory)
1. [Use ApiBehaviorOptions.ClientErrorMapping](#use-apibehavioroptionsclienterrormapping)

### Default problem details response

The following `Program.cs` file was generated by the web application templates for API controllers:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/problem-details-service/Program.cs" id="snippet_default":::

Consider the following controller, which returns <xref:Microsoft.AspNetCore.Http.HttpResults.BadRequest> when the input is invalid:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/problem-details-service/Controllers/ValuesController.cs" id="snippet_1":::

A problem details response is generated with the previous code when any of the following conditions apply:

* The `/api/values2/divide` endpoint is called with a zero denominator.
* The `/api/values2/squareroot` endpoint is called with a radicand less than zero.

The default problem details response body has the following `type`, `title`, and `status` values:

```json
{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
  "title": "Bad Request",
  "status": 400,
  "traceId": "00-84c1fd4063c38d9f3900d06e56542d48-85d1d4-00"
}
```

<a name="pds7"></a>

### Problem details service

ASP.NET Core supports creating [Problem Details for HTTP APIs](https://www.rfc-editor.org/rfc/rfc7807.html) using the <xref:Microsoft.AspNetCore.Http.IProblemDetailsService>. For more information, see the [Problem details service](/aspnet/core/fundamentals/error-handling#pds7).

The following code configures the app to generate a problem details response for all HTTP client and server error responses that ***don't have a body content yet***:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/problem-details-service/Program.cs" id="snippet_apishort" highlight="4,8-9,13":::

Consider the API controller from the previous section, which returns <xref:Microsoft.AspNetCore.Http.HttpResults.BadRequest> when the input is invalid:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/problem-details-service/Controllers/ValuesController.cs" id="snippet_1":::

A problem details response is generated with the previous code when any of the following conditions apply:

* An invalid input is supplied.
* The URI has no matching endpoint.
* An unhandled exception occurs.

The automatic creation of a `ProblemDetails` for error status codes is disabled when the <xref:Microsoft.AspNetCore.Mvc.ApiBehaviorOptions.SuppressMapClientErrors%2A> property is set to `true`:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/problem-details-service/Program.cs" id="snippet_disable" highlight="4-7":::

Using the preceding code, when an API controller returns `BadRequest`, an [HTTP 400](https://developer.mozilla.org/docs/Web/HTTP/Status/400) response status is returned with no response body. `SuppressMapClientErrors` prevents a `ProblemDetails` response from being created, even when calling `WriteAsync` for an API Controller endpoint. `WriteAsync` is explained later in this article.

The next section shows how to customize the problem details response body, using <xref:Microsoft.AspNetCore.Http.ProblemDetailsOptions.CustomizeProblemDetails>, to return a more helpful response. For more customization options, see [Customizing problem details](/aspnet/core/fundamentals/error-handling#cpd7).

#### Customize problem details with `CustomizeProblemDetails`

The following code uses <xref:Microsoft.AspNetCore.Http.ProblemDetailsOptions> to set <xref:Microsoft.AspNetCore.Http.ProblemDetailsOptions.CustomizeProblemDetails>:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/problem-details-service/Program.cs" id="snippet_api_controller" highlight="6":::

The updated API controller:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/problem-details-service/Controllers/ValuesController.cs" id="snippet"  highlight="9-17,27-35":::

The following code contains the `MathErrorFeature` and `MathErrorType`, which are used with the preceding sample:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/problem-details-service/MathErrorFeature.cs" :::

A problem details response is generated with the previous code when any of the following conditions apply:

* The `/divide` endpoint is called with a zero denominator.
* The `/squareroot` endpoint is called with a radicand less than zero.
* The URI has no matching endpoint.

The problem details response body contains the following when either `squareroot` endpoint is called with a radicand less than zero:

```json
{
  "type": "https://en.wikipedia.org/wiki/Square_root",
  "title": "Bad Input",
  "status": 400,
  "detail": "Negative or complex numbers are not allowed."
}
```

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/fundamentals/middleware/problem-details-service)


### Implement `ProblemDetailsFactory`

MVC uses <xref:Microsoft.AspNetCore.Mvc.Infrastructure.ProblemDetailsFactory?displayProperty=fullName> to produce all instances of <xref:Microsoft.AspNetCore.Mvc.ProblemDetails> and <xref:Microsoft.AspNetCore.Mvc.ValidationProblemDetails>. This factory is used for:

* Client error responses
* Validation failure error responses
* <xref:Microsoft.AspNetCore.Mvc.ControllerBase.Problem%2A?displayProperty=nameWithType> and <xref:Microsoft.AspNetCore.Mvc.ControllerBase.ValidationProblem%2A?displayProperty=nameWithType>

To customize the problem details response, register a custom implementation of <xref:Microsoft.AspNetCore.Mvc.Infrastructure.ProblemDetailsFactory> in `Program.cs`:

:::code language="csharp" source="handle-errors/samples/6.x/HandleErrorsSample/Snippets/Program.cs" id="snippet_ReplaceProblemDetailsFactory":::

### Use `ApiBehaviorOptions.ClientErrorMapping`

Use the <xref:Microsoft.AspNetCore.Mvc.ApiBehaviorOptions.ClientErrorMapping%2A> property to configure the contents of the `ProblemDetails` response. For example, the following code in `Program.cs` updates the <xref:Microsoft.AspNetCore.Mvc.ClientErrorData.Link%2A> property for 404 responses:

:::code language="csharp" source="handle-errors/samples/6.x/HandleErrorsSample/Snippets/Program.cs" id="snippet_ClientErrorMapping":::

## Additional resources

* [How to Use ModelState Validation in ASP.NET Core Web API](https://code-maze.com/aspnetcore-modelstate-validation-web-api/)
* [View or download sample code](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/fundamentals/middleware/problem-details-service)
* [Hellang.Middleware.ProblemDetails](https://www.nuget.org/packages/Hellang.Middleware.ProblemDetails/)

:::moniker-end

:::moniker range="= aspnetcore-6.0"

This article describes how to handle errors and customize error handling with ASP.NET Core web APIs.

## Developer Exception Page

The [Developer Exception Page](xref:fundamentals/error-handling) shows detailed stack traces for server errors. It uses <xref:Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware> to capture synchronous and asynchronous exceptions from the HTTP pipeline and to generate error responses. For example, consider the following controller action, which throws an exception:

:::code language="csharp" source="handle-errors/samples/6.x/HandleErrorsSample/Controllers/ErrorsController.cs" id="snippet_Throw":::

When the Developer Exception Page detects an unhandled exception, it generates a default plain-text response similar to the following example:

```console
HTTP/1.1 500 Internal Server Error
Content-Type: text/plain; charset=utf-8
Server: Kestrel
Transfer-Encoding: chunked

System.Exception: Sample exception.
   at HandleErrorsSample.Controllers.ErrorsController.Get() in ...
   at lambda_method1(Closure , Object , Object[] )
   at Microsoft.AspNetCore.Mvc.Infrastructure.ActionMethodExecutor.SyncActionResultExecutor.Execute(IActionResultTypeMapper mapper, ObjectMethodExecutor executor, Object controller, Object[] arguments)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.InvokeActionMethodAsync()
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.InvokeNextActionFilterAsync()

...
```

If the client requests an HTML-formatted response, the Developer Exception Page generates a response similar to the following example:

```console
HTTP/1.1 500 Internal Server Error
Content-Type: text/html; charset=utf-8
Server: Kestrel
Transfer-Encoding: chunked

<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <meta charset="utf-8" />
        <title>Internal Server Error</title>
        <style>
            body {
    font-family: 'Segoe UI', Tahoma, Arial, Helvetica, sans-serif;
    font-size: .813em;
    color: #222;
    background-color: #fff;
}

h1 {
    color: #44525e;
    margin: 15px 0 15px 0;
}

...
```

To request an HTML-formatted response, set the `Accept` HTTP request header to `text/html`.

> [!WARNING]
> Don't enable the Developer Exception Page **unless the app is running in the Development environment**. Don't share detailed exception information publicly when the app runs in production. For more information on configuring environments, see <xref:fundamentals/environments>.

## Exception handler

In non-development environments, use [Exception Handling Middleware](xref:fundamentals/error-handling) to produce an error payload:

1. In `Program.cs`, call <xref:Microsoft.AspNetCore.Builder.ExceptionHandlerExtensions.UseExceptionHandler%2A> to add the Exception Handling Middleware:

    :::code language="csharp" source="handle-errors/samples/6.x/HandleErrorsSample/Program.cs" id="snippet_Middleware" highlight="7":::

1. Configure a controller action to respond to the `/error` route:

    :::code language="csharp" source="handle-errors/samples/6.x/HandleErrorsSample/Controllers/ErrorsController.cs" id="snippet_HandleError":::

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

Exception Handling Middleware can also be used in the Development environment to produce a consistent payload format across all environments:

1. In `Program.cs`, register environment-specific Exception Handling Middleware instances:

    :::code language="csharp" source="handle-errors/samples/6.x/HandleErrorsSample/Snippets/Program.cs" id="snippet_ConsistentEnvironments":::

    In the preceding code, the middleware is registered with:

    * A route of `/error-development` in the Development environment.
    * A route of `/error` in non-Development environments.
    
    <a name="pd"></a>
1. Add controller actions for both the Development and non-Development routes:

    :::code language="csharp" source="handle-errors/samples/6.x/HandleErrorsSample/Controllers/ErrorsController.cs" id="snippet_ConsistentEnvironments":::

## Use exceptions to modify the response

The contents of the response can be modified from outside of the controller using a custom exception and an action filter:

1. Create a well-known exception type named `HttpResponseException`:

    :::code language="csharp" source="handle-errors/samples/6.x/HandleErrorsSample/Snippets/HttpResponseException.cs" id="snippet_Class":::

1. Create an action filter named `HttpResponseExceptionFilter`:

    :::code language="csharp" source="handle-errors/samples/6.x/HandleErrorsSample/Snippets/HttpResponseExceptionFilter.cs" id="snippet_Class":::

    The preceding filter specifies an `Order` of the maximum integer value minus 10. This `Order` allows other filters to run at the end of the pipeline.

1. In `Program.cs`, add the action filter to the filters collection:

    :::code language="csharp" source="handle-errors/samples/6.x/HandleErrorsSample/Snippets/Program.cs" id="snippet_AddHttpResponseExceptionFilter":::

## Validation failure error response

For web API controllers, MVC responds with a <xref:Microsoft.AspNetCore.Mvc.ValidationProblemDetails> response type when model validation fails. MVC uses the results of <xref:Microsoft.AspNetCore.Mvc.ApiBehaviorOptions.InvalidModelStateResponseFactory> to construct the error response for a validation failure. The following example replaces the default factory with an implementation that also supports formatting responses as XML, in `Program.cs`:

:::code language="csharp" source="handle-errors/samples/6.x/HandleErrorsSample/Snippets/Program.cs" id="snippet_ConfigureInvalidModelStateResponseFactory":::

## Client error response

An *error result* is defined as a result with an HTTP status code of 400 or higher. For web API controllers, MVC transforms an error result to produce a <xref:Microsoft.AspNetCore.Mvc.ProblemDetails>.

The error response can be configured in one of the following ways:

1. [Implement ProblemDetailsFactory](#implement-problemdetailsfactory)
1. Use [ApiBehaviorOptions.ClientErrorMapping](#use-apibehavioroptionsclienterrormapping)

### Implement `ProblemDetailsFactory`

MVC uses <xref:Microsoft.AspNetCore.Mvc.Infrastructure.ProblemDetailsFactory?displayProperty=fullName> to produce all instances of <xref:Microsoft.AspNetCore.Mvc.ProblemDetails> and <xref:Microsoft.AspNetCore.Mvc.ValidationProblemDetails>. This factory is used for:

* Client error responses
* Validation failure error responses
* <xref:Microsoft.AspNetCore.Mvc.ControllerBase.Problem%2A?displayProperty=nameWithType> and <xref:Microsoft.AspNetCore.Mvc.ControllerBase.ValidationProblem%2A?displayProperty=nameWithType>

To customize the problem details response, register a custom implementation of <xref:Microsoft.AspNetCore.Mvc.Infrastructure.ProblemDetailsFactory> in `Program.cs`:

:::code language="csharp" source="handle-errors/samples/6.x/HandleErrorsSample/Snippets/Program.cs" id="snippet_ReplaceProblemDetailsFactory":::

### Use `ApiBehaviorOptions.ClientErrorMapping`

Use the <xref:Microsoft.AspNetCore.Mvc.ApiBehaviorOptions.ClientErrorMapping%2A> property to configure the contents of the `ProblemDetails` response. For example, the following code in `Program.cs` updates the <xref:Microsoft.AspNetCore.Mvc.ClientErrorData.Link%2A> property for 404 responses:

:::code language="csharp" source="handle-errors/samples/6.x/HandleErrorsSample/Snippets/Program.cs" id="snippet_ClientErrorMapping":::

## Custom Middleware to handle exceptions

The defaults in the exception handling middleware work well for most apps. For apps that require specialized exception handling, consider [customizing the exception handling middleware](xref:fundamentals/error-handling#exception-handler-lambda).

### Produce a ProblemDetails payload for exceptions

ASP.NET Core doesn't produce a standardized error payload when an unhandled exception occurs. For scenarios where it's desirable to return a standardized [ProblemDetails response](https://datatracker.ietf.org/doc/html/rfc7807) to the client, the [ProblemDetails middleware](https://www.nuget.org/packages/Hellang.Middleware.ProblemDetails/) can be used to map exceptions and 404 responses to a [ProblemDetails](xref:web-api/handle-errors#pd) payload. The exception handling middleware can also be used to return a <xref:Microsoft.AspNetCore.Mvc.ProblemDetails> payload for unhandled exceptions.

## Additional resources

* [How to Use ModelState Validation in ASP.NET Core Web API](https://code-maze.com/aspnetcore-modelstate-validation-web-api/)
* [View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/web-api/handle-errors/samples) ([How to download](xref:index#how-to-download-a-sample))

:::moniker-end

:::moniker range="< aspnetcore-6.0"

This article describes how to handle and customize error handling with ASP.NET Core web APIs.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/web-api/handle-errors/samples) ([How to download](xref:index#how-to-download-a-sample))

## Developer Exception Page

The [Developer Exception Page](xref:fundamentals/error-handling) is a useful tool to get detailed stack traces for server errors. It uses <xref:Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware> to capture synchronous and asynchronous exceptions from the HTTP pipeline and to generate error responses. To illustrate, consider the following controller action:

:::code language="csharp" source="handle-errors/samples/3.x/Controllers/WeatherForecastController.cs" id="snippet_GetByCity":::

Run the following `curl` command to test the preceding action:

```bash
curl -i https://localhost:5001/weatherforecast/chicago
```

The Developer Exception Page displays a plain-text response if the client doesn't request HTML-formatted output. The following output appears:

```console
HTTP/1.1 500 Internal Server Error
Transfer-Encoding: chunked
Content-Type: text/plain
Server: Microsoft-IIS/10.0
X-Powered-By: ASP.NET
Date: Fri, 27 Sep 2019 16:13:16 GMT

System.ArgumentException: We don't offer a weather forecast for chicago. (Parameter 'city')
   at WebApiSample.Controllers.WeatherForecastController.Get(String city) in C:\working_folder\aspnet\AspNetCore.Docs\aspnetcore\web-api\handle-errors\samples\3.x\Controllers\WeatherForecastController.cs:line 34
   at lambda_method(Closure , Object , Object[] )
   at Microsoft.Extensions.Internal.ObjectMethodExecutor.Execute(Object target, Object[] parameters)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ActionMethodExecutor.SyncObjectResultExecutor.Execute(IActionResultTypeMapper mapper, ObjectMethodExecutor executor, Object controller, Object[] arguments)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.<InvokeActionMethodAsync>g__Logged|12_1(ControllerActionInvoker invoker)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.<InvokeNextActionFilterAsync>g__Awaited|10_0(ControllerActionInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Rethrow(ActionExecutedContextSealed context)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.InvokeInnerFilterAsync()
--- End of stack trace from previous location where exception was thrown ---
   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeFilterPipelineAsync>g__Awaited|19_0(ResourceInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeAsync>g__Logged|17_1(ResourceInvoker invoker)
   at Microsoft.AspNetCore.Routing.EndpointMiddleware.<Invoke>g__AwaitRequestTask|6_0(Endpoint endpoint, Task requestTask, ILogger logger)
   at Microsoft.AspNetCore.Authorization.AuthorizationMiddleware.Invoke(HttpContext context)
   at Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware.Invoke(HttpContext context)

HEADERS
=======
Accept: */*
Host: localhost:44312
User-Agent: curl/7.55.1
```

To display an HTML-formatted response instead, set the `Accept` HTTP request header to the `text/html` media type. For example:

```bash
curl -i -H "Accept: text/html" https://localhost:5001/weatherforecast/chicago
```

Consider the following excerpt from the HTTP response:

```console
HTTP/1.1 500 Internal Server Error
Transfer-Encoding: chunked
Content-Type: text/html; charset=utf-8
Server: Microsoft-IIS/10.0
X-Powered-By: ASP.NET
Date: Fri, 27 Sep 2019 16:55:37 GMT

<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <meta charset="utf-8" />
        <title>Internal Server Error</title>
        <style>
            body {
    font-family: 'Segoe UI', Tahoma, Arial, Helvetica, sans-serif;
    font-size: .813em;
    color: #222;
    background-color: #fff;
}
```

The HTML-formatted response becomes useful when testing via tools like Postman. The following screen capture shows both the plain-text and the HTML-formatted responses in Postman:

:::image source="handle-errors/_static/developer-exception-page-postman.gif" alt-text="Test the Developer Exception Page in Postman.":::

> [!WARNING]
> Enable the Developer Exception Page **only when the app is running in the Development environment**. Don't share detailed exception information publicly when the app runs in production. For more information on configuring environments, see <xref:fundamentals/environments>.
>
> Don't mark the error handler action method with HTTP method attributes, such as `HttpGet`. Explicit verbs prevent some requests from reaching the action method. Allow anonymous access to the method if unauthenticated users should see the error.

## Exception handler

In non-development environments, [Exception Handling Middleware](xref:fundamentals/error-handling) can be used to produce an error payload:

1. In `Startup.Configure`, invoke <xref:Microsoft.AspNetCore.Builder.ExceptionHandlerExtensions.UseExceptionHandler%2A> to use the middleware:

    :::code language="csharp" source="handle-errors/samples/3.x/Startup.cs" id="snippet_UseExceptionHandler" highlight="9":::

1. Configure a controller action to respond to the `/error` route:

    :::code language="csharp" source="handle-errors/samples/3.x/Controllers/ErrorController.cs" id="snippet_ErrorController":::

The preceding `Error` action sends an [RFC 7807](https://tools.ietf.org/html/rfc7807)-compliant payload to the client.

Exception Handling Middleware can also provide more detailed content-negotiated output in the local development environment. Use the following steps to produce a consistent payload format across development and production environments:

1. In `Startup.Configure`, register environment-specific Exception Handling Middleware instances:

    ```csharp
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseExceptionHandler("/error-local-development");
        }
        else
        {
            app.UseExceptionHandler("/error");
        }
    }
    ```

    In the preceding code, the middleware is registered with:

    * A route of `/error-local-development` in the Development environment.
    * A route of `/error` in environments that aren't Development.
    
    <a name="pd"></a>
1. Apply attribute routing to controller actions:

    :::code language="csharp" source="handle-errors/samples/3.x/Controllers/ErrorController.cs" id="snippet_ErrorControllerEnvironmentSpecific":::

    The preceding code calls [ControllerBase.Problem](xref:Microsoft.AspNetCore.Mvc.ControllerBase.Problem%2A) to create a <xref:Microsoft.AspNetCore.Mvc.ProblemDetails> response.

## Use exceptions to modify the response

The contents of the response can be modified from outside of the controller. In ASP.NET 4.x Web API, one way to do this was using the <xref:System.Web.Http.HttpResponseException> type. ASP.NET Core doesn't include an equivalent type. Support for `HttpResponseException` can be added with the following steps:

1. Create a well-known exception type named `HttpResponseException`:

    :::code language="csharp" source="handle-errors/samples/3.x/Exceptions/HttpResponseException.cs" id="snippet_HttpResponseException":::

1. Create an action filter named `HttpResponseExceptionFilter`:

    :::code language="csharp" source="handle-errors/samples/3.x/Filters/HttpResponseExceptionFilter.cs" id="snippet_HttpResponseExceptionFilter":::

    The preceding filter specifies an `Order` of the maximum integer value minus 10. This `Order` allows other filters to run at the end of the pipeline.

1. In `Startup.ConfigureServices`, add the action filter to the filters collection:

    :::code language="csharp" source="handle-errors/samples/3.x/Startup.cs" id="snippet_AddExceptionFilter":::

## Validation failure error response

For web API controllers, MVC responds with a <xref:Microsoft.AspNetCore.Mvc.ValidationProblemDetails> response type when model validation fails. MVC uses the results of <xref:Microsoft.AspNetCore.Mvc.ApiBehaviorOptions.InvalidModelStateResponseFactory> to construct the error response for a validation failure. The following example uses the factory to change the default response type to <xref:Microsoft.AspNetCore.Mvc.SerializableError> in `Startup.ConfigureServices`:

:::code language="csharp" source="handle-errors/samples/3.x/Startup.cs" id="snippet_DisableProblemDetailsInvalidModelStateResponseFactory" highlight="4-13":::

## Client error response

An *error result* is defined as a result with an HTTP status code of 400 or higher. For web API controllers, MVC transforms an error result to a result with <xref:Microsoft.AspNetCore.Mvc.ProblemDetails>.

The error response can be configured in one of the following ways:

1. [Implement ProblemDetailsFactory](#implement-problemdetailsfactory)
1. [Use ApiBehaviorOptions.ClientErrorMapping](#use-apibehavioroptionsclienterrormapping)

### Implement `ProblemDetailsFactory`

MVC uses <xref:Microsoft.AspNetCore.Mvc.Infrastructure.ProblemDetailsFactory?displayProperty=fullName> to produce all instances of <xref:Microsoft.AspNetCore.Mvc.ProblemDetails> and <xref:Microsoft.AspNetCore.Mvc.ValidationProblemDetails>. This factory is used for:

* Client error responses
* Validation failure error responses
* <xref:Microsoft.AspNetCore.Mvc.ControllerBase.Problem%2A?displayProperty=nameWithType> and <xref:Microsoft.AspNetCore.Mvc.ControllerBase.ValidationProblem%2A?displayProperty=nameWithType> >

To customize the problem details response, register a custom implementation of <xref:Microsoft.AspNetCore.Mvc.Infrastructure.ProblemDetailsFactory> in `Startup.ConfigureServices`:

```csharp
public void ConfigureServices(IServiceCollection serviceCollection)
{
    services.AddControllers();
    services.AddTransient<ProblemDetailsFactory, CustomProblemDetailsFactory>();
}
```

### Use ApiBehaviorOptions.ClientErrorMapping

Use the <xref:Microsoft.AspNetCore.Mvc.ApiBehaviorOptions.ClientErrorMapping%2A> property to configure the contents of the `ProblemDetails` response. For example, the following code in `Startup.ConfigureServices` updates the `type` property for 404 responses:

:::code language="csharp" source="index/samples/3.x/Startup.cs" id="snippet_ConfigureApiBehaviorOptions" highlight="8-9":::

## Custom Middleware to handle exceptions

The defaults in the exception handling middleware work well for most apps. For apps that require specialized exception handling, consider [customizing the exception handling middleware](xref:fundamentals/error-handling#exception-handler-lambda).

### Producing a ProblemDetails payload for exceptions

ASP.NET Core doesn't produce a standardized error payload when an unhandled exception occurs. For scenarios where it's desirable to return a standardized [ProblemDetails response](https://datatracker.ietf.org/doc/html/rfc7807) to the client, the [ProblemDetails middleware](https://www.nuget.org/packages/Hellang.Middleware.ProblemDetails/) can be used to map exceptions and 404 responses to a [ProblemDetails](xref:web-api/handle-errors#pd) payload. The exception handling middleware can also be used to return a <xref:Microsoft.AspNetCore.Mvc.ProblemDetails> payload for unhandled exceptions.

:::moniker-end
