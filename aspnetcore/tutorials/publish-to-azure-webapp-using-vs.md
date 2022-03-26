---
title: Publish an ASP.NET Core app to Azure with Visual Studio
author: rick-anderson
description: Learn how to publish an ASP.NET Core app to Azure App Service using Visual Studio.
ms.author: riande
ms.custom: "devx-track-csharp, mvc"
ms.date: 07/10/2019
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: tutorials/publish-to-azure-webapp-using-vs
---
# Publish an ASP.NET Core app to Azure with Visual Studio

By [Rick Anderson](https://twitter.com/RickAndMSFT)
:::moniker range=">= aspnetcore-3.0"

[!INCLUDE [Azure App Service Preview Notice](../includes/azure-apps-preview-notice.md)]

:::moniker-end


If you're working on macOS, see [Publish a Web app to Azure App Service using Visual Studio for Mac](/visualstudio/mac/publish-app-svc).

To troubleshoot an App Service deployment issue, see <xref:test/troubleshoot-azure-iis>.

## Set up

* Open a [free Azure account](https://azure.microsoft.com/free/dotnet/) if you don't have one. 

## Create a web app

In the Visual Studio Start Page, select **File** > **New** > **Project**.

![File menu](publish-to-azure-webapp-using-vs/_static/file_new_project.png)

Complete the **New Project** dialog:

* Select **ASP.NET Core Web Application**.
* Select **Next**.

![New Project dialog](publish-to-azure-webapp-using-vs/_static/new_prj.png)

In the **New ASP.NET Core Web Application** dialog:

* Select **Web Application**.
* Select **Change** under Authentication.

![New ASP.NET Core Web dialog](publish-to-azure-webapp-using-vs/_static/new_prj_2.png)

The **Change Authentication** dialog appears. 

* Select **Individual User Accounts**.
* Select **OK** to return to the **New ASP.NET Core Web Application**, then select **Create**.

![New ASP.NET Core Web authentication dialog](publish-to-azure-webapp-using-vs/_static/new_prj_auth.png) 

Visual Studio creates the solution.

## Run the app

* Press CTRL+F5 to run the project.
* Test the **Privacy** link.

![Web application open in Microsoft Edge on localhost](publish-to-azure-webapp-using-vs/_static/show.png)

### Register a user

* Select **Register** and register a new user. You can use a fictitious email address. When you submit, the page displays the following error:

    *"A database operation failed while processing the request. Applying existing migrations for Application DB context may resolve this issue."*
* Select **Apply Migrations** and, once the page updates, refresh the page.

![A database operation failed while processing the request. Applying existing migrations for Application DB context may resolve this issue.](publish-to-azure-webapp-using-vs/_static/mig.png)

The app displays the email used to register the new user and a **Logout** link.

![Web application open in Microsoft Edge. The Register link is replaced by the text Hello user1@example.com!](publish-to-azure-webapp-using-vs/_static/hello.png)

## Deploy the app to Azure

Right-click on the project in Solution Explorer and select **Publish**.

![Contextual menu open with Publish link highlighted](publish-to-azure-webapp-using-vs/_static/pub.png)

In the **Publish** dialog:

* Select **Azure**.
* Select **Next**.

![Publish dialog](publish-to-azure-webapp-using-vs/_static/maas1.png)

In the **Publish** dialog:

* Select **Azure App Service (Linux)**.
* Select **Next**.

![Publish Dialog: select Azure Service](publish-to-azure-webapp-using-vs/_static/maas2.png)

In the **Publish** dialog, select **Create a new Azure App Service**.

![Publish dialog: select Azure Service instance](publish-to-azure-webapp-using-vs/_static/maas3.png)

The **Create App Service** dialog appears:

* The **App Name**, **Resource Group**, and **App Service Plan** entry fields are populated. You can keep these names or change them.
* Select **Create**.

![Create App Service dialog](publish-to-azure-webapp-using-vs/_static/newrg1.png)

After creation is completed the dialog is automatically closed and the **Publish** dialog gets focus again:

* The new instance that was just created is automatically selected.
* Select **Finish**.

![Publish dialog: select App Service instance](publish-to-azure-webapp-using-vs/_static/select_as.png)

Next you see the **Publish Profile summary** page. Visual Studio has detected that this application requires a SQL Server database and it's asking you to configure it. Select **Configure**.

![Publish Profile summary page: configure SQL Server dependency](publish-to-azure-webapp-using-vs/_static/sql.png)

The **Configure dependency** dialog appears:

* Select **Azure SQL Database**.
* Select **Next**.

![Configure SQL Server Dependency dialog](publish-to-azure-webapp-using-vs/_static/sql1.png)

In the **Configure Azure SQL database** dialog, select **Create a SQL Database**.

![Select Create a SQL DB](publish-to-azure-webapp-using-vs/_static/sql2.png)

The **Create Azure SQL Database** appears:

* The **Database name**, **Resource Group**, **Database server** and **App Service Plan** entry fields are populated. You can keep these values or change them.
* Enter the **Database administrator username** and **Database administrator password** for the selected **Database server** (note the account you use must have the necessary permissions to create the new Azure SQL database)
* Select **Create**.

![New Azure SQL Database dialog](publish-to-azure-webapp-using-vs/_static/sql_create.png)

After creation is completed the dialog is automatically closed and the **Configure Azure SQL Database** dialog gets focus again:

* The new instance that was just created is automatically selected.
* Select **Next**.

![Select Next](publish-to-azure-webapp-using-vs/_static/sql_select.png)

In the next step of the **Configure Azure SQL Database** dialog:

* Enter the **Database connection user name** and **Database connection password** fields. These are the details your application will use to connect to the database at runtime. Best practice is to avoid using the same details as the admin username & password used in the previous step.
* Select **Finish**.

![Configure Azure SQL Database dialog, connection string details](publish-to-azure-webapp-using-vs/_static/sql_connection.png)

In the **Publish Profile summary** page select **Settings**:

![Publish profile summary page: edit settings](publish-to-azure-webapp-using-vs/_static/pp_configured.png)

On the **Settings** page of the **Publish** dialog:

* Expand **Databases** and check **Use this connection string at runtime**.
* Expand **Entity Framework Migrations** and check **Apply this migration on publish**.

* Select **Save**. Visual Studio returns to the **Publish** dialog. 

![Publish dialog: Settings panel:Save](publish-to-azure-webapp-using-vs/_static/pp_settings.png)

Click **Publish**. Visual Studio publishes your app to Azure. When the deployment completes, the app is opened in a browser.

![Last step](publish-to-azure-webapp-using-vs/_static/pp_publish.png)

### Update the app

* Edit the `Pages/Index.cshtml` Razor page and change its contents. For example, you can modify the paragraph to say "Hello ASP.NET Core!":

    [!code-html[Index](publish-to-azure-webapp-using-vs/sample/index.cshtml?highlight=10&range=1-12)]

* Select **Publish** from the **Publish Profile summary** page again.

![Publish profile summary page](publish-to-azure-webapp-using-vs/_static/pp_publish.png)

* After the app is published, verify the changes you made are available on Azure.

![Verify task is complete](publish-to-azure-webapp-using-vs/_static/final.png)

### Clean up

When you have finished testing the app, go to the [Azure portal](https://portal.azure.com/) and delete the app.

* Select **Resource groups**, then select the resource group you created.

![Azure Portal: Resource Groups in sidebar menu](publish-to-azure-webapp-using-vs/_static/portalrg.png)

* In the **Resource groups** page, select **Delete**.

![Azure Portal: Resource Groups page](publish-to-azure-webapp-using-vs/_static/rgd.png)

* Enter the name of the resource group and select **Delete**. Your app and all other resources created in this tutorial are now deleted from Azure.

## Additional resources

* For Visual Studio Code, see [Publish profiles](xref:host-and-deploy/visual-studio-publish-profiles#publish-profiles).
* [Azure App Service](/azure/app-service/app-service-web-overview)
* [Azure resource groups](/azure/azure-resource-manager/resource-group-overview#resource-groups)
* [Azure SQL Database](/azure/sql-database/)
* <xref:host-and-deploy/visual-studio-publish-profiles>
* <xref:test/troubleshoot-azure-iis>
