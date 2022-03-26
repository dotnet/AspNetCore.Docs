---
title: Handle errors in ASP.NET Core
author: rick-anderson
description: Discover how to handle errors in ASP.NET Core apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/09/2021
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: fundamentals/error-handling
---
# Handle errors in ASP.NET Core

:::moniker range=">= aspnetcore-6.0"

By [Kirk Larkin](https://twitter.com/serpent5), [Tom Dykstra](https://github.com/tdykstra/), and [Steve Smith](https://ardalis.com/)

This article covers common approaches to handling errors in ASP.NET Core web apps. See <xref:web-api/handle-errors> for web APIs.

## Developer exception page

The *Developer Exception Page* displays detailed information about unhandled request exceptions. ASP.NET Core apps enable the developer exception page by default when running in the [Development environment](xref:fundamentals/environments).

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

In the following example, <xref:Microsoft.AspNetCore.Builder.ExceptionHandlerExtensions.UseExceptionHandler%2A> adds the exception handling middleware in non-Development environments:

:::code language="csharp" source="error-handling/samples/6.x/ErrorHandlingSample/Program.cs" id="snippet_UseExceptionHandler" highlight="3,5":::

The Razor Pages app template provides an Error page (`.cshtml`) and <xref:Microsoft.AspNetCore.Mvc.RazorPages.PageModel> class (`ErrorModel`) in the *Pages* folder. For an MVC app, the project template includes an `Error` action method and an Error view for the Home controller.

The exception handling middleware re-executes the request using the *original* HTTP method. If an error handler endpoint is restricted to a specific set of HTTP methods, it runs only for those HTTP methods. For example, an MVC controller action that uses the `[HttpGet]` attribute runs only for GET requests. To ensure that *all* requests reach the custom error handling page, don't restrict them to a specific set of HTTP methods.

To handle exceptions differently based on the original HTTP method:

* For Razor Pages, create multiple handler methods. For example, use `OnGet` to handle GET exceptions and use `OnPost` to handle POST exceptions.
* For MVC, apply HTTP verb attributes to multiple actions. For example, use `[HttpGet]` to handle GET exceptions and use `[HttpPost]` to handle POST exceptions.

To allow unauthenticated users to view the custom error handling page, ensure that it supports anonymous access.

### Access the exception

Use <xref:Microsoft.AspNetCore.Diagnostics.IExceptionHandlerPathFeature> to access the exception and the original request path in an error handler. The following example uses `IExceptionHandlerPathFeature` to get more information about the exception that was thrown:

:::code language="csharp" source="error-handling/samples/6.x/ErrorHandlingSample/Pages/Error.cshtml.cs" id="snippet_Class" highlight="15-27":::

> [!WARNING]
> Do **not** serve sensitive error information to clients. Serving errors is a security risk.

## Exception handler lambda

An alternative to a [custom exception handler page](#exception-handler-page) is to provide a lambda to <xref:Microsoft.AspNetCore.Builder.ExceptionHandlerExtensions.UseExceptionHandler%2A>. Using a lambda allows access to the error before returning the response.

The following code uses a lambda for exception handling:

:::code language="csharp" source="error-handling/samples/6.x/ErrorHandlingSample/Snippets/Program.cs" id="snippet_UseExceptionHandlerInline" highlight="5-29":::

> [!WARNING]
> Do **not** serve sensitive error information to clients. Serving errors is a security risk.

## UseStatusCodePages

By default, an ASP.NET Core app doesn't provide a status code page for HTTP error status codes, such as *404 - Not Found*. When the app sets an HTTP 400-599 error status code that doesn't have a body, it returns the status code and an empty response body. To enable default text-only handlers for common error status codes, call <xref:Microsoft.AspNetCore.Builder.StatusCodePagesExtensions.UseStatusCodePages%2A> in `Program.cs`:

:::code language="csharp" source="error-handling/samples/6.x/ErrorHandlingSample/Snippets/Program.cs" id="snippet_UseStatusCodePages" highlight="9":::

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

:::code language="csharp" source="error-handling/samples/6.x/ErrorHandlingSample/Snippets/Program.cs" id="snippet_UseStatusCodePagesContent" highlight="10":::

In the preceding code, `{0}` is a placeholder for the error code.

`UseStatusCodePages` with a format string isn't typically used in production because it returns a message that isn't useful to users.

### UseStatusCodePages with lambda

To specify custom error-handling and response-writing code, use the overload of <xref:Microsoft.AspNetCore.Builder.StatusCodePagesExtensions.UseStatusCodePages%2A> that takes a lambda expression:

:::code language="csharp" source="error-handling/samples/6.x/ErrorHandlingSample/Snippets/Program.cs" id="snippet_UseStatusCodePagesInline" highlight="9-16":::

`UseStatusCodePages` with a lambda isn't typically used in production because it returns a message that isn't useful to users.

### UseStatusCodePagesWithRedirects

The <xref:Microsoft.AspNetCore.Builder.StatusCodePagesExtensions.UseStatusCodePagesWithRedirects%2A> extension method:

* Sends a [302 - Found](https://developer.mozilla.org/docs/Web/HTTP/Status/302) status code to the client.
* Redirects the client to the error handling endpoint provided in the URL template. The error handling endpoint typically displays error information and returns HTTP 200.

:::code language="csharp" source="error-handling/samples/6.x/ErrorHandlingSample/Snippets/Program.cs" id="snippet_UseStatusCodePagesRedirect" highlight="9":::

The URL template can include a `{0}` placeholder for the status code, as shown in the preceding code. If the URL template starts with `~` (tilde), the `~` is replaced by the app's `PathBase`. When specifying an endpoint in the app, create an MVC view or Razor page for the endpoint.

This method is commonly used when the app:

* Should redirect the client to a different endpoint, usually in cases where a different app processes the error. For web apps, the client's browser address bar reflects the redirected endpoint.
* Shouldn't preserve and return the original status code with the initial redirect response.

### UseStatusCodePagesWithReExecute

The <xref:Microsoft.AspNetCore.Builder.StatusCodePagesExtensions.UseStatusCodePagesWithReExecute%2A> extension method:

* Returns the original status code to the client.
* Generates the response body by re-executing the request pipeline using an alternate path.

:::code language="csharp" source="error-handling/samples/6.x/ErrorHandlingSample/Snippets/Program.cs" id="snippet_UseStatusCodePagesReExecute" highlight="9":::

If an endpoint within the app is specified, create an MVC view or Razor page for the endpoint.

This method is commonly used when the app should:

* Process the request without redirecting to a different endpoint. For web apps, the client's browser address bar reflects the originally requested endpoint.
* Preserve and return the original status code with the response.

The URL template must start with `/` and may include a placeholder `{0}` for the status code. To pass the status code as a query-string parameter, pass a second argument into `UseStatusCodePagesWithReExecute`. For example:

:::code language="csharp" source="error-handling/samples/6.x/ErrorHandlingSample/Snippets/Program.cs" id="snippet_UseStatusCodePagesReExecuteQueryString":::

The endpoint that processes the error can get the original URL that generated the error, as shown in the following example:

:::code language="csharp" source="error-handling/samples/6.x/ErrorHandlingSample/Pages/StatusCode.cshtml.cs" id="snippet_Class" highlight="12-21":::

## Disable status code pages

To disable status code pages for an MVC controller or action method, use the [[SkipStatusCodePages]](xref:Microsoft.AspNetCore.Mvc.SkipStatusCodePagesAttribute) attribute.

To disable status code pages for specific requests in a Razor Pages handler method or in an MVC controller, use <xref:Microsoft.AspNetCore.Diagnostics.IStatusCodePagesFeature>:

:::code language="csharp" source="error-handling/samples/6.x/ErrorHandlingSample/Snippets/Pages/Index.cshtml.cs" id="snippet_OnGet":::

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

:::code language="csharp" source="error-handling/samples/6.x/ErrorHandlingSample/Program.cs" id="snippet_AddDatabaseDeveloperPageExceptionFilter" highlight="3":::

## Exception filters

In MVC apps, exception filters can be configured globally or on a per-controller or per-action basis. In Razor Pages apps, they can be configured globally or per page model. These filters handle any unhandled exceptions that occur during the execution of a controller action or another filter. For more information, see <xref:mvc/controllers/filters#exception-filters>.

Exception filters are useful for trapping exceptions that occur within MVC actions, but they're not as flexible as the built-in [exception handling middleware](https://github.com/dotnet/aspnetcore/blob/main/src/Middleware/Diagnostics/src/ExceptionHandler/ExceptionHandlerMiddleware.cs), <xref:Microsoft.AspNetCore.Builder.ExceptionHandlerExtensions.UseExceptionHandler%2A>. We recommend using `UseExceptionHandler`, unless you need to perform error handling differently based on which MVC action is chosen.

## Model state errors

For information about how to handle model state errors, see [Model binding](xref:mvc/models/model-binding) and [Model validation](xref:mvc/models/validation).

## Additional resources

* [View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/error-handling/samples) ([how to download](xref:index#how-to-download-a-sample))
* <xref:test/troubleshoot-azure-iis>
* <xref:host-and-deploy/azure-iis-errors-reference>

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

By [Kirk Larkin](https://twitter.com/serpent5), [Tom Dykstra](https://github.com/tdykstra/), and [Steve Smith](https://ardalis.com/)

This article covers common approaches to handling errors in ASP.NET Core web apps. See <xref:web-api/handle-errors> for web APIs.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/error-handling/samples). ([How to download](xref:index#how-to-download-a-sample).) The network tab on the F12 browser developer tools is useful when testing the sample app.

## Developer Exception Page

The *Developer Exception Page* displays detailed information about unhandled request exceptions. The ASP.NET Core templates generate the following code:

:::code language="csharp" source="error-handling/samples/5.x/ErrorHandlingSample/Startup.cs" id="snippet" highlight="3-6":::

The preceding highlighted code enables the developer exception page when the app is running in the [Development environment](xref:fundamentals/environments).

The templates place <xref:Microsoft.AspNetCore.Builder.DeveloperExceptionPageExtensions.UseDeveloperExceptionPage%2A> early in the middleware pipeline so that it can catch unhandled exceptions thrown in middleware that follows.

The preceding code enables the Developer Exception Page ***only*** when the app runs in the Development environment. Detailed exception information shouldn't be displayed publicly when the app runs in the Production environment. For more information on configuring environments, see <xref:fundamentals/environments>.

The Developer Exception Page can include the following information about the exception and the request:

* Stack trace
* Query string parameters if any
* Cookies if any
* Headers

The Developer Exception Page isn't guaranteed to provide any information. Use [Logging](xref:fundamentals/logging/index) for complete error information.

## Exception handler page

To configure a custom error handling page for the [Production environment](xref:fundamentals/environments), call <xref:Microsoft.AspNetCore.Builder.ExceptionHandlerExtensions.UseExceptionHandler%2A>. This exception handling middleware:

* Catches and logs unhandled exceptions.
* Re-executes the request in an alternate pipeline using the path indicated. The request isn't re-executed if the response has started. The template-generated code re-executes the request using the `/Error` path.

> [!WARNING]
> If the alternate pipeline throws an exception of its own, Exception Handling Middleware rethrows the original exception.

In the following example, <xref:Microsoft.AspNetCore.Builder.ExceptionHandlerExtensions.UseExceptionHandler%2A> adds the exception handling middleware in non-Development environments:

:::code language="csharp" source="error-handling/samples/5.x/ErrorHandlingSample/Startup.cs" id="snippet_DevPageAndHandlerPage" highlight="5-9":::

The Razor Pages app template provides an Error page (`.cshtml`) and <xref:Microsoft.AspNetCore.Mvc.RazorPages.PageModel> class (`ErrorModel`) in the *Pages* folder. For an MVC app, the project template includes an `Error` action method and an Error view for the Home controller.

The exception handling middleware re-executes the request using the *original* HTTP method. If an error handler endpoint is restricted to a specific set of HTTP methods, it runs only for those HTTP methods. For example, an MVC controller action that uses the `[HttpGet]` attribute runs only for GET requests. To ensure that *all* requests reach the custom error handling page, don't restrict them to a specific set of HTTP methods.

To handle exceptions differently based on the original HTTP method:

* For Razor Pages, create multiple handler methods. For example, use `OnGet` to handle GET exceptions and use `OnPost` to handle POST exceptions.
* For MVC, apply HTTP verb attributes to multiple actions. For example, use `[HttpGet]` to handle GET exceptions and use `[HttpPost]` to handle POST exceptions.

To allow unauthenticated users to view the custom error handling page, ensure that it supports anonymous access.

### Access the exception

Use <xref:Microsoft.AspNetCore.Diagnostics.IExceptionHandlerPathFeature> to access the exception and the original request path in an error handler. The following code adds `ExceptionMessage` to the default `Pages/Error.cshtml.cs` generated by the ASP.NET Core templates:

:::code language="csharp" source="error-handling/samples/5.x/ErrorHandlingSample/Pages/Error.cshtml.cs" id="snippet":::

> [!WARNING]
> Do **not** serve sensitive error information to clients. Serving errors is a security risk.

To test the exception in the [sample app](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/error-handling/samples/5.x):

* Set the environment to production.
* Remove the comments from `webBuilder.UseStartup<Startup>();` in `Program.cs`.
* Select **Trigger an exception** on the home page.

## Exception handler lambda

An alternative to a [custom exception handler page](#exception-handler-page) is to provide a lambda to <xref:Microsoft.AspNetCore.Builder.ExceptionHandlerExtensions.UseExceptionHandler%2A>. Using a lambda allows access to the error before returning the response.

The following code uses a lambda for exception handling:

:::code language="csharp" source="error-handling/samples/5.x/ErrorHandlingSample/StartupLambda.cs" id="snippet":::

<!-- 
In the preceding code, `await context.Response.WriteAsync(new string(' ', 512));` is added so the Internet Explorer browser displays the error message rather than an IE error message. For more information, see [this GitHub issue](https://github.com/dotnet/AspNetCore.Docs/issues/16144).
-->

> [!WARNING]
> Do **not** serve sensitive error information from <xref:Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature> or <xref:Microsoft.AspNetCore.Diagnostics.IExceptionHandlerPathFeature> to clients. Serving errors is a security risk.

To test the exception handling lambda in the [sample app](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/error-handling/samples/5.x):

* Set the environment to production.
* Remove the comments from `webBuilder.UseStartup<StartupLambda>();` in `Program.cs`.
* Select **Trigger an exception** on the home page.

## UseStatusCodePages

By default, an ASP.NET Core app doesn't provide a status code page for HTTP error status codes, such as *404 - Not Found*. When the app sets an HTTP 400-599 error status code that doesn't have a body, it returns the status code and an empty response body. To provide status code pages, use the status code pages middleware. To enable default text-only handlers for common error status codes, call <xref:Microsoft.AspNetCore.Builder.StatusCodePagesExtensions.UseStatusCodePages%2A> in the `Startup.Configure` method:

:::code language="csharp" source="error-handling/samples/5.x/ErrorHandlingSample/StartupUseStatusCodePages.cs" id="snippet" highlight="13":::

Call `UseStatusCodePages` before request handling middleware. For example, call `UseStatusCodePages` before the Static File Middleware and the Endpoints Middleware.

When `UseStatusCodePages` isn't used, navigating to a URL without an endpoint returns a browser-dependent error message indicating the endpoint can't be found. For example, navigating to `Home/Privacy2`. When `UseStatusCodePages` is called, the browser returns:

```html
Status Code: 404; Not Found
```

`UseStatusCodePages` isn't typically used in production because it returns a message that isn't useful to users.

To test `UseStatusCodePages` in the [sample app](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/error-handling/samples/5.x):

* Set the environment to production.
* Remove the comments from `webBuilder.UseStartup<StartupUseStatusCodePages>();` in `Program.cs`.
* Select the links on the home page on the home page.

> [!NOTE]
> The status code pages middleware does **not** catch exceptions. To provide a custom error handling page, use the [exception handler page](#exception-handler-page).

### UseStatusCodePages with format string

To customize the response content type and text, use the overload of <xref:Microsoft.AspNetCore.Builder.StatusCodePagesExtensions.UseStatusCodePages%2A> that takes a content type and format string:

:::code language="csharp" source="error-handling/samples/5.x/ErrorHandlingSample/StartupFormat.cs" id="snippet" highlight="13-14":::

In the preceding code, `{0}` is a placeholder for the error code.

`UseStatusCodePages` with a format string isn't typically used in production because it returns a message that isn't useful to users.

To test `UseStatusCodePages` in the [sample app](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/error-handling/samples/5.x), remove the comments from `webBuilder.UseStartup<StartupFormat>();` in `Program.cs`.

### UseStatusCodePages with lambda

To specify custom error-handling and response-writing code, use the overload of <xref:Microsoft.AspNetCore.Builder.StatusCodePagesExtensions.UseStatusCodePages%2A> that takes a lambda expression:

:::code language="csharp" source="error-handling/samples/5.x/ErrorHandlingSample/StartupStatusLambda.cs" id="snippet" highlight="13-20":::

`UseStatusCodePages` with a lambda isn't typically used in production because it returns a message that isn't useful to users.

To test `UseStatusCodePages` in the [sample app](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/error-handling/samples/5.x), remove the comments from `webBuilder.UseStartup<StartupStatusLambda>();` in `Program.cs`.

### UseStatusCodePagesWithRedirects

The <xref:Microsoft.AspNetCore.Builder.StatusCodePagesExtensions.UseStatusCodePagesWithRedirects%2A> extension method:

* Sends a [302 - Found](https://developer.mozilla.org/docs/Web/HTTP/Status/302) status code to the client.
* Redirects the client to the error handling endpoint provided in the URL template. The error handling endpoint typically displays error information and returns HTTP 200.

:::code language="csharp" source="error-handling/samples/5.x/ErrorHandlingSample/StartupSCredirect.cs" id="snippet" highlight="13":::

The URL template can include a `{0}` placeholder for the status code, as shown in the preceding code. If the URL template starts with `~` (tilde), the `~` is replaced by the app's `PathBase`. When specifying an endpoint in the app, create an MVC view or Razor page for the endpoint. For a Razor Pages example, see [Pages/MyStatusCode.cshtml](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/error-handling/samples/5.x/ErrorHandlingSample/Pages) in the [sample app](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/error-handling/samples/5.x).

This method is commonly used when the app:

* Should redirect the client to a different endpoint, usually in cases where a different app processes the error. For web apps, the client's browser address bar reflects the redirected endpoint.
* Shouldn't preserve and return the original status code with the initial redirect response.

To test `UseStatusCodePages` in the [sample app](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/error-handling/samples/5.x), remove the comments from `webBuilder.UseStartup<StartupSCredirect>();` in `Program.cs`.

### UseStatusCodePagesWithReExecute

The <xref:Microsoft.AspNetCore.Builder.StatusCodePagesExtensions.UseStatusCodePagesWithReExecute%2A> extension method:

* Returns the original status code to the client.
* Generates the response body by re-executing the request pipeline using an alternate path.

:::code language="csharp" source="error-handling/samples/5.x/ErrorHandlingSample/StartupSCreX.cs" id="snippet" highlight="13":::

If an endpoint within the app is specified, create an MVC view or Razor page for the endpoint. Ensure `UseStatusCodePagesWithReExecute` is placed before `UseRouting` so the request can be rerouted to the status page. For a Razor Pages example, see [Pages/MyStatusCode2.cshtml](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/error-handling/samples/5.x/ErrorHandlingSample/Pages) in the [sample app](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/error-handling/samples/5.x).

This method is commonly used when the app should:

* Process the request without redirecting to a different endpoint. For web apps, the client's browser address bar reflects the originally requested endpoint.
* Preserve and return the original status code with the response.

The URL and query string templates may include a placeholder `{0}` for the status code. The URL template must start with `/`.

<!-- Review: removing this. The sample code doesn't use @page "{code?}"
If you want that, it should be @page "{code:int?}"
but that's not required. Original text follows:

When using a placeholder in the path, confirm that the endpoint can process the path segment. For example, a Razor Page for errors should accept the optional path segment value with the `@page` directive:

```cshtml
@page "{code?}"
```
-->

The endpoint that processes the error can get the original URL that generated the error, as shown in the following example:

:::code language="csharp" source="error-handling/samples/5.x/ErrorHandlingSample/Pages/MyStatusCode2.cshtml.cs" id="snippet":::

For a Razor Pages example, see [Pages/MyStatusCode2.cshtml](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/error-handling/samples/5.x/ErrorHandlingSample/Pages) in the [sample app](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/error-handling/samples/5.x).

To test `UseStatusCodePages` in the [sample app](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/error-handling/samples/5.x), remove the comments from `webBuilder.UseStartup<StartupSCreX>();` in `Program.cs`.

## Disable status code pages

To disable status code pages for an MVC controller or action method, use the [[SkipStatusCodePages]](xref:Microsoft.AspNetCore.Mvc.SkipStatusCodePagesAttribute) attribute.

To disable status code pages for specific requests in a Razor Pages handler method or in an MVC controller, use <xref:Microsoft.AspNetCore.Diagnostics.IStatusCodePagesFeature>:

:::code language="csharp" source="error-handling/samples/5.x/ErrorHandlingSample/Pages/Privacy.cshtml.cs" id="snippet":::

## Exception-handling code

Code in exception handling pages can also throw exceptions. Production error pages should be tested thoroughly and take extra care to avoid throwing exceptions of their own.
<!-- Review: original, which is not realistic 
 > It's often a good idea for production error pages to consist of purely static content.

 comments: - after you catch the exception, you need code to log the details and perhaps dynamically create a string with an error message. 
-->

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

The Database developer page exception filter `AddDatabaseDeveloperPageExceptionFilter` captures database-related exceptions that can be resolved by using Entity Framework Core migrations. When these exceptions occur, an HTML response is generated with details of possible actions to resolve the issue. This page is enabled only in the Development environment. The following code was generated by the ASP.NET Core Razor Pages templates when individual user accounts were specified:

:::code language="csharp" source="error-handling/samples/5.x/StartupDBexFilter.cs" id="snippet" highlight="6":::

## Exception filters

In MVC apps, exception filters can be configured globally or on a per-controller or per-action basis. In Razor Pages apps, they can be configured globally or per page model. These filters handle any unhandled exceptions that occur during the execution of a controller action or another filter. For more information, see <xref:mvc/controllers/filters#exception-filters>.

Exception filters are useful for trapping exceptions that occur within MVC actions, but they're not as flexible as the built-in [exception handling middleware](https://github.com/dotnet/aspnetcore/blob/main/src/Middleware/Diagnostics/src/ExceptionHandler/ExceptionHandlerMiddleware.cs), `UseExceptionHandler`. We recommend using `UseExceptionHandler`, unless you need to perform error handling differently based on which MVC action is chosen.

:::code language="csharp" source="error-handling/samples/5.x/ErrorHandlingSample/Startup.cs" id="snippet" highlight="9":::

## Model state errors

For information about how to handle model state errors, see [Model binding](xref:mvc/models/model-binding) and [Model validation](xref:mvc/models/validation).

## Additional resources

* <xref:test/troubleshoot-azure-iis>
* <xref:host-and-deploy/azure-iis-errors-reference>

:::moniker-end

:::moniker range="< aspnetcore-5.0"

By  [Tom Dykstra](https://github.com/tdykstra/), and [Steve Smith](https://ardalis.com/)

This article covers common approaches to handling errors in ASP.NET Core web apps. See <xref:web-api/handle-errors> for web APIs.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/error-handling/samples). ([How to download](xref:index#how-to-download-a-sample).)

## Developer Exception Page

The *Developer Exception Page* displays detailed information about request exceptions. The ASP.NET Core templates generate the following code:

:::code language="csharp" source="error-handling/samples/2.x/ErrorHandlingSample/Startup.cs" id="snippet_DevPageAndHandlerPage" highlight="1-4":::

The preceding code enables the developer exception page when the app is running in the [Development environment](xref:fundamentals/environments).

The templates place <xref:Microsoft.AspNetCore.Builder.DeveloperExceptionPageExtensions.UseDeveloperExceptionPage%2A> before any middleware so exceptions are caught in the middleware that follows.

The preceding code enables the Developer Exception Page **only when the app is running in the Development environment**. Detailed exception information should not be displayed publicly when the app runs in production. For more information on configuring environments, see <xref:fundamentals/environments>.

The Developer Exception Page includes the following information about the exception and the request:

* Stack trace
* Query string parameters if any
* Cookies if any
* Headers

## Exception handler page

To configure a custom error handling page for the Production environment, use the Exception Handling Middleware. The middleware:

* Catches and logs exceptions.
* Re-executes the request in an alternate pipeline for the page or controller indicated. The request isn't re-executed if the response has started. The template generated code re-executes the request to `/Error`.

In the following example, <xref:Microsoft.AspNetCore.Builder.ExceptionHandlerExtensions.UseExceptionHandler%2A> adds the Exception Handling Middleware in non-Development environments:

:::code language="csharp" source="error-handling/samples/2.x/ErrorHandlingSample/Startup.cs" id="snippet_DevPageAndHandlerPage" highlight="5-9":::

The Razor Pages app template provides an Error page (`.cshtml`) and <xref:Microsoft.AspNetCore.Mvc.RazorPages.PageModel> class (`ErrorModel`) in the *Pages* folder. For an MVC app, the project template includes an Error action method and an Error view in the Home controller.

Don't mark the error handler action method with HTTP method attributes, such as `HttpGet`. Explicit verbs prevent some requests from reaching the method. Allow anonymous access to the method if unauthenticated users should see the error view.

### Access the exception

Use <xref:Microsoft.AspNetCore.Diagnostics.IExceptionHandlerPathFeature> to access the exception and the original request path in an error handler controller or page:

:::code language="csharp" source="error-handling/samples/2.x/ErrorHandlingSample/Pages/MyFolder/Error.cshtml.cs" id="snippet_ExceptionHandlerPathFeature":::

> [!WARNING]
> Do **not** serve sensitive error information to clients. Serving errors is a security risk.

To trigger the preceding exception handling page, set the environment to productions and force an exception.

## Exception handler lambda

An alternative to a [custom exception handler page](#exception-handler-page) is to provide a lambda to <xref:Microsoft.AspNetCore.Builder.ExceptionHandlerExtensions.UseExceptionHandler%2A>. Using a lambda allows access to the error before returning the response.

Here's an example of using a lambda for exception handling:

:::code language="csharp" source="error-handling/samples/2.x/ErrorHandlingSample/Startup.cs" id="snippet_HandlerPageLambda":::

In the preceding code, `await context.Response.WriteAsync(new string(' ', 512));` is added so the Internet Explorer browser displays the error message rather than an IE error message. For more information, see [this GitHub issue](https://github.com/dotnet/AspNetCore.Docs/issues/16144).

> [!WARNING]
> Do **not** serve sensitive error information from <xref:Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature> or <xref:Microsoft.AspNetCore.Diagnostics.IExceptionHandlerPathFeature> to clients. Serving errors is a security risk.

To see the result of the exception handling lambda in the [sample app](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/error-handling/samples), use the `ProdEnvironment` and `ErrorHandlerLambda` preprocessor directives, and select **Trigger an exception** on the home page.

## UseStatusCodePages

By default, an ASP.NET Core app doesn't provide a status code page for HTTP status codes, such as *404 - Not Found*. The app returns a status code and an empty response body. To provide status code pages, use Status Code Pages middleware.

The middleware is made available by the [Microsoft.AspNetCore.Diagnostics](https://www.nuget.org/packages/Microsoft.AspNetCore.Diagnostics/) package.

To enable default text-only handlers for common error status codes, call <xref:Microsoft.AspNetCore.Builder.StatusCodePagesExtensions.UseStatusCodePages%2A> in the `Startup.Configure` method:

:::code language="csharp" source="error-handling/samples/2.x/ErrorHandlingSample/Startup.cs" id="snippet_StatusCodePages":::

Call `UseStatusCodePages` before request handling middleware (for example, Static File Middleware and MVC Middleware).

When `UseStatusCodePages` isn't used, navigating to a URL without an endpoint returns a browser dependent error message indicating the endpoint can't be found. For example, navigating to `Home/Privacy2`. When `UseStatusCodePages` is called, the browser returns:

```
Status Code: 404; Not Found
```

## UseStatusCodePages with format string

To customize the response content type and text, use the overload of <xref:Microsoft.AspNetCore.Builder.StatusCodePagesExtensions.UseStatusCodePages%2A> that takes a content type and format string:

:::code language="csharp" source="error-handling/samples/2.x/ErrorHandlingSample/Startup.cs" id="snippet_StatusCodePagesFormatString":::

## UseStatusCodePages with lambda

To specify custom error-handling and response-writing code, use the overload of <xref:Microsoft.AspNetCore.Builder.StatusCodePagesExtensions.UseStatusCodePages%2A> that takes a lambda expression:

:::code language="csharp" source="error-handling/samples/2.x/ErrorHandlingSample/Startup.cs" id="snippet_StatusCodePagesLambda":::

## UseStatusCodePagesWithRedirects

The <xref:Microsoft.AspNetCore.Builder.StatusCodePagesExtensions.UseStatusCodePagesWithRedirects%2A> extension method:

* Sends a *302 - Found* status code to the client.
* Redirects the client to the location provided in the URL template.

:::code language="csharp" source="error-handling/samples/2.x/ErrorHandlingSample/Startup.cs" id="snippet_StatusCodePagesWithRedirect":::

The URL template can include a `{0}` placeholder for the status code, as shown in the example. If the URL template starts with `~` (tilde), the `~` is replaced by the app's `PathBase`. If you point to an endpoint within the app, create an MVC view or Razor page for the endpoint. For a Razor Pages example, see `Pages/StatusCode.cshtml` in the [sample app](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/error-handling/samples).

This method is commonly used when the app:

* Should redirect the client to a different endpoint, usually in cases where a different app processes the error. For web apps, the client's browser address bar reflects the redirected endpoint.
* Shouldn't preserve and return the original status code with the initial redirect response.

## UseStatusCodePagesWithReExecute

The <xref:Microsoft.AspNetCore.Builder.StatusCodePagesExtensions.UseStatusCodePagesWithReExecute%2A> extension method:

* Returns the original status code to the client.
* Generates the response body by re-executing the request pipeline using an alternate path.

:::code language="csharp" source="error-handling/samples/2.x/ErrorHandlingSample/Startup.cs" id="snippet_StatusCodePagesWithReExecute":::

If you point to an endpoint within the app, create an MVC view or Razor page for the endpoint. Ensure `UseStatusCodePagesWithReExecute` is placed before `UseRouting` so the request can be rerouted to the status page. For a Razor Pages example, see `Pages/StatusCode.cshtml` in the [sample app](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/error-handling/samples).

This method is commonly used when the app should:

* Process the request without redirecting to a different endpoint. For web apps, the client's browser address bar reflects the originally requested endpoint.
* Preserve and return the original status code with the response.

The URL and query string templates may include a placeholder (`{0}`) for the status code. The URL template must start with a slash (`/`). When using a placeholder in the path, confirm that the endpoint (page or controller) can process the path segment. For example, a Razor Page for errors should accept the optional path segment value with the `@page` directive:

```cshtml
@page "{code?}"
```

The endpoint that processes the error can get the original URL that generated the error, as shown in the following example:

:::code language="csharp" source="error-handling/samples/2.x/ErrorHandlingSample/Pages/StatusCode.cshtml.cs" id="snippet_StatusCodeReExecute":::

Don't mark the error handler action method with HTTP method attributes, such as `HttpGet`. Explicit verbs prevent some requests from reaching the method. Allow anonymous access to the method if unauthenticated users should see the error view.

## Disable status code pages

To disable status code pages for an MVC controller or action method, use the [`[SkipStatusCodePages]`](xref:Microsoft.AspNetCore.Mvc.SkipStatusCodePagesAttribute) attribute.

To disable status code pages for specific requests in a Razor Pages handler method or in an MVC controller, use <xref:Microsoft.AspNetCore.Diagnostics.IStatusCodePagesFeature>:

```csharp
var statusCodePagesFeature = HttpContext.Features.Get<IStatusCodePagesFeature>();

if (statusCodePagesFeature != null)
{
    statusCodePagesFeature.Enabled = false;
}
```

## Exception-handling code

Code in exception handling pages can throw exceptions. It's often a good idea for production error pages to consist of purely static content.

### Response headers

Once the headers for a response are sent:

* The app can't change the response's status code.
* Any exception pages or handlers can't run. The response must be completed or the connection aborted.

## Server exception handling

In addition to the exception handling logic in your app, the [HTTP server implementation](xref:fundamentals/servers/index) can handle some exceptions. If the server catches an exception before response headers are sent, the server sends a *500 - Internal Server Error* response without a response body. If the server catches an exception after response headers are sent, the server closes the connection. Requests that aren't handled by your app are handled by the server. Any exception that occurs when the server is handling the request is handled by the server's exception handling. The app's custom error pages, exception handling middleware, and filters don't affect this behavior.

## Startup exception handling

Only the hosting layer can handle exceptions that take place during app startup. The host can be configured to [capture startup errors](xref:fundamentals/host/web-host#capture-startup-errors) and [capture detailed errors](xref:fundamentals/host/web-host#detailed-errors).

The hosting layer can show an error page for a captured startup error only if the error occurs after host address/port binding. If binding fails:

* The hosting layer logs a critical exception.
* The dotnet process crashes.
* No error page is displayed when the HTTP server is [Kestrel](xref:fundamentals/servers/kestrel).

When running on [IIS](/iis) (or Azure App Service) or [IIS Express](/iis/extensions/introduction-to-iis-express/iis-express-overview), a *502.5 - Process Failure* is returned by the [ASP.NET Core Module](xref:host-and-deploy/aspnet-core-module) if the process can't start. For more information, see <xref:test/troubleshoot-azure-iis>.

## Database error page

Database Error Page Middleware captures database-related exceptions that can be resolved by using Entity Framework migrations. When these exceptions occur, an HTML response with details of possible actions to resolve the issue is generated. This page should be enabled only in the Development environment. Enable the page by adding code to `Startup.Configure`:

```csharp
if (env.IsDevelopment())
{
    app.UseDatabaseErrorPage();
}
```

<xref:Microsoft.AspNetCore.Builder.DatabaseErrorPageExtensions.UseDatabaseErrorPage%2A> requires the [Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore/) NuGet package.

<!-- FUTURE UPDATE: On the next topic overhaul/release update, add API crosslink to this section for xref:Microsoft.AspNetCore.Builder.DatabaseErrorPageExtensions.UseDatabaseErrorPage* when available via the API docs. -->

## Exception filters

In MVC apps, exception filters can be configured globally or on a per-controller or per-action basis. In Razor Pages apps, they can be configured globally or per page model. These filters handle any unhandled exception that occurs during the execution of a controller action or another filter. For more information, see <xref:mvc/controllers/filters#exception-filters>.

> [!TIP]
> Exception filters are useful for trapping exceptions that occur within MVC actions, but they're not as flexible as the Exception Handling Middleware. We recommend using the middleware. Use filters only where you need to perform error handling differently based on which MVC action is chosen.

## Model state errors

For information about how to handle model state errors, see [Model binding](xref:mvc/models/model-binding) and [Model validation](xref:mvc/models/validation).

## Additional resources

* <xref:test/troubleshoot-azure-iis>
* <xref:host-and-deploy/azure-iis-errors-reference>

:::moniker-end
