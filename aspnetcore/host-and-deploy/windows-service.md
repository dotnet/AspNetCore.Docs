---
title: Host in a Windows Service
author: tdykstra
description: Learn how to host an ASP.NET Core application in a Windows Service.
ms.author: tdykstra
manager: wpickett
ms.custom: mvc
ms.date: 03/30/2017
ms.topic: article
ms.technology: aspnet
ms.prod: aspnet-core
uid: host-and-deploy/windows-service
---
# Host an ASP.NET Core app in a Windows Service

By [Tom Dykstra](https://github.com/tdykstra)

The recommended way to host an ASP.NET Core app on Windows without using IIS is to run it in a [Windows Service](https://docs.microsoft.com/dotnet/framework/windows-services/introduction-to-windows-service-applications). That way it can automatically start after reboots and crashes, without waiting for someone to log in.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/host-and-deploy/windows-service/sample) ([how to download](xref:tutorials/index#how-to-download-a-sample)). See the [Next Steps](#next-steps) section for instructions on how to run it.

## Prerequisites

* The app must run on the .NET Framework runtime.  In the *.csproj* file, specify appropriate values for [TargetFramework](https://docs.microsoft.com/nuget/schema/target-frameworks) and [RuntimeIdentifier](https://docs.microsoft.com/dotnet/articles/core/rid-catalog). Here's an example:

  [!code-xml[](windows-service/sample/AspNetCoreService.csproj?range=3-6)]

  When creating a project in Visual Studio, use the **ASP.NET Core Application (.NET Framework)** template.

* If the app receives requests from the Internet (not just from an internal network), it must use the [WebListener](xref:fundamentals/servers/weblistener) web server rather than [Kestrel](xref:fundamentals/servers/kestrel).  Kestrel must be used with IIS for edge deployments.  For more information, see [When to use Kestrel with a reverse proxy](xref:fundamentals/servers/kestrel#when-to-use-kestrel-with-a-reverse-proxy).

## Getting started

This section explains the minimum changes required to set up an existing ASP.NET Core project to run in a service.

* Install the NuGet package [Microsoft.AspNetCore.Hosting.WindowsServices](https://www.nuget.org/packages/Microsoft.AspNetCore.Hosting.WindowsServices/).

* Make the following changes in `Program.Main`:
  
  * Call `host.RunAsService` instead of `host.Run`.
  
  * If the code calls `UseContentRoot`, use a path to the publish location instead of `Directory.GetCurrentDirectory()` 
  
  [!code-csharp[](windows-service/sample/Program.cs?name=ServiceOnly&highlight=3-4,8,14)]

* Publish the application to a folder.

  Use [dotnet publish](https://docs.microsoft.com/dotnet/articles/core/tools/dotnet-publish) or a [Visual Studio publish profile](xref:host-and-deploy/visual-studio-publish-profiles) that publishes to a folder.

* Test by creating and starting the service.

  Open an administrator command prompt window to use the [sc.exe](https://technet.microsoft.com/library/bb490995) command-line tool to create and start a service.  
  
  If the service is named MyService, publish the app to `c:\svc`, and the app itself is named AspNetCoreService, the commands would look like this:

  ```console
  sc create MyService binPath="C:\Svc\AspNetCoreService.exe"
  sc start MyService
  ```

  The `binPath` value is the path to the app's executable, including the executable filename itself.

  ![Console window create and start example](windows-service/_static/create-start.png)

  When these commands finish, browse to the same path as when running as a console app (by default, `http://localhost:5000`)

  ![Running in a service](windows-service/_static/running-in-service.png)


## Provide a way to run outside of a service

It's easier to test and debug when running outside of a service, so it's customary to add code that calls `host.RunAsService` only under certain conditions.  For example, the app can run as a console app with a `--console` command-line argument or if the debugger is attached.

[!code-csharp[](windows-service/sample/Program.cs?name=ServiceOrConsole)]

## Handle stopping and starting events

To handle `OnStarting`, `OnStarted`, and `OnStopping` events, make the following additional changes:

* Create a class that derives from `WebHostService`.

  [!code-csharp[](windows-service/sample/CustomWebHostService.cs?name=NoLogging)]

* Create an extension method for `IWebHost` that passes the custom `WebHostService` to `ServiceBase.Run`.

  [!code-csharp[](windows-service/sample/WebHostServiceExtensions.cs?name=ExtensionsClass)]

* In `Program.Main` change call the new extension method instead of `host.RunAsService`.

  [!code-csharp[](windows-service/sample/Program.cs?name=HandleStopStart&highlight=26)]

If the custom `WebHostService` code needs to get a service from dependency injection (such as a logger), get it from the `Services` property of `IWebHost`.

[!code-csharp[](windows-service/sample/CustomWebHostService.cs?name=Logging&highlight=7)]

## Next steps

The [sample application](https://github.com/aspnet/Docs/tree/master/aspnetcore/host-and-deploy/windows-service/sample) that accompanies this article is a simple MVC web app that has been modified as shown in preceding code examples.  To run it in a service, do the following steps:

* Publish to *c:\svc*.

* Open an administrator window.

* Enter the following commands:

  ```console
  sc create MyService binPath="c:\svc\aspnetcoreservice.exe"
  sc start MyService
  ```

  * In a browser, go to http://localhost:5000 to verify that it's running.

If the app doesn't start up as expected when running in a service, a quick way to make error messages accessible is to add a logging provider such as the [Windows EventLog provider](xref:fundamentals/logging/index#eventlog).

## Acknowledgments

This article was written with the help of sources that were already published. The earliest and most useful of them were these:

* [Hosting ASP.NET Core as Windows service](https://stackoverflow.com/questions/37346383/hosting-asp-net-core-as-windows-service/37464074)
* [How to host your ASP.NET Core in a Windows Service](https://dotnetthoughts.net/how-to-host-your-aspnet-core-in-a-windows-service/)
