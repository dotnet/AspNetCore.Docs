---
title: Access HttpContext in ASP.NET Core
author: coderandhiker
description: Learn about using HttpContext in ASP.NET Core apps. HttpContext isn't thread-safe and can throw an exception when accessed.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 01/31/2022
uid: fundamentals/httpcontext
---
# Access `HttpContext` in ASP.NET Core

:::moniker range=">= aspnetcore-6.0"

<xref:Microsoft.AspNetCore.Http.HttpContext> encapsulates all information about an individual HTTP request and response. An `HttpContext` instance is initialized when an HTTP request is received. The `HttpContext` instance is accessible by middleware and app frameworks such as Web API controllers, Razor Pages, SignalR, gRPC, and more.

For information about using `HttpContext` with a HTTP request and response, see <xref:fundamentals/use-httpcontext>.

## Access `HttpContext` from Razor Pages

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

## Access `HttpContext` from a Razor view in MVC

Razor views in the MVC pattern expose the `HttpContext` via the <xref:Microsoft.AspNetCore.Mvc.Razor.RazorPage.Context%2A?displayProperty=nameWithType> property on the view. The following example retrieves the current username in an intranet app using Windows Authentication:

```cshtml
@{
    var username = Context.User.Identity.Name;
    
    // ...
}
```

## Access `HttpContext` from a controller

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

## Access `HttpContext` from minimal APIs

To use `HttpContext` from minimal APIs, add a `HttpContext` parameter:

```csharp
app.MapGet("/", (HttpContext context) => context.Response.WriteAsync("Hello World"));
```

## Access `HttpContext` from middleware

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

## Access `HttpContext` from SignalR

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

## Access `HttpContext` from gRPC methods

To use `HttpContext` from gRPC methods, see [Resolve `HttpContext` in gRPC methods](xref:grpc/aspnetcore#resolve-httpcontext-in-grpc-methods).

## Access `HttpContext` from custom components

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

## `HttpContext` access from a background thread

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

## `IHttpContextAccessor`/`HttpContext` in Razor components (Blazor)

[!INCLUDE[](~/blazor/security/includes/httpcontext.md)]

:::moniker-end

:::moniker range="< aspnetcore-6.0"
    
<xref:Microsoft.AspNetCore.Http.HttpContext> encapsulates all information about an individual HTTP request and response. An `HttpContext` instance is initialized when an HTTP request is received. The `HttpContext` instance is accessible by middleware and app frameworks such as Web API controllers, Razor Pages, SignalR, gRPC, and more.

For information about using `HttpContext` with a HTTP request and response, see <xref:fundamentals/use-httpcontext>.

## Access `HttpContext` from Razor Pages

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

## Access `HttpContext` from a Razor view in MVC

Razor views in the MVC pattern expose the `HttpContext` via the <xref:Microsoft.AspNetCore.Mvc.Razor.RazorPage.Context%2A?displayProperty=nameWithType> property on the view. The following example retrieves the current username in an intranet app using Windows Authentication:

```cshtml
@{
    var username = Context.User.Identity.Name;
    
    // ...
}
```

## Access `HttpContext` from a controller

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

## Access `HttpContext` from middleware

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

## Access `HttpContext` from custom components

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

## `HttpContext` access from a background thread

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

## `IHttpContextAccessor`/`HttpContext` in Razor components (Blazor)

[!INCLUDE[](~/blazor/security/includes/httpcontext.md)]

:::moniker-end
