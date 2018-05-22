# Tools and Downloads

## Overview

Azure has multiple interfaces for provisioning and managing resources, such as the [Azure portal](https://portal.azure.com), [Azure CLI](https://docs.microsoft.com/cli/azure/?view=azure-cli-latest), [Azure PowerShell](https://docs.microsoft.com/en-us/powershell/azure/overview?view=azurermps-6.0.0), [Azure Cloud Shell](https://shell.azure.com/bash), and Visual Studio. This guide takes a minimalist approach and uses the Azure Cloud Shell whenever possible to reduce the steps required. However, the Portal must be used for some portions.

## Required tools and subscriptions

* An Azure account. If you don't have one, [get a free trial](https://azure.microsoft.com/free/).
* [Git](https://git-scm.com/) is required to download and deploy the sample application.
* [.NET Core SDK](https://www.microsoft.com/net/learn/get-started) 2.0 or greater is required to build and run the sample application. If Visual Studio is installed with the *.NET Core cross-platform development* workload, the .NET Core SDK is already installed.
    
    Verify your installation with the following command:
    
    ```bash
    dotnet --version
    ``` 

## Recommended tools (Windows only)

* [Visual Studio](https://www.visualstudio.com/)'s robust Azure tools provide a GUI for most of the functionality described in this guide. Any edition of Visual Studio will work, including the free Visual Studio Community Edition. The tutorials have been written to demonstrate development, deployment, and continuous integration both with and without Visual Studio.
    
    Ensure that Visual Studio has the following [workloads](https://docs.microsoft.com/visualstudio/install/modify-visual-studio) installed:
    
    * ASP.NET and web development
    * Azure development
    * .NET Core cross-platform development
