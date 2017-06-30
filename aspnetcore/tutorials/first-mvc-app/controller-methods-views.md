---
title: Controller methods and views
author: rick-anderson
description: Working with controller methods, views and DataAnnotations
keywords: ASP.NET Core,
ms.author: riande
manager: wpickett
ms.date: 03/07/2017
ms.topic: get-started-article
ms.assetid: c7313211-b271-4adf-bab8-8e72603cc0ce
ms.technology: aspnet
ms.prod: asp.net-core
uid: tutorials/first-mvc-app/controller-methods-views
---

# Controller methods and views

By [Rick Anderson](https://twitter.com/RickAndMSFT)

We have a good start to the movie app, but the presentation is not ideal. We don't want to see the time (12:00:00 AM in the image below) and **ReleaseDate** should be two words.

![Index view: Release Date is one word (no space) and every movie release date shows a time of 12 AM](working-with-sql/_static/m55.png)

Open the *Models/Movie.cs* file and add the highlighted lines shown below:

[!code-csharp[Main](start-mvc/sample/MvcMovie/Models/MovieDateWithExtraUsings.cs?name=snippet_1&highlight=13-14)]

Right click on a red squiggly line **> Quick Actions and Refactorings**.

  ![Contextual menu shows **> Quick Actions and Refactorings**.](controller-methods-views/_static/qa.png)


Tap `using System.ComponentModel.DataAnnotations;`

  ![using System.ComponentModel.DataAnnotations at top of list](controller-methods-views/_static/da.png)

  Visual studio adds `using System.ComponentModel.DataAnnotations;`.

Let's remove the `using` statements that are not needed. They show up by default in a light grey font. Right click anywhere in the *Movie.cs* file **> Remove and Sort Usings**.

![Remove and Sort Usings](controller-methods-views/_static/rm.png)

The updated code:

[!code-csharp[Main](./start-mvc/sample/MvcMovie/Models/MovieDate.cs?name=snippet_1)]

<!-- include start -->

[!INCLUDE[adding-model](../../includes/mvc-intro/controller-methods-views.md)]

>[!div class="step-by-step"]
[Previous](working-with-sql.md)
[Next](search.md)  
