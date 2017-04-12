---
title: Hosting and deployment overview - ASP.NET Core | Microsoft Docs
author: tdykstra
description: Overview of how to set up hosting environments and deploy ASP.NET Core apps to them.
keywords: ASP.NET Core,
ms.author: riande
manager: wpickett
ms.date: 10/14/2016
ms.topic: article
ms.assetid: f0930c68-4d17-4748-adbf-801e17601eb6
ms.technology: aspnet
ms.prod: asp.net-core
uid: publishing/index
---
# Hosting and deployment overview for ASP.NET Core apps

Here are the main steps you perform to deploy an ASP.NET Core app to a hosting environment:

* Publish the app's runtime files to a folder, and copy the folder to a server.
* Set up a process manager that starts the app when requests come in and restarts it after it crashes or the server reboots.
* Set up a reverse proxy that forwards requests to the app.

## Publish runtime files to a folder 

The [dotnet publish](https://docs.microsoft.com/dotnet/articles/core/tools/dotnet-publish) CLI command compiles application code and copies the application files and dependency files into a *publish* folder. When you deploy from Visual Studio the `dotnet publish` step is done for you automatically before deployment.

### Publish folder contents

The *publish* folder contains *.exe* and *.dll* files for the application, its dependencies, and optionally the .NET runtime.

A .NET Core app can be published as *self-contained* or *framework-dependent*. If the app is self-contained, the *.dll* files that contain the .NET runtime are included in the *publish* folder.  If the app is framework-dependent, the .NET runtime files are not included because the app has a reference to a version of .NET that is installed on the computer. The default deployment model is framework-dependent. For more information, see [.NET Core application deployment](https://docs.microsoft.com/dotnet/articles/core/deploying/index).

In addition to *.exe* and *.dll* files, the *publish* folder for an ASP.NET Core app can contain configuration files, static assets, log files, and MVC views.  For more information, see [Directory structure](xref:hosting/directory-structure).

## Set up a process manager

An ASP.NET Core app is a console app that has to be started when a server boots and restarted after crashes. To automate starts and restarts you need a process manager. The most common process managers for ASP.NET Core are [Nginx](xref:publishing/linuxproduction) and [Apache](xref:publishing/apache-proxy) on Linux, and [IIS](xref:publishing/iis) and [Windows Service](xref:hosting/windows-service) on Windows.

## Set up a reverse proxy

If your app uses the [Kestrel](xref:fundamentals/servers/kestrel) web server and will be exposed to the Internet, we recommend that you use [Nginx](xref:publishing/linuxproduction), [Apache](xref:publishing/apache-proxy), or [IIS](xref:publishing/iis) as a reverse proxy server. A reverse proxy server receives HTTP requests from the Internet and forwards them to Kestrel after some preliminary handling. The main reason for using a reverse proxy is security. For more information, see [When to use Kestrel with a reverse proxy](xref:fundamentals/servers/kestrel#when-to-use-kestrel-with-a-reverse-proxy).

## Using Visual Studio and MSBuild to automate deployment

Deployment often requires other tasks besides copying the output from `dotnet publish` to a server. For example, you might need to copy additional files to the deployment destination, or exclude some files that `dotnet publish` puts in the *publish* folder. Visual Studio uses MSBuild for web deployment, and you can customize MSBuild to do many other tasks during deployment. For more information, see [Publish profiles in Visual Studio](xref:publishing/web-publishing-vs) and the [Using MSBuild and Team Foundation Build](http://msbuildbook.com/) book.

You can deploy directly from Visual Studio to Azure App Service by using [the Publish Web feature](xref:tutorials/publish-to-azure-webapp-using-vs) or by using [built-in Git support](xref:publishing/azure-continuous-deployment). For continuous deployment to Azure App Service, you can use [Visual Studio Team Services](xref:publishing/vsts-continuous-deployment).

## Additional resources

For information about using Docker as a hosting environment, see [Host ASP.NET Core apps in Docker](xref:publishing/docker).
