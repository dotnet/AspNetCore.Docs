---
title: Razor Pages with EF Core - Migrations - 4 of 8
author: rick-anderson
description: In this tutorial, you start using the EF Core migrations feature for managing data model changes in an ASP.NET Core MVC app.
manager: wpickett
ms.author: riande
ms.date: 10/15/2017
ms.prod: asp.net-core
ms.technology: aspnet
ms.topic: get-started-article
uid: data/ef-rp/migrations
---

# Migrations - EF Core with Razor Pages tutorial (4 of 8)

By [Tom Dykstra](https://github.com/tdykstra), [Jon P Smith](https://twitter.com/thereformedprog), and [Rick Anderson](https://twitter.com/RickAndMSFT)

[!INCLUDE[about the series](../../includes/RP-EF/intro.md)]

In this tutorial, the EF Core migrations feature for managing data model changes is used.

If you run into problems you can't solve, download the [completed app for this stage](
https://github.com/aspnet/Docs/tree/master/aspnetcore/data/ef-rp/intro/samples/StageSnapShots/cu-part4-migrations).

When a new app is developed, the data model changes frequently. Each time the model changes, the model gets out of sync with the database. This tutorial started by configuring the Entity Framework to create the database if it doesn't exist. Each time the data model changes:

* The DB is dropped.
* EF creates a new one that matches the model.
* The app seeds the DB with test data.

This approach to keeping the DB in sync with the data model works well until you deploy the app to production. When the app is running in production, it's usually storing data that needs to be maintained. The app can't start with a test DB each time a change is made (such as adding a new column). The EF Core Migrations feature solves this problem by enabling EF Core to update the DB schema instead of creating a new DB.

Rather than dropping and recreating the DB when the data model changes, migrations updates the schema and retains existing data.

## Entity Framework Core NuGet packages for migrations

To work with migrations, use the **Package Manager Console** (PMC) or the command-line interface (CLI). These tutorials show how to use CLI commands. Information about the PMC is at [the end of this tutorial](#pmc).

The EF Core tools for the command-line interface (CLI) are provided in [Microsoft.EntityFrameworkCore.Tools.DotNet](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools.DotNet). To install this package, add it to the `DotNetCliToolReference` collection in the *.csproj* file, as shown. **Note:** This package must be installed by editing the *.csproj* file. The`install-package` command or the package manager GUI cannot be used to install this package. Edit the *.csproj* file by right-clicking the project name in **Solution Explorer** and selecting **Edit ContosoUniversity.csproj**.

The following markup shows the updated *.csproj* file with the EF Core CLI tools highlighted:

[!code-xml[](intro/samples/cu/ContosoUniversity.csproj?highlight=12)]
  
The version numbers in the preceding example were current when the tutorial was written. Use the same version for the EF Core CLI tools found in the other packages.

## Change the connection string

In the *appsettings.json* file, change the name of the DB in the connection string to ContosoUniversity2.

[!code-json[Main](intro/samples/cu/appsettings2.json?range=1-4)]

Changing the DB name in the connection string causes the first migration to create a new DB. A new DB is created because one with that name doesn't exist. Changing the connection string isn't required for getting started with migrations.

An alternative to changing the DB name is deleting the DB. Use **SQL Server Object Explorer** (SSOX) or the `database drop` CLI command:

 ```console
 dotnet ef database drop
 ```

The following section explains how to run CLI commands.

## Create an initial migration

Build the project.

Open a command window and navigate to the project folder. The project folder contains the *Startup.cs* file.

Enter the following in the command window:

```console
dotnet ef migrations add InitialCreate
```

The command window displays information similar to the following:

```console
info: Microsoft.AspNetCore.DataProtection.KeyManagement.XmlKeyManager[0]
      User profile is available. Using 'C:\Users\username\AppData\Local\ASP.NET\DataProtection-Keys' as key repository and Windows DPAPI to encrypt keys at rest.
info: Microsoft.EntityFrameworkCore.Infrastructure[100403]
      Entity Framework Core 2.0.0-rtm-26452 initialized 'SchoolContext' using provider 'Microsoft.EntityFrameworkCore.SqlServer' with options: None
Done. To undo this action, use 'ef migrations remove'
```

If the migration fails with the message "*cannot access the file ... ContosoUniversity.dll because it is being used by another process.*" is displayed:

* Stop IIS Express.

   * Exit and restart Visual Studio, or
   * Find the IIS Express icon in the Windows System Tray.
   * Right-click the IIS Express icon, and then click **ContosoUniversity > Stop Site**.

If the error message "Build failed." is displayed, run the command again. If you get this error, leave a note at the bottom of this tutorial.

### Examine the Up and Down methods

The EF Core command `migrations add` generated code to create the DB from. This migrations code is in the *Migrations\<timestamp>_InitialCreate.cs* file. The `Up` method of the `InitialCreate` class creates the DB tables that correspond to the data model entity sets. The `Down` method deletes them, as shown in the following example:

[!code-csharp[Main](intro/samples/cu/Migrations/20171026010210_InitialCreate.cs?range=8-24,77-)]

Migrations calls the `Up` method to implement the data model changes for a migration. When you enter a command to roll back the update, migrations calls the `Down` method.

The preceding code is for the initial migration. That code was created when the `migrations add InitialCreate` command was run. The migration name parameter ("InitialCreate" in the example) is used for the file name. The migration name can be any valid file name. It's best to choose a word or phrase that summarizes what is being done in the migration. For example, a migration that added a department table might be called "AddDepartmentTable."

If the initial migration is created and the DB exits:

* The DB creation code is generated.
* The DB creation code doesn't need to run because the DB already matches the data model. If the DB creation code is run, it doesn't make any changes because the DB already matches the data model.

When the app is deployed to a new environment, the DB creation code must be run to create the DB.

Previously the connection string was changed to use a new name for the DB. The specified DB doesn't exist, so migrations creates the DB.

### Examine the data model snapshot

Migrations creates a *snapshot* of the current DB schema in *Migrations/SchoolContextModelSnapshot.cs*:

[!code-csharp[Main](intro/samples/cu/Migrations/SchoolContextModelSnapshot1.cs?name=snippet_Truncate)]

Because the current DB schema is represented in code, EF Core doesn't have to interact with the DB to create migrations. When you add a migration, EF Core determines what changed by comparing the data model to the snapshot file. EF Core interacts with the DB only when it has to update the DB.

The snapshot file must be in sync with the migrations that created it. A migration can't be removed by deleting the file named *\<timestamp>_\<migrationname>.cs*. If that file is deleted, the remaining migrations are out of sync with the DB snapshot file. To delete the last migration added, use the [dotnet ef migrations remove](https://docs.microsoft.com/ef/core/miscellaneous/cli/dotnet#dotnet-ef-migrations-remove) command.

## Remove EnsureCreated

For early development, the `EnsureCreated` command was used. In this tutorial, migrations is used. `EnsureCreated` has the following limitations:

* Bypasses migrations and creates the DB and schema.
* Doesn't create a migrations table.
* Can *not* be used with migrations.
* Is designed for testing or rapid prototyping where the DB is dropped and re-created frequently.

Remove the following line from `DbInitializer`:

```csharp
context.Database.EnsureCreated();
```

## Apply the migration to the DB in development

In the command window, enter the following to create the DB and tables.

```console
dotnet ef database update
```

Note: If the `update` command returns the error "Build failed.":

* Run the command again.
* If it fails again, exit Visual Studio and then run the `update` command.
* Leave a message at the bottom of the page.

The output from the command is similar to the `migrations add` command output. In the preceding command, logs for the SQL commands that set up the DB are displayed. Most of the logs are omitted in the following sample output:

```text
info: Microsoft.AspNetCore.DataProtection.KeyManagement.XmlKeyManager[0]
      User profile is available. Using 'C:\Users\username\AppData\Local\ASP.NET\DataProtection-Keys' as key repository and Windows DPAPI to encrypt keys at rest.
info: Microsoft.EntityFrameworkCore.Infrastructure[100403]
      Entity Framework Core 2.0.0-rtm-26452 initialized 'SchoolContext' using provider 'Microsoft.EntityFrameworkCore.SqlServer' with options: None
info: Microsoft.EntityFrameworkCore.Database.Command[200101]
      Executed DbCommand (467ms) [Parameters=[], CommandType='Text', CommandTimeout='60']
      CREATE DATABASE [ContosoUniversity2];
info: Microsoft.EntityFrameworkCore.Database.Command[200101]
      Executed DbCommand (20ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE [__EFMigrationsHistory] (
          [MigrationId] nvarchar(150) NOT NULL,
          [ProductVersion] nvarchar(32) NOT NULL,
          CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
      );

<logs omitted for brevity>

info: Microsoft.EntityFrameworkCore.Database.Command[200101]
      Executed DbCommand (3ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
      VALUES (N'20170816151242_InitialCreate', N'2.0.0-rtm-26452');
Done.
```

To reduce the level of detail in log messages, can change the log levels in the *appsettings.Development.json* file. For more information, see [Introduction to logging](xref:fundamentals/logging/index).

Use **SQL Server Object Explorer** to inspect the DB. Notice the addition of an `__EFMigrationsHistory` table. The `__EFMigrationsHistory` table keeps track of which migrations have been applied to the DB. View the data in the `__EFMigrationsHistory` table, it shows one row for the first migration. The last log in the preceding CLI output example shows the INSERT statement that creates this row.

Run the app and verify that everything works.

## Appling migrations in production

We recommend production apps should **not** call [Database.Migrate](https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.relationaldatabasefacadeextensions.migrate?view=efcore-2.0#Microsoft_EntityFrameworkCore_RelationalDatabaseFacadeExtensions_Migrate_Microsoft_EntityFrameworkCore_Infrastructure_DatabaseFacade_) at application startup. `Migrate` shouldn't be called from an app in server farm. For example, if the app has been cloud deployed with scale-out (multiple instances of the app are running).

Database migration should be done as part of deployment, and in a controlled way. Production database migration approaches include:

* Using migrations to create SQL scripts and using the SQL scripts in deployment.
* Running `dotnet ef database update` from a controlled environment.

EF Core uses the `__MigrationsHistory` table to see if any migrations need to run. If the DB is up to date, no migration is run.

<a id="pmc"></a>
## Command-line interface (CLI) vs. Package Manager Console (PMC)

The EF Core tooling for managing migrations is available from:

* .NET Core CLI commands.
* The PowerShell cmdlets in the Visual Studio **Package Manager Console** (PMC) window.

This tutorial shows how to use the CLI, some developers prefer using the PMC.

The EF Core commands for the PMC are in the [Microsoft.EntityFrameworkCore.Tools](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools) package. This package is included in the [Microsoft.AspNetCore.All](xref:fundamentals/metapackage) metapackage, so you don't have to install it.

**Important:** This isn't the same package as the one you install for the CLI by editing the *.csproj* file. The name of this one ends in `Tools`, unlike the CLI package name which ends in `Tools.DotNet`.

For more information about the CLI commands, see [.NET Core CLI](https://docs.microsoft.com/ef/core/miscellaneous/cli/dotnet).

For more information about the PMC commands, see [Package Manager Console (Visual Studio)](https://docs.microsoft.com/ef/core/miscellaneous/cli/powershell).

## Troubleshooting

Download the [completed app for this stage](
https://github.com/aspnet/Docs/tree/master/aspnetcore/data/ef-rp/intro/samples/StageSnapShots/cu-part4-migrations).

The app generates the following exception:

```text
`SqlException: Cannot open database "ContosoUniversity" requested by the login.
The login failed.
Login failed for user 'user name'.
```

Solution: Run `dotnet ef database update`

If the `update` command returns the error "Build failed.":

* Run the command again.
* Leave a message at the bottom of the page.

>[!div class="step-by-step"]
[Previous](xref:data/ef-rp/sort-filter-page)
[Next](xref:data/ef-rp/complex-data-model)
