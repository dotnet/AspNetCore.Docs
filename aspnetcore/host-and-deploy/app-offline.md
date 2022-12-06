---
title: App Offline file (app_offline.htm)
author: rick-anderson
description: Learn how the App Offline file (`app_offline.htm`) works with the ASP.NET Core Module.
monikerRange: '>= aspnetcore-5.0'
ms.author: riande
ms.custom: mvc
ms.date: 1/13/2020
uid: host-and-deploy/iis/app-offline
---
# App Offline file (`app_offline.htm`)

The App Offline file (`app_offline.htm`) is used by the ASP.NET Core Module to shut down an app.

If a file with the name `app_offline.htm` is detected in the root directory of an app, the ASP.NET Core Module attempts to gracefully shut down the app and stop processing incoming requests. If the app is still running after the number of seconds defined in `shutdownTimeLimit`, the ASP.NET Core Module stops the running process.

While the `app_offline.htm` file is present, the ASP.NET Core Module responds to requests by sending back the contents of the `app_offline.htm` file. The `app_offline.htm` must be less than 4 GB. When the `app_offline.htm` file is removed, the next request starts the app.

When using the out-of-process hosting model, the app might not shut down immediately if there's an open connection. For example, a WebSocket connection may delay app shut down.

## Locked deployment files

Files in the deployment folder are locked when the app is running. Locked files can't be overwritten during deployment.

`app_offline.htm` is the primary mechanism to release locked files. `app_offline.htm` is used by Web Deploy to properly stop and start the app.

`app_offline.htm` can be manually used to start and stop the app (requires PowerShell 5 or later):

```powershell
$pathToApp = '{PATH TO APP}'


New-Item -Path $pathToApp -Name "app_offline.htm" -ItemType "file"

# Provide script commands here to deploy the app

Remove-Item -Path $pathToApp\app_offline.htm
```

In the preceding PowerShell script:

* The placeholder `{PATH TO APP}` is the path to the app.
* The `New-Item` command stops the app pool.
* The `Remove-Item` command starts the app pool.
* Commands between the `New-Item` command and the `Remove-Item` command are provided by the developer to deploy the app.

Files can also be unlocked by manually stopping the app pool in the IIS Manager on the server. Don't use the `app_offline.htm` file when using the IIS Manager to stop and restart the app pool.
