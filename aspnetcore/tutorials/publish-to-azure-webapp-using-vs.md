---
title: Publish an ASP.NET Core app to Azure using Visual Studio
author: rick-anderson
description: 
keywords: ASP.NET Core,
ms.author: riande
manager: wpickett
ms.date: 10/14/2016
ms.topic: get-started-article
ms.assetid: 78571e4a-a143-452d-9cf2-0860f85972e6
ms.technology: aspnet
ms.prod: asp.net-core
uid: tutorials/publish-to-azure-webapp-using-vs
---
# Publish an ASP.NET Core web app to Azure App Service using Visual Studio

By [Rick Anderson](https://twitter.com/RickAndMSFT) and [Cesar Blum Silveira](https://github.com/cesarbs)

## Set up the development environment

* Install the latest [Azure SDK for Visual Studio](https://www.visualstudio.com/features/azure-tools-vs). The SDK installs Visual Studio if you don't already have it.

> [!NOTE]
> The SDK installation can take more than 30 minutes if your machine doesn't have many of the dependencies.

* Install [.NET Core + Visual Studio tooling](http://go.microsoft.com/fwlink/?LinkID=798306)

* Verify your [Azure account](https://portal.azure.com/). You can [open a free Azure account](https://azure.microsoft.com/pricing/free-trial/) or [Activate Visual Studio subscriber benefits](https://azure.microsoft.com/pricing/member-offers/msdn-benefits-details/).

## Create a web app

In the Visual Studio Start Page, tap **New Project...**.

![Start Page](publish-to-azure-webapp-using-vs/_static/new_project.png)

Alternatively, you can use the menus to create a new project. Tap **File > New > Project...**.

![File menu](publish-to-azure-webapp-using-vs/_static/alt_new_project.png)

Complete the **New Project** dialog:

* In the left pane, tap **Web**

* In the center pane, tap **ASP.NET Core Web Application (.NET Core)**

* Tap **OK**

![New Project dialog](publish-to-azure-webapp-using-vs/_static/new_prj.png)

In the **New ASP.NET Core Web Application (.NET Core)** dialog:

* Tap **Web Application**

* Verify **Authentication** is set to **Individual User Accounts**

* Verify **Host in the cloud** is **not** checked

* Tap **OK**

![New ASP.NET Core Web Application (.NET Core) dialog](publish-to-azure-webapp-using-vs/_static/noath.png)

## Test the app locally

* Press **Ctrl-F5** to run the app locally

* Tap the **About** and **Contact** links. Depending on the size of your device, you might need to tap the navigation icon to show the links

![Web application open in Microsoft Edge on localhost](publish-to-azure-webapp-using-vs/_static/show.png)

* Tap **Register** and register a new user. You can use a fictitious email address. When you submit, you'll get the following error:

![Internal Server Error: A database operation failed while processing the request. SQL exception: Cannot open the database. Applying existing migrations for Application DB context may resolve this issue.](publish-to-azure-webapp-using-vs/_static/mig.png)

You can fix the problem in two different ways:

* Tap **Apply Migrations** and, once the page updates, refresh the page; or

* Run the following from a command prompt in the project's directory:

  <!-- literal_block {"ids": [], "xml:space": "preserve"} -->

  ```
  dotnet ef database update
     ```

The app displays the email used to register the new user and a **Log off** link.

![Web application open in Microsoft Edge. The Register link is replaced by the text Hello abc@example.com!](publish-to-azure-webapp-using-vs/_static/hello.png)

## Deploy the app to Azure

Right-click on the project in Solution Explorer and select **Publish...**.

![Contextual menu open with Publish link highlighted](publish-to-azure-webapp-using-vs/_static/pub.png)

In the **Publish** dialog, tap **Microsoft Azure App Service**.

![Publish dialog](publish-to-azure-webapp-using-vs/_static/maas1.png)

Tap **New...** to create a new resource group. Creating a new resource group will make it easier to delete all the Azure resources you create in this tutorial.

![App Service dialog](publish-to-azure-webapp-using-vs/_static/newrg1.png)

Create a new resource group and app service plan:

* Tap **New...** for the resource group and enter a name for the new resource group

* Tap **New...** for the  app service plan and select a location near you. You can keep the default generated name

* Tap **Explore additional Azure services** to create a new database

![New Resource Group dialog: Hosting panel](publish-to-azure-webapp-using-vs/_static/cas.png)

* Tap the green **+** icon to create a new SQL Database

![New Resource Group dialog: Services panel](publish-to-azure-webapp-using-vs/_static/sql.png)

* Tap **New...** on the **Configure SQL Database** dialog to create a new database server.

![Configure SQL Database dialog](publish-to-azure-webapp-using-vs/_static/conf.png)

* Enter an administrator user name and password, and then tap **OK**. Don't forget the user name and password you create in this step. You can keep the default **Server Name**

![Configure SQL Server dialog](publish-to-azure-webapp-using-vs/_static/conf_servername.png)

> [!NOTE]
> "admin" is not allowed as the administrator user name.

* Tap **OK** on the  **Configure SQL Database** dialog

![Configure SQL Database dialog](publish-to-azure-webapp-using-vs/_static/conf_final.png)

* Tap **Create** on the **Create App Service** dialog

![Create App Service dialog](publish-to-azure-webapp-using-vs/_static/create_as.png)

* Tap **Next** in the **Publish** dialog

![Publish dialog: Connection panel](publish-to-azure-webapp-using-vs/_static/pubc.png)

* On the **Settings** stage of the **Publish** dialog:

  * Expand **Databases** and check **Use this connection string at runtime**

  * Expand **Entity Framework Migrations** and check **Apply this migration on publish**

* Tap **Publish** and wait until Visual Studio finishes publishing your app

![Publish dialog: Settings panel](publish-to-azure-webapp-using-vs/_static/pubs.png)

Visual Studio will publish your app to Azure and launch the cloud app in your browser.

### Test your app in Azure

* Test the **About** and **Contact** links

* Register a new user

![Web application opened in Microsoft Edge on Azure App Service](publish-to-azure-webapp-using-vs/_static/final.png)

### Update the app

* Edit the `Views/Home/About.cshtml` Razor view file and change its contents. For example:

<!-- literal_block {"ids": [], "linenos": false, "xml:space": "preserve", "language": "html", "highlight_args": {"hl_lines": [7]}} -->

```html
@{
       ViewData["Title"] = "About";
   }
   <h2>@ViewData["Title"].</h2>
   <h3>@ViewData["Message"]</h3>

   <p>My updated about page.</p>
   ```

* Right-click on the project and tap **Publish...** again

![Contextual menu open with Publish link highlighted](publish-to-azure-webapp-using-vs/_static/pub.png)

* After the app is published, verify the changes you made are available on Azure

### Clean up

When you have finished testing the app, go to the [Azure portal](https://portal.azure.com/) and delete the app.

* Select **Resource groups**, then tap the resource group you created

![Azure Portal: Resource Groups in sidebar menu](publish-to-azure-webapp-using-vs/_static/portalrg.png)

* In the **Resource group** blade, tap **Delete**

![Azure Portal: Resource Groups blade](publish-to-azure-webapp-using-vs/_static/rgd.png)

* Enter the name of the resource group and tap **Delete**. Your app and all other resources created in this tutorial are now deleted from Azure

### Next steps

* [Getting started with ASP.NET Core MVC and Visual Studio](first-mvc-app/start-mvc.md)

* [Introduction to ASP.NET Core](../index.md)

* [Fundamentals](../fundamentals/index.md)
