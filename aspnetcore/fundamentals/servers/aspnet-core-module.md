---
title: ASP.NET Core Module
author: guardrex
description: Learn how the ASP.NET Core Module allows the Kestrel web server to use IIS or IIS Express.
ms.author: tdykstra
ms.custom: mvc
ms.date: 11/30/2018
uid: fundamentals/servers/aspnet-core-module
---
# ASP.NET Core Module

By [Tom Dykstra](https://github.com/tdykstra), [Rick Strahl](https://github.com/RickStrahl), and [Chris Ross](https://github.com/Tratcher)

::: moniker range=">= aspnetcore-2.2"

The ASP.NET Core Module allows ASP.NET Core apps to run in an IIS worker process (*in-process*) or behind IIS in a reverse proxy configuration (*out-of-process*). IIS provides advanced web app security and manageability features.

::: moniker-end

::: moniker range="< aspnetcore-2.2"

The ASP.NET Core Module allows ASP.NET Core apps to run behind IIS in a reverse proxy configuration. IIS provides advanced web app security and manageability features.

::: moniker-end

Supported Windows versions:

* Windows 7 or later
* Windows Server 2008 R2 or later

::: moniker range=">= aspnetcore-2.2"

When hosting in-process, the module uses an IIS in-process server implementation, IIS HTTP Server (`IISHttpServer`).

When hosting out-of-process, the module only works with Kestrel. The module is incompatible with [HTTP.sys](xref:fundamentals/servers/httpsys) (formerly called [WebListener](xref:fundamentals/servers/weblistener)).

::: moniker-end

::: moniker range="< aspnetcore-2.2"

The module only works with Kestrel. The module is incompatible with [HTTP.sys](xref:fundamentals/servers/httpsys) (formerly called [WebListener](xref:fundamentals/servers/weblistener)).

::: moniker-end

## ASP.NET Core Module description

::: moniker range=">= aspnetcore-2.2"

The ASP.NET Core Module is a native IIS module that plugs into the IIS pipeline to either:

* Host an ASP.NET Core app inside of the IIS worker process (`w3wp.exe`), called the [in-process hosting model](#in-process-hosting-model).

* Forward web requests to a backend ASP.NET Core app running the [Kestrel server](xref:fundamentals/servers/kestrel), called the [out-of-process hosting model](#out-of-process-hosting-model).

### In-process hosting model

Using in-process hosting, an ASP.NET Core app runs in the same process as its IIS worker process. This removes the performance penalty of proxying requests over the loopback adapter when using the out-of-process hosting model. IIS handles process management with the [Windows Process Activation Service (WAS)](/iis/manage/provisioning-and-managing-iis/features-of-the-windows-process-activation-service-was).

The ASP.NET Core Module:

* Performs app initialization.
  * Loads the [CoreCLR](/dotnet/standard/glossary#coreclr).
  * Calls `Program.Main`.
* Handles the lifetime of the IIS native request.

The following diagram illustrates the relationship between IIS, the ASP.NET Core Module, and an app hosted in-process:

![ASP.NET Core Module](aspnet-core-module/_static/ancm-inprocess.png)

A request arrives from the web to the kernel-mode HTTP.sys driver. The driver routes the native request to IIS on the website's configured port, usually 80 (HTTP) or 443 (HTTPS). The module receives the native request and passes it to IIS HTTP Server (`IISHttpServer`). IIS HTTP Server is an IIS in-process server implementation that converts the request from native to managed.

After the IIS HTTP Server processes the request, the request is pushed into the ASP.NET Core middleware pipeline. The middleware pipeline handles the request and passes it on as an `HttpContext` instance to the app's logic. The app's response is passed back to IIS, which pushes it back out to the client that initiated the request.

### Out-of-process hosting model

Because ASP.NET Core apps run in a process separate from the IIS worker process, the module handles process management. The module starts the process for the ASP.NET Core app when the first request arrives and restarts the app if it shuts down or crashes. This is essentially the same behavior as seen with apps that run in-process that are managed by the [Windows Process Activation Service (WAS)](/iis/manage/provisioning-and-managing-iis/features-of-the-windows-process-activation-service-was).

The following diagram illustrates the relationship between IIS, the ASP.NET Core Module, and an app hosted out-of-process:

![ASP.NET Core Module](aspnet-core-module/_static/ancm-outofprocess.png)

Requests arrive from the web to the kernel-mode HTTP.sys driver. The driver routes the requests to IIS on the website's configured port, usually 80 (HTTP) or 443 (HTTPS). The module forwards the requests to Kestrel on a random port for the app, which isn't port 80/443.

The module specifies the port via an environment variable at startup, and the IIS Integration Middleware configures the server to listen on `http://localhost:{port}`. Additional checks are performed, and requests that don't originate from the module are rejected. The module doesn't support HTTPS forwarding, so requests are forwarded over HTTP even if received by IIS over HTTPS.

After Kestrel picks up the request from the module, the request is pushed into the ASP.NET Core middleware pipeline. The middleware pipeline handles the request and passes it on as an `HttpContext` instance to the app's logic. Middleware added by IIS Integration updates the scheme, remote IP, and pathbase to account for forwarding the request to Kestrel. The app's response is passed back to IIS, which pushes it back out to the HTTP client that initiated the request.

::: moniker-end

::: moniker range="< aspnetcore-2.2"

The ASP.NET Core Module is a native IIS module that plugs into the IIS pipeline to forward web requests to backend ASP.NET Core apps.

Because ASP.NET Core apps run in a process separate from the IIS worker process, the module also handles process management. The module starts the process for the ASP.NET Core app when the first request arrives and restarts the app if it crashes. This is essentially the same behavior as seen with ASP.NET 4.x apps that run in-process in IIS that are managed by the [Windows Process Activation Service (WAS)](/iis/manage/provisioning-and-managing-iis/features-of-the-windows-process-activation-service-was).

The following diagram illustrates the relationship between IIS, the ASP.NET Core Module, and an app:

![ASP.NET Core Module](aspnet-core-module/_static/ancm-outofprocess.png)

Requests arrive from the web to the kernel-mode HTTP.sys driver. The driver routes the requests to IIS on the website's configured port, usually 80 (HTTP) or 443 (HTTPS). The module forwards the requests to Kestrel on a random port for the app, which isn't port 80/443.

The module specifies the port via an environment variable at startup, and the IIS Integration Middleware configures the server to listen on `http://localhost:{port}`. Additional checks are performed, and requests that don't originate from the module are rejected. The module doesn't support HTTPS forwarding, so requests are forwarded over HTTP even if received by IIS over HTTPS.

After Kestrel picks up the request from the module, the request is pushed into the ASP.NET Core middleware pipeline. The middleware pipeline handles the request and passes it on as an `HttpContext` instance to the app's logic. Middleware added by IIS Integration updates the scheme, remote IP, and pathbase to account for forwarding the request to Kestrel. The app's response is passed back to IIS, which pushes it back out to the HTTP client that initiated the request.

::: moniker-end

Many native modules, such as Windows Authentication, remain active. To learn more about IIS modules active with the module, see <xref:host-and-deploy/iis/modules>.

The ASP.NET Core Module has a few other functions. The module can:

* Set environment variables for the worker process.
* Log stdout output to file storage for troubleshooting startup issues.
* Forward Windows authentication tokens.

## How to install and use the ASP.NET Core Module

For detailed instructions on how to install and use the ASP.NET Core Module, see <xref:host-and-deploy/iis/index>. For information on configuring the module, see the <xref:host-and-deploy/aspnet-core-module>.

## Additional resources

* <xref:host-and-deploy/iis/index>
* <xref:host-and-deploy/aspnet-core-module>
* [ASP.NET Core Module GitHub repository (source code)](https://github.com/aspnet/AspNetCoreModule)
* <xref:host-and-deploy/iis/modules>
