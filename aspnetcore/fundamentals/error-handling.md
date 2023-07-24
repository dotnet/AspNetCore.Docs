---
title: Handle errors in ASP.NET Core
author: tdykstra
description: Discover how to handle errors in ASP.NET Core apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 07/06/2023
uid: fundamentals/error-handling
---
# Handle errors in ASP.NET Core

[!INCLUDE[](~/includes/not-latest-version.md)]

:::moniker range=">= aspnetcore-8.0"

By [Tom Dykstra](https://github.com/tdykstra/)

This article covers common approaches to handling errors in ASP.NET Core web apps. See also <xref:web-api/handle-errors> and <xref:fundamentals/minimal-apis/handle-errors>.

## Developer exception page

The *Developer Exception Page* displays detailed information about unhandled request exceptions. ASP.NET Core apps enable the developer exception page by default when both:

* Running in the [Development environment](xref:fundamentals/environments).
* App created with the current templates, that is, using [WebApplication.CreateBuilder](/dotnet/api/microsoft.aspnetcore.builder.webapplication.createbuilder).  Apps created using the [`WebHost.CreateDefaultBuilder`](xref:Microsoft.AspNetCore.WebHost.CreateDefaultBuilder) must enable the developer exception page by calling `app.UseDeveloperExceptionPage` in `Configure`.

The developer exception page runs early in the middleware pipeline, so that it can catch unhandled exceptions thrown in middleware that follows.

Detailed exception information shouldn't be displayed publicly when the app runs in the Production environment. For more information on configuring environments, see <xref:fundamentals/environments>.

The Developer Exception Page can include the following information about the exception and the request:

* Stack trace
* Query string parameters, if any
* Cookies, if any
* Headers

The Developer Exception Page isn't guaranteed to provide any information. Use [Logging](xref:fundamentals/logging/index) for complete error information.

## Exception handler page

To configure a custom error handling page for the [Production environment](xref:fundamentals/environments), call <xref:Microsoft.AspNetCore.Builder.ExceptionHandlerExtensions.UseExceptionHandler%2A>. This exception handling middleware:

* Catches and logs unhandled exceptions.
* Re-executes the request in an alternate pipeline using the path indicated. The request isn't re-executed if the response has started. The template-generated code re-executes the request using the `/Error` path.

> [!WARNING]
> If the alternate pipeline throws an exception of its own, Exception Handling Middleware rethrows the original exception.

Since this middleware can re-execute the request pipeline:

* Middlewares need to handle reentrancy with the same request. This normally means either cleaning up their state after calling `_next` or caching their processing on the `HttpContext` to avoid redoing it. When dealing with the request body, this either means buffering or caching the results like the Form reader.
* For the <xref:Microsoft.AspNetCore.Builder.ExceptionHandlerExtensions.UseExceptionHandler(Microsoft.AspNetCore.Builder.IApplicationBuilder,System.String)> overload that is used in templates, only the request path is modified, and the route data is cleared. Request data such as headers, method, and items are all reused as-is.
* Scoped services remain the same.

In the following example, <xref:Microsoft.AspNetCore.Builder.ExceptionHandlerExtensions.UseExceptionHandler%2A> adds the exception handling middleware in non-Development environments:

:::code language="csharp" source="~/fundamentals/error-handling/samples/7.x/ErrorHandlingSample/Program.cs" id="snippet_UseExceptionHandler" highlight="3,5":::

The Razor Pages app template provides an Error page (`.cshtml`) and <xref:Microsoft.AspNetCore.Mvc.RazorPages.PageModel> class (`ErrorModel`) in the *Pages* folder. For an MVC app, the project template includes an `Error` action method and an Error view for the Home controller.

The exception handling middleware re-executes the request using the *original* HTTP method. If an error handler endpoint is restricted to a specific set of HTTP methods, it runs only for those HTTP methods. For example, an MVC controller action that uses the `[HttpGet]` attribute runs only for GET requests. To ensure that *all* requests reach the custom error handling page, don't restrict them to a specific set of HTTP methods.

To handle exceptions differently based on the original HTTP method:

* For Razor Pages, create multiple handler methods. For example, use `OnGet` to handle GET exceptions and use `OnPost` to handle POST exceptions.
* For MVC, apply HTTP verb attributes to multiple actions. For example, use `[HttpGet]` to handle GET exceptions and use `[HttpPost]` to handle POST exceptions.

To allow unauthenticated users to view the custom error handling page, ensure that it supports anonymous access.

### Access the exception

Use <xref:Microsoft.AspNetCore.Diagnostics.IExceptionHandlerPathFeature> to access the exception and the original request path in an error handler. The following example uses `IExceptionHandlerPathFeature` to get more information about the exception that was thrown:

:::code language="csharp" source="~/fundamentals/error-handling/samples/7.x/ErrorHandlingSample/Pages/Error.cshtml.cs" id="snippet_Class" highlight="15-27":::

> [!WARNING]
> Do **not** serve sensitive error information to clients. Serving errors is a security risk.

## Exception handler lambda

An alternative to a [custom exception handler page](#exception-handler-page) is to provide a lambda to <xref:Microsoft.AspNetCore.Builder.ExceptionHandlerExtensions.UseExceptionHandler%2A>. Using a lambda allows access to the error before returning the response.

The following code uses a lambda for exception handling:

:::code language="csharp" source="~/fundamentals/error-handling/samples/7.x/ErrorHandlingSample/Snippets/Program.cs" id="snippet_UseExceptionHandlerInline" highlight="5-29":::

> [!WARNING]
> Do **not** serve sensitive error information to clients. Serving errors is a security risk.

## IExceptionHandler

[IExceptionHandler](https://source.dot.net/#Microsoft.AspNetCore.Diagnostics/ExceptionHandler/IExceptionHandler.cs,adae2915ad0c6dc5) is an interface that gives the developer a callback for handling known exceptions in a central location.

`IExceptionHandler` implementations are registered by calling [`IServiceCollection.AddExceptionHandler<T>`](https://source.dot.net/#Microsoft.AspNetCore.Diagnostics/ExceptionHandler/ExceptionHandlerServiceCollectionExtensions.cs,e74aac24e3e2cbc9). The lifetime of an `IExceptionHandler` instance is singleton. Multiple implementations can be added, and they're called in the order registered.

If an exception handler handles a request, it can return `true` to stop processing. If an exception isn't handled by any exception handler, then control falls back to the default behavior and options from the middleware. Different metrics and logs are emitted for handled versus unhandled exceptions.

The following example shows an `IExceptionHandler` implementation:

:::code language="csharp" source="~/fundamentals/error-handling/samples/8.x/ErrorHandlingSample/CustomExceptionHandler.cs":::

The following example shows how to register an `IExceptionHandler` implementation for dependency injection:

:::code language="csharp" source="~/fundamentals/error-handling/samples/8.x/ErrorHandlingSample/Program.cs" id="snippet_RegisterIExceptionHandler" highlight="7":::

When the preceding code runs in the Development environment:

* The `CustomExceptionHandler` is called first to handle an exception.
* After logging the exception, the `TryHandleException` method returns `false`, so the [developer exception page](#developer-exception-page) is shown.

In other environments:

* The `CustomExceptionHandler` is called first to handle an exception.
* After logging the exception, the `TryHandleException` method returns `false`, so the [`/Error` page](#exception-handler-page) is shown.

<!-- links to this in other docs require sestatuscodepages -->
<a name="sestatuscodepages"></a>

## UseStatusCodePages

By default, an ASP.NET Core app doesn't provide a status code page for HTTP error status codes, such as *404 - Not Found*. When the app sets an HTTP 400-599 error status code that doesn't have a body, it returns the status code and an empty response body. To enable default text-only handlers for common error status codes, call <xref:Microsoft.AspNetCore.Builder.StatusCodePagesExtensions.UseStatusCodePages%2A> in `Program.cs`:

:::code language="csharp" source="~/fundamentals/error-handling/samples/7.x/ErrorHandlingSample/Snippets/Program.cs" id="snippet_UseStatusCodePages" highlight="9":::

Call `UseStatusCodePages` before request handling middleware. For example, call `UseStatusCodePages` before the Static File Middleware and the Endpoints Middleware.

When `UseStatusCodePages` isn't used, navigating to a URL without an endpoint returns a browser-dependent error message indicating the endpoint can't be found. When `UseStatusCodePages` is called, the browser returns the following response:

```console
Status Code: 404; Not Found
```

`UseStatusCodePages` isn't typically used in production because it returns a message that isn't useful to users.

> [!NOTE]
> The status code pages middleware does **not** catch exceptions. To provide a custom error handling page, use the [exception handler page](#exception-handler-page).

### UseStatusCodePages with format string

To customize the response content type and text, use the overload of <xref:Microsoft.AspNetCore.Builder.StatusCodePagesExtensions.UseStatusCodePages%2A> that takes a content type and format string:

:::code language="csharp" source="~/fundamentals/error-handling/samples/7.x/ErrorHandlingSample/Snippets/Program.cs" id="snippet_UseStatusCodePagesContent" highlight="10":::

In the preceding code, `{0}` is a placeholder for the error code.

`UseStatusCodePages` with a format string isn't typically used in production because it returns a message that isn't useful to users.

### UseStatusCodePages with lambda

To specify custom error-handling and response-writing code, use the overload of <xref:Microsoft.AspNetCore.Builder.StatusCodePagesExtensions.UseStatusCodePages%2A> that takes a lambda expression:

:::code language="csharp" source="~/fundamentals/error-handling/samples/7.x/ErrorHandlingSample/Snippets/Program.cs" id="snippet_UseStatusCodePagesInline" highlight="9-16":::

`UseStatusCodePages` with a lambda isn't typically used in production because it returns a message that isn't useful to users.

### UseStatusCodePagesWithRedirects

The <xref:Microsoft.AspNetCore.Builder.StatusCodePagesExtensions.UseStatusCodePagesWithRedirects%2A> extension method:

* Sends a [302 - Found](https://developer.mozilla.org/docs/Web/HTTP/Status/302) status code to the client.
* Redirects the client to the error handling endpoint provided in the URL template. The error handling endpoint typically displays error information and returns HTTP 200.

:::code language="csharp" source="~/fundamentals/error-handling/samples/7.x/ErrorHandlingSample/Snippets/Program.cs" id="snippet_UseStatusCodePagesRedirect" highlight="9":::

The URL template can include a `{0}` placeholder for the status code, as shown in the preceding code. If the URL template starts with `~` (tilde), the `~` is replaced by the app's `PathBase`. When specifying an endpoint in the app, create an MVC view or Razor page for the endpoint.

This method is commonly used when the app:

* Should redirect the client to a different endpoint, usually in cases where a different app processes the error. For web apps, the client's browser address bar reflects the redirected endpoint.
* Shouldn't preserve and return the original status code with the initial redirect response.

### UseStatusCodePagesWithReExecute

The <xref:Microsoft.AspNetCore.Builder.StatusCodePagesExtensions.UseStatusCodePagesWithReExecute%2A> extension method:

* Generates the response body by re-executing the request pipeline using an alternate path.
* Does not alter the status code before or after re-executing the pipeline.

The new pipeline execution may alter the response's status code, as the new pipeline has full control of the status code. If the new pipeline does not alter the status code, the original status code will be sent to the client.

:::code language="csharp" source="~/fundamentals/error-handling/samples/7.x/ErrorHandlingSample/Snippets/Program.cs" id="snippet_UseStatusCodePagesReExecute" highlight="9":::

If an endpoint within the app is specified, create an MVC view or Razor page for the endpoint.

This method is commonly used when the app should:

* Process the request without redirecting to a different endpoint. For web apps, the client's browser address bar reflects the originally requested endpoint.
* Preserve and return the original status code with the response.

The URL template must start with `/` and may include a placeholder `{0}` for the status code. To pass the status code as a query-string parameter, pass a second argument into `UseStatusCodePagesWithReExecute`. For example:

:::code language="csharp" source="~/fundamentals/error-handling/samples/7.x/ErrorHandlingSample/Snippets/Program.cs" id="snippet_UseStatusCodePagesReExecuteQueryString":::

The endpoint that processes the error can get the original URL that generated the error, as shown in the following example:

:::code language="csharp" source="~/fundamentals/error-handling/samples/7.x/ErrorHandlingSample/Pages/StatusCode.cshtml.cs" id="snippet_Class" highlight="12-21":::

Since this middleware can re-execute the request pipeline:

* Middlewares need to handle reentrancy with the same request. This normally means either cleaning up their state after calling `_next` or caching their processing on the `HttpContext` to avoid redoing it. When dealing with the request body, this either means buffering or caching the results like the Form reader.
* Scoped services remain the same.

## Disable status code pages

To disable status code pages for an MVC controller or action method, use the [[SkipStatusCodePages]](xref:Microsoft.AspNetCore.Mvc.SkipStatusCodePagesAttribute) attribute.

To disable status code pages for specific requests in a Razor Pages handler method or in an MVC controller, use <xref:Microsoft.AspNetCore.Diagnostics.IStatusCodePagesFeature>:

:::code language="csharp" source="~/fundamentals/error-handling/samples/7.x/ErrorHandlingSample/Snippets/Pages/Index.cshtml.cs" id="snippet_OnGet":::

## Exception-handling code

Code in exception handling pages can also throw exceptions. Production error pages should be tested thoroughly and take extra care to avoid throwing exceptions of their own.

### Response headers

Once the headers for a response are sent:

* The app can't change the response's status code.
* Any exception pages or handlers can't run. The response must be completed or the connection aborted.

## Server exception handling

In addition to the exception handling logic in an app, the [HTTP server implementation](xref:fundamentals/servers/index) can handle some exceptions. If the server catches an exception before response headers are sent, the server sends a `500 - Internal Server Error` response without a response body. If the server catches an exception after response headers are sent, the server closes the connection. Requests that aren't handled by the app are handled by the server. Any exception that occurs when the server is handling the request is handled by the server's exception handling. The app's custom error pages, exception handling middleware, and filters don't affect this behavior.

## Startup exception handling

Only the hosting layer can handle exceptions that take place during app startup. The host can be configured to [capture startup errors](xref:fundamentals/host/web-host#capture-startup-errors) and [capture detailed errors](xref:fundamentals/host/web-host#detailed-errors).

The hosting layer can show an error page for a captured startup error only if the error occurs after host address/port binding. If binding fails:

* The hosting layer logs a critical exception.
* The dotnet process crashes.
* No error page is displayed when the HTTP server is [Kestrel](xref:fundamentals/servers/kestrel).

When running on [IIS](/iis) (or Azure App Service) or [IIS Express](/iis/extensions/introduction-to-iis-express/iis-express-overview), a *502.5 - Process Failure* is returned by the [ASP.NET Core Module](xref:host-and-deploy/aspnet-core-module) if the process can't start. For more information, see <xref:test/troubleshoot-azure-iis>.

## Database error page

The Database developer page exception filter <xref:Microsoft.Extensions.DependencyInjection.DatabaseDeveloperPageExceptionFilterServiceExtensions.AddDatabaseDeveloperPageExceptionFilter%2A> captures database-related exceptions that can be resolved by using Entity Framework Core migrations. When these exceptions occur, an HTML response is generated with details of possible actions to resolve the issue. This page is enabled only in the Development environment. The following code adds the Database developer page exception filter:

:::code language="csharp" source="~/fundamentals/error-handling/samples/7.x/ErrorHandlingSample/Program.cs" id="snippet_AddDatabaseDeveloperPageExceptionFilter" highlight="3":::

## Exception filters

In MVC apps, exception filters can be configured globally or on a per-controller or per-action basis. In Razor Pages apps, they can be configured globally or per page model. These filters handle any unhandled exceptions that occur during the execution of a controller action or another filter. For more information, see <xref:mvc/controllers/filters#exception-filters>.

Exception filters are useful for trapping exceptions that occur within MVC actions, but they're not as flexible as the built-in [exception handling middleware](https://github.com/dotnet/aspnetcore/blob/main/src/Middleware/Diagnostics/src/ExceptionHandler/ExceptionHandlerMiddleware.cs), <xref:Microsoft.AspNetCore.Builder.ExceptionHandlerExtensions.UseExceptionHandler%2A>. We recommend using `UseExceptionHandler`, unless you need to perform error handling differently based on which MVC action is chosen.

## Model state errors

For information about how to handle model state errors, see [Model binding](xref:mvc/models/model-binding) and [Model validation](xref:mvc/models/validation).

<a name="pds7"></a>

## Problem details

[!INCLUDE[](~/includes/problem-details-service.md)]

The following code configures the app to generate a problem details response for all HTTP client and server error responses that ***don't have a body content yet***:

:::code language="csharp" source="~/fundamentals/error-handling/samples/7.x/ErrorHandlingSample/Snippets/Program.cs" id="snippet_AddProblemDetails" highlight="1":::

The next section shows how to customize the problem details response body.

<a name="cpd7"></a>

### Customize problem details

The automatic creation of a `ProblemDetails` can be customized using any of the following options:

1. Use [`ProblemDetailsOptions.CustomizeProblemDetails`](#customizeproblemdetails-operation)
2. Use a custom [`IProblemDetailsWriter`](#custom-iproblemdetailswriter)
3. Call the [`IProblemDetailsService` in a middleware](#problem-details-from-middleware)

#### `CustomizeProblemDetails` operation

The generated problem details can be customized using <xref:Microsoft.AspNetCore.Http.ProblemDetailsOptions.CustomizeProblemDetails>, and the customizations are applied to all auto-generated problem details.

The following code uses <xref:Microsoft.AspNetCore.Http.ProblemDetailsOptions> to set <xref:Microsoft.AspNetCore.Http.ProblemDetailsOptions.CustomizeProblemDetails>:

:::code language="csharp" source="~/fundamentals/error-handling/samples/7.x/ErrorHandlingSample/Snippets/Program.cs" id="snippet_CustomizeProblemDetails" highlight="3-5":::

For example, an [`HTTP Status 400 Bad Request`](https://developer.mozilla.org/docs/Web/HTTP/Status/400) endpoint result produces the following problem details response body:

```json
{
  "type": "https://tools.ietf.org/html/rfc9110#section-15.5.1",
  "title": "Bad Request",
  "status": 400,
  "nodeId": "my-machine-name"
}
```

#### Custom `IProblemDetailsWriter`

An <xref:Microsoft.AspNetCore.Http.IProblemDetailsWriter> implementation can be created for advanced customizations.

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/problem-details-service/SampleProblemDetailsWriter.cs" :::

***Note:*** When using a custom `IProblemDetailsWriter`, the custom `IProblemDetailsWriter` must be registered before calling <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddRazorPages%2A>, <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddControllers%2A>, <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddControllersWithViews%2A>, or <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddMvc%2A>:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/problem-details-service/Program.cs" id="snippet_sampleproblemdetailswriter" :::

#### Problem details from Middleware

An alternative approach to using <xref:Microsoft.AspNetCore.Http.ProblemDetailsOptions> with <xref:Microsoft.AspNetCore.Http.ProblemDetailsOptions.CustomizeProblemDetails> is to set the <xref:Microsoft.AspNetCore.Http.ProblemDetailsContext.ProblemDetails> in middleware. A problem details response can be written by calling [`IProblemDetailsService.WriteAsync`](/dotnet/api/microsoft.aspnetcore.http.iproblemdetailsservice.writeasync?view=aspnetcore-7.0&preserve-view=true):

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/problem-details-service/Program.cs" id="snippet_middleware" highlight="5,19-40":::

In the preceding code, the minimal API endpoints `/divide` and `/squareroot` return the expected custom problem response on error input.

The API controller endpoints return the default problem response on error input, not the custom problem response. The default problem response is returned because the API controller has written to the response stream, [Problem details for error status codes](/aspnet/core/web-api/#problem-details-for-error-status-codes-1), before [`IProblemDetailsService.WriteAsync`](https://github.com/dotnet/aspnetcore/blob/ce2db7ea0b161fc5eb35710fca6feeafeeac37bc/src/Http/Http.Extensions/src/ProblemDetailsService.cs#L24) is called and the response is **not** written again.

The following `ValuesController` returns <xref:Microsoft.AspNetCore.Mvc.BadRequestResult>, which writes to the response stream and therefore prevents the custom problem response from being returned.

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/problem-details-service/Controllers/ValuesController.cs" id="snippet"  highlight="9-17,27-35":::

The following `Values3Controller` returns [`ControllerBase.Problem`](/dotnet/api/microsoft.aspnetcore.mvc.controllerbase.problem) so the expected custom problem result is returned:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/problem-details-service/Controllers/ValuesController.cs" id="snippet3"  highlight="16-21":::

## Produce a ProblemDetails payload for exceptions

Consider the following app:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/problem-details-service/Program.cs" id="snippet_apishort" highlight="4,8":::

In non-development environments, when an exception occurs, the following is a standard [ProblemDetails response](https://datatracker.ietf.org/doc/html/rfc7807) that is returned to the client:

```json
{
"type":"https://tools.ietf.org/html/rfc7231#section-6.6.1",
"title":"An error occurred while processing your request.",
"status":500,"traceId":"00-b644<snip>-00"
}
```

For most apps, the preceding code is all that's needed for exceptions. However, the following section shows how to get more detailed problem responses.

An alternative to a [custom exception handler page](xref:fundamentals/error-handling#exception-handler-page) is to provide a lambda to <xref:Microsoft.AspNetCore.Builder.ExceptionHandlerExtensions.UseExceptionHandler%2A>. Using a lambda allows access to the error and writing a problem details response with [`IProblemDetailsService.WriteAsync`](/dotnet/api/microsoft.aspnetcore.http.iproblemdetailsservice.writeasync?view=aspnetcore-7.0&preserve-view=true):

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/problem-details-service/Program.cs" id="snippet_lambda" :::

> [!WARNING]
> Do **not** serve sensitive error information to clients. Serving errors is a security risk.

An alternative approach to generate problem details is to use the third-party NuGet package [Hellang.Middleware.ProblemDetails](https://www.nuget.org/packages/Hellang.Middleware.ProblemDetails/) that can be used to map exceptions and client errors to problem details.

## Additional resources

* [View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/error-handling/samples) ([how to download](xref:index#how-to-download-a-sample))
* <xref:test/troubleshoot-azure-iis>
* <xref:host-and-deploy/azure-iis-errors-reference>
* <xref:web-api/handle-errors>
* <xref:fundamentals/minimal-apis/handle-errors>.

:::moniker-end

[!INCLUDE[](~/fundamentals/error-handling/includes/error-handling3-7.md)]
