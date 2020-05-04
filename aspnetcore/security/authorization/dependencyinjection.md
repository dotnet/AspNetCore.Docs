---
title: Dependency injection in requirement handlers in ASP.NET Core
author: rick-anderson
description: Learn how to inject authorization requirement handlers into an ASP.NET Core app using dependency injection.
ms.author: riande
ms.date: 10/14/2016
no-loc: [Blazor, "Identity", "Let's Encrypt", Razor, SignalR]
uid: security/authorization/dependencyinjection
---
# Dependency injection in requirement handlers in ASP.NET Core

<a name="security-authorization-di"></a>

[Authorization handlers must be registered](xref:security/authorization/policies#handler-registration) in the service collection during configuration (using [dependency injection](xref:fundamentals/dependency-injection)).

Suppose you had a repository of rules you wanted to evaluate inside an authorization handler and that repository was registered in the service collection. Authorization will resolve and inject that into your constructor.

For example, if you wanted to use ASP.NET's logging infrastructure you would want to inject `ILoggerFactory` into your handler. Such a handler might look like:

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

You would register the handler with `services.AddSingleton()`:

```csharp
services.AddSingleton<IAuthorizationHandler, LoggingAuthorizationHandler>();
```

An instance of the handler will be created when your application starts, and DI will inject the registered `ILoggerFactory` into your constructor.

> [!NOTE]
> Handlers that use Entity Framework shouldn't be registered as singletons.
