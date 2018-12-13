---
title: Handle errors in ASP.NET Core
author: tdykstra
description: Discover how to handle errors in ASP.NET Core apps.
ms.author: tdykstra
ms.custom: mvc
ms.date: 11/01/2018
uid: fundamentals/error-handling
---
# Handle errors in ASP.NET Core

By [Steve Smith](https://ardalis.com/) and [Tom Dykstra](https://github.com/tdykstra/)

This article covers common approaches to handling errors in ASP.NET Core apps.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/error-handling/samples/2.x/ErrorHandlingSample) ([how to download](xref:index#how-to-download-a-sample))

## The Developer Exception Page

::: moniker range=">= aspnetcore-2.1"

To configure an app to display a page that shows detailed information about exceptions, use the *Developer Exception Page*. The page is made available by the [Microsoft.AspNetCore.Diagnostics](https://www.nuget.org/packages/Microsoft.AspNetCore.Diagnostics/) package, which is available in the [Microsoft.AspNetCore.App metapackage](xref:fundamentals/metapackage-app). Add a line to the `Startup.Configure` method:

::: moniker-end

::: moniker range="= aspnetcore-2.0"

To configure an app to display a page that shows detailed information about exceptions, use the *Developer Exception Page*. The page is made available by the [Microsoft.AspNetCore.Diagnostics](https://www.nuget.org/packages/Microsoft.AspNetCore.Diagnostics/) package, which is available in the [Microsoft.AspNetCore.All metapackage](xref:fundamentals/metapackage). Add a line to the `Startup.Configure` method:

::: moniker-end

::: moniker range="< aspnetcore-2.0"

To configure an app to display a page that shows detailed information about exceptions, use the *Developer Exception Page*. The page is made available by adding a package reference for the [Microsoft.AspNetCore.Diagnostics](https://www.nuget.org/packages/Microsoft.AspNetCore.Diagnostics/) package in the project file. Add a line to the `Startup.Configure` method:

::: moniker-end

[!code-csharp[](error-handling/samples/2.x/ErrorHandlingSample/Startup.cs?name=snippet_DevExceptionPage&highlight=7)]

Place the call to [UseDeveloperExceptionPage](/dotnet/api/microsoft.aspnetcore.builder.developerexceptionpageextensions.usedeveloperexceptionpage) in front of any middleware where you want to catch exceptions, such as `app.UseMvc`.

> [!WARNING]
> Enable the Developer Exception Page **only when the app is running in the Development environment**. You don't want to share detailed exception information publicly when the app runs in production. [Learn more about configuring environments](xref:fundamentals/environments).

To see the Developer Exception Page, run the sample app with the environment set to `Development` and add `?throw=true` to the base URL of the app. The page includes several tabs with information about the exception and the request. The first tab includes a stack trace:

![Stack trace](error-handling/_static/developer-exception-page.png)

The next tab shows the query string parameters, if any:

![Query string parameters](error-handling/_static/developer-exception-page-query.png)

If the request has cookies, they appear on the **Cookies** tab. Headers are seen in the last tab:

![Headers](error-handling/_static/developer-exception-page-headers.png)

## Configure a custom exception handling page

Configure an exception handler page to use when the app isn't running in the `Development` environment:

[!code-csharp[](error-handling/samples/2.x/ErrorHandlingSample/Startup.cs?name=snippet_DevExceptionPage&highlight=11)]

In a Razor Pages app, the [dotnet new](/dotnet/core/tools/dotnet-new) Razor Pages template provides an Error page and an error `PageModel` class in the *Pages* folder.

In an MVC app, don't decorate the error handler action method with HTTP method attributes, such as `HttpGet`. Explicit verbs prevent some requests from reaching the method. Allow anonymous access to the method so that unauthenticated users are able to receive the error view.

For example, the following error handler method is provided by the [dotnet new](/dotnet/core/tools/dotnet-new) MVC template and appears in the Home controller:

```csharp
[AllowAnonymous]
public IActionResult Error()
{
    return View(new ErrorViewModel 
        { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}
```

## Configure status code pages

By default, an app doesn't provide a rich status code page for HTTP status codes, such as *404 Not Found*. To provide status code pages, use Status Code Pages Middleware.

::: moniker range=">= aspnetcore-2.1"

The middleware is made available by the [Microsoft.AspNetCore.Diagnostics](https://www.nuget.org/packages/Microsoft.AspNetCore.Diagnostics/) package, which is available in the [Microsoft.AspNetCore.App metapackage](xref:fundamentals/metapackage-app).

::: moniker-end

::: moniker range="= aspnetcore-2.0"

The middleware is made available by the [Microsoft.AspNetCore.Diagnostics](https://www.nuget.org/packages/Microsoft.AspNetCore.Diagnostics/) package, which is available in the [Microsoft.AspNetCore.All metapackage](xref:fundamentals/metapackage).

::: moniker-end

::: moniker range="< aspnetcore-2.0"

The middleware is made available by adding a package reference for the [Microsoft.AspNetCore.Diagnostics](https://www.nuget.org/packages/Microsoft.AspNetCore.Diagnostics/) package in the project file.

::: moniker-end

Add a line to the `Startup.Configure` method:

```csharp
app.UseStatusCodePages();
```

<xref:Microsoft.AspNetCore.Builder.StatusCodePagesExtensions.UseStatusCodePages*> should be called before request handling middlewares in the pipeline (for example, Static File Middleware and MVC Middleware).

By default, Status Code Pages Middleware adds text-only handlers for common status codes, such as 404:

![404 page](error-handling/_static/default-404-status-code.png)

The middleware supports several extension methods. One method takes a lambda expression:

[!code-csharp[](error-handling/samples/2.x/ErrorHandlingSample/Startup.cs?name=snippet_StatusCodePages)]

An overload of `UseStatusCodePages` takes a content type and format string:

```csharp
app.UseStatusCodePages("text/plain", "Status code page, status code: {0}");
```
### Redirect re-execute extension methods

<xref:Microsoft.AspNetCore.Builder.StatusCodePagesExtensions.UseStatusCodePagesWithRedirects*>:

* Sends a *302 - Found* status code to the client.
* Redirects the client to the location provided in the URL template. 

The template may include a `{0}` placeholder for the status code. The template must start with a forward slash (`/`).

[!code-csharp[](error-handling/samples/2.x/ErrorHandlingSample/Startup.cs?name=snippet_StatusCodePagesWithRedirect)]

<xref:Microsoft.AspNetCore.Builder.StatusCodePagesExtensions.UseStatusCodePagesWithReExecute*>:

* Returns the original status code to the client.
* Specifies that the response body should be generated by re-executing the request pipeline using an alternate path. 

The template may include a `{0}` placeholder for the status code. The template must start with a forward slash (`/`).

```csharp
app.UseStatusCodePagesWithReExecute("/error/{0}");
```

Status code pages can be disabled for specific requests in a Razor Pages handler method or in an MVC controller. To disable status code pages, attempt to retrieve the [IStatusCodePagesFeature](/dotnet/api/microsoft.aspnetcore.diagnostics.istatuscodepagesfeature) from the request's [HttpContext.Features](/dotnet/api/microsoft.aspnetcore.http.httpcontext.features) collection and disable the feature if it's available:

```csharp
var statusCodePagesFeature = HttpContext.Features.Get<IStatusCodePagesFeature>();

if (statusCodePagesFeature != null)
{
    statusCodePagesFeature.Enabled = false;
}
```

To use a `UseStatusCodePages*` overload that points to an endpoint within the app, create an MVC view or Razor Page for the endpoint. For example, the [dotnet new](/dotnet/core/tools/dotnet-new) template for a Razor Pages app produces the following page and page model class:

*Error.cshtml*:

```cshtml
@page
@model ErrorModel
@{
    ViewData["Title"] = "Error";
}

<h1 class="text-danger">Error.</h1>
<h2 class="text-danger">An error occurred while processing your request.</h2>

@if (Model.ShowRequestId)
{
    <p>
        <strong>Request ID:</strong> <code>@Model.RequestId</code>
    </p>
}

<h3>Development Mode</h3>
<p>
    Swapping to <strong>Development</strong> environment will display more detailed 
    information about the error that occurred.
</p>
<p>
    <strong>Development environment should not be enabled in deployed applications
    </strong>, as it can result in sensitive information from exceptions being 
    displayed to end users. For local debugging, development environment can be 
    enabled by setting the <strong>ASPNETCORE_ENVIRONMENT</strong> environment 
    variable to <strong>Development</strong>, and restarting the application.
</p>
```

*Error.cshtml.cs*:

```csharp
public class ErrorModel : PageModel
{
    public string RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, 
        NoStore = true)]
    public void OnGet()
    {
        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
    }
}
```

## Exception-handling code

Code in exception handling pages can throw exceptions. It's often a good idea for production error pages to consist of purely static content.

Also, be aware that once the headers for a response have been sent, you can't change the response's status code, nor can any exception pages or handlers run. The response must be completed or the connection aborted.

## Server exception handling

In addition to the exception handling logic in your app, the [server](xref:fundamentals/servers) hosting your app performs some exception handling. If the server catches an exception before the headers are sent, the server sends a *500 Internal Server Error* response with no body. If the server catches an exception after the headers have been sent, the server closes the connection. Requests that aren't handled by your app are handled by the server. Any exception that occurs is handled by the server's exception handling. Any configured custom error pages or exception handling middleware or filters don't affect this behavior.

## Startup exception handling

Only the hosting layer can handle exceptions that take place during app startup. Using the [Web Host](xref:fundamentals/host/web-host), you can [configure how the host behaves in response to errors during startup](xref:fundamentals/host/web-host#detailed-errors) with the `captureStartupErrors` and `detailedErrors` keys.

Hosting can only show an error page for a captured startup error if the error occurs after host address/port binding. If any binding fails for any reason, the hosting layer logs a critical exception, the dotnet process crashes, and no error page is displayed when the app is running on the [Kestrel](xref:fundamentals/servers/kestrel) server.

When running on [IIS](/iis) or [IIS Express](/iis/extensions/introduction-to-iis-express/iis-express-overview), a *502.5 Process Failure* is returned by the [ASP.NET Core Module](xref:host-and-deploy/aspnet-core-module) if the process can't be started. For information on troubleshooting startup issues when hosting with IIS, see <xref:host-and-deploy/iis/troubleshoot>. For information on troubleshooting startup issues with Azure App Service, see <xref:host-and-deploy/azure-apps/troubleshoot>.

## ASP.NET Core MVC error handling

[MVC](xref:mvc/overview) apps have some additional options for handling errors, such as configuring exception filters and performing model validation.

### Exception filters

Exception filters can be configured globally or on a per-controller or per-action basis in an MVC app. These filters handle any unhandled exception that occurs during the execution of a controller action or another filter. These filters aren't called otherwise. To learn more, see [Filters](xref:mvc/controllers/filters).

> [!TIP]
> Exception filters are good for trapping exceptions that occur within MVC actions, but they're not as flexible as error handling middleware. Generally prefer the use of middleware, and use filters only where you need to perform error handling *differently* based on which MVC action is chosen.

### Handling model state errors

[Model validation](xref:mvc/models/validation) occurs prior to invoking each controller action, and it's the action method's responsibility to inspect `ModelState.IsValid` and react appropriately.

Some apps choose to follow a standard convention for dealing with model validation errors, in which case a [filter](xref:mvc/controllers/filters) may be an appropriate place to implement such a policy. You should test how your actions behave with invalid model states. Learn more in [Test controller logic](xref:mvc/controllers/testing).

## Additional resources

* <xref:host-and-deploy/azure-iis-errors-reference>
* <xref:host-and-deploy/iis/troubleshoot>
* <xref:host-and-deploy/azure-apps/troubleshoot>
