---
title: Application Parts in ASP.NET Core
author: rick-anderson
description: Share controllers, view, Razor Pages and more with Application Parts in ASP.NET Core
ms.author: riande
ms.date: 05/14/2019
uid: mvc/extensibility/app-parts
---
# Share controllers, view, Razor Pages and more with Application Parts in ASP.NET Core

https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/generic-classes

By [Rick Anderson](https://twitter.com/RickAndMSFT)

[View or download sample code](https://github.com/aspnet/AspNetCore.Docs/tree/master/aspnetcore/mvc/advanced/app-parts/sample) ([how to download](xref:index#how-to-download-a-sample))

An *Application Part* is an abstraction over the resources of an app. Application Parts allow ASP.NET Core to discover controllers, view components, tag helpers, Razor Pages, razor compilation sources, and more. [AssemblyPart](/dotnet/api/microsoft.aspnetcore.mvc.applicationparts.assemblypart#Microsoft_AspNetCore_Mvc_ApplicationParts_AssemblyPart) is an Application part. `AssemblyPart` encapsulates an assembly reference and exposes types and compilation references.

*Feature providers* work with application parts to populate the features of an ASP.NET Core app. The main use case for application parts is to configure an app to discover (or avoid loading) ASP.NET Core features from an assembly. For example, you might want to share common functionality between multiple apps. Using Application Parts, you can share an assembly (DLL) containing controllers, views, Razor Pages, razor compilation sources, Tag Helpers, and more with multiple apps. Sharing an assembly is preferred to duplicating the code in multiple projects.

ASP.NET Core apps load features from [ApplicationPart](/dotnet/api/microsoft.aspnetcore.mvc.applicationparts.applicationpart). The [AssemblyPart](/dotnet/api/microsoft.aspnetcore.mvc.applicationparts.assemblypart#Microsoft_AspNetCore_Mvc_ApplicationParts_AssemblyPart) class represents an application part that's backed by an assembly.

## Load ASP.NET Core features

Use the `ApplicationPart` and `AssemblyPart` classes to discover and load ASP.NET Core features (controllers, view components, etc). The [ApplicationPartManager](/dotnet/api/microsoft.aspnetcore.mvc.applicationparts.applicationpartmanager) tracks the application parts and feature providers available. `ApplicationPartManager` is configured in `Startup.ConfigureServices`:

[!code-csharp[](./app-parts/sample/sample1/WebAppParts/Startup.cs?name=snippet)]

The following code provides an alternative approach to configuring `ApplicationPartManager` using `AssemblyPart`:

[!code-csharp[](./app-parts/sample/sample1/WebAppParts/Startup2.cs?name=snippet)]

The preceding two code samples load the `SharedController` from an assembly. The `SharedController` is not in the applications project. See the [WebAppParts solution](https://github.com/aspnet/AspNetCore.Docs/tree/master/aspnetcore/mvc/advanced/app-parts/sample1/WebAppParts) sample download.

### Include views

To include views in the assembly:

* Add the following markup to the shared project file:

  ```csproj
    <ItemGroup>
      <EmbeddedResource Include = "Views\**\*.cshtml" />
    </ ItemGroup >
  ```

* Add the <xref:Microsoft.Extensions.FileProviders.EmbeddedFileProvider> to the <xref:Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine>:

    [!code-csharp[](./app-parts/sample/sample1/WebAppParts/Startup2Views.cs?name=snippet&highlight=3-7)]

### Prevent loading resources

You can use application parts to *avoid* looking for controllers in a particular assembly or location. You can control which parts (or assemblies) are available to the app by modifying the <xref:Microsoft.AspNetCore.Mvc.ApplicationParts> collection of the `ApplicationPartManager`. The order of the entries in the `ApplicationParts` collection isn't important. It's important to fully configure the `ApplicationPartManager` before using it to configure services in the container. For example, you should fully configure the `ApplicationPartManager` before invoking `AddControllersAsServices`. Failing to do so, will mean that controllers in application parts added after that method call won't be affected (won't get registered as services) which might result in incorrect behavior of your application.

If you have an assembly that contains controllers you don't want to be used, remove it from the `ApplicationPartManager`:

The following code uses <xref:Microsoft.AspNetCore.Mvc.ApplicationParts> to remove `MyDependentLibrary` from the app:
[!code-csharp[](./app-parts/sample/sample1/WebAppParts/StartupRm.cs?name=snippet)]

In addition to your project's assembly and its dependent assemblies, the `ApplicationPartManager` includes parts for:

* The apps assembly and dependent assemblies.
* `Microsoft.AspNetCore.Mvc.TagHelpers`
* `Microsoft.AspNetCore.Mvc.Razor` by default.

## Application feature providers

Application feature providers examine application parts and provide features for those parts. There are built-in feature providers for the following ASP.NET Core features:

* [Controllers](/dotnet/api/microsoft.aspnetcore.mvc.controllers.controllerfeatureprovider)
* [Tag Helpers](/dotnet/api/microsoft.aspnetcore.mvc.razor.taghelpers.taghelperfeatureprovider)
* [View Components](/dotnet/api/microsoft.aspnetcore.mvc.viewcomponents.viewcomponentfeatureprovider)

Feature providers inherit from <xref:Microsoft.AspNetCore.Mvc.ApplicationParts.IApplicationFeatureProvider`1>, where `T` is the type of the feature. Feature providers can be implemented for any of the previously listed feature types. The order of feature providers in the `ApplicationPartManager.FeatureProviders` can impact run time behavior. Later added providers can react to actions taken by earlier added providers.

### Sample: Generic controller feature

By default, ASP.NET Core MVC ignores [generic controllers](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/generic-classes). A generic controller has a type parameter (for example, `MyController<T>`). The following sample adds generic controller instances:

This sample uses a controller feature provider that runs after the default provider and adds generic controller instances for a specified list of types (defined in `EntityTypes.Types`):

[!code-csharp[](./app-parts/sample/AppPartsSample/GenericControllerFeatureProvider.cs?highlight=13&range=18-36)]

The entity types:

[!code-csharp[](./app-parts/sample/AppPartsSample/Model/EntityTypes.cs?range=6-16)]

The feature provider is added in `Startup`:

```csharp
services.AddMvc()
    .ConfigureApplicationPartManager(apm => 
        apm.FeatureProviders.Add(new GenericControllerFeatureProvider()));
```

By default, the generic controller names used for routing would be of the form *GenericController`1[Widget]* instead of *Widget*. The following attribute is used to modify the name to correspond to the generic type used by the controller:

[!code-csharp[](./app-parts/sample/AppPartsSample/GenericControllerNameConvention.cs)]

The `GenericController` class:

[!code-csharp[](./app-parts/sample/AppPartsSample/GenericController.cs?highlight=5-6)]

The result, when a matching route is requested:

![Example output from the sample app reads, 'Hello from a generic Sprocket controller.'](app-parts/_static/generic-controller.png)

### Sample: Display available features

You can iterate through the populated features available to your app by requesting an `ApplicationPartManager` through [dependency injection](../../fundamentals/dependency-injection.md) and using it to populate instances of the appropriate features:

[!code-csharp[](./app-parts/sample/AppPartsSample/Controllers/FeaturesController.cs?highlight=16,25-27)]

Example output:

![Example output from the sample app](app-parts/_static/available-features.png)
