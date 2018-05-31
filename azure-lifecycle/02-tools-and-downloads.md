# Tools and downloads

## Overview

Azure has multiple interfaces for provisioning and managing resources, such as the [Azure portal](https://portal.azure.com), [Azure CLI](https://docs.microsoft.com/cli/azure/?view=azure-cli-latest), [Azure PowerShell](https://docs.microsoft.com/en-us/powershell/azure/overview?view=azurermps-6.0.0), [Azure Cloud Shell](https://shell.azure.com/bash), and Visual Studio. This guide takes a minimalist approach and uses the Azure Cloud Shell whenever possible to reduce the steps required. However, the Azure portal must be used for some portions.

## Prerequisites

The following subscriptions are required:

* Azure &mdash; If you don't have an account, [get a free trial](https://azure.microsoft.com/free/).
* Visual Studio Team Services (VSTS) &mdash; We'll create this in Chapter 4.
* GitHub &mdash; If you don't have an account, [sign up for free](https://github.com/join).

The following tools are required:

* [Git](https://git-scm.com/downloads)
* [.NET Core SDK](https://www.microsoft.com/net/download/) &mdash; Version 2.0 or later is required to build and run the sample app. If Visual Studio is installed with the **.NET Core cross-platform development** workload, the .NET Core SDK is already installed.

    Verify your .NET Core SDK installation. Open a command shell, and run the following command:

    ```console
    dotnet --version
    ```

## Recommended tools (Windows only)

* [Visual Studio](https://www.visualstudio.com/)'s robust Azure tools provide a GUI for most of the functionality described in this guide. Any edition of Visual Studio will work, including the free Visual Studio Community Edition. The tutorials are written to demonstrate development, deployment, and DevOps both with and without Visual Studio.

    Ensure that Visual Studio has the following [workloads](https://docs.microsoft.com/visualstudio/install/modify-visual-studio) installed:

    * ASP.NET and web development
    * Azure development
    * .NET Core cross-platform development
