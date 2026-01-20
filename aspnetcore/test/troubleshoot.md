---
title: Troubleshoot and debug ASP.NET Core projects
author: tdykstra
description: Understand and troubleshoot warnings and errors with ASP.NET Core projects.
ms.author: tdykstra
ms.custom: mvc
ms.date: 5/2/2025
uid: test/troubleshoot
---
# Troubleshoot and debug ASP.NET Core projects

:::moniker range=">= aspnetcore-6.0"

By [Rick Anderson](https://twitter.com/RickAndMSFT)

The following links provide troubleshooting guidance:

* <xref:test/troubleshoot-azure-iis>
* <xref:host-and-deploy/azure-iis-errors-reference>
* [NDC Conference (London, 2018): Diagnosing issues in ASP.NET Core Applications](https://www.youtube.com/watch?v=RYI0DHoIVaA)
* [ASP.NET Blog: Troubleshooting ASP.NET Core Performance Problems](https://blogs.msdn.microsoft.com/webdev/2018/05/23/asp-net-core-performance-improvements/)

## .NET Core SDK warnings

### Both the 32-bit and 64-bit versions of the .NET Core SDK are installed

In the **New Project** dialog for ASP.NET Core, you may see the following warning:

> Both 32-bit and 64-bit versions of the .NET Core SDK are installed. Only templates from the 64-bit versions installed at 'C:\\Program Files\\dotnet\\sdk\\' are displayed.

This warning appears when both 32-bit (x86) and 64-bit (x64) versions of the [.NET Core SDK](https://dotnet.microsoft.com/download/dotnet-core) are installed. Common reasons both versions may be installed include:

* You originally downloaded the .NET Core SDK installer using a 32-bit machine but then copied it across and installed it on a 64-bit machine.
* The 32-bit .NET Core SDK was installed by another application.
* The wrong version was downloaded and installed.

Uninstall the 32-bit .NET Core SDK to prevent this warning. Uninstall from **Control Panel** > **Programs and Features** > **Uninstall or change a program**. If you understand why the warning occurs and its implications, you can ignore the warning.

### The .NET Core SDK is installed in multiple locations

In the **New Project** dialog for ASP.NET Core, you may see the following warning:

> The .NET Core SDK is installed in multiple locations. Only templates from the SDKs installed at 'C:\\Program Files\\dotnet\\sdk\\' are displayed.

You see this message when you have at least one installation of the .NET Core SDK in a directory outside of *C:\\Program Files\\dotnet\\sdk\\*. Usually this happens when the .NET Core SDK has been deployed on a machine using copy/paste instead of the MSI installer.

Uninstall all 32-bit .NET Core SDKs and runtimes to prevent this warning. Uninstall from **Control Panel** > **Programs and Features** > **Uninstall or change a program**. If you understand why the warning occurs and its implications, you can ignore the warning.

### No .NET Core SDKs were detected

* In the Visual Studio **New Project** dialog for ASP.NET Core, you may see the following warning:

  > No .NET Core SDKs were detected, ensure they are included in the environment variable `PATH`.

* When executing a `dotnet` command, the warning appears as:

  > It was not possible to find any installed dotnet SDKs.

These warnings appear when the environment variable `PATH` doesn't point to any .NET Core SDKs on the machine. To resolve this problem:

* Install the .NET Core SDK. Obtain the latest installer from [.NET Downloads](https://dotnet.microsoft.com/download).
* Verify that the `PATH` environment variable points to the location where the SDK is installed (`C:\Program Files\dotnet\` for 64-bit/x64 or `C:\Program Files (x86)\dotnet\` for 32-bit/x86). The SDK installer normally sets the `PATH`. Always install the same bitness SDKs and runtimes on the same machine.

### Missing SDK after installing the .NET Core Hosting Bundle

Installing the [.NET Core Hosting Bundle](xref:host-and-deploy/iis/index#install-the-net-core-hosting-bundle) modifies the `PATH` when it installs the .NET Core runtime to point to the 32-bit (x86) version of .NET Core (`C:\Program Files (x86)\dotnet\`). This can result in missing SDKs when the 32-bit (x86) .NET Core `dotnet` command is used ([No .NET Core SDKs were detected](#no-net-core-sdks-were-detected)). To resolve this problem, move `C:\Program Files\dotnet\` to a position before `C:\Program Files (x86)\dotnet\` on the `PATH`.

## Obtain data from an app

If an app is capable of responding to requests, you can obtain the following data from the app using middleware:

* Request: Method, scheme, host, pathbase, path, query string, headers
* Connection: Remote IP address, remote port, local IP address, local port, client certificate
* Identity: Name, display name
* Configuration settings
* Environment variables

Place the following [middleware](xref:fundamentals/middleware/index#create-a-middleware-pipeline-with-iapplicationbuilder) code at the beginning of the `Startup.Configure` method's request processing pipeline. The environment is checked before the middleware is run to ensure that the code is only executed in the `Development` environment.

Get the environment from the `Environment` property of `WebApplication`. For example, `if (app.Environment.IsDevelopment())` as in the following sample code.

:::code language="csharp" source="~/test/troubleshoot/code/9.x/Program.cs" highlight="13-85":::

## Debug ASP.NET Core apps

The following links provide information on debugging ASP.NET Core apps.

* [Debugging ASP Core on Linux](https://devblogs.microsoft.com/premier-developer/debugging-asp-core-on-linux-with-visual-studio-2017/)
* [Debugging .NET Core on Unix over SSH](https://devblogs.microsoft.com/devops/debugging-net-core-on-unix-over-ssh/)
* [Quickstart: Debug ASP.NET with the Visual Studio debugger](/visualstudio/debugger/quickstart-debug-aspnet)
* See [this GitHub issue](https://github.com/dotnet/AspNetCore.Docs/issues/2960) for more debugging information.

:::moniker-end

[!INCLUDE[](~/test/troubleshoot/includes/troubleshoot5.md)]
