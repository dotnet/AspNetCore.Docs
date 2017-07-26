---
title: Adding a model to a Razor Pages app in ASP.NET Core
author: rick-anderson
description: Adding a model to a Razor Pages app in ASP.NET Core
keywords: ASP.NET Core,Razor Pages,Razor,MVC
ms.author: riande
manager: wpickett
ms.date: 7/27/2017
ms.topic: get-started-article
ms.technology: aspnet
ms.prod: aspnet-core
uid: tutorials/razor-pages/model
---
# Adding a model to a Razor Pages app

By [Rick Anderson](https://twitter.com/RickAndMSFT)

In this section you add some classes for managing movies in a database. You use these classes with the [Entity Framework Core](https://docs.microsoft.com/ef/core) (EF Core) to work with a database. EF Core is an object-relational mapping (ORM) framework that simplifies the data-access code that you have to write.

The model classes you'll create are known as POCO classes (from "plain-old CLR objects") because they don't have any dependency on EF Core. They just define the properties of the data that are stored in the database.

In this tutorial you write the model classes first, and EF Core creates the database. An alternate approach not covered here is to generate model classes from an already-existing database. For information about that approach, see [ASP.NET Core - Existing Database](https://docs.microsoft.com/ef/core/get-started/aspnetcore/existing-db).

## Add a data model class

In Solution Explorer, right click the **RazorPagesMovie** project > **Add** > **New Folder**. Name the folder *Models*.

Right click the *Models* folder > **Add** > **Class**. Name the class **Movie** and add the following properties:

[!code-csharp[Main](razor-pages-start\sample\RazorPagesMovie\Models\MovieNoEF.cs?name=MovieNoEF)]

The `ID` field is required by the database for the primary key. 

Build the project to verify you don't have any errors.


>[!div class="step-by-step"]
[Previous Getting Started](razor-pages-start.md)
<!--
[Next Working with SQL](working-with-sql.md)    
-->
