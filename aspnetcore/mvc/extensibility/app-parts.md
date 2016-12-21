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


## Application Feature Providers

asdf

<!-- literal_block {"ids": [], "linenos": true, "xml:space": "preserve", "language": "csharp"} -->

```csharp
/// some code
```

## Configuring in Startup

Show how to configure application parts and feature providers in Startup using MvcBuilder extension methods.

