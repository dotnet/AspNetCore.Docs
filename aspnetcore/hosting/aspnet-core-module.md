---
title: ASP.NET Core Module Configuration Reference | Microsoft Docs
author: rick-anderson
description: 
keywords: ASP.NET Core,
ms.author: riande
manager: wpickett
ms.date: 10/27/2016
ms.topic: article
ms.assetid: 5de0c8f7-50ce-4e2c-b3d4-a1bd9fdfcff5
ms.technology: aspnet
ms.prod: aspnet-core
uid: hosting/aspnet-core-module
---
# ASP.NET Core Module Configuration Reference

By [Luke Latham](https://github.com/GuardRex), [Rick Anderson](https://twitter.com/RickAndMSFT) and [Sourabh Shirhatti](https://twitter.com/sshirhatti)

ASP.NET Core Module is an IIS module that lets [Kestrel](../fundamentals/servers/kestrel.md) use IIS or IIS Express as a reverse proxy server. This document provides an overview of how to configure the ASP.NET Core Module for shared hosting of ASP.NET Core applications.

For an introduction to ASP.NET Core Module and information about how to install it, see [ASP.NET Core Module](../fundamentals/servers/aspnet-core-module.md).

## The Web.config file

The ASP.NET Core Module is configured via a site or application *web.config* file and has its own `aspNetCore` configuration section within `system.webServer`. Here's an example from a Visual Studio project, with placeholders for settings that Visual Studio plugs in when you run or debug the project.

```xml
<configuration>
  <!--
    Configure your application settings in appsettings.json. Learn more at http://go.microsoft.com/fwlink/?LinkId=786380
  -->
  <system.webServer>
    <handlers>
      <add name="aspNetCore" path="*" verb="*" modules="AspNetCoreModule" resourceType="Unspecified" />
    </handlers>
    <aspNetCore processPath="%LAUNCHER_PATH%" arguments="%LAUNCHER_ARGS%" stdoutLogEnabled="true" stdoutLogFile=".\logs\stdout" forwardWindowsAuthToken="false" />
  </system.webServer>
</configuration>
```

When the project is published, Visual Studio automatically plugs in the values required for the destination environment, as shown in this example of a project that has been deployed to an Azure web app.

```xml
<configuration>
  <!--
    Configure your application settings in appsettings.json. Learn more at http://go.microsoft.com/fwlink/?LinkId=786380
  -->
  <system.webServer>
    <handlers>
      <add name="aspNetCore" path="*" verb="*" modules="AspNetCoreModule" resourceType="Unspecified" />
    </handlers>
    <aspNetCore processPath=".\sample.exe" arguments="" stdoutLogEnabled="true" stdoutLogFile="\\?\%home%\LogFiles\stdout" forwardWindowsAuthToken="false" />
  </system.webServer>
</configuration>
<!--ProjectGuid: c270f740-c62c-4f88-a2dc-c3f7e9dc61e8-->
```

### Attributes of the aspNetCore element

| Attribute  |     Description |
|---|---|
| processPath             |<p>Required string attribute.</p><p>Path to the executable that will launch a process listening for HTTP requests. Relative paths are supported. If the path begins with '.', the path is considered to be relative to the site root.</p><p>There is no default value.</p>|
| arguments               |<p>Optional string attribute.</p><p>Arguments to the executable specified in **processPath**.</p><p>The default value is an empty string.</p>|
| startupTimeLimit        |<p>Optional integer attribute.</p><p>Duration in seconds for which the module will wait for the executable to start a process listening on the port. If this time limit is exceeded, the module will kill the process. The module will attempt to launch the process again when it receives a new request and will continue to attempt to restart the process on subsequent incoming requests unless the application fails to start **rapidFailsPerMinute** number of times in the last rolling minute.</p><p>The default value is 120.</p>|
| shutdownTimeLimit       |<p>Optional integer attribute.</p><p>Duration in seconds for which the module will wait for the executable to gracefully shutdown when the *app_offline.htm* file is detected.</p><p>The default value is 10.</p>|
| rapidFailsPerMinute     |<p>Optional integer attribute.</p><p>Specifies the number of times the process specified in **processPath** is allowed to crash per minute. If this limit is exceeded, the module will stop launching the process for the remainder of the minute.</p><p>The default value is 10.</p>|
| requestTimeout          |<p>Optional timespan attribute.</p><p>Specifies the duration for which the ASP.NET Core Module will wait for a response from the process listening on %ASPNETCORE_PORT%.</p><p>The default value is "00:02:00".</p>|
| stdoutLogEnabled        |<p>Optional Boolean attribute.</p><p>If true, **stdout** and **stderr** for the process specified in **processPath** will be redirected to the file specified in **stdoutLogFile**.</p><p>The default value is false.</p>|
| stdoutLogFile           |<p>Optional string attribute.</p><p>Specifies the relative or absolute file path for which **stdout** and **stderr** from the process specified in **processPath** will be logged. Relative paths are relative to the root of the site. Any path starting with '.' will be relative to the site root and all other paths will be treated as absolute paths. A timestamp and the file extension will automatically be added to the filename provided. Any folders provided in the path must exist in order for the module to create the log file.</p><p>The default value is `aspnetcore-stdout`.</p>|
| forwardWindowsAuthToken |true or false.</p><p>If true, the token will be forwarded to the child process listening on %ASPNETCORE_PORT% as a header 'MS-ASPNETCORE-WINAUTHTOKEN' per request. It is the responsibility of that process to call CloseHandle on this token per request.</p><p>The default value is false.</p>|
| disableStartUpErrorPage |true or false.</p><p>If true, the **502.5 - Process Failure** page will be suppressed, and the 502 status code page configured in your *web.config* will take precedence.</p><p>The default value is false.</p>|

### environmentVariables child element of aspNetCore

The ASP.NET Core Module allows you specify environment variables for the process specified in the `processPath` attribute by specifying them in one or more `environmentVariable` child elements of an `environmentVariables` collection element under the `aspNetCore` element. Environment variables set in this section take precedence over system environment variables for the process.

Here's an example that sets two environment variables.

```xml
<aspNetCore processPath="dotnet"
        arguments=".\MyApp.dll"
        stdoutLogEnabled="false"
        stdoutLogFile="\\?\%home%\LogFiles\stdout">
  <environmentVariables>
    <environmentVariable name="ASPNETCORE_ENVIRONMENT" value="Staging" />
    <environmentVariable name="ENV_VAR_1" value="VALUE_1" />
    <environmentVariable name="ENV_VAR_2" value="VALUE_2" />
  </environmentVariables>
</aspNetCore>
```

## app_offline.htm

If you place a file with the name *app_offline.htm* at the root of a web application directory, the ASP.NET Core Module will attempt to gracefully shut-down the application and stop processing any new incoming requests. If the application is still running after `shutdownTimeLimit` number of seconds, the ASP.NET Core Module will kill the running process.

While the *app_offline.htm* file is present, the ASP.NET Core Module will respond to all requests by sending back the contents of the *app_offline.htm* file. Once the *app_offline.htm* file is removed, the next request loads the application, which then responds to requests.

## Start-up error page

If the ASP.NET Core Module fails to launch the backend process or the backend process starts but fails to listen on the configured port, you will see an HTTP 502.5 status code page. 

![image](aspnet-core-module/_static/ANCM-502_5.png)

To suppress this page and revert to the default IIS 502 status code page, use the `disableStartUpErrorPage` attribute. Look at the [HTTP Errors attribute](https://www.iis.net/configreference/system.webserver/httperrors) to override this page with a custom error page.

## Log creation and redirection

The ASP.NET Core Module redirects `stdout` and `stderr` logs to disk if you set the `stdoutLogEnabled` and `stdoutLogFile` attributes of the `aspNetCore` element. Any folders in the `stdoutLogFile` path must exist in order for the module to create the log file. A timestamp and file extension will be added automatically when the log file is created. Logs are not rotated (unless process recycling/restart occurs). It is the responsibility of the hoster to limit the disk space the logs consume. Using the `stdout` log is only recommended for troubleshooting application startup issues and not for general application logging purposes.

Here's a sample aspNetCore element that configures stdout logging:

```xml
<aspNetCore processPath="dotnet"
        arguments=".\MyApp.dll"
        stdoutLogEnabled="true"
        stdoutLogFile="\\?\%home%\LogFiles\stdout">
</aspNetCore>
```

## ASP.NET Core Module with IIS Shared Configuration

The ASP.NET Core Module installer runs with the privileges of the **SYSTEM** account. Because the local system account does not have modify permission for the share path which is used by the IIS Shared Configuration, the installer will hit an access denied error when attempting to configure the module settings in *applicationHost.config* on the share.

The unsupported workaround is to disable the IIS Shared Configuration, run the installer, export the updated *applicationHost.config* file to the share, and re-enable the IIS Shared Configuration.

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

You can search for *aspnetcore.dll* in the *applicationHost.config* file. For IIS Express, the *applicationHost.config* file won't exist by default. The file is created at *{application root}\.vs\config* when you start any web application project in the Visual Studio solution.
