---
title: Part 6, add search
author: wadepickett
description: Part 6 of tutorial series on Razor Pages.
ms.author: wpickett
ms.date: 01/08/2026
uid: tutorials/razor-pages/search
---
# Part 6, add search to ASP.NET Core Razor Pages

[!INCLUDE[](~/includes/not-latest-version.md)]

By [Rick Anderson](https://twitter.com/RickAndMSFT)

:::moniker range=">= aspnetcore-10.0"

In the following sections, you add the ability to search movies by *genre* or *name*.

Add the following highlighted code to `Pages/Movies/Index.cshtml.cs`:

[!code-csharp[](~/tutorials/razor-pages/razor-pages-start/snapshot-sample10/Pages/Movies/Index.cshtml.cs?name=snippet_search_newProps&highlight=12-18)]

In the previous code:

* `SearchString`: Contains the text users enter in the search text box. `SearchString` has the [`[BindProperty]`](xref:Microsoft.AspNetCore.Mvc.BindPropertyAttribute) attribute. `[BindProperty]` binds form values and query strings with the same name as the property. `[BindProperty(SupportsGet = true)]` is required for binding on HTTP GET requests.
* `Genres`: Contains the list of genres. `Genres` allows the user to select a genre from the list. `SelectList` requires `using Microsoft.AspNetCore.Mvc.Rendering;`
* `MovieGenre`: Contains the specific genre the user selects. For example, "Western".
* `Genres` and `MovieGenre` are used later in this tutorial.

[!INCLUDE[](~/includes/bind-get.md)]

Update the `Movies/Index` page's `OnGetAsync` method with the following code:

[!code-csharp[](~/tutorials/razor-pages/razor-pages-start/snapshot-sample10/Pages/Movies/Index.cshtml.cs?name=snippet_search_1stSearch)]

The first line of the `OnGetAsync` method creates a [LINQ](/dotnet/csharp/programming-guide/concepts/linq/) query to select the movies:

[!code-csharp[](~/tutorials/razor-pages/razor-pages-start/snapshot-sample10/Pages/Movies/Index.cshtml.cs?name=snippet_search_linq)]

The query is only ***defined*** at this point. It isn't run against the database.

If the `SearchString` property isn't `null` or empty, the movies query is modified to filter on the search string:

[!code-csharp[](~/tutorials/razor-pages/razor-pages-start/snapshot-sample10/Pages/Movies/Index.cshtml.cs?name=snippet_search_SearchNull)]

The `s => s.Title.Contains()` code is a [Lambda Expression](/dotnet/csharp/programming-guide/statements-expressions-operators/lambda-expressions). Lambdas are used in method-based [LINQ](/dotnet/csharp/programming-guide/concepts/linq/) queries as arguments to standard query operator methods such as the [Where](/dotnet/csharp/programming-guide/concepts/linq/query-syntax-and-method-syntax-in-linq) method or `Contains`. LINQ queries aren't executed when you define them or when you modify them by calling a method, such as `Where`, `Contains`, or `OrderBy`. Rather, query execution is deferred. The evaluation of an expression is delayed until its realized value is iterated over or the `ToListAsync` method is called. For more information, see [Query Execution](/dotnet/csharp/linq/get-started/introduction-to-linq-queries#deferred).

> [!NOTE]
> The <xref:System.Data.Objects.DataClasses.EntityCollection%601.Contains%2A> method runs on the database, not in the C# code. The case sensitivity on the query depends on the database and the collation. On SQL Server, `Contains` maps to [SQL LIKE](/sql/t-sql/language-elements/like-transact-sql), which is case insensitive. SQLite with the default collation is a mixture of case sensitive and case ***IN***sensitive, depending on the query. For information on making case insensitive SQLite queries, see the following:
> 
> * [How to use case-insensitive query with Sqlite provider? (`dotnet/efcore` #11414)](https://github.com/dotnet/efcore/issues/11414)
> * [How to make a SQLite column case insensitive (`dotnet/AspNetCore.Docs` #22314)](https://github.com/dotnet/AspNetCore.Docs/issues/22314)
> * [Collations and Case Sensitivity](/ef/core/miscellaneous/collations-and-case-sensitivity)

Navigate to the Movies page and append a query string such as `?searchString=Ghost` to the URL. For example, `https://localhost:5001/Movies?searchString=Ghost`. The filtered movies are displayed.

![Index view](~/tutorials/razor-pages/search/_static/10/search-string-ghost.png)

If you add the following route template to the Index page, you can pass the search string as a URL segment. For example, `https://localhost:5001/Movies/Ghost`.

```cshtml
@page "{searchString?}"
```

The preceding route constraint allows searching the title as route data (a URL segment) instead of as a query string value.  The `?` in `"{searchString?}"` means this is an optional route parameter.

![Index view with the word ghost added to the Url and a returned movie list of two movies, Ghostbusters and Ghostbusters 2](~/tutorials/razor-pages/search/_static/10/ghost-title-route-data.png)

The ASP.NET Core runtime uses [model binding](xref:mvc/models/model-binding) to set the value of the `SearchString` property from the query string (`?searchString=Ghost`) or route data (`https://localhost:5001/Movies/Ghost`). Model binding isn't case sensitive.

However, users can't be expected to modify the URL to search for a movie. In this step, you add UI to filter movies. If you added the route constraint `"{searchString?}"`, remove it.

Open the `Pages/Movies/Index.cshtml` file, and add the markup highlighted in the following code:

[!code-cshtml[](~/tutorials/razor-pages/razor-pages-start/snapshot-sample10/Pages/Movies/Index_SearchAddedTitle.cshtml?highlight=14-19&range=1-22)]

The HTML `<form>` tag uses the following [Tag Helpers](xref:mvc/views/tag-helpers/intro):

* [Form Tag Helper](xref:mvc/views/working-with-forms#the-form-tag-helper). When you submit the form, it sends the filter string to the *Pages/Movies/Index* page through the query string.
* [Input Tag Helper](xref:mvc/views/working-with-forms#the-input-tag-helper)

Save your changes and test the filter.

![Index view with the word ghost typed into the Title filter textbox](~/tutorials/razor-pages/search/_static/10/filter-by-title.png)

## Search by genre

Update the `Movies/Index.cshtml.cs` page `OnGetAsync` method with the following code:

[!code-csharp[](~/tutorials/razor-pages/razor-pages-start/snapshot-sample10/Pages/Movies/Index_SearchAddedGenre.cshtml.cs?range=30-55)]

The following code is a LINQ query that retrieves all the genres from the database.

[!code-csharp[](~/tutorials/razor-pages/razor-pages-start/snapshot-sample10/Pages/Movies/Index_SearchAddedGenre.cshtml.cs?name=snippet_search_linqQuery)]

The `SelectList` of genres is created by projecting the distinct genres:

[!code-csharp[](~/tutorials/razor-pages/razor-pages-start/snapshot-sample10/Pages/Movies/Index_SearchAddedGenre.cshtml.cs?name=snippet_search_selectList)]

### Add search by genre to the Razor Page

Update the `Index.cshtml` [`<form>` element](https://developer.mozilla.org/docs/Web/HTML/Element/form) as highlighted in the following markup:

[!code-cshtml[](~/tutorials/razor-pages/razor-pages-start/snapshot-sample10/Pages/Movies/Index_SearchAddedGenre.cshtml?highlight=16-18&range=1-22)]

Test the app by searching by genre, by movie title, and by both:

![Index view complete with Genre selector and Title textbox search filters](~/tutorials/razor-pages/search/_static/10/filter-by-genre-title.png)

## Next steps


> [!div class="step-by-step"]
> [Previous: Update the pages](xref:tutorials/razor-pages/da1)
> [Next: Add a new field](xref:tutorials/razor-pages/new-field)

:::moniker-end

[!INCLUDE[](~/tutorials/razor-pages/search/includes/search9.md)]

[!INCLUDE[](~/tutorials/razor-pages/search/includes/search8.md)]

[!INCLUDE[](~/tutorials/razor-pages/search/includes/search7.md)]

[!INCLUDE[](~/tutorials/razor-pages/search/includes/search6.md)]

[!INCLUDE[](~/tutorials/razor-pages/search/includes/search3-5.md)]
