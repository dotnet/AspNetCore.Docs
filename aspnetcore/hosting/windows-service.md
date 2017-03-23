---
title: Host in a Windows Service | Microsoft Docs
author: tdykstra
description: Learn how to host an ASP.NET Core application in a Windows Service.
keywords: ASP.NET Core, Windows service, hosting
ms.author: tdykstra
manager: wpickett
ms.date: 03/30/2017
ms.topic: article
ms.assetid: d9a65066-d7cb-47df-b046-64629c4d2c6f
ms.technology: aspnet
ms.prod: aspnet-core
uid: hosting/windows-service
---

# Host an ASP.NET Core app in a Windows Service

When you're hosting an app on Windows without using IIS, you can run the app in a Windows Service. The main reason for running in a service is to maximize availability. Services can automatically start after a machine boots, before a user logs on.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/hosting/windows-service/sample)

## Prerequisites

* The app must run on the .NET framework runtime.  Specify appropriate values for `TargetFramework` and `RuntimeIdentifier` in the *.csproj* file.  Here's an example:

  [!code-xml[](windows-service/sample/AspNetCoreService.csproj?range=3-6)]

  When creating a project in Visual Studio, use the **ASP.NET Core Application (.NET Framework)** template.

* If the app will get requests from the internet (not just from an internal network), it must use the [WebListener](xref:aspnetcore/fundamentals/servers/weblistener) web server rather than [Kestrel](xref:aspnetcore/fundamentals/servers/kestrel).  Kestrel must be used with IIS for edge deployments.  For more information, see [When to use Kestrel with a reverse proxy](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/servers/kestrel#when-to-use-kestrel-with-a-reverse-proxy).

## Getting started

This section explains the minimum changes required to set up an existing ASP.NET Core project to run in a service.

* Install the NuGet package [Microsoft.AspNetCore.Hosting.WindowsServices](https://www.nuget.org/packages/Microsoft.AspNetCore.Hosting.WindowsServices/).

* Make the following changes in `Program.Main`:
  
  * Call `host.RunAsService` instead of `host.Run`.
  
  * If you're calling `UseContentRoot`, use an absolute path to the publish location instead of `Directory.GetCurrentDirectory()` 
  
  [!code-csharp[](windows-service/sample/Program.cs?name=ServiceOnly)]

* Publish the application to a folder.

  Use [dotnet publish](https://docs.microsoft.com/dotnet/articles/core/tools/dotnet-publish) or a Visual Studio publish profile that publishes to a folder.

* Test by creating and starting the service.

  You can use the [sc.exe](https://technet.microsoft.com/library/bb490995) command-line tool from an administrator command prompt window:

  ```console
  sc create servicename binPath= "path\to\yourapp.exe"
  sc start servicename
  ```

  Note: The space after `binPath=` is required. The parameter name is actually `binpath=`, not `binpath`.

  You can now browse to same path as when you run as a console app (by default, `http://localhost:5000`)

## Provide a way to run outside of a service

It's easier to test when you're running outside of a service, so it's customary to add code that call host.RunAsService only under certain conditions.  For example, you could run as a console app if you get a `--console` command-line argument or if the debugger is attached.

[!code-csharp[](windows-service/sample/Program.cs?name=ServiceOrConsole)]

## Handle stopping and starting events

If you want to handle `OnStarting`, `OnStarted`, and `OnStopping` events, make the following additional changes.

* Create a class that derives from `WebHostService`.

  [!code-csharp[](windows-service/sample/CustomWebHostService.cs?name=NoLogging)]

* Create an extension method for `IWebHost`.

  [!code-csharp[](windows-service/sample/WebHostServiceExtensions.cs?name=ExtensionsClass)]

* In `Program.Main` change the `host.RunAsService` command to use new extension method.

  [!code-csharp[](windows-service/sample/Program.cs?name=HandleStopStart)]

## Next steps

The sample application was created by using Visual Studio to create a new project using the MVC web app template, and following the directions in this article.  [View or download the sample code here.](https://github.com/aspnet/Docs/tree/master/aspnetcore/hosting/windows-service/sample)
