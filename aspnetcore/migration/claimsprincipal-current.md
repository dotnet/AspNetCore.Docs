---
title: Migrate from ClaimsPrincipal.Current
author: mjrousos
description: Learn how to migrate away from ClaimsPrincipal.Current to retrieve the current authenticated user's identity and claims in ASP.NET Core.
ms.author: scaddie
ms.custom: mvc
ms.date: 03/26/2019
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: migration/claimsprincipal-current
---
# Migrate from ClaimsPrincipal.Current

In ASP.NET 4.x projects, it was common to use <xref:System.Security.Claims.ClaimsPrincipal.Current%2A?displayProperty=nameWithType> to retrieve the current authenticated user's identity and claims. In ASP.NET Core, this property is no longer set. Code that was depending on it needs to be updated to get the current authenticated user's identity through a different means.

## Context-specific state instead of static state

When using ASP.NET Core, the values of both `ClaimsPrincipal.Current` and `Thread.CurrentPrincipal` aren't set. These properties both represent static state, which ASP.NET Core generally avoids. Instead, ASP.NET Core uses [dependency injection](xref:fundamentals/dependency-injection) (DI) to provide dependencies such as the current user's identity. Getting the current user's identity from DI is more testable, too, since test identities can be easily injected.

## Retrieve the current user in an ASP.NET Core app

There are several options for retrieving the current authenticated user's `ClaimsPrincipal` in ASP.NET Core in place of `ClaimsPrincipal.Current`:

* **ControllerBase.User**. MVC controllers can access the current authenticated user with their <xref:Microsoft.AspNetCore.Mvc.ControllerBase.User%2A> property.
* **HttpContext.User**. Components with access to the current `HttpContext` (middleware, for example) can get the current user's `ClaimsPrincipal` from <xref:Microsoft.AspNetCore.Http.HttpContext.User%2A?displayProperty=nameWithType>.
* **Passed in from caller**. Libraries without access to the current `HttpContext` are often called from controllers or middleware components and can have the current user's identity passed as an argument.
* **IHttpContextAccessor**. The project being migrated to ASP.NET Core may be too large to easily pass the current user's identity to all necessary locations. In such cases, <xref:Microsoft.AspNetCore.Http.IHttpContextAccessor> can be used as a workaround. `IHttpContextAccessor` is able to access the current `HttpContext` (if one exists). If DI is being used, see <xref:fundamentals/httpcontext>. A short-term solution to getting the current user's identity in code that hasn't yet been updated to work with ASP.NET Core's DI-driven architecture would be:

  * Make `IHttpContextAccessor` available in the DI container by calling [AddHttpContextAccessor](https://github.com/aspnet/Hosting/issues/793) in `Startup.ConfigureServices`.
  * Get an instance of `IHttpContextAccessor` during startup and store it in a static variable. The instance is made available to code that was previously retrieving the current user from a static property.
  * Retrieve the current user's `ClaimsPrincipal` using `HttpContextAccessor.HttpContext?.User`. If this code is used outside of the context of an HTTP request, the `HttpContext` is null.

The final option, using an `IHttpContextAccessor` instance stored in a static variable, is contrary to the ASP.NET Core principle of preferring injected dependencies to static dependencies. Plan to eventually retrieve `IHttpContextAccessor` instances from DI instead. A static helper can be a useful bridge, though, when migrating large existing ASP.NET apps that use `ClaimsPrincipal.Current`.
