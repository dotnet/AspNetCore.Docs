---
title: Overview of Single Page Applications (SPA) in ASP.NET Core
author: rick-anderson
ms.author: jacalvar
monikerRange: '>= aspnetcore-6.0'
description: Overview of Single Page Applications (SPA) in ASP.NET Core
ms.date: 2/11/2023
uid: spa/intro
---
# Overview of Single Page Applications (SPA) in ASP.NET Core

[!INCLUDE[](~/includes/not-latest-version.md)]

::: moniker range=">= aspnetcore-8.0"

Starting with ASP.NET Core 8.0, we recommend that you use the Visual Studio project templates to create single-page apps (SPAs) based on JavaScript frameworks such as [Angular](https://angular.io/), [React](https://facebook.github.io/react/), and [Vue](https://vuejs.org/). These templates:

* Create a Visual Studio solution with a frontend project and a backend project.
* Use the Visual Studio project type for JavaScript and TypeScript (*.esproj*) for the frontend.
* Use a [minimal API](xref:fundamentals/minimal-apis/overview) project for the backend.

## Visual Studio documentation

To get started, follow one of the tutorials in the Visual Studio documentation:

* [Angular with Visual Studio](/visualstudio/javascript/tutorial-asp-net-core-with-angular)
* [React with Visual Studio](/visualstudio/javascript/tutorial-asp-net-core-with-react)
* [Vue with Visual Studio](/visualstudio/javascript/tutorial-asp-net-core-with-vue)

For more information, see [JavaScript and TypeScript in Visual Studio](/visualstudio/javascript/javascript-in-visual-studio)

## Newer vs. older SPA templates

The SPA templates that use the special project type for JavaScript and TypeScript are available in Visual Studio 2022 version 17.7 or later with the **ASP.NET and web development** workload installed. They are available only in Visual Studio, not by using the `dotnet new` command of the .NET CLI.

There are older SPA templates that don't use the special project type for JavaScript and TypeScript. They are available via the `dotnet new angular` or `dotnet new react` command if you install an earlier SDK version, such as [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) or [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0). For documentation on these older templates, see the ASP.NET Core 7.0 version of this article, [Angular](xref:spa/angular?view=aspnetcore-7.0&tabs=netcore-cli), and [React](xref:spa/react?view=aspnetcore-7.0&tabs=netcore-cli).

::: moniker-end

[!INCLUDE[](~/client-side/spa/includes/intro6-7.md)]
