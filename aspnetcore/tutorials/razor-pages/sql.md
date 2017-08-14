---
title: Working with SQL Server LocalDB and ASP.NET Core
author: rick-anderson
description: Explains working with SQL Server LocalDB and ASP.NET Core.
keywords: ASP.NET Core,Razor Pages,Razor,MVC, SQL, LocalDB
ms.author: riande
manager: wpickett
ms.date: 8/7/2017
ms.topic: get-started-article
ms.technology: aspnet
ms.prod: aspnet-core
uid: tutorials/razor-pages/sql
---
# Working with SQL Server LocalDB and ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT) and [Joe Audette](https://twitter.com/joeaudette) 

The `MovieContext` object handles the task of connecting to the database and mapping `Movie` objects to database records. The database context is registered with the [Dependency Injection](xref:fundamentals/dependency-injection) container in the `ConfigureServices` method in the *Startup.cs* file:

[!code-csharp[Main](razor-pages-start/sample/RazorPagesMovie/Startup.cs?name=snippet_ConfigureServices&highlight=6-7)]

The ASP.NET Core [Configuration](xref:fundamentals/configuration) system reads the `ConnectionString`. For local development, it gets the connection string from the *appsettings.json* file:

[!code-javascript[Main](razor-pages-start/sample/RazorPagesMovie/appsettings.json?highlight=2&range=8-10)]

When you deploy the app to a test or production server, you can use an environment variable or another approach to set the connection string to a real SQL Server. See [Configuration](xref:fundamentals/configuration) for more information.

## SQL Server Express LocalDB

LocalDB is a lightweight version of the SQL Server Express Database Engine that is targeted for program development. LocalDB starts on demand and runs in user mode, so there is no complex configuration. By default, LocalDB database creates "\*.mdf" files in the *C:/Users/\<user\>* directory.

<a name="ssox"></a>
* From the **View** menu, open **SQL Server Object Explorer** (SSOX).

  ![View menu](sql/_static/ssox.png)

* Right click on the `Movie` table **> View Designer**

  ![Contextual menu open on Movie table](sql/_static/design.png)

  ![Movie table open in Designer](sql/_static/dv.png)

Note the key icon next to `ID`. By default, EF will make a property named `ID` the primary key.

* Right click on the `Movie` table **> View Data**

  ![Movie table open showing table data](sql/_static/vd22.png)

## Seed the database

Create a new class named `SeedData` in the *Models* folder. Replace the generated code with the following:

[!code-csharp[Main](razor-pages-start/sample/RazorPagesMovie/Models/SeedData.cs?name=snippet_1)]

If there are any movies in the DB, the seed initializer returns and no movies are added.

```csharp
if (context.Movie.Any())
{
    return;   // DB has been seeded.
}
```
<a name="si"></a>
### Add the seed initializer

Add the seed initializer to the end of the `Main` method in the *Program.cs* file:

[!code-csharp[Main](razor-pages-start/sample/RazorPagesMovie/Program.cs?highlight=6,17-32)]

Test the app

* Delete all the records in the DB. You can do this with the delete links in the browser or from [SSOX](xref:tutorials/razor-pages/new-field#ssox)
* Force the app to initialize (call the methods in the `Startup` class) so the seed method runs. To force initialization, IIS Express must be stopped and restarted. You can do this with any of the following approaches:

  * Right click the IIS Express system tray icon in the notification area and tap **Exit** or **Stop Site**

    ![IIS Express system tray icon](../first-mvc-app/working-with-sql/_static/iisExIcon.png)

    ![Contextual menu](sql/_static/stopIIS.png)

   * If you were running VS in non-debug mode, press F5 to run in debug mode.
   * If you were running VS in debug mode, stop the debugger and press F5.
   
The app shows the seeded data.

![Movie application open in Chrome showing movie data](sql/_static/m55.png)

The next tutorial will clean up the presentation of the data.

>[!div class="step-by-step"]
[Previous: Scaffolded Razor Pages](xref:tutorials/razor-pages/page)   
[Next: Updating the pages](xref:tutorials/razor-pages/da1)
