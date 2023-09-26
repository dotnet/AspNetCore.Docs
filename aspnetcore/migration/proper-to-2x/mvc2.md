---
title: Migrate from ASP.NET to ASP.NET Core 2.0
author: isaacrlevin
description: Receive guidance for migrating existing ASP.NET MVC or Web API applications to ASP.NET Core 2.0.
ms.author: scaddie
ms.custom: mvc
ms.date: 10/24/2018
uid: migration/mvc2
---
# Migrate from ASP.NET to ASP.NET Core 2.0

By [Isaac Levin](https://isaaclevin.com)

This article serves as a reference guide for migrating ASP.NET applications to ASP.NET Core 2.0.

## Prerequisites

Install **one** of the following from [.NET Downloads: Windows](https://dotnet.microsoft.com/download):

* .NET Core SDK
* Visual Studio for Windows
  * **ASP.NET and web development** workload
  * **.NET Core cross-platform development** workload

## Target frameworks

ASP.NET Core 2.0 projects offer developers the flexibility of targeting .NET Core, .NET Framework, or both. See [Choosing between .NET Core and .NET Framework for server apps](/dotnet/standard/choosing-core-framework-server) to determine which target framework is most appropriate.

When targeting .NET Framework, projects need to reference individual NuGet packages.

Targeting .NET Core allows you to eliminate numerous explicit package references, thanks to the ASP.NET Core 2.0 [metapackage](xref:fundamentals/metapackage). Install the `Microsoft.AspNetCore.All` metapackage in your project:

```xml
<ItemGroup>
  <PackageReference Include="Microsoft.AspNetCore.All" Version="2.0.9" />
</ItemGroup>
```

When the metapackage is used, no packages referenced in the metapackage are deployed with the app. The .NET Core Runtime Store includes these assets, and they're precompiled to improve performance. See <xref:fundamentals/metapackage> for more detail.

## Project structure differences

The `.csproj` file format has been simplified in ASP.NET Core. Some notable changes include:

* Explicit inclusion of files isn't necessary for them to be considered part of the project. This reduces the risk of XML merge conflicts when working on large teams.
* There are no GUID-based references to other projects, which improves file readability.
* The file can be edited without unloading it in Visual Studio:

  ![Edit CSPROJ context menu option in Visual Studio 2017](_static/EditProjectVs2017.png)

## Global.asax file replacement

ASP.NET Core introduced a new mechanism for bootstrapping an app. The entry point for ASP.NET applications is the *Global.asax* file. Tasks such as route configuration and filter and area registrations are handled in the *Global.asax* file.

[!code-csharp[](samples/globalasax-sample.cs)]

This approach couples the application and the server to which it's deployed in a way that interferes with the implementation. In an effort to decouple, [OWIN](https://owin.org/) was introduced to provide a cleaner way to use multiple frameworks together. OWIN provides a pipeline to add only the modules needed. The hosting environment takes a [Startup](xref:fundamentals/startup) function to configure services and the app's request pipeline. `Startup` registers a set of middleware with the application. For each request, the application calls each of the middleware components with the head pointer of a linked list to an existing set of handlers. Each middleware component can add one or more handlers to the request handling pipeline. This is accomplished by returning a reference to the handler that's the new head of the list. Each handler is responsible for remembering and invoking the next handler in the list. With ASP.NET Core, the entry point to an application is `Startup`, and you no longer have a dependency on *Global.asax*. When using OWIN with .NET Framework, use something like the following as a pipeline:

[!code-csharp[](samples/webapi-owin.cs)]

This configures your default routes, and defaults to XmlSerialization over Json. Add other Middleware to this pipeline as needed (loading services, configuration settings, static files, etc.).

ASP.NET Core uses a similar approach, but doesn't rely on OWIN to handle the entry. Instead, that's done through the `Program.cs` `Main` method (similar to console applications) and `Startup` is loaded through there.

[!code-csharp[](samples/program.cs)]

`Startup` must include a `Configure` method. In `Configure`, add the necessary middleware to the pipeline. In the following example (from the default web site template), several extension methods are used to configure the pipeline with support for:

* BrowserLink
* Error pages
* Static files
* ASP.NET Core MVC
* Identity

[!code-csharp[](../../common/samples/WebApplication1/Startup.cs?highlight=8,9,10,14,17,19,21&start=58&end=84)]

The host and application have been decoupled, which provides the flexibility of moving to a different platform in the future.

For a more in-depth reference to ASP.NET Core Startup and Middleware, see <xref:fundamentals/startup>.

## Storing configurations

ASP.NET supports storing settings. These setting are used, for example, to support the environment to which the applications were deployed. A common practice was to store all custom key-value pairs in the `<appSettings>` section of the *Web.config* file:

[!code-xml[](samples/webconfig-sample.xml)]

Applications read these settings using the `ConfigurationManager.AppSettings` collection in the `System.Configuration` namespace:

[!code-csharp[](samples/read-webconfig.cs)]

ASP.NET Core can store configuration data for the application in any file and load them as part of middleware bootstrapping. The default file used in the project templates is `appsettings.json`:

[!code-json[](samples/appsettings-sample.json)]

Loading this file into an instance of `IConfiguration` inside your application is done in `Startup.cs`:

[!code-csharp[](samples/startup-builder.cs)]

The app reads from `Configuration` to get the settings:

[!code-csharp[](samples/read-appsettings.cs)]

There are extensions to this approach to make the process more robust, such as using [Dependency Injection](xref:fundamentals/dependency-injection) (DI) to load a service with these values. The DI approach provides a strongly-typed set of configuration objects.

```csharp
// Assume AppConfiguration is a class representing a strongly-typed version of AppConfiguration section
services.Configure<AppConfiguration>(Configuration.GetSection("AppConfiguration"));
```

**Note:** For a more in-depth reference to ASP.NET Core configuration, see <xref:fundamentals/configuration/index>.

## Native dependency injection

An important goal when building large, scalable applications is the loose coupling of components and services. [Dependency injection](xref:fundamentals/dependency-injection) is a popular technique for achieving this, and it's a native component of ASP.NET Core.

In ASP.NET applications, developers rely on a third-party library to implement dependency injection. One such library is [Unity](https://github.com/unitycontainer/unity), provided by Microsoft Patterns & Practices.

An example of setting up dependency injection with Unity is implementing `IDependencyResolver` that wraps a `UnityContainer`:

[!code-csharp[](samples/sample8.cs)]

Create an instance of your `UnityContainer`, register your service, and set the dependency resolver of `HttpConfiguration` to the new instance of `UnityResolver` for your container:

[!code-csharp[](samples/sample9.cs)]

Inject `IProductRepository` where needed:

[!code-csharp[](samples/sample5.cs)]

Because dependency injection is part of ASP.NET Core, you can add your service in the `Startup.ConfigureServices`:

[!code-csharp[](samples/configure-services.cs)]

The repository can be injected anywhere, as was true with Unity.

For more information on dependency injection in ASP.NET Core, see <xref:fundamentals/dependency-injection>.

## Serving static files

An important part of web development is the ability to serve static, client-side assets. The most common examples of static files are HTML, CSS, Javascript, and images. These files need to be saved in the published location of the app (or CDN) and referenced so they can be loaded by a request. This process has changed in ASP.NET Core.

In ASP.NET, static files are stored in various directories and referenced in the views.

In ASP.NET Core, static files are stored in the "web root" (*&lt;content root&gt;/wwwroot*), unless configured otherwise. The files are loaded into the request pipeline by invoking the `UseStaticFiles` extension method from `Startup.Configure`:

[!code-csharp[](../../fundamentals/static-files/samples/1.x/StaticFilesSample/StartupStaticFiles.cs?highlight=3&name=snippet_ConfigureMethod)]

**Note:** If targeting .NET Framework, install the NuGet package `Microsoft.AspNetCore.StaticFiles`.

For example, an image asset in the *wwwroot/images* folder is accessible to the browser at a location such as `http://<app>/images/<imageFileName>`.

**Note:** For a more in-depth reference to serving static files in ASP.NET Core, see <xref:fundamentals/static-files>.

## Additional resources

* [Porting Libraries to .NET Core](/dotnet/core/porting/libraries)
