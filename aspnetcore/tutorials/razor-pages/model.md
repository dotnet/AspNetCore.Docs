---
title: Add a model to a Razor Pages app in ASP.NET Core
author: rick-anderson
description: Discover how to add classes for managing movies in a database using Entity Framework Core (EF Core).
ms.author: riande
ms.date: 05/30/2018
uid: tutorials/razor-pages/model
---
# Add a model to a Razor Pages app in ASP.NET Core

::: moniker range=">= aspnetcore-2.1"

[!INCLUDE [model1](~/includes/RP/model1.md)]

## Add a data model

In Solution Explorer, right-click the **RazorPagesMovie** project > **Add** > **New Folder**. Name the folder *Models*.

Right click the *Models* folder. Select **Add** > **Class**. Name the class **Movie** and add the following properties:

Replace the contents of the `Movie` class with the following code:

[!code-csharp[Main](razor-pages-start/sample/RazorPagesMovie21/Models/Movie1.cs?name=snippet)]

## Scaffold the movie model

In this section, the movie model is scaffolded. That is, the scaffolding tool produces pages for Create, Read, Update, and Delete (CRUD) operations for the movie model.

Create a *Pages/Movies* folder:

* In **Solution Explorer**, right click on the *Pages* folder > **Add** > **New Folder**.
* Name the folder *Movies*

In **Solution Explorer**, right click on the *Pages/Movies* folder > **Add** > **New Scaffolded Item**.

![Image from the previous instructions.](model/_static/sca.png)

In the **Add Scaffold** dialog, select **Razor Pages using Entity Framework (CRUD)** > **ADD**.

![Image from the previous instructions.](model/_static/add_scaffold.png)

Complete the **Add Razor Pages using Entity Framework (CRUD)** dialog:

* In the **Model class** drop down, select **Movie (RazorPagesMovie.Models)**.
* In the **Data context class** row, select the **+** (plus) sign and accept the generated name **RazorPagesMovie.Models.RazorPagesMovieContext**.
* In the **Data context class** drop down, select **RazorPagesMovie.Models.RazorPagesMovieContext**
* Select **Add**.

![Image from the previous instructions.](model/_static/arp.png)

The scaffold process created and changed the following files:

### Files created

* *Pages/Movies* Create, Delete, Details, Edit, Index. These pages are detailed in the next tutorial.
* *Data/RazorPagesMovieContext.cs*

### Files updates

* *Startup.cs*: Changes to this file are detailed in the next section.
* *appsettings.json*: The connection string used to connect to a local database is added.

## Examine the context registered with dependency injection

ASP.NET Core is built with [dependency injection](xref:fundamentals/dependency-injection). Services (such as the EF Core DB context) are registered with dependency injection during application startup. Components that require these services (such as Razor Pages) are provided these services via constructor parameters. The constructor code that gets a DB context instance is shown later in the tutorial.

The scaffolding tool automatically created a DB context and registered it with the dependency injection container.

Examine the `Startup.ConfigureServices` method. The highlighted line was added by the scaffolder:

[!code-csharp[](razor-pages-start/sample/RazorPagesMovie21/Startup.cs?name=snippet_ConfigureServices&highlight=12-13)]

The main class that coordinates EF Core functionality for a given data model is the DB context class. The data context is derived from [Microsoft.EntityFrameworkCore.DbContext](/dotnet/api/microsoft.entityframeworkcore.dbcontext). The data context specifies which entities are included in the data model. In this project, the class is named `RazorPagesMovieContext`.

[!code-csharp[](razor-pages-start/sample/RazorPagesMovie21/Data/RazorPagesMovieContext.cs)]

The preceding code creates a [DbSet\<Movie>](/dotnet/api/microsoft.entityframeworkcore.dbset-1) property for the entity set. In Entity Framework terminology, an entity set typically corresponds to a database table. An entity corresponds to a row in the table.

The name of the connection string is passed in to the context by calling a method on a [DbContextOptions](/dotnet/api/microsoft.entityframeworkcore.dbcontextoptions) object. For local development, the [ASP.NET Core configuration system](xref:fundamentals/configuration/index) reads the connection string from the *appsettings.json* file.

<a name="pmc"></a>
## Perform initial migration

In this section, you use the Package Manager Console (PMC) to:

* Add an initial migration.
* Update the database with the initial migration.

From the **Tools** menu, select **NuGet Package Manager** > **Package Manager Console**.

  ![PMC menu](../first-mvc-app/adding-model/_static/pmc.png)

In the PMC, enter the following commands:

```PMC
Add-Migration Initial
Update-Database
```

Alternatively, the following .NET Core CLI commands can be used:

