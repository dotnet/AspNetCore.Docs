---
title: ASP.NET Core Module overview
author: tdykstra
description: 
keywords: ASP.NET Core,
ms.author: tdykstra
manager: wpickett
ms.date: 10/27/2016
ms.topic: article
ms.assetid: 4661af33-34c5-4d71-93a0-8c7632f43580
ms.prod: aspnet-core
uid: fundamentals/servers/aspnet-core-module
---
# ASP.NET Core Module overview

By [Tom Dykstra](http://github.com/tdykstra), [Rick Strahl](https://github.com/RickStrahl), and [Chris Ross](https://github.com/Tratcher) 

ASP.NET Core Module (ANCM) is an IIS module that lets [Kestrel](kestrel.md) use IIS or IIS Express as a reverse proxy server. **ANCM works only with Kestrel; it isn't compatible with [WebListener](weblistener.md).** 

Supported Windows versions:

* Windows 7 and Windows Server 2008 R2 and later

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/servers/aspnet-core-module/sample)

## What ASP.NET Core Module does

ANCM is a native IIS module that hooks into the IIS pipeline and redirects traffic to the backend ASP.NET Core application. Most other modules, such as windows authentication, still get a chance to run. ANCM only takes control when a handler is selected for the request, and handler mapping is defined in the application *web.config* file.

Because ASP.NET Core applications run in a process separate from the IIS worker process, ANCM also does process management. ANCM starts the process for the ASP.NET Core application when the first request comes in and restarts it when it crashes. This is essentially the same behavior as classic ASP.NET applications that run in-process in IIS and are managed by WAS (Windows Activation Service).

Here's a diagram that illustrates the relationship between IIS, ANCM, and ASP.NET Core applications.

![ASP.NET Core Module](aspnet-core-module/_static/ancm.png)

Requests come in from the Web and hit the kernel mode Http.Sys driver which routes into IIS on the primary port (80) or SSL port (443). The request is then forwarded to the ASP.NET Core application on the HTTP port configured for the application, which is not port 80/443. Kestrel picks up the request and pushes it into the ASP.NET Core middleware pipeline which then handles the request and passes it on as an `HttpContext` instance to application logic. The application's response is then passed back to IIS, which pushes it back out to the HTTP client that initiated the request.

ANCM has a few other functions as well:

* Sets environment variables.
* Logs `stdout` output to file storage.
* Forwards Windows authentication tokens.

## How to use ANCM in ASP.NET Core apps

This section provides an overview of the process for setting up an IIS server and ASP.NET Core application. For detailed instructions, see [Publishing to IIS](../../publishing/iis.md).

### Install ANCM

The ASP.NET Core Module has to be installed in IIS on your servers and in IIS Express on your development machines. For servers, ANCM is included in the [ASP.NET Core Server Hosting Bundle](https://aka.ms/dotnetcore_windowshosting_1_1_0). For development machines, Visual Studio automatically installs ANCM in IIS Express, and in IIS if it is already installed on the machine.

### Install the IISIntegration NuGet package

In your application, install [Microsoft.AspNetCore.Server.IISIntegration](https://www.nuget.org/packages/Microsoft.AspNetCore.Server.IISIntegration/). This is an interoperability pack that reads environment variables broadcast by ANCM to set up your app. The environment variables provide configuration information such as the port to listen on. 

### Call UseIISIntegration

In your application's `Main` method, call the `UseIISIntegration` extension method on [`WebHostBuilder`](http://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/AspNetCore/Hosting/WebHostBuilder/index.html#Microsoft.AspNetCore.Hosting.WebHostBuilder.md). 

[!code-csharp[](aspnet-core-module/sample/Program.cs?name=snippet_Main&highlight=12)]

The `UseIISIntegration` method looks for environment variables that ANCM sets, and it does nothing if they aren't found. This behavior facilitates scenarios like [developing and testing on MacOS and deploying to a server that runs IIS](../../tutorials/your-first-mac-aspnet.md).  While running on the Mac, Kestrel acts as the web server, but when the app is deployed to the IIS environment, it automatically hooks up to ANCM and IIS.

### Don't call UseUrls

ANCM generates a dynamic port to assign to the back-end process. `IWebHostBuilder.UseIISIntegration` picks up this dynamic port and configures Kestrel to listen on `http://locahost:{dynamicPort}/`. This overwrites other URL configurations like calls to `IWebHostBuilder.UseUrls`. Therefore, you don't need to call `UseUrls` when you use ANCM. When you run the app without IIS, it listens on the default port number at http://localhost:5000.

If you need to set the port number for when you run the app without IIS, you can call `UseURLs`.  When you run without IIS, the port number that you provide to `UseUrls` will take effect because `IISIntegration` will do nothing. But when you run with IIS, the port number specified by ANCM will override whatever you passed to `UseUrls`.

In ASP.NET Core 1.0, if you call `UseUrls`, do it **before** you call `IISIntegration` so that the ANCM-configured port doesn't get overwritten. This calling order is not required in ASP.NET Core 1.1, because the ANCM setting will always override `UseUrls`.

### Configure ANCM options in Web.config

Configuration for the ASP.NET Core Module is stored in the *Web.config* file that is located in the application's root folder. Settings in this file point to the startup command and arguments that start your ASP.NET Core app. For sample Web.config code and guidance on configuration options, see [ASP.NET Core Module Configuration Reference](../../hosting/aspnet-core-module.md).

### Run with IIS Express in development

IIS Express can be launched by Visual Studio using the default profile defined by the ASP.NET Core templates.

## Next steps

For more information, see the following resources:

* [Sample app for this article](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/servers/aspnet-core-module/sample)
* [ASP.NET Core Module source code](https://github.com/aspnet/AspNetCoreModule)
* [ASP.NET Core Module Configuration Reference](../../hosting/aspnet-core-module.md)
* [Publishing to IIS](../../publishing/iis.md)
