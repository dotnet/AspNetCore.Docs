---
title: Host ASP.NET Core in a Windows Service
author: guardrex
description: Learn how to host an ASP.NET Core app in a Windows Service.
manager: wpickett
ms.author: tdykstra
ms.custom: mvc
ms.date: 06/04/2018
ms.prod: aspnet-core
ms.technology: aspnet
ms.topic: article
uid: host-and-deploy/windows-service
---
# Host ASP.NET Core in a Windows Service

By [Luke Latham](https://github.com/guardrex) and [Tom Dykstra](https://github.com/tdykstra)

An ASP.NET Core app can be hosted on Windows without using IIS as a [Windows Service](/dotnet/framework/windows-services/introduction-to-windows-service-applications). When hosted as a Windows Service, the app can automatically start after reboots and crashes without requiring human intervention.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/host-and-deploy/windows-service/sample) ([how to download](xref:tutorials/index#how-to-download-a-sample))

## Get started

The following minimum changes are required to set up an existing ASP.NET Core project to run in a service:

1. Add a package reference for [Microsoft.AspNetCore.Hosting.WindowsServices](https://www.nuget.org/packages/Microsoft.AspNetCore.Hosting.WindowsServices/).

1. Make the following changes in `Program.Main`:

   * Call [host.RunAsService](/dotnet/api/microsoft.aspnetcore.hosting.windowsservices.webhostwindowsserviceextensions.runasservice) instead of `host.Run`.

   * If the code calls `UseContentRoot`, use a path to the app's published location instead of `Directory.GetCurrentDirectory()`.

     ::: moniker range=">= aspnetcore-2.0"

     [!code-csharp[](windows-service/sample/Program.cs?name=ServiceOnly&highlight=3-4,7,11)]

     ::: moniker-end

     ::: moniker range="< aspnetcore-2.0"

     [!code-csharp[](windows-service/sample_snapshot/Program.cs?name=ServiceOnly&highlight=3-4,8,13)]

     ::: moniker-end

1. Publish the app to a folder. Use [dotnet publish](/dotnet/articles/core/tools/dotnet-publish) or a [Visual Studio publish profile](xref:host-and-deploy/visual-studio-publish-profiles) that publishes to a folder.

   To publish the sample app from the command line, run the following command in a console window from the project folder:

   ```console
   dotnet publish --configuration Release --output c:\svc
   ```

1. Use the [sc.exe](https://technet.microsoft.com/library/bb490995) command-line tool to create the service (`sc create <SERVICE_NAME> binPath= "<PATH_TO_SERVICE_EXECUTABLE>"`). The `binPath` value is the path to the app's executable, which includes the executable file name. **The space between the equal sign and the quote character that starts the path is required.**

   For the sample app and command that follows, the service is:

   * Named **MyService**.
   * Published to *c:\\svc* folder.
   * Has an app executable named *AspNetCoreService.exe*.

   Open a command shell with administrative privileges and run the following command:

   ```console
   sc create MyService binPath= "c:\svc\aspnetcoreservice.exe"
   ```

   **Make sure the space is present between the `binPath=` argument and its value.**

1. Start the service with the `sc start <SERVICE_NAME>` command.

   To start the sample app service, use the following command:

   ```console
   sc start MyService
   ```

   The command takes a few seconds to start the service.

1. The `sc query <SERVICE_NAME>` command can be used to check the status of the service to determine its status:

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

1. Stop the service with the `sc stop <SERVICE_NAME>` command.

   The following command stops the sample app service:

   ```console
   sc stop MyService
   ```

1. After a short delay to stop a service, uninstall the service with the `sc delete <SERVICE_NAME>` command.

   Check the status of the sample app service:

   ```console
   sc query MyService
   ```

   When the sample app service is in the `STOPPED` state, use the following command to uninstall the sample app service:

   ```console
   sc delete MyService
   ```

## Provide a way to run outside of a service

It's easier to test and debug when running outside of a service, so it's customary to add code that calls `RunAsService` only under certain conditions. For example, the app can run as a console app with a `--console` command-line argument or if the debugger is attached:

::: moniker range=">= aspnetcore-2.0"

[!code-csharp[](windows-service/sample/Program.cs?name=ServiceOrConsole)]

Because ASP.NET Core configuration requires name-value pairs for command-line arguments, the `--console` switch is removed before the arguments are passed to [CreateDefaultBuilder](/dotnet/api/microsoft.aspnetcore.webhost.createdefaultbuilder).

::: moniker-end

::: moniker range="< aspnetcore-2.0"

[!code-csharp[](windows-service/sample_snapshot/Program.cs?name=ServiceOrConsole)]

::: moniker-end

## Handle stopping and starting events

To handle [OnStarting](/dotnet/api/microsoft.aspnetcore.hosting.windowsservices.webhostservice.onstarting), [OnStarted](/dotnet/api/microsoft.aspnetcore.hosting.windowsservices.webhostservice.onstarted), and [OnStopping](/dotnet/api/microsoft.aspnetcore.hosting.windowsservices.webhostservice.onstopping) events, make the following additional changes:

1. Create a class that derives from [WebHostService](/dotnet/api/microsoft.aspnetcore.hosting.windowsservices.webhostservice):

   [!code-csharp[](windows-service/sample/CustomWebHostService.cs?name=NoLogging)]

2. Create an extension method for [IWebHost](/dotnet/api/microsoft.aspnetcore.hosting.iwebhost) that passes the custom `WebHostService` to [ServiceBase.Run](/dotnet/api/system.serviceprocess.servicebase.run):

   [!code-csharp[](windows-service/sample/WebHostServiceExtensions.cs?name=ExtensionsClass)]

3. In `Program.Main`, call the new extension method, `RunAsCustomService`, instead of [RunAsService](/dotnet/api/microsoft.aspnetcore.hosting.windowsservices.webhostwindowsserviceextensions.runasservice):

   ::: moniker range=">= aspnetcore-2.0"

   [!code-csharp[](windows-service/sample/Program.cs?name=HandleStopStart&highlight=27)]

   ::: moniker-end

   ::: moniker range="< aspnetcore-2.0"

   [!code-csharp[](windows-service/sample_snapshot/Program.cs?name=HandleStopStart&highlight=27)]

   ::: moniker-end

If the custom `WebHostService` code requires a service from dependency injection (such as a logger), obtain it from the [IWebHost.Services](/dotnet/api/microsoft.aspnetcore.hosting.iwebhost.services) property:

[!code-csharp[](windows-service/sample/CustomWebHostService.cs?name=Logging&highlight=7)]

## Proxy server and load balancer scenarios

Services that interact with requests from the Internet or a corporate network and are behind a proxy or load balancer might require additional configuration. For more information, see [Configure ASP.NET Core to work with proxy servers and load balancers](xref:host-and-deploy/proxy-load-balancer).

## Acknowledgments

This article was written with the help of published sources:

* [Hosting ASP.NET Core as Windows service](https://stackoverflow.com/questions/37346383/hosting-asp-net-core-as-windows-service/37464074)
* [How to host your ASP.NET Core in a Windows Service](https://dotnetthoughts.net/how-to-host-your-aspnet-core-in-a-windows-service/)
