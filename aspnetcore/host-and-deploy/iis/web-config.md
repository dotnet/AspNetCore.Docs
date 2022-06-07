---
title: web.config file
author: rick-anderson
description: Discover what is inside of the web.config file and how to configure different ASP.NET Core Module options.
monikerRange: '>= aspnetcore-5.0'
ms.author: riande
ms.custom: mvc
ms.date: 02/07/2020
uid: host-and-deploy/iis/web-config
---
# `web.config` file

The `web.config` is a file that is read by IIS and the [ASP.NET Core Module](xref:host-and-deploy/aspnet-core-module) to configure an app hosted with IIS.

## `web.config` file location

In order to set up the [ASP.NET Core Module](xref:host-and-deploy/aspnet-core-module) correctly, the `web.config` file must be present at the [content root](xref:fundamentals/index#content-root) path (typically the app base path) of the deployed app. This is the same location as the website physical path provided to IIS. The `web.config` file is required at the root of the app to enable the publishing of multiple apps using Web Deploy.

Sensitive files exist on the app's physical path, such as `{ASSEMBLY}.runtimeconfig.json`, `{ASSEMBLY}.xml` (XML Documentation comments), and `{ASSEMBLY}.deps.json`, where the placeholder `{ASSEMBLY}` is the assembly name. When the `web.config` file is present and the site starts normally, IIS doesn't serve these sensitive files if they're requested. If the `web.config` file is missing, incorrectly named, or unable to configure the site for normal startup, IIS may serve sensitive files publicly.

**The `web.config` file must be present in the deployment at all times, correctly named, and able to configure the site for normal start up. Never remove the `web.config` file from a production deployment.**

If a `web.config` file isn't present in the project, the file is created with the correct `processPath` and `arguments` to configure the ASP.NET Core Module and moved to [published output](xref:host-and-deploy/directory-structure).

If a `web.config` file is present in the project, the file is transformed with the correct `processPath` and `arguments` to configure the ASP.NET Core Module and moved to published output. The transformation doesn't modify IIS configuration settings in the file.

The `web.config` file may provide additional IIS configuration settings that control active IIS modules. For information on IIS modules that are capable of processing requests with ASP.NET Core apps, see the [IIS modules](xref:host-and-deploy/iis/modules) topic.

Creating, transforming, and publishing the `web.config` file is handled by an MSBuild target (`_TransformWebConfig`) when the project is published. This target is present in the Web SDK targets (`Microsoft.NET.Sdk.Web`). The SDK is set at the top of the project file:

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">
```

To prevent the Web SDK from transforming the `web.config` file, use the `<IsTransformWebConfigDisabled>` property in the project file:

```xml
<PropertyGroup>
  <IsTransformWebConfigDisabled>true</IsTransformWebConfigDisabled>
</PropertyGroup>
```

When disabling the Web SDK from transforming the file, the `processPath` and `arguments` should be manually set by the developer. For more information, see <xref:host-and-deploy/aspnet-core-module>.

## Configuration of ASP.NET Core Module with `web.config`

The ASP.NET Core Module is configured with the `aspNetCore` section of the `system.webServer` node in the site's `web.config` file.

The following `web.config` file is published for a [framework-dependent deployment](/dotnet/articles/core/deploying/#framework-dependent-deployments-fdd) and configures the ASP.NET Core Module to handle site requests:

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <location path="." inheritInChildApplications="false">
    <system.webServer>
      <handlers>
        <add name="aspNetCore" path="*" verb="*" modules="AspNetCoreModuleV2" resourceType="Unspecified" />
      </handlers>
      <aspNetCore processPath="dotnet"
                  arguments=".\MyApp.dll"
                  stdoutLogEnabled="false"
                  stdoutLogFile=".\logs\stdout"
                  hostingModel="inprocess" />
    </system.webServer>
  </location>
</configuration>
```

The following `web.config` is published for a [self-contained deployment](/dotnet/articles/core/deploying/#self-contained-deployments-scd):

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <location path="." inheritInChildApplications="false">
    <system.webServer>
      <handlers>
        <add name="aspNetCore" path="*" verb="*" modules="AspNetCoreModuleV2" resourceType="Unspecified" />
      </handlers>
      <aspNetCore processPath=".\MyApp.exe"
                  stdoutLogEnabled="false"
                  stdoutLogFile=".\logs\stdout"
                  hostingModel="inprocess" />
    </system.webServer>
  </location>
</configuration>
```

The <xref:System.Configuration.SectionInformation.InheritInChildApplications%2A> property is set to `false` to indicate that the settings specified within the [`<location>`](/iis/manage/managing-your-configuration-settings/understanding-iis-configuration-delegation#the-concept-of-location) element aren't inherited by apps that reside in a subdirectory of the app.

When an app is deployed to [Azure App Service](https://azure.microsoft.com/services/app-service/), the `stdoutLogFile` path is set to `\\?\%home%\LogFiles\stdout`. The path saves stdout logs to the `LogFiles` folder, which is a location automatically created by the service.

For information on IIS sub-application configuration, see <xref:host-and-deploy/iis/advanced#sub-applications>.

### Attributes of the `aspNetCore` element

| Attribute | Description | Default |
| --------- | ----------- | :-----: |
| `arguments` | <p>Optional string attribute.</p><p>Arguments to the executable specified in `processPath`.</p> | |
| `disableStartUpErrorPage` | <p>Optional Boolean attribute.</p><p>If true, the **502.5 - Process Failure** page is suppressed, and the 502 status code page configured in the `web.config` takes precedence.</p> | `false` |
| `forwardWindowsAuthToken` | <p>Optional Boolean attribute.</p><p>If true, the token is forwarded to the child process listening on `%ASPNETCORE_PORT%` as a header 'MS-ASPNETCORE-WINAUTHTOKEN' per request. It's the responsibility of that process to call CloseHandle on this token per request.</p> | `true` |
| `hostingModel` | <p>Optional string attribute.</p><p>Specifies the hosting model as in-process (`InProcess`/`inprocess`) or out-of-process (`OutOfProcess`/`outofprocess`).</p> | `OutOfProcess`/`outofprocess` when not present |
| `processesPerApplication` | <p>Optional integer attribute.</p><p>Specifies the number of instances of the process specified in the `processPath` setting that can be spun up per app.</p><p>&dagger;For in-process hosting, the value is limited to `1`.</p><p>Setting `processesPerApplication` is discouraged. This attribute will be removed in a future release.</p> | Default: `1`<br>Min: `1`<br>Max: `100`&dagger; |
| `processPath` | <p>Required string attribute.</p><p>Path to the executable that launches a process listening for HTTP requests. Relative paths are supported. If the path begins with `.`, the path is considered to be relative to the site root.</p> | |
| `rapidFailsPerMinute` | <p>Optional integer attribute.</p><p>Specifies the number of times the process specified in `processPath` is allowed to crash per minute. If this limit is exceeded, the module stops launching the process for the remainder of the minute.</p><p>Not supported with in-process hosting.</p> | Default: `10`<br>Min: `0`<br>Max: `100` |
| `requestTimeout` | <p>Optional timespan attribute.</p><p>Specifies the duration for which the ASP.NET Core Module waits for a response from the process listening on %ASPNETCORE_PORT%.</p><p>In versions of the ASP.NET Core Module that shipped with the release of ASP.NET Core 2.1 or later, the `requestTimeout` is specified in hours, minutes, and seconds.</p><p>Doesn't apply to in-process hosting. For in-process hosting, the module waits for the app to process the request.</p><p>Valid values for minutes and seconds segments of the string are in the range 0-59. Use of `60` in the value for minutes or seconds results in a *500 - Internal Server Error*.</p> | Default: `00:02:00`<br>Min: `00:00:00`<br>Max: `360:00:00` |
| `shutdownTimeLimit` | <p>Optional integer attribute.</p><p>Duration in seconds that the module waits for the executable to gracefully shutdown when the `app_offline.htm` file is detected.</p> | Default: `10`<br>Min: `0`<br>Max: `600` |
| `startupTimeLimit` | <p>Optional integer attribute.</p><p>Duration in seconds that the module waits for the executable to start a process listening on the port. If this time limit is exceeded, the module kills the process.</p><p>When hosting *in-process*: The process is **not** restarted and does **not** use the `rapidFailsPerMinute` setting.</p><p>When hosting *out-of-process*: The module attempts to relaunch the process when it receives a new request and continues to attempt to restart the process on subsequent incoming requests unless the app fails to start `rapidFailsPerMinute` number of times in the last rolling minute.</p><p>A value of 0 (zero) is **not** considered an infinite timeout.</p> | Default: `120`<br>Min: `0`<br>Max: `3600` |
| `stdoutLogEnabled` | <p>Optional Boolean attribute.</p><p>If true, `stdout` and `stderr` for the process specified in `processPath` are redirected to the file specified in `stdoutLogFile`.</p> | `false` |
| `stdoutLogFile` | <p>Optional string attribute.</p><p>Specifies the relative or absolute file path for which `stdout` and `stderr` from the process specified in `processPath` are logged. Relative paths are relative to the root of the site. Any path starting with `.` are relative to the site root and all other paths are treated as absolute paths. Any folders provided in the path are created by the module when the log file is created. Using underscore delimiters, a timestamp, process ID, and file extension (`.log`) are added to the last segment of the `stdoutLogFile` path. If `.\logs\stdout` is supplied as a value, an example stdout log is saved as `stdout_20180205194132_1934.log` in the `logs` folder when saved on February 5, 2018 at 19:41:32 with a process ID of 1934.</p> | `aspnetcore-stdout` |

### Set environment variables

Environment variables can be specified for the process in the `processPath` attribute. Specify an environment variable with the `<environmentVariable>` child element of an `<environmentVariables>` collection element. Environment variables set in this section take precedence over system environment variables.

The following example sets two environment variables in `web.config`. `ASPNETCORE_ENVIRONMENT` configures the app's environment to `Development`. A developer may temporarily set this value in the `web.config` file in order to force the [Developer Exception Page](xref:fundamentals/error-handling) to load when debugging an app exception. `CONFIG_DIR` is an example of a user-defined environment variable, where the developer has written code that reads the value on startup to form a path for loading the app's configuration file.

```xml
<aspNetCore processPath="dotnet"
      arguments=".\MyApp.dll"
      stdoutLogEnabled="false"
      stdoutLogFile=".\logs\stdout"
      hostingModel="inprocess">
  <environmentVariables>
    <environmentVariable name="ASPNETCORE_ENVIRONMENT" value="Development" />
    <environmentVariable name="CONFIG_DIR" value="f:\application_config" />
  </environmentVariables>
</aspNetCore>
```

> [!NOTE]
> An alternative to setting the environment directly in `web.config` is to include the `<EnvironmentName>` property in the [publish profile (`.pubxml`)](xref:host-and-deploy/visual-studio-publish-profiles) or project file. This approach sets the environment in `web.config` when the project is published:
>
> ```xml
> <PropertyGroup>
>   <EnvironmentName>Development</EnvironmentName>
> </PropertyGroup>
> ```

> [!WARNING]
> Only set the `ASPNETCORE_ENVIRONMENT` environment variable to `Development` on staging and testing servers that aren't accessible to untrusted networks, such as the Internet.

## Configuration of IIS with `web.config`

IIS configuration is influenced by the `<system.webServer>` section of `web.config` for IIS scenarios that are functional for ASP.NET Core apps with the ASP.NET Core Module. For example, IIS configuration is functional for dynamic compression. If IIS is configured at the server level to use dynamic compression, the `<urlCompression>` element in the app's `web.config` file can disable it for an ASP.NET Core app.

For more information, see the following topics:

* [Configuration reference for `<system.webServer>`](/iis/configuration/system.webServer/)
* <xref:host-and-deploy/aspnet-core-module>
* <xref:host-and-deploy/iis/modules>

To set environment variables for individual apps running in isolated app pools (supported for IIS 10.0 or later), see the *`AppCmd.exe` command* section of the [Environment Variables `<environmentVariables>`](/iis/configuration/system.applicationHost/applicationPools/add/environmentVariables/#appcmdexe) topic in the IIS reference documentation.

## Configuration sections of `web.config`

Configuration sections of ASP.NET 4.x apps in `web.config` aren't used by ASP.NET Core apps for configuration:

* `<system.web>`
* `<appSettings>`
* `<connectionStrings>`
* `<location>`

ASP.NET Core apps are configured using other configuration providers. For more information, see [Configuration](xref:fundamentals/configuration/index).

## Transform web.config

If you need to transform `web.config` on publish, see <xref:host-and-deploy/iis/transform-webconfig>. You might need to transform `web.config` on publish to set environment variables based on the configuration, profile, or environment.

## Additional resources

* [IIS \<system.webServer>](/iis/configuration/system.webServer/)
* <xref:host-and-deploy/iis/modules>
* <xref:host-and-deploy/iis/transform-webconfig>
