---
title: Publish an ASP.NET Core app to Azure using Visual Studio
author: rick-anderson
description: Learn how to publish an ASP.NET Core app to Azure App Service using Visual Studio.
keywords: ASP.NET Core
ms.author: riande
manager: wpickett
ms.date: 12/16/2017
ms.topic: get-started-article
ms.technology: aspnet
ms.prod: asp.net-core
uid: tutorials/publish-to-azure-webapp-using-vs
---
/en-us

# Publish an ASP.NET Core web app to Azure App Service using Visual Studio

By [Rick Anderson](https://twitter.com/RickAndMSFT), [Cesar Blum Silveira](https://github.com/cesarbs), and [Rachel Appel](https://twitter.com/rachelappel)

See [Publish to Azure from Visual Studio for Mac](https://blog.xamarin.com/publish-azure-visual-studio-mac/) if you are working on a Mac.

## Set up

* Open a [free Azure account](https://aka.ms/K5y5yh) if you do not have one. 

## Create a web app

In the Visual Studio Start Page, select **File > New > Project...**

![File menu](publish-to-azure-webapp-using-vs/_static/file_new_project.png)

Complete the **New Project** dialog:

* In the left pane, select **.NET Core**.
* In the center pane, select **ASP.NET Core Web Application**.
* Select **OK**.

![New Project dialog](publish-to-azure-webapp-using-vs/_static/new_prj.png)

In the **New ASP.NET Core Web Application** dialog:

* Select **Web Application**.
* Select **Change Authentication**.

![New Project dialog](publish-to-azure-webapp-using-vs/_static/new_prj_2.png)

The **Change Authentication** dialog appears. 

* Select **Individual User Accounts**.
* Select **OK** to return to the **New ASP.NET Core Web Application**, then select **OK** again.

![New ASP.NET Core Web authentication dialog](publish-to-azure-webapp-using-vs/_static/new_prj_auth.png) 

Visual Studio creates the solution.

## Run the app

* Press CTRL+F5 to run the project.
* Test the **About** and **Contact** links.

![Web application open in Microsoft Edge on localhost](publish-to-azure-webapp-using-vs/_static/show.png)

### Register a user

* Select **Register** and register a new user. You can use a fictitious email address. When you submit, the page displays the following error:

    *"Internal Server Error: A database operation failed while processing the request. SQL exception: Cannot open the database. Applying existing migrations for Application DB context may resolve this issue."*
* Select **Apply Migrations** and, once the page updates, refresh the page.

![Internal Server Error: A database operation failed while processing the request. SQL exception: Cannot open the database. Applying existing migrations for Application DB context may resolve this issue.](publish-to-azure-webapp-using-vs/_static/mig.png)

The app displays the email used to register the new user and a **Log out** link.

![Web application open in Microsoft Edge. The Register link is replaced by the text Hello email@domain.com!](publish-to-azure-webapp-using-vs/_static/hello.png)

## Deploy the app to Azure

Right-click on the project in Solution Explorer and select **Publish...**.

![Contextual menu open with Publish link highlighted](publish-to-azure-webapp-using-vs/_static/pub.png)

In the **Publish** dialog:

* Select **Microsoft Azure App Service**.
* Select the gear icon and then select **Create Profile**.
* Select **Create Profile**.

![Publish dialog](publish-to-azure-webapp-using-vs/_static/maas1.png)

### Create Azure resources

The **Create App Service** dialog appears:

* Enter your subscription.
* The **App Name**, **Resource Group**, and **App Service Plan** entry fields are populated. You can keep these names or change them.

![App Service dialog](publish-to-azure-webapp-using-vs/_static/newrg1.png)

* Select the **Services** tab to create a new database.

* Select the green **+** icon to create a new SQL Database

![New SQL Database](publish-to-azure-webapp-using-vs/_static/sql.png)

* Select **New...** on the **Configure SQL Database** dialog to create a new database.

![New SQL Database and server](publish-to-azure-webapp-using-vs/_static/conf.png)

The **Configure SQL Server** dialog appears.

* Enter an administrator user name and password, and then select **OK**. You can keep the default **Server Name**. 

> [!NOTE]
> "admin" is not allowed as the administrator user name.

![Configure SQL Server dialog](publish-to-azure-webapp-using-vs/_static/conf_servername.png)

* Select **OK**.

Visual Studio returns to the **Create App Service** dialog.

* Select **Create** on the **Create App Service** dialog.

![Configure SQL Database dialog](publish-to-azure-webapp-using-vs/_static/conf_final.png)

Visual Studio creates the Web app and SQL Server on Azure. This step can take a few minutes. For information on the resources created, see [Additonal resources](#additonal-resources).

When deployment completes, select **Settings**:

![Configure SQL Server dialog](publish-to-azure-webapp-using-vs/_static/set.png)

On the **Settings** page of the **Publish** dialog:

  * Expand **Databases** and check **Use this connection string at runtime**.
  * Expand **Entity Framework Migrations** and check **Apply this migration on publish**.

* Select **Save**. Visual Studio returns to the **Publish** dialog. 

![Publish dialog: Settings panel](publish-to-azure-webapp-using-vs/_static/pubs.png)

Click **Publish**. Visual Studio publishs your app to Azure. When the depoyment completes, the app is opened in a browser.

### Test your app in Azure

* Test the **About** and **Contact** links

* Register a new user

![Web application opened in Microsoft Edge on Azure App Service](publish-to-azure-webapp-using-vs/_static/register.png)

### Update the app

* Edit the *Pages/About.cshtml* Razor page and change its contents. For example, you can modify the paragraph to say "Hello ASP.NET Core!":
    [!code-html[About](publish-to-azure-webapp-using-vs/sample/about.cshtml?highlight=9&range=1-9)]

* Right-click on the project and select **Publish...** again.

![Contextual menu open with Publish link highlighted](publish-to-azure-webapp-using-vs/_static/pub.png)

* After the app is published, verify the changes you made are available on Azure.

![Verify task is complete](publish-to-azure-webapp-using-vs/_static/final.png)

### Clean up

When you have finished testing the app, go to the [Azure portal](https://portal.azure.com/) and delete the app.

* Select **Resource groups**, then select the resource group you created.

![Azure Portal: Resource Groups in sidebar menu](publish-to-azure-webapp-using-vs/_static/portalrg.png)

* In the **Resource groups** page, select **Delete**.

![Azure Portal: Resource Groups page](publish-to-azure-webapp-using-vs/_static/rgd.png)

* Enter the name of the resource group and select **Delete**. Your app and all other resources created in this tutorial are now deleted from Azure.

### Next steps

* [Continuous Deployment to Azure with Visual Studio and Git](xref:host-and-deploy/azure-apps/azure-continuous-deployment)

## Additonal resources

* [Azure App Service](https://docs.microsoft.com/en-us/azure/app-service/app-service-web-overview)
* [Azure resource groups](https://docs.microsoft.com/en-us/azure/azure-resource-manager/resource-group-overview#resource-groups)
* [Azure SQL Database](https://docs.microsoft.com/en-us/azure/sql-database/)