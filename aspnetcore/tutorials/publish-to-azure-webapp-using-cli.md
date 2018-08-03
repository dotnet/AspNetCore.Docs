---
title: Publish an ASP.NET Core app to Azure with command line tools
author: camsoper
description: Learn how to publish an ASP.NET Core app to Azure App Service using the Git command line client.
ms.author: casoper
ms.custom: mvc
ms.date: 11/03/2017
services: multiple
uid: tutorials/publish-to-azure-webapp-using-cli
---

# Publish an ASP.NET Core app to Azure with command line tools

By [Cam Soper](https://twitter.com/camsoper)

[!INCLUDE [Azure App Service Preview Notice](../includes/azure-apps-preview-notice.md)]

This tutorial will show you how to build and deploy an ASP.NET Core app to Microsoft Azure App Service using command line tools. When finished, you'll have a Razor Pages web app built in ASP.NET Core hosted as an Azure App Service Web App. This tutorial is written using Windows command line tools, but can be applied to macOS and Linux environments, as well.

In this tutorial, you learn how to:

> [!div class="checklist"]
> * Create an Azure App Service website using Azure CLI
> * Deploy an ASP.NET Core app to Azure App Service using the Git command line tool

## Prerequisites

To complete this tutorial, you'll need:

* A [Microsoft Azure subscription](https://azure.microsoft.com/free/)
* [!INCLUDE [](~/includes/net-core-sdk-download-link.md)]
* [Git](https://www.git-scm.com/) command line client

## Create a web app

Create a new directory for the web app, create a new ASP.NET Core Razor Pages app, and then run the website locally.

# [Windows](#tab/windows)

::: moniker range=">= aspnetcore-2.1"

```console
REM Create a new ASP.NET Core Razor Pages app
dotnet new webapp -o MyApplication

REM Change to the new directory that was just created
cd MyApplication

REM Run the app
dotnet run
```

[!INCLUDE[](~/includes/webapp-alias-notice.md)]

::: moniker-end

::: moniker range="= aspnetcore-2.0"

```console
REM Create a new ASP.NET Core Razor Pages app
dotnet new razor -o MyApplication

REM Change to the new directory that was just created
cd MyApplication

REM Run the app
dotnet run
```

::: moniker-end

# [Other](#tab/other)

::: moniker range=">= aspnetcore-2.1"

```bash
# Create a new ASP.NET Core Razor Pages app
dotnet new webapp -o MyApplication

# Change to the new directory that was just created
cd MyApplication

# Run the app
dotnet run
```

[!INCLUDE[](~/includes/webapp-alias-notice.md)]

::: moniker-end

::: moniker range="= aspnetcore-2.0"

```bash
# Create a new ASP.NET Core Razor Pages app
dotnet new razor -o MyApplication

# Change to the new directory that was just created
cd MyApplication

# Run the app
dotnet run
```

::: moniker-end

---

![Command line output](publish-to-azure-webapp-using-cli/_static/new_prj.png)

Test the app by browsing to `http://localhost:5000`.

![The website running locally](publish-to-azure-webapp-using-cli/_static/app_test.png)

## Create the Azure App Service instance

Using the [Azure Cloud Shell](/azure/cloud-shell/quickstart), create a resource group, App Service plan, and an App Service web app.

```azurecli-interactive
# Generate a unique Web App name
let randomNum=$RANDOM*$RANDOM
webappname=tutorialApp$randomNum

# Create the DotNetAzureTutorial resource group
az group create --name DotNetAzureTutorial --location EastUS

# Create an App Service plan.
az appservice plan create --name $webappname --resource-group DotNetAzureTutorial --sku FREE

# Create the Web App
az webapp create --name $webappname --resource-group DotNetAzureTutorial --plan $webappname
```

Before deployment, set the account-level deployment credentials using the following command:

```azurecli-interactive
az webapp deployment user set --user-name <desired user name> --password <desired password>
```

A deployment URL is needed to deploy the app using Git. Retrieve the URL like this.

```azurecli-interactive
az webapp deployment source config-local-git -n $webappname -g DotNetAzureTutorial --query [url] -o tsv
```

Note the displayed URL ending in `.git`. It's used in the next step.

## Deploy the app using Git

You're ready to deploy from your local machine using Git.

> [!NOTE]
> It's safe to ignore any warnings from Git about line endings.

# [Windows](#tab/windows)

```cmd
REM Initialize the local Git repository
git init

REM Add the contents of the working directory to the repo
git add --all

REM Commit the changes to the local repo
git commit -a -m "Initial commit"

REM Add the URL as a Git remote repository
git remote add azure <THE GIT URL YOU NOTED EARLIER>

REM Push the local repository to the remote
git push azure master
```

# [Other](#tab/other)

```bash
# Initialize the local Git repository
git init

# Add the contents of the working directory to the repo
git add --all

# Commit the changes to the local repo
git commit -a -m "Initial commit"

# Add the URL as a Git remote repository
git remote add azure <THE GIT URL YOU NOTED EARLIER>

# Push the local repository to the remote
git push azure master
```

---

Git prompts for the deployment credentials that were set earlier. After authenticating, the app will be pushed to the remote location, built, and deployed.

![Git deployment output](publish-to-azure-webapp-using-cli/_static/post_deploy.png)

## Test the app

Test the app by browsing to `https://<web app name>.azurewebsites.net`. To display the address in the Cloud Shell (or Azure CLI), use the following:

```azurecli-interactive
az webapp show -n $webappname -g DotNetAzureTutorial --query defaultHostName -o tsv
```

![The app running in Azure](publish-to-azure-webapp-using-cli/_static/app_deployed.png)

## Clean up

When finished testing the app and inspecting the code and resources, delete the web app and plan by deleting the resource group.

```azurecli-interactive
az group delete -n DotNetAzureTutorial
```

## Next steps

In this tutorial, you learned how to:

> [!div class="checklist"]
> * Create an Azure App Service website using Azure CLI
> * Deploy an ASP.NET Core app to Azure App Service using the Git command line tool

Next, learn to use the command line to deploy an existing web app that uses CosmosDB.

> [!div class="nextstepaction"]
> [Deploy to Azure from the command line with .NET Core](/dotnet/azure/dotnet-quickstart-xplat)
