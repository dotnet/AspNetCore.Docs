---
title: Migrations | Microsoft Docs
author: tdykstra
description: 
keywords: ASP.NET Core,
ms.author: tdykstra
manager: wpickett
ms.date: 10/14/2016
ms.topic: article
ms.assetid: 81f6c9c2-a819-4f3a-97a4-4b0503b56c26
ms.technology: aspnet
ms.prod: aspnet-core
uid: data/ef-mvc/migrations
---
# Migrations

The Contoso University sample web application demonstrates how to create ASP.NET Core 1.0 MVC web applications using Entity Framework Core 1.0 and Visual Studio 2015. For information about the tutorial series, see [the first tutorial in the series](intro.md).

In this tutorial, you start using the EF Core migrations feature for managing data model changes. In later tutorials, you'll add more migrations as you change the data model.

## Introduction to migrations

When you develop a new application, your data model changes frequently, and each time the model changes, it gets out of sync with the database. You started these tutorials by configuring the Entity Framework to create the database if it doesn't exist. Then each time you change the data model -- add, remove, or change entity classes or change your DbContext class -- you can delete the database and EF creates a new one that matches the model, and seeds it with test data.

This method of keeping the database in sync with the data model works well until you deploy the application to production. When the application is running in production it is usually storing data that you want to keep, and you don't want to lose everything each time you make a change such as adding a new column. The EF Core Migrations feature solves this problem by enabling EF to update the database schema instead of creating  a new database.

## Change the connection string

In the *appsettings.json* file, change the name of the database in the connection string to ContosoUniversity2 or some other name that you haven't used on the computer you're using.

[!code-json[](intro/samples/cu/appsettings2.json?range=1-4)]

This change sets up the project so that the first migration will create a new database. This isn't required for getting started with migrations, but you'll see later why it's a good idea.

> [!NOTE]
> As an alternative to changing the database name, you can delete the database. Use **SQL Server Object Explorer** (SSOX) or the `database drop` CLI command:
> ```console
> dotnet ef database drop -c SchoolContext
> ```
> The following section explains how to run CLI commands.

## Create an initial migration

Save your changes and build the project. Then open a command window and navigate to the project folder. Here's a quick way to do that:

* In **Solution Explorer**, right-click the project and choose **Open in File Explorer** from the context menu.

  ![Open in File Explorer menu item](migrations/_static/open-in-file-explorer.png)

* Hold down the Shift key and right-click the project folder in File Explorer, then choose Open command window here from the context menu.

  ![Open command window](migrations/_static/open-command-window.png)

Before you enter a command, stop IIS Express for the site, or you may get an error message: "*cannot access the file ... ContosoUniversity.dll because it is being used by another process.*" To stop the site, find the IIS Express icon in the Windows System Tray, and right-click it, then click **ContosoUniversity > Stop Site**.

After you have stopped IIS Express, enter the following command in the command window:

```console
dotnet ef migrations add InitialCreate -c SchoolContext
```

You see output like the following in the command window:

```text
C:\ContosoUniversity\src\ContosoUniversity>dotnet ef migrations add InitialCreate -c SchoolContext
Project ContosoUniversity (.NETCoreApp,Version=v1.0) was previously compiled. Skipping compilation.

Done.

To undo this action, use 'dotnet ef migrations remove'
```

You have to include the `-c SchoolContext` parameter to specify the database context class, because the project has two context classes (the other one is for ASP.NET Identity).

## Examine the Up and Down methods

When you executed the `migrations add` command, EF generated the code that will create the database from scratch. This code is in the *Migrations* folder, in the file named *<timestamp>_InitialCreate.cs*. The `Up` method of the `InitialCreate` class creates the database tables that correspond to the data model entity sets, and the `Down` method deletes them, as shown in the following example.

[!code-csharp[Main](intro/samples/cu/Migrations/20160726224716_InitialCreate.cs?range=92-120)]

Migrations calls the `Up` method to implement the data model changes for a migration. When you enter a command to roll back the update, Migrations calls the `Down` method.

This code is for the initial migration that was created when you entered the `migrations add InitialCreate` command. The migration name parameter ("InitialCreate" in the example) is used for the file name and can be whatever you want. It's best to choose a word or phrase that summarizes what is being done in the migration. For example, you might name a later migration "AddDepartmentTable".

If you created the initial migration when the database already exists, the database creation code is generated but it doesn't have to run because the database already matches the data model. When you deploy the app to another environment where the database doesn't exist yet, this code will run to create your database, so it's a good idea to test it first. That's why you changed the name of the database in the connection string earlier -- so that migrations can create a new one from scratch.

## Examine the data model snapshot

Migrations also creates a "snapshot" of the current database schema in *Migrations/SchoolContextModelSnapshot.cs*. Here's what that code looks like:

[!code-csharp[Main](intro/samples/cu/Migrations/SchoolContextModelSnapshot1.cs?name=snippet_Truncate)]

Because this code has to reflect the database state after the latest migration,  you can't remove a migration just by deleting the file named  *<timestamp>_<migrationname>.cs*. If you delete that file, the remaining migrations will be out of sync with the database snapshot file. To delete the last migration that you added, use the [dotnet ef migrations remove](https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet#dotnet-ef-migrations-remove) command.

## Apply the migration to the database

In the command window, enter the following command to create the database and tables in it.

```console
dotnet ef database update -c SchoolContext
```

The output from the command is similar to the `migrations add` command.

```text
C:\ContosoUniversity\src\ContosoUniversity>dotnet ef database update -c SchoolContext
Project ContosoUniversity (.NETCoreApp,Version=v1.0) was previously compiled. Skipping compilation.

Done.
```

Use **SQL Server Object Explorer** to inspect the database as you did in the first tutorial.  You'll notice the addition of an __EFMigrationsHistory table that keeps track of which migrations have been applied to the database. View the data in that table and you'll see one entry for the first migration.

![Migrations history in SSOX](migrations/_static/migrations-table.png)

Run the application to verify that everything still works the same as before.

![Students Index page](migrations/_static/students-index.png)

## Command line interface (CLI) vs. Package Manager Console (PMC)

The EF tooling for managing migrations is available from .NET Core CLI commands or from PowerShell cmdlets in the Visual Studio **Package Manager Console** (PMC) window. In this preview version of the tooling, the CLI commands are more stable than the PMC cmdlets, so this tutorial shows how to use the .NET Core CLI commands.

For more information about the CLI commands, see [.NET Core CLI](https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet). For information about the PMC commands, see [Package Manager Console (Visual Studio)](https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/powershell).

## Summary

In this tutorial, you've seen how to create and apply your first migration. In the next tutorial, you'll begin looking at more advanced topics by expanding the data model. Along the way you'll create and apply additional migrations.

>[!div class="step-by-step"]
[Previous](sort-filter-page.md)
[Next](complex-data-model.md)  
