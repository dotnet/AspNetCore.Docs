---
title: Troubleshoot ASP.NET Core on IIS
author: guardrex
description: Learn how to diagnose problems with Internet Information Services (IIS) deployments of ASP.NET Core apps.
ms.author: riande
ms.custom: mvc
ms.date: 02/07/2018
uid: host-and-deploy/iis/troubleshoot
---
# Troubleshoot ASP.NET Core on IIS

By [Luke Latham](https://github.com/guardrex)

This article provides instructions on how to diagnose an ASP.NET Core app startup issue when hosting with [Internet Information Services (IIS)](/iis). The information in this article applies to hosting in IIS on Windows Server and Windows Desktop.

In Visual Studio, an ASP.NET Core project defaults to [IIS Express](/iis/extensions/introduction-to-iis-express/iis-express-overview) hosting during debugging. A *502.5 Process Failure* that occurs when debugging locally can be troubleshooted using the advice in this topic.

Additional troubleshooting topics:

[Troubleshoot ASP.NET Core on Azure App Service](xref:host-and-deploy/azure-apps/troubleshoot)  
Although App Service uses the [ASP.NET Core Module](xref:fundamentals/servers/aspnet-core-module) and IIS to host apps, see the dedicated topic for instructions specific to App Service.

[Handle errors](xref:fundamentals/error-handling)  
Discover how to handle errors in ASP.NET Core apps during development on a local system.

[Learn to debug using Visual Studio](/visualstudio/debugger/getting-started-with-the-debugger)  
This topic introduces the features of the Visual Studio debugger.

[Debugging with Visual Studio Code](https://code.visualstudio.com/docs/editor/debugging)  
Learn about the debugging support built into Visual Studio Code.

## App startup errors

**502.5 Process Failure**  
The worker process fails. The app doesn't start.

The ASP.NET Core Module attempts to start the worker process but it fails to start. The cause of a process startup failure can usually be determined from entries in the [Application Event Log](#application-event-log) and the [ASP.NET Core Module stdout log](#aspnet-core-module-stdout-log).

The *502.5 Process Failure* error page is returned when a hosting or app misconfiguration causes the worker process to fail:

![Browser window showing the 502.5 Process Failure page](troubleshoot/_static/process-failure-page.png)

**500 Internal Server Error**  
The app starts, but an error prevents the server from fulfilling the request.

This error occurs within the app's code during startup or while creating a response. The response may contain no content, or the response may appear as a *500 Internal Server Error* in the browser. The Application Event Log usually states that the app started normally. From the server's perspective, that's correct. The app did start, but it can't generate a valid response. [Run the app at a command prompt](#run-the-app-at-a-command-prompt) on the server or [enable the ASP.NET Core Module stdout log](#aspnet-core-module-stdout-log) to troubleshoot the problem.

**Connection reset**

If an error occurs after the headers are sent, it's too late for the server to send a **500 Internal Server Error** when an error occurs. This often happens when an error occurs during the serialization of complex objects for a response. This type of error appears as a *connection reset* error on the client. [Application logging](xref:fundamentals/logging/index) can help troubleshoot these types of errors.

## Default startup limits

The ASP.NET Core Module is configured with a default *startupTimeLimit* of 120 seconds. When left at the default value, an app may take up to two minutes to start before the module logs a process failure. For information on configuring the module, see [Attributes of the aspNetCore element](xref:host-and-deploy/aspnet-core-module#attributes-of-the-aspnetcore-element).

## Troubleshoot app startup errors

### Application Event Log

Access the Application Event Log:

1. Open the Start menu, search for **Event Viewer**, and then select the **Event Viewer** app.
1. In **Event Viewer**, open the **Windows Logs** node.
1. Select **Application** to open the Application Event Log.
1. Search for errors associated with the failing app. Errors have a value of *IIS AspNetCore Module* or *IIS Express AspNetCore Module* in the *Source* column.

### Run the app at a command prompt

Many startup errors don't produce useful information in the Application Event Log. You can find the cause of some errors by running the app at a command prompt on the hosting system.

**Framework-dependent deployment**

If the app is a [framework-dependent deployment](/dotnet/core/deploying/#framework-dependent-deployments-fdd):

1. At a command prompt, navigate to the deployment folder and run the app by executing the app's assembly with *dotnet.exe*. In the following command, substitute the name of the app's assembly for \<assembly_name>: `dotnet .\<assembly_name>.dll`.
1. The console output from the app, showing any errors, is written to the console window.
1. If the errors occur when making a request to the app, make a request to the host and port where Kestrel listens. Using the default host and post, make a request to `http://localhost:5000/`. If the app responds normally at the Kestrel endpoint address, the problem is more likely related to the reverse proxy configuration and less likely within the app.

**Self-contained deployment**

If the app is a [self-contained deployment](/dotnet/core/deploying/#self-contained-deployments-scd):

1. At a command prompt, navigate to the deployment folder and run the app's executable. In the following command, substitute the name of the app's assembly for \<assembly_name>: `<assembly_name>.exe`.
1. The console output from the app, showing any errors, is written to the console window.
1. If the errors occur when making a request to the app, make a request to the host and port where Kestrel listens. Using the default host and post, make a request to `http://localhost:5000/`. If the app responds normally at the Kestrel endpoint address, the problem is more likely related to the reverse proxy configuration and less likely within the app.

### ASP.NET Core Module stdout log

To enable and view stdout logs:

1. Navigate to the site's deployment folder on the hosting system.
1. If the *logs* folder isn't present, create the folder. For instructions on how to enable MSBuild to create the *logs* folder in the deployment automatically, see the [Directory structure](xref:host-and-deploy/directory-structure) topic.
1. Edit the *web.config* file. Set **stdoutLogEnabled** to `true` and change the **stdoutLogFile** path to point to the *logs* folder (for example, `.\logs\stdout`). `stdout` in the path is the log file name prefix. A timestamp, process id, and file extension are added automatically when the log is created. Using `stdout` as the file name prefix, a typical log file is named *stdout_20180205184032_5412.log*. 
1. Ensure your application pool's identity has write permissions to the *logs* folder.
1. Save the updated *web.config* file.
1. Make a request to the app.
1. Navigate to the *logs* folder. Find and open the most recent stdout log.
1. Study the log for errors.

**Important!** Disable stdout logging when troubleshooting is complete.

1. Edit the *web.config* file.
1. Set **stdoutLogEnabled** to `false`.
1. Save the file.

> [!WARNING]
> Failure to disable the stdout log can lead to app or server failure. There's no limit on log file size or the number of log files created.
>
> For routine logging in an ASP.NET Core app, use a logging library that limits log file size and rotates logs. For more information, see [third-party logging providers](xref:fundamentals/logging/index#third-party-logging-providers).

## Enabling the Developer Exception Page

The `ASPNETCORE_ENVIRONMENT` [environment variable can be added to web.config](xref:host-and-deploy/aspnet-core-module#setting-environment-variables) to run the app in the Development environment. As long as the environment isn't overridden in app startup by `UseEnvironment` on the host builder, setting the environment variable allows the [Developer Exception Page](xref:fundamentals/error-handling) to appear when the app is run.

```xml
<aspNetCore processPath="dotnet"
      arguments=".\MyApp.dll"
      stdoutLogEnabled="false"
      stdoutLogFile=".\logs\stdout">
  <environmentVariables>
    <environmentVariable name="ASPNETCORE_ENVIRONMENT" value="Development" />
  </environmentVariables>
</aspNetCore>
```

Setting the environment variable for `ASPNETCORE_ENVIRONMENT` is only recommended for use on staging and testing servers that aren't exposed to the Internet. Remove the environment variable from the *web.config* file after troubleshooting. For information on setting environment variables in *web.config*, see [environmentVariables child element of aspNetCore](xref:host-and-deploy/aspnet-core-module#setting-environment-variables).

## Common startup errors 

See the [ASP.NET Core common errors reference](xref:host-and-deploy/azure-iis-errors-reference). Most of the common problems that prevent app startup are covered in the reference topic.

## Slow or hanging app

When an app responds slowly or hangs on a request, obtain and analyze a [dump file](/visualstudio/debugger/using-dump-files). Dump files can be obtained using any of the following tools:

* [ProcDump](/sysinternals/downloads/procdump)
* [DebugDiag](https://www.microsoft.com/download/details.aspx?id=49924)
* WinDbg: [Download Debugging tools for Windows](https://developer.microsoft.com/windows/hardware/download-windbg), [Debugging Using WinDbg](/windows-hardware/drivers/debugger/debugging-using-windbg)

## Remote debugging

See [Remote Debug ASP.NET Core on a Remote IIS Computer in Visual Studio 2017](/visualstudio/debugger/remote-debugging-aspnet-on-a-remote-iis-computer) in the Visual Studio documentation.

## Application Insights

[Application Insights](/azure/application-insights/) provides telemetry from apps hosted by IIS, including error logging and reporting features. Application Insights can only report on errors that occur after the app starts when the app's logging features become available. For more information, see [Application Insights for ASP.NET Core](/azure/application-insights/app-insights-asp-net-core).

## Additional troubleshooting advice

Sometimes a functioning app fails immediately after upgrading either the .NET Core SDK on the development machine or package versions within the app. In some cases, incoherent packages may break an app when performing major upgrades. Most of these issues can be fixed by following these instructions:

1. Delete the *bin* and *obj* folders.
1. Clear the package caches at *%UserProfile%\\.nuget\\packages* and *%LocalAppData%\\Nuget\\v3-cache*.
1. Restore and rebuild the project.
1. Confirm that the prior deployment on the server has been completely deleted prior to redeploying the app.

> [!TIP]
> A convenient way to clear package caches is to execute `dotnet nuget locals all --clear` from a command prompt.
> 
> Clearing package caches can also be accomplished by using the [nuget.exe](https://www.nuget.org/downloads) tool and executing the command `nuget locals all -clear`. *nuget.exe* isn't a bundled install with the Windows desktop operating system and must be obtained separately from the [NuGet website](https://www.nuget.org/downloads).

## Additional resources

* [Introduction to Error Handling in ASP.NET Core](xref:fundamentals/error-handling)
* [Common errors reference for Azure App Service and IIS with ASP.NET Core](xref:host-and-deploy/azure-iis-errors-reference)
* [ASP.NET Core Module configuration reference](xref:host-and-deploy/aspnet-core-module)
* [Troubleshoot ASP.NET Core on Azure App Service](xref:host-and-deploy/azure-apps/troubleshoot)
