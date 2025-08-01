---
title: Part 5, work with a database in an ASP.NET Core MVC app
author: wadepickett
description: Part 5 of tutorial series on ASP.NET Core MVC.
ms.author: wpickett
ms.date: 03/02/2025
ms.custom: sfi-ropc-nochange
monikerRange: '>= aspnetcore-3.1'
uid: tutorials/first-mvc-app/working-with-sql
---

# Part 5, work with a database in an ASP.NET Core MVC app

[!INCLUDE[](~/includes/not-latest-version.md)]

By [Rick Anderson](https://twitter.com/RickAndMSFT) and [Jon P Smith](https://twitter.com/thereformedprog).

:::moniker range=">= aspnetcore-9.0"

The `MvcMovieContext` object handles the task of connecting to the database and mapping `Movie` objects to database records. The database context is registered with the [Dependency Injection](xref:fundamentals/dependency-injection) container in the `Program.cs` file:

# [Visual Studio](#tab/visual-studio)

[!code-csharp[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie90/Program.cs?name=snippet_FirstSQLServer&highlight=2-3)]

The ASP.NET Core [Configuration](xref:fundamentals/configuration/index) system reads the `ConnectionString` key. For local development, it gets the connection string from the `appsettings.json` file:

[!code-json[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie90/appsettings.json?highlight=2&range=9-11)]

# [Visual Studio Code](#tab/visual-studio-code)

[!code-csharp[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie90/Program.cs?name=snippet_FirstSQLite&highlight=3-4)]

The ASP.NET Core [Configuration](xref:fundamentals/configuration/index) system reads the `ConnectionString`. For local development, it gets the connection string from the `appsettings.json` file:

[!code-json[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie90/appsettings_SQLite.json?highlight=2&range=9-11)]

---

[!INCLUDE [managed-identities](~/includes/managed-identities-test-non-production.md)]

# [Visual Studio](#tab/visual-studio)

## SQL Server Express LocalDB

LocalDB:

* Is a lightweight version of the SQL Server Express Database Engine, installed by default with Visual Studio.
* Starts on demand by using a connection string.
* Is targeted for program development. It runs in user mode, so there's no complex configuration.
* By default creates *.mdf* files in the *C:/Users/{user}* directory.

### Examine the database

From the **View** menu, open **SQL Server Object Explorer** (SSOX).

Right-click on the `Movie` table (`dbo.Movie`) **> View Designer**

![Right-click on the Movie table > View Designer.](~/tutorials/first-mvc-app/working-with-sql/_static/8/designvs22v17.8.0.png)

![Movie table open in Designer](~/tutorials/first-mvc-app/working-with-sql/_static/8/dv_vs22v17.8.0.png)

Note the key icon next to `ID`. By default, EF makes a property named `ID` the primary key.

Right-click on the `Movie` table **> View Data**

![Right-click on the Movie table > View Data.](~/tutorials/first-mvc-app/working-with-sql/_static/8/ssox2_vs22v17.8.0.png)

![Movie table open showing table data](~/tutorials/first-mvc-app/working-with-sql/_static/8/vd_vs22_17.8.0.png)
-->

# [Visual Studio Code](#tab/visual-studio-code)

[!INCLUDE[](~/includes/rp/sqlite.md)]
[!INCLUDE[](~/includes/RP-mvc-shared/sqlite-warn.md)]

---
<!-- End of VS tabs -->

## Seed the database

Create a new class named `SeedData` in the *Models* folder. Replace the generated code with the following:

[!code-csharp[](~/tutorials/first-mvc-app/start-mvc/sample/mvcmovie90/Models/SeedData.cs?name=snippet_FirstVersion)]

If there are any movies in the database, the seed initializer returns and no movies are added.

```csharp
if (context.Movie.Any())
{
    return;  // DB has been seeded.
}
```

<a name="si"></a>

### Add the seed initializer

# [Visual Studio](#tab/visual-studio)

Replace the contents of `Program.cs` with the following code. The new code is highlighted.

[!code-csharp[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie90/Program.cs?name=snippet_SQLServerSeedData&highlight=4,14-20)]

Delete all the records in the database. You can do this with the delete links in the browser or from SSOX.

Test the app. Force the app to initialize, calling the code in the `Program.cs` file, so the seed method runs. To force initialization, close the command prompt window that Visual Studio opened, and restart by pressing Ctrl+F5.

# [Visual Studio Code](#tab/visual-studio-code)

Update `Program.cs` with the following highlighted code:

[!code-csharp[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie90/Program.cs?name=snippet_SQLiteSeedData&highlight=4,15-20)]

Delete all the records in the database.

Test the app. Stop it and restart it so the `SeedData.Initialize` method runs and seeds the database.

---

The app shows the seeded data.

![MVC Movie app open in Microsoft Edge showing movie data](~/tutorials/first-mvc-app/working-with-sql/_static/9/m90.png)

> [!div class="step-by-step"]
> [Previous: Adding a model](~/tutorials/first-mvc-app/adding-model.md)
> [Next: Adding controller methods and views](~/tutorials/first-mvc-app/controller-methods-views.md)

:::moniker-end

[!INCLUDE[](~/tutorials/first-mvc-app/working-with-sql/includes/working-with-sql8.md)]

[!INCLUDE[](~/tutorials/first-mvc-app/working-with-sql/includes/working-with-sql7.md)]

[!INCLUDE[](~/tutorials/first-mvc-app/working-with-sql/includes/working-with-sql6.md)]

[!INCLUDE[](~/tutorials/first-mvc-app/working-with-sql/includes/working-with-sql3-5.md)]
