---
title: App Offline
author: rick-anderson
description: Learn how app_offline works with the ASP.NET Core Module.
monikerRange: '>= aspnetcore-5.0'
ms.author: riande
ms.custom: mvc
ms.date: 01/13/2020
no-loc: ["ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: host-and-deploy/iis/app-offline
---

# app_offline.htm

*app_offline.htm* is a file that is used by the ASP.NET Core Module to know if an app should be shutdown. 

If a file with the name *app_offline.htm* is detected in the root directory of an app, the ASP.NET Core Module attempts to gracefully shutdown the app and stop processing incoming requests. If the app is still running after the number of seconds defined in `shutdownTimeLimit`, the ASP.NET Core Module kills the running process.

While the *app_offline.htm* file is present, the ASP.NET Core Module responds to requests by sending back the contents of the *app_offline.htm* file. When the *app_offline.htm* file is removed, the next request starts the app.

When using the out-of-process hosting model, the app might not shut down immediately if there's an open connection. For example, a websocket connection may delay app shut down.

## Locked deployment files

Files in the deployment folder are locked when the app is running. Locked files can't be overwritten during deployment.

*app_offline.htm* is the primary mechanism to release locked files. *app_offline.htm* is used by Web Deploy to properly stop and start the app.

You can also manually use *app_offline* to start and stop the app as well (requires PowerShell 5 or later):

  ```powershell
  $pathToApp = 'PATH_TO_APP'

  # Stop the AppPool
  New-Item -Path $pathToApp app_offline.htm

  # Provide script commands here to deploy the app

  # Restart the AppPool
  Remove-Item -Path $pathToApp app_offline.htm

  ```

Files can also be unlocked by manually stopping the app pool in the IIS Manager on the server. You don't need to use *app_offine.htm* in this scenario.
