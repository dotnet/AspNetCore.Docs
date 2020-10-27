---
title: Dependency injection in requirement handlers in ASP.NET Core
author: rick-anderson
description: Learn how to inject authorization requirement handlers into an ASP.NET Core app using dependency injection.
ms.author: riande
ms.date: 10/14/2016
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: security/authorization/dependencyinjection
---
# Dependency injection in requirement handlers in ASP.NET Core

<a name="security-authorization-di"></a>

[Authorization handlers must be registered](xref:security/authorization/policies#handler-registration) in the service collection during configuration using [dependency injection](xref:fundamentals/dependency-injection).

Suppose you had a repository of rules you wanted to evaluate inside an authorization handler and that repository was registered in the service collection. Authorization resolves and injects that into the constructor.

For example, to use ASP.NET's logging infrastructure, inject `ILoggerFactory` into the handler. Such a handler might look like the following code:

```csharp
public class LoggingAuthorizationHandler : AuthorizationHandler<MyRequirement>
   {
       ILogger _logger;

       public LoggingAuthorizationHandler(ILoggerFactory loggerFactory)
       {
           _logger = loggerFactory.CreateLogger(this.GetType().FullName);
       }

       protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MyRequirement requirement)
       {
           _logger.LogInformation("Inside my handler");
           // Check if the requirement is fulfilled.
           return Task.CompletedTask;
       }
   }
   ```

The preceding handler can be registered with any [service lifetime](/dotnet/core/extensions/dependency-injection#service-lifetimes). The following code uses `AddSingleton` to register the preceding handler:

```csharp
services.AddSingleton<IAuthorizationHandler, LoggingAuthorizationHandler>();
```

An instance of the handler is created when the app starts, and DI injects the registered `ILoggerFactory` into the constructor.

> [!NOTE]
> Handlers that use Entity Framework shouldn't be registered as singletons.
