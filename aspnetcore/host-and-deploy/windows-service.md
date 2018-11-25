---
title: Host ASP.NET Core in a Windows Service
author: guardrex
description: Learn how to host an ASP.NET Core app in a Windows Service.
monikerRange: '>= aspnetcore-2.1'
ms.author: tdykstra
ms.custom: mvc
ms.date: 11/26/2018
uid: host-and-deploy/windows-service
---
# Host ASP.NET Core in a Windows Service

By [Luke Latham](https://github.com/guardrex) and [Tom Dykstra](https://github.com/tdykstra)

An ASP.NET Core app can be hosted on Windows without using IIS as a [Windows Service](/dotnet/framework/windows-services/introduction-to-windows-service-applications). When hosted as a Windows Service, the app automatically starts after reboots.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/host-and-deploy/windows-service/samples) ([how to download](xref:index#how-to-download-a-sample))

## Convert a project into a Windows Service

The following minimum changes are required to set up an existing ASP.NET Core project to run as a service:

1. In the project file:

   * Confirm the presence of a Windows [Runtime Identifier (RID)](/dotnet/core/rid-catalog) or add it to the `<PropertyGroup>` that contains the target framework:

      ```xml
      <PropertyGroup>
        <TargetFramework>netcoreapp2.2</TargetFramework>
        <RuntimeIdentifier>win7-x64</RuntimeIdentifier>
      </PropertyGroup>
      ```

      To publish for multiple RIDs:

      * Provide the RIDs in a semicolon-delimited list.
      * Use the property name `<RuntimeIdentifiers>` (plural).

      For more information, see [.NET Core RID Catalog](/dotnet/core/rid-catalog).

   * Add a package reference for [Microsoft.AspNetCore.Hosting.WindowsServices](https://www.nuget.org/packages/Microsoft.AspNetCore.Hosting.WindowsServices).

1. Make the following changes in `Program.Main`:

   * Call [host.RunAsService](/dotnet/api/microsoft.aspnetcore.hosting.windowsservices.webhostwindowsserviceextensions.runasservice) instead of `host.Run`.

   * Call [UseContentRoot](xref:fundamentals/host/web-host#content-root) and use a path to the app's published location instead of `Directory.GetCurrentDirectory()`.

     [!code-csharp[](windows-service/samples/2.x/AspNetCoreService/Program.cs?name=ServiceOnly&highlight=8-9,16)]

1. Publish the app using [dotnet publish](/dotnet/articles/core/tools/dotnet-publish), a [Visual Studio publish profile](xref:host-and-deploy/visual-studio-publish-profiles), or Visual Studio Code. When using Visual Studio, select the **FolderProfile** and configure the **Target Location** before selecting the **Publish** button.

   To publish the sample app using command-line interface (CLI) tools, run the [dotnet publish](/dotnet/core/tools/dotnet-publish) command at a command prompt from the project folder. The RID must be specified in the `<RuntimeIdenfifier>` (or `<RuntimeIdentifiers>`) property of the project file. In the following example, the app is published in Release configuration for the `win7-x64` runtime to a folder created at *c:\\svc*:

   ```console
   dotnet publish --configuration Release --runtime win7-x64 --output c:\svc
   ```

1. Create a user account for the service using the `net user` command:

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

1. Grant write/read/execute access to the app's folder using the [icacls](/windows-server/administration/windows-commands/icacls) command:

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

1. Use the [sc.exe](https://technet.microsoft.com/library/bb490995) command-line tool to create the service. The `binPath` value is the path to the app's executable, which includes the executable file name. **The space between the equal sign and the quote character of each parameter and value is required.**

   ```console
   sc create {SERVICE NAME} binPath= "{PATH}" obj= "{DOMAIN}\{USER ACCOUNT}" password= "{PASSWORD}"
   ```

   * `{SERVICE NAME}` &ndash; The name to assign to the service in [Service Control Manager](/windows/desktop/services/service-control-manager).
   * `{PATH}` &ndash; The path to the service executable.
   * `{DOMAIN}` (or if the machine isn't domain joined, the local machine name) and `{USER ACCOUNT}` &ndash; The domain (or local machine name) and user account under which the service runs. Do **not** omit the `obj` parameter. The default value for `obj` is the [LocalSystem account](/windows/desktop/services/localsystem-account) account. Running a service under the `LocalSystem` account presents a significant security risk. Always run a service under a user account with restricted privileges on the server.
   * `{PASSWORD}` &ndash; The user account password.

   In the following example:

   * The service is named **MyService**.
   * The published service resides in the *c:\\svc* folder. The app executable is named *AspNetCoreService.exe*. The `binPath` value is enclosed in straight quotation marks (").
   * The service runs under the `ServiceUser` account. Replace `{DOMAIN}` with the user account's domain or local machine name. Enclose the `obj` value in straight quotation marks ("). Example: If the hosting system is a local machine named `MairaPC`, set `obj` to `"MairaPC\ServiceUser"`.
   * Replace `{PASSWORD}` with the user account's password. The `password` value is enclosed in straight quotation marks (").

   ```console
   sc create MyService binPath= "c:\svc\aspnetcoreservice.exe" obj= "{DOMAIN}\ServiceUser" password= "{PASSWORD}"
   ```

   > [!IMPORTANT]
   > Make sure that the spaces between the parameters' equal signs and the parameters' values are present.

1. Start the service with the `sc start {SERVICE NAME}` command.

   To start the sample app service, use the following command:

   ```console
   sc start MyService
   ```

   The command takes a few seconds to start the service.

1. To check the status of the service, use the `sc query {SERVICE NAME}` command. The status is reported as one of the following values:

   * `START_PENDING`
   * `RUNNING`
   * `STOP_PENDING`
   * `STOPPED`

   Use the following command to check the status of the sample app service:

   ```console
   sc query MyService
   ```

1. When the service is in the `RUNNING` state and if the service is a web app, browse the app at its path (by default, `http://localhost:5000`, which redirects to `https://localhost:5001` when using [HTTPS Redirection Middleware](xref:security/enforcing-ssl)).

   For the sample app service, browse the app at `http://localhost:5000`.

1. Stop the service with the `sc stop {SERVICE NAME}` command.

   The following command stops the sample app service:

   ```console
   sc stop MyService
   ```

1. After a short delay to stop a service, uninstall the service with the `sc delete {SERVICE NAME}` command.

   Check the status of the sample app service:

   ```console
   sc query MyService
   ```

   When the sample app service is in the `STOPPED` state, use the following command to uninstall the sample app service:

   ```console
   sc delete MyService
   ```

## Run the app outside of a service

It's easier to test and debug when running outside of a service, so it's customary to add code that calls `RunAsService` only under certain conditions. For example, the app can run as a console app with a `--console` command-line argument or if the debugger is attached:

[!code-csharp[](windows-service/samples/2.x/AspNetCoreService/Program.cs?name=ServiceOrConsole)]

Because ASP.NET Core configuration requires name-value pairs for command-line arguments, the `--console` switch is removed before the arguments are passed to [CreateDefaultBuilder](/dotnet/api/microsoft.aspnetcore.webhost.createdefaultbuilder).

> [!NOTE]
> `isService` isn't passed from `Main` into `CreateWebHostBuilder` because the signature of `CreateWebHostBuilder` must be `CreateWebHostBuilder(string[])` in order for [integration testing](xref:test/integration-tests) to work properly.

## Handle stopping and starting events

To handle [OnStarting](/dotnet/api/microsoft.aspnetcore.hosting.windowsservices.webhostservice.onstarting), [OnStarted](/dotnet/api/microsoft.aspnetcore.hosting.windowsservices.webhostservice.onstarted), and [OnStopping](/dotnet/api/microsoft.aspnetcore.hosting.windowsservices.webhostservice.onstopping) events, make the following additional changes:

1. Create a class that derives from [WebHostService](/dotnet/api/microsoft.aspnetcore.hosting.windowsservices.webhostservice):

   [!code-csharp[](windows-service/samples/2.x/AspNetCoreService/CustomWebHostService.cs?name=NoLogging)]

2. Create an extension method for [IWebHost](/dotnet/api/microsoft.aspnetcore.hosting.iwebhost) that passes the custom `WebHostService` to [ServiceBase.Run](/dotnet/api/system.serviceprocess.servicebase.run):

   [!code-csharp[](windows-service/samples/2.x/AspNetCoreService/WebHostServiceExtensions.cs?name=ExtensionsClass)]

3. In `Program.Main`, call the new extension method, `RunAsCustomService`, instead of [RunAsService](/dotnet/api/microsoft.aspnetcore.hosting.windowsservices.webhostwindowsserviceextensions.runasservice):

   [!code-csharp[](windows-service/samples/2.x/AspNetCoreService/Program.cs?name=HandleStopStart&highlight=17)]

   > [!NOTE]
   > `isService` isn't passed from `Main` into `CreateWebHostBuilder` because the signature of `CreateWebHostBuilder` must be `CreateWebHostBuilder(string[])` in order for [integration testing](xref:test/integration-tests) to work properly.

If the custom `WebHostService` code requires a service from dependency injection (such as a logger), obtain it from the [IWebHost.Services](/dotnet/api/microsoft.aspnetcore.hosting.iwebhost.services) property:

[!code-csharp[](windows-service/samples/2.x/AspNetCoreService/CustomWebHostService.cs?name=Logging&highlight=7-8)]

## Proxy server and load balancer scenarios

Services that interact with requests from the Internet or a corporate network and are behind a proxy or load balancer might require additional configuration. For more information, see <xref:host-and-deploy/proxy-load-balancer>.

## Configure HTTPS

To configure the service with a secure endpoint:

1. Create an X.509 certificate for the hosting system using your platform's certificate acquisition and deployment mechanisms.
1. Specify a [Kestrel server HTTPS endpoint configuration](xref:fundamentals/servers/kestrel#endpoint-configuration) to use the certificate.

Use of the ASP.NET Core HTTPS development certificate to secure a service endpoint isn't supported.

## Current directory and content root

The current working directory returned by calling `Directory.GetCurrentDirectory()` for a Windows Service is the *C:\\WINDOWS\\system32* folder. The *system32* folder isn't a suitable location to store a service's files (for example, settings files). Use one of the following approaches to maintain and access a service's assets and settings files with [FileConfigurationExtensions.SetBasePath](/dotnet/api/microsoft.extensions.configuration.fileconfigurationextensions.setbasepath) when using an [IConfigurationBuilder](/dotnet/api/microsoft.extensions.configuration.iconfigurationbuilder):

* Use the content root path. The `IHostingEnvironment.ContentRootPath` is the same path provided to the `binPath` argument when the service is created. Instead of using `Directory.GetCurrentDirectory()` to create paths to settings files, use the content root path and maintain the files in the app's content root.
* Store the files in a suitable location on disk. Specify an absolute path with `SetBasePath` to the folder containing the files.

## Additional resources

* [Kestrel endpoint configuration](xref:fundamentals/servers/kestrel#endpoint-configuration) (includes HTTPS configuration and SNI support)
* <xref:fundamentals/host/web-host>
* <xref:test/troubleshoot>
