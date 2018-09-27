---
title: Controller methods and views in ASP.NET Core
author: rick-anderson
description: Learn how to work with controller methods, views,  and DataAnnotations in ASP.NET Core.
ms.author: riande
ms.date: 04/07/2017
uid: tutorials/first-mvc-app-xplat/controller-methods-views
---

# Controller methods and views in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT)

We have a good start to the movie app, but the presentation isn't ideal. We don't want to see the time (12:00:00 AM in the image below) and **ReleaseDate** should be two words.

![Index view: Release Date is one word (no space) and every movie release date shows a time of 12 AM](../../tutorials/first-mvc-app/working-with-sql/_static/m55.png)

Open the *Models/Movie.cs* file and add the highlighted lines shown below:

[!code-csharp[](../../tutorials/first-mvc-app/start-mvc/sample/MvcMovie/Models/MovieDate.cs?name=snippet_1&highlight=2,11-12)]

Build and run the app.

<!-- include start
![MVC Movie application open browser showing movie data](../../tutorials/first-mvc-app/working-with-sql/_static/m55.png)

 -->

[!INCLUDE [adding-model](../../includes/mvc-intro/controller-methods-views.md)]

> [!div class="step-by-step"]
> [Previous - Working with SQLite](working-with-sql.md)
> [Next - Add search](search.md)  
