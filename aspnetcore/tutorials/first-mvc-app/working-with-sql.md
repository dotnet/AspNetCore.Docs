---
title: Working with SQL Server LocalDB | Microsoft Docs
author: rick-anderson
description: 
keywords: ASP.NET Core,
ms.author: riande
manager: wpickett
ms.date: 10/14/2016
ms.topic: article
ms.assetid: ff8fd9b8-7c98-424d-8641-7524e23bf541
ms.technology: aspnet
ms.prod: asp.net-core
uid: tutorials/first-mvc-app/working-with-sql
---
# Working with SQL Server LocalDB

By [Rick Anderson](https://twitter.com/RickAndMSFT)

The `ApplicationDbContext` class handles the task of connecting to the database and mapping `Movie` objects to database records. The database context is registered with the [Dependency Injection](../../fundamentals/dependency-injection.md) container in the `ConfigureServices` method in the *Startup.cs* file:

[!code-csharp[Main](start-mvc/sample2/src/MvcMovie/Startup.cs?name=snippet_details)]

The ASP.NET Core [Configuration](../../fundamentals/configuration.md) system reads the `ConnectionString`. For local development, it gets the connection string from the *appsettings.json* file:

[!code-javascript[Main](../../tutorials/first-mvc-app/start-mvc/sample2/src/MvcMovie/appsettings.json?highlight=3&range=1-6)]

When you deploy the app to a test or production server, you can use an environment variable or another approach to set the connection string to a real SQL Server. See [Configuration](../../fundamentals/configuration.md) .

## SQL Server Express LocalDB

LocalDB is a lightweight version of the SQL Server Express Database Engine that is targeted for program development. LocalDB starts on demand and runs in user mode, so there is no complex configuration. By default, LocalDB database creates "\*.mdf" files in the *C:/Users/\<user\>* directory.

* From the **View** menu, open **SQL Server Object Explorer** (SSOX).

  ![View menu](working-with-sql/_static/ssox.png)

* Right click on the `Movie` table **> View Designer**

  ![Contextual menu open on Movie table](working-with-sql/_static/design.png)

  ![Movie table open in Designer](working-with-sql/_static/dv.png)

Note the key icon next to `ID`. By default, EF will make a property named `ID` the primary key.

* Right click on the `Movie` table **> View Data**

  ![Contextual menu open on Movie table](working-with-sql/_static/ssox2.png)

  ![Movie table open showing table data](working-with-sql/_static/vd22.png)

## Seed the database

Create a new class named `SeedData` in the *Models* folder. Replace the generated code with the following:

[!code-csharp[Main](start-mvc/sample2/src/MvcMovie/Models/SeedData.cs?name=snippet_1)]

Notice if there are any movies in the DB, the seed initializer returns.

```csharp
if (context.Movie.Any())
{
    return;   // DB has been seeded.
}
```

Add the seed initializer to the end of the `Configure` method in the *Startup.cs* file:

[!code-csharp[Main](start-mvc/sample2/src/MvcMovie/Startup.cs?highlight=9&range=79-)]

Test the app

* Delete all the records in the DB. You can do this with the delete links in the browser or from SSOX.
* Force the app to initialize (call the methods in the `Startup` class) so the seed method runs. To force initialization, IIS Express must be stopped and restarted. You can do this with any of the following approaches:

  * Right click the IIS Express system tray icon in the notification area and tap **Exit** or **Stop Site**

    ![IIS Express system tray icon](working-with-sql/_static/iisExIcon.png)

    ![Contextual menu](working-with-sql/_static/stopIIS.png)

    > [!Note]
    > In Visual Studio 2017 RC you don't need to stop IIS Express.

   * If you were running VS in non-debug mode, press F5 to run in debug mode
   * If you were running VS in debug mode, stop the debugger and press F5
   
The app shows the seeded data.

![MVC Movie application open in Microsoft Edge showing movie data](working-with-sql/_static/m55.png)

>[!div class="step-by-step"]
[Previous](adding-model.md)
[Next](controller-methods-views.md)  
