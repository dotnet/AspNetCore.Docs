---
title: Access HttpContext in ASP.NET Core
author: coderandhiker
description: HttpContext in ASP.NET Core. HttpContext isn't thread-safe and can throw NullReferenceException.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 01/31/2022
uid: fundamentals/httpcontext
---
# Access HttpContext in ASP.NET Core

:::moniker range=">= aspnetcore-6.0"

ASP.NET Core apps access `HttpContext` through the <xref:Microsoft.AspNetCore.Http.IHttpContextAccessor> interface and its default implementation <xref:Microsoft.AspNetCore.Http.HttpContextAccessor>. It's only necessary to use `IHttpContextAccessor` when you need access to the `HttpContext` inside a service.

## HttpContext isn't thread safe

This article primarily discusses using `HttpContext` in request and response flow from Razor Pages, controllers, middleware, etc. Consider the following when using `HttpContext` outside the request and response flow:

* The `HttpContext` is **NOT** thread safe, accessing it from multiple threads can result in exceptions, data corruption and generally unpredictable results.
* The <xref:Microsoft.AspNetCore.Http.IHttpContextAccessor> interface should be used with caution. As always, the `HttpContext` must ***not*** be captured outside of the request flow.  `IHttpContextAccessor`:
  * Relies on  <xref:System.Threading.AsyncLocal%601> which can have a negative performance impact on asynchronous calls.
  * Creates a dependency on "ambient state" which can make testing more difficult.
* <xref:Microsoft.AspNetCore.Http.IHttpContextAccessor.HttpContext%2A?displayProperty=nameWithType> may be `null` if accessed outside of the request flow.
* To access information from `HttpContext` outside the request flow, copy the information inside the request flow. Be careful to copy the actual data and not just references. For example, rather than copying a reference to an `IHeaderDictionary`, copy the relevant header values or copy the entire dictionary key by key before leaving the request flow.
* Don't capture `IHttpContextAccessor.HttpContext` in a constructor.

The following sample logs GitHub branches when requested from the `/branch` endpoint:

[!code-csharp[](~/fundamentals/http-context/samples/6.x/HttpContextInBackgroundThread/Program.cs?highlight=26-45)]

The GitHub API requires two headers. The `User-Agent` header is added dynamically by the `UserAgentHeaderHandler`:

[!code-csharp[](~/fundamentals/http-context/samples/6.x/HttpContextInBackgroundThread/Program.cs?highlight=10-20)]

The `UserAgentHeaderHandler`:

[!code-csharp[](~/fundamentals/http-context/samples/6.x/HttpContextInBackgroundThread/UserAgentHeaderHandler.cs?highlight=21-29)]

In the preceding code, when the `HttpContext` is `null`, the `userAgent` string is set to `"Unknown"`. If possible, `HttpContext` should be explicitly passed to the service. Explicitly passing in `HttpContext` data:

* Makes the service API more useable outside the request flow.
* Is better for performance.
* Makes the code easier to understand and reason about than relying on ambient state.

When the service must access `HttpContext`, it should account for the possibility of `HttpContext` being `null` when not called from a request thread.

The application also includes `PeriodicBranchesLoggerService`, which logs the open GitHub branches of the specified repository every 30 seconds:

[!code-csharp[](~/fundamentals/http-context/samples/6.x/HttpContextInBackgroundThread/PeriodicBranchesLoggerService.cs)]

`PeriodicBranchesLoggerService` is a [hosted service](xref:fundamentals/host/hosted-services), which runs outside the request and response flow. Logging from the `PeriodicBranchesLoggerService` has a null `HttpContext`. The `PeriodicBranchesLoggerService` was written to not depend on the `HttpContext`.

[!code-csharp[](~/fundamentals/http-context/samples/6.x/HttpContextInBackgroundThread/Program.cs?highlight=8&range=1-11)]

## Use HttpContext from Razor Pages

The Razor Pages <xref:Microsoft.AspNetCore.Mvc.RazorPages.PageModel> exposes the <xref:Microsoft.AspNetCore.Mvc.RazorPages.PageModel.HttpContext?displayProperty=nameWithType> property:

```csharp
public class IndexModel : PageModel
{
    public void OnGet()
    {
        var message = HttpContext.Request.PathBase;

        // ...
    }
}
```

The same property can be used in the corresponding Razor Page View:

