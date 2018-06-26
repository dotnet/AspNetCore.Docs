---
title: ASP.NET Core directory structure
author: guardrex
description: Learn about the directory structure of published ASP.NET Core apps.
ms.author: riande
ms.custom: mvc
ms.date: 04/09/2018
uid: host-and-deploy/directory-structure
---
# ASP.NET Core directory structure

By [Luke Latham](https://github.com/guardrex)

In ASP.NET Core, the published application directory, *publish*, is comprised of application files, config files, static assets, packages, and the runtime (for [self-contained deployments](/dotnet/core/deploying/#self-contained-deployments-scd)).


| App Type | Directory Structure |
| -------- | ------------------- |
| [Framework-dependent Deployment](/dotnet/core/deploying/#framework-dependent-deployments-fdd) | <ul><li>publish&dagger;<ul><li>Logs&dagger; (optional unless required to receive stdout logs)</li><li>Views&dagger; (MVC apps; if views aren't precompiled)</li><li>Pages&dagger; (MVC or Razor Pages apps; if pages aren't precompiled)</li><li>wwwroot&dagger;</li><li>*\.dll files</li><li>\<assembly-name>.deps.json</li><li>\<assembly-name>.dll</li><li>\<assembly-name>.pdb</li><li>\<assembly-name>.PrecompiledViews.dll</li><li>\<assembly-name>.PrecompiledViews.pdb</li><li>\<assembly-name>.runtimeconfig.json</li><li>web.config (IIS deployments)</li></ul></li></ul> |
| [Self-contained Deployment](/dotnet/core/deploying/#self-contained-deployments-scd) | <ul><li>publish&dagger;<ul><li>Logs&dagger; (optional unless required to receive stdout logs)</li><li>refs&dagger;</li><li>Views&dagger; (MVC apps; if views aren't precompiled)</li><li>Pages&dagger; (MVC or Razor Pages apps; if pages aren't precompiled)</li><li>wwwroot&dagger;</li><li>\*.dll files</li><li>\<assembly-name>.deps.json</li><li>\<assembly-name>.exe</li><li>\<assembly-name>.pdb</li><li>\<assembly-name>.PrecompiledViews.dll</li><li>\<assembly-name>.PrecompiledViews.pdb</li><li>\<assembly-name>.runtimeconfig.json</li><li>web.config (IIS deployments)</li></ul></li></ul> |

&dagger;Indicates a directory

The *publish* directory represents the *content root path*, also called the *application base path*, of the deployment. Whatever name is given to the *publish* directory of the deployed app on the server, its location serves as the server's physical path to the hosted app.

The *wwwroot* directory, if present, only contains static assets.

The stdout *Logs* directory can be created for the deployment using one of the following two approaches:

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

   The `<MakeDir>` element creates an empty *Logs* folder in the published output. The element uses the `PublishDir` property to determine the target location for creating the folder. Several deployment methods, such as Web Deploy, skip empty folders during deployment. The `<WriteLinesToFile>` element generates a file in the *Logs* folder, which guarantees deployment of the folder to the server. Note that folder creation may still fail if the worker process doesn't have write access to the target folder.

* Physically create the *Logs* directory on the server in the deployment.

The deployment directory requires Read/Execute permissions. The *Logs* directory requires Read/Write permissions. Additional directories where files are written require Read/Write permissions.
