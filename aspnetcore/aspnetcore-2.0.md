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

# What's new in ASP.NET Core 2.0 Preview

> [!NOTE]
> ASP.NET Core 2.0 is in preview, and some of the documentation for it has not yet been written. This document links to GitHub issues for articles that are planned but not yet published. For information about how to install ASP.NET 2.0 Preview 2, see [Introducing ASP.NET Core 2.0 Preview 2](https://blogs.msdn.microsoft.com/webdev/2017/06/28/introducing-asp-net-core-2-0-preview-2/)

Here are some of the most significant updates in ASP.NET Core 2.0:

- [Razor Pages](xref:mvc/razor-pages/index)
- [ASP.NET Core metapackage](#aspnet-core-metapackage)
- [.NET Standard 2.0](#net-standard-20)
- [Configuration update](#configuration-update)
- [Logging update](#logging-update)
- [Authentication update](#authentication-update)
- [Identity update](#identity-update)
- [SPA templates](#spa-templates)
- [Kestrel improvements](#kestrel-improvements)
- [WebListener renamed to HttpSys](#weblistener-renamed-to-httpsys)
- [Enhanced HTTP header support](#enhanced-http-header-support)
- [Hosting startup and Application Insights](#hosting-startup-and-application-insights)
- [Automatic use of anti-forgery tokens](#automatic-use-of-anti-forgery-tokens)
- [Automatic precompilation](#automatic-precompilation)
- [Razor support for C# 7.1](#razor-support-for-c-71)

For the complete list of changes, see the [ASP.NET Core Release Notes](https://github.com/aspnet/Home/releases/).

<!--
For guidance on how to migrate ASP.NET Core 1.x applications to ASP.NET Core 2.0, see [Migrate from 1.x to 2.0](https://github.com/aspnet/Docs/issues/3548).
-->

## ASP.NET Core metapackage

A new ASP.NET Core metapackage includes all of the packages made and supported by the ASP.NET Core and Entity Framework Core teams, along with their internal and 3rd-party dependencies. You no longer need to choose individual ASP.NET Core features by package. All features are included in the [Microsoft.AspNetCore.All](https://www.nuget.org/packages/Microsoft.AspNetCore.All) package. The default templates use this package.

The version number of the `Microsoft.AspNetCore.All` metapackage represents the latest ASP.NET Core version (aligned with the .NET Core version).

Applications that use the `Microsoft.AspNetCore.All` metapackage automatically take advantage of the new .NET Core Runtime Store. The Runtime Store will contain all the runtime assets needed to run ASP.NET Core 2.0 applications. When you use the `Microsoft.AspNetCore.All` metapackage, no assets from the referenced ASP.NET Core NuGet packages are deployed with the application because they already reside on the target system. The assets in the Runtime Store are also precompiled to improve application startup-time.

If there are features you don’t use in your application, the new package trimming features will exclude those binaries in the published application output.

For information about the status of planned documentation, see the following GitHub issues:
   
* [Metapackage issue](https://github.com/aspnet/Docs/issues/3449)
* [Runtime Store issue](https://github.com/aspnet/Docs/issues/3667)
* [Package trimming issue](https://github.com/dotnet/docs/issues/1745)

## .NET Standard 2.0

The ASP.NET Core 2.0 packages target .NET Standard 2.0. The packages can be referenced by other .NET Standard 2.0 libraries, and they can run on .NET Standard 2.0-compliant implementations of .NET, including .NET Core 2.0 and .NET Framework 4.6.1. 

The `Microsoft.AspNetCore.All` metapackage targets .NET Core 2.0 only, because it is intended to be used with the .NET Core 2.0 Runtime Store.

For information about the status of planned documentation, see the [GitHub issue](https://github.com/aspnet/Docs/issues/3449).

## Configuration update

An `IConfiguration` instance is added to the services container by default in ASP.NET Core 2.0. `IConfiguration` in the services container makes it easier for applications to retrieve configuration values from the container.

For information about the status of planned documentation, see the [GitHub issue](https://github.com/aspnet/Docs/issues/3387).

## Logging update

In ASP.NET 2.0, logging is incorporated into the dependency injection (DI) system by default. You add providers and configure filtering in the *Program.cs* file instead of in the *Startup.cs* file. Here's an example that shows how to add providers and specify that configuration is used to set up filtering:

```csharp
var builder = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = hostingContext.HostingEnvironment;
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                    config.AddEnvironmentVariables();
                })
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    logging.AddConsole();
                    logging.AddDebug();
                });
```

The ASP.NET Core 2.0 project templates set up configuration and logging as shown above by default. If you only need `Console` and `Debug` logging and a `Logging` configuration section to control filtering, you don't need to add any extra code. However, you won't see the preceding code in your projects because the project template code calls a `CreateDefaultBuilder` method to do all that.  Here's the project template code with an extra `ConfigureLogging` call that shows how to add a provider:

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseStartup<Startup>()
    .ConfigureLogging(logging => logging.AddEventLog())
    .Build();
```

### Configuring filtering

In ASP.NET Core 1.x, it's difficult to configure filtering: the way to do it across providers is not intuitive, and if you do it for individual providers, each provider handles it differently. In 2.0 we have changed the default `ILoggerFactory` to support filtering in a way that lets you use one flexible approach for both cross-provider filtering and specific-provider filtering.  This approach to filtering is designed to work with `IConfiguration`, so you can control filtering from whatever configuration sources you choose. 

### Create filter rules in configuration

The `CreateDefaultBuilder` method sets up logging to look for configuration in a `Logging` section. The configuration data specifies minimum log levels by provider and category, as in the following example:

```json
{
  "Logging": {
    "IncludeScopes": false,
    "Debug": {
      "LogLevel": {
        "Default": "Warning"
      }
    },
    "Console": {
      "LogLevel": {
        "Microsoft.AspNetCore.Mvc.Razor.Internal": "Warning",
        "Microsoft.AspNetCore.Mvc.Razor.Razor": "Debug",
        "Microsoft.AspNetCore.Mvc.Razor": "Error",
        "Default": "Warning"
      }
    },
    "": {
      "LogLevel": {
        "Default": "Debug"
      }
    }
  }
}

```

This JSON creates six filter rules, one for the Debug provider, four for the Console provider, and one that applies to all providers. You'll see [later](#how-filtering-rules-are-applied) how a single rule is chosen for each provider when an `ILogger` object is created.

### Filter rules in code

You can register filter rules in code, as shown in the following example:

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseStartup<Startup>()
    .ConfigureLogging(logging =>
        logging.AddFilter("System", LogLevel.Debug)
               .AddFilter<DebugLoggerProvider>("Microsoft", LogLevel.Trace))
    .Build();
```

The second `AddFilter` specifies the Debug provider by using its type name. The first `AddFilter` call applies to all providers because it doesn't specify a provider type.

### How filtering rules are applied

The configuration data and the `AddFilter` code shown in the preceding examples create the following rules. The first six come from the [configuration example](#create-filter-rules-in-configuration) and the last two come from the [code example](#filter-rules-in-code):

Number|Provider|Categories that begin with|Minimum log level|
------|--------|--------------------------|-----------------|
1|Debug|All categories|Warning|
2|Console|Microsoft.AspNetCore.Mvc.Razor.Internal|Warning|
3|Console|Microsoft.AspNetCore.Mvc.Razor.Razor|Debug|
4|Console|Microsoft.AspNetCore.Mvc.Razor|Error|
5|Console|All categories|Warning|
6|All providers|All categories|Warning
7|All providers|System|Debug
8|Debug|Microsoft|Trace

When you create an `ILogger` object to write logs with, the `ILoggerFactory` object selects a single rule per provider to apply to that logger. All messages written to that `ILogger` object are filtered based on the selected rules. The most specific rule possible for each provider and category pair is selected from the available rules.

The following algorithm is used for each provider when an `ILogger` is created for a given category:

* Select all rules that match the provider or its alias.  If none are found, select all rules with an empty provider.
* From the result of the preceding step, select rules with longest matching category prefix. If none are found, select all rules that don't specify a category.
* If multiple rules are selected take the **last** one.
* If no rules are selected, use `MinimumLevel`.
 
For example, suppose you have the preceding list of rules and you create an `ILogger` object for category "Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine":

* For the Debug provider, rules 1, 6, and 8 apply. Rule 8 is most specific, so that's the one selected.
* For the Console provider, rules 3, 4, 5, and 6 apply. Rule 3 is most specific.

When you create logs with that `ILogger`, logs of Trace level and above will go to the Debug provider, and logs of Debug level and above will go to the Console provider.

### Provider aliases

You can use the type name to specify a provider in configuration, but each provider defines a shorter *alias* that is easier to use. For the built-in providers, use the following aliases:

- Console
- Debug
- EventLog
- AzureAppServices
- TraceSource
- EventSource

### Default minimum level

You set the default minimum level by calling `SetMinimumLevel`:

```csharp
public static IWebHost BuildWebHost(string[] args) =>
    WebHost.CreateDefaultBuilder(args)
        .UseStartup<Startup>()
        .ConfigureLogging(logging => logging.SetMinimumLevel(LogLevel.Warning))
        .Build();
```

### Filter functions

You can apply a filter function to a specific provider or category or globally for all providers and categories. A global filter function has access to the provider type (or alias), category, and log level to decide whether or not a message should be logged. For example:

```
ConfigureLogging(logBuilder =>
{
    logBuilder.AddFilter((provider, category, logLevel) =>
    {
        if(provider == "Microsoft.Extensions.Logging.EventSource" && category == "TodoApi.Controllers.TodoController")
        {
            return false;
        }
        return true;
    });
})
```

A filter function is only invoked when the message level is at least the rule minimum level.

### Replacing the LoggerFactory

The default `LoggerFactory` provided by .NET Core gets providers from DI and uses `LoggerFilterOptions` to filter. If you want to replace the factory, you can do so by replacing the `ILoggerFactory` service in DI:

```csharp
ConfigureServices(collection => collection.AddSingleton<ILoggerFactory>(myFactory))
```

### Provider Authoring

If you are writing a custom `ILoggerProvider`, you can take advantage of the fact that they are now in DI. In your constructor, accept any registered services that you want to use. Decorate the class with the `ProviderAlias` attribute to specify an alias.

### More information about logging documentation

For information about the status of planned documentation about logging, see the [GitHub issue](https://github.com/aspnet/Docs/issues/3388).

## Authentication update

A new authentication model makes it easier to configure authentication for an application using DI.

New templates are available for configuring authentication for web apps and web APIs using [Azure AD B2C]
(https://azure.microsoft.com/services/active-directory-b2c/).

For information about the status of planned documentation, see the [GitHub issue](https://github.com/aspnet/Docs/issues/3054).

## Identity update

We've made it easier to build secure web APIs using Identity in ASP.NET Core 2.0. You can acquire access tokens for accessing your web APIs using the [Microsoft Authentication Library (MSAL)](https://www.nuget.org/packages/Microsoft.Identity.Client).

For information about the status of planned documentation, see the [GitHub issue](https://github.com/aspnet/Docs/issues/3668).

## SPA templates

Single Page Application (SPA) project templates for Angular, Aurelia, Knockout.js, React.js, and React.js with Redux are available. The Angular template has been updated to Angular 4. The Angular and React templates are available by default; for information about how to get the other templates, see [Creating a new SPA project](xref:client-side/spa-services#creating-a-new-project). For information about how to build a SPA in ASP.NET Core, see [Using JavaScriptServices for Creating Single Page Applications](xref:client-side/spa-services).

## Kestrel improvements

The Kestrel web server has new features that make it more suitable as an Internet-facing server. We’ve added a number of server constraint configuration options in the `KestrelServerOptions` class’s new `Limits` property.  You can now add limits for the following:

- Maximum client connections
- Maximum request body size
- Minimum request body data rate

### Maximum client connections

The maximum number of concurrent open HTTP/S connections can be set for the entire application with the following code:

```csharp
.UseKestrel(options =>
{
    options.Limits.MaxConcurrentConnections = 100;
    options.Limits.MaxConcurrentUpgradedConnections = 100;
```

Note how there are two limits. Once a connection is upgraded from HTTP to another protocol (e.g. on a WebSockets request), it’s not counted against the limit anymore since upgraded connections have their own limit.

### Maximum request body size

To configure the default constraint for the entire application:

```csharp
.UseKestrel(options =>
{
    options.Limits.MaxRequestBodySize = 10 * 1024;
```

This will affect every request, unless it’s overridden on a specific request:

```csharp
app.Run(async context =>
{
    context.Features.Get<IHttpMaxRequestBodySizeFeature>().MaxRequestBodySize = 10 * 1024;
```
 
You can only configure the limit on a request if the application hasn’t started reading yet; otherwise an exception is thrown. There’s an `IsReadOnly` property that tells you if the request body is in read-only state, meaning it’s too late to configure the limit.

### Minimum request body data rate

To configure a default minimum request rate:

```csharp
.UseKestrel(options =>
{
    options.Limits.RequestBodyMinimumDataRate = 
        new MinimumDataRate(rate: 100, gracePeriod: TimeSpan.FromSeconds(10));
```

To configure per-request:

```csharp
app.Run(async context =>
{
    context.Features.Get<IHttpRequestBodyMinimumDataRateFeature>().MinimumDataRate = 
        new MinimumDataRate(rate: 100, gracePeriod: TimeSpan.FromSeconds(10));
```

The way the rate works is as follows: Kestrel checks every second if data is coming in at the specified rate in bytes/second. If the rate drops below the minimum, the connection is timed out. The grace period is the amount of time that Kestrel will give the client to get its send rate up to the minimum; the rate is not checked during that time. The grace period is to avoid dropping connections that are initially sending data at a slow rate due to TCP slow start.

For information about the status of planned documentation, see the [GitHub issue](https://github.com/aspnet/Docs/issues/3385).

## WebListener renamed to HttpSys

The packages `Microsoft.AspNetCore.Server.WebListener` and `Microsoft.Net.Http.Server` have been merged into a new package `Microsoft.AspNetCore.Server.HttpSys`. The namespaces have been updated to match.

For information about the status of planned documentation, see the [GitHub issue](https://github.com/aspnet/Docs/issues/2648).

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

ASP.NET Core has always helped HTMLEncode your content by default, but with the new version we’re taking an extra step to help prevent cross-site request forgery (XSRF) attacks: ASP.NET Core will now emit anti-forgery tokens by default and validate them on form POST actions and pages without extra configuration.

For information about the status of planned documentation, see the [GitHub issue](https://github.com/aspnet/Docs/issues/3688).

## Automatic precompilation

Razor view pre-compilation is enabled during publish by default, reducing the publish output size and application startup time.

For information about the status of planned documentation, see the [GitHub issue](https://github.com/aspnet/Docs/issues/3547).

## Razor support for C# 7.1

The Razor engine has been updated to work with the new Roslyn compiler. That includes support for C# 7.1 features like Default Expressions, Inferred Tuple Names, and Pattern-Matching with Generics.  To use C #7.1 in your project, add the following property in your project file and then reload the solution:

```xml
<LangVersion>latest</LangVersion>
```

For information about the status of C# 7.1 features, see [the Roslyn GitHub repository](https://github.com/dotnet/roslyn/blob/master/docs/Language%20Feature%20Status.md).

## Additional Information

- [ASP.NET Core Release Notes](https://github.com/aspnet/Home/releases/)
- If you’d like to connect with the ASP.NET Core development team’s progress and plans, tune in to the weekly [ASP.NET Community Standup](https://live.asp.net/).
