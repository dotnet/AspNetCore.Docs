---
title: Application Parts in ASP.NET Core
author: ardalis
description: Learn how to use application parts, which are abstrations over the resources of an app, to configure your app to discover or avoid loading features from an assembly.
keywords: ASP.NET Core,application part,app part
ms.author: riande
manager: wpickett
ms.date: 1/4/2017
ms.topic: article
ms.assetid: b355a48e-a15c-4d58-b69c-899963613a98
ms.technology: aspnet
ms.prod: asp.net-core
uid: mvc/extensibility/app-parts
---
# Application Parts in ASP.NET Core

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/mvc/advanced/app-parts/sample)

An *Application Part* is an abstraction over the resources of an application, from which MVC features like controllers, view components, or tag helpers may be discovered. One example of an application part is an AssemblyPart, which encapsulates an assembly reference and exposes types and compilation references. *Feature providers* work with application parts to populate the features of an ASP.NET Core MVC app. The main use case for application parts is to allow you to configure your app to discover (or avoid loading) MVC features from an assembly.

## Introducing Application Parts

MVC apps load their features from [application parts](/aspnet/core/api/microsoft.aspnetcore.mvc.applicationparts.applicationpart). In particular, the [AssemblyPart](/aspnet/core/api/microsoft.aspnetcore.mvc.applicationparts.assemblypart#Microsoft_AspNetCore_Mvc_ApplicationParts_AssemblyPart) class represents an application part that is backed by an assembly. You can use these classes to discover and load MVC features, such as controllers, view components, tag helpers, and razor compilation sources. The [ApplicationPartManager](/aspnet/core/api/microsoft.aspnetcore.mvc.applicationparts.applicationpartmanager) is responsible for tracking the application parts and feature providers available to the MVC app. You can interact with the `ApplicationPartManager` in `Startup` when you configure MVC:

```csharp
// create an assembly part from a class's assembly
var assembly = typeof(Startup).GetTypeInfo().Assembly;
services.AddMvc()
    .AddApplicationPart(assembly);

// OR
var assembly = typeof(Startup).GetTypeInfo().Assembly;
var part = new AssemblyPart(assembly);
services.AddMvc()
    .ConfigureApplicationPartManager(apm => p.ApplicationParts.Add(part));
```

By default MVC will search the dependency tree and find controllers (even in other assemblies). To load an arbitrary assembly (for instance, from a plugin that isn't referenced at compile time), you can use an application part.

You can use application parts to *avoid* looking for controllers in a particular assembly or location. You can control which parts (or assemblies) are available to the app by modifying the `ApplicationParts` collection of the `ApplicationPartManager`. The order of the entries in the `ApplicationParts` collection is not important. It is important to fully configure the `ApplicationPartManager` before using it to configure services in the container. For example, you should fully configure the `ApplicationPartManager` before invoking `AddControllersAsServices`. Failing to do so, will mean that controllers in application parts added after that method call will not be affected (will not get registered as services) which might result in incorrect bevavior of your application.

If you have an assembly that contains controllers you do not want to be used, remove it from the `ApplicationPartManager`:

```csharp
services.AddMvc()
    .ConfigureApplicationPartManager(p =>
    {
        var dependentLibrary = p.ApplicationParts
            .FirstOrDefault(part => part.Name == "DependentLibrary");

        if (dependentLibrary != null)
        {
           p.ApplicationParts.Remove(dependentLibrary);
        }
    })
```

In addition to your project's assembly and its dependent assemblies, the `ApplicationPartManager` will include parts for `Microsoft.AspNetCore.Mvc.TagHelpers` and `Microsoft.AspNetCore.Mvc.Razor` by default.

## Application Feature Providers

Application Feature Providers examine application parts and provide features for those parts. There are built-in feature providers for the following MVC features:

* [Controllers](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.mvc.controllers.controllerfeatureprovider)
* [Metadata Reference](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.mvc.razor.compilation.metadatareferencefeatureprovider)
* [Tag Helpers](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.mvc.razor.taghelpers.taghelperfeatureprovider)
* [View Components](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.mvc.viewcomponents.viewcomponentfeatureprovider)

Feature providers inherit from `IApplicationFeatureProvider<T>`, where `T` is the type of the feature. You can implement your own feature providers for any of MVC's feature types listed above. The order of feature providers in the `ApplicationPartManager.FeatureProviders` collection can be important, since later providers can react to actions taken by previous providers.

### Sample: Generic controller feature

By default, ASP.NET Core MVC ignores generic controllers (for example, `SomeController<T>`). This sample uses a controller feature provider that runs after the default provider and adds generic controller instances for a specified list of types (defined in `EntityTypes.Types`):

[!code-csharp[Main](./app-parts/sample/AppPartsSample/GenericControllerFeatureProvider.cs?highlight=13&range=18-36)]

The entity types:

[!code-csharp[Main](./app-parts/sample/AppPartsSample/Model/EntityTypes.cs?range=6-16)]

The feature provider is added in `Startup`:

```csharp
services.AddMvc()
    .ConfigureApplicationPartManager(p => 
        p.FeatureProviders.Add(new GenericControllerFeatureProvider()));
```

By default, the generic controller names used for routing would be of the form *GenericController`1[Widget]* instead of *Widget*. The following attribute is used to modify the name to correspond to the generic type used by the controller:

[!code-csharp[Main](./app-parts/sample/AppPartsSample/GenericControllerNameConvention.cs)]

The `GenericController` class:

[!code-csharp[Main](./app-parts/sample/AppPartsSample/GenericController.cs?highlight=5-6)]

The result, when a matching route is requested:

![Example output from the sample app reads, 'Hello from a generic Sproket controller.'](app-parts/_static/generic-controller.png)

### Sample: Display available features

You can iterate through the populated features available to your app by requesting an `ApplicationPartManager` through [dependency injection](../../fundamentals/dependency-injection.md) and using it to populate instances of the appropriate features:

[!code-csharp[Main](./app-parts/sample/AppPartsSample/Controllers/FeaturesController.cs?highlight=16,25-27)]

Example output:

![Example output from the sample app](app-parts/_static/available-features.png)
