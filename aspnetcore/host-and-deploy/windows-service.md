---
title: Host in a Windows Service
author: tdykstra
description: Learn how to host an ASP.NET Core app in a Windows Service.
manager: wpickett
ms.author: tdykstra
ms.custom: mvc
ms.date: 01/30/2018
ms.prod: aspnet-core
ms.technology: aspnet
ms.topic: article
uid: host-and-deploy/windows-service
---
# Host an ASP.NET Core app in a Windows Service

By [Tom Dykstra](https://github.com/tdykstra)

The recommended way to host an ASP.NET Core app on Windows without using IIS is to run it in a [Windows Service](/dotnet/framework/windows-services/introduction-to-windows-service-applications). When hosted as a Windows Service, the app can automatically start after reboots and crashes without requiring human intervention.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/host-and-deploy/windows-service/sample) ([how to download](xref:tutorials/index#how-to-download-a-sample)). For instructions on how to run the sample app, see the sample's *README.md* file.

## Prerequisites

* The app must run on the .NET Framework runtime. In the *.csproj* file, specify appropriate values for [TargetFramework](/nuget/schema/target-frameworks) and [RuntimeIdentifier](/dotnet/articles/core/rid-catalog). Here's an example:

  [!code-xml[](windows-service/sample/AspNetCoreService.csproj?range=3-6)]

  When creating a project in Visual Studio, use the **ASP.NET Core Application (.NET Framework)** template.

* If the app receives requests from the Internet (not just from an internal network), it must use the [HTTP.sys](xref:fundamentals/servers/httpsys) web server (formerly known as [WebListener](xref:fundamentals/servers/weblistener) for ASP.NET Core 1.x apps) rather than [Kestrel](xref:fundamentals/servers/kestrel). IIS is recommended for use as a reverse proxy server with Kestrel for edge deployments. For more information, see [When to use Kestrel with a reverse proxy](xref:fundamentals/servers/kestrel#when-to-use-kestrel-with-a-reverse-proxy).

## Getting started

This section explains the minimum changes required to set up an existing ASP.NET Core project to run in a service.

1. Install the NuGet package [Microsoft.AspNetCore.Hosting.WindowsServices](https://www.nuget.org/packages/Microsoft.AspNetCore.Hosting.WindowsServices/).

1. Make the following changes in `Program.Main`:
  
   * Call `host.RunAsService` instead of `host.Run`.
  
   * If the code calls `UseContentRoot`, use a path to the publish location instead of `Directory.GetCurrentDirectory()`.

   # [ASP.NET Core 2.x](#tab/aspnetcore2x)

   [!code-csharp[](windows-service/sample/Program.cs?name=ServiceOnly&highlight=3-4,7,12)]

   # [ASP.NET Core 1.x](#tab/aspnetcore1x)

   [!code-csharp[](windows-service/sample_snapshot/Program.cs?name=ServiceOnly&highlight=3-4,8,14)]

   ---

1. Publish the app to a folder. Use [dotnet publish](/dotnet/articles/core/tools/dotnet-publish) or a [Visual Studio publish profile](xref:host-and-deploy/visual-studio-publish-profiles) that publishes to a folder.

1. Test by creating and starting the service.

   Open a command shell with administrative privileges to use the [sc.exe](https://technet.microsoft.com/library/bb490995) command-line tool to create and start a service. If the service is named MyService, published to `c:\svc`, and named AspNetCoreService, the commands are:

   ```console
   sc create MyService binPath="c:\svc\aspnetcoreservice.exe"
   sc start MyService
   ```

   The `binPath` value is the path to the app's executable, which includes the executable file name.

   ![Console window create and start example](windows-service/_static/create-start.png)

   When these commands finish, browse to the same path as when running as a console app (by default, `http://localhost:5000`):

   ![Running in a service](windows-service/_static/running-in-service.png)

## Provide a way to run outside of a service

It's easier to test and debug when running outside of a service, so it's customary to add code that calls `RunAsService` only under certain conditions. For example, the app can run as a console app with a `--console` command-line argument or if the debugger is attached:

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

[!code-csharp[](windows-service/sample/Program.cs?name=ServiceOrConsole)]

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

[!code-csharp[](windows-service/sample_snapshot/Program.cs?name=ServiceOrConsole)]

---

## Handle stopping and starting events

To handle `OnStarting`, `OnStarted`, and `OnStopping` events, make the following additional changes:

1. Create a class that derives from `WebHostService`:

   [!code-csharp[](windows-service/sample/CustomWebHostService.cs?name=NoLogging)]

1. Create an extension method for `IWebHost` that passes the custom `WebHostService` to `ServiceBase.Run`:

   [!code-csharp[](windows-service/sample/WebHostServiceExtensions.cs?name=ExtensionsClass)]

1. In `Program.Main`, call the new extension method, `RunAsCustomService`, instead of `RunAsService`:

   # [ASP.NET Core 2.x](#tab/aspnetcore2x)

   [!code-csharp[](windows-service/sample/Program.cs?name=HandleStopStart&highlight=24)]

   # [ASP.NET Core 1.x](#tab/aspnetcore1x)

   [!code-csharp[](windows-service/sample_snapshot/Program.cs?name=HandleStopStart&highlight=26)]

   ---

If the custom `WebHostService` code requires a service from dependency injection (such as a logger), obtain it from the `Services` property of `IWebHost`:

[!code-csharp[](windows-service/sample/CustomWebHostService.cs?name=Logging&highlight=7)]

## Acknowledgments

This article was written with the help of published sources:

* [Hosting ASP.NET Core as Windows service](https://stackoverflow.com/questions/37346383/hosting-asp-net-core-as-windows-service/37464074)
* [How to host your ASP.NET Core in a Windows Service](https://dotnetthoughts.net/how-to-host-your-aspnet-core-in-a-windows-service/)
