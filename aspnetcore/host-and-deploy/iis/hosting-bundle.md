---
title: Hosting Bundle
author: rick-anderson
description: Learn how to configure the .NET Core Hosting Bundle.  
monikerRange: '>= aspnetcore-5.0'
ms.author: riande
ms.custom: mvc
ms.date: 02/07/2020
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: host-and-deploy/iis/hosting-bundle
---
# The .NET Core Hosting Bundle

The .NET Core Hosting bundle is an installer for the .NET Core Runtime and the [ASP.NET Core Module](xref:host-and-deploy/aspnet-core-module). The bundle allows ASP.NET Core apps to run with IIS.

## Install the .NET Core Hosting Bundle

> [!IMPORTANT]
> If the Hosting Bundle is installed before IIS, the bundle installation must be repaired. Run the Hosting Bundle installer again after installing IIS.
>
> If the Hosting Bundle is installed after installing the 64-bit (x64) version of .NET Core, SDKs might appear to be missing ([No .NET Core SDKs were detected](xref:test/troubleshoot#no-net-core-sdks-were-detected)). To resolve the problem, see <xref:test/troubleshoot#missing-sdk-after-installing-the-net-core-hosting-bundle>.

### Direct download (current version)

Download the installer using the following link:

[Current .NET Core Hosting Bundle installer (direct download)](https://dotnet.microsoft.com/permalink/dotnetcore-current-windows-runtime-bundle-installer)

### Earlier versions of the installer

To obtain an earlier version of the installer:

1. Navigate to the [Download .NET Core](https://dotnet.microsoft.com/download/dotnet-core) page.
1. Select the desired .NET Core version.
1. In the **Run apps - Runtime** column, find the row of the .NET Core runtime version desired.
1. Download the installer using the **Hosting Bundle** link.

> [!WARNING]
> Some installers contain release versions that have reached their end of life (EOL) and are no longer supported by Microsoft. For more information, see the [support policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-core).

### Install the Hosting Bundle

1. Run the installer on the server. The following parameters are available when running the installer from an administrator command shell:

   * `OPT_NO_ANCM=1`: Skip installing the ASP.NET Core Module.
   * `OPT_NO_RUNTIME=1`: Skip installing the .NET Core runtime. Used when the server only hosts [self-contained deployments (SCD)](/dotnet/core/deploying/#self-contained-deployments-scd).
   * `OPT_NO_SHAREDFX=1`: Skip installing the ASP.NET Shared Framework (ASP.NET runtime). Used when the server only hosts [self-contained deployments (SCD)](/dotnet/core/deploying/#self-contained-deployments-scd).
   * `OPT_NO_X86=1`: Skip installing x86 runtimes. Use this parameter when you know that you won't be hosting 32-bit apps. If there's any chance that you will host both 32-bit and 64-bit apps in the future, don't use this parameter and install both runtimes.
   * `OPT_NO_SHARED_CONFIG_CHECK=1`: Disable the check for using an IIS Shared Configuration when the shared configuration (`applicationHost.config`) is on the same machine as the IIS installation. *Only available for ASP.NET Core 2.2 or later Hosting Bundler installers.* For more information, see <xref:host-and-deploy/aspnet-core-module#aspnet-core-module-with-an-iis-shared-configuration>.
1. Restart the system or execute the following commands in a command shell:

   ```console
   net stop was /y
   net start w3svc
   ```
   Restarting IIS picks up a change to the system PATH, which is an environment variable, made by the installer.

ASP.NET Core doesn't adopt roll-forward behavior for patch releases of shared framework packages. After upgrading the shared framework by installing a new hosting bundle, restart the system or execute the following commands in a command shell:

```console
net stop was /y
net start w3svc
```

> [!NOTE]
> For information on IIS Shared Configuration, see [ASP.NET Core Module with IIS Shared Configuration](xref:host-and-deploy/aspnet-core-module#aspnet-core-module-with-an-iis-shared-configuration).

## Module version and Hosting Bundle installer logs

To determine the version of the installed ASP.NET Core Module:

1. On the hosting system, navigate to `%PROGRAMFILES%\IIS\Asp.Net Core Module\V2`.
1. Locate the `aspnetcorev2.dll` file.
1. Right-click the file and select **Properties** from the contextual menu.
1. Select the **Details** tab. The **File version** and **Product version** represent the installed version of the module.

The Hosting Bundle installer logs for the module are found at `C:\Users\%UserName%\AppData\Local\Temp`. The file is named `dd_DotNetCoreWinSvrHosting__{TIMESTAMP}_000_AspNetCoreModule_x64.log`, where the placeholder `{TIMESTAMP}` is the timestamp of the file.
