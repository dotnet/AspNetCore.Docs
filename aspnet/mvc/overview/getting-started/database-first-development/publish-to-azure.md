---
uid: mvc/overview/getting-started/database-first-development/publish-to-azure
title: "Tutorial: Publish MVC Database First site to Azure"
description: "This tutorial focuses on publishing the web app and database to Azure."
author: Rick-Anderson
ms.author: riande
ms.date: 01/28/2019
ms.topic: tutorial
ms.assetid: 7131f1c1-cef3-4396-ab44-ed4519676546
msc.legacyurl: /mvc/overview/getting-started/database-first-development/publish-to-azure
msc.type: authoredcontent
---

# Tutorial: Publish MVC Database First site to Azure

Using MVC, Entity Framework, and ASP.NET Scaffolding, you can create a web application that provides an interface to an existing database. This tutorial series shows you how to automatically generate code that enables users to display, edit, create, and delete data that resides in a database table. The generated code corresponds to the columns in the database table.

This tutorialr focuses on publishing the web app and database to Azure.

In this tutorial, you:

> [!div class="checklist"]
> * Deploy your web app on Azure
> * Publish the database to SQL Azure

## Prerequisites

* [Enhance data validation](enhancing-data-validation.md)

## Deploy your web app on Azure

You need an Azure account to complete this tutorial:

- You can [open an Azure account for free](https://azure.microsoft.com/pricing/free-trial/?WT.mc_id=A261C142F) - You get credits you can use to try out paid Azure services, and even after they're used up you can keep the account and use free Azure services.
- You can [activate MSDN subscriber benefits](https://azure.microsoft.com/pricing/member-offers/msdn-benefits-details/?WT.mc_id=A261C142F) - Your MSDN subscription gives you credits every month that you can use for paid Azure services.

To publish your web app, right-click the **ContosoSite** project and select **Publish**. Click **Start**.

In **Pick a publish target**, select **App Service** > **Create New** and then select **Publish**.

![Screenshot of Pick a publish target dialog.](publish-to-azure/_static/image2.png)

If you are not signed in to Azure, provide your Azure account credentials. **Create App Service** appears.

![Screenshot of Create App Service dialog.](publish-to-azure/_static/image3.png)

Create a unique name for your web app. You will know the name is not unique if you see this error message: *Name is not available, please choose another*. Select your subscription and then either select an existing resource group and hosting plan, or create new ones.

Select **Create a SQL Database**.

![Screenshot of Configure SQL Database dialog.](publish-to-azure/_static/image4.png)

In **Configure SQL Database**, next to the **SQL Server** drop-down list, select **New**. Enter **Administrator Username** and **Administrator Password** credentials. Leave the other default values and select **OK**.

Back in **Create App Service**, select **Create**.

The **Output** pane will display the result of your publication.

After publication, the site is immediately launched in a web browser. Your site has been deployed and you can register a new user to the site; however, your tables in the **ContosoUniversityData** project have not yet been published. If you click on the **List of students** link you will receive an error.

In the **ContosoSite** - **Publish** pane, select **Configure**. In the **Publish** dialog that appears, select **Settings**.

![Screenshot of published Databases](publish-to-azure/_static/image5.png)

Notice that the database connection is specified - **ContosoUniversityDataEntities**. This value only shows the connection string for the databases. It does not mean that these databases will be published when you publish your site. You publish your database project in the next section.

The ellipsis (...) next to the database connection shows you the details of the connection string. Click the ellipsis next to **ContosoUniversityDataEntities**.

Note the name of the database server and the database. The server name is randomly generated. The database name is simple the name of your site with _db appended. You will need both names later when you publish your database.
Click **OK** to close the database connection string window and **Cancel** to close the **Publish** window.

## Publish database to SQL Azure

Before publishing your database, you must make sure your local computer can connect to the database server. The firewall for your database server restricts which machines can connect to the database. You need to add the IP address of your computer to the allowed IP addresses for the firewall.

Login to your Azure account through the Azure portal.

In the left pane, select **SQL databases** and then select your new database. From the menu at the top of the **Overview** section, select **Connect with** > **Visual Studio**.

![manage](publish-to-azure/_static/image10.png)

On the blade that opens, select **Open in Visual Studio**. A warning message appears. Select **Yes**. Visual Studio opens.

In the **Connect** dialog, enter your **User Name** and **Password** and select **Connect**.

If you receive an error message, you need to add your IP address.

![login](publish-to-azure/_static/image12.png)

In the details you will see the IP address that you need to add. Note this IP address.

Close Visual Studio 2017 and go back to Azure. In the **Open Visual Studio** blade, select **Configure your firewall**.

Create a rule name, add your IP to the **START IP** and **END IP** fields and select **Save**.

![publish database](publish-to-azure/_static/image13.png)

You may need to wait a few minutes before the allowed IP addresses are correctly configured for the firewall. A message will appear in Azure: *Success! Successfully updated firewall rules*.

When you can successfully log in the database, you have finished setting up your connection to the database.

Restart Visual Studio 2017 and open your database project in **Solution Explorer**. Select **File** > **Open** > **Project/Solution** > **ContosoUniversityData** > **ContosoUniversityData.sln**.  Right-click the project and select **Publish**.

In the **Publish Database** window, select **Edit**.

In the **Connect** dialog, on the **History** tab, select your database. Select **Show Connection Properties**, provide authentication credentials for the server, and select **OK**.

![save profile](publish-to-azure/_static/image18.png)

You will probably want to save this profile so you can publish updates in the future without re-entering all of the connection information. Select **Create Profile**.

![save profile](publish-to-azure/_static/image19.png)

It will create a file in your project named **ContosoUniversityData.publish.xml**. The next time you want to publish the database to Azure, simply load that profile.

Now, click **Publish** to create the database on Azure.

After running for a while, the publishing results are displayed.

Now, you can go to the **Query editor** for your database. In Azure, select **SQL databases** > **Query Editor**. Enter your database password and select **OK**.  Refresh the design view, and notice the three tables with pre-filled data have been deployed.

![new tables](publish-to-azure/_static/image22.png)

Now you are ready to test the web app that is deployed to Azure. Navigate to the web app on Azure (such as http://contosositeexample.azurewebsites.net/). Click the link for List of students and you should see the index view for students.

![view](publish-to-azure/_static/image23.png)

Occasionally, the database and connection need a little time to be properly configured. If you receive an error, wait a few minutes and then try again.

## Conclusion

This series provided a simple example of how to generate code from an existing database that enables users to edit, update, create and delete data. It used ASP.NET MVC 5, Entity Framework and ASP.NET Scaffolding to create the project.

For an introductory example of Code First development, see [Getting Started with ASP.NET MVC 5](../introduction/getting-started.md).

For a more advanced example, see [Creating an Entity Framework Data Model for an ASP.NET MVC 4 App](../getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application.md). Note that the DbContext API that you use for working with data in Database First is the same as the API you use for working with data in Code First. Even if you intend to use Database First, you can learn how to handle more complex scenarios such as reading and updating related data, handling concurrency conflicts, and so forth from a Code First tutorial. The only difference is in how the database, context class, and entity classes are created.

## Next steps

In this tutorial, you:

> [!div class="checklist"]
> * Deployed your web app on Azure
> * Published the database to SQL Azure

This completes this series of tutorials on using the Entity Framework Database First in an ASP.NET MVC application. If you want to learn about the lifecycle of an ASP.NET MVC 5 application, go to the next tutorial.
> [!div class="step-by-step"]
> [Lifecycle of an ASP.NET MVC 5 app](../lifecycle-of-an-aspnet-mvc-5-application.md)