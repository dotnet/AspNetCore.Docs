---
title: Working with SQLite | Microsoft Docs
author: rick-anderson
description: Using SQLite with a simple MVC app
keywords: ASP.NET Core,SQLite, SQL Server 
ms.author: riande
manager: wpickett
ms.date: 04/07/2017
ms.topic: article
ms.assetid: 1638d9b8-7c98-424d-8641-1638e23bf541
ms.technology: aspnet
ms.prod: asp.net-core
uid: tutorials/first-mvc-app-xplat/working-with-sql
---
# Working with SQLite

By [Rick Anderson](https://twitter.com/RickAndMSFT)

The `MvcMovieContext` object handles the task of connecting to the database and mapping `Movie` objects to database records. The database context is registered with the [Dependency Injection](xref:fundamentals/dependency-injection) container in the `ConfigureServices` method in the *Startup.cs* file:

[!code-csharp[Main](start-mvc/sample/MvcMovie/Startup.cs?name=snippet2&highlight=6-8)]


## SQLite

The [SQLite](https://www.sqlite.org/) website states:

  SQLite is a self-contained, high-reliability, embedded, full-featured, public-domain, SQL database engine. SQLite is the most used database engine in the world.

There are many third party tools you can download to manage and view a SQLite database. The image below is from [DB Browser for SQLite](http://sqlitebrowser.org/). If you have a favorite SQLite tool, leave a LiveFyre comment on what you like about it.

![DB Browser for SQLite showing movie db](working-with-sql/_static/dbb.png)

## Seed the database

Create a new class named `SeedData` in the *Models* folder. Replace the generated code with the following:

[!code-csharp[Main](../../tutorials/first-mvc-app/start-mvc/sample/MvcMovie/Models/SeedData.cs?name=snippet_1)]

If there are any movies in the DB, the seed initializer returns.

```csharp
if (context.Movie.Any())
{
    return;   // DB has been seeded.
}
```

Add the seed initializer to the end of the `Configure` method in the *Startup.cs* file:

[!code-csharp[Main](../../tutorials/first-mvc-app/start-mvc/sample/MvcMovie/Startup.cs?highlight=9&name=snippet_seed)]

### Test the app

Delete all the records in the DB (So the seed method will run). Stop and start the app to seed the database.
   
The app shows the seeded data.

![MVC Movie application open browser showing movie data](../../tutorials/first-mvc-app/working-with-sql/_static/m55.png)

>[!div class="step-by-step"]
[Previous](adding-model.md)
<!--
[Next](controller-methods-views.md)  
-->