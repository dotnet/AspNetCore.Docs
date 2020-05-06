---
title: Tools and downloads - DevOps with ASP.NET Core and Azure 
author: CamSoper
description: Tools and downloads required for DevOps with ASP.NET Core and Azure.
ms.author: casoper
ms.custom: "mvc, seodec18"
ms.date: 10/24/2018
no-loc: [Blazor, "Identity", "Let's Encrypt", Razor, SignalR]
uid: azure/devops/tools-and-downloads
---
# Tools and downloads

Azure has several interfaces for provisioning and managing resources, such as the [Azure portal](https://portal.azure.com), [Azure CLI](/cli/azure/), [Azure PowerShell](/powershell/azure/overview), [Azure Cloud Shell](https://shell.azure.com/bash), and Visual Studio. This guide takes a minimalist approach and uses the Azure Cloud Shell whenever possible to reduce the steps required. However, the Azure portal must be used for some portions.

## Prerequisites

The following subscriptions are required:

* Azure &mdash; If you don't have an account, [get a free trial](https://azure.microsoft.com/free/dotnet/).
* Azure DevOps Services &mdash; your Azure DevOps subscription and organization is created in Chapter 4.
* GitHub &mdash; If you don't have an account, [sign up for free](https://github.com/join).

The following tools are required:

* [Git](https://git-scm.com/downloads) &mdash; A fundamental understanding of Git is recommended for this guide. Review the [Git documentation](https://git-scm.com/doc), specifically [git remote](https://git-scm.com/docs/git-remote) and [git push](https://git-scm.com/docs/git-push).
* [.NET Core SDK](https://dotnet.microsoft.com/download/) &mdash; Version 2.1.300 or later is required to build and run the sample app. If Visual Studio is installed with the **.NET Core cross-platform development** workload, the .NET Core SDK is already installed.

    Verify your .NET Core SDK installation. Open a command shell, and run the following command:

    ```dotnetcli
    dotnet --version
    ```

## Recommended tools (Windows only)

* [Visual Studio](https://visualstudio.microsoft.com)'s robust Azure tools provide a GUI for most of the functionality described in this guide. Any edition of Visual Studio will work, including the free Visual Studio Community Edition. The tutorials are written to demonstrate development, deployment, and DevOps both with and without Visual Studio.

  Confirm that Visual Studio has the following [workloads](/visualstudio/install/modify-visual-studio) installed:

  * ASP.NET and web development
  * Azure development
  * .NET Core cross-platform development
