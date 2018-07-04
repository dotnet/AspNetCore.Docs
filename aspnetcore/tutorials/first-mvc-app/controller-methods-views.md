---
title: Controller methods and views in ASP.NET Core
author: rick-anderson
description: Learn how to work with controller methods, views, and DataAnnotations in ASP.NET Core.
ms.author: riande
ms.date: 03/07/2017
uid: tutorials/first-mvc-app/controller-methods-views
---

# Controller methods and views in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT)

We have a good start to the movie app, but the presentation isn't ideal. We don't want to see the time (12:00:00 AM in the image below) and **ReleaseDate** should be two words.

![Index view: Release Date is one word (no space) and every movie release date shows a time of 12 AM](working-with-sql/_static/m55.png)

Open the *Models/Movie.cs* file and add the highlighted lines shown below:

::: moniker range=">= aspnetcore-2.1"
[!code-csharp[](start-mvc/sample/MvcMovie21/Models/MovieDateFixed.cs?name=snippet_1&highlight=2,3,12-13,17)]
::: moniker-end
::: moniker range="<= aspnetcore-2.0"
[!code-csharp[](start-mvc/sample/MvcMovie/Models/MovieDateWithExtraUsings.cs?name=snippet_1&highlight=13-14)]
::: moniker-end

[!INCLUDE [adding-model](~/includes/mvc-intro/controller-methods-views.md)]

> [!div class="step-by-step"]
> [Previous](working-with-sql.md)
> [Next](search.md)  
