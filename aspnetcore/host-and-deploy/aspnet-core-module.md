---
title: ASP.NET Core Module configuration reference
author: guardrex
description: Learn how to configure the ASP.NET Core Module for hosting ASP.NET Core apps.
ms.author: riande
ms.custom: mvc
ms.date: 02/15/2018
uid: host-and-deploy/aspnet-core-module
---
# ASP.NET Core Module configuration reference

By [Luke Latham](https://github.com/guardrex), [Rick Anderson](https://twitter.com/RickAndMSFT), and [Sourabh Shirhatti](https://twitter.com/sshirhatti)

This document provides instructions on how to configure the ASP.NET Core Module for hosting ASP.NET Core apps. For an introduction to the ASP.NET Core Module and installation instructions, see the [ASP.NET Core Module overview](xref:fundamentals/servers/aspnet-core-module).

## Configuration with web.config

The ASP.NET Core Module is configured with the `aspNetCore` section of the `system.webServer` node in the site's *web.config* file.

The following *web.config* file is published for a [framework-dependent deployment](/dotnet/articles/core/deploying/#framework-dependent-deployments-fdd) and configures the ASP.NET Core Module to handle site requests:

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <system.webServer>
    <handlers>
      <add name="aspNetCore" path="*" verb="*" modules="AspNetCoreModule" resourceType="Unspecified" />
    </handlers>
    <aspNetCore processPath="dotnet" 
                arguments=".\MyApp.dll" 
                stdoutLogEnabled="false" 
                stdoutLogFile=".\logs\stdout" />
  </system.webServer>
</configuration>
```

The following *web.config* is published for a [self-contained deployment](/dotnet/articles/core/deploying/#self-contained-deployments-scd):

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <system.webServer>
    <handlers>
      <add name="aspNetCore" path="*" verb="*" modules="AspNetCoreModule" resourceType="Unspecified" />
    </handlers>
    <aspNetCore processPath=".\MyApp.exe" 
                stdoutLogEnabled="false" 
                stdoutLogFile=".\logs\stdout" />
  </system.webServer>
</configuration>
```

When an app is deployed to [Azure App Service](https://azure.microsoft.com/services/app-service/), the `stdoutLogFile` path is set to `\\?\%home%\LogFiles\stdout`. The path saves stdout logs to the *LogFiles* folder, which is a location automatically created by the service.

See [Sub-application configuration](xref:host-and-deploy/iis/index#sub-application-configuration) for an important note pertaining to the configuration of *web.config* files in sub-apps.

### Attributes of the aspNetCore element

::: moniker range="<= aspnetcore-2.0"
| Attribute | Description | Default |
| --------- | ----------- | :-----: |
| `arguments` | <p>Optional string attribute.</p><p>Arguments to the executable specified in **processPath**.</p>| |
| `disableStartUpErrorPage` | true or false.</p><p>If true, the **502.5 - Process Failure** page is suppressed, and the 502 status code page configured in the *web.config* takes precedence.</p> | `false` |
| `forwardWindowsAuthToken` | true or false.</p><p>If true, the token is forwarded to the child process listening on %ASPNETCORE_PORT% as a header 'MS-ASPNETCORE-WINAUTHTOKEN' per request. It's the responsibility of that process to call CloseHandle on this token per request.</p> | `true` |
| `processPath` | <p>Required string attribute.</p><p>Path to the executable that launches a process listening for HTTP requests. Relative paths are supported. If the path begins with `.`, the path is considered to be relative to the site root.</p> | |
| `rapidFailsPerMinute` | <p>Optional integer attribute.</p><p>Specifies the number of times the process specified in **processPath** is allowed to crash per minute. If this limit is exceeded, the module stops launching the process for the remainder of the minute.</p> | `10` |
| `requestTimeout` | <p>Optional timespan attribute.</p><p>Specifies the duration for which the ASP.NET Core Module waits for a response from the process listening on %ASPNETCORE_PORT%.</p><p>In versions of the ASP.NET Core Module that shipped with the release of ASP.NET Core 2.0 or earlier, the `requestTimeout` must be specified in whole minutes only, otherwise it defaults to 2 minutes.</p> | `00:02:00` |
| `shutdownTimeLimit` | <p>Optional integer attribute.</p><p>Duration in seconds that the module waits for the executable to gracefully shutdown when the *app_offline.htm* file is detected.</p> | `10` |
| `startupTimeLimit` | <p>Optional integer attribute.</p><p>Duration in seconds that the module waits for the executable to start a process listening on the port. If this time limit is exceeded, the module kills the process. The module attempts to relaunch the process when it receives a new request and continues to attempt to restart the process on subsequent incoming requests unless the app fails to start **rapidFailsPerMinute** number of times in the last rolling minute.</p> | `120` |
| `stdoutLogEnabled` | <p>Optional Boolean attribute.</p><p>If true, **stdout** and **stderr** for the process specified in **processPath** are redirected to the file specified in **stdoutLogFile**.</p> | `false` |
| `stdoutLogFile` | <p>Optional string attribute.</p><p>Specifies the relative or absolute file path for which **stdout** and **stderr** from the process specified in **processPath** are logged. Relative paths are relative to the root of the site. Any path starting with `.` are relative to the site root and all other paths are treated as absolute paths. Any folders provided in the path must exist in order for the module to create the log file. Using underscore delimiters, a timestamp, process ID, and file extension (*.log*) are added to the last segment of the **stdoutLogFile** path. If `.\logs\stdout` is supplied as a value, an example stdout log is saved as *stdout_20180205194132_1934.log* in the *logs* folder when saved on 2/5/2018 at 19:41:32 with a process ID of 1934.</p> | `aspnetcore-stdout` |
::: moniker-end
::: moniker range=">= aspnetcore-2.1"
| Attribute | Description | Default |
| --------- | ----------- | :-----: |
| `arguments` | <p>Optional string attribute.</p><p>Arguments to the executable specified in **processPath**.</p>| |
| `disableStartUpErrorPage` | true or false.</p><p>If true, the **502.5 - Process Failure** page is suppressed, and the 502 status code page configured in the *web.config* takes precedence.</p> | `false` |
| `forwardWindowsAuthToken` | true or false.</p><p>If true, the token is forwarded to the child process listening on %ASPNETCORE_PORT% as a header 'MS-ASPNETCORE-WINAUTHTOKEN' per request. It's the responsibility of that process to call CloseHandle on this token per request.</p> | `true` |
| `processPath` | <p>Required string attribute.</p><p>Path to the executable that launches a process listening for HTTP requests. Relative paths are supported. If the path begins with `.`, the path is considered to be relative to the site root.</p> | |
| `rapidFailsPerMinute` | <p>Optional integer attribute.</p><p>Specifies the number of times the process specified in **processPath** is allowed to crash per minute. If this limit is exceeded, the module stops launching the process for the remainder of the minute.</p> | `10` |
| `requestTimeout` | <p>Optional timespan attribute.</p><p>Specifies the duration for which the ASP.NET Core Module waits for a response from the process listening on %ASPNETCORE_PORT%.</p><p>In versions of the ASP.NET Core Module that shipped with the release of ASP.NET Core 2.1 or later, the `requestTimeout` is specified in hours, minutes, and seconds.</p> | `00:02:00` |
| `shutdownTimeLimit` | <p>Optional integer attribute.</p><p>Duration in seconds that the module waits for the executable to gracefully shutdown when the *app_offline.htm* file is detected.</p> | `10` |
| `startupTimeLimit` | <p>Optional integer attribute.</p><p>Duration in seconds that the module waits for the executable to start a process listening on the port. If this time limit is exceeded, the module kills the process. The module attempts to relaunch the process when it receives a new request and continues to attempt to restart the process on subsequent incoming requests unless the app fails to start **rapidFailsPerMinute** number of times in the last rolling minute.</p> | `120` |
| `stdoutLogEnabled` | <p>Optional Boolean attribute.</p><p>If true, **stdout** and **stderr** for the process specified in **processPath** are redirected to the file specified in **stdoutLogFile**.</p> | `false` |
| `stdoutLogFile` | <p>Optional string attribute.</p><p>Specifies the relative or absolute file path for which **stdout** and **stderr** from the process specified in **processPath** are logged. Relative paths are relative to the root of the site. Any path starting with `.` are relative to the site root and all other paths are treated as absolute paths. Any folders provided in the path must exist in order for the module to create the log file. Using underscore delimiters, a timestamp, process ID, and file extension (*.log*) are added to the last segment of the **stdoutLogFile** path. If `.\logs\stdout` is supplied as a value, an example stdout log is saved as *stdout_20180205194132_1934.log* in the *logs* folder when saved on 2/5/2018 at 19:41:32 with a process ID of 1934.</p> | `aspnetcore-stdout` |
::: moniker-end

### Setting environment variables

Environment variables can be specified for the process in the `processPath` attribute. Specify an environment variable with the `environmentVariable` child element of an `environmentVariables` collection element. Environment variables set in this section take precedence over system environment variables.

The following example sets two environment variables. `ASPNETCORE_ENVIRONMENT` configures the app's environment to `Development`. A developer may temporarily set this value in the *web.config* file in order to force the [Developer Exception Page](xref:fundamentals/error-handling) to load when debugging an app exception. `CONFIG_DIR` is an example of a user-defined environment variable, where the developer has written code that reads the value on startup to form a path for loading the app's configuration file.

```xml
<aspNetCore processPath="dotnet"
      arguments=".\MyApp.dll"
      stdoutLogEnabled="false"
      stdoutLogFile="\\?\%home%\LogFiles\stdout">
  <environmentVariables>
    <environmentVariable name="ASPNETCORE_ENVIRONMENT" value="Development" />
    <environmentVariable name="CONFIG_DIR" value="f:\application_config" />
  </environmentVariables>
</aspNetCore>
```

> [!WARNING]
> Only set the `ASPNETCORE_ENVIRONMENT` envirnonment variable to `Development` on staging and testing servers that aren't accessible to untrusted networks, such as the Internet.

## app_offline.htm

If a file with the name *app_offline.htm* is detected in the root directory of an app, the ASP.NET Core Module attempts to gracefully shutdown the app and stop processing incoming requests. If the app is still running after the number of seconds defined in `shutdownTimeLimit`, the ASP.NET Core Module kills the running process.

While the *app_offline.htm* file is present, the ASP.NET Core Module responds to requests by sending back the contents of the *app_offline.htm* file. When the *app_offline.htm* file is removed, the next request starts the app.

## Start-up error page

If the ASP.NET Core Module fails to launch the backend process or the backend process starts but fails to listen on the configured port, a *502.5 Process Failure* status code page appears. To suppress this page and revert to the default IIS 502 status code page, use the `disableStartUpErrorPage` attribute. For more information on configuring custom error messages, see [HTTP Errors `<httpErrors>`](/iis/configuration/system.webServer/httpErrors/).

![502.5 Process Failure Status Code Page](aspnet-core-module/_static/ANCM-502_5.png)

## Log creation and redirection

The ASP.NET Core Module redirects stdout and stderr logs to disk if the `stdoutLogEnabled` and `stdoutLogFile` attributes of the `aspNetCore` element are set. Any folders in the `stdoutLogFile` path must exist in order for the module to create the log file. The app pool must have write access to the location where the logs are written (use `IIS AppPool\<app_pool_name>` to provide write permission).

Logs aren't rotated, unless process recycling/restart occurs. It's the responsibility of the hoster to limit the disk space the logs consume.

Using the stdout log is only recommended for troubleshooting app startup issues. Don't use the stdout log for general app logging purposes. For routine logging in an ASP.NET Core app, use a logging library that limits log file size and rotates logs. For more information, see [third-party logging providers](xref:fundamentals/logging/index#third-party-logging-providers).

A timestamp and file extension are added automatically when the log file is created. The log file name is composed by appending the timestamp, process ID, and file extension (*.log*) to the last segment of the `stdoutLogFile` path (typically *stdout*) delimited by underscores. If the `stdoutLogFile` path ends with *stdout*, a log for an app with a PID of 1934 created on 2/5/2018 at 19:42:32 has the file name *stdout_20180205194132_1934.log*.

The following sample `aspNetCore` element configures stdout logging for an app hosted in Azure App Service. A local path or network share path is acceptable for local logging. Confirm that the AppPool user identity has permission to write to the path provided.

```xml
<aspNetCore processPath="dotnet"
    arguments=".\MyApp.dll"
    stdoutLogEnabled="true"
    stdoutLogFile="\\?\%home%\LogFiles\stdout">
</aspNetCore>
```

See [Configuration with web.config](#configuration-with-webconfig) for an example of the `aspNetCore` element in the *web.config* file.

## Proxy configuration uses HTTP protocol and a pairing token

The proxy created between the ASP.NET Core Module and Kestrel uses the HTTP protocol. Using HTTP is a performance optimization, where the traffic between the module and Kestrel takes place on a loopback address off of the network interface. There's no risk of eavesdropping the traffic between the module and Kestrel from a location off of the server.

A pairing token is used to guarantee that the requests received by Kestrel were proxied by IIS and didn't come from some other source. The pairing token is created and set into an environment variable (`ASPNETCORE_TOKEN`) by the module. The pairing token is also set into a header (`MSAspNetCoreToken`) on every proxied request. IIS Middleware checks each request it receives to confirm that the pairing token header value matches the environment variable value. If the token values are mismatched, the request is logged and rejected. The pairing token environment variable and the traffic between the module and Kestrel aren't accessible from a location off of the server. Without knowing the pairing token value, an attacker can't submit requests that bypass the check in the IIS Middleware.

## ASP.NET Core Module with an IIS Shared Configuration

The ASP.NET Core Module installer runs with the privileges of the **SYSTEM** account. Because the local system account doesn't have modify permission for the share path used by the IIS Shared Configuration, the installer hits an access denied error when attempting to configure the module settings in *applicationHost.config* on the share. When using an IIS Shared Configuration, follow these steps:

1. Disable the IIS Shared Configuration.
1. Run the installer.
1. Export the updated *applicationHost.config* file to the share.
1. Re-enable the IIS Shared Configuration.

## Module version and Hosting Bundle installer logs

To determine the version of the installed ASP.NET Core Module:

1. On the hosting system, navigate to *%windir%\System32\inetsrv*.
1. Locate the *aspnetcore.dll* file.
1. Right-click the file and select **Properties** from the contextual menu.
1. Select the **Details** tab. The **File version** and **Product version** represent the installed version of the module.

The Hosting Bundle installer logs for the module are found at *C:\\Users\\%UserName%\\AppData\\Local\\Temp*. The file is named *dd_DotNetCoreWinSvrHosting__\<timestamp>_000_AspNetCoreModule_x64.log*.

## Module, schema, and configuration file locations

### Module

**IIS (x86/amd64):**

   * %windir%\System32\inetsrv\aspnetcore.dll

   * %windir%\SysWOW64\inetsrv\aspnetcore.dll

**IIS Express (x86/amd64):**

   * %ProgramFiles%\IIS Express\aspnetcore.dll

   * %ProgramFiles(x86)%\IIS Express\aspnetcore.dll

### Schema

**IIS**

   * %windir%\System32\inetsrv\config\schema\aspnetcore_schema.xml

**IIS Express**

   * %ProgramFiles%\IIS Express\config\schema\aspnetcore_schema.xml

### Configuration

**IIS**

   * %windir%\System32\inetsrv\config\applicationHost.config

**IIS Express**

   * .vs\config\applicationHost.config

The files can be found by searching for *aspnetcore.dll* in the *applicationHost.config* file. For IIS Express, the *applicationHost.config* file won't exist by default. The file is created at *\<application_root>\\.vs\\config* when starting any web app project in the Visual Studio solution.
