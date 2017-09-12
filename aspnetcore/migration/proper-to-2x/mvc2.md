---
title: Migrating From ASP.NET to ASP.NET Core 2.0
author: isaac2004
description: This reference document provides guidance for migrating existing ASP.NET MVC or Web API applications to ASP.NET Core 2.0.
keywords: ASP.NET Core,MVC,migrating
ms.author: scaddie
manager: wpickett
ms.date: 08/27/2017
ms.topic: article
ms.assetid: 3155cc9e-d0c9-424b-886c-35c0ec6f9f4e
ms.technology: aspnet
ms.prod: asp.net-core
uid: migration/mvc2
---

# Migrating From ASP.NET to ASP.NET Core 2.0

By [Isaac Levin](https://isaaclevin.com)

This article serves as a reference guide for migrating ASP.NET applications to ASP.NET Core 2.0.

## Prerequisites

* [.NET Core 2.0.0 SDK](https://www.microsoft.com/net/core) or later.

## Target Frameworks
ASP.NET Core 2.0 projects offer developers the flexibility of targeting .NET Core, .NET Framework, or both. See [Choosing between .NET Core and .NET Framework for server apps](https://docs.microsoft.com/dotnet/standard/choosing-core-framework-server) to determine which target framework is most appropriate.

When targeting .NET Framework, projects need to reference individual NuGet packages.

Targeting .NET Core allows you to eliminate numerous explicit package references, thanks to the ASP.NET Core 2.0 [metapackage](xref:fundamentals/metapackage). Install the `Microsoft.AspNetCore.All` metapackage in your project:

```xml
<ItemGroup>
  <PackageReference Include="Microsoft.AspNetCore.All" Version="2.0.0" />
</ItemGroup>
```

When the metapackage is used, no packages referenced in the metapackage are deployed with the app. The .NET Core Runtime Store includes these assets, and they are precompiled to improve performance. See [Microsoft.AspNetCore.All metapackage for ASP.NET Core 2.x](xref:fundamentals/metapackage) for more detail.

## Project structure differences
The *.csproj* file format has been simplified in ASP.NET Core. Some notable changes include:
- Explicit inclusion of files is not necessary for them to be considered part of the project. This reduces the risk of XML merge conflicts when working on large teams.
- There are no GUID-based references to other projects, which improves file readability.
- The file can be edited without unloading it in Visual Studio:

    ![Edit CSPROJ context menu option in Visual Studio 2017](_static/EditProjectVs2017.png)

## Global.asax file replacement
ASP.NET Core introduced a new mechanism for bootstrapping an app. The entry point for ASP.NET applications is the *Global.asax* file. Tasks such as route configuration and filter and area registrations are handled in the *Global.asax* file.

[!code-csharp[Main](samples/globalasax-sample.cs)]

This approach couples the application and the server to which it's deployed in a way that interferes with the implementation. In an effort to decouple, [OWIN](http://owin.org/) was introduced to provide a cleaner way to use multiple frameworks together. OWIN provides a pipeline to add only the modules needed. The hosting environment takes a [Startup](xref:fundamentals/startup) function to configure services and the app's request pipeline. `Startup` registers a set of middleware with the application. For each request, the application calls each of the the middleware components with the head pointer of a linked list to an existing set of handlers. Each middleware component can add one or more handlers to the request handling pipeline. This is accomplished by returning a reference to the handler that is the new head of the list. Each handler is responsible for remembering and invoking the next handler in the list. With ASP.NET Core, the entry point to an application is `Startup`, and you no longer have a dependency on *Global.asax*. When using OWIN with .NET Framework, use something like the following as a pipeline:

[!code-csharp[Main](samples/webapi-owin.cs)]

This configures your default routes, and defaults to XmlSerialization over Json. Add other Middleware to this pipeline as needed (loading services, configuration settings, static files, etc.).

ASP.NET Core uses a similar approach, but doesn't rely on OWIN to handle the entry. Instead, that is done through the *Program.cs* `Main` method (similar to console applications) and `Startup` is loaded through there.

[!code-csharp[Main](samples/program.cs)]

`Startup` must include a `Configure` method. In `Configure`, add the necessary middleware to the pipeline. In the following example (from the default web site template), several extension methods are used to configure the pipeline with support for:

* [BrowserLink](http://vswebessentials.com/features/browserlink)
* Error pages
* Static files
* ASP.NET Core MVC
* Identity

[!code-csharp[Main](../../common/samples/WebApplication1/Startup.cs?highlight=8,9,10,14,17,19,21&start=58&end=84)]

The host and application have been decoupled, which provides the flexibility of moving to a different platform in the future.

**Note:** For a more in-depth reference to ASP.NET Core Startup and Middleware, see [Startup in ASP.NET Core](xref:fundamentals/startup)

## Storing Configurations
ASP.NET supports storing settings. These setting are used, for example, to support the environment to which the applications were deployed. A common practice was to store all custom key-value pairs in the `<appSettings>` section of the *Web.config* file:

[!code-xml[Main](samples/webconfig-sample.xml)]

Applications read these settings using the `ConfigurationManager.AppSettings` collection in the `System.Configuration` namespace:

[!code-csharp[Main](samples/read-webconfig.cs)]

ASP.NET Core can store configuration data for the application in any file and load them as part of middleware bootstrapping. The default file used in the project templates is *appsettings.json*:

[!code-json[Main](samples/appsettings-sample.json)]

Loading this file into an instance of `IConfiguration` inside your application is done in *Startup.cs*:

[!code-csharp[Main](samples/startup-builder.cs)]

The app reads from `Configuration` to get the settings:

[!code-csharp[Main](samples/read-appsettings.cs)]

There are extensions to this approach to make the process more robust, such as using [Dependency Injection](xref:fundamentals/dependency-injection) (DI) to load a service with these values. The DI approach provides a strongly-typed set of configuration objects.

````csharp
// Assume AppConfiguration is a class representing a strongly-typed version of AppConfiguration section
services.Configure<AppConfiguration>(Configuration.GetSection("AppConfiguration"));
````

**Note:** For a more in-depth reference to ASP.NET Core configuration, see [Configuration in ASP.NET Core](xref:fundamentals/configuration).

## Native Dependency Injection
An important goal when building large, scalable applications is the loose coupling of components and services. [Dependency Injection](xref:fundamentals/dependency-injection) is a popular technique for achieving this, and it is a native component of ASP.NET Core.

In ASP.NET applications, developers rely on a third-party library to implement Dependency Injection. One such library is [Unity](https://github.com/unitycontainer/unity), provided by Microsoft Patterns & Practices. 

An example of setting up Dependency Injection with Unity is implementing `IDependencyResolver` that wraps a `UnityContainer`:

[!code-csharp[Main](../../../aspnet/web-api/overview/advanced/dependency-injection/samples/sample8.cs)]

Create an instance of your `UnityContainer`, register your service, and set the dependency resolver of `HttpConfiguration` to the new instance of `UnityResolver` for your container:

[!code-csharp[Main](../../../aspnet/web-api/overview/advanced/dependency-injection/samples/sample9.cs)]

Inject `IProductRepository` where needed:

[!code-csharp[Main](../../../aspnet/web-api/overview/advanced/dependency-injection/samples/sample5.cs)]

Because Dependency Injection is part of ASP.NET Core, you can add your service in the `ConfigureServices` method of *Startup.cs*:

[!code-csharp[Main](samples/configure-services.cs)]

The repository can be injected anywhere, as was true with Unity.

**Note:** For an in-depth reference to dependency injection in ASP.NET Core, see [Dependency Injection in ASP.NET Core](xref:fundamentals/dependency-injection#replacing-the-default-services-container)

## Serving Static Files
An important part of web development is the ability to serve static, client-side assets. The most common examples of static files are HTML, CSS, Javascript, and images. These files need to be saved in the published location of the app (or CDN) and referenced so they can be loaded by a request. This process has changed in ASP.NET Core.

In ASP.NET, static files are stored in various directories and referenced in the views.

In ASP.NET Core, static files are stored in the "web root" (*&lt;content root&gt;/wwwroot*), unless configured otherwise. The files are loaded into the request pipeline by invoking the `UseStaticFiles` extension method from `Startup.Configure`:

[!code-csharp[Main](../../fundamentals/static-files/sample/StartupStaticFiles.cs?highlight=3&name=snippet1)]

**Note:** If targeting .NET Framework, install the NuGet package `Microsoft.AspNetCore.StaticFiles`.

For example, an image asset in the *wwwroot/images* folder is accessible to the browser at a location such as `http://<app>/images/<imageFileName>`.

**Note:** For a more in-depth reference to serving static files in ASP.NET Core, see [Introduction to working with static files in ASP.NET Core](xref:fundamentals/static-files).

## Additional Resources
* [Porting Libraries to .NET Core](https://docs.microsoft.com/dotnet/core/porting/libraries)
