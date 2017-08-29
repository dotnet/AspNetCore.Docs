---
title: What's new in ASP.NET Core 2.0
author: rick-anderson
description: What's new in ASP.NET Core 2.0
keywords: ASP.NET Core, release notes, what's new
ms.author: riande
manager: wpickett
ms.date: 07/10/2017
ms.topic: article
ms.assetid: 08c9f457-9c24-40f9-a08b-47dc251e4cec
ms.technology: aspnet
ms.prod: aspnet-core
uid: aspnetcore-2.0
---

# What's new in ASP.NET Core 2.0

This article highlights the most significant changes in ASP.NET Core 2.0, with links to relevant documentation.

## Razor Pages

Razor Pages is a new feature of ASP.NET Core MVC that makes coding page-focused scenarios easier and more productive.

For more information, see the introduction and tutorial:

* [Introduction to Razor Pages](xref:mvc/razor-pages/index)
* [Getting started with Razor Pages](xref:tutorials/razor-pages/razor-pages-start)

## ASP.NET Core metapackage

A new ASP.NET Core metapackage includes all of the packages made and supported by the ASP.NET Core and Entity Framework Core teams, along with their internal and 3rd-party dependencies. You no longer need to choose individual ASP.NET Core features by package. All features are included in the [Microsoft.AspNetCore.All](https://www.nuget.org/packages/Microsoft.AspNetCore.All) package. The default templates use this package.

For more information, see [Microsoft.AspNetCore.All metapackage for ASP.NET Core 2.0](xref:fundamentals/metapackage).

## Runtime Store

Applications that use the `Microsoft.AspNetCore.All` metapackage automatically take advantage of the new .NET Core Runtime Store. The Store contains all the runtime assets needed to run ASP.NET Core 2.0 applications. When you use the `Microsoft.AspNetCore.All` metapackage, no assets from the referenced ASP.NET Core NuGet packages are deployed with the application because they already reside on the target system. The assets in the Runtime Store are also precompiled to improve application startup time.

For more information, see [Runtime store](https://docs.microsoft.com/dotnet/core/deploying/runtime-store)

## .NET Standard 2.0

The ASP.NET Core 2.0 packages target .NET Standard 2.0. The packages can be referenced by other .NET Standard 2.0 libraries, and they can run on .NET Standard 2.0-compliant implementations of .NET, including .NET Core 2.0 and .NET Framework 4.6.1. 

The `Microsoft.AspNetCore.All` metapackage targets .NET Core 2.0 only, because it is intended to be used with the .NET Core 2.0 Runtime Store.

## Configuration update

An `IConfiguration` instance is added to the services container by default in ASP.NET Core 2.0. `IConfiguration` in the services container makes it easier for applications to retrieve configuration values from the container.

For information about the status of planned documentation, see the [GitHub issue](https://github.com/aspnet/Docs/issues/3387).

## Logging update

In ASP.NET Core 2.0, logging is incorporated into the dependency injection (DI) system by default. You add providers and configure filtering in the *Program.cs* file instead of in the *Startup.cs* file. And the default `ILoggerFactory` supports filtering in a way that lets you use one flexible approach for both cross-provider filtering and specific-provider filtering.

For more information, see [Introduction to Logging](xref:fundamentals/logging).

## Authentication update

A new authentication model makes it easier to configure authentication for an application using DI.

New templates are available for configuring authentication for web apps and web APIs using [Azure AD B2C]
(https://azure.microsoft.com/services/active-directory-b2c/).

For information about the status of planned documentation, see the [GitHub issue](https://github.com/aspnet/Docs/issues/3054).

## Identity update

We've made it easier to build secure web APIs using Identity in ASP.NET Core 2.0. You can acquire access tokens for accessing your web APIs using the [Microsoft Authentication Library (MSAL)](https://www.nuget.org/packages/Microsoft.Identity.Client).

For more information on authentication changes in 2.0, see the following resources:

* [Account confirmation and password recovery in ASP.NET Core](xref:security/authentication/accconfirm)
* [Enabling QR Code generation for authenticator apps in ASP.NET Core](xref:security/authentication/identity-enable-qrcodes)
* [Migrating Authentication and Identity to ASP.NET Core 2.0](xref:migration/1x-to-2x/identity-2x)

## SPA templates

Single Page Application (SPA) project templates for Angular, Aurelia, Knockout.js, React.js, and React.js with Redux are available. The Angular template has been updated to Angular 4. The Angular and React templates are available by default; for information about how to get the other templates, see [Creating a new SPA project](xref:client-side/spa-services#creating-a-new-project). For information about how to build a SPA in ASP.NET Core, see [Using JavaScriptServices for Creating Single Page Applications](xref:client-side/spa-services).

## Kestrel improvements

The Kestrel web server has new features that make it more suitable as an Internet-facing server. We’ve added a number of server constraint configuration options in the `KestrelServerOptions` class’s new `Limits` property. You can now add limits for the following:

- Maximum client connections
- Maximum request body size
- Minimum request body data rate

For more information, see [Kestrel web server implementation in ASP.NET Core](xref:fundamentals/servers/kestrel).

## WebListener renamed to HTTP.sys

The packages `Microsoft.AspNetCore.Server.WebListener` and `Microsoft.Net.Http.Server` have been merged into a new package `Microsoft.AspNetCore.Server.HttpSys`. The namespaces have been updated to match.

For more information, see [HTTP.sys web server implementation in ASP.NET Core](xref:fundamentals/servers/httpsys).

## Enhanced HTTP header support

When using MVC to transmit a `FileStreamResult` or a `FileContentResult`, you now have the option to set an `ETag` or a `LastModified` date on the content you transmit. You can set these values on the returned content with code similar to the following:

```csharp
var data = Encoding.UTF8.GetBytes("This is a sample text from a binary array");
var entityTag = new EntityTagHeaderValue("\"MyCalculatedEtagValue\"");
return File(data, "text/plain", "downloadName.txt", lastModified: DateTime.UtcNow.AddSeconds(-5), entityTag: entityTag);
```

The file returned to your visitors will be decorated with the appropriate HTTP headers for the `ETag` and `LastModified` values.

If an application visitor requests content with a Range Request header, ASP.NET will recognize that and handle that header. If the requested content can be partially delivered, ASP.NET will appropriately skip and return just the requested set of bytes.  You do not need to write any special handlers into your methods to adapt or handle this feature; it is automatically handled for you.

## Hosting startup and Application Insights

Hosting environments can now inject extra package dependencies and execute code during application startup, without the application needing to explicitly take a dependency or call any methods. This feature can be used to enable certain environments to "light-up" features unique to that environment without the application needing to know ahead of time. 

In ASP.NET Core 2.0, this feature is used to automatically enable Application Insights diagnostics when debugging in Visual Studio and (after opting in) when running in Azure App Services. As a result, the project templates no longer add Application Insights packages and code by default.

For information about the status of planned documentation, see the [GitHub issue](https://github.com/aspnet/Docs/issues/3389).

## Automatic use of anti-forgery tokens

ASP.NET Core has always helped HTML-encode your content by default, but with the new version we’re taking an extra step to help prevent cross-site request forgery (XSRF) attacks. ASP.NET Core will now emit anti-forgery tokens by default and validate them on form POST actions and pages without extra configuration.

For more information, see [Preventing Cross-Site Request Forgery (XSRF/CSRF) Attacks in ASP.NET Core](xref:security/anti-request-forgery).

## Automatic precompilation

Razor view pre-compilation is enabled during publish by default, reducing the publish output size and application startup time.

## Razor support for C# 7.1

The Razor view engine has been updated to work with the new Roslyn compiler. That includes support for C# 7.1 features like Default Expressions, Inferred Tuple Names, and Pattern-Matching with Generics. To use C# 7.1 in your project, add the following property in your project file and then reload the solution:

```xml
<LangVersion>latest</LangVersion>
```

For information about the status of C# 7.1 features, see [the Roslyn GitHub repository](https://github.com/dotnet/roslyn/blob/master/docs/Language%20Feature%20Status.md).

## Other documentation updates for 2.0

* [Create publish profiles for Visual Studio and MSBuild, to deploy ASP.NET Core apps](xref:publishing/web-publishing-vs)
* [Key Management](xref:security/data-protection/implementation/key-management)
* [Configuring Facebook authentication](xref:security/authentication/facebook-logins)
* [Configuring Twitter authentication](xref:security/authentication/twitter-logins)
* [Configuring Google authentication](xref:security/authentication/google-logins)
* [Configuring Microsoft Account authentication](xref:security/authentication/microsoft-logins)
* [Setting up HTTPS for development in ASP.NET Core](xref:security/https)

## Migration guidance

For guidance on how to migrate ASP.NET Core 1.x applications to ASP.NET Core 2.0, see the following resources:

* [Migrating from ASP.NET Core 1.x to ASP.NET Core 2.0](xref:migration/1x-to-2x/index)
* [Migrating Authentication and Identity to ASP.NET Core 2.0](xref:migration/1x-to-2x/identity-2x)

## Additional Information

For the complete list of changes, see the [ASP.NET Core 2.0 Release Notes](https://github.com/aspnet/Home/releases/tag/2.0.0).

If you’d like to connect with the ASP.NET Core development team’s progress and plans, tune in to the weekly [ASP.NET Community Standup](https://live.asp.net/).
