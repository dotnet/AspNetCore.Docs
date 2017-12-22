---
title: Working with multiple environments in ASP.NET Core
author: rick-anderson
description: Learn how ASP.NET Core provides support for controlling app behavior across multiple environments.
keywords: ASP.NET Core,Environment settings,ASPNETCORE_ENVIRONMENT
ms.author: riande
manager: wpickett
ms.date: 12/25/2017
ms.topic: article
ms.technology: aspnet
ms.prod: asp.net-core
uid: fundamentals/environments
---
# Working with multiple environments

By [Rick Anderson](https://twitter.com/RickAndMSFT)

ASP.NET Core provides support for setting application behavior at runtime with environment variables.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/environments/sample) ([how to download](xref:tutorials/index#how-to-download-a-sample))

## Environments

ASP.NET Core reads the environment variable `ASPNETCORE_ENVIRONMENT` at application startup and stores that value in [IHostingEnvironment.EnvironmentName](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.hosting.ihostingenvironment.environmentname?view=aspnetcore-2.0#Microsoft_AspNetCore_Hosting_IHostingEnvironment_EnvironmentName). `ASPNETCORE_ENVIRONMENT` can be set to any value, but [three values are supported by the framework](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.hosting.environmentname?view=aspnetcore-2.0): [Development](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.hosting.environmentname.development?view=aspnetcore-2.0), [Staging](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.hosting.environmentname.staging?view=aspnetcore-2.0), and [Production](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.hosting.environmentname.production?view=aspnetcore-2.0).

[!code-csharp[Main](environments/sample/WebApp1/Startup.cs?name=snippet)]

The preceding code:

* Calls [UseDeveloperExceptionPage](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.builder.developerexceptionpageextensions.usedeveloperexceptionpage?view=aspnetcore-2.0#Microsoft_AspNetCore_Builder_DeveloperExceptionPageExtensions_UseDeveloperExceptionPage_Microsoft_AspNetCore_Builder_IApplicationBuilder_) and [UseBrowserLink](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.builder.browserlinkextensions.usebrowserlink?view=aspnetcore-2.0#Microsoft_AspNetCore_Builder_BrowserLinkExtensions_UseBrowserLink_Microsoft_AspNetCore_Builder_IApplicationBuilder_) when `ASPNETCORE_ENVIRONMENT` is set to `Development`.
* Calls [UseExceptionHandler](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.builder.exceptionhandlerextensions.useexceptionhandler?view=aspnetcore-2.0#Microsoft_AspNetCore_Builder_ExceptionHandlerExtensions_UseExceptionHandler_Microsoft_AspNetCore_Builder_IApplicationBuilder_) when the value of `ASPNETCORE_ENVIRONMENT` is set one of the following:

    * `Staging`
    * `Production`
    * `Staging_2`

The [Environment Tag Helper ](xref:mvc/views/tag-helpers/builtin-th/environment-tag-helper) uses the value of `IHostingEnvironment.EnvironmentName` to include or exclude markup in the element:

[!code-html[Main](environments/sample/WebApp1/Pages/About.cshtml)]

Note: On Windows and macOS, environment variables and values are insensitive. Linux environment variables and values are **case sensitive** by default.

### Development

The development environment can enable features that should not be exposed in production. For example, the ASP.NET Core templates enable the [developer exception page](xref:fundamentals/error-handling#the-developer-exception-page) in the development environment.

The environment for local machine development can be set in the *Properties\launchSettings.json* file of the project. Environment values set in *launchSettings.json* override values set in the system environment.

The following XML shows three profiles from a *launchSettings.json* file:

[!code-xml[Main](environments/sample/WebApp1/Properties/launchSettings.json)]

When the application is launched with `dotnet run`, the first profile with `"commandName": "Project"` will be used. The value of `commandName` specifies the web server to launch. `commandName` can be one of :

* IIS Express
* IIS
* Project (which launches  Kestrel)

The Visual Studio **Debug** tab provides a GUI to edit the *launchSettings.json* file:

![Project Properties Setting Environment variables](environments/_static/project-properties-debug.png)

Changes made to project profiles may not take effect until the web server used is restarted. Kestrel must be restarted before it will detect changes made to its environment.

>[!WARNING]
> *launchSettings.json* should not store secrets. The [Secret Manager tool](xref:security/app-secrets) can be used to store secrets for local development.

### Production

The production environment should be configured to maximize security, performance, and application robustness. Some common settings that a production environment might have that would differ from development include:

* Caching.
* Client-side resources are bundled, minified, and potentially served from a CDN.
* Diagnostic error pages disabled.
* Friendly error pages enabled.
* Production logging and monitoring enabled. For example, [Application Insights](https://azure.microsoft.com/documentation/articles/app-insights-asp-net-five/).

<!-- FALSE - what about the
It's best to avoid scattering environment checks in many parts of your application. Instead, the recommended approach is to perform such checks within the application's `Startup` class(es) wherever possible
-->

## Setting the environment

The method for setting the environment depends on the operating system.

### Azure

For Azure app service:

* Select the **Application settings** blade.
* Add the key and value in **App settings**.

<!--
Why would you ever do this?  Testing maybe? Anyone who needed to do this knows how to set the env variable so I'm removing it.

### Windows
To set the `ASPNETCORE_ENVIRONMENT` for the current session, if the app is started using `dotnet run`, the following commands are used

**Command line**
```
set ASPNETCORE_ENVIRONMENT=Development
```
**PowerShell**
```
$Env:ASPNETCORE_ENVIRONMENT = "Development"
```

These commands take effect only for the current window. When the window is closed, the ASPNETCORE_ENVIRONMENT setting reverts to the default setting or machine value. In order to set the value globally on Windows open the **Control Panel** > **System** > **Advanced system settings** and add or edit the `ASPNETCORE_ENVIRONMENT` value.

![System Advanced Properties](environments/_static/systemsetting_environment.png)

Ha, Steve is setting a user env variable, not a system one. That won't do much good on a server.

![ASPNET Core Environment Variable](environments/_static/windows_aspnetcore_environment.png)

-->

**web.config**

See the *Setting environment variables* section of the [ASP.NET Core Module configuration reference](xref:hosting/aspnet-core-module#setting-environment-variables) topic.

**Per IIS Application Pool**

To set environment variables for individual apps running in isolated Application Pools (supported on IIS 10.0+), see the *AppCmd.exe command* section of the [Environment Variables \<environmentVariables>](/iis/configuration/system.applicationHost/applicationPools/add/environmentVariables/#appcmdexe) topic.

<!--
### macOS
Setting the current environment for macOS can be done in-line when running the application;

```bash
ASPNETCORE_ENVIRONMENT=Development dotnet run
```
or using `export` to set it prior to running the app.

```bash
export ASPNETCORE_ENVIRONMENT=Development
```
Machine level environment variables are set in the *.bashrc*  or *.bash_profile* file. Edit the file using any text editor and add the following statment.

```
export ASPNETCORE_ENVIRONMENT=Development
```

### Linux
For Linux distros, use the `export` command at the command line for session based variable settings and *bash_profile* file for machine level environment settings.

-->

<!--
This is all covered at the beginning of the article

## Determining the environment at runtime

The `IHostingEnvironment` service provides the core abstraction for working with environments. This service is provided by the ASP.NET hosting layer, and can be injected into your startup logic via [Dependency Injection](dependency-injection.md). The ASP.NET Core web site template in Visual Studio uses this approach to load environment-specific configuration files (if present) and to customize the app's error handling settings. In both cases, this behavior is achieved by referring to the currently specified environment by calling `EnvironmentName` or
`IsEnvironment` on the instance of `IHostingEnvironment` passed into the appropriate method.

> [!NOTE]
> If you need to check whether the application is running in a particular environment, use `env.IsEnvironment("environmentname")` since it will correctly ignore case (instead of checking if `env.EnvironmentName == "Development"` for example).

For example, you can use the following code in your Configure method to setup environment specific error handling:


If the app is running in a `Development` environment, then it enables the runtime support necessary to use the "BrowserLink" feature in Visual Studio, development-specific error pages (which typically should not be run in production) and special database error pages (which provide a way to apply migrations and should therefore only be used in development). Otherwise, if the app is not running in a development environment, a standard error handling page is configured to be displayed in response to any unhandled exceptions.

You may need to determine which content to send to the client at runtime, depending on the current environment. For example, in a development environment you generally serve non-minimized scripts and style sheets, which makes debugging easier. Production and test environments should serve the minified versions and generally from a CDN. You can do this using the Environment [tag helper](../mvc/views/tag-helpers/intro.md). The Environment tag helper will only render its contents if the current environment matches one of the environments specified using the `names` attribute.


To get started with using tag helpers in your application see [Introduction to Tag Helpers](../mvc/views/tag-helpers/intro.md).

-->
<a name="startup-conventions"></a>
## Environment based Startup class and methods

When an ASP.NET Core app starts, the [Startup class](xref:fundamentals/startup) bootstraps the app. If a class `Startup{EnvironmentName}` exists, that class will be called for that `EnvironmentName`:

[!code-csharp[Main](environments/sample/WebApp1/StartupDev.cs?name=snippet&highlight=1)]

Note: Calling `WebHostBuilder.UseStartup<TStartup>()` overrides configuration sections.

`Configure` and `ConfigureServices` support environment specific versions  of the form `Configure{EnvironmentName}` and `Configure{EnvironmentName}Services`:

[!code-csharp[Main](environments/sample/WebApp1/Startup.cs?name=snippet_all&highlight=15,38)]

## Additional Resources

* [Application startup](xref:fundamentals/startup)
* [Configuration](xref:fundamentals/configuration/index)
* [IHostingEnvironment.EnvironmentName](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.hosting.ihostingenvironment.environmentname?view=aspnetcore-2.0#Microsoft_AspNetCore_Hosting_IHostingEnvironment_EnvironmentName)
*
