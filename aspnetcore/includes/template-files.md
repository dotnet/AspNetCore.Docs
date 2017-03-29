---
title: Template files | Microsoft Docs
author: rick-anderson
description: Template file include
keywords: ASP.NET Core, MVC
ms.author: riande
manager: wpickett
ms.date: 03/29/2017
ms.topic: include
ms.assetid: 1638b589-e3fd-1638-bde6-fb0f41998FFF
ms.technology: aspnet
ms.prod: asp.net-core
uid: includes/template-files
---

* Startup.cs : [Startup Class](../fundamentals/startup.md) - class configures the request pipeline that handles all requests made to the application.
* Program.cs : [Program Class](../fundamentals/index.md) that contains the Main entry point of the application.
* firstapp.csproj : [Project file](https://docs.microsoft.com/en-us/dotnet/articles/core/preview3/tools/csproj) MSBuild Project file format for ASP.NET Core applications. Contains Project to Project references, NuGet References and other project related items.
* appsettings.json / appsettings.Development.json : Environment base app settings configuration file. [See Configuration](xref:fundamentals/configuration).
* bower.json : Bower package dependencies for the project.
* .bowerrc : Bower configuration file which defines where to install the components when Bower downloads the assets.
* bundleconfig.json : configuration files for bundling and minifying front-end JavaScript and CSS assets.
* Views : Contains the Razor views. Views are the components that display the app's user interface (UI). Generally, this UI displays the model data.
* Controllers : Contains MVC Controllers, initially *HomeController.cs*. Controllers are classes that handle browser requests.
* wwwroot : Web application root folder.

For more information see [The MVC pattern](xref:mvc/overview).