---
title: Dependency injection in requirement handlers in ASP.NET Core
author: rick-anderson
description: Learn how to inject authorization requirement handlers into an ASP.NET Core app using dependency injection.
monikerRange: ">= aspnetcore-2.1"
ms.author: riande
ms.date: 03/25/2022
uid: security/authorization/dependencyinjection
---
# Dependency injection in requirement handlers in ASP.NET Core

:::moniker range=">= aspnetcore-6.0"

[Authorization handlers must be registered](xref:security/authorization/policies#security-authorization-policies-based-handler-registration) in the service collection during configuration using [dependency injection](xref:fundamentals/dependency-injection).

Suppose you had a repository of rules you wanted to evaluate inside an authorization handler and that repository was registered in the service collection. Authorization resolves and injects that into the constructor.

For example, to use the .NET logging infrastructure, inject <xref:Microsoft.Extensions.Logging.ILoggerFactory> into the handler, as shown in the following example:

```csharp
public class SampleAuthorizationHandler : AuthorizationHandler<SampleRequirement>
{
    private readonly ILogger _logger;

    public SampleAuthorizationHandler(ILoggerFactory loggerFactory)
        => _logger = loggerFactory.CreateLogger(GetType().FullName);

    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context, SampleRequirement requirement)
    {
        _logger.LogInformation("Inside my handler");
        
        // ...

        return Task.CompletedTask;
    }
}
```

The preceding handler can be registered with any [service lifetime](/dotnet/core/extensions/dependency-injection#service-lifetimes). The following code uses <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton%2A> to register the preceding handler:

```csharp
builder.Services.AddSingleton<IAuthorizationHandler, SampleAuthorizationHandler>();
```

An instance of the handler is created when the app starts, and DI injects the registered `ILoggerFactory` into its constructor.

> [!NOTE]
> Don't register authorization handlers that use Entity Framework (EF) as singletons.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

[Authorization handlers must be registered](xref:security/authorization/policies#security-authorization-policies-based-handler-registration) in the service collection during configuration using [dependency injection](xref:fundamentals/dependency-injection).

Suppose you had a repository of rules you wanted to evaluate inside an authorization handler and that repository was registered in the service collection. Authorization resolves and injects that into the constructor.

For example, to use the .NET logging infrastructure, inject <xref:Microsoft.Extensions.Logging.ILoggerFactory> into the handler, as shown in the following example:

```csharp
public class SampleAuthorizationHandler : AuthorizationHandler<SampleRequirement>
{
    private readonly ILogger _logger;

    public SampleAuthorizationHandler(ILoggerFactory loggerFactory)
        => _logger = loggerFactory.CreateLogger(GetType().FullName);

    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context, SampleRequirement requirement)
    {
        _logger.LogInformation("Inside my handler");
        
        // ...

        return Task.CompletedTask;
    }
}
```

The preceding handler can be registered with any [service lifetime](/dotnet/core/extensions/dependency-injection#service-lifetimes). The following code uses <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton%2A> to register the preceding handler:

```csharp
services.AddSingleton<IAuthorizationHandler, SampleAuthorizationHandler>();
```

An instance of the handler is created when the app starts, and DI injects the registered `ILoggerFactory` into its constructor.

> [!NOTE]
> Don't register authorization handlers that use Entity Framework (EF) as singletons.

:::moniker-end
