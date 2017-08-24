---
title: Dependency Injection in requirement handlers
author: rick-anderson
description: 
keywords: ASP.NET Core,
ms.author: riande
manager: wpickett
ms.date: 10/14/2016
ms.topic: article
ms.assetid: 5fb6625c-173a-4feb-8380-73c9844dc23c
ms.technology: aspnet
ms.prod: asp.net-core
uid: security/authorization/dependencyinjection
---
# Dependency Injection in requirement handlers

<a name=security-authorization-di></a>

[Authorization handlers must be registered](policies.md#security-authorization-policies-based-handler-registration) in the service collection during configuration (using [dependency injection](../../fundamentals/dependency-injection.md#fundamentals-dependency-injection)).

Suppose you had a repository of rules you wanted to evaluate inside an authorization handler and that repository was registered in the service collection.  Authorization will resolve and inject that into your constructor.

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
