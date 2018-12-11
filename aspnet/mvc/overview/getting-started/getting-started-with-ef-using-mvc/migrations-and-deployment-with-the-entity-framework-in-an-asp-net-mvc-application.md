---
uid: mvc/overview/getting-started/getting-started-with-ef-using-mvc/migrations-and-deployment-with-the-entity-framework-in-an-asp-net-mvc-application
title: "Code First Migrations and Deployment with the Entity Framework in an ASP.NET MVC Application | Microsoft Docs"
author: tdykstra
description: "The Contoso University sample web application demonstrates how to create ASP.NET MVC 5 applications using the Entity Framework 6 Code First and Visual Studio..."
ms.author: riande
ms.date: 10/08/2018
ms.assetid: d4dfc435-bda6-4621-9762-9ba270f8de4e
msc.legacyurl: /mvc/overview/getting-started/getting-started-with-ef-using-mvc/migrations-and-deployment-with-the-entity-framework-in-an-asp-net-mvc-application
msc.type: authoredcontent
---
Code First migrations and deployment with the Entity Framework in an ASP.NET MVC application
====================
by [Tom Dykstra](https://github.com/tdykstra)

[Download Completed Project](http://code.msdn.microsoft.com/ASPNET-MVC-Application-b01a9fe8)

> The Contoso University sample web application demonstrates how to create ASP.NET MVC 5 applications using the Entity Framework 6 Code First and Visual Studio. For information about the tutorial series, see [the first tutorial in the series](creating-an-entity-framework-data-model-for-an-asp-net-mvc-application.md).

So far the application has been running locally in IIS Express on your development computer. To make a real application available for other people to use over the Internet, you have to deploy it to a web hosting provider. In this tutorial, you'll deploy the Contoso University application to the cloud in Azure.

The tutorial contains the following sections:

- Enable Code First Migrations. The Migrations feature enables you to change the data model and deploy your changes to production by updating the database schema without having to drop and re-create the database.
- Deploy to Azure. This step is optional; you can continue with the remaining tutorials without having deployed the project.

We recommend that you use a continuous integration process with source control for deployment, but this tutorial does not cover those topics. For more information, see the [source control](xref:aspnet/overview/developing-apps-with-windows-azure/building-real-world-cloud-apps-with-windows-azure/source-control) and [continuous integration](xref:aspnet/overview/developing-apps-with-windows-azure/building-real-world-cloud-apps-with-windows-azure/continuous-integration-and-continuous-delivery) chapters of [Building Real-World Cloud Apps with Azure](xref:aspnet/overview/developing-apps-with-windows-azure/building-real-world-cloud-apps-with-windows-azure/introduction).

## Enable Code First migrations

When you develop a new application, your data model changes frequently, and each time the model changes, it gets out of sync with the database. You have configured the Entity Framework to automatically drop and re-create the database each time you change the data model. When you add, remove, or change entity classes or change your `DbContext` class, the next time you run the application it automatically deletes your existing database, creates a new one that matches the model, and seeds it with test data.

This method of keeping the database in sync with the data model works well until you deploy the application to production. When the application is running in production, it is usually storing data that you want to keep, and you don't want to lose everything each time you make a change such as adding a new column. The [Code First Migrations](https://msdn.microsoft.com/data/jj591621) feature solves this problem by enabling Code First to update the database schema instead of dropping and re-creating the database. In this tutorial, you'll deploy the application, and to prepare for that you'll enable Migrations.

1. Disable the initializer that you set up earlier by commenting out or deleting the `contexts` element that you added to the application Web.config file.

    [!code-xml[Main](migrations-and-deployment-with-the-entity-framework-in-an-asp-net-mvc-application/samples/sample1.xml?highlight=2,6)]
2. Also in the application *Web.config* file, change the name of the database in the connection string to ContosoUniversity2.

    [!code-xml[Main](migrations-and-deployment-with-the-entity-framework-in-an-asp-net-mvc-application/samples/sample2.xml?highlight=2)]

    This change sets up the project so that the first migration creates a new database. This isn't required but you'll see later why it's a good idea.
3. From the **Tools** menu, select **NuGet Package Manager** > **Package Manager Console**.

1. At the `PM>` prompt enter the following commands:

    ```text
    enable-migrations
    add-migration InitialCreate
    ```

    ![enable-migrations command](migrations-and-deployment-with-the-entity-framework-in-an-asp-net-mvc-application/_static/image1.png)

    The `enable-migrations` command creates a *Migrations* folder in the ContosoUniversity project, and it puts in that folder a *Configuration.cs* file that you can edit to configure Migrations.

    (If you missed the step above that directs you to change the database name, Migrations will find the existing database and automatically do the `add-migration` command. That's okay, it just means you won't run a test of the migrations code before you deploy the database. Later when you run the `update-database` command nothing will happen because the database already exists.)

    ![Migrations folder](migrations-and-deployment-with-the-entity-framework-in-an-asp-net-mvc-application/_static/image2.png)

    Like the initializer class that you saw earlier, the `Configuration` class includes a `Seed` method.

    [!code-csharp[Main](migrations-and-deployment-with-the-entity-framework-in-an-asp-net-mvc-application/samples/sample3.cs)]

    The purpose of the [Seed](https://msdn.microsoft.com/library/hh829453(v=vs.103).aspx) method is to enable you to insert or update test data after Code First creates or updates the database. The method is called when the database is created and every time the database schema is updated after a data model change.

### Set up the Seed method

When you drop and re-create the database for every data model change, you use the initializer class's `Seed` method to insert test data, because after every model change the database is dropped and all the test data is lost. With Code First Migrations, test data is retained after database changes, so including test data in the [Seed](https://msdn.microsoft.com/library/hh829453(v=vs.103).aspx) method is typically not necessary. In fact, you don't want the `Seed` method to insert test data if you'll be using Migrations to deploy the database to production, because the `Seed` method will run in production. In that case, you want the `Seed` method to insert into the database only the data that you need in production. For example, you might want the database to include actual department names in the `Department` table when the application becomes available in production.

For this tutorial, you'll be using Migrations for deployment, but your `Seed` method will insert test data anyway in order to make it easier to see how application functionality works without having to manually insert a lot of data.

1. Replace the contents of the *Configuration.cs* file with the following code, which loads test data into the new database.

    [!code-csharp[Main](migrations-and-deployment-with-the-entity-framework-in-an-asp-net-mvc-application/samples/sample4.cs)]

    The [Seed](https://msdn.microsoft.com/library/hh829453(v=vs.103).aspx) method takes the database context object as an input parameter, and the code in the method uses that object to add new entities to the database. For each entity type, the code creates a collection of new entities, adds them to the appropriate [DbSet](https://msdn.microsoft.com/library/system.data.entity.dbset(v=vs.103).aspx) property, and then saves the changes to the database. It isn't necessary to call the [SaveChanges](https://msdn.microsoft.com/library/system.data.entity.dbcontext.savechanges(v=VS.103).aspx) method after each group of entities, as is done here, but doing that helps you locate the source of a problem if an exception occurs while the code is writing to the database.

    Some of the statements that insert data use the [AddOrUpdate](https://msdn.microsoft.com/library/system.data.entity.migrations.idbsetextensions.addorupdate(v=vs.103).aspx) method to perform an "upsert" operation. Because the `Seed` method runs every time you execute the `update-database` command, typically after each migration, you can't just insert data, because the rows you are trying to add will already be there after the first migration that creates the database. The "upsert" operation prevents errors that would happen if you try to insert a row that already exists, but it ***overrides*** any changes to data that you may have made while testing the application. With test data in some tables you might not want that to happen: in some cases when you change data while testing you want your changes to remain after database updates. In that case you want to do a conditional insert operation: insert a row only if it doesn't already exist. The Seed method uses both approaches.

    The first parameter passed to the [AddOrUpdate](https://msdn.microsoft.com/library/system.data.entity.migrations.idbsetextensions.addorupdate(v=vs.103).aspx) method specifies the property to use to check if a row already exists. For the test student data that you are providing, the `LastName` property can be used for this purpose since each last name in the list is unique:

    [!code-csharp[Main](migrations-and-deployment-with-the-entity-framework-in-an-asp-net-mvc-application/samples/sample5.cs)]

    This code assumes that last names are unique. If you manually add a student with a duplicate last name, you'll get the following exception the next time you perform a migration:

    **Sequence contains more than one element**

    For information about how to handle redundant data such as two students named "Alexander Carson", see [Seeding and Debugging Entity Framework (EF) DBs](https://blogs.msdn.com/b/rickandy/archive/2013/02/12/seeding-and-debugging-entity-framework-ef-dbs.aspx) on Rick Anderson's blog. For more information about the `AddOrUpdate` method, see [Take care with EF 4.3 AddOrUpdate Method](http://thedatafarm.com/blog/data-access/take-care-with-ef-4-3-addorupdate-method/) on Julie Lerman's blog.

    The code that creates `Enrollment` entities assumes you have the `ID` value in the entities in the `students` collection, although you didn't set that property in the code that creates the collection.

    [!code-csharp[Main](migrations-and-deployment-with-the-entity-framework-in-an-asp-net-mvc-application/samples/sample6.cs?highlight=2)]

    You can use the `ID` property here because the `ID` value is set when you call `SaveChanges` for the `students` collection. EF automatically gets the primary key value when it inserts an entity into the database, and it updates the `ID` property of the entity in memory.

    The code that adds each `Enrollment` entity to the `Enrollments` entity set doesn't use the `AddOrUpdate` method. It checks if an entity already exists and inserts the entity if it doesn't exist. This approach will preserve changes you make to an enrollment grade by using the application UI. The code loops through each member of the `Enrollment`[List](https://msdn.microsoft.com/library/6sh2ey19.aspx) and if the enrollment is not found in the database, it adds the enrollment to the database. The first time you update the database, the database will be empty, so it will add each enrollment.

    [!code-csharp[Main](migrations-and-deployment-with-the-entity-framework-in-an-asp-net-mvc-application/samples/sample7.cs)]

2. Build the project.

### Execute the first migration

When you executed the `add-migration` command, Migrations generated the code that would create the database from scratch. This code is also in the *Migrations* folder, in the file named *&lt;timestamp&gt;\_InitialCreate.cs*. The `Up` method of the `InitialCreate` class creates the database tables that correspond to the data model entity sets, and the `Down` method deletes them.

[!code-csharp[Main](migrations-and-deployment-with-the-entity-framework-in-an-asp-net-mvc-application/samples/sample8.cs)]

Migrations calls the `Up` method to implement the data model changes for a migration. When you enter a command to roll back the update, Migrations calls the `Down` method.

This is the initial migration that was created when you entered the `add-migration InitialCreate` command. The parameter (`InitialCreate` in the example) is used for the file name and can be whatever you want; you typically choose a word or phrase that summarizes what is being done in the migration. For example, you might name a later migration &quot;AddDepartmentTable&quot;.

If you created the initial migration when the database already exists, the database creation code is generated but it doesn't have to run because the database already matches the data model. When you deploy the app to another environment where the database doesn't exist yet, this code will run to create your database, so it's a good idea to test it first. That's why you changed the name of the database in the connection string earlier&mdash;so that migrations can create a new one from scratch.

1. In the **Package Manager Console** window, enter the following command:

    `update-database`

    ![](migrations-and-deployment-with-the-entity-framework-in-an-asp-net-mvc-application/_static/image3.png)

    The `update-database` command runs the `Up` method to create the database and then it runs the `Seed` method to populate the database. The same process will run automatically in production after you deploy the application, as you'll see in the following section.
2. Use **Server Explorer** to inspect the database as you did in the first tutorial, and run the application to verify that everything still works the same as before.

## Deploy to Azure

So far the application has been running locally in IIS Express on your development computer. To make it available for other people to use over the Internet, you have to deploy it to a web hosting provider. In this section of the tutorial, you'll deploy it to Azure. This section is optional; you can skip this and continue with the following tutorial, or you can adapt the instructions in this section for a different hosting provider of your choice.

### Use Code First migrations to deploy the database

To deploy the database, you'll use Code First Migrations. When you create the publish profile that you use to configure settings for deploying from Visual Studio, you'll select a check box labeled **Update Database**. This setting causes the deployment process to automatically configure the application *Web.config* file on the destination server so that Code First uses the `MigrateDatabaseToLatestVersion` initializer class.

Visual Studio doesn't do anything with the database during the deployment process while it is copying your project to the destination server. When you run the deployed application and it accesses the database for the first time after deployment, Code First checks if the database matches the data model. If there's a mismatch, Code First automatically creates the database (if it doesn't exist yet) or updates the database schema to the latest version (if a database exists but doesn't match the model). If the application implements a Migrations `Seed` method, the method runs after the database is created or the schema is updated.

Your Migrations `Seed` method inserts test data. If you were deploying to a production environment, you would have to change the `Seed` method so that it only inserts data that you want to be inserted into your production database. For example, in your current data model you might want to have real courses but fictional students in the development database. You can write a `Seed` method to load both in development, and then comment out the fictional students before you deploy to production. Or you can write a `Seed` method to load only courses, and enter the fictional students in the test database manually by using the application's UI.

### Get an Azure account

You'll need an Azure account. If you don't already have one, but you do have a Visual Studio subscription, you can [activate your subscription benefits](https://azure.microsoft.com/pricing/member-offers/credit-for-visual-studio-subscribers/
). Otherwise, you can create a free trial account in just a couple of minutes. For details, see [Azure Free Trial](https://azure.microsoft.com/free/).

### Create a web site and a SQL database in Azure

Your web app in Azure will run in a shared hosting environment, which means it runs on virtual machines (VMs) that are shared with other Azure clients. A shared hosting environment is a low-cost way to get started in the cloud. Later, if your web traffic increases, the application can scale to meet the need by running on dedicated VMs. To learn more about Pricing Options for Azure App Service, read [App Service pricing](https://azure.microsoft.com/pricing/details/app-service/).

You'll deploy the database to Azure SQL database. SQL database is a cloud-based relational database service that is built on SQL Server technologies. Tools and applications that work with SQL Server also work with SQL database.

1. In the [Azure Management Portal](https://portal.azure.com), choose **Create a resource** in the left tab and then choose **See all** on the **New** pane (or *blade*) to see all available resources. Choose **Web App + SQL** in the **Web** section of the **Everything** blade. Finally, choose **Create**.

    ![Create a resource in Azure portal](migrations-and-deployment-with-the-entity-framework-in-an-asp-net-mvc-application/_static/create-azure-resource.png)

   The form to create a new **New Web App + SQL** resource opens.

2. Enter a string in the **App name** box to use as the unique URL for your application. The complete URL will consist of what you enter here plus the default domain of Azure App Services (.azurewebsites.net). If the **App name** is already taken, the Wizard notifies you with a red *The app name is not available* message. If the **App name** is available, you see a green checkmark.

    ![Create with Database link in Management Portal](migrations-and-deployment-with-the-entity-framework-in-an-asp-net-mvc-application/_static/create-web-app-sql-resource.png)

3. In the **Subscription** box, choose the Azure Subscription in which you want the **App Service** to reside.

4. In the **Resource Group** text box, choose a Resource Group or create a new one. This setting specifies which data center your web site will run in. For more information about Resource Groups, see [Resource groups](/azure/azure-resource-manager/resource-group-overview#resource-groups).

5. Create a new **App Service Plan** by clicking the *App Service section*, **Create New**, and fill in **App Service plan** (can be same name as App Service), **Location**, and **Pricing tier** (there is a free option).

6. Click **SQL Database**, and then choose **Create a new database** or select an existing database.

    ![](migrations-and-deployment-with-the-entity-framework-in-an-asp-net-mvc-application/_static/new-sql-database.png)

7. In the **Name** box, enter a name for your database.
8. Click the **Target Server** box, and then select **Create a new server**. Alternatively, if you previously created a server, you can select that server from list of available servers.
9. Choose **Pricing tier** section, choose *Free*. If additional resources are needed, the database can be scaled up at any time. To learn more on Azure SQL Pricing, see [Azure SQL Database pricing](https://azure.microsoft.com/pricing/details/sql-database/managed/).
10. Modify [collation](/sql/relational-databases/collations/collation-and-unicode-support) as needed.
11. Enter an administrator **SQL Admin Username** and **SQL Admin Password**.

   - If you selected **New SQL Database server**, define a new name and password that you'll use later when you access the database.
   - If you selected a server that you created previously, enter credentials for that server.

12. Telemetry collection can be enabled for App Service using Application Insights. With little configuration, Application Insights collects valuable event, exception, dependency, request, and trace information. To learn more about Application Insights, see [Azure Monitor](https://azure.microsoft.com/services/monitor/).
13. Click **Create** at the bottom to indicate that you're finished.

    The Management Portal returns to the Dashboard page, and the **Notifications** area at the top of the page shows that the site is being created. After a while (typically less than a minute), there's a notification that the Deployment succeeded. In the navigation bar at the left, the new App Service appears in the **App Services** section and the new SQL database appears in the **SQL databases** section.

### Deploy the app to Azure

1. In Visual Studio, right-click the project in **Solution Explorer** and select **Publish** from the context menu.

    ![Publish menu item in Solution Explorer](migrations-and-deployment-with-the-entity-framework-in-an-asp-net-mvc-application/_static/image10.png)

2. On the **Pick a publish target** page, choose **App Service** and then **Select Existing**, and then choose **Publish**.

    ![Pick a publish target page](migrations-and-deployment-with-the-entity-framework-in-an-asp-net-mvc-application/_static/publish-select-existing-azure-app-service.png)

3. If you haven't previously added your Azure subscription in Visual Studio, perform the steps on the screen. These steps enable Visual Studio to connect to your Azure subscription so that the list of **App Services** will include your web site.

4. On the **App Service** page, select the **Subscription** you added the App Service to. Under **View**, select **Resource Group**. Expand the resource group you added the App Service to, and then select the App Service. Choose **OK** to publish the app.

    ![Select App Service](migrations-and-deployment-with-the-entity-framework-in-an-asp-net-mvc-application/_static/app-service-page.png)

5. The **Output** window shows what deployment actions were taken and reports successful completion of the deployment.

    ![Output window reporting successful deployment](migrations-and-deployment-with-the-entity-framework-in-an-asp-net-mvc-application/_static/publish-output.png)

6. Upon successful deployment, the default browser automatically opens to the URL of the deployed web site.

    ![Students_index_page_with_paging](migrations-and-deployment-with-the-entity-framework-in-an-asp-net-mvc-application/_static/cloud-app-browser.png)

    Your app is now running in the cloud.

At this point, the *SchoolContext* database has been created in the Azure SQL database because you selected **Execute Code First Migrations (runs on app start)**. The *Web.config* file in the deployed web site has been changed so that the [MigrateDatabaseToLatestVersion](https://msdn.microsoft.com/library/hh829476(v=vs.103).aspx) initializer runs the first time your code reads or writes data in the database (which happened when you selected the **Students** tab):

![Web.config file excerpt](https://asp.net/media/4367421/mig.png)

The deployment process also created a new connection string *(SchoolContext\_DatabasePublish*) for Code First Migrations to use for updating the database schema and seeding the database.

![Connection string in Web.config file](migrations-and-deployment-with-the-entity-framework-in-an-asp-net-mvc-application/_static/image26.png)

You can find the deployed version of the Web.config file on your own computer in *ContosoUniversity\obj\Release\Package\PackageTmp\Web.config*. You can access the deployed *Web.config* file itself by using FTP. For instructions, see [ASP.NET Web Deployment using Visual Studio: Deploying a Code Update](xref:web-forms/overview/deployment/visual-studio-web-deployment/deploying-a-code-update). Follow the instructions that start with "To use an FTP tool, you need three things: the FTP URL, the user name, and the password."

> [!NOTE]
> The web app doesn't implement security, so anyone who finds the URL can change the data. For instructions on how to secure the web site, see [Deploy a Secure ASP.NET MVC app with Membership, OAuth, and SQL database to Azure](/aspnet/core/security/authorization/secure-data). You can prevent other people from using the site by stopping the service using the Azure Management Portal or **Server Explorer** in Visual Studio.

![Stop app service menu item](migrations-and-deployment-with-the-entity-framework-in-an-asp-net-mvc-application/_static/server-explorer-stop-app-service.png)

## Advanced migrations scenarios

If you deploy a database by running migrations automatically as shown in this tutorial, and you are deploying to a web site that runs on multiple servers, you could get multiple servers trying to run migrations at the same time. Migrations are atomic, so if two servers try to run the same migration, one will succeed and the other will fail (assuming the operations can't be done twice). In that scenario if you want to avoid those issues, you can call migrations manually and set up your own code so that it only happens once. For more information, see [Running and Scripting Migrations from Code](http://romiller.com/2012/02/09/running-scripting-migrations-from-code/) on Rowan Miller's blog and [Migrate.exe](/ef/ef6/modeling/code-first/migrations/migrate-exe) (for executing migrations from the command line).

For information about other migrations scenarios, see [Migrations Screencast Series](https://blogs.msdn.com/b/adonet/archive/2014/03/12/migrations-screencast-series.aspx).

## Code First initializers

In the deployment section, you saw the [MigrateDatabaseToLatestVersion](https://msdn.microsoft.com/library/hh829476(v=vs.103).aspx) initializer being used. Code First also provides other initializers, including [CreateDatabaseIfNotExists](https://msdn.microsoft.com/library/gg679221(v=vs.103).aspx) (the default), [DropCreateDatabaseIfModelChanges](https://msdn.microsoft.com/library/gg679604(v=VS.103).aspx) (which you used earlier) and [DropCreateDatabaseAlways](https://msdn.microsoft.com/library/gg679506(v=VS.103).aspx). The `DropCreateAlways` initializer can be useful for setting up conditions for unit tests. You can also write your own initializers, and you can call an initializer explicitly if you don't want to wait until the application reads from or writes to the database.

For more information about initializers, see [Understanding Database Initializers in Entity Framework Code First](http://www.codeguru.com/csharp/article.php/c19999/Understanding-Database-Initializers-in-Entity-Framework-Code-First.htm) and chapter 6 of the book [Programming Entity Framework: Code First](http://shop.oreilly.com/product/0636920022220.do) by Julie Lerman and Rowan Miller.

## Summary

In this tutorial, you learned how to enable migrations and deploy the application. In the next tutorial, you'll begin looking at more advanced topics by expanding the data model.

Please leave feedback on how you liked this tutorial and what we could improve.

Links to other Entity Framework resources can be found in [ASP.NET Data Access - Recommended Resources](xref:whitepapers/aspnet-data-access-content-map).

> [!div class="step-by-step"]
> [Previous](xref:mvc/overview/getting-started/getting-started-with-ef-using-mvc/connection-resiliency-and-command-interception-with-the-entity-framework-in-an-asp-net-mvc-application)
> [Next](xref:mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-a-more-complex-data-model-for-an-asp-net-mvc-application)
