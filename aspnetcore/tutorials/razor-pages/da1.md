---
title: Update the generated pages in an ASP.NET Core app
author: rick-anderson
description: Learn how to update the generated pages in an ASP.NET Core app.
monikerRange: '>= aspnetcore-2.0'
ms.author: riande
ms.date: 05/30/2018
uid: tutorials/razor-pages/da1
---
# Update the generated pages in an ASP.NET Core app

By [Rick Anderson](https://twitter.com/RickAndMSFT)

We have a good start to the movie app, but the presentation isn't ideal. We don't want to see the time (12:00:00 AM in the image below) and **ReleaseDate** should be **Release Date** (two words).

![Movie application open in Chrome showing movie data](sql/_static/m55.png)

## Update the generated code

Open the *Models/Movie.cs* file and add the highlighted lines shown in the following code:

[!code-csharp[](~/tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie22/Models/MovieDate.cs?name=snippet_1&highlight=10-11,15)]


[!INCLUDE [model1](~/includes/RP/da2.md)]

> [!div class="step-by-step"]
> [Previous: Working with SQL Server LocalDB](xref:tutorials/razor-pages/sql)
> [Next: Add search](xref:tutorials/razor-pages/search)
