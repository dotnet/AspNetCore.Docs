---
title: Publish an ASP.NET Core app to Azure with Visual Studio Code
author: rick-anderson
description: Learn how to publish an ASP.NET Core app to Azure App Service using Visual Studio Code
monikerRange: '>= aspnetcore-6.0'
ms.author: riserrad
ms.custom: "devx-track-csharp, mvc, vscode-azure-extension-update-completed"
ms.date: 08/23/2022
uid: tutorials/publish-to-azure-webapp-using-vscode
---

# Publish an ASP.NET Core app to Azure with Visual Studio Code

By [Ricardo Serradas](https://twitter.com/ricardoserradas)

[!INCLUDE [Azure App Service Preview Notice](../includes/azure-apps-preview-notice.md)]

To troubleshoot an App Service deployment issue, see <xref:test/troubleshoot-azure-iis>.

## Intro

With this tutorial, you'll learn how to create an ASP.Net Core MVC Application
and deploy it within Visual Studio Code.

## Set up

- Open a [free Azure account](https://azure.microsoft.com/free/dotnet/) if you don't have one.
- Install [.NET Core SDK](https://dotnet.microsoft.com/download)
- Install [Visual Studio Code](https://code.visualstudio.com/Download)
  - Install the [C# Extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) to Visual Studio Code
  - Install the [Azure App Service Extension](https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-azureappservice)
  to Visual Studio Code and configure it before proceeding

## Create an ASP.Net Core MVC project

The tutorial assumes familiarity with VS Code. For more information, see [Getting started with VS Code](https://code.visualstudio.com/docs).

- Open the [integrated terminal](https://code.visualstudio.com/docs/editor/integrated-terminal).
- Change to the directory (`cd`) that will contain the project.
- Run the following command:

   ```dotnetcli
   dotnet new mvc -o MyMVCapp
   code -r MyMVCapp
   ```

  If a dialog box appears with **Required assets to build and debug are missing from 'MvcMovie'. Add them?**, select **Yes**

- `dotnet new mvc -o MvcMovie`: Creates a new ASP.NET Core MVC project in the *MvcMovie* folder.
- `code -r MvcMovie`:
  - Loads the `MvcMovie.csproj` project file in Visual Studio Code.
  - Visual Studio Code updates the integrated terminal to the project directory.

A new ASP.NET Core MVC project is created in a *MyMVCapp* folder with a structure similar to the following:

```cmd
      appsettings.Development.json
      appsettings.json
<DIR> bin
<DIR> Controllers
<DIR> Models
      MyMVCapp.csproj
<DIR> obj
      Program.cs
<DIR> Properties
<DIR> Views
<DIR> wwwroot
```

A `.vscode` folder will be created under the project structure. It will contain utility files to help you build and debug your .NET Core Web App.

## Test the project

Before deploying the app to Azure, make sure it is running properly on your local machine.

 [!INCLUDE[](~/includes/trustCertVSC.md)]

- Run the following command:

```dotnetcli
dotnet run
```

The output shows messages similar to the following, indicating that the app is running and awaiting requests:

```dotnetcli
$ dotnet run
Hosting environment: Development
Content root path: C:/Docs/aspnetcore/tutorials/dotnet-watch/sample/WebApp
Now listening on: http://localhost:5000
Application started. Press Ctrl+C to shut down.
```

- `dotnet run`:
  - Starts [Kestrel](xref:fundamentals/servers/kestrel)
  - Displays a URL to test the Web app such as ` http://localhost:<port>`, where `<port>` is the random port number set in `Properties\launchSettings.json` at project creation.

Select the URL to test the Web app in a browser.

Press Ctrl+C on the command line to shut down the Web app after testing it.

## Generate the deployment package locally

- Open Visual Studio Code terminal
- Use the following command to generate a `Release` package to a sub folder called `publish`:
  - `dotnet publish -c Release -o ./publish`
- A new `publish` folder will be created under the project structure

![Publish folder structure](publish-to-azure-webapp-using-vscode/_static/publish-folder.jpg)

## Publish to Azure App Service

Leveraging the Azure App Service extension for Visual Studio Code, follow the
steps below to publish the website directly to the Azure App Service.

### If you're creating a new Web App

- Right click the `publish` folder and select `Deploy to Web App...`
- Select the subscription you want to create the Web App
- Select `Create New Web App`
- Enter a name for the Web App

The extension will create the new Web App and will automatically start
deploying the package to it. Once the deployment is finished, click
`Browse Website` to validate the deployment.

![Deployment succeeded message](publish-to-azure-webapp-using-vscode/_static/deployment-succeeded-message.jpg)

Once you click `Browse Website`, you'll navigate to it using your default browser:

![New Web App successfully deployed](publish-to-azure-webapp-using-vscode/_static/new-webapp-deployed.jpg)

### If you're deploying to an existing Web App

- Right click the `publish` folder and select `Deploy to Web App...`
- Select the subscription the existing Web App resides
- Select the Web App from the list
- Visual Studio Code will ask you if you want to overwrite the
existing content. Click `Deploy` to confirm

The extension will deploy the updated content to the Web App. Once it's done,
click `Browse Website` to validate the deployment.

![Existing Web App successfully deployed](publish-to-azure-webapp-using-vscode/_static/existing-webapp-deployed.jpg)

## Next steps

- [Create your first Azure DevOps pipeline](/azure/devops/pipelines/create-first-pipeline)

## Additional resources

- [Azure App Service](/azure/app-service/app-service-web-overview)
- [Azure resource groups](/azure/azure-resource-manager/resource-group-overview#resource-groups)
