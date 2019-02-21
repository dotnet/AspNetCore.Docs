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

ASP.NET Core MVC controllers request their dependencies explicitly via their constructors. In some instances, individual controller actions may require a service, and it may not make sense to request at the controller level. In this case, you can also choose to inject a service as a parameter on the action method.

ASP.NET Core has built-in support for [dependency injection](xref:fundamentals/dependency-injection), which makes apps easier to test and maintain.

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

## Accessing Settings from a Controller

Accessing application or configuration settings from within a controller is a common pattern. This access should use the Options pattern described in [configuration](xref:fundamentals/configuration/index). You generally shouldn't request settings directly from your controller using dependency injection. A better approach is to request an `IOptions<T>` instance, where `T` is the configuration class you need.

To work with the options pattern, you need to create a class that represents the options, such as this one:

[!code-csharp[](dependency-injection/sample/ControllerDI/Models/SampleWebSettings.cs)]

Then you need to configure the application to use the options model and add your configuration class to the services collection in `ConfigureServices.cs`:

[!code-csharp[](./dependency-injection/sample/ControllerDI/Startup.cs?highlight=5&range=27-32)]


> [!NOTE]
> We configured the application to read the settings from a JSON-formatted file by modifying `Program.cs`
> [!code-csharp[](./dependency-injection/sample/ControllerDI/Program.cs?highlight=4-7&range=21-28)]
> You can also configure the settings entirely in code, as is shown in the commented code above. See [Configuration](xref:fundamentals/configuration/index) for further configuration options.

Once you've specified a strongly-typed configuration object (in this case, `SampleWebSettings`) and added it to the services collection, you can request it from any Controller or Action method by requesting an instance of `IOptions<T>` (in this case, `IOptions<SampleWebSettings>`). The following code shows how one would request the settings from a controller:

[!code-csharp[](./dependency-injection/sample/ControllerDI/Controllers/SettingsController.cs?highlight=2-7&range=12-27)]

Following the Options pattern allows settings and configuration to be decoupled from one another, and ensures the controller is following [separation of concerns](/dotnet/standard/modern-web-apps-azure-architecture/architectural-principles#separation-of-concerns), since it doesn't need to know how or where to find the settings information. It also makes the controller easier to [unit test](testing.md), since there's no direct instantiation of settings classes within the controller class.

## Addition resources

* See [Test controller logic](testing.md) to learn how to make code easier to test by explicitly requesting dependencies in controllers.

* [Replace the default dependency injection container with a third party implementation](xref:fundamentals/dependency-injection#default-service-container-replacement).