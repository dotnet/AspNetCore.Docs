---
title: Controller methods and views in an ASP.NET Core MVC app
author: rick-anderson
description: Working with controller methods, views and DataAnnotations
keywords: ASP.NET Core,
ms.author: riande
manager: wpickett
ms.date: 04/07/2017
ms.topic: get-started-article
ms.assetid: c7313211-babe-babe-babe-8e72603cc0ce
ms.technology: aspnet
ms.prod: asp.net-core
uid: tutorials/first-mvc-app-mac/controller-methods-views
---

# Controller methods and views in an ASP.NET Core MVC app

By [Rick Anderson](https://twitter.com/RickAndMSFT)

We have a good start to the movie app, but the presentation is not ideal. We don't want to see the time (12:00:00 AM in the following image) and **ReleaseDate** should be two words.

![Index view: Release Date is one word (no space) and every movie release date shows a time of 12 AM](../../tutorials/first-mvc-app/working-with-sql/_static/m55.png)

Open the *Models/Movie.cs* file and add the highlighted lines shown below:

[!code-csharp[Main](../../tutorials/first-mvc-app/start-mvc/sample/MvcMovie/Models/MovieDate.cs?name=snippet_1&highlight=2,11-12)]

Build and run the app.

<!-- include start
![MVC Movie application open browser showing movie data](../../tutorials/first-mvc-app/working-with-sql/_static/m55.png)

 -->

[!INCLUDE[adding-model](../../includes/mvc-intro/controller-methods-views.md)]

>[!div class="step-by-step"]
[Previous - Working with SQLite](working-with-sql.md)
[Next - Add search](search.md)
