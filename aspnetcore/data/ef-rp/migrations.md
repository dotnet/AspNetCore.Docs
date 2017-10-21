---
title: Razor Pages with EF Core - Migrations - 4 of 10
author: tdykstra
description: In this tutorial, you start using the EF Core migrations feature for managing data model changes in an ASP.NET Core MVC app.
keywords: ASP.NET Core,Entity Framework Core,migrations
ms.author: tdykstra
manager: wpickett
ms.date: 10/15/2017
ms.topic: get-started-article
ms.technology: aspnet
ms.prod: asp.net-core
uid: data/ef-rp/migrations
---

# Migrations - EF Core with Razor Pages tutorial (4 of 10)

By [Tom Dykstra](https://github.com/tdykstra) and [Rick Anderson](https://twitter.com/RickAndMSFT)

The Contoso University web app demonstrates how to create Razor Pages web apps using EF Core and Visual Studio. For information about the tutorial series, see [the first tutorial](xref:data/ef-rp/intro).

In this tutorial, the EF Core migrations feature for managing data model changes is used. 

## Introduction to migrations

When a new app is developed, the data model changes frequently. Each time the model changes, the model gets out of sync with the database. This tutorial started by configuring the Entity Framework to create the database if it doesn't exist.  Each time the data model changes:

* The DB is dropped.
* EF creates a new one that matches the model.
* The app seeds the DB with test data.

This approch to keeping the DB in sync with the data model works well until you deploy the app to production. When the app is running in production it is usually storing data that needs to be maintained. The app can't start with a test DB each time  a change is made (such as adding a new column). The EF Core Migrations feature solves this problem by enabling EF to update the DB schema instead of creating  a new DB.

## Entity Framework Core NuGet packages for migrations

To work with migrations, use the **Package Manager Console** (PMC) or the command-line interface (CLI).  These tutorials show how to use CLI commands. Information about the PMC is at [the end of this tutorial](#pmc).

The EF tools for the command-line interface (CLI) are provided in [Microsoft.EntityFrameworkCore.Tools.DotNet](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools.DotNet). To install this package, add it to the `DotNetCliToolReference` collection in the *.csproj* file, as shown. **Note:** This package mustbe installed by editing the *.csproj* file.  The`install-package` command or the package manager GUI cannot be used to install this package. Edit the *.csproj* file by right-clicking the project name in **Solution Explorer** and selecting **Edit ContosoUniversity.csproj**.

The following markup shows the updated *.csproj* file with the EF CLI tools highlighted:

[!code-xml[](intro/samples/cu/ContosoUniversity.csproj?highlight=12)]
  
The version numbers in this example were current when the tutorial was written. Use the same version for the EF CLI tools found in the other packages. 

## Change the connection string

In the *appsettings.json* file, change the name of the DB in the connection string to ContosoUniversity2.

[!code-json[Main](intro/samples/cu/appsettings2.json?range=1-4)]

Changing the DB name in the connection string causes the first migration to create a new DB. A new DB is created because one with that name does not exist. This isn't required for getting started with migrations. Later in the tutorial, the advantages of creating a new DB are explained.

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

The command window how displays information similar to the following:

```console
info: Microsoft.AspNetCore.DataProtection.KeyManagement.XmlKeyManager[0]
      User profile is available. Using 'C:\Users\username\AppData\Local\ASP.NET\DataProtection-Keys' as key repository and Windows DPAPI to encrypt keys at rest.
info: Microsoft.EntityFrameworkCore.Infrastructure[100403]
      Entity Framework Core 2.0.0-rtm-26452 initialized 'SchoolContext' using provider 'Microsoft.EntityFrameworkCore.SqlServer' with options: None
Done. To undo this action, use 'ef migrations remove'
```

It the following error message is displayed "*cannot access the file ... ContosoUniversity.dll because it is being used by another process.*":

* Stop IIS Express.

   * Exit and restart Visual Studio, or
   * Find the IIS Express icon in the Windows System Tray.
   * Right-click the IIS Express icon, and then click **ContosoUniversity > Stop Site**.

## Examine the Up and Down methods

The EF command `migrations add` generated  code to create the DB from scratch. This code is in the *Migrations* folder, in the file named *\<timestamp>_InitialCreate.cs*. The `Up` method of the `InitialCreate` class creates the DB tables that correspond to the data model entity sets. The `Down` method deletes them, as shown in the following example.

[!code-csharp[Main](intro/samples/cu/Migrations/20171021031845_InitialCreate.cs?range=8-24,77-)]

Migrations calls the `Up` method to implement the data model changes for a migration. When you enter a command to roll back the update, Migrations calls the `Down` method.

This code is for the initial migration that was created when you entered the `migrations add InitialCreate` command. The migration name parameter ("InitialCreate" in the example) is used for the file name and can be whatever you want. It's best to choose a word or phrase that summarizes what is being done in the migration. For example, you might name a later migration "AddDepartmentTable".

If you created the initial migration when the DB already exists, the DB creation code is generated but it doesn't have to run because the DB already matches the data model. When you deploy the app to another environment where the DB doesn't exist yet, this code will run to create your DB, so it's a good idea to test it first. That's why you changed the name of the DB in the connection string earlier -- so that migrations can create a new one from scratch.

## Examine the data model snapshot

Migrations also creates a *snapshot* of the current DB schema in *Migrations/SchoolContextModelSnapshot.cs*. Here's what that code looks like:

<!-- zz
[!code-csharp[Main](intro/samples/cu/Migrations/SchoolContextModelSnapshot1.cs?name=snippet_Truncate)]

Because the current DB schema is represented in code, EF Core doesn't have to interact with the DB to create migrations. When you add a migration, EF determines what changed by comparing the data model to the snapshot file. EF interacts with the DB only when it has to update the DB. 

The snapshot file has to be kept in sync with the migrations that create it, so you can't remove a migration just by deleting the file named  *\<timestamp>_\<migrationname>.cs*. If you delete that file, the remaining migrations will be out of sync with the DB snapshot file. To delete the last migration that you added, use the [dotnet ef migrations remove](https://docs.microsoft.com/ef/core/miscellaneous/cli/dotnet#dotnet-ef-migrations-remove) command.

## Apply the migration to the DB

In the command window, enter the following command to create the DB and tables in it.

```console
dotnet ef database update
```

The output from the command is similar to the `migrations add` command, except that you see logs for the SQL commands that set up the DB. Most of the logs are omitted in the following sample output. If you prefer not to see this level of detail in log messages, you can change the log levels in the *appsettings.Development.json* file. For more information, see [Introduction to logging](xref:fundamentals/logging).

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

Use **SQL Server Object Explorer** to inspect the DB as you did in the first tutorial.  You'll notice the addition of an __EFMigrationsHistory table that keeps track of which migrations have been applied to the DB. View the data in that table and you'll see one row for the first migration. (The last log in the preceding CLI output example shows the INSERT statement that creates this row.)

Run the app to verify that everything still works the same as before.

![Students Index page](migrations/_static/students-index.png)

<a id="pmc"></a>
## Command-line interface (CLI) vs. Package Manager Console (PMC)

The EF tooling for managing migrations is available from .NET Core CLI commands or from PowerShell cmdlets in the Visual Studio **Package Manager Console** (PMC) window. This tutorial shows how to use the CLI, but you can use the PMC if you prefer.

The EF commands for the PMC commands are in the [Microsoft.EntityFrameworkCore.Tools](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools) package. This package is already included in the [Microsoft.AspNetCore.All](xref:fundamentals/metapackage) metapackage, so you don't have to install it.

**Important:** This is not the same package as the one you install for the CLI by editing the *.csproj* file. The name of this one ends in `Tools`, unlike the CLI package name which ends in `Tools.DotNet`.

For more information about the CLI commands, see [.NET Core CLI](https://docs.microsoft.com/ef/core/miscellaneous/cli/dotnet). 

For more information about the PMC commands, see [Package Manager Console (Visual Studio)](https://docs.microsoft.com/ef/core/miscellaneous/cli/powershell).


>[!div class="step-by-step"]
[Previous](sort-filter-page.md)
[Next](complex-data-model.md)  

-->