---
title: Adding Search to ASP.NET Core Razor Pages
author: rick-anderson
description: Shows how to add search to ASP.NET Core Razor Pages
keywords: ASP.NET Core,
ms.author: riande
manager: wpickett
ms.date: 08/07/2017
ms.topic: get-started-article
ms.technology: aspnet
ms.prod: asp.net-core
uid: tutorials/razor-pages/search
---

Adding Search to ASP.NET Core Razor Pages

# Adding Search to an ASP.NET Core MVC app

By [Rick Anderson](https://twitter.com/RickAndMSFT)

In this section you add search capability to the `Index` action method that lets you search movies by *genre* or *name*.

Update the `Index` method with the following code:

[!code-csharp[Main](razor-pages-start/sample/RazorPagesMovie/Pages/Movies/Index.cshtml.cs?name=snippet_1stSearch)]

The first line of the `Index` action method creates a [LINQ](http://msdn.microsoft.com/library/bb397926.aspx) query to select the movies:

```csharp
 var movies = from m in _context.Movie
              select m;
```

The query is *only* defined at this point, it has **not** been run against the database.

If the `searchString` parameter contains a string, the movies query is modified to filter on the value of the search string:

[!code-csharp[Main](razor-pages-start/sample/RazorPagesMovie/Pages/Movies/Index.cshtml.cs?name=snippet_SearchNull)]

The `s => s.Title.Contains()` code is a [Lambda Expression](http://msdn.microsoft.com/library/bb397687.aspx). Lambdas are used in method-based [LINQ](http://msdn.microsoft.com/library/bb397926.aspx) queries as arguments to standard query operator methods such as the [Where](http://msdn.microsoft.com/library/system.linq.enumerable.where.aspx) method or `Contains` (used in the preceeding code). LINQ queries are not executed when they are defined or when they are modified by calling a method such as `Where`, `Contains`  or `OrderBy`. Rather, query execution is deferred.  That means that the evaluation of an expression is delayed until its realized value is actually iterated over or the `ToListAsync` method is called. For more information about deferred query execution, see [Query Execution](http://msdn.microsoft.com/library/bb738633.aspx).

Note: The [Contains](http://msdn.microsoft.com/library/bb155125.aspx) method is run on the database, not in the c# code. The case sensitivity on the query depends on the database and the collation. On SQL Server, [Contains](http://msdn.microsoft.com/library/bb155125.aspx) maps to [SQL LIKE](http://msdn.microsoft.com/library/ms179859.aspx), which is case insensitive. In SQLlite, with the default collation, it's case sensitive.

Navigate to the Movies page and append a query string such as `?searchString=Ghost` to the URL (for example, `http://localhost:5000/Movies?searchString=Ghost`). The filtered movies are displayed.

![Index view](search/_static/ghost.png)

If you add the following route template to the Index page, you can pass the search string as route data.

```cshtml
@page "{searchString?}"
```

The preceding  route constraint allows searching the title as route data (a URL segment) instead of as a query string value.

![Index view with the word ghost added to the Url and a returned movie list of two movies, Ghostbusters and Ghostbusters 2](search/_static/g2.png)

However, you can't expect users to modify the URL every time they want to search for a movie. So now you'll add UI to help them filter movies. If you added the route constraint `"{searchString?}"`, remove it.

Open the *Pages/Movies/Index.cshtml* file, and add the `<form>` markup highlighted below:

[!code-HTML[Main](../../tutorials/first-mvc-app/start-mvc/sample/MvcMovie/Views/Movies/IndexForm1.cshtml?highlight=10-16&range=4-21)]
[!code-cshtml[Main](razor-pages-start/sample/RazorPagesMovie/Pages/Movies/Index2.cshtml?highlight=14-19&range=1-21)]

The HTML `<form>` tag uses the [Form Tag Helper](xref:mvc/views/working-with-forms#the-form-tag-helper). When you submit the form, the filter string is posted to the Pages/Movies/Index Razor Page. Save your changes and test the filter.

![Index view with the word ghost typed into the Title filter textbox](../../tutorials/first-mvc-app/search/_static/filter.png)

>[!div class="step-by-step"]
[Previous Updating the pages](xref:tutorials/razor-pages/da1)