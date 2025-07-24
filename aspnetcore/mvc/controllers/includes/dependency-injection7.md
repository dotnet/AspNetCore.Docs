
:::moniker range=">= aspnetcore-3.0 < aspnetcore-8.0"

By [Shadi Alnamrouti](https://stackoverflow.com/users/3380497/shadi-alnamrouti), [Rick Anderson](https://twitter.com/RickAndMSFT), and [Steve Smith](https://github.com/ardalis)

ASP.NET Core MVC controllers request dependencies explicitly via constructors. ASP.NET Core has built-in support for [dependency injection (DI)](xref:fundamentals/dependency-injection). DI makes apps easier to test and maintain.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/mvc/controllers/dependency-injection/sample) ([how to download](xref:index#how-to-download-a-sample))

## Constructor injection

Services are added as a constructor parameter, and the runtime resolves the service from the service container. Services are typically defined using interfaces. For example, consider an app that requires the current time. The following interface exposes the `IDateTime` service:

[!code-csharp[](~/mvc/controllers/dependency-injection/3.1sample/ControllerDI/Interfaces/IDateTime.cs?name=snippet)]

The following code implements the `IDateTime` interface:

[!code-csharp[](~/mvc/controllers/dependency-injection/3.1sample/ControllerDI/Services/SystemDateTime.cs?name=snippet)]

Add the service to the service container:

[!code-csharp[](~/mvc/controllers/dependency-injection/3.1sample/ControllerDI/Startup1.cs?name=snippet&highlight=3)]

For more information on <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton*>, see [DI service lifetimes](xref:fundamentals/dependency-injection#service-lifetimes).

The following code displays a greeting to the user based on the time of day:

[!code-csharp[](~/mvc/controllers/dependency-injection/3.1sample/ControllerDI/Controllers/HomeController.cs?name=snippet)]

Run the app and a message is displayed based on the time.

## Action injection with `FromServices`

The <xref:Microsoft.AspNetCore.Mvc.FromServicesAttribute> enables injecting a service directly into an action method without using constructor injection:

[!code-csharp[](~/mvc/controllers/dependency-injection/3.1sample/ControllerDI/Controllers/HomeController.cs?name=snippet2)]

## Access settings from a controller

Accessing app or configuration settings from within a controller is a common pattern. The *options pattern* described in <xref:fundamentals/configuration/options> is the preferred approach to manage settings. Generally, don't directly inject <xref:Microsoft.Extensions.Configuration.IConfiguration> into a controller.

Create a class that represents the options. For example:

[!code-csharp[](~/mvc/controllers/dependency-injection/3.1sample/ControllerDI/Models/SampleWebSettings.cs?name=snippet)]

Add the configuration class to the services collection:

[!code-csharp[](~/mvc/controllers/dependency-injection/3.1sample/ControllerDI/Startup.cs?highlight=4&name=snippet1)]

Configure the app to read the settings from a JSON-formatted file:

[!code-csharp[](~/mvc/controllers/dependency-injection/3.1sample/ControllerDI/Program.cs?name=snippet&range=10-15)]

The following code requests the `IOptions<SampleWebSettings>` settings from the service container and uses them in the `Index` method:

[!code-csharp[](~/mvc/controllers/dependency-injection/3.1sample/ControllerDI/Controllers/SettingsController.cs?name=snippet)]

## Additional resources

* See <xref:mvc/controllers/testing> to learn how to make code easier to test by explicitly requesting dependencies in controllers.

* [Replace the default dependency injection container with a third party implementation](xref:fundamentals/dependency-injection#default-service-container-replacement).

:::moniker-end

:::moniker range="< aspnetcore-3.0"

By [Shadi Namrouti](https://shadinamrouti.com/), [Rick Anderson](https://twitter.com/RickAndMSFT), and [Steve Smith](https://github.com/ardalis)

ASP.NET Core MVC controllers request dependencies explicitly via constructors. ASP.NET Core has built-in support for [dependency injection (DI)](xref:fundamentals/dependency-injection). DI makes apps easier to test and maintain.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/mvc/controllers/dependency-injection/sample) ([how to download](xref:index#how-to-download-a-sample))

## Constructor injection

Services are added as a constructor parameter, and the runtime resolves the service from the service container. Services are typically defined using interfaces. For example, consider an app that requires the current time. The following interface exposes the `IDateTime` service:

[!code-csharp[](~/mvc/controllers/dependency-injection/sample/ControllerDI/Interfaces/IDateTime.cs?name=snippet)]

The following code implements the `IDateTime` interface:

[!code-csharp[](~/mvc/controllers/dependency-injection/sample/ControllerDI/Services/SystemDateTime.cs?name=snippet)]

Add the service to the service container:

[!code-csharp[](~/mvc/controllers/dependency-injection/sample/ControllerDI/Startup1.cs?name=snippet&highlight=3)]

For more information on <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton*>, see [DI service lifetimes](xref:fundamentals/dependency-injection#service-lifetimes).

The following code displays a greeting to the user based on the time of day:

[!code-csharp[](~/mvc/controllers/dependency-injection/sample/ControllerDI/Controllers/HomeController.cs?name=snippet)]

Run the app and a message is displayed based on the time.

## Action injection with `FromServices`

The <xref:Microsoft.AspNetCore.Mvc.FromServicesAttribute> enables injecting a service directly into an action method without using constructor injection:

[!code-csharp[](~/mvc/controllers/dependency-injection/sample/ControllerDI/Controllers/HomeController.cs?name=snippet2)]

## Access settings from a controller

Accessing app or configuration settings from within a controller is a common pattern. The *options pattern* described in <xref:fundamentals/configuration/options> is the preferred approach to manage settings. Generally, don't directly inject <xref:Microsoft.Extensions.Configuration.IConfiguration> into a controller.

Create a class that represents the options. For example:

[!code-csharp[](~/mvc/controllers/dependency-injection/sample/ControllerDI/Models/SampleWebSettings.cs?name=snippet)]

Add the configuration class to the services collection:

[!code-csharp[](~/mvc/controllers/dependency-injection/sample/ControllerDI/Startup.cs?highlight=4&name=snippet1)]

Configure the app to read the settings from a JSON-formatted file:

[!code-csharp[](~/mvc/controllers/dependency-injection/sample/ControllerDI/Program.cs?name=snippet&range=10-15)]

The following code requests the `IOptions<SampleWebSettings>` settings from the service container and uses them in the `Index` method:

[!code-csharp[](~/mvc/controllers/dependency-injection/sample/ControllerDI/Controllers/SettingsController.cs?name=snippet)]

## Additional resources

* See <xref:mvc/controllers/testing> to learn how to make code easier to test by explicitly requesting dependencies in controllers.

* [Replace the default dependency injection container with a third party implementation](xref:fundamentals/dependency-injection#default-service-container-replacement).

:::moniker-end
