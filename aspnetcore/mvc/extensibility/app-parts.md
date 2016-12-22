---
title: Application Parts | Microsoft Docs
author: ardalis
description: 
keywords: ASP.NET Core,
ms.author: riande
manager: wpickett
ms.date: 12/7/2016
ms.topic: article
ms.assetid: b355a48e-a15c-4d58-b69c-899963613a97
ms.technology: aspnet
ms.prod: aspnet-core
uid: mvc/extensibility/app-parts
---
# Application Parts

By [Steve Smith](http://ardalis)

An *Application Part* is a resource where MVC features may be discovered, such as an assembly. *Feature providers* work with application parts to populate the features of an ASP.NET Core MVC app.

## Introducing Application Parts

MVC apps load their features from [application parts](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.mvc.applicationparts.applicationpart). In particular, the [AssemblyPart](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.mvc.applicationparts.assemblypart#Microsoft_AspNetCore_Mvc_ApplicationParts_AssemblyPart) class represents an application part that is backed by an assembly. You can use these classes to discover and load MVC features, such as controllers, view components, tag helpers, and razor compilation sources. The [ApplicationPartManager](https://docs.microsoft.com/en-us/aspnet/core/api/microsoft.aspnetcore.mvc.applicationparts.applicationpartmanager) is responsible for tracking the application parts and feature providers available to the MVC app. You can interact with the manager in `Startup` when you configure MVC:

<!-- literal_block {"ids": [], "linenos": true, "xml:space": "preserve", "language": "csharp"} -->

```csharp
// create an assembly part from a class's assembly
var assembly = typeof(Startup).GetTypeInfo().Assembly;
services
	.AddMvc()
	.AddApplicationPart(assembly);

// OR
var assembly = typeof(Startup).GetTypeInfo().Assembly;
var part = new AssemblyPart(assembly);
services
    .AddMvc()
    .ConfigureApplicationPartManager(apm => p.ApplicationParts.Add(part));
```

The main use case for application parts is to allow you to configure your app to discover MVC features from another assembly. For instance, by default MVC will search the dependency tree and find controllers (even in other assemblies). To load an arbitrary assembly (for instance, from a plugin that isn't referenced at compile time), you can use an application part. Without application parts, the only way to achieve this would be to replace and rewrite controller discovery and creation - using application parts greatly simplifies this process.

Note that you can also use application parts to *avoid* looking for controllers in a particular assembly or location. By modifying the `ApplicationParts` collection of the `ApplicationPartManager`, you can control which parts of available to the app. The order of the entries in the `ApplicationParts` collection is not important. It is important, though, to ensure you have configured your application parts before you try to use them for features. In `ConfigureServices`, be sure to configure the application part manager completely before using anything that requires services these parts may have added.

If you have an assembly in your MVC project's dependency tree that has controllers in it you do not want to be used by the app, remove it from the `ApplicationPartManager`:

<!-- literal_block {"ids": [], "linenos": true, "xml:space": "preserve", "language": "csharp"} -->

```csharp
services.AddMvc()
    .ConfigureApplicationPartManager(p =>
    {
        var parts = p.ApplicationParts.ToList();
        p.ApplicationParts.Clear();
        p.ApplicationParts.AddRange(parts.Where(part => part.Name != "DependentLibrary"));
    });
```

In addition to your project's assembly and its dependent assemblies, the `ApplicationPartManager` will include parts for `Microsoft.AspNetCore.Mvc.TagHelpers` and `Microsoft.AspNetCore.Mvc.Razor` by default.

## Application Feature Providers

Application Feature Providers examine application parts and provide features for those parts. There are built-in feature providers for the following MVC features:

- [Controllers](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.mvc.controllers.controllerfeatureprovider)
- [Metadata Reference](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.mvc.razor.compilation.metadatareferencefeatureprovider)
- [Tag Helpers](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.mvc.razor.taghelpers.taghelperfeatureprovider)
- [View Components](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.mvc.viewcomponents.viewcomponentfeatureprovider)

> [!NOTE]
> Views do not use feature providers, but will do so in a future release.

Feature providers inherit from `IApplicationFeatureProvider<T>`, where `T` is the type of the feature. You can implement your own feature providers for any of MVC's feature types listed above. The order of feature providers in the `ApplicationPartManager.FeatureProviders` collection can be important, since later providers can react to actions taken by previous providers.

### Sample: Generic Controller Feature

Normally, ASP.NET Core MVC ignores generic controllers (for example, `SomeController<T>`). This sample uses a controller feature provider that runs after the default provider and adds generic controller instances for certain known types (defined in `EntityTypes.Types`):

[!code-csharp[Main](./app-parts/sample/src/AppPartSample/GenericControllerFeatureProvider.cs?highlight=30&range=18-36)]

The entity types:

[!code-csharp[Main](./app-parts/sample/src/AppPartSample/Model/EntityTypes.cs?range=6-16)]

The feature provider is added in `Startup`:

<!-- literal_block {"ids": [], "linenos": true, "xml:space": "preserve", "language": "csharp"} -->

```csharp
services.AddMvc()
        .ConfigureApplicationPartManager(p => p.FeatureProviders.Add(new GenericControllerFeatureProvider()));
```

By default, the generic controller names used for routing would be of the form *GenericController`1[Widget]* instead of *Widget*. The following attribute is used to modify the name to correspond to the generic type used by the controller:

[!code-csharp[Main](./app-parts/sample/src/AppPartSample/GenericControllerNameConvention.cs)]


## Configuring in Startup

Show how to configure application parts and feature providers in Startup using MvcBuilder extension methods.

