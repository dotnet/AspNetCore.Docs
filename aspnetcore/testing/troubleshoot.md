---
title: Troubleshoot for ASP.NET Core
author: Rick-Anderson
description: Understand and troubleshoot warnings and errors with ASP.NET Core projects.
manager: wpickett
ms.author: riande
ms.date: 4/5/2018
ms.prod: asp.net-core
ms.technology: aspnet
ms.topic: content
uid: testing/troubleshoot
---
# Troubleshoot ASP.NET Core projects

By [Rick Anderson](https://twitter.com/RickAndMSFT)

## .NET Core SDK  Warnings

### Both the 32 and 64 bit versions of the .NET Core SDK are installed
In the **New Project** dialog for ASP.NET Core you may see the following warning appear at the top: 

    Both 32 and 64 bit versions of the .NET Core SDK are installed. Only templates from the 64 bit version(s) installed at C:\Program Files\dotnet\sdk\" will be displayed.

![A screenshot of the OneASP.NET dialog showing the warning message](troubleshoot/_static/both32and64bit.png)

This warning appears when both 32 bit (x86) and 64 bit (x64) versions of the [.NET Core SDK](https://www.microsoft.com/net/download/all) are installed. Common reasons both versions can be installed include:

* You originally downloaded the .NET Core SDK installer using a 32 bit machine, but then copied it across and installed it on a 64 bit machine. 
* The 32 bit .NET Core SDK was installed by another application.
* The wrong version was downloaded and installed.

To 
If you understand why you are seeing this warning and you are not interested in making it go away, you can safely ignore it. If you are interested in making it go away, all you have to do is uninstall any 32 bit versions of the .NET Core SDK installed on the machine. You can use Control Panel | Programs and Features | Uninstall or change a program to do that.

### The .NET Core SDK is installed in multiple locations
In the "New Project" dialog for ASP.NET Core you may see the following warning appear at the top: "The .NET Core SDK is installed in multiple locations. Only templates from the SDK(s) installed at 'C:\Program Files\dotnet\sdk\' will be displayed."

![A screenshot of the OneASP.NET dialog showing the warning message](troubleshoot/_static/multiplelocations.png)


You are seeing this message because you have at least one installation of the .NET Core SDK in a directory outside of 'C:\Program Files\dotnet\sdk\'. Usually that happens when the .NET Core SDK has been deployed on a machine using copy/paste instead of the MSI installer.

If you understand why you are seeing this warning and you are not interested in making it go away, you can safely ignore it. If you are interested in making it go away, all you have to do is remove any installations of the .NET Core SDK that exist outside of 'C:\Program Files\dotnet\sdk\'. The specific file we look for in order to display the warning is 'dotnet.dll'.
