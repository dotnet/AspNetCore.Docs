---
title: Host ASP.NET Core in a Windows Service
author: rick-anderson
description: Learn how to host an ASP.NET Core app in a Windows Service.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 3/07/2022
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: host-and-deploy/windows-service
---
# Host ASP.NET Core in a Windows Service

:::moniker range=">= aspnetcore-6.0"

An ASP.NET Core app can be hosted on Windows as a [Windows Service](/dotnet/framework/windows-services/introduction-to-windows-service-applications) without using IIS. When hosted as a Windows Service, the app automatically starts after server reboots.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/host-and-deploy/windows-service/samples) ([how to download](xref:index#how-to-download-a-sample))

## Prerequisites

* [ASP.NET Core SDK 2.1 or later](https://dotnet.microsoft.com/download)
* [PowerShell 6.2 or later](https://github.com/PowerShell/PowerShell)

## Worker Service template

The ASP.NET Core Worker Service template provides a starting point for writing long running service apps. To use the template as a basis for a Windows Service app:

1. Create a Worker Service app from the .NET Core template.
1. Follow the guidance in the [App configuration](#app-configuration) section to update the Worker Service app so that it can run as a Windows Service.

[!INCLUDE[](~/includes/worker-template-instructions.md)]

## App configuration

The app requires a package reference for [Microsoft.Extensions.Hosting.WindowsServices](https://www.nuget.org/packages/Microsoft.Extensions.Hosting.WindowsServices).

`IHostBuilder.UseWindowsService` is called when building the host. If the app is running as a Windows Service, the method:

* Sets the host lifetime to `WindowsServiceLifetime`.
* Sets the [content root](xref:fundamentals/index#content-root) to [AppContext.BaseDirectory](xref:System.AppContext.BaseDirectory). For more information, see the [Current directory and content root](#current-directory-and-content-root) section.
* Enables logging to the event log:
  * The application name is used as the default source name.
  * The default log level is *Warning* or higher for an app based on an ASP.NET Core template that calls `CreateDefaultBuilder` to build the host.
  * Override the default log level with the `Logging:EventLog:LogLevel:Default` key in `appsettings.json`/`appsettings.{Environment}.json` or other configuration provider.
  * Only administrators can create new event sources. When an event source can't be created using the application name, a warning is logged to the *Application* source and event logs are disabled.

In `CreateHostBuilder` of `Program.cs`:

```csharp
Host.CreateDefaultBuilder(args)
    .UseWindowsService()
    ...
```

The following sample apps accompany this topic:

* Background Worker Service Sample: A non-web app sample based on the [Worker Service template](#worker-service-template) that uses [hosted services](xref:fundamentals/host/hosted-services) for background tasks.
* Web App Service Sample: A Razor Pages web app sample that runs as a Windows Service with [hosted services](xref:fundamentals/host/hosted-services) for background tasks.

For MVC guidance, see the articles under <xref:mvc/overview> and <xref:migration/22-to-30>.

## Deployment type

For information and advice on deployment scenarios, see [.NET Core application deployment](/dotnet/core/deploying/).

### SDK

For a web app-based service that uses the Razor Pages or MVC frameworks, specify the Web SDK in the project file:

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">
```

If the service only executes background tasks (for example, [hosted services](xref:fundamentals/host/hosted-services)), specify the Worker SDK in the project file:

```xml
<Project Sdk="Microsoft.NET.Sdk.Worker">
```

### Framework-dependent deployment (FDD)

Framework-dependent deployment (FDD) relies on the presence of a shared system-wide version of .NET Core on the target system. When the FDD scenario is adopted following the guidance in this article, the SDK produces an executable (*.exe*), called a *framework-dependent executable*.

If using the [Web SDK](#sdk), a *web.config* file, which is normally produced when publishing an ASP.NET Core app, is unnecessary for a Windows Services app. To disable the creation of the *web.config* file, add the `<IsTransformWebConfigDisabled>` property set to `true`.

```xml
<PropertyGroup>
  <TargetFramework>netcoreapp3.0</TargetFramework>
  <IsTransformWebConfigDisabled>true</IsTransformWebConfigDisabled>
</PropertyGroup>
```

### Self-contained deployment (SCD)

Self-contained deployment (SCD) doesn't rely on the presence of a shared framework on the host system. The runtime and the app's dependencies are deployed with the app.

A Windows [Runtime Identifier (RID)](/dotnet/core/rid-catalog) is included in the `<PropertyGroup>` that contains the target framework:

```xml
<RuntimeIdentifier>win7-x64</RuntimeIdentifier>
```

To publish for multiple RIDs:

* Provide the RIDs in a semicolon-delimited list.
* Use the property name [\<RuntimeIdentifiers>](/dotnet/core/tools/csproj#runtimeidentifiers) (plural).

For more information, see [.NET Core RID Catalog](/dotnet/core/rid-catalog).

## Service user account

To create a user account for a service, use the [New-LocalUser](/powershell/module/microsoft.powershell.localaccounts/new-localuser) cmdlet from an administrative PowerShell 6 command shell.

On Windows 10 October 2018 Update (version 1809/build 10.0.17763) or later:

```powershell
New-LocalUser -Name {SERVICE NAME}
```

On Windows OS earlier than the Windows 10 October 2018 Update (version 1809/build 10.0.17763):

```console
powershell -Command "New-LocalUser -Name {SERVICE NAME}"
```

Provide a [strong password](/windows/security/threat-protection/security-policy-settings/password-must-meet-complexity-requirements) when prompted.

Unless the `-AccountExpires` parameter is supplied to the [New-LocalUser](/powershell/module/microsoft.powershell.localaccounts/new-localuser) cmdlet with an expiration <xref:System.DateTime>, the account doesn't expire.

For more information, see [Microsoft.PowerShell.LocalAccounts](/powershell/module/microsoft.powershell.localaccounts/) and [Service User Accounts](/windows/desktop/services/service-user-accounts).

An alternative approach to managing users when using Active Directory is to use Managed Service Accounts. For more information, see [Group Managed Service Accounts Overview](/windows-server/security/group-managed-service-accounts/group-managed-service-accounts-overview).

## Log on as a service rights

To establish *Log on as a service* rights for a service user account:

1. Open the Local Security Policy editor by running *secpol.msc*.
1. Expand the **Local Policies** node and select **User Rights Assignment**.
1. Open the **Log on as a service** policy.
1. Select **Add User or Group**.
1. Provide the object name (user account) using either of the following approaches:
   1. Type the user account (`{DOMAIN OR COMPUTER NAME\USER}`) in the object name field and select **OK** to add the user to the policy.
   1. Select **Advanced**. Select **Find Now**. Select the user account from the list. Select **OK**. Select **OK** again to add the user to the policy.
1. Select **OK** or **Apply** to accept the changes.

## Create and manage the Windows Service

### Create a service

Use PowerShell commands to register a service. From an administrative PowerShell 6 command shell, execute the following commands:

```powershell
$acl = Get-Acl "{EXE PATH}"
$aclRuleArgs = "{DOMAIN OR COMPUTER NAME\USER}", "Read,Write,ReadAndExecute", "ContainerInherit,ObjectInherit", "None", "Allow"
$accessRule = New-Object System.Security.AccessControl.FileSystemAccessRule($aclRuleArgs)
$acl.SetAccessRule($accessRule)
$acl | Set-Acl "{EXE PATH}"

New-Service -Name {SERVICE NAME} -BinaryPathName "{EXE FILE PATH}" -Credential "{DOMAIN OR COMPUTER NAME\USER}" -Description "{DESCRIPTION}" -DisplayName "{DISPLAY NAME}" -StartupType Automatic
```

* `{EXE PATH}`: Path of the app's executable on the host (for example, `d:\myservice`). Don't include the app's executable file name in the path. A trailing slash isn't required.
* `{DOMAIN OR COMPUTER NAME\USER}`: Service user account (for example, `Contoso\ServiceUser`).
* `{SERVICE NAME}`: Service name (for example, `MyService`).
* `{EXE FILE PATH}`: The app's full executable path (for example, `d:\myservice\myservice.exe`). Include the executable's file name with extension.
* `{DESCRIPTION}`: Service description (for example, `My sample service`).
* `{DISPLAY NAME}`: Service display name (for example, `My Service`).

### Start a service

Start a service with the following PowerShell 6 command:

```powershell
Start-Service -Name {SERVICE NAME}
```

The command takes a few seconds to start the service.

### Determine a service's status

To check the status of a service, use the following PowerShell 6 command:

```powershell
Get-Service -Name {SERVICE NAME}
```

The status is reported as one of the following values:

* `Starting`
* `Running`
* `Stopping`
* `Stopped`

### Stop a service

Stop a service with the following PowerShell 6 command:

```powershell
Stop-Service -Name {SERVICE NAME}
```

### Remove a service

After a short delay to stop a service, remove a service with the following PowerShell 6 command:

```powershell
Remove-Service -Name {SERVICE NAME}
```

## Proxy server and load balancer scenarios

Services that interact with requests from the Internet or a corporate network and are behind a proxy or load balancer might require additional configuration. For more information, see <xref:host-and-deploy/proxy-load-balancer>.

## Configure endpoints

By default, ASP.NET Core binds to `http://localhost:5000`. Configure the URL and port by setting the `ASPNETCORE_URLS` environment variable.

For additional URL and port configuration approaches, see the relevant server article:

* <xref:fundamentals/servers/kestrel/endpoints>
* <xref:fundamentals/servers/httpsys#configure-windows-server>

The preceding guidance covers support for HTTPS endpoints. For example, configure the app for HTTPS when authentication is used with a Windows Service.

> [!NOTE]
> Use of the ASP.NET Core HTTPS development certificate to secure a service endpoint isn't supported.

## Current directory and content root

The current working directory returned by calling <xref:System.IO.Directory.GetCurrentDirectory%2A> for a Windows Service is the *C:\\WINDOWS\\system32* folder. The *system32* folder isn't a suitable location to store a service's files (for example, settings files). Use one of the following approaches to maintain and access a service's assets and settings files.

### Use ContentRootPath or ContentRootFileProvider

Use [IHostEnvironment.ContentRootPath](xref:Microsoft.Extensions.Hosting.IHostEnvironment.ContentRootPath) or <xref:Microsoft.Extensions.Hosting.IHostEnvironment.ContentRootFileProvider> to locate an app's resources.

When the app runs as a service, <xref:Microsoft.Extensions.Hosting.WindowsServiceLifetimeHostBuilderExtensions.UseWindowsService%2A> sets the <xref:Microsoft.Extensions.Hosting.IHostEnvironment.ContentRootPath> to [AppContext.BaseDirectory](xref:System.AppContext.BaseDirectory).

The app's default settings files, `appsettings.json` and `appsettings.{Environment}.json`, are loaded from the app's content root by calling [CreateDefaultBuilder during host construction](xref:fundamentals/host/generic-host#set-up-a-host).

For other settings files loaded by developer code in <xref:Microsoft.Extensions.Hosting.HostBuilder.ConfigureAppConfiguration%2A>, there's no need to call <xref:Microsoft.Extensions.Configuration.FileConfigurationExtensions.SetBasePath%2A>. In the following example, the `custom_settings.json` file exists in the app's content root and is loaded without explicitly setting a base path:

:::code language="csharp" source="windows-service/samples_snapshot/CustomSettingsExample.cs" highlight="13":::

Don't attempt to use <xref:System.IO.Directory.GetCurrentDirectory%2A> to obtain a resource path because a Windows Service app returns the *C:\\WINDOWS\\system32* folder as its current directory.

### Store a service's files in a suitable location on disk

Specify an absolute path with <xref:Microsoft.Extensions.Configuration.FileConfigurationExtensions.SetBasePath%2A> when using an <xref:Microsoft.Extensions.Configuration.IConfigurationBuilder> to the folder containing the files.

## Troubleshoot

To troubleshoot a Windows Service app, see <xref:test/troubleshoot>.

### Common errors

* An old or pre-release version of PowerShell is in use.
* The registered service doesn't use the app's **published** output from the [dotnet publish](/dotnet/core/tools/dotnet-publish) command. Output of the [dotnet build](/dotnet/core/tools/dotnet-build) command isn't supported for app deployment. Published assets are found in either of the following folders depending on the deployment type:
  * *bin/Release/{TARGET FRAMEWORK}/publish* (FDD)
  * *bin/Release/{TARGET FRAMEWORK}/{RUNTIME IDENTIFIER}/publish* (SCD)
* The service isn't in the RUNNING state.
* The paths to resources that the app uses (for example, certificates) are incorrect. The base path of a Windows Service is *c:\\Windows\\System32*.
* The user doesn't have *Log on as a service* rights.
* The user's password is expired or incorrectly passed when executing the `New-Service` PowerShell command.
* The app requires ASP.NET Core authentication but isn't configured for secure connections (HTTPS).
* The request URL port is incorrect or not configured correctly in the app.

### System and Application Event Logs

Access the System and Application Event Logs:

1. Open the Start menu, search for *Event Viewer*, and select the **Event Viewer** app.
1. In **Event Viewer**, open the **Windows Logs** node.
1. Select **System** to open the System Event Log. Select **Application** to open the Application Event Log.
1. Search for errors associated with the failing app.

### Run the app at a command prompt

Many startup errors don't produce useful information in the event logs. You can find the cause of some errors by running the app at a command prompt on the hosting system. To log additional detail from the app, lower the [log level](xref:fundamentals/logging/index#log-level) or run the app in the [Development environment](xref:fundamentals/environments).

### Clear package caches

A functioning app may fail immediately after upgrading either the .NET Core SDK on the development machine or changing package versions within the app. In some cases, incoherent packages may break an app when performing major upgrades. Most of these issues can be fixed by following these instructions:

1. Delete the *bin* and *obj* folders.
1. Clear the package caches by executing [dotnet nuget locals all --clear](/dotnet/core/tools/dotnet-nuget-locals) from a command shell.

   Clearing package caches can also be accomplished with the [nuget.exe](https://www.nuget.org/downloads) tool and executing the command `nuget locals all -clear`. *nuget.exe* isn't a bundled install with the Windows desktop operating system and must be obtained separately from the [NuGet website](https://www.nuget.org/downloads).

1. Restore and rebuild the project.
1. Delete all of the files in the deployment folder on the server prior to redeploying the app.

### Slow or unresponsive app

A *crash dump* is a snapshot of the system's memory and can help determine the cause of an app crash, startup failure, or slow app.

#### App crashes or encounters an exception

Obtain and analyze a dump from [Windows Error Reporting (WER)](/windows/desktop/wer/windows-error-reporting):

1. Create a folder to hold crash dump files at `c:\dumps`.
1. Run the [EnableDumps PowerShell script](https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/host-and-deploy/windows-service/samples/scripts/EnableDumps.ps1) with the application executable name:

   ```powershell
   .\EnableDumps {APPLICATION EXE} c:\dumps
   ```

1. Run the app under the conditions that cause the crash to occur.
1. After the crash has occurred, run the [DisableDumps PowerShell script](https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/host-and-deploy/windows-service/samples/scripts/DisableDumps.ps1):

   ```powershell
   .\DisableDumps {APPLICATION EXE}
   ```

After an app crashes and dump collection is complete, the app is allowed to terminate normally. The PowerShell script configures WER to collect up to five dumps per app.

> [!WARNING]
> Crash dumps might take up a large amount of disk space (up to several gigabytes each).

#### App is unresponsive, fails during startup, or runs normally

When an app *hangs* (stops responding but doesn't crash), fails during startup, or runs normally, see [User-Mode Dump Files: Choosing the Best Tool](/windows-hardware/drivers/debugger/user-mode-dump-files#choosing-the-best-tool) to select an appropriate tool to produce the dump.

#### Analyze the dump

A dump can be analyzed using several approaches. For more information, see [Analyzing a User-Mode Dump File](/windows-hardware/drivers/debugger/analyzing-a-user-mode-dump-file).

## Additional resources

* [Kestrel endpoint configuration](xref:fundamentals/servers/kestrel/endpoints) (includes HTTPS configuration and SNI support)
* <xref:fundamentals/host/generic-host>
* <xref:test/troubleshoot>

:::moniker-end

:::moniker range="= aspnetcore-5.0"

An ASP.NET Core app can be hosted on Windows as a [Windows Service](/dotnet/framework/windows-services/introduction-to-windows-service-applications) without using IIS. When hosted as a Windows Service, the app automatically starts after server reboots.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/host-and-deploy/windows-service/samples) ([how to download](xref:index#how-to-download-a-sample))

## Prerequisites

* [ASP.NET Core SDK 5.0](https://dotnet.microsoft.com/download)
* [PowerShell 6.2 or later](https://github.com/PowerShell/PowerShell)

## Worker Service template

The ASP.NET Core Worker Service template provides a starting point for writing long running service apps. To use the template as a basis for a Windows Service app:

1. Create a Worker Service app from the .NET Core template.
1. Follow the guidance in the [App configuration](#app-configuration) section to update the Worker Service app so that it can run as a Windows Service.

[!INCLUDE[](~/includes/worker-template-instructions.md)]

## App configuration

The app requires a package reference for [Microsoft.Extensions.Hosting.WindowsServices](https://www.nuget.org/packages/Microsoft.Extensions.Hosting.WindowsServices).

`IHostBuilder.UseWindowsService` is called when building the host. If the app is running as a Windows Service, the method:

* Sets the host lifetime to `WindowsServiceLifetime`.
* Sets the [content root](xref:fundamentals/index#content-root) to [AppContext.BaseDirectory](xref:System.AppContext.BaseDirectory). For more information, see the [Current directory and content root](#current-directory-and-content-root) section.
* Enables logging to the event log:
  * The application name is used as the default source name.
  * The default log level is *Warning* or higher for an app based on an ASP.NET Core template that calls `CreateDefaultBuilder` to build the host.
  * Override the default log level with the `Logging:EventLog:LogLevel:Default` key in `appsettings.json`/`appsettings.{Environment}.json` or other configuration provider.
  * Only administrators can create new event sources. When an event source can't be created using the application name, a warning is logged to the *Application* source and event logs are disabled.

In `CreateHostBuilder` of `Program.cs`:

```csharp
Host.CreateDefaultBuilder(args)
    .UseWindowsService()
    ...
```

The following sample apps accompany this topic:

* Background Worker Service Sample: A non-web app sample based on the [Worker Service template](#worker-service-template) that uses [hosted services](xref:fundamentals/host/hosted-services) for background tasks.
* Web App Service Sample: A Razor Pages web app sample that runs as a Windows Service with [hosted services](xref:fundamentals/host/hosted-services) for background tasks.

For MVC guidance, see the articles under <xref:mvc/overview> and <xref:migration/22-to-30>.

## Deployment type

For information and advice on deployment scenarios, see [.NET Core application deployment](/dotnet/core/deploying/).

### SDK

For a web app-based service that uses the Razor Pages or MVC frameworks, specify the Web SDK in the project file:

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">
```

If the service only executes background tasks (for example, [hosted services](xref:fundamentals/host/hosted-services)), specify the Worker SDK in the project file:

```xml
<Project Sdk="Microsoft.NET.Sdk.Worker">
```

### Framework-dependent deployment (FDD)

Framework-dependent deployment (FDD) relies on the presence of a shared system-wide version of .NET Core on the target system. When the FDD scenario is adopted following the guidance in this article, the SDK produces an executable (*.exe*), called a *framework-dependent executable*.

If using the [Web SDK](#sdk), a *web.config* file, which is normally produced when publishing an ASP.NET Core app, is unnecessary for a Windows Services app. To disable the creation of the *web.config* file, add the `<IsTransformWebConfigDisabled>` property set to `true`.

```xml
<PropertyGroup>
  <TargetFramework>netcoreapp3.0</TargetFramework>
  <IsTransformWebConfigDisabled>true</IsTransformWebConfigDisabled>
</PropertyGroup>
```

### Self-contained deployment (SCD)

Self-contained deployment (SCD) doesn't rely on the presence of a shared framework on the host system. The runtime and the app's dependencies are deployed with the app.

A Windows [Runtime Identifier (RID)](/dotnet/core/rid-catalog) is included in the `<PropertyGroup>` that contains the target framework:

```xml
<RuntimeIdentifier>win7-x64</RuntimeIdentifier>
```

To publish for multiple RIDs:

* Provide the RIDs in a semicolon-delimited list.
* Use the property name [\<RuntimeIdentifiers>](/dotnet/core/tools/csproj#runtimeidentifiers) (plural).

For more information, see [.NET Core RID Catalog](/dotnet/core/rid-catalog).

## Service user account

To create a user account for a service, use the [New-LocalUser](/powershell/module/microsoft.powershell.localaccounts/new-localuser) cmdlet from an administrative PowerShell 6 command shell.

On Windows 10 October 2018 Update (version 1809/build 10.0.17763) or later:

```powershell
New-LocalUser -Name {SERVICE NAME}
```

On Windows OS earlier than the Windows 10 October 2018 Update (version 1809/build 10.0.17763):

```console
powershell -Command "New-LocalUser -Name {SERVICE NAME}"
```

Provide a [strong password](/windows/security/threat-protection/security-policy-settings/password-must-meet-complexity-requirements) when prompted.

Unless the `-AccountExpires` parameter is supplied to the [New-LocalUser](/powershell/module/microsoft.powershell.localaccounts/new-localuser) cmdlet with an expiration <xref:System.DateTime>, the account doesn't expire.

For more information, see [Microsoft.PowerShell.LocalAccounts](/powershell/module/microsoft.powershell.localaccounts/) and [Service User Accounts](/windows/desktop/services/service-user-accounts).

An alternative approach to managing users when using Active Directory is to use Managed Service Accounts. For more information, see [Group Managed Service Accounts Overview](/windows-server/security/group-managed-service-accounts/group-managed-service-accounts-overview).

## Log on as a service rights

To establish *Log on as a service* rights for a service user account:

1. Open the Local Security Policy editor by running *secpol.msc*.
1. Expand the **Local Policies** node and select **User Rights Assignment**.
1. Open the **Log on as a service** policy.
1. Select **Add User or Group**.
1. Provide the object name (user account) using either of the following approaches:
   1. Type the user account (`{DOMAIN OR COMPUTER NAME\USER}`) in the object name field and select **OK** to add the user to the policy.
   1. Select **Advanced**. Select **Find Now**. Select the user account from the list. Select **OK**. Select **OK** again to add the user to the policy.
1. Select **OK** or **Apply** to accept the changes.

## Create and manage the Windows Service

### Create a service

Use PowerShell commands to register a service. From an administrative PowerShell 6 command shell, execute the following commands:

```powershell
$acl = Get-Acl "{EXE PATH}"
$aclRuleArgs = "{DOMAIN OR COMPUTER NAME\USER}", "Read,Write,ReadAndExecute", "ContainerInherit,ObjectInherit", "None", "Allow"
$accessRule = New-Object System.Security.AccessControl.FileSystemAccessRule($aclRuleArgs)
$acl.SetAccessRule($accessRule)
$acl | Set-Acl "{EXE PATH}"

New-Service -Name {SERVICE NAME} -BinaryPathName "{EXE FILE PATH}" -Credential "{DOMAIN OR COMPUTER NAME\USER}" -Description "{DESCRIPTION}" -DisplayName "{DISPLAY NAME}" -StartupType Automatic
```

* `{EXE PATH}`: Path of the app's executable on the host (for example, `d:\myservice`). Don't include the app's executable file name in the path. A trailing slash isn't required.
* `{DOMAIN OR COMPUTER NAME\USER}`: Service user account (for example, `Contoso\ServiceUser`).
* `{SERVICE NAME}`: Service name (for example, `MyService`).
* `{EXE FILE PATH}`: The app's full executable path (for example, `d:\myservice\myservice.exe`). Include the executable's file name with extension.
* `{DESCRIPTION}`: Service description (for example, `My sample service`).
* `{DISPLAY NAME}`: Service display name (for example, `My Service`).

### Start a service

Start a service with the following PowerShell 6 command:

```powershell
Start-Service -Name {SERVICE NAME}
```

The command takes a few seconds to start the service.

### Determine a service's status

To check the status of a service, use the following PowerShell 6 command:

```powershell
Get-Service -Name {SERVICE NAME}
```

The status is reported as one of the following values:

* `Starting`
* `Running`
* `Stopping`
* `Stopped`

### Stop a service

Stop a service with the following PowerShell 6 command:

```powershell
Stop-Service -Name {SERVICE NAME}
```

### Remove a service

After a short delay to stop a service, remove a service with the following PowerShell 6 command:

```powershell
Remove-Service -Name {SERVICE NAME}
```

## Proxy server and load balancer scenarios

Services that interact with requests from the Internet or a corporate network and are behind a proxy or load balancer might require additional configuration. For more information, see <xref:host-and-deploy/proxy-load-balancer>.

## Configure endpoints

By default, ASP.NET Core binds to `http://localhost:5000`. Configure the URL and port by setting the `ASPNETCORE_URLS` environment variable.

For additional URL and port configuration approaches, see the relevant server article:

* <xref:fundamentals/servers/kestrel/endpoints>
* <xref:fundamentals/servers/httpsys#configure-windows-server>

The preceding guidance covers support for HTTPS endpoints. For example, configure the app for HTTPS when authentication is used with a Windows Service.

> [!NOTE]
> Use of the ASP.NET Core HTTPS development certificate to secure a service endpoint isn't supported.

## Current directory and content root

The current working directory returned by calling <xref:System.IO.Directory.GetCurrentDirectory%2A> for a Windows Service is the *C:\\WINDOWS\\system32* folder. The *system32* folder isn't a suitable location to store a service's files (for example, settings files). Use one of the following approaches to maintain and access a service's assets and settings files.

### Use ContentRootPath or ContentRootFileProvider

Use [IHostEnvironment.ContentRootPath](xref:Microsoft.Extensions.Hosting.IHostEnvironment.ContentRootPath) or <xref:Microsoft.Extensions.Hosting.IHostEnvironment.ContentRootFileProvider> to locate an app's resources.

When the app runs as a service, <xref:Microsoft.Extensions.Hosting.WindowsServiceLifetimeHostBuilderExtensions.UseWindowsService%2A> sets the <xref:Microsoft.Extensions.Hosting.IHostEnvironment.ContentRootPath> to [AppContext.BaseDirectory](xref:System.AppContext.BaseDirectory).

The app's default settings files, `appsettings.json` and `appsettings.{Environment}.json`, are loaded from the app's content root by calling [CreateDefaultBuilder during host construction](xref:fundamentals/host/generic-host#set-up-a-host).

For other settings files loaded by developer code in <xref:Microsoft.Extensions.Hosting.HostBuilder.ConfigureAppConfiguration%2A>, there's no need to call <xref:Microsoft.Extensions.Configuration.FileConfigurationExtensions.SetBasePath%2A>. In the following example, the `custom_settings.json` file exists in the app's content root and is loaded without explicitly setting a base path:

:::code language="csharp" source="windows-service/samples_snapshot/CustomSettingsExample.cs" highlight="13":::

Don't attempt to use <xref:System.IO.Directory.GetCurrentDirectory%2A> to obtain a resource path because a Windows Service app returns the *C:\\WINDOWS\\system32* folder as its current directory.

### Store a service's files in a suitable location on disk

Specify an absolute path with <xref:Microsoft.Extensions.Configuration.FileConfigurationExtensions.SetBasePath%2A> when using an <xref:Microsoft.Extensions.Configuration.IConfigurationBuilder> to the folder containing the files.

## Troubleshoot

To troubleshoot a Windows Service app, see <xref:test/troubleshoot>.

### Common errors

* An old or pre-release version of PowerShell is in use.
* The registered service doesn't use the app's **published** output from the [dotnet publish](/dotnet/core/tools/dotnet-publish) command. Output of the [dotnet build](/dotnet/core/tools/dotnet-build) command isn't supported for app deployment. Published assets are found in either of the following folders depending on the deployment type:
  * *bin/Release/{TARGET FRAMEWORK}/publish* (FDD)
  * *bin/Release/{TARGET FRAMEWORK}/{RUNTIME IDENTIFIER}/publish* (SCD)
* The service isn't in the RUNNING state.
* The paths to resources that the app uses (for example, certificates) are incorrect. The base path of a Windows Service is *c:\\Windows\\System32*.
* The user doesn't have *Log on as a service* rights.
* The user's password is expired or incorrectly passed when executing the `New-Service` PowerShell command.
* The app requires ASP.NET Core authentication but isn't configured for secure connections (HTTPS).
* The request URL port is incorrect or not configured correctly in the app.

### System and Application Event Logs

Access the System and Application Event Logs:

1. Open the Start menu, search for *Event Viewer*, and select the **Event Viewer** app.
1. In **Event Viewer**, open the **Windows Logs** node.
1. Select **System** to open the System Event Log. Select **Application** to open the Application Event Log.
1. Search for errors associated with the failing app.

### Run the app at a command prompt

Many startup errors don't produce useful information in the event logs. You can find the cause of some errors by running the app at a command prompt on the hosting system. To log additional detail from the app, lower the [log level](xref:fundamentals/logging/index#log-level) or run the app in the [Development environment](xref:fundamentals/environments).

### Clear package caches

A functioning app may fail immediately after upgrading either the .NET Core SDK on the development machine or changing package versions within the app. In some cases, incoherent packages may break an app when performing major upgrades. Most of these issues can be fixed by following these instructions:

1. Delete the *bin* and *obj* folders.
1. Clear the package caches by executing [dotnet nuget locals all --clear](/dotnet/core/tools/dotnet-nuget-locals) from a command shell.

   Clearing package caches can also be accomplished with the [nuget.exe](https://www.nuget.org/downloads) tool and executing the command `nuget locals all -clear`. *nuget.exe* isn't a bundled install with the Windows desktop operating system and must be obtained separately from the [NuGet website](https://www.nuget.org/downloads).

1. Restore and rebuild the project.
1. Delete all of the files in the deployment folder on the server prior to redeploying the app.

### Slow or unresponsive app

A *crash dump* is a snapshot of the system's memory and can help determine the cause of an app crash, startup failure, or slow app.

#### App crashes or encounters an exception

Obtain and analyze a dump from [Windows Error Reporting (WER)](/windows/desktop/wer/windows-error-reporting):

1. Create a folder to hold crash dump files at `c:\dumps`.
1. Run the [EnableDumps PowerShell script](https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/host-and-deploy/windows-service/samples/scripts/EnableDumps.ps1) with the application executable name:

   ```powershell
   .\EnableDumps {APPLICATION EXE} c:\dumps
   ```

1. Run the app under the conditions that cause the crash to occur.
1. After the crash has occurred, run the [DisableDumps PowerShell script](https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/host-and-deploy/windows-service/samples/scripts/DisableDumps.ps1):

   ```powershell
   .\DisableDumps {APPLICATION EXE}
   ```

After an app crashes and dump collection is complete, the app is allowed to terminate normally. The PowerShell script configures WER to collect up to five dumps per app.

> [!WARNING]
> Crash dumps might take up a large amount of disk space (up to several gigabytes each).

#### App is unresponsive, fails during startup, or runs normally

When an app *hangs* (stops responding but doesn't crash), fails during startup, or runs normally, see [User-Mode Dump Files: Choosing the Best Tool](/windows-hardware/drivers/debugger/user-mode-dump-files#choosing-the-best-tool) to select an appropriate tool to produce the dump.

#### Analyze the dump

A dump can be analyzed using several approaches. For more information, see [Analyzing a User-Mode Dump File](/windows-hardware/drivers/debugger/analyzing-a-user-mode-dump-file).

## Additional resources

* [Kestrel endpoint configuration](xref:fundamentals/servers/kestrel/endpoints) (includes HTTPS configuration and SNI support)
* <xref:fundamentals/host/generic-host>
* <xref:test/troubleshoot>

:::moniker-end

:::moniker range="< aspnetcore-5.0"

An ASP.NET Core app can be hosted on Windows as a [Windows Service](/dotnet/framework/windows-services/introduction-to-windows-service-applications) without using IIS. When hosted as a Windows Service, the app automatically starts after server reboots.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/host-and-deploy/windows-service/samples) ([how to download](xref:index#how-to-download-a-sample))

## Prerequisites

* [ASP.NET Core SDK 2.1 or later](https://dotnet.microsoft.com/download)
* [PowerShell 6.2 or later](https://github.com/PowerShell/PowerShell)

## Worker Service template

The ASP.NET Core Worker Service template provides a starting point for writing long running service apps. To use the template as a basis for a Windows Service app:

1. Create a Worker Service app from the .NET Core template.
1. Follow the guidance in the [App configuration](#app-configuration) section to update the Worker Service app so that it can run as a Windows Service.

[!INCLUDE[](~/includes/worker-template-instructions.md)]

## App configuration

The app requires a package reference for [Microsoft.Extensions.Hosting.WindowsServices](https://www.nuget.org/packages/Microsoft.Extensions.Hosting.WindowsServices).

`IHostBuilder.UseWindowsService` is called when building the host. If the app is running as a Windows Service, the method:

* Sets the host lifetime to `WindowsServiceLifetime`.
* Sets the [content root](xref:fundamentals/index#content-root) to [AppContext.BaseDirectory](xref:System.AppContext.BaseDirectory). For more information, see the [Current directory and content root](#current-directory-and-content-root) section.
* Enables logging to the event log:
  * The application name is used as the default source name.
  * The default log level is *Warning* or higher for an app based on an ASP.NET Core template that calls `CreateDefaultBuilder` to build the host.
  * Override the default log level with the `Logging:EventLog:LogLevel:Default` key in `appsettings.json`/`appsettings.{Environment}.json` or other configuration provider.
  * Only administrators can create new event sources. When an event source can't be created using the application name, a warning is logged to the *Application* source and event logs are disabled.

In `CreateHostBuilder` of `Program.cs`:

```csharp
Host.CreateDefaultBuilder(args)
    .UseWindowsService()
    ...
```

The following sample apps accompany this topic:

* Background Worker Service Sample: A non-web app sample based on the [Worker Service template](#worker-service-template) that uses [hosted services](xref:fundamentals/host/hosted-services) for background tasks.
* Web App Service Sample: A Razor Pages web app sample that runs as a Windows Service with [hosted services](xref:fundamentals/host/hosted-services) for background tasks.

For MVC guidance, see the articles under <xref:mvc/overview> and <xref:migration/22-to-30>.

## Deployment type

For information and advice on deployment scenarios, see [.NET Core application deployment](/dotnet/core/deploying/).

### SDK

For a web app-based service that uses the Razor Pages or MVC frameworks, specify the Web SDK in the project file:

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">
```

If the service only executes background tasks (for example, [hosted services](xref:fundamentals/host/hosted-services)), specify the Worker SDK in the project file:

```xml
<Project Sdk="Microsoft.NET.Sdk.Worker">
```

### Framework-dependent deployment (FDD)

Framework-dependent deployment (FDD) relies on the presence of a shared system-wide version of .NET Core on the target system. When the FDD scenario is adopted following the guidance in this article, the SDK produces an executable (*.exe*), called a *framework-dependent executable*.

If using the [Web SDK](#sdk), a *web.config* file, which is normally produced when publishing an ASP.NET Core app, is unnecessary for a Windows Services app. To disable the creation of the *web.config* file, add the `<IsTransformWebConfigDisabled>` property set to `true`.

```xml
<PropertyGroup>
  <TargetFramework>netcoreapp3.0</TargetFramework>
  <IsTransformWebConfigDisabled>true</IsTransformWebConfigDisabled>
</PropertyGroup>
```

### Self-contained deployment (SCD)

Self-contained deployment (SCD) doesn't rely on the presence of a shared framework on the host system. The runtime and the app's dependencies are deployed with the app.

A Windows [Runtime Identifier (RID)](/dotnet/core/rid-catalog) is included in the `<PropertyGroup>` that contains the target framework:

```xml
<RuntimeIdentifier>win7-x64</RuntimeIdentifier>
```

To publish for multiple RIDs:

* Provide the RIDs in a semicolon-delimited list.
* Use the property name [\<RuntimeIdentifiers>](/dotnet/core/tools/csproj#runtimeidentifiers) (plural).

For more information, see [.NET Core RID Catalog](/dotnet/core/rid-catalog).

## Service user account

To create a user account for a service, use the [New-LocalUser](/powershell/module/microsoft.powershell.localaccounts/new-localuser) cmdlet from an administrative PowerShell 6 command shell.

On Windows 10 October 2018 Update (version 1809/build 10.0.17763) or later:

```powershell
New-LocalUser -Name {SERVICE NAME}
```

On Windows OS earlier than the Windows 10 October 2018 Update (version 1809/build 10.0.17763):

```console
powershell -Command "New-LocalUser -Name {SERVICE NAME}"
```

Provide a [strong password](/windows/security/threat-protection/security-policy-settings/password-must-meet-complexity-requirements) when prompted.

Unless the `-AccountExpires` parameter is supplied to the [New-LocalUser](/powershell/module/microsoft.powershell.localaccounts/new-localuser) cmdlet with an expiration <xref:System.DateTime>, the account doesn't expire.

For more information, see [Microsoft.PowerShell.LocalAccounts](/powershell/module/microsoft.powershell.localaccounts/) and [Service User Accounts](/windows/desktop/services/service-user-accounts).

An alternative approach to managing users when using Active Directory is to use Managed Service Accounts. For more information, see [Group Managed Service Accounts Overview](/windows-server/security/group-managed-service-accounts/group-managed-service-accounts-overview).

## Log on as a service rights

To establish *Log on as a service* rights for a service user account:

1. Open the Local Security Policy editor by running *secpol.msc*.
1. Expand the **Local Policies** node and select **User Rights Assignment**.
1. Open the **Log on as a service** policy.
1. Select **Add User or Group**.
1. Provide the object name (user account) using either of the following approaches:
   1. Type the user account (`{DOMAIN OR COMPUTER NAME\USER}`) in the object name field and select **OK** to add the user to the policy.
   1. Select **Advanced**. Select **Find Now**. Select the user account from the list. Select **OK**. Select **OK** again to add the user to the policy.
1. Select **OK** or **Apply** to accept the changes.

## Create and manage the Windows Service

### Create a service

Use PowerShell commands to register a service. From an administrative PowerShell 6 command shell, execute the following commands:

```powershell
$acl = Get-Acl "{EXE PATH}"
$aclRuleArgs = "{DOMAIN OR COMPUTER NAME\USER}", "Read,Write,ReadAndExecute", "ContainerInherit,ObjectInherit", "None", "Allow"
$accessRule = New-Object System.Security.AccessControl.FileSystemAccessRule($aclRuleArgs)
$acl.SetAccessRule($accessRule)
$acl | Set-Acl "{EXE PATH}"

New-Service -Name {SERVICE NAME} -BinaryPathName "{EXE FILE PATH}" -Credential "{DOMAIN OR COMPUTER NAME\USER}" -Description "{DESCRIPTION}" -DisplayName "{DISPLAY NAME}" -StartupType Automatic
```

* `{EXE PATH}`: Path of the app's executable on the host (for example, `d:\myservice`). Don't include the app's executable file name in the path. A trailing slash isn't required.
* `{DOMAIN OR COMPUTER NAME\USER}`: Service user account (for example, `Contoso\ServiceUser`).
* `{SERVICE NAME}`: Service name (for example, `MyService`).
* `{EXE FILE PATH}`: The app's full executable path (for example, `d:\myservice\myservice.exe`). Include the executable's file name with extension.
* `{DESCRIPTION}`: Service description (for example, `My sample service`).
* `{DISPLAY NAME}`: Service display name (for example, `My Service`).

### Start a service

Start a service with the following PowerShell 6 command:

```powershell
Start-Service -Name {SERVICE NAME}
```

The command takes a few seconds to start the service.

### Determine a service's status

To check the status of a service, use the following PowerShell 6 command:

```powershell
Get-Service -Name {SERVICE NAME}
```

The status is reported as one of the following values:

* `Starting`
* `Running`
* `Stopping`
* `Stopped`

### Stop a service

Stop a service with the following PowerShell 6 command:

```powershell
Stop-Service -Name {SERVICE NAME}
```

### Remove a service

After a short delay to stop a service, remove a service with the following PowerShell 6 command:

```powershell
Remove-Service -Name {SERVICE NAME}
```

## Proxy server and load balancer scenarios

Services that interact with requests from the Internet or a corporate network and are behind a proxy or load balancer might require additional configuration. For more information, see <xref:host-and-deploy/proxy-load-balancer>.

## Configure endpoints

By default, ASP.NET Core binds to `http://localhost:5000`. Configure the URL and port by setting the `ASPNETCORE_URLS` environment variable.

For additional URL and port configuration approaches, see the relevant server article:

* <xref:fundamentals/servers/kestrel#endpoint-configuration>
* <xref:fundamentals/servers/httpsys#configure-windows-server>

The preceding guidance covers support for HTTPS endpoints. For example, configure the app for HTTPS when authentication is used with a Windows Service.

> [!NOTE]
> Use of the ASP.NET Core HTTPS development certificate to secure a service endpoint isn't supported.

## Current directory and content root

The current working directory returned by calling <xref:System.IO.Directory.GetCurrentDirectory%2A> for a Windows Service is the *C:\\WINDOWS\\system32* folder. The *system32* folder isn't a suitable location to store a service's files (for example, settings files). Use one of the following approaches to maintain and access a service's assets and settings files.

### Use ContentRootPath or ContentRootFileProvider

Use [IHostEnvironment.ContentRootPath](xref:Microsoft.Extensions.Hosting.IHostEnvironment.ContentRootPath) or <xref:Microsoft.Extensions.Hosting.IHostEnvironment.ContentRootFileProvider> to locate an app's resources.

When the app runs as a service, <xref:Microsoft.Extensions.Hosting.WindowsServiceLifetimeHostBuilderExtensions.UseWindowsService%2A> sets the <xref:Microsoft.Extensions.Hosting.IHostEnvironment.ContentRootPath> to [AppContext.BaseDirectory](xref:System.AppContext.BaseDirectory).

The app's default settings files, `appsettings.json` and `appsettings.{Environment}.json`, are loaded from the app's content root by calling [CreateDefaultBuilder during host construction](xref:fundamentals/host/generic-host#set-up-a-host).

For other settings files loaded by developer code in <xref:Microsoft.Extensions.Hosting.HostBuilder.ConfigureAppConfiguration%2A>, there's no need to call <xref:Microsoft.Extensions.Configuration.FileConfigurationExtensions.SetBasePath%2A>. In the following example, the `custom_settings.json` file exists in the app's content root and is loaded without explicitly setting a base path:

:::code language="csharp" source="windows-service/samples_snapshot/CustomSettingsExample.cs" highlight="13":::

Don't attempt to use <xref:System.IO.Directory.GetCurrentDirectory%2A> to obtain a resource path because a Windows Service app returns the *C:\\WINDOWS\\system32* folder as its current directory.

### Store a service's files in a suitable location on disk

Specify an absolute path with <xref:Microsoft.Extensions.Configuration.FileConfigurationExtensions.SetBasePath%2A> when using an <xref:Microsoft.Extensions.Configuration.IConfigurationBuilder> to the folder containing the files.

## Troubleshoot

To troubleshoot a Windows Service app, see <xref:test/troubleshoot>.

### Common errors

* An old or pre-release version of PowerShell is in use.
* The registered service doesn't use the app's **published** output from the [dotnet publish](/dotnet/core/tools/dotnet-publish) command. Output of the [dotnet build](/dotnet/core/tools/dotnet-build) command isn't supported for app deployment. Published assets are found in either of the following folders depending on the deployment type:
  * *bin/Release/{TARGET FRAMEWORK}/publish* (FDD)
  * *bin/Release/{TARGET FRAMEWORK}/{RUNTIME IDENTIFIER}/publish* (SCD)
* The service isn't in the RUNNING state.
* The paths to resources that the app uses (for example, certificates) are incorrect. The base path of a Windows Service is *c:\\Windows\\System32*.
* The user doesn't have *Log on as a service* rights.
* The user's password is expired or incorrectly passed when executing the `New-Service` PowerShell command.
* The app requires ASP.NET Core authentication but isn't configured for secure connections (HTTPS).
* The request URL port is incorrect or not configured correctly in the app.

### System and Application Event Logs

Access the System and Application Event Logs:

1. Open the Start menu, search for *Event Viewer*, and select the **Event Viewer** app.
1. In **Event Viewer**, open the **Windows Logs** node.
1. Select **System** to open the System Event Log. Select **Application** to open the Application Event Log.
1. Search for errors associated with the failing app.

### Run the app at a command prompt

Many startup errors don't produce useful information in the event logs. You can find the cause of some errors by running the app at a command prompt on the hosting system. To log additional detail from the app, lower the [log level](xref:fundamentals/logging/index#log-level) or run the app in the [Development environment](xref:fundamentals/environments).

### Clear package caches

A functioning app may fail immediately after upgrading either the .NET Core SDK on the development machine or changing package versions within the app. In some cases, incoherent packages may break an app when performing major upgrades. Most of these issues can be fixed by following these instructions:

1. Delete the *bin* and *obj* folders.
1. Clear the package caches by executing [dotnet nuget locals all --clear](/dotnet/core/tools/dotnet-nuget-locals) from a command shell.

   Clearing package caches can also be accomplished with the [nuget.exe](https://www.nuget.org/downloads) tool and executing the command `nuget locals all -clear`. *nuget.exe* isn't a bundled install with the Windows desktop operating system and must be obtained separately from the [NuGet website](https://www.nuget.org/downloads).

1. Restore and rebuild the project.
1. Delete all of the files in the deployment folder on the server prior to redeploying the app.

### Slow or unresponsive app

A *crash dump* is a snapshot of the system's memory and can help determine the cause of an app crash, startup failure, or slow app.

#### App crashes or encounters an exception

Obtain and analyze a dump from [Windows Error Reporting (WER)](/windows/desktop/wer/windows-error-reporting):

1. Create a folder to hold crash dump files at `c:\dumps`.
1. Run the [EnableDumps PowerShell script](https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/host-and-deploy/windows-service/samples/scripts/EnableDumps.ps1) with the application executable name:

   ```powershell
   .\EnableDumps {APPLICATION EXE} c:\dumps
   ```

1. Run the app under the conditions that cause the crash to occur.
1. After the crash has occurred, run the [DisableDumps PowerShell script](https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/host-and-deploy/windows-service/samples/scripts/DisableDumps.ps1):

   ```powershell
   .\DisableDumps {APPLICATION EXE}
   ```

After an app crashes and dump collection is complete, the app is allowed to terminate normally. The PowerShell script configures WER to collect up to five dumps per app.

> [!WARNING]
> Crash dumps might take up a large amount of disk space (up to several gigabytes each).

#### App is unresponsive, fails during startup, or runs normally

When an app *hangs* (stops responding but doesn't crash), fails during startup, or runs normally, see [User-Mode Dump Files: Choosing the Best Tool](/windows-hardware/drivers/debugger/user-mode-dump-files#choosing-the-best-tool) to select an appropriate tool to produce the dump.

#### Analyze the dump

A dump can be analyzed using several approaches. For more information, see [Analyzing a User-Mode Dump File](/windows-hardware/drivers/debugger/analyzing-a-user-mode-dump-file).

## Additional resources

* [Kestrel endpoint configuration](xref:fundamentals/servers/kestrel#endpoint-configuration) (includes HTTPS configuration and SNI support)
* <xref:fundamentals/host/generic-host>
* <xref:test/troubleshoot>

:::moniker-end
