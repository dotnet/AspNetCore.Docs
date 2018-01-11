---
title: Host and deploy ASP.NET Core
author: tdykstra
description: Learn how to set up hosting environments and deploy ASP.NET Core apps.
ms.author: riande
manager: wpickett
ms.custom: mvc
ms.date: 08/07/2017
ms.topic: article
ms.technology: aspnet
ms.prod: asp.net-core
uid: host-and-deploy/index
---
# Host and deploy ASP.NET Core

In general, to deploy an ASP.NET Core app to a hosting environment:

* Publish the app to a folder on the hosting server.
* Set up a process manager that starts the app when requests arrive and restarts the app after it crashes or the server reboots.
* Set up a reverse proxy that forwards requests to the app.

## Publish to a folder 

The [dotnet publish](/dotnet/articles/core/tools/dotnet-publish) CLI command compiles app code and copies the files needed to run the app into a *publish* folder. When deploying from Visual Studio, the `dotnet publish` step happens automatically before the files are copied to the deployment destination.

### Folder contents

The *publish* folder contains *.exe* and *.dll* files for the app, its dependencies, and optionally the .NET runtime.

A .NET Core app can be published as *self-contained* or *framework-dependent* app. If the app is self-contained, the *.dll* files that contain the .NET runtime are included in the *publish* folder. If the app is framework-dependent, the .NET runtime files aren't included because the app has a reference to a version of .NET that is installed on the server. The default deployment model is framework-dependent. For more information, see [.NET Core application deployment](/dotnet/articles/core/deploying/index).

In addition to *.exe* and *.dll* files, the *publish* folder for an ASP.NET Core app typically contains configuration files, static assets, and MVC views. For more information, see [Directory structure](xref:host-and-deploy/directory-structure).

## Set up a process manager

An ASP.NET Core app is a console app that must be started when a server boots and restarted if it crashes. To automate starts and restarts, a process manager is required. The most common process managers for ASP.NET Core are:

* Linux
  * [nginx](xref:host-and-deploy/linux-nginx)
  * [Apache](xref:host-and-deploy/linux-apache)
* Windows
  * [IIS](xref:host-and-deploy/iis/index)
  * [Windows Service](xref:host-and-deploy/windows-service)

## Set up a reverse proxy

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

If the app uses the [Kestrel](xref:fundamentals/servers/kestrel) web server, [nginx](xref:host-and-deploy/linux-nginx), [Apache](xref:host-and-deploy/linux-apache), or [IIS](xref:host-and-deploy/iis/index) can be used as a reverse proxy server. A reverse proxy server receives HTTP requests from the Internet and forwards them to Kestrel after some preliminary handling. For more information, see [When to use Kestrel with a reverse proxy](xref:fundamentals/servers/kestrel?tabs=aspnetcore2x#when-to-use-kestrel-with-a-reverse-proxy).

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

If the app uses the [Kestrel](xref:fundamentals/servers/kestrel) web server and will be exposed to the Internet, use [nginx](xref:host-and-deploy/linux-nginx), [Apache](xref:host-and-deploy/linux-apache), or [IIS](xref:host-and-deploy/iis/index) as a reverse proxy server. A reverse proxy server receives HTTP requests from the Internet and forwards them to Kestrel after some preliminary handling. The main reason for using a reverse proxy is security. For more information, see [When to use Kestrel with a reverse proxy](xref:fundamentals/servers/kestrel?tabs=aspnetcore1x#when-to-use-kestrel-with-a-reverse-proxy).

---

## Using Visual Studio and MSBuild to automate deployment

Deployment often requires additional tasks besides copying the output from `dotnet publish` to a server. For example, extra files might be required or excluded from the *publish* folder. Visual Studio uses MSBuild for web deployment, and MSBuild can be customized to do many other tasks during deployment. For more information, see [Publish profiles in Visual Studio](xref:host-and-deploy/visual-studio-publish-profiles) and the [Using MSBuild and Team Foundation Build](http://msbuildbook.com/) book.

By using [the Publish Web feature](xref:tutorials/publish-to-azure-webapp-using-vs) or [built-in Git support](xref:host-and-deploy/azure-apps/azure-continuous-deployment), apps can be deployed directly from Visual Studio to the Azure App Service. Visual Studio Team Services supports [continuous deployment to Azure App Service](/vsts/build-release/apps/cd/azure/aspnet-core-to-azure-webapp?tabs=vsts).

## Publishing to Azure

See [Publish an ASP.NET Core web app to Azure App Service using Visual Studio](xref:tutorials/publish-to-azure-webapp-using-vs) for instructions on how to publish an app to Azure using Visual Studio. The app can also be published to Azure from the [command line](xref:tutorials/publish-to-azure-webapp-using-cli).

## Additional resources

For information on using Docker as a hosting environment, see [Host ASP.NET Core apps in Docker](xref:host-and-deploy/docker/index).
