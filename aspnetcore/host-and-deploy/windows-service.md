---
title: Host ASP.NET Core in a Windows Service
author: guardrex
description: Learn how to host an ASP.NET Core app in a Windows Service.
monikerRange: '>= aspnetcore-2.1'
ms.author: tdykstra
ms.custom: mvc
ms.date: 05/17/2019
uid: host-and-deploy/windows-service
---
# Host ASP.NET Core in a Windows Service

By [Luke Latham](https://github.com/guardrex) and [Tom Dykstra](https://github.com/tdykstra)

An ASP.NET Core app can be hosted on Windows as a [Windows Service](/dotnet/framework/windows-services/introduction-to-windows-service-applications) without using IIS. When hosted as a Windows Service, the app automatically starts after server reboots.

[View or download sample code](https://github.com/aspnet/AspNetCore.Docs/tree/master/aspnetcore/host-and-deploy/windows-service/) ([how to download](xref:index#how-to-download-a-sample))

## Prerequisites

* [ASP.NET Core SDK 2.1 or later](https://dotnet.microsoft.com/download)
* [PowerShell 6.2 or later](https://github.com/PowerShell/PowerShell)

## Deployment type

Create either a framework-dependent or self-contained Windows Service deployment. For information and advice on deployment scenarios, see [.NET Core application deployment](/dotnet/core/deploying/).

### Framework-dependent deployment (FDD)

Framework-dependent deployment (FDD) relies on the presence of a shared system-wide version of .NET Core on the target system. When the FDD scenario is adopted following the guidance in this article, the SDK produces an executable (*.exe*), called a *framework-dependent executable*.

### Self-contained deployment (SCD)

Self-contained deployment (SCD) doesn't rely on the presence of a shared framework on the host system. The runtime and the app's dependencies are deployed with the app.

## Convert a project into a Windows Service

Make the following changes to an existing ASP.NET Core project to run the app as a service:

### Project file updates

Based on your choice of [deployment type](#deployment-type), update the project file according to the following guidance.

#### Package dependencies

::: moniker range=">= aspnetcore-3.0"

Add a package reference for [Microsoft.Extensions.Hosting.WindowsServices](https://www.nuget.org/packages/Microsoft.Extensions.Hosting.WindowsServices).

::: moniker-end

::: moniker range="< aspnetcore-3.0"

Add a package reference for [Microsoft.AspNetCore.Hosting.WindowsServices](https://www.nuget.org/packages/Microsoft.AspNetCore.Hosting.WindowsServices). To enable Windows Event Log logging, add a package reference for [Microsoft.Extensions.Logging.EventLog](https://www.nuget.org/packages/Microsoft.Extensions.Logging.EventLog).

::: moniker-end

#### Framework-dependent Deployment

::: moniker range=">= aspnetcore-3.0"

To create an FDD, add the following property elements to the project file:

* `<OutputType>` &ndash; The app's output type (`Exe` for executable).
* `<LangVersion>` &ndash; The C# language version (`latest` or `preview`).

A *web.config* file, which is normally produced when publishing an ASP.NET Core app, is unnecessary for a Windows Services app. To disable the creation of the *web.config* file, add the `<IsTransformWebConfigDisabled>` property set to `true`.

```xml
<PropertyGroup>
  <TargetFramework>netcoreapp3.0</TargetFramework>
  <OutputType>Exe</OutputType>
  <LangVersion>preview</LangVersion>
  <IsTransformWebConfigDisabled>true</IsTransformWebConfigDisabled>
</PropertyGroup>
```

::: moniker-end

::: moniker range="= aspnetcore-2.2"

Add a Windows [Runtime Identifier (RID)](/dotnet/core/rid-catalog) ([\<RuntimeIdentifier>](/dotnet/core/tools/csproj#runtimeidentifier)) to the `<PropertyGroup>` that contains the target framework. In the following example, the RID is set to `win7-x64`. Add the `<SelfContained>` property set to `false`. These properties instruct the SDK to generate an executable (*.exe*) file for Windows and an app that depends on the shared .NET Core framework.

A *web.config* file, which is normally produced when publishing an ASP.NET Core app, is unnecessary for a Windows Services app. To disable the creation of the *web.config* file, add the `<IsTransformWebConfigDisabled>` property set to `true`.

```xml
<PropertyGroup>
  <TargetFramework>netcoreapp2.2</TargetFramework>
  <RuntimeIdentifier>win7-x64</RuntimeIdentifier>
  <SelfContained>false</SelfContained>
  <IsTransformWebConfigDisabled>true</IsTransformWebConfigDisabled>
</PropertyGroup>
```

::: moniker-end

::: moniker range="= aspnetcore-2.1"

Add a Windows [Runtime Identifier (RID)](/dotnet/core/rid-catalog) ([\<RuntimeIdentifier>](/dotnet/core/tools/csproj#runtimeidentifier)) to the `<PropertyGroup>` that contains the target framework. In the following example, the RID is set to `win7-x64`. Add the `<SelfContained>` property set to `false`. These properties instruct the SDK to generate an executable (*.exe*) file for Windows and an app that depends on the shared .NET Core framework.

A *web.config* file, which is normally produced when publishing an ASP.NET Core app, is unnecessary for a Windows Services app. To disable the creation of the *web.config* file, add the `<IsTransformWebConfigDisabled>` property set to `true`.

Add the `<UseAppHost>` property set to `true`. This property provides the service with an activation path (an executable, *.exe*) for an FDD.

```xml
<PropertyGroup>
  <TargetFramework>netcoreapp2.1</TargetFramework>
  <RuntimeIdentifier>win7-x64</RuntimeIdentifier>
  <UseAppHost>true</UseAppHost>
  <SelfContained>false</SelfContained>
  <IsTransformWebConfigDisabled>true</IsTransformWebConfigDisabled>
</PropertyGroup>
```

::: moniker-end

#### Self-contained Deployment

To create an SCD, follow the guidance in the [Framework-dependent Deployment](#framework-dependent-deployment) section.

Confirm the presence of (or add) a Windows [Runtime Identifier (RID)](/dotnet/core/rid-catalog) to the `<PropertyGroup>` that contains the target framework.

```xml
<RuntimeIdentifier>win7-x64</RuntimeIdentifier>
```

To publish for multiple RIDs:

* Provide the RIDs in a semicolon-delimited list.
* Use the property name [\<RuntimeIdentifiers>](/dotnet/core/tools/csproj#runtimeidentifiers) (plural).

For more information, see [.NET Core RID Catalog](/dotnet/core/rid-catalog).

::: moniker range="< aspnetcore-3.0"

Set the `<SelfContained>` property to `true`:

```xml
<SelfContained>true</SelfContained>
```

::: moniker-end

### Program.cs updates

Make the following changes in `Program.Main`:

::: moniker range=">= aspnetcore-3.0"

`IHostBuilder.UseWindowsService` is called when building the host. If the app is running as a Windows Service, the method:

* Sets the host lifetime to `WindowsServiceLifetime`.
* Sets the content root.
* Enables logging to the event log with the application name as the default source name. Set the logging level with the `Logging:LogLevel:Default` key in the *appsettings.Production.json* file. Only administrators can create new event sources. When an event source can't be created using the application name, a warning is logged to the *Application* source and event logs are disabled.

[IHost.RunAsync](xref:Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.RunAsync*) runs the app.

[!code-csharp[](windows-service/samples/3.x/AspNetCoreService/Program.cs?name=snippet_Program)]

::: moniker-end

::: moniker range="< aspnetcore-3.0"

* To test and debug when running outside of a service, add code to determine if the app is running as a service or a console app. Inspect if the debugger is attached or a `--console` switch is present.

  If either condition is true (the app isn't run as a service), call <xref:Microsoft.AspNetCore.Hosting.WebHostExtensions.Run*>.

  If the conditions are false (the app is run as a service):

  * Call <xref:System.IO.Directory.SetCurrentDirectory*> and use a path to the app's published location. Don't call <xref:System.IO.Directory.GetCurrentDirectory*> to obtain the path because a Windows Service app returns the *C:\\WINDOWS\\system32* folder when <xref:System.IO.Directory.GetCurrentDirectory*> is called. For more information, see the [Current directory and content root](#current-directory-and-content-root) section. This step is performed before the app is configured in `CreateWebHostBuilder`.
  * Call <xref:Microsoft.AspNetCore.Hosting.WindowsServices.WebHostWindowsServiceExtensions.RunAsService*> to run the app as a service.

  Because the [Command-line Configuration Provider](xref:fundamentals/configuration/index#command-line-configuration-provider) requires name-value pairs for command-line arguments, the `--console` switch is removed from the arguments before <xref:Microsoft.AspNetCore.WebHost.CreateDefaultBuilder*> receives the arguments.

* To write to the Windows Event Log, add the EventLog provider to <xref:Microsoft.AspNetCore.Hosting.WebHostBuilder.ConfigureLogging*>. Set the logging level with the `Logging:LogLevel:Default` key in the *appsettings.Production.json* file.

[!code-csharp[](windows-service/samples/2.x/AspNetCoreService/Program.cs?name=snippet_Program)]

::: moniker-end

## Publish the app

Publish the app using [dotnet publish](/dotnet/articles/core/tools/dotnet-publish), a [Visual Studio publish profile](xref:host-and-deploy/visual-studio-publish-profiles), or Visual Studio Code. When using Visual Studio, select the **FolderProfile** and configure the **Target Location** before selecting the **Publish** button.

Use the [-o|--output](/dotnet/core/tools/dotnet-publish#options) option with a path to publish to a folder (the folder is created if it doesn't exist when the command is executed).

### Publish a Framework-dependent Deployment (FDD)

In the following example, the app is published to the *c:\\svc* folder:

```console
dotnet publish --configuration Release --output c:\svc
```

### Publish a Self-contained Deployment (SCD)

The RID must be specified in the [\<RuntimeIdentifier>](/dotnet/core/tools/csproj#runtimeidentifier) (or [\<RuntimeIdentifiers>](/dotnet/core/tools/csproj#runtimeidentifiers)) property of the project file. Supply the runtime to the [-r|--runtime](/dotnet/core/tools/dotnet-publish#options) option of the `dotnet publish` command.

In the following example, the app is published for the `win7-x64` runtime to the *c:\\svc* folder:

```console
dotnet publish --configuration Release --runtime win7-x64 --output c:\svc
```

## Create a user account

Create a user account for the service using the [New-LocalUser](/powershell/module/microsoft.powershell.localaccounts/new-localuser) cmdlet from an administrative PowerShell 6 command shell.

On Windows 10 October 2018 Update (version 1809/build 10.0.17763) or later:

```PowerShell
New-LocalUser -Name {NAME}
```

On Windows OS earlier than the Windows 10 October 2018 Update (version 1809/build 10.0.17763):

```console
powershell -Command "New-LocalUser -Name {NAME}"
```

Provide a [strong password](/windows/security/threat-protection/security-policy-settings/password-must-meet-complexity-requirements) when prompted.

Unless the `-AccountExpires` parameter is supplied to the [New-LocalUser](/powershell/module/microsoft.powershell.localaccounts/new-localuser) cmdlet with an expiration <xref:System.DateTime>, the account doesn't expire.

For more information, see [Microsoft.PowerShell.LocalAccounts](/powershell/module/microsoft.powershell.localaccounts/) and [Service User Accounts](/windows/desktop/services/service-user-accounts).

An alternative approach to managing users when using Active Directory is to use Managed Service Accounts. For more information, see [Group Managed Service Accounts Overview](/windows-server/security/group-managed-service-accounts/group-managed-service-accounts-overview).

## Provide Log on as a service rights

1. Open the Local Security Policy editor by running *secpool.msc*.
1. Expand the **Local Policies** node and select **User Rights Assignment**.
1. Open the **Log on as a service** policy.
1. Select **Add User or Group**.
1. Provide the object name (user account) using either of the following approaches:
   1. Type the user account (`{DOMAIN OR COMPUTER NAME\USER}`) in the object name field and select **OK** to add the user to the policy.
   1. Select **Advanced**. Select **Find Now**. Select the user account from the list. Select **OK**. Select **OK** again to add the user to the policy.
1. Select **OK** or **Apply** to accept the changes.

## Create the service

Use PowerShell commands to register the service. From an administrative PowerShell 6 command shell, execute the following commands:

```powershell
$acl = Get-Acl "{EXE PATH}"
$aclRuleArgs = {DOMAIN OR COMPUTER NAME\USER}, "Read,Write,ReadAndExecute", "ContainerInherit,ObjectInherit", "None", "Allow"
$accessRule = New-Object System.Security.AccessControl.FileSystemAccessRule($aclRuleArgs)
$acl.SetAccessRule($accessRule)
$acl | Set-Acl "{EXE PATH}"

New-Service -Name {NAME} -BinaryPathName {EXE FILE PATH} -Credential {DOMAIN OR COMPUTER NAME\USER} -Description "{DESCRIPTION}" -DisplayName "{DISPLAY NAME}" -StartupType Automatic
```

* `{EXE PATH}` &ndash; Path to the app's folder on the host. Don't include the app's executable in the path. A trailing slash isn't required
* `{DOMAIN OR COMPUTER NAME\USER}` &ndash; The service user account.
* `{NAME}` &ndash; Name of the service.
* `{EXE FILE PATH}` &ndash; The app's executable path. Include the executable's file name with extension.
* `{DESCRIPTION}` &ndash; Description of the service.
* `{DISPLAY NAME}` &ndash; Service display name.

## Manage the service

### Start the service

Start the service with the following PowerShell 6 command:

```powershell
Start-Service -Name {NAME}
```

The command takes a few seconds to start the service.

### Determine the service status

To check the status of the service, use the following PowerShell 6 command:

```powershell
Get-Service -Name {NAME}
```

The status is reported as one of the following values:

* `Starting`
* `Running`
* `Stopping`
* `Stopped`

### Stop the service

Stop the service with the following Powershell 6 command:

```powershell
Stop-Service -Name {NAME}
```

### Remove the service

After a short delay to stop a service, remove the service with the following Powershell 6 command:

```powershell
Remove-Service -Name {NAME}
```

::: moniker range="< aspnetcore-3.0"

## Handle starting and stopping events

To handle <xref:Microsoft.AspNetCore.Hosting.WindowsServices.WebHostService.OnStarting*>, <xref:Microsoft.AspNetCore.Hosting.WindowsServices.WebHostService.OnStarted*>, and <xref:Microsoft.AspNetCore.Hosting.WindowsServices.WebHostService.OnStopping*> events, perform the following additional changes:

1. Create a class that derives from <xref:Microsoft.AspNetCore.Hosting.WindowsServices.WebHostService> with the `OnStarting`, `OnStarted`, and `OnStopping` methods:

   [!code-csharp[](windows-service/samples/2.x/AspNetCoreService/CustomWebHostService.cs?name=snippet_CustomWebHostService)]

2. Create an extension method for <xref:Microsoft.AspNetCore.Hosting.IWebHost> that passes the `CustomWebHostService` to <xref:System.ServiceProcess.ServiceBase.Run*>:

   [!code-csharp[](windows-service/samples/2.x/AspNetCoreService/WebHostServiceExtensions.cs?name=ExtensionsClass)]

3. In `Program.Main`, call the `RunAsCustomService` extension method instead of <xref:Microsoft.AspNetCore.Hosting.WindowsServices.WebHostWindowsServiceExtensions.RunAsService*>:

   ```csharp
   host.RunAsCustomService();
   ```

   To see the location of <xref:Microsoft.AspNetCore.Hosting.WindowsServices.WebHostWindowsServiceExtensions.RunAsService*> in `Program.Main`, refer to the code sample shown in the [Convert a project into a Windows Service](#convert-a-project-into-a-windows-service) section.

::: moniker-end

## Proxy server and load balancer scenarios

Services that interact with requests from the Internet or a corporate network and are behind a proxy or load balancer might require additional configuration. For more information, see <xref:host-and-deploy/proxy-load-balancer>.

## Configure HTTPS

To configure the service with a secure endpoint:

1. Create an X.509 certificate for the hosting system using your platform's certificate acquisition and deployment mechanisms.

1. Specify a [Kestrel server HTTPS endpoint configuration](xref:fundamentals/servers/kestrel#endpoint-configuration) to use the certificate.

Use of the ASP.NET Core HTTPS development certificate to secure a service endpoint isn't supported.

## Current directory and content root

The current working directory returned by calling <xref:System.IO.Directory.GetCurrentDirectory*> for a Windows Service is the *C:\\WINDOWS\\system32* folder. The *system32* folder isn't a suitable location to store a service's files (for example, settings files). Use one of the following approaches to maintain and access a service's assets and settings files.

::: moniker range=">= aspnetcore-3.0"

### Use ContentRootPath or ContentRootFileProvider

Use [IHostEnvironment.ContentRootPath](xref:xref:Microsoft.Extensions.Hosting.IHostEnvironment.ContentRootPath) or <xref:Microsoft.Extensions.Hosting.IHostEnvironment.ContentRootFileProvider> to locate the app's resources.

::: moniker-end

::: moniker range="< aspnetcore-3.0"

### Set the content root path to the app's folder

The <xref:Microsoft.Extensions.Hosting.IHostingEnvironment.ContentRootPath*> is the same path provided to the `binPath` argument when the service is created. Instead of calling `GetCurrentDirectory` to create paths to settings files, call <xref:System.IO.Directory.SetCurrentDirectory*> with the path to the app's content root.

In `Program.Main`, determine the path to the folder of the service's executable and use the path to establish the app's content root:

```csharp
var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
var pathToContentRoot = Path.GetDirectoryName(pathToExe);
Directory.SetCurrentDirectory(pathToContentRoot);

CreateWebHostBuilder(args)
    .Build()
    .RunAsService();
```

::: moniker-end

### Store the service's files in a suitable location on disk

Specify an absolute path with <xref:Microsoft.Extensions.Configuration.FileConfigurationExtensions.SetBasePath*> when using an <xref:Microsoft.Extensions.Configuration.IConfigurationBuilder> to the folder containing the files.

## Additional resources

::: moniker range=">= aspnetcore-3.0"

* [Kestrel endpoint configuration](xref:fundamentals/servers/kestrel#endpoint-configuration) (includes HTTPS configuration and SNI support)
* <xref:fundamentals/host/generic-host>
* <xref:test/troubleshoot>

::: moniker-end

::: moniker range="< aspnetcore-3.0"

* [Kestrel endpoint configuration](xref:fundamentals/servers/kestrel#endpoint-configuration) (includes HTTPS configuration and SNI support)
* <xref:fundamentals/host/web-host>
* <xref:test/troubleshoot>

::: moniker-end
