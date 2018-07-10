---
title: Accessing HttpContext in ASP.NET Core
author: coderandhiker
description: Learn how to access HttpContext in ASP.NET Core.
manager: wpickett
ms.author: riande
ms.custom: mvc
ms.date: 05/22/2018
ms.prod: aspnet-core
ms.technology: aspnet
ms.topic: article
uid: fundamentals/httpcontext
---
# Accessing HttpContext in ASP.NET Core

ASP.NET Core apps access the HttpContext through the [IHttpContextAccessor](/dotnet/api/microsoft.aspnetcore.http.ihttpcontextaccessor) interface and its default implementation [HttpContextAccessor](/dotnet/api/microsoft.aspnetcore.http.httpcontextaccessor).

## Use the HttpContext from Razor Pages, controllers, and middleware

The Razor Pages [PageModel](/dotnet/api/microsoft.aspnetcore.mvc.razorpages.pagemodel) exposes the [HttpContext](/dotnet/api/microsoft.aspnetcore.mvc.razorpages.pagemodel.httpcontext) property:

```csharp
public class AboutModel : PageModel
{
    public string Message { get; set; }

    public void OnGet()
    {
        Message = HttpContext.Request.PathBase;
    }
}
```

Controllers expose the `HttpContext` property from the [ControllerBase](/dotnet/api/microsoft.aspnetcore.mvc.controllerbase):

```csharp
public IActionResult About()
{
    var pathBase = HttpContext.Request.PathBase;
    // Do something with the PathBase.

    return View();
}
```

When working with custom middleware components, `HttpContext` is passed into the `Invoke` or `InvokeAsync` method and can be accessed when the middleware is configured:

```csharp
public class MyCustomMiddleware
{
    public Task InvokeAsync(HttpContext context)
    {
        // Middleware initialization optionally using HttpContext
    }
    ...
}
```

## Use HttpContext from custom components

For other framework and custom components that need access to `HttpContext`, the recommended approach is to register a dependency using the built-in [dependency injection](xref:fundamentals/dependency-injection) container. The dependency injection container supplies the `IHttpContextAccessor` to any classes that declare it as a dependency in their constructors.

```csharp
public void ConfigureServices(IServiceCollection services)
{
     services.AddMvc();
     services.AddHttpContextAccessor();
     services.AddTransient<IUserRepository, UserRepository>();
}
```

In the preceding example:

* `UserRepository` declares its dependency on `IHttpContextAccessor`.
* The dependency is supplied when dependency injection resolves the dependency chain and creates an instance of `UserRepository`.

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

    ...
}
```

