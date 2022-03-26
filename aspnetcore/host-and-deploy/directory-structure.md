---
title: ASP.NET Core directory structure
author: rick-anderson
description: Learn about the directory structure of published ASP.NET Core apps.
monikerRange: '>= aspnetcore-2.2'
ms.author: riande
ms.custom: mvc
ms.date: 04/09/2020
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: host-and-deploy/directory-structure
---
# ASP.NET Core directory structure

:::moniker range=">= aspnetcore-6.0"

The *publish* directory contains the app's deployable assets produced by the [dotnet publish](/dotnet/core/tools/dotnet-publish) command. The directory contains:

* Application files
* Configuration files
* Static assets
* Packages
* A runtime ([self-contained deployment](/dotnet/core/deploying/#self-contained-deployments-scd) only)

| App Type | Directory Structure |
| -------- | ------------------- |
| [Framework-dependent Executable (FDE)](/dotnet/core/deploying/#framework-dependent-executables-fde) | <ul><li>publish&dagger;<ul><li>Views&dagger; MVC apps; if views aren't precompiled</li><li>Pages&dagger; MVC or Razor Pages apps, if pages aren't precompiled</li><li>wwwroot&dagger;</li><li>\*.dll files</li><li>{ASSEMBLY NAME}.deps.json</li><li>{ASSEMBLY NAME}.dll</li><li>{ASSEMBLY NAME}{.EXTENSION}.exe extension on Windows, no extension on macOS or Linux</li><li>{ASSEMBLY NAME}.pdb</li><li>{ASSEMBLY NAME}.runtimeconfig.json</li><li>web.config (IIS deployments)</li><li>createdump ([Linux createdump utility](https://github.com/dotnet/coreclr/blob/master/Documentation/botr/xplat-minidump-generation.md#configurationpolicy))</li><li>\*.so (Linux shared object library)</li><li>\*.a (macOS archive)</li><li>\*.dylib (macOS dynamic library)</li></ul></li></ul> |
| [Self-contained Deployment (SCD)](/dotnet/core/deploying/#self-contained-deployments-scd) | <ul><li>publish&dagger;<ul><li>Views&dagger; MVC apps, if views aren't precompiled</li><li>Pages&dagger; MVC or Razor Pages apps, if pages aren't precompiled</li><li>wwwroot&dagger;</li><li>\*.dll files</li><li>{ASSEMBLY NAME}.deps.json</li><li>{ASSEMBLY NAME}.dll</li><li>{ASSEMBLY NAME}{.EXTENSION} .exe extension on Windows, no extension on macOS or Linux</li><li>{ASSEMBLY NAME}.pdb</li><li>{ASSEMBLY NAME}.runtimeconfig.json</li><li>web.config (IIS deployments)</li></ul></li></ul> |

&dagger;Indicates a directory

The *publish* directory represents the *content root path*, also called the *application base path*, of the deployment. Whatever name is given to the *publish* directory of the deployed app on the server, its location serves as the server's physical path to the hosted app.

The *wwwroot* directory, if present, only contains static assets.

## Additional resources

* [dotnet publish](/dotnet/core/tools/dotnet-publish)
* [.NET Core application deployment](/dotnet/core/deploying/)
* [Target frameworks](/dotnet/standard/frameworks)
* [.NET Core RID Catalog](/dotnet/core/rid-catalog)

:::moniker-end

:::moniker range=">= aspnetcore-3.0 < aspnetcore-6.0"

The *publish* directory contains the app's deployable assets produced by the [dotnet publish](/dotnet/core/tools/dotnet-publish) command. The directory contains:

* Application files
* Configuration files
* Static assets
* Packages
* A runtime ([self-contained deployment](/dotnet/core/deploying/#self-contained-deployments-scd) only)

| App Type | Directory Structure |
| -------- | ------------------- |
| [Framework-dependent Executable (FDE)](/dotnet/core/deploying/#framework-dependent-executables-fde) | <ul><li>publish&dagger;<ul><li>Views&dagger; MVC apps; if views aren't precompiled</li><li>Pages&dagger; MVC or Razor Pages apps, if pages aren't precompiled</li><li>wwwroot&dagger;</li><li>\*.dll files</li><li>{ASSEMBLY NAME}.deps.json</li><li>{ASSEMBLY NAME}.dll</li><li>{ASSEMBLY NAME}{.EXTENSION}.exe extension on Windows, no extension on macOS or Linux</li><li>{ASSEMBLY NAME}.pdb</li><li>{ASSEMBLY NAME}.Views.dll</li><li>{ASSEMBLY NAME}.Views.pdb</li><li>{ASSEMBLY NAME}.runtimeconfig.json</li><li>web.config (IIS deployments)</li><li>createdump ([Linux createdump utility](https://github.com/dotnet/coreclr/blob/master/Documentation/botr/xplat-minidump-generation.md#configurationpolicy))</li><li>\*.so (Linux shared object library)</li><li>\*.a (macOS archive)</li><li>\*.dylib (macOS dynamic library)</li></ul></li></ul> |
| [Self-contained Deployment (SCD)](/dotnet/core/deploying/#self-contained-deployments-scd) | <ul><li>publish&dagger;<ul><li>Views&dagger; MVC apps, if views aren't precompiled</li><li>Pages&dagger; MVC or Razor Pages apps, if pages aren't precompiled</li><li>wwwroot&dagger;</li><li>\*.dll files</li><li>{ASSEMBLY NAME}.deps.json</li><li>{ASSEMBLY NAME}.dll</li><li>{ASSEMBLY NAME}{.EXTENSION} .exe extension on Windows, no extension on macOS or Linux</li><li>{ASSEMBLY NAME}.pdb</li><li>{ASSEMBLY NAME}.Views.dll</li><li>{ASSEMBLY NAME}.Views.pdb</li><li>{ASSEMBLY NAME}.runtimeconfig.json</li><li>web.config (IIS deployments)</li></ul></li></ul> |

&dagger;Indicates a directory

The *publish* directory represents the *content root path*, also called the *application base path*, of the deployment. Whatever name is given to the *publish* directory of the deployed app on the server, its location serves as the server's physical path to the hosted app.

The *wwwroot* directory, if present, only contains static assets.

## Additional resources

* [dotnet publish](/dotnet/core/tools/dotnet-publish)
* [.NET Core application deployment](/dotnet/core/deploying/)
* [Target frameworks](/dotnet/standard/frameworks)
* [.NET Core RID Catalog](/dotnet/core/rid-catalog)

:::moniker-end

:::moniker range="< aspnetcore-3.0"

The *publish* directory contains the app's deployable assets produced by the [dotnet publish](/dotnet/core/tools/dotnet-publish) command. The directory contains:

* Application files
* Configuration files
* Static assets
* Packages
* A runtime ([self-contained deployment](/dotnet/core/deploying/#self-contained-deployments-scd) only)

| App Type | Directory Structure |
| -------- | ------------------- |
| [Framework-dependent Executable (FDE)](/dotnet/core/deploying/#framework-dependent-executables-fde) | <ul><li>publish&dagger;<ul><li>Views&dagger; MVC apps; if views aren't precompiled</li><li>Pages&dagger; MVC or Razor Pages apps, if pages aren't precompiled</li><li>wwwroot&dagger;</li><li>\*.dll files</li><li>{ASSEMBLY NAME}.deps.json</li><li>{ASSEMBLY NAME}.dll</li><li>{ASSEMBLY NAME}{.EXTENSION} .exe extension on Windows, no extension on macOS or Linux</li><li>{ASSEMBLY NAME}.pdb</li><li>{ASSEMBLY NAME}.Views.dll</li><li>{ASSEMBLY NAME}.Views.pdb</li><li>{ASSEMBLY NAME}.runtimeconfig.json</li><li>web.config (IIS deployments)</li><li>createdump ([Linux createdump utility](https://github.com/dotnet/coreclr/blob/master/Documentation/botr/xplat-minidump-generation.md#configurationpolicy))</li><li>\*.so (Linux shared object library)</li><li>\*.a (macOS archive)</li><li>\*.dylib (macOS dynamic library)</li></ul></li></ul> |
| [Self-contained Deployment (SCD)](/dotnet/core/deploying/#self-contained-deployments-scd) | <ul><li>publish&dagger;<ul><li>Views&dagger; MVC apps, if views aren't precompiled</li><li>Pages&dagger; MVC or Razor Pages apps, if pages aren't precompiled</li><li>wwwroot&dagger;</li><li>\*.dll files</li><li>{ASSEMBLY NAME}.deps.json</li><li>{ASSEMBLY NAME}.dll</li><li>{ASSEMBLY NAME}.exe</li><li>{ASSEMBLY NAME}.pdb</li><li>{ASSEMBLY NAME}.Views.dll</li><li>{ASSEMBLY NAME}.Views.pdb</li><li>{ASSEMBLY NAME}.runtimeconfig.json</li><li>web.config (IIS deployments)</li></ul></li></ul> |

&dagger;Indicates a directory

The *publish* directory represents the *content root path*, also called the *application base path*, of the deployment. Whatever name is given to the *publish* directory of the deployed app on the server, its location serves as the server's physical path to the hosted app.

The *wwwroot* directory, if present, only contains static assets.

Creating a *Logs* folder is useful for [ASP.NET Core Module enhanced debug logging](xref:host-and-deploy/iis/logging-and-diagnostics#enhanced-diagnostic-logs). Folders in the path provided to the `<handlerSetting>` value aren't created by the module automatically and should pre-exist in the deployment to allow the module to write the debug log.

A *Logs* directory can be created for the deployment using one of the following two approaches:

* Add the following `<Target>` element to the project file:

   ```xml
   <Target Name="CreateLogsFolder" AfterTargets="Publish">
     <MakeDir Directories="$(PublishDir)Logs" 
              Condition="!Exists('$(PublishDir)Logs')" />
     <WriteLinesToFile File="$(PublishDir)Logs\.log" 
                       Lines="Generated file" 
                       Overwrite="True" 
                       Condition="!Exists('$(PublishDir)Logs\.log')" />
   </Target>
   ```

   The `<MakeDir>` element creates an empty *Logs* folder in the published output. The element uses the `PublishDir` property to determine the target location for creating the folder. Several deployment methods, such as Web Deploy, skip empty folders during deployment. The `<WriteLinesToFile>` element generates a file in the *Logs* folder, which guarantees deployment of the folder to the server. Folder creation using this approach fails if the worker process doesn't have write access to the target folder.

* Physically create the *Logs* directory on the server in the deployment.

The deployment directory requires Read/Execute permissions. The *Logs* directory requires Read/Write permissions. Additional directories where files are written require Read/Write permissions.

## Additional resources

* [dotnet publish](/dotnet/core/tools/dotnet-publish)
* [.NET Core application deployment](/dotnet/core/deploying/)
* [Target frameworks](/dotnet/standard/frameworks)
* [.NET Core RID Catalog](/dotnet/core/rid-catalog)

:::moniker-end
