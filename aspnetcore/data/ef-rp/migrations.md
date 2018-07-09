---
title: Razor Pages with EF Core in ASP.NET Core - Migrations - 4 of 8
author: rick-anderson
description: In this tutorial, you start using the EF Core migrations feature for managing data model changes in an ASP.NET Core MVC app.
ms.author: riande
ms.date: 6/31/2017
uid: data/ef-rp/migrations
---

# Razor Pages with EF Core in ASP.NET Core - Migrations - 4 of 8

[!INCLUDE[2.0 version](~/includes/RP-EF/20-pdf.md)]

::: moniker range=">= aspnetcore-2.1"

By [Tom Dykstra](https://github.com/tdykstra), [Jon P Smith](https://twitter.com/thereformedprog), and [Rick Anderson](https://twitter.com/RickAndMSFT)

[!INCLUDE [about the series](~/includes/RP-EF/intro.md)]

In this tutorial, the EF Core migrations feature for managing data model changes is used.

If you run into problems you can't solve, download the [completed app](
https://github.com/aspnet/Docs/tree/master/aspnetcore/data/ef-rp/intro/samples).

When a new app is developed, the data model changes frequently. Each time the model changes, the model gets out of sync with the database. This tutorial started by configuring the Entity Framework to create the database if it doesn't exist. Each time the data model changes:

* The DB is dropped.
* EF creates a new one that matches the model.
* The app seeds the DB with test data.

This approach to keeping the DB in sync with the data model works well until you deploy the app to production. When the app is running in production, it's usually storing data that needs to be maintained. The app can't start with a test DB each time a change is made (such as adding a new column). The EF Core Migrations feature solves this problem by enabling EF Core to update the DB schema instead of creating a new DB.

Rather than dropping and recreating the DB when the data model changes, migrations updates the schema and retains existing data.

## Drop the database

Use **SQL Server Object Explorer** (SSOX) or the `database drop` command:

# [Visual Studio](#tab/visual-studio)

In the **Package Manager Console** (PMC), run the following command:

```PMC
Drop-Database
```

Run `Get-Help about_EntityFrameworkCore` from the PMC to get help information.

# [.NET Core CLI](#tab/netcore-cli)

Open a command window and navigate to the project folder. The project folder contains the *Startup.cs* file.

Enter the following in the command window:

 ```console
 dotnet ef database drop
 ```

------

## Create an initial migration and update the DB

Build the project and create the first migration.

# [Visual Studio](#tab/visual-studio)

```PMC
Add-Migration InitialCreate
Update-Database
```

# [.NET Core CLI](#tab/netcore-cli)

```console
dotnet ef migrations add InitialCreate
dotnet ef database update
```

------

### Examine the Up and Down methods

The EF Core `migrations add` command  generated code to create the DB. This migrations code is in the *Migrations\<timestamp>_InitialCreate.cs* file. The `Up` method of the `InitialCreate` class creates the DB tables that correspond to the data model entity sets. The `Down` method deletes them, as shown in the following example:

[!code-csharp[](intro/samples/cu21/Migrations/20180626224812_InitialCreate.cs?range=7-24,77-88)]

Migrations calls the `Up` method to implement the data model changes for a migration. When you enter a command to roll back the update, migrations calls the `Down` method.

The preceding code is for the initial migration. That code was created when the `migrations add InitialCreate` command was run. The migration name parameter ("InitialCreate" in the example) is used for the file name. The migration name can be any valid file name. It's best to choose a word or phrase that summarizes what is being done in the migration. For example, a migration that added a department table might be called "AddDepartmentTable."

If the initial migration is created and the DB exists:

* The DB creation code is generated.
* The DB creation code doesn't need to run because the DB already matches the data model. If the DB creation code is run, it doesn't make any changes because the DB already matches the data model.

When the app is deployed to a new environment, the DB creation code must be run to create the DB.

Previously the DB was dropped and doesn't exist, so migrations creates the new DB.

### The data model snapshot

Migrations create a *snapshot* of the current database schema in *Migrations/SchoolContextModelSnapshot.cs*. When you add a migration, EF determines what changed by comparing the data model to the snapshot file.

To delete a migration, use the following command:

# [Visual Studio](#tab/visual-studio)

Remove-Migration

# [.NET Core CLI](#tab/netcore-cli)

```console
dotnet ef migrations remove
```

For more information, see  [dotnet ef migrations remove](/ef/core/miscellaneous/cli/dotnet#dotnet-ef-migrations-remove).

------

The remove migrations command deletes the migration and ensures the snapshot is correctly reset.

### Remove EnsureCreated and test the app

For early development, `EnsureCreated` was used. In this tutorial, migrations are used. `EnsureCreated` has the following limitations:

* Bypasses migrations and creates the DB and schema.
* Doesn't create a migrations table.
* Can *not* be used with migrations.
* Is designed for testing or rapid prototyping where the DB is dropped and re-created frequently.

Remove the following line from `DbInitializer`:

```csharp
context.Database.EnsureCreated();
```

Run the app and verify the DB is seeded.

### Inspect the database

Use **SQL Server Object Explorer** to inspect the DB. Notice the addition of an `__EFMigrationsHistory` table. The `__EFMigrationsHistory` table keeps track of which migrations have been applied to the DB. View the data in the `__EFMigrationsHistory` table, it shows one row for the first migration. The last log in the preceding CLI output example shows the INSERT statement that creates this row.

Run the app and verify that everything works.

## Applying migrations in production

We recommend production apps should **not** call [Database.Migrate](/dotnet/api/microsoft.entityframeworkcore.relationaldatabasefacadeextensions.migrate?view=efcore-2.0#Microsoft_EntityFrameworkCore_RelationalDatabaseFacadeExtensions_Migrate_Microsoft_EntityFrameworkCore_Infrastructure_DatabaseFacade_) at application startup. `Migrate` shouldn't be called from an app in server farm. For example, if the app has been cloud deployed with scale-out (multiple instances of the app are running).

Database migration should be done as part of deployment, and in a controlled way. Production database migration approaches include:

* Using migrations to create SQL scripts and using the SQL scripts in deployment.
* Running `dotnet ef database update` from a controlled environment.

EF Core uses the `__MigrationsHistory` table to see if any migrations need to run. If the DB is up-to-date, no migration is run.

## Troubleshooting

Download the [completed app](
https://github.com/aspnet/Docs/tree/master/aspnetcore/data/ef-rp/intro/samples/StageSnapShots/cu-part4-migrations).

The app generates the following exception:

```text
SqlException: Cannot open database "ContosoUniversity" requested by the login.
The login failed.
Login failed for user 'user name'.
```

Solution: Run `dotnet ef database update`

### Additional resources

* [.NET Core CLI](/ef/core/miscellaneous/cli/dotnet).
* [Package Manager Console (Visual Studio)](/ef/core/miscellaneous/cli/powershell)

::: moniker-end

> [!div class="step-by-step"]
> [Previous](xref:data/ef-rp/sort-filter-page)
> [Next](xref:data/ef-rp/complex-data-model)
