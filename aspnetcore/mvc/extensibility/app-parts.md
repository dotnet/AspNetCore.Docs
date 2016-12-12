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

MVC apps load their features from [application parts](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.mvc.applicationparts.applicationpart). In particular, the [AssemblyPart](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.mvc.applicationparts.assemblypart#Microsoft_AspNetCore_Mvc_ApplicationParts_AssemblyPart) class represents an assembly part that is backed by an assembly. You can use these classes to discover and load MVC features, such as controllers, view components, tag helpers, and razor compilation sources. The [ApplicationPartManager](https://docs.microsoft.com/en-us/aspnet/core/api/microsoft.aspnetcore.mvc.applicationparts.applicationpartmanager) is responsible for tracking the application parts and feature providers available to the MVC app. You interact with the manager in Startup when you configure MVC:

<!-- literal_block {"ids": [], "linenos": true, "xml:space": "preserve", "language": "csharp"} -->

```csharp
services
    .AddMvc()
    .ConfigureApplicationPartManager(apm => p.FeatureProviders.Add(new YourFeatureProvider()))
```

## Application Feature Providers

asdf

<!-- literal_block {"ids": [], "linenos": true, "xml:space": "preserve", "language": "csharp"} -->

```csharp
/// some code
```

## Configuring in Startup

Show how to configure application parts and feature providers in Startup using MvcBuilder extension methods.

