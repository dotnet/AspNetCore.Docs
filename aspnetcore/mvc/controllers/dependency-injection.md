---
title: Dependency injection into controllers in ASP.NET Core
author: ardalis
description: Discover how ASP.NET Core MVC controllers request their dependencies explicitly via their constructors with dependency injection in ASP.NET Core.
ms.author: riande
ms.date: 2/24/2019
uid: mvc/controllers/dependency-injection
---
# Dependency injection into controllers in ASP.NET Core

<a name="dependency-injection-controllers"></a>

By [Shadi Namrouti](https://github.com/shadinamrouti), [Rick Anderson](https://twitter.com/RickAndMSFT) and [Steve Smith](https://github.com/ardalis)

ASP.NET Core MVC controllers request their dependencies explicitly via their constructors. ASP.NET Core has built-in support for [dependency injection](xref:fundamentals/dependency-injection), which makes apps easier to test and maintain.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/mvc/controllers/dependency-injection/sample) ([how to download](xref:index#how-to-download-a-sample))

## Constructor Injection

Services are added as a constructor parameter, and the runtime resolves the service from the service container. Services are typically defined using interfaces. For example, consider an app that requires the current time. The following interface exposes the `IDateTime` service:

[!code-csharp[](dependency-injection/sample/ControllerDI/Interfaces/IDateTime.cs)]

The following code implements the `IDateTime` interface:

[!code-csharp[](dependency-injection/sample/ControllerDI/Services/SystemDateTime.cs)]

Add the service to the dependency container:

[!code-csharp[](./dependency-injection/sample/ControllerDI/Startup1.cs?name=snippet)]

For more information on <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton*>, see  [see DI service lifetimes](xref:fundamentals/dependency-injection#service-lifetimes).

The following shows the `HomeController.Index` method code used display a greeting to the user based on the time of day:

[!code-csharp[](./dependency-injection/sample/ControllerDI/Controllers/HomeController.cs?name=snippet)]

Run the app and a message is displayed based on the time.

## Action injection with FromServices

The <xref:Microsoft.AspNetCore.Mvc.FromServicesAttribute> attribute enables injecting a service directly into action method without using constructor injection:

[!code-csharp[](./dependency-injection/sample/ControllerDI/Controllers/HomeController.cs?name=snippet2)]

## Accessing settings from a controller

Accessing application or configuration settings from within a controller is a common pattern. Generally, the *options pattern* described in [Configuration](xref:fundamentals/configuration/index) is the preferred approach to get settings. You generally shouldn't request <xref:Microsoft.Extensions.Configuration.IConfiguration> directly from your controller

Create a class that represents the options. For example:

[!code-csharp[](dependency-injection/sample/ControllerDI/Models/SampleWebSettings.cs&name=snippet)]

Add the configuration class to the services collection:

[!code-csharp[](./dependency-injection/sample/ControllerDI/Startup.cs?highlight=4&name=snippet)]

We configured the app to read the settings from a JSON-formatted file:

[!code-csharp[](./dependency-injection/sample/ControllerDI/Program.cs?name=snippet&range=10-15)]

The following code request the `IOptions<SampleWebSettings>`settings from a controller and uses them in the `Index` method:

[!code-csharp[](./dependency-injection/sample/ControllerDI/Controllers/SettingsController.cs?name=snippet)]

## Addition resources

* See [Test controller logic](testing.md) to learn how to make code easier to test by explicitly requesting dependencies in controllers.

* [Replace the default dependency injection container with a third party implementation](xref:fundamentals/dependency-injection#default-service-container-replacement).