```cshtml
@page
@model IndexModel

@{
    var message = HttpContext.Request.PathBase;
    
    // ...
}
```

## Use HttpContext from a Razor view in MVC

Razor views in the MVC pattern expose the `HttpContext` via the <xref:Microsoft.AspNetCore.Mvc.Razor.RazorPage.Context%2A?displayProperty=nameWithType> property on the view. The following example retrieves the current username in an intranet app using Windows Authentication:

```cshtml
@{
    var username = Context.User.Identity.Name;
    
    // ...
}
```

## Use HttpContext from a controller

Controllers expose the <xref:Microsoft.AspNetCore.Mvc.ControllerBase.HttpContext%2A?displayProperty=nameWithType> property:

```csharp
public class HomeController : Controller
{
    public IActionResult About()
    {
        var pathBase = HttpContext.Request.PathBase;

        // ...

        return View();
    }
}
```

## Use HttpContext from minimal APIs

To use `HttpContext` from minimal APIs, add a `HttpContext` parameter:

```csharp
app.MapGet("/", (HttpContext context) => context.Response.WriteAsync("Hello World"));
```

## Use HttpContext from middleware

To use `HttpContext` from custom middleware components, use the `HttpContext` parameter passed into the `Invoke` or `InvokeAsync` method:

```csharp
public class MyCustomMiddleware
{
    // ...

    public async Task InvokeAsync(HttpContext context)
    {
        // ...
    }
}
```

## Use HttpContext from SignalR

To use `HttpContext` from SignalR, call the <xref:Microsoft.AspNetCore.SignalR.GetHttpContextExtensions.GetHttpContext%2A> method on <xref:Microsoft.AspNetCore.SignalR.Hub.Context%2A?displayProperty=nameWithType>:

```csharp
public class MyHub : Hub
{
    public async Task SendMessage()
    {
        var httpContext = Context.GetHttpContext();

        // ...
    }
}
```

## Use HttpContext from gRPC methods

To use `HttpContext` from gRPC methods, see [Resolve HttpContext in gRPC methods](xref:grpc/aspnetcore#resolve-httpcontext-in-grpc-methods).

## Use HttpContext from custom components

For other framework and custom components that require access to `HttpContext`, the recommended approach is to register a dependency using the built-in [Dependency Injection (DI)](xref:fundamentals/dependency-injection) container. The DI container supplies the `IHttpContextAccessor` to any classes that declare it as a dependency in their constructors:

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IUserRepository, UserRepository>();
```

In the following example:

* `UserRepository` declares its dependency on `IHttpContextAccessor`.
* The dependency is supplied when DI resolves the dependency chain and creates an instance of `UserRepository`.

```csharp
public class UserRepository : IUserRepository
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserRepository(IHttpContextAccessor httpContextAccessor) =>
        _httpContextAccessor = httpContextAccessor;

    public void LogCurrentUser()
    {
        var username = _httpContextAccessor.HttpContext.User.Identity.Name;
        
        // ...
    }
}
```

## HttpContext access from a background thread

`HttpContext` isn't thread-safe. Reading or writing properties of the `HttpContext` outside of processing a request can result in a <xref:System.NullReferenceException>.

> [!NOTE]
> If your app generates sporadic `NullReferenceException` errors, review parts of the code that start background processing or that continue processing after a request completes. Look for mistakes, such as defining a controller method as `async void`.

To safely do background work with `HttpContext` data:

* Copy the required data during request processing.
* Pass the copied data to a background task.
* Do ***not*** reference `HttpContext` data in parallel tasks. Extract the data needed from the context before starting the parallel tasks.

To avoid unsafe code, never pass `HttpContext` into a method that does background work. Pass the required data instead. In the following example, `SendEmail` calls `SendEmailCoreAsync` to start sending an email. The value of the `X-Correlation-Id` header is passed to `SendEmailCoreAsync` instead of the `HttpContext`. Code execution doesn't wait for `SendEmailCoreAsync` to complete:

```csharp
public class EmailController : Controller
{
    public IActionResult SendEmail(string email)
    {
        var correlationId = HttpContext.Request.Headers["X-Correlation-Id"].ToString();

        _ = SendEmailCoreAsync(correlationId);

        return View();
    }

