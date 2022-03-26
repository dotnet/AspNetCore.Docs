---
title: Migrate from ASP.NET to ASP.NET Core
author: isaacrlevin
description: Receive guidance for migrating existing ASP.NET MVC or Web API apps to ASP.NET Core.web
ms.author: scaddie
ms.date: 10/18/2019
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: migration/proper-to-2x/index
---
# Migrate from ASP.NET to ASP.NET Core

By [Isaac Levin](https://isaaclevin.com)

This article serves as a reference guide for migrating ASP.NET apps to ASP.NET Core. See the ebook [Porting existing ASP.NET apps to .NET Core](https://aka.ms/aspnet-porting-ebook) for a comprehensive porting guide.

## Prerequisites

[.NET Core SDK 2.2 or later](https://dotnet.microsoft.com/download)

## Target frameworks

ASP.NET Core projects offer developers the flexibility of targeting .NET Core, .NET Framework, or both. See [Choosing between .NET Core and .NET Framework for server apps](/dotnet/standard/choosing-core-framework-server) to determine which target framework is most appropriate.

When targeting .NET Framework, projects need to reference individual NuGet packages.

Targeting .NET Core allows you to eliminate numerous explicit package references, thanks to the ASP.NET Core [metapackage](xref:fundamentals/metapackage-app). Install the `Microsoft.AspNetCore.App` metapackage in your project:

```xml
<ItemGroup>
   <PackageReference Include="Microsoft.AspNetCore.App" />
</ItemGroup>
```

When the metapackage is used, no packages referenced in the metapackage are deployed with the app. The .NET Core Runtime Store includes these assets, and they're precompiled to improve performance. See [Microsoft.AspNetCore.App metapackage for ASP.NET Core](xref:fundamentals/metapackage-app) for more detail.

## Project structure differences

The `.csproj` file format has been simplified in ASP.NET Core. Some notable changes include:

- Explicit inclusion of files isn't necessary for them to be considered part of the project. This reduces the risk of XML merge conflicts when working on large teams.
- There are no GUID-based references to other projects, which improves file readability.
- The file can be edited without unloading it in Visual Studio:

    ![Edit CSPROJ context menu option in Visual Studio 2017](_static/EditProjectVs2017.png)

## Global.asax file replacement

ASP.NET Core introduced a new mechanism for bootstrapping an app. The entry point for ASP.NET applications is the *Global.asax* file. Tasks such as route configuration and filter and area registrations are handled in the *Global.asax* file.

[!code-csharp[](samples/globalasax-sample.cs)]

This approach couples the application and the server to which it's deployed in a way that interferes with the implementation. In an effort to decouple, [OWIN](https://owin.org/) was introduced to provide a cleaner way to use multiple frameworks together. OWIN provides a pipeline to add only the modules needed. The hosting environment takes a [Startup](xref:fundamentals/startup) function to configure services and the app's request pipeline. `Startup` registers a set of middleware with the application. For each request, the application calls each of the middleware components with the head pointer of a linked list to an existing set of handlers. Each middleware component can add one or more handlers to the request handling pipeline. This is accomplished by returning a reference to the handler that's the new head of the list. Each handler is responsible for remembering and invoking the next handler in the list. With ASP.NET Core, the entry point to an application is `Startup`, and you no longer have a dependency on *Global.asax*. When using OWIN with .NET Framework, use something like the following as a pipeline:

[!code-csharp[](samples/webapi-owin.cs)]

This configures your default routes, and defaults to XmlSerialization over Json. Add other Middleware to this pipeline as needed (loading services, configuration settings, static files, etc.).

ASP.NET Core uses a similar approach, but doesn't rely on OWIN to handle the entry. Instead, that's done through the `Program.cs` `Main` method (similar to console applications) and `Startup` is loaded through there.

[!code-csharp[](samples/program.cs)]

`Startup` must include a `Configure` method. In `Configure`, add the necessary middleware to the pipeline. In the following example (from the default web site template), extension methods configure the pipeline with support for:

- Error pages
- HTTP Strict Transport Security
- HTTP redirection to HTTPS
- ASP.NET Core MVC

[!code-csharp[](samples/startup.cs)]

The host and application have been decoupled, which provides the flexibility of moving to a different platform in the future.

> [!NOTE]
> For a more in-depth reference to ASP.NET Core Startup and Middleware, see [Startup in ASP.NET Core](xref:fundamentals/startup)

## Store configurations

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

> [!NOTE]
> For a more in-depth reference to ASP.NET Core configuration, see [Configuration in ASP.NET Core](xref:fundamentals/configuration/index).

## Native dependency injection

An important goal when building large, scalable applications is the loose coupling of components and services. [Dependency Injection](xref:fundamentals/dependency-injection) is a popular technique for achieving this, and it's a native component of ASP.NET Core.

In ASP.NET apps, developers rely on a third-party library to implement Dependency Injection. One such library is [Unity](https://github.com/unitycontainer/unity), provided by Microsoft Patterns & Practices.

An example of setting up Dependency Injection with Unity is implementing `IDependencyResolver` that wraps a `UnityContainer`:

[!code-csharp[](samples/sample8.cs)]

Create an instance of your `UnityContainer`, register your service, and set the dependency resolver of `HttpConfiguration` to the new instance of `UnityResolver` for your container:

[!code-csharp[](samples/sample9.cs)]

Inject `IProductRepository` where needed:

[!code-csharp[](samples/sample5.cs)]

Because Dependency Injection is part of ASP.NET Core, you can add your service in the `ConfigureServices` method of `Startup.cs`:

[!code-csharp[](samples/configure-services.cs)]

The repository can be injected anywhere, as was true with Unity.

> [!NOTE]
> For more information on dependency injection, see [Dependency injection](xref:fundamentals/dependency-injection).

## Serve static files

An important part of web development is the ability to serve static, client-side assets. The most common examples of static files are HTML, CSS, Javascript, and images. These files need to be saved in the published location of the app (or CDN) and referenced so they can be loaded by a request. This process has changed in ASP.NET Core.

In ASP.NET, static files are stored in various directories and referenced in the views.

In ASP.NET Core, static files are stored in the "web root" (*&lt;content root&gt;/wwwroot*), unless configured otherwise. The files are loaded into the request pipeline by invoking the `UseStaticFiles` extension method from `Startup.Configure`:

[!code-csharp[](../../fundamentals/static-files/samples/1.x/StaticFilesSample/StartupStaticFiles.cs?highlight=3&name=snippet_ConfigureMethod)]

> [!NOTE]
> If targeting .NET Framework, install the NuGet package `Microsoft.AspNetCore.StaticFiles`.

For example, an image asset in the *wwwroot/images* folder is accessible to the browser at a location such as `http://<app>/images/<imageFileName>`.

> [!NOTE]
> For a more in-depth reference to serving static files in ASP.NET Core, see [Static files](xref:fundamentals/static-files).

## Multi-value cookies

[Multi-value cookies](xref:System.Web.HttpCookie.Values) aren't supported in ASP.NET Core. Create one cookie per value.

## Authentication cookies are not compressed in ASP.NET Core

[!INCLUDE[](~/includes/cookies-not-compressed.md)]

## Partial app migration

One approach to partial app migration is to create an IIS sub-application and only move certain routes from ASP.NET 4.x to ASP.NET Core while preserving the URL structure the app. For example, consider the URL structure of the app from the *applicationHost.config* file:

```xml
<sites>
    <site name="Default Web Site" id="1" serverAutoStart="true">
        <application path="/">
            <virtualDirectory path="/" physicalPath="D:\sites\MainSite\" />
        </application>
        <application path="/api" applicationPool="DefaultAppPool">
            <virtualDirectory path="/" physicalPath="D:\sites\netcoreapi" />
        </application>
        <bindings>
            <binding protocol="http" bindingInformation="*:80:" />
            <binding protocol="https" bindingInformation="*:443:" sslFlags="0" />
        </bindings>
    </site>
	...
</sites>
```

Directory structure:

```
.
├── MainSite
│   ├── ...
│   └── Web.config
└── NetCoreApi
    ├── ...
    └── web.config
```

## [BIND] and Input Formatters

[Previous versions of ASP.NET](/aspnet/mvc/overview/getting-started/introduction/examining-the-edit-methods-and-edit-view) used the `[Bind]` attribute to protect against overposting attacks. [Input formatters](xref:mvc/models/model-binding#input-formatters) work differently in ASP.NET Core. The `[Bind]` attribute is no longer designed to prevent overposting when used with input formatters to parse JSON or XML. These attributes affect model binding when the source of data is form data posted with the `x-www-form-urlencoded` content type.

For apps that post JSON information to controllers and use JSON Input Formatters to parse the data, we recommend replacing the `[Bind]` attribute with a view model that matches the properties defined by the `[Bind]` attribute.

## Additional resources

- [Porting Libraries to .NET Core](/dotnet/core/porting/libraries)
