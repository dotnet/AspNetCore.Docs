---
title: ASP.NET Core Module
author: rick-anderson
description: Learn how the ASP.NET Core Module allows the Kestrel web server to use IIS or IIS Express as a reverse proxy server.
ms.author: tdykstra
ms.custom: mvc
ms.date: 02/23/2018
uid: fundamentals/servers/aspnet-core-module
---
# ASP.NET Core Module

By [Tom Dykstra](https://github.com/tdykstra), [Rick Strahl](https://github.com/RickStrahl), and [Chris Ross](https://github.com/Tratcher) 

The ASP.NET Core Module allows ASP.NET Core apps to run behind IIS in a reverse proxy configuration. IIS provides advanced web app security and manageability features.

Supported Windows versions:

* Windows 7 or later
* Windows Server 2008 R2 or later

The ASP.NET Core Module only works with Kestrel. The module is incompatible with [HTTP.sys](xref:fundamentals/servers/httpsys) (formerly called [WebListener](xref:fundamentals/servers/weblistener)).

## ASP.NET Core Module description

The ASP.NET Core Module is a native IIS module that plugs into the IIS pipeline to redirect web requests to backend ASP.NET Core apps. Many native modules, such as Windows Authentication, remain active. To learn more about IIS modules active with the module, see [IIS modules](xref:host-and-deploy/iis/modules).

Because ASP.NET Core apps run in a process separate from the IIS worker process, the module also handles process management. The module starts the process for the ASP.NET Core app when the first request arrives and restarts the app if it crashes. This is essentially the same behavior as seen with ASP.NET 4.x apps that run in-process in IIS that are managed by the [Windows Process Activation Service (WAS)](/iis/manage/provisioning-and-managing-iis/features-of-the-windows-process-activation-service-was).

The following diagram illustrates the relationship between IIS, the ASP.NET Core Module, and ASP.NET Core apps:

![ASP.NET Core Module](aspnet-core-module/_static/ancm.png)

Requests arrive from the web to the kernel-mode HTTP.sys driver. The driver routes the requests to IIS on the website's configured port, usually 80 (HTTP) or 443 (HTTPS). The module forwards the requests to Kestrel on a random port for the app, which isn't port 80/443.

The module specifies the port via an environment variable at startup, and the IIS Integration Middleware configures the server to listen on `http://localhost:{port}`. Additional checks are performed, and requests that don't originate from the module are rejected. The module doesn't support HTTPS forwarding, so requests are forwarded over HTTP even if received by IIS over HTTPS.

After Kestrel picks up a request from the module, the request is pushed into the ASP.NET Core middleware pipeline. The middleware pipeline handles the request and passes it on as an `HttpContext` instance to the app's logic. The app's response is passed back to IIS, which pushes it back out to the HTTP client that initiated the request.

The ASP.NET Core Module has a few other functions. The module can:

* Set environment variables for the worker process.
* Log stdout output to file storage for troubleshooting startup issues.
* Forward Windows authentication tokens.

## How to install and use the ASP.NET Core Module

For detailed instructions on how to install and use the ASP.NET Core Module, see [Host on Windows with IIS](xref:host-and-deploy/iis/index). For information on configuring the module, see the [ASP.NET Core Module configuration reference](xref:host-and-deploy/aspnet-core-module).

## Additional resources

* [Host on Windows with IIS](xref:host-and-deploy/iis/index)
* [ASP.NET Core Module configuration reference](xref:host-and-deploy/aspnet-core-module)
* [ASP.NET Core Module GitHub repository (source code)](https://github.com/aspnet/AspNetCoreModule)
