---
title: ASP.NET Core directory structure
author: guardrex
description: See the directory structure of published ASP.NET Core applications.
manager: wpickett
ms.author: riande
ms.custom: mvc
ms.date: 03/15/2017
ms.prod: asp.net-core
ms.technology: aspnet
ms.topic: article
uid: host-and-deploy/directory-structure
---
# Directory structure of published ASP.NET Core apps

By [Luke Latham](https://github.com/guardrex)

In ASP.NET Core, the application directory, *publish*, is comprised of application files, config files, static assets, packages, and the runtime (for self-contained apps).

| App Type                       | Directory Structure |
| ------------------------------ | ------------------- |
| Framework-dependent Deployment | <ul><li>publish\*<ul><li>logs\* (if included in publishOptions)</li><li>refs\*</li><li>runtimes\*</li><li>Views\* (if included in publishOptions)</li><li>wwwroot\* (if included in publishOptions)</li><li>.dll files</li><li>myapp.deps.json</li><li>myapp.dll</li><li>myapp.pdb</li><li>myapp.PrecompiledViews.dll (if precompiling Razor Views)</li><li>myapp.PrecompiledViews.pdb (if precompiling Razor Views)</li><li>myapp.runtimeconfig.json</li><li>web.config (if included in publishOptions)</li></ul></li></ul> |
| Self-contained Deployment      | <ul><li>publish\*<ul><li>logs\* (if included in publishOptions)</li><li>refs\*</li><li>Views\* (if included in publishOptions)</li><li>wwwroot\* (if included in publishOptions)</li><li>.dll files</li><li>myapp.deps.json</li><li>myapp.exe</li><li>myapp.pdb</li><li>myapp.PrecompiledViews.dll (if precompiling Razor Views)</li><li>myapp.PrecompiledViews.pdb (if precompiling Razor Views)</li><li>myapp.runtimeconfig.json</li><li>web.config (if included in publishOptions)</li></ul></li></ul> |
\* Indicates a directory

The contents of the *publish* directory represents the *content root path*, also called the *application base path*, of the deployment. Whatever name is given to the *publish* directory in the deployment, its location serves as the server's physical path to the hosted application. The *wwwroot* directory, if present, only contains static assets. The *logs* directory may be included in the deployment by creating it in the project and adding the `<Target>` element shown below to your *.csproj* file or by physically creating the directory on the server.

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

The deployment directory requires Read/Execute permissions, while the *Logs* directory requires Read/Write permissions. Additional directories where assets will be written require Read/Write permissions.
