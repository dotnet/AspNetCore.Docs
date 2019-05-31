---
title: Troubleshoot ASP.NET Core on IIS
author: guardrex
description: Learn how to diagnose problems with Internet Information Services (IIS) deployments of ASP.NET Core apps.
monikerRange: '>= aspnetcore-2.1'
ms.author: riande
ms.custom: mvc
ms.date: 05/12/2019
uid: host-and-deploy/iis/troubleshoot
---
# Troubleshoot ASP.NET Core on IIS

By [Luke Latham](https://github.com/guardrex)

This article provides instructions on how to diagnose an ASP.NET Core app startup issue when hosting with [Internet Information Services (IIS)](/iis). The information in this article applies to hosting in IIS on Windows Server and Windows Desktop.

::: moniker range=">= aspnetcore-2.2"

In Visual Studio, an ASP.NET Core project defaults to [IIS Express](/iis/extensions/introduction-to-iis-express/iis-express-overview) hosting during debugging. A *502.5 - Process Failure* or a *500.30 - Start Failure* that occurs when debugging locally can be troubleshooted using the advice in this topic.

::: moniker-end

::: moniker range="< aspnetcore-2.2"

In Visual Studio, an ASP.NET Core project defaults to [IIS Express](/iis/extensions/introduction-to-iis-express/iis-express-overview) hosting during debugging. A *502.5 Process Failure* that occurs when debugging locally can be troubleshooted using the advice in this topic.

::: moniker-end

Additional troubleshooting topics:

<xref:host-and-deploy/azure-apps/troubleshoot>
Although App Service uses the [ASP.NET Core Module](xref:host-and-deploy/aspnet-core-module) and IIS to host apps, see the dedicated topic for instructions specific to App Service.

<xref:fundamentals/error-handling>
Discover how to handle errors in ASP.NET Core apps during development on a local system.

[Learn to debug using Visual Studio](/visualstudio/debugger/getting-started-with-the-debugger)
This topic introduces the features of the Visual Studio debugger.

[Debugging with Visual Studio Code](https://code.visualstudio.com/docs/editor/debugging)
Learn about the debugging support built into Visual Studio Code.

## App startup errors

### 502.5 Process Failure

The worker process fails. The app doesn't start.

The ASP.NET Core Module attempts to start the backend dotnet process but it fails to start. The cause of a process startup failure can usually be determined from entries in the [Application Event Log](#application-event-log) and the [ASP.NET Core Module stdout log](#aspnet-core-module-stdout-log).

A common failure condition is the app is misconfigured due to targeting a version of the ASP.NET Core shared framework that isn't present. Check which versions of the ASP.NET Core shared framework are installed on the target machine. The *shared framework* is the set of assemblies (*.dll* files) that are installed on the machine and referenced by a metapackage such as `Microsoft.AspNetCore.App`. The metapackage reference can specify a minimum required version. For more information, see [The shared framework](https://natemcmaster.com/blog/2018/08/29/netcore-primitives-2/).

The *502.5 Process Failure* error page is returned when a hosting or app misconfiguration causes the worker process to fail:

![Browser window showing the 502.5 Process Failure page](troubleshoot/_static/process-failure-page.png)

::: moniker range="= aspnetcore-2.2"

### 500.30 In-Process Startup Failure

The worker process fails. The app doesn't start.

The ASP.NET Core Module attempts to start the .NET Core CLR in-process, but it fails to start. The cause of a process startup failure can usually be determined from entries in the [Application Event Log](#application-event-log) and the [ASP.NET Core Module stdout log](#aspnet-core-module-stdout-log).

A common failure condition is the app is misconfigured due to targeting a version of the ASP.NET Core shared framework that isn't present. Check which versions of the ASP.NET Core shared framework are installed on the target machine.

### 500.0 In-Process Handler Load Failure

The worker process fails. The app doesn't start.

The ASP.NET Core Module fails to find the .NET Core CLR and find the in-process request handler (*aspnetcorev2_inprocess.dll*). Check that:

* The app targets either the [Microsoft.AspNetCore.Server.IIS](https://www.nuget.org/packages/Microsoft.AspNetCore.Server.IIS) NuGet package or the [Microsoft.AspNetCore.App metapackage](xref:fundamentals/metapackage-app).
* The version of the ASP.NET Core shared framework that the app targets is installed on the target machine.

### 500.0 Out-Of-Process Handler Load Failure

The worker process fails. The app doesn't start.

The ASP.NET Core Module fails to find the out-of-process hosting request handler. Make sure the *aspnetcorev2_outofprocess.dll* is present in a subfolder next to *aspnetcorev2.dll*.

::: moniker-end

::: moniker range="= aspnetcore-3.0"

### 500.30 In-Process Startup Failure

The worker process fails. The app doesn't start.

The ASP.NET Core Module attempts to start the .NET Core CLR in-process, but it fails to start. The cause of a process startup failure can usually be determined from entries in the [Application Event Log](#application-event-log) and the [ASP.NET Core Module stdout log](#aspnet-core-module-stdout-log).

### 500.31 ANCM Failed to Find Native Dependencies

The worker process fails. The app doesn't start.

The ASP.NET Core Module attempts to start the .NET Core runtime in-process, but it fails to start. The most common cause of this startup failure is when the `Microsoft.NETCore.App` or `Microsoft.AspNetCore.App` runtime is not installed. For example, if the application is deployed to target ASP.NET Core 3.0 and that version doesn't exist on the machine, this error can occur. An example error message is shown below:

```
The specified framework 'Microsoft.NETCore.App', version '3.0.0' was not found.
  - The following frameworks were found:
      2.2.1 at [C:\Program Files\dotnet\x64\shared\Microsoft.NETCore.App]
      3.0.0-preview5-27626-15 at [C:\Program Files\dotnet\x64\shared\Microsoft.NETCore.App]
      3.0.0-preview6-27713-13 at [C:\Program Files\dotnet\x64\shared\Microsoft.NETCore.App]
      3.0.0-preview6-27714-15 at [C:\Program Files\dotnet\x64\shared\Microsoft.NETCore.App]
      3.0.0-preview6-27723-08 at [C:\Program Files\dotnet\x64\shared\Microsoft.NETCore.App]
```

The error message lists all the installed versions, as well as the version requested by the application. To fix this error, either:
* Install the appropriate version of .NET Core on the machine.
* Change the app to target a version of .NET Core that is present on the machine.
* Publish the app as a [self-contained deployment](/dotnet/core/deploying/#self-contained-deployments-scd).

When running in development (the `ASPNETCORE_ENVIRONMENT` environment variable is set to Development), the specific error that occurred will be written to the HTTP response. The cause of a process startup failure can also be found in the [Application Event Log](#application-event-log).

### 500.32 ANCM Failed to Load dll

The worker process fails. The app doesn't start.

The most common cause for this is that the app was published for an incompatible processor architecture. For example, if the worker process is running as a 32-bit application and the application was published to target 64-bit, this error will occur.

To fix this error, either:
* Re-publish the app for the same processor architecture as the worker process.
* Publish the app as a [framework-dependent deployment](/dotnet/core/deploying/#framework-dependent-executables-fde).

### 500.33 ANCM Request Handler Load Failure

The worker process fails. The app doesn't start.

The app didn't reference the `Microsoft.AspNetCore.App` framework. Only apps targeting that framework can be hosted by ANCM.

To fix this error, make sure the app is targeting the `Microsoft.AspNetCore.App` framework. Check the `.runtimeconfig.json` to verify the framework targeted by the app.

### 500.34 ANCM Mixed Hosting Models Not Supported

The worker process cannot run both an in-process and out-of-process application in the same worker process.

To fix this error, run apps in separate IIS application pools.

### 500.35 ANCM Multiple In-Process Applications in same Process

The worker process cannot run two inprocess applications in the same worker process.

To fix this error, run apps in separate IIS application pools.

### 500.36 ANCM Out-Of-Process Handler Load Failure

The out-of-process request handler, `aspnetcorev2_outofprocess.dll`, could not be found next to the `aspnetcorev2.dll`. This indicates a corrupted installation of the ASP.NET Core Module.

To fix this error, repair your installation of the Windows Hosting Bundle (for IIS) or Visual Studio (for IIS Express).

### 500.37 ANCM Failed to Start Within Startup Time Limit

ANCM failed to start within the provied startup time limit. By default, the timeout is 120 seconds.

This can occur when starting a large number of apps on the same machine. Check for CPU/Memory usage spikes on the server during startup. You may need to stagger the startup process of multiple apps.

### 500.0 In-Process Handler Load Failure

The worker process fails. The app doesn't start.

An unknown error occurred loading ANCM components. Contact [Microsoft Support](https://support.microsoft.com/oas/default.aspx?prid=15832) (select "Developer Tools" then "ASP.NET Core") for assistance, ask on Stack Overflow, or file an issue on our [GitHub repository](https://github.com/aspnet/AspNetCore).

::: moniker-end

### 500 Internal Server Error

The app starts, but an error prevents the server from fulfilling the request.

This error occurs within the app's code during startup or while creating a response. The response may contain no content, or the response may appear as a *500 Internal Server Error* in the browser. The Application Event Log usually states that the app started normally. From the server's perspective, that's correct. The app did start, but it can't generate a valid response. [Run the app at a command prompt](#run-the-app-at-a-command-prompt) on the server or [enable the ASP.NET Core Module stdout log](#aspnet-core-module-stdout-log) to troubleshoot the problem.

### Failed to start application (ErrorCode '0x800700c1')

```
EventID: 1010
Source: IIS AspNetCore Module V2
Failed to start application '/LM/W3SVC/6/ROOT/', ErrorCode '0x800700c1'.
```

The app failed to start because the app's assembly (*.dll*) couldn't be loaded.

This error occurs when there's a bitness mismatch between the published app and the w3wp/iisexpress process.

Confirm that the app pool's 32-bit setting is correct:

1. Select the app pool in IIS Manager's **Application Pools**.
1. Select **Advanced Settings** under **Edit Application Pool** in the **Actions** panel.
1. Set **Enable 32-Bit Applications**:
   * If deploying a 32-bit (x86) app, set the value to `True`.
   * If deploying a 64-bit (x64) app, set the value to `False`.

### Connection reset

If an error occurs after the headers are sent, it's too late for the server to send a **500 Internal Server Error** when an error occurs. This often happens when an error occurs during the serialization of complex objects for a response. This type of error appears as a *connection reset* error on the client. [Application logging](xref:fundamentals/logging/index) can help troubleshoot these types of errors.

## Default startup limits

The ASP.NET Core Module is configured with a default *startupTimeLimit* of 120 seconds. When left at the default value, an app may take up to two minutes to start before the module logs a process failure. For information on configuring the module, see [Attributes of the aspNetCore element](xref:host-and-deploy/aspnet-core-module#attributes-of-the-aspnetcore-element).

## Troubleshoot app startup errors

### Enable the ASP.NET Core Module debug log

Add the following handler settings to the app's *web.config* file to enable ASP.NET Core Module debug logs:

```xml
<aspNetCore ...>
  <handlerSettings>
    <handlerSetting name="debugLevel" value="file" />
    <handlerSetting name="debugFile" value="c:\temp\ancm.log" />
  </handlerSettings>
</aspNetCore>
```

Confirm that the path specified for the log exists and that the app pool's identity has write permissions to the location.

### Application Event Log

Access the Application Event Log:

1. Open the Start menu, search for **Event Viewer**, and then select the **Event Viewer** app.
1. In **Event Viewer**, open the **Windows Logs** node.
1. Select **Application** to open the Application Event Log.
1. Search for errors associated with the failing app. Errors have a value of *IIS AspNetCore Module* or *IIS Express AspNetCore Module* in the *Source* column.

### Run the app at a command prompt

Many startup errors don't produce useful information in the Application Event Log. You can find the cause of some errors by running the app at a command prompt on the hosting system.

#### Framework-dependent deployment

If the app is a [framework-dependent deployment](/dotnet/core/deploying/#framework-dependent-deployments-fdd):

1. At a command prompt, navigate to the deployment folder and run the app by executing the app's assembly with *dotnet.exe*. In the following command, substitute the name of the app's assembly for \<assembly_name>: `dotnet .\<assembly_name>.dll`.
1. The console output from the app, showing any errors, is written to the console window.
1. If the errors occur when making a request to the app, make a request to the host and port where Kestrel listens. Using the default host and post, make a request to `http://localhost:5000/`. If the app responds normally at the Kestrel endpoint address, the problem is more likely related to the hosting configuration and less likely within the app.

#### Self-contained deployment

If the app is a [self-contained deployment](/dotnet/core/deploying/#self-contained-deployments-scd):

1. At a command prompt, navigate to the deployment folder and run the app's executable. In the following command, substitute the name of the app's assembly for \<assembly_name>: `<assembly_name>.exe`.
1. The console output from the app, showing any errors, is written to the console window.
1. If the errors occur when making a request to the app, make a request to the host and port where Kestrel listens. Using the default host and post, make a request to `http://localhost:5000/`. If the app responds normally at the Kestrel endpoint address, the problem is more likely related to the hosting configuration and less likely within the app.

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

> [!IMPORTANT]
> Disable stdout logging when troubleshooting is complete.

1. Edit the *web.config* file.
1. Set **stdoutLogEnabled** to `false`.
1. Save the file.

> [!WARNING]
> Failure to disable the stdout log can lead to app or server failure. There's no limit on log file size or the number of log files created.
>
> For routine logging in an ASP.NET Core app, use a logging library that limits log file size and rotates logs. For more information, see [third-party logging providers](xref:fundamentals/logging/index#third-party-logging-providers).

## Enable the Developer Exception Page

The `ASPNETCORE_ENVIRONMENT` [environment variable can be added to web.config](xref:host-and-deploy/aspnet-core-module#setting-environment-variables) to run the app in the Development environment. As long as the environment isn't overridden in app startup by `UseEnvironment` on the host builder, setting the environment variable allows the [Developer Exception Page](xref:fundamentals/error-handling) to appear when the app is run.

::: moniker range=">= aspnetcore-2.2"

```xml
<aspNetCore processPath="dotnet"
      arguments=".\MyApp.dll"
      stdoutLogEnabled="false"
      stdoutLogFile=".\logs\stdout"
      hostingModel="InProcess">
  <environmentVariables>
    <environmentVariable name="ASPNETCORE_ENVIRONMENT" value="Development" />
  </environmentVariables>
</aspNetCore>
```

::: moniker-end

::: moniker range="< aspnetcore-2.2"

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

::: moniker-end

Setting the environment variable for `ASPNETCORE_ENVIRONMENT` is only recommended for use on staging and testing servers that aren't exposed to the Internet. Remove the environment variable from the *web.config* file after troubleshooting. For information on setting environment variables in *web.config*, see [environmentVariables child element of aspNetCore](xref:host-and-deploy/aspnet-core-module#setting-environment-variables).

## Common startup errors

See <xref:host-and-deploy/azure-iis-errors-reference>. Most of the common problems that prevent app startup are covered in the reference topic.

## Obtain data from an app

If an app is capable of responding to requests, obtain request, connection, and additional data from the app using terminal inline middleware. For more information and sample code, see <xref:test/troubleshoot#obtain-data-from-an-app>.

## Create a dump

A *dump* is a snapshot of the system's memory and can help determine the cause of an app crash, startup failure, or slow app.

### App crashes or encounters an exception

Obtain and analyze a dump from [Windows Error Reporting (WER)](/windows/desktop/wer/windows-error-reporting):

1. Create a folder to hold crash dump files at `c:\dumps`. The app pool must have write access to the folder.
1. Run the [EnableDumps PowerShell script](https://github.com/aspnet/AspNetCore.Docs/blob/master/aspnetcore/host-and-deploy/iis/troubleshoot/scripts/EnableDumps.ps1):
   * If the app uses the [in-process hosting model](xref:fundamentals/servers/index#in-process-hosting-model), run the script for *w3wp.exe*:

     ```console
     .\EnableDumps w3wp.exe c:\dumps
     ```

   * If the app uses the [out-of-process hosting model](xref:fundamentals/servers/index#out-of-process-hosting-model), run the script for *dotnet.exe*:

     ```console
     .\EnableDumps dotnet.exe c:\dumps
     ```

1. Run the app under the conditions that cause the crash to occur.
1. After the crash has occurred, run the [DisableDumps PowerShell script](https://github.com/aspnet/AspNetCore.Docs/blob/master/aspnetcore/host-and-deploy/iis/troubleshoot/scripts/DisableDumps.ps1):
   * If the app uses the [in-process hosting model](xref:fundamentals/servers/index#in-process-hosting-model), run the script for *w3wp.exe*:

     ```console
     .\DisableDumps w3wp.exe
     ```

   * If the app uses the [out-of-process hosting model](xref:fundamentals/servers/index#out-of-process-hosting-model), run the script for *dotnet.exe*:

     ```console
     .\DisableDumps dotnet.exe
     ```

After an app crashes and dump collection is complete, the app is allowed to terminate normally. The PowerShell script configures WER to collect up to five dumps per app.

> [!WARNING]
> Crash dumps might take up a large amount of disk space (up to several gigabytes each).

### App hangs, fails during startup, or runs normally

When an app *hangs* (stops responding but doesn't crash), fails during startup, or runs normally, see [User-Mode Dump Files: Choosing the Best Tool](/windows-hardware/drivers/debugger/user-mode-dump-files#choosing-the-best-tool) to select an appropriate tool to produce the dump.

### Analyze the dump

A dump can be analyzed using several approaches. For more information, see [Analyzing a User-Mode Dump File](/windows-hardware/drivers/debugger/analyzing-a-user-mode-dump-file).

## Remote debugging

See [Remote Debug ASP.NET Core on a Remote IIS Computer in Visual Studio 2017](/visualstudio/debugger/remote-debugging-aspnet-on-a-remote-iis-computer) in the Visual Studio documentation.

## Application Insights

[Application Insights](/azure/application-insights/) provides telemetry from apps hosted by IIS, including error logging and reporting features. Application Insights can only report on errors that occur after the app starts when the app's logging features become available. For more information, see [Application Insights for ASP.NET Core](/azure/application-insights/app-insights-asp-net-core).

## Additional advice

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

* <xref:test/troubleshoot>
* <xref:fundamentals/error-handling>
* <xref:host-and-deploy/azure-iis-errors-reference>
* <xref:host-and-deploy/aspnet-core-module>
* <xref:host-and-deploy/azure-apps/troubleshoot>
