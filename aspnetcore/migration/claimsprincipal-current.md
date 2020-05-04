---
title: Migrate from ClaimsPrincipal.Current
author: mjrousos
description: Learn how to migrate away from ClaimsPrincipal.Current to retrieve the current authenticated user's identity and claims in ASP.NET Core.
ms.author: scaddie
ms.custom: mvc
ms.date: 03/26/2019
no-loc: [Blazor, "Identity", "Let's Encrypt", Razor, SignalR]
uid: migration/claimsprincipal-current
---
# Migrate from ClaimsPrincipal.Current

In ASP.NET 4.x projects, it was common to use [ClaimsPrincipal.Current](/dotnet/api/system.security.claims.claimsprincipal.current) to retrieve the current authenticated user's identity and claims. In ASP.NET Core, this property is no longer set. Code that was depending on it needs to be updated to get the current authenticated user's identity through a different means.

## Context-specific data instead of static data

When using ASP.NET Core, the values of both `ClaimsPrincipal.Current` and `Thread.CurrentPrincipal` aren't set. These properties both represent static state, which ASP.NET Core generally avoids. Instead, ASP.NET Core's architecture is to retrieve dependencies (like the current user's identity) from context-specific service collections (using its [dependency injection](xref:fundamentals/dependency-injection) (DI) model). What's more, `Thread.CurrentPrincipal` is thread static, so it may not persist changes in some asynchronous scenarios (and `ClaimsPrincipal.Current` just calls `Thread.CurrentPrincipal` by default).

To understand the sorts of problems thread static members can lead to in asynchronous scenarios, consider the following code snippet:

```csharp
// Create a ClaimsPrincipal and set Thread.CurrentPrincipal
var identity = new ClaimsIdentity();
identity.AddClaim(new Claim(ClaimTypes.Name, "User1"));
Thread.CurrentPrincipal = new ClaimsPrincipal(identity);

// Check the current user
Console.WriteLine($"Current user: {Thread.CurrentPrincipal?.Identity.Name}");

// For the method to complete asynchronously
await Task.Yield();

// Check the current user after
Console.WriteLine($"Current user: {Thread.CurrentPrincipal?.Identity.Name}");
```

The preceding sample code sets `Thread.CurrentPrincipal` and checks its value before and after awaiting an asynchronous call. `Thread.CurrentPrincipal` is specific to the *thread* on which it's set, and the method is likely to resume execution on a different thread after the await. Consequently, `Thread.CurrentPrincipal` is present when it's first checked but is null after the call to `await Task.Yield()`.

Getting the current user's identity from the app's DI service collection is more testable, too, since test identities can be easily injected.

## Retrieve the current user in an ASP.NET Core app

There are several options for retrieving the current authenticated user's `ClaimsPrincipal` in ASP.NET Core in place of `ClaimsPrincipal.Current`:

* **ControllerBase.User**. MVC controllers can access the current authenticated user with their [User](/dotnet/api/microsoft.aspnetcore.mvc.controllerbase.user) property.
* **HttpContext.User**. Components with access to the current `HttpContext` (middleware, for example) can get the current user's `ClaimsPrincipal` from [HttpContext.User](/dotnet/api/microsoft.aspnetcore.http.httpcontext.user).
* **Passed in from caller**. Libraries without access to the current `HttpContext` are often called from controllers or middleware components and can have the current user's identity passed as an argument.
* **IHttpContextAccessor**. The project being migrated to ASP.NET Core may be too large to easily pass the current user's identity to all necessary locations. In such cases, [IHttpContextAccessor](/dotnet/api/microsoft.aspnetcore.http.ihttpcontextaccessor) can be used as a workaround. `IHttpContextAccessor` is able to access the current `HttpContext` (if one exists). If DI is being used, see <xref:fundamentals/httpcontext>. A short-term solution to getting the current user's identity in code that hasn't yet been updated to work with ASP.NET Core's DI-driven architecture would be:

  * Make `IHttpContextAccessor` available in the DI container by calling [AddHttpContextAccessor](https://github.com/aspnet/Hosting/issues/793) in `Startup.ConfigureServices`.
  * Get an instance of `IHttpContextAccessor` during startup and store it in a static variable. The instance is made available to code that was previously retrieving the current user from a static property.
  * Retrieve the current user's `ClaimsPrincipal` using `HttpContextAccessor.HttpContext?.User`. If this code is used outside of the context of an HTTP request, the `HttpContext` is null.

The final option, using an `IHttpContextAccessor` instance stored in a static variable, is contrary to ASP.NET Core principles (preferring injected dependencies to static dependencies). Plan to eventually retrieve `IHttpContextAccessor` instances from dependency injection instead. A static helper can be a useful bridge, though, when migrating large existing ASP.NET apps that were previously using `ClaimsPrincipal.Current`.
