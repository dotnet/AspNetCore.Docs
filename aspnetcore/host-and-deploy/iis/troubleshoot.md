---
title: Troubleshoot ASP.NET Core on IIS
author: guardrex
description: Learn how to diagnose problems with IIS deployments of ASP.NET Core apps.
ms.author: riande
manager: wpickett
ms.custom: mvc
ms.date: 03/13/2017
ms.topic: article
ms.technology: aspnet
ms.prod: asp.net-core
uid: host-and-deploy/iis/troubleshoot
---
# Troubleshoot ASP.NET Core on IIS

By [Luke Latham](https://github.com/guardrex)

To diagnose issues with IIS deployments:

* Study browser output.
* Examine the system's **Application** log through **Event Viewer**.
* Enable `stdout` logging. The **ASP.NET Core Module** log is found on the path provided in the *stdoutLogFile* attribute of the `<aspNetCore>` element in *web.config*. Any folders on the path provided in the attribute value must exist in the deployment. Set *stdoutLogEnabled* to `true`. Apps that use the the `Microsoft.NET.Sdk.Web` SDK to create the *web.config* file default the *stdoutLogEnabled* setting to `false`, so manually provide the *web.config* file or modify the file in order to enable `stdout` logging.

Use information from those three sources with the [common errors reference topic](xref:host-and-deploy/azure-iis-errors-reference) to determine the problem. Follow the troubleshooting advice provided to resolve the issue.

Several of the common errors don't appear in the browser, Application Log, and ASP.NET Core Module Log until the module *startupTimeLimit* (default: 120 seconds) and *startupRetryCount* (default: 2) have passed. Therefore, wait a full six minutes before deducing that the module has failed to start a process for the app.

One quick way to determine if the app is working properly is to run the app directly on Kestrel. If the app was published as a [framework-dependent deployment](/dotnet/core/deploying/#framework-dependent-deployments-fdd), execute `dotnet <assembly_name>.dll` in the deployment folder, which is the IIS physical path to the app. If the app was published as a [self-contained deployment](/dotnet/core/deploying/#self-contained-deployments-scd), run the app's executable directly from a command prompt, `<assembly_name>.exe`, in the deployment folder. If Kestrel is listening on default port 5000, the app should be available at `http://localhost:5000/`. If the app responds normally at the Kestrel endpoint address, the problem is more likely related to the reverse proxy configuration and less likely within the app.

One way to determine if the reverse proxy is working properly is to perform a simple static file request for a stylesheet, script, or image from the app's static files in *wwwroot* using [Static File Middleware](xref:fundamentals/static-files). If the app can serve static files but MVC Views and other endpoints are failing, the problem is less likely related to the reverse proxy configuration and more likely within the app (for example, MVC routing or 500 Internal Server Error).

When Kestrel starts normally behind IIS but the app won't run on the system after successfully running locally, an environment variable can be temporarily added to *web.config* to set the `ASPNETCORE_ENVIRONMENT` to `Development`. As long as the environment isn't overridden in app startup, setting the environment variable allows the [developer exception page](xref:fundamentals/error-handling) to appear when the app is run. Setting the environment variable for `ASPNETCORE_ENVIRONMENT` in this way is only recommended for staging/testing servers that aren't exposed to the Internet. Be sure to remove the environment variable from the *web.config* file when finished. For information on setting environment variables via *web.config*, see [environmentVariables child element of aspNetCore](xref:host-and-deploy/aspnet-core-module#setting-environment-variables).

In most cases, enabling application logging assists in troubleshooting problems with the app or the reverse proxy. See [Logging](xref:fundamentals/logging/index) for more information.

The last troubleshooting tip pertains to apps that fail to run after upgrading either the .NET Core SDK on the development machine or package versions within the app. In some cases, incoherent packages may break an app when performing major upgrades. Most of these issues can be fixed by:

* Deleting the `bin` and `obj` folders in the project.
* Clearing package caches at `%UserProfile%\.nuget\packages\` and `%LocalAppData%\Nuget\v3-cache`.
* Restoring and rebuilding the project.
* Confirming that the prior deployment on the server has been completely deleted prior to re-deploying the app.

> [!TIP]
> A convenient way to clear package caches is to execute `dotnet nuget locals all --clear` from a command prompt.
> 
> Clearing package caches can also be accomplished by using the [nuget.exe](https://www.nuget.org/downloads) tool and executing the command `nuget locals all -clear`. *nuget.exe* isn't a bundled install with Windows 10 and must be obtained separately from the NuGet website.
<!--
> [!TIP]
> A convenient way to clear package caches is to:
>
> * Obtain the *NuGet.exe* tool from [NuGet.org](https://www.nuget.org/).
> * Add the path to *NuGet.exe* to the system PATH.
> * Execute `nuget locals all -clear` from a command prompt.
>
> Alternatively, execute `dotnet nuget locals all --clear` from a command prompt without obtaining *NuGet.exe*. -->

## Additional resources

* [Common errors reference for Azure App Service and IIS with ASP.NET Core](xref:host-and-deploy/azure-iis-errors-reference)
* [ASP.NET Core Module configuration reference](xref:host-and-deploy/aspnet-core-module)
