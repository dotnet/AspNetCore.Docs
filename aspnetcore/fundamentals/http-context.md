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
# Use IHttpContextAccessor to manage HttpContext

ASP.NET Core applications access the HttpContext through the [IHttpContextAccessor](/dotnet/api/microsoft.aspnetcore.http.ihttpcontextaccessor?view=aspnetcore-2.0) interface and its default implementation [HttpContextAccessor](/dotnet/api/microsoft.aspnetcore.http.httpcontextaccessor.httpcontext?view=aspnetcore-2.0).

## Use the HttpContext from Razor Pages, controllers, and middleware

The Razor Pages `PageModel` exposes the `HttpContext` property:

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

Controllers expose the `HttpContext` property from the `ControllerBase`:

```csharp
public IActionResult About()
{
    var pathBase = HttpContext.Request.PathBase;
    // Do something with the PathBase.

    return View();
}
```

When working with custom middleware components, `HttpContext` is passed into the `Invoke` method and can be accessed when the middleware is being configured.

```csharp
public class MyCustomMiddleware
{
    public async Task Invoke(HttpContext context)
    {
        // Middleware initialization optionally using HttpContext
    }
    ...
}
```

## Use HttpContext from custom components

For other framework and custom components that need access to `HttpContext`, the recommended approach is to register a dependency using the built-in [dependency injection](xref:fundamentals/dependency-injection) container. The dependency injection container will supply the `IHttpContextAccessor` to any classes that declare it as a dependency in their constructors.

```csharp
public void ConfigureServices(IServiceCollection services)
{
     services.AddMvc();
     services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
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
```

## Work with libraries and ported code

Registering IHttpContextAccessor in the application startup using the built-in dependency injection framework is the preferred approach to accessing HttpContext. In scenarios where it is not feasible to refactor to this approach, it is possible to simulate the behavior of `System.Web.HttpContext` from ASP.NET 4.x.

Register `IHttpContextAccessor` as a dependency in the `ConfigureServices` method.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
}
```

Create a wrapper class for `HttpContext` and provide a method to invoke to pass an instance of `IHttpContextAccessor`.

```csharp
public static class HttpContext
{
    private static IHttpContextAccessor _httpContextAccessor;

    public static Microsoft.AspNetCore.Http.HttpContext Current => _httpContextAccessor.HttpContext;

    public static void RegisterContextAccessor(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
}
```

Introduce an extension method to resolve the `IHttpContextAccessor` dependency and set the `HttpContext` property.

```csharp
public static IApplicationBuilder UseStaticHttpContext(this IApplicationBuilder app)
{
     var httpContextAccessor = app.ApplicationServices.GetRequiredService<IHttpContextAccessor>();

     HttpContext.RegisterContextAccessor(httpContextAccessor);
     return app;
}
```

Configure the application to use the static `HttpContext` object.

```csharp
public void Configure(IApplicationBuilder app)
{
     app.UseStaticHttpContext();
}
```

You will now be able to access the current HttpContext through the static `HttpContext.Current`. When porting code to ASP.NET Core, it may be helpful to place the static `HttpContext` class in the `System.Web` namespace.