    private async Task SendEmailCoreAsync(string correlationId)
    {
        // ...
    }
}
```

## Blazor and shared state

[!INCLUDE[](~/blazor/security/includes/blazor-shared-state.md)]

:::moniker-end

:::moniker range="< aspnetcore-6.0"
    
ASP.NET Core apps access `HttpContext` through the <xref:Microsoft.AspNetCore.Http.IHttpContextAccessor> interface and its default implementation <xref:Microsoft.AspNetCore.Http.HttpContextAccessor>. It's only necessary to use `IHttpContextAccessor` when you need access to the `HttpContext` inside a service.

## Use HttpContext from Razor Pages

The Razor Pages <xref:Microsoft.AspNetCore.Mvc.RazorPages.PageModel> exposes the <xref:Microsoft.AspNetCore.Mvc.RazorPages.PageModel.HttpContext?displayProperty=nameWithType> property:

```csharp
public class IndexModel : PageModel
{
    public void OnGet()
    {
        var message = HttpContext.Request.PathBase;

        // ...
    }
}
```

The same property can be used in the corresponding Razor Page View:

```cshtml
@page
@model IndexModel

@{
    var message = HttpContext.Request.PathBase;
    
    // ...
}
```

## Use HttpContext from a Razor view in MVC

Razor views in the MVC pattern expose the `HttpContext` via the <xref:Microsoft.AspNetCore.Mvc.Razor.RazorPage.Context%2A?displayProperty=nameWithType> property on the view. The following example retrieves the current username in an intranet app using Windows Authentication:

```cshtml
@{
    var username = Context.User.Identity.Name;
    
    // ...
}
```

## Use HttpContext from a controller

Controllers expose the <xref:Microsoft.AspNetCore.Mvc.ControllerBase.HttpContext%2A?displayProperty=nameWithType> property:

```csharp
public class HomeController : Controller
{
    public IActionResult About()
    {
        var pathBase = HttpContext.Request.PathBase;

        // ...

        return View();
    }
}
```

## Use HttpContext from middleware

When working with custom middleware components, `HttpContext` is passed into the `Invoke` or `InvokeAsync` method:

```csharp
public class MyCustomMiddleware
{
    public Task InvokeAsync(HttpContext context)
    {
        // ...
    }
}
```

## Use HttpContext from custom components

For other framework and custom components that require access to `HttpContext`, the recommended approach is to register a dependency using the built-in [Dependency Injection (DI)](xref:fundamentals/dependency-injection) container. The DI container supplies the `IHttpContextAccessor` to any classes that declare it as a dependency in their constructors:

```csharp
public void ConfigureServices(IServiceCollection services)
{
     services.AddControllersWithViews();
     services.AddHttpContextAccessor();
     services.AddTransient<IUserRepository, UserRepository>();
}
```

In the following example:

* `UserRepository` declares its dependency on `IHttpContextAccessor`.
* The dependency is supplied when DI resolves the dependency chain and creates an instance of `UserRepository`.

```csharp
public class UserRepository : IUserRepository
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserRepository(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public void LogCurrentUser()
    {
        var username = _httpContextAccessor.HttpContext.User.Identity.Name;
        service.LogAccessRequest(username);
    }
}
```

## HttpContext access from a background thread

`HttpContext` isn't thread-safe. Reading or writing properties of the `HttpContext` outside of processing a request can result in a <xref:System.NullReferenceException>.

> [!NOTE]
> If your app generates sporadic `NullReferenceException` errors, review parts of the code that start background processing or that continue processing after a request completes. Look for mistakes, such as defining a controller method as `async void`.

To safely do background work with `HttpContext` data:

* Copy the required data during request processing.
* Pass the copied data to a background task.
* Do ***not*** reference `HttpContext` data in parallel tasks. Extract the data needed from the context before starting the parallel tasks.

To avoid unsafe code, never pass the `HttpContext` into a method that does background work. Pass the required data instead. In the following example, `SendEmailCore` is called to start sending an email. The `correlationId` is passed to `SendEmailCore`, not the `HttpContext`. Code execution doesn't wait for `SendEmailCore` to complete:

```csharp
public class EmailController : Controller
{
    public IActionResult SendEmail(string email)
    {
        var correlationId = HttpContext.Request.Headers["x-correlation-id"].ToString();

        _ = SendEmailCore(correlationId);

        return View();
    }

    private async Task SendEmailCore(string correlationId)
    {
        // ...
    }
}
```

## Blazor and shared state

[!INCLUDE[](~/blazor/security/includes/blazor-shared-state.md)]

:::moniker-end
