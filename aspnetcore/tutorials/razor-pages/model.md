---
title: Add a model to a Razor Pages app in ASP.NET Core
author: rick-anderson
description: Discover how to add classes for managing movies in a database using Entity Framework Core (EF Core).
ms.author: riande
monikerRange: '>= aspnetcore-2.2'
ms.date: 05/30/2018
uid: tutorials/razor-pages/model
---
# Add a model to a Razor Pages app in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT)

In this section, classes are added for managing movies in a database. These classes are used with [Entity Framework Core](/ef/core) (EF Core) to work with a database. EF Core is an object-relational mapping (ORM) framework that simplifies data access code.

The model classes are known as POCO classes (from "plain-old CLR objects") because they don't have any dependency on EF Core. They define the properties of the data that are stored in the database.

[View or download](https://github.com/aspnet/Docs/tree/master/aspnetcore/tutorials/razor-pages-start/sample/) sample.

## Add a data model

<!-- VS -------------------------->

# [Visual Studio](#tab/visual-studio)

Right-click the **RazorPagesMovie** project > **Add** > **New Folder**. Name the folder *Models*.

Right click the *Models* folder. Select **Add** > **Class**. Name the class **Movie**.

Add the following properties to the `Movie` class:

[!code-csharp[](razor-pages-start/sample/RazorPagesMovie22/Models/Movie.cs?name=snippet1)]

The `Movie` class contains:

* The `ID` field is required by the database for the primary key.
* `[DataType(DataType.Date)]`:  The [DataType](/dotnet/api/microsoft.aspnetcore.mvc.dataannotations.internal.datatypeattributeadapter) attribute specifies the type of the data (Date). With this attribute:

  * The user is not required to enter time information in the date field.
  * Only the date is displayed, not time information.

[DataAnnotations](/dotnet/api/system.componentmodel.dataannotations) are covered in a later tutorial.

<!-- Code -------------------------->

# [Visual Studio Code](#tab/visual-studio-code)

* Add a folder named *Models*.
* Add a class to the *Models* folder named *Movie.cs*.

[!INCLUDE [model 2](~/includes/RP/model2.md)]

[!INCLUDE [model 3](~/includes/RP/model3.md)]

<a name="scaffold"></a>

<!-- Mac -------------------------->
# [Visual Studio for Mac](#tab/visual-studio-mac)

* In Solution Explorer, right-click the **RazorPagesMovie** project, and then select **Add** > **New Folder**. Name the folder *Models*.
* Right-click the *Models* folder, and then select **Add** > **New File**.
* In the **New File** dialog:

  * Select **General** in the left pane.
  * Select **Empty Class** in the center pain.
  * Name the class **Movie** and select **New**.

[!INCLUDE [model 2](~/includes/RP/model2.md)]

[!INCLUDE [model 3](~/includes/RP/model3.md)]

<!-- End of VS tabs -->

---

## Scaffold the movie model

In this section, the movie model is scaffolded. That is, the scaffolding tool produces pages for Create, Read, Update, and Delete (CRUD) operations for the movie model.

<!-- VS -------------------------->

# [Visual Studio](#tab/visual-studio)

Create a *Pages/Movies* folder:

* Right click on the *Pages* folder > **Add** > **New Folder**.
* Name the folder *Movies*

Right click on the *Pages/Movies* folder > **Add** > **New Scaffolded Item**.

![Image from the previous instructions.](model/_static/sca.png)

In the **Add Scaffold** dialog, select **Razor Pages using Entity Framework (CRUD)** > **Add**.

![Image from the previous instructions.](model/_static/add_scaffold.png)

Complete the **Add Razor Pages using Entity Framework (CRUD)** dialog:

* In the **Model class** drop down, select **Movie (RazorPagesMovie.Models)**.
* In the **Data context class** row, select the **+** (plus) sign and accept the generated name **RazorPagesMovie.Models.RazorPagesMovieContext**.
* Select **Add**.

![Image from the previous instructions.](model/_static/arp.png)

<!-- Code -------------------------->

# [Visual Studio Code](#tab/visual-studio-code)

<!-- Mac -------------------------->

# [Visual Studio for Mac](#tab/visual-studio-mac)

<!-- End of VS tabs -->

---

The scaffold process creates and updates the following files:

### Files created

* *Pages/Movies*: Create, Delete, Details, Edit, and Index.
* *Data/RazorPagesMovieContext.cs*

### File updated

* *Startup.cs*
* *appsettings.json*: The connection string used to connect to a local database is added.

The created and updated files are explained in the next section.

## Examine the context registered with dependency injection

ASP.NET Core is built with [dependency injection](xref:fundamentals/dependency-injection). Services (such as the EF Core DB context) are registered with dependency injection during application startup. Components that require these services (such as Razor Pages) are provided these services via constructor parameters. The constructor code that gets a DB context instance is shown later in the tutorial.

The scaffolding tool automatically created a DB context and registered it with the dependency injection container.

Examine the `Startup.ConfigureServices` method. The highlighted line was added by the scaffolder:

[!code-csharp[](razor-pages-start/sample/RazorPagesMovie22/Startup.cs?name=snippet_ConfigureServices&highlight=12-13)]

The main class that coordinates EF Core functionality for a given data model is the DB context class. The data context is derived from [Microsoft.EntityFrameworkCore.DbContext](/dotnet/api/microsoft.entityframeworkcore.dbcontext). The data context specifies which entities are included in the data model. In this project, the class is named `RazorPagesMovieContext`.

[!code-csharp[](razor-pages-start/sample/RazorPagesMovie22/Data/RazorPagesMovieContext.cs)]

The preceding code creates a [DbSet/\<Movie>](/dotnet/api/microsoft.entityframeworkcore.dbset-1) property for the entity set. In Entity Framework terminology, an entity set typically corresponds to a database table. An entity corresponds to a row in the table.

The name of the connection string is passed in to the context by calling a method on a [DbContextOptions](/dotnet/api/microsoft.entityframeworkcore.dbcontextoptions) object. For local development, the [ASP.NET Core configuration system](xref:fundamentals/configuration/index) reads the connection string from the *appsettings.json* file.

<a name="pim"></a>
## Perform initial migration

In this section, the Package Manager Console (PMC) is used to:

* Add an initial migration.
* Update the database with the initial migration.

From the **Tools** menu, select **NuGet Package Manager** > **Package Manager Console**.

  ![PMC menu](../first-mvc-app/adding-model/_static/pmc.png)

In the PMC, enter the following commands:

```PMC
Add-Migration Initial
Update-Database
```

Alternatively, the following .NET Core CLI commands can be used from the project folder:

```console
dotnet ef migrations add Initial
dotnet ef database update
```

Ignore the following warning message, you fix that in a a later tutorial:

```console
Microsoft.EntityFrameworkCore.Model.Validation[30000]
      No type was specified for the decimal column 'Price' on entity type 'Movie'. This will cause values to be silently truncated if they do not fit in the default precision and scale. Explicitly specify the SQL server column type that can accommodate all the values using 'ForHasColumnType()'.
```

The `Add-Migration` command generates code to create the initial database schema. The schema is based on the model specified in the `RazorPagesMovieContext` (In the *Data/RazorPagesMovieContext.cs* file). The `Initial` argument is used to name the migrations. You can use any name, but by convention you choose a name that describes the migration. See [Introduction to migrations](xref:data/ef-mvc/migrations#introduction-to-migrations) for more information.

The `Update-Database` command runs the `Up` method in the *Migrations/{time-stamp}_InitialCreate.cs* file, which creates the database.

If you get the error:

```console
SqlException: Cannot open database "RazorPagesMovieContext-GUID" requested by the login. The login failed.
Login failed for user 'User-name'.
```

You missed the [migrations step](#pmc).

<a name="test"></a>

### Test the app

* Run the app and append `/Movies` to the URL in the browser (`http://localhost:port/movies`).
* Test the **Create** link.

  ![Create page](model/_static/conan.png)

<a name="scaffold"></a>

* Test the **Edit**, **Details**, and **Delete** links.

If you get a SQL exception, verify you have run migrations and updated the database.

The next tutorial explains the files created by scaffolding.

> [!div class="step-by-step"]
> [Previous: Get Started](xref:tutorials/razor-pages/razor-pages-start)
> [Next: Scaffolded Razor Pages](xref:tutorials/razor-pages/page)
