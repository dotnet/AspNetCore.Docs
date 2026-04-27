---
title: Access HttpContext in ASP.NET Core
author: coderandhiker
description: Learn about using HttpContext in ASP.NET Core apps. HttpContext isn't thread-safe and can throw an exception when accessed.
monikerRange: '>= aspnetcore-3.1'
ms.author: tdykstra
ms.custom: mvc
ms.date: 04/27/2026
uid: fundamentals/httpcontext

# customer intent: As an ASP.NET developer, I want to understand how to access HttpContext in my ASP.NET Core apps, so I can address related exceptions and thread issues.
---
# Access HttpContext in ASP.NET Core

[!INCLUDE[](~/includes/not-latest-version.md)]

The <xref:Microsoft.AspNetCore.Http.HttpContext> encapsulates all information about an individual HTTP request and response. An `HttpContext` instance is initialized when an HTTP request is received. The `HttpContext` instance is accessible by middleware and app frameworks such as Web API controllers, Razor Pages, [SignalR](xref:signalr/introduction), gRPC, and more.

For information about using `HttpContext` with an HTTP request and response, see <xref:fundamentals/use-httpcontext>.

## Access HttpContext from Razor Pages

The Razor Pages <xref:Microsoft.AspNetCore.Mvc.RazorPages.PageModel> exposes the <xref:Microsoft.AspNetCore.Mvc.RazorPages.PageModel.HttpContext> property:

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

You can use the same property in the corresponding Razor Page View:

```cshtml
@page
@model IndexModel

@{
    var message = HttpContext.Request.PathBase;
    
    // ...
}
```

## Access HttpContext from a Razor view in MVC

Razor views in the MVC pattern expose the `HttpContext` via the <xref:Microsoft.AspNetCore.Mvc.Razor.RazorPage.Context%2A> property on the view. The following example retrieves the current username in an intranet app by using Windows Authentication:

```cshtml
@{
    var username = Context.User.Identity.Name;
    
    // ...
}
```

## Access HttpContext from a controller

Controllers expose the <xref:Microsoft.AspNetCore.Mvc.ControllerBase.HttpContext%2A> property:

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

:::moniker range=">= aspnetcore-6.0"

## Access HttpContext from Minimal APIs

To use `HttpContext` from [Minimal APIs](minimal-apis.md):

```csharp
app.MapGet("/", (HttpContext context) => context.Response.WriteAsync("Hello World"));
```

:::moniker-end

## Access HttpContext from middleware

To use `HttpContext` from custom middleware components, pass the `HttpContext` parameter into the `Invoke` or `InvokeAsync` method:

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

## Access HttpContext from SignalR

To use `HttpContext` from SignalR, call the <xref:Microsoft.AspNetCore.SignalR.GetHttpContextExtensions.GetHttpContext%2A> on the <xref:Microsoft.AspNetCore.SignalR.Hub.Context%2A>:

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

## Access HttpContext from gRPC methods

To use `HttpContext` from [gRPC](xref:grpc/aspnetcore) methods, see [Resolve HttpContext in gRPC methods](xref:grpc/aspnetcore#resolve-httpcontext-in-grpc-methods).

## Access HttpContext from custom components

For other framework and custom components that require access to `HttpContext`, the recommended approach is to register a dependency by using the built-in [Dependency Injection (DI)](xref:fundamentals/dependency-injection) container. The DI container supplies the `IHttpContextAccessor` to any classes that declare it as a dependency in their constructors:

:::moniker range=">= aspnetcore-6.0"

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IUserRepository, UserRepository>();
```

:::moniker-end
:::moniker range="< aspnetcore-6.0"

```csharp
public void ConfigureServices(IServiceCollection services)
{
     services.AddControllersWithViews();
     services.AddHttpContextAccessor();
     services.AddTransient<IUserRepository, UserRepository>();
}
```

:::moniker-end

In the following example:

* The `UserRepository` instance declares its dependency on `IHttpContextAccessor`.
* The dependency is supplied when DI resolves the dependency chain and creates an instance of `UserRepository`.

:::moniker range=">= aspnetcore-6.0"

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

:::moniker-end
:::moniker range="< aspnetcore-6.0"

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

:::moniker-end

## Access HttpContext from a background thread

`HttpContext` isn't thread-safe. Reading or writing properties of the `HttpContext` outside of processing a request can result in a <xref:System.NullReferenceException> error.

> [!NOTE]
> If your app generates sporadic `NullReferenceException` errors, review parts of the code that start background processing or code that continues processing after a request completes. Look for mistakes, such as defining a controller method as `async void`.

To safely do background work with `HttpContext` data:

* Copy the required data during request processing.
* Pass the copied data to a background task.
* **Don't** reference `HttpContext` data in parallel tasks. Extract the data needed from the context before starting the parallel tasks.

To avoid unsafe code, never pass `HttpContext` into a method that does background work. Pass the required data instead. 

:::moniker range=">= aspnetcore-6.0"

In the following example, the `SendEmail` method calls the `SendEmailCoreAsync` method to start sending an email. The value of the `X-Correlation-Id` header is passed to `SendEmailCoreAsync` instead of the `HttpContext`. Code execution doesn't wait for `SendEmailCoreAsync` to complete:

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

:::moniker-end
:::moniker range="< aspnetcore-6.0"

In the following example, the `SendEmailCore` method is called to start sending an email. The `correlationId` parameter is passed to `SendEmailCore`, not the `HttpContext`. Code execution doesn't wait for `SendEmailCore` to complete:

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

:::moniker-end

## Access IHttpContextAccessor or HttpContext in Razor components (Blazor)

If you want to access the `IHttpContextAccessor` or `HttpContext` in Razor components (Blazor apps), see <xref:blazor/components/httpcontext>.

## Related content

- [Use HttpContext in ASP.NET Core](xref:fundamentals/use-httpcontext)
- [Razor Pages architecture and concepts in ASP.NET Core](xref:razor-pages/index)
- [gRPC services with ASP.NET Core](xref:grpc/aspnetcore)