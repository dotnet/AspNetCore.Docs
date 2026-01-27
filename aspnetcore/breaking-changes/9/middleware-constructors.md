---
title: "Breaking change: Middleware types with multiple constructors"
description: Learn about the breaking change in ASP.NET Core 9 where having multiple constructors in a middleware type can cause an exception at runtime.
ms.date: 11/6/2024
ms.custom: https://github.com/aspnet/Announcements/issues/514
---

# Middleware types with multiple constructors

Previously, when a middleware type with multiple satisfiable constructors was instantiated from the dependency injection container, the one with the most parameters was used. Now that only happens if the dependency injection container implements <xref:Microsoft.Extensions.DependencyInjection.IServiceProviderIsService>. If it doesn't, an exception is thrown at runtime.

## Version introduced

.NET 9 RC 1

## Previous behavior

Previously, the first of the following two constructors was preferred (when both were satisfied) because it has more parameters.

```csharp
public class CookiePolicyMiddleware
{
    public CookiePolicyMiddleware(RequestDelegate next, IOptions<CookiePolicyOptions> options, ILoggerFactory factory)
    {
        // ...
    }

    public CookiePolicyMiddleware(RequestDelegate next, IOptions<CookiePolicyOptions> options)
    {
        // ...
    }
}
```

## New behavior

Starting in .NET 9, neither constructor is preferred, and construction fails with an error like:

> System.InvalidOperationException: 'Multiple constructors accepting all given argument types have been found in type 'Microsoft.AspNetCore.CookiePolicy.CookiePolicyMiddleware'. There should only be one applicable constructor.'

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The activation mechanism was changed to help support keyed dependency injection.

## Recommended action

If this happens and you can't upgrade to a dependency injection container that implements <xref:Microsoft.Extensions.DependencyInjection.IServiceProviderIsService>, you can add the <xref:Microsoft.Extensions.DependencyInjection.ActivatorUtilitiesConstructorAttribute> to the preferred constructor of the affected middleware type.

## Affected APIs

This change is known to cause errors when instantiating <xref:Microsoft.AspNetCore.CookiePolicy.CookiePolicyMiddleware?displayProperty=fullName> with [Autofac.Extensions.DependencyInjection](https://www.nuget.org/packages/Autofac.Extensions.DependencyInjection) 7.x.
