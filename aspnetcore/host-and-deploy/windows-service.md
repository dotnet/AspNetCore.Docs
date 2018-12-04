---
title: Host ASP.NET Core in a Windows Service
author: guardrex
description: Learn how to host an ASP.NET Core app in a Windows Service.
monikerRange: '>= aspnetcore-2.1'
ms.author: tdykstra
ms.custom: mvc
ms.date: 12/01/2018
uid: host-and-deploy/windows-service
---
# Host ASP.NET Core in a Windows Service

By [Luke Latham](https://github.com/guardrex) and [Tom Dykstra](https://github.com/tdykstra)

An ASP.NET Core app can be hosted on Windows as a [Windows Service](/dotnet/framework/windows-services/introduction-to-windows-service-applications) without using IIS. When hosted as a Windows Service, the app automatically starts after reboots.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/host-and-deploy/windows-service/samples) ([how to download](xref:index#how-to-download-a-sample))

## Deployment type

You can create either a framework-dependent or self-contained Windows Service deployment. For information and advice on deployment scenarios, see [.NET Core application deployment](/dotnet/core/deploying/).

### Framework-dependent deployment

Framework-dependent deployment (FDD) relies on the presence of a shared system-wide version of .NET Core on the target system. When the FDD scenario is used with an ASP.NET Core Windows Service app, the SDK produces an executable (*\*.exe*), called a *framework-dependent executable*.

### Self-contained deployment

Self-contained deployment (SCD) doesn't rely on the presence of shared components on the target system. The runtime and the app's dependencies are deployed with the app to the hosting system.

## Convert a project into a Windows Service

Make the following changes to an existing ASP.NET Core project to run the app as a service:

### Project file updates

Based on your choice of [deployment type](#deployment-type), update the project file:

#### Framework-dependent Deployment (FDD)

Add a Windows [Runtime Identifier (RID)](/dotnet/core/rid-catalog) to the `<PropertyGroup>` that contains the target framework. Add the `<SelfContained>` property set to `false`. Disable the creation of a *web.config* file by adding the `<IsTransformWebConfigDisabled>` property set to `true`.

::: moniker range=">= aspnetcore-2.2"

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

#### Self-contained Deployment (SCD)

Confirm the presence of a Windows [Runtime Identifier (RID)](/dotnet/core/rid-catalog) or add a RID to the `<PropertyGroup>` that contains the target framework. Disable the creation of a *web.config* file by adding the `<IsTransformWebConfigDisabled>` property set to `true`.

```xml
<PropertyGroup>
  <TargetFramework>netcoreapp2.2</TargetFramework>
  <RuntimeIdentifier>win7-x64</RuntimeIdentifier>
  <IsTransformWebConfigDisabled>true</IsTransformWebConfigDisabled>
</PropertyGroup>
```

To publish for multiple RIDs:

* Provide the RIDs in a semicolon-delimited list.
* Use the property name `<RuntimeIdentifiers>` (plural).

  For more information, see [.NET Core RID Catalog](/dotnet/core/rid-catalog).

Add a package reference for [Microsoft.AspNetCore.Hosting.WindowsServices](https://www.nuget.org/packages/Microsoft.AspNetCore.Hosting.WindowsServices).

To enable Windows Event Log logging, add a package reference for [Microsoft.Extensions.Logging.EventLog](https://www.nuget.org/packages/Microsoft.Extensions.Logging.EventLog).

For more information, see the [Handle starting and stopping events](#handle-starting-and-stopping-events) section.

### Program.Main updates

Make the following changes in `Program.Main`:

* To test and debug when running outside of a service, add code to determine if the app is running as a service or a console app. Inspect if the debugger is attached or a `--console` command-line argument is present.

  If either condition is true (the app isn't run as a service), call <xref:Microsoft.AspNetCore.Hosting.WebHostExtensions.Run*> on the Web Host.

  If the conditions are false (the app is run as a service):

  * Call <xref:Microsoft.Extensions.Hosting.HostingHostBuilderExtensions.UseContentRoot*> and use a path to the app's published location. Don't call <xref:System.IO.Directory.GetCurrentDirectory*> to obtain the path because a Windows Service app returns the *C:\\WINDOWS\\system32* folder when `GetCurrentDirectory` is called. For more information, see the [Current directory and content root](#current-directory-and-content-root) section.
  * Call <xref:Microsoft.AspNetCore.Hosting.WindowsServices.WebHostWindowsServiceExtensions.RunAsService*> to run the app as a service.

  Because the [Command-line Configuration Provider](xref:fundamentals/configuration/index#command-line-configuration-provider) requires name-value pairs for command-line arguments, the `--console` switch is removed from the arguments before <xref:Microsoft.AspNetCore.WebHost.CreateDefaultBuilder*> receives them.

* To write to the Windows Event Log, add the EventLog provider to <xref:Microsoft.AspNetCore.Hosting.WebHostBuilder.ConfigureLogging*>. Set the logging level with the `Logging:LogLevel:Default` key in the *appsettings.Production.json* file. For demonstration and testing purposes, the sample app's Production settings file sets the logging level to `Information`. In production, the value is typically set to `Error`. For more information, see <xref:fundamentals/logging/index#windows-eventlog-provider>.

[!code-csharp[](windows-service/samples/2.x/AspNetCoreService/Program.cs?name=snippet_Program)]

### Publish the app

Publish the app using [dotnet publish](/dotnet/articles/core/tools/dotnet-publish), a [Visual Studio publish profile](xref:host-and-deploy/visual-studio-publish-profiles), or Visual Studio Code. When using Visual Studio, select the **FolderProfile** and configure the **Target Location** before selecting the **Publish** button.

To publish the sample app using command-line interface (CLI) tools, run the [dotnet publish](/dotnet/core/tools/dotnet-publish) command at a command prompt from the project folder with a Release configuration passed to the [-c|--configuration](/dotnet/core/tools/dotnet-publish#options) option. Use the [-o|--output](/dotnet/core/tools/dotnet-publish#options) option with a path to publish to a folder outside of the app.

#### Publish a Framework-dependent Deployment (FDD)

In the following example, the app is published to the *c:\\svc* folder:

```console
dotnet publish --configuration Release --output c:\svc
```

#### Publish a Self-contained Deployment (SCD)

The RID must be specified in the `<RuntimeIdenfifier>` (or `<RuntimeIdentifiers>`) property of the project file. Supply the runtime to the [-r|--runtime](/dotnet/core/tools/dotnet-publish#options) option of the `dotnet publish` command.

In the following example, the app is published for the `win7-x64` runtime to the *c:\\svc* folder:

```console
dotnet publish --configuration Release --runtime win7-x64 --output c:\svc
```

### Create a user account

Create a user account for the service using the `net user` command:

```console
net user {USER ACCOUNT} {PASSWORD} /add
```

For the sample app, create a user account with the name `ServiceUser` and a password. In the following command, replace `{PASSWORD}` with a [strong password](/windows/security/threat-protection/security-policy-settings/password-must-meet-complexity-requirements).

```console
net user ServiceUser {PASSWORD} /add
```

If you need to add the user to a group, use the `net localgroup` command, where `{GROUP}` is the name of the group:

```console
net localgroup {GROUP} {USER ACCOUNT} /add
```

For more information, see [Service User Accounts](/windows/desktop/services/service-user-accounts).

### Set permissions

Grant write/read/execute access to the app's folder using the [icacls](/windows-server/administration/windows-commands/icacls) command:

```console
icacls "{PATH}" /grant {USER ACCOUNT}:(OI)(CI){PERMISSION FLAGS} /t
```

* `{PATH}` &ndash; Path to the app's folder.
* `{USER ACCOUNT}` &ndash; The user account (SID).
* `(OI)` &ndash; The Object Inherit flag propagates permissions to subordinate files.
* `(CI)` &ndash; The Container Inherit flag propagates permissions to subordinate folders.
* `{PERMISSION FLAGS}` &ndash; Sets the app's access permissions.
  * Write (`W`)
  * Read (`R`)
  * Execute (`X`)
  * Full (`F`)
  * Modify (`M`)
* `/t` &ndash; Apply recursively to existing subordinate folders and files.

For the sample app published to the *c:\\svc* folder and the `ServiceUser` account with write/read/execute permissions, use the following command:

```console
icacls "c:\svc" /grant ServiceUser:(OI)(CI)WRX /t
```

For more information, see [icacls](/windows-server/administration/windows-commands/icacls).

## Manage the service

### Create the service

Use the [sc.exe](https://technet.microsoft.com/library/bb490995) command-line tool to create the service. The `binPath` value is the path to the app's executable, which includes the executable file name. **The space between the equal sign and the quote character of each parameter and value is required.**

```console
sc create {SERVICE NAME} binPath= "{PATH}" obj= "{DOMAIN}\{USER ACCOUNT}" password= "{PASSWORD}"
```

* `{SERVICE NAME}` &ndash; The name to assign to the service in [Service Control Manager](/windows/desktop/services/service-control-manager).
* `{PATH}` &ndash; The path to the service executable.
* `{DOMAIN}` &ndash; The domain of a domain-joined machine. If the machine isn't domain-joined, the local machine name.
* `{USER ACCOUNT}` &ndash; The user account under which the service runs.
* `{PASSWORD}` &ndash; The user account password.

> [!WARNING]
> Do **not** omit the `obj` parameter. The default value for `obj` is the [LocalSystem account](/windows/desktop/services/localsystem-account) account. Running a service under the `LocalSystem` account presents a significant security risk. Always run a service with a user account that has restricted privileges.

In the following example for the sample app:

* The service is named **MyService**.
* The published service resides in the *c:\\svc* folder. The app executable is named *SampleApp.exe*. Enclose the `binPath` value in double quotation marks (").
* The service runs under the `ServiceUser` account. Replace `{DOMAIN}` with the user account's domain or local machine name. Enclose the `obj` value in double quotation marks ("). Example: If the hosting system is a local machine named `MairaPC`, set `obj` to `"MairaPC\ServiceUser"`.
* Replace `{PASSWORD}` with the user account's password. Enclose the `password` value in double quotation marks (").

```console
sc create MyService binPath= "c:\svc\sampleapp.exe" obj= "{DOMAIN}\ServiceUser" password= "{PASSWORD}"
```

> [!IMPORTANT]
> Make sure that the spaces between the parameters' equal signs and the parameters' values are present.

### Start the service

Start the service with the `sc start {SERVICE NAME}` command.

To start the sample app service, use the following command:

```console
sc start MyService
```

The command takes a few seconds to start the service.

### Determine the service status

To check the status of the service, use the `sc query {SERVICE NAME}` command. The status is reported as one of the following values:

* `START_PENDING`
* `RUNNING`
* `STOP_PENDING`
* `STOPPED`

Use the following command to check the status of the sample app service:

```console
sc query MyService
```

### Browse a web app service

When the service is in the `RUNNING` state and if the service is a web app, browse the app at its path (by default, `http://localhost:5000`, which redirects to `https://localhost:5001` when using [HTTPS Redirection Middleware](xref:security/enforcing-ssl)).

For the sample app service, browse the app at `http://localhost:5000`.

### Stop the service

Stop the service with the `sc stop {SERVICE NAME}` command.

The following command stops the sample app service:

```console
sc stop MyService
```

### Delete the service

After a short delay to stop a service, uninstall the service with the `sc delete {SERVICE NAME}` command.

Check the status of the sample app service:

```console
sc query MyService
```

When the sample app service is in the `STOPPED` state, use the following command to uninstall the sample app service:

```console
sc delete MyService
```

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

## Proxy server and load balancer scenarios

Services that interact with requests from the Internet or a corporate network and are behind a proxy or load balancer might require additional configuration. For more information, see <xref:host-and-deploy/proxy-load-balancer>.

## Configure HTTPS

To configure the service with a secure endpoint:

1. Create an X.509 certificate for the hosting system using your platform's certificate acquisition and deployment mechanisms.

1. Specify a [Kestrel server HTTPS endpoint configuration](xref:fundamentals/servers/kestrel#endpoint-configuration) to use the certificate.

Use of the ASP.NET Core HTTPS development certificate to secure a service endpoint isn't supported.

## Current directory and content root

The current working directory returned by calling <xref:System.IO.Directory.GetCurrentDirectory*> for a Windows Service is the *C:\\WINDOWS\\system32* folder. The *system32* folder isn't a suitable location to store a service's files (for example, settings files). Use one of the following approaches to maintain and access a service's assets and settings files.

### Set the content root path to the app's folder

The <xref:Microsoft.Extensions.Hosting.IHostingEnvironment.ContentRootPath*> is the same path provided to the `binPath` argument when the service is created. Instead of calling `GetCurrentDirectory` to create paths to settings files, call <xref:Microsoft.Extensions.Hosting.HostingHostBuilderExtensions.UseContentRoot*> with the path to the app's content root.

In `Program.Main`, determine the path to the folder of the service's executable and use the path to establish the app's content root:

```csharp
var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
var pathToContentRoot = Path.GetDirectoryName(pathToExe);

CreateWebHostBuilder(args)
    .UseContentRoot(pathToContentRoot)
    .Build()
    .RunAsService();
```

### Store the service's files in a suitable location on disk

Specify an absolute path with <xref:Microsoft.Extensions.Configuration.FileConfigurationExtensions.SetBasePath*> when using an <xref:Microsoft.Extensions.Configuration.IConfigurationBuilder> to the folder containing the files.

## Additional resources

* [Kestrel endpoint configuration](xref:fundamentals/servers/kestrel#endpoint-configuration) (includes HTTPS configuration and SNI support)
* <xref:fundamentals/host/web-host>
* <xref:test/troubleshoot>
