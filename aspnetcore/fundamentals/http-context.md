---
title: Accessing HttpContext in .NET Core
author: coderandhiker
ms.author: riande
manager: wpickett
description: Learn how to access HttpContext using .NET Core
ms.date: 05/22/2018
ms.topic: article
ms.prod: aspnet-core
uid: fundamentals/http-context
---

# Use IHttpContextAccessor to manage HttpContext

ASP.NET Core applications access the HttpContext hrough the [IHttpContextAccessor](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.ihttpcontextaccessor?view=aspnetcore-2.0) interface and its default implementation [HttpContextAccessor](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httpcontextaccessor.httpcontext?view=aspnetcore-2.0). 

## Use the HttpContext from Razor Pages, controllers, and middleware

If you need to access the current context from a controller, you can access it by using the `HttpContext` property exposed by the `ControllerBase` class from which the `Controller` class is derived.

When working with custom middleware components, `HttpContext` is passed into the Invoke method and can be accessed when the middleware is being configured.

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

## Using HttpContext from custom components

For other framework and custom components that need access to `HttpContext`, the recommended approach is to register a dependency using the built-in dependency injection framework.  This will suplly the `IHttpContextAccessor` to any classes that declare it as a dependency in their constructors.


```csharp
public void ConfigureServices(IServiceCollection services)
{
     services.AddMvc();
     services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
     services.AddTransient<IUserRepository, UserRepository>();
}
```

In this example `UserRepository` declares its dependency on `IHttpContextAccessor`, which is supplied when the dependency injection framework resolves the dependency chain and creates an instance of `UserRepository`.

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

## Working with libraries and ported code
Registering IHttpContextAccessor in the application startup using the built-in dependency injection framework is the preferred approach to accessing HttpContext.  In scenarios where it is not feasible to refactor to this approach, it is possible to simulate the behavior of `System.Web.HttpContext` from ASP.NET 4.x.

Begin by registering `IHttpContextAccessor` as a dependency in your `ConfigureServices` method in your startup class.

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