```console
dotnet ef migrations add Initial
dotnet ef database update
```

Ignore the following warning message, you fix that in the next tutorial:

`Microsoft.EntityFrameworkCore.Model.Validation[30000]`

      *No type was specified for the decimal column 'Price' on entity type 'Movie'. This will cause values to be silently truncated if they do not fit in the default precision and scale. Explicitly specify the SQL server column type that can accommodate all the values using 'ForHasColumnType()'.*

The `Add-Migration` command generates code to create the initial database schema. The schema is based on the model specified in the `RazorPagesMovieContext` (In the *Data/RazorPagesMovieContext.cs* file). The `Initial` argument is used to name the migrations. You can use any name, but by convention you choose a name that describes the migration. See [Introduction to migrations](xref:data/ef-mvc/migrations#introduction-to-migrations) for more information.

The `Update-Database` command runs the `Up` method in the *Migrations/{time-stamp}_InitialCreate.cs* file, which creates the database.

If you get the error:

SqlException: Cannot open database "RazorPagesMovieContext-GUID" requested by the login. The login failed.
Login failed for user 'User-name'.

You missed the [migrations step](#pmc).
::: moniker-end

::: moniker range="= aspnetcore-2.0"

[!INCLUDE [model1](~/includes/RP/model1.md)]

## Add a data model

In Solution Explorer, right-click the **RazorPagesMovie** project > **Add** > **New Folder**. Name the folder *Models*.

Right click the *Models* folder. Select **Add** > **Class**. Name the class **Movie** and add the following properties:

[!INCLUDE [model 2](~/includes/RP/model2.md)]

<a name="cs"></a>
### Add a database connection string

Add a connection string to the *appsettings.json* file.

[!code-json[](../../tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie/appsettings.json?highlight=8-10)]

<a name="reg"></a>
###  Register the database context

Register the database context with the [dependency injection](xref:fundamentals/dependency-injection) container in the [ConfigureServices method of the Startup class](xref:fundamentals/startup#the-startup-class) (*Startup.cs*):

[!code-csharp[](../../tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie/Startup.cs?name=snippet_ConfigureServices&highlight=3-5,7-9)]

Build the project to verify you don't have any errors.

<a name="pmc"></a>
## Add scaffold tooling and perform initial migration

In this section, you use the Package Manager Console (PMC) to:

* Add the Visual Studio web code generation package. This package is required to run the scaffolding engine.
* Add an initial migration.
* Update the database with the initial migration.

From the **Tools** menu, select **NuGet Package Manager** > **Package Manager Console**.

  ![PMC menu](../first-mvc-app/adding-model/_static/pmc.png)

In the PMC, enter the following commands:

```powershell
Install-Package Microsoft.VisualStudio.Web.CodeGeneration.Design -Version 2.0.3
Add-Migration Initial
Update-Database
```

Alternatively, the following .NET Core CLI commands can be used:

```console
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet ef migrations add Initial
dotnet ef database update
```

Ignore the following message:

    `Microsoft.EntityFrameworkCore.Model.Validation[30000]`

      *No type was specified for the decimal column 'Price' on entity type 'Movie'. This will cause values to be silently truncated if they do not fit in the default precision and scale. Explicitly specify the SQL server column type that can accommodate all the values using 'ForHasColumnType()'*

You fix that in the next tutorial.

The `Install-Package` command installs the tooling required to run the scaffolding engine.

The `Add-Migration` command generates code to create the initial database schema. The schema is based on the model specified in the `DbContext` (In the *Models/MovieContext.cs* file). The `Initial` argument is used to name the migrations. You can use any name, but by convention you choose a name that describes the migration. See [Introduction to migrations](xref:data/ef-mvc/migrations#introduction-to-migrations) for more information.

The `Update-Database` command runs the `Up` method in the *Migrations/{time-stamp}_InitialCreate.cs* file, which creates the database.

[!INCLUDE [model 4windows](~/includes/RP/model4Win.md)]

[!INCLUDE [model 4](~/includes/RP/model4tbl.md)]

::: moniker-end

<a name="test"></a>

### Test the app

* Run the app and append `/Movies` to the URL in the browser (`http://localhost:port/movies`).
* Test the **Create** link.

  ![Create page](../../tutorials/razor-pages/model/_static/conan.png)

<a name="scaffold"></a>

* Test the **Edit**, **Details**, and **Delete** links.

If you get a SQL exception, verify you have run migrations and updated the database.

The next tutorial explains the files created by scaffolding.

> [!div class="step-by-step"]
> [Previous: Get Started](xref:tutorials/razor-pages/razor-pages-start)
> [Next: Scaffolded Razor Pages](xref:tutorials/razor-pages/page)
