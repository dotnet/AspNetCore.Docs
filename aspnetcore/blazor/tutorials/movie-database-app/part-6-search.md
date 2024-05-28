---
title: Build a Blazor movie database app (Part 6 - Add search)
author: guardrex
description: This part of the Blazor movie database app tutorial explains ...
monikerRange: '>= aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 05/28/2024
uid: blazor/tutorials/movie-database/search
---
# Build a Blazor movie database app (Part 6 - Add search)

<!-- UPDATE 9.0 Activate after release

[!INCLUDE[](~/includes/not-latest-version.md)]

-->

This article is the sixth part of the Blazor movie database app tutorial that teaches you the basics of building an ASP.NET Core Blazor Web App with features to manage a movie database.

This part of the series covers adding a search feature to the movies `Index` component to filter movies by title.

The [`QuickGrid`](xref:Microsoft.AspNetCore.Components.QuickGrid) component is used by the movie `Index` component (`Components/MoviePages/Index.razor`) to display movies from the database:

```razor
<QuickGrid Class="table" Items="DB.Movie">
    ...
</QuickGrid>
```

The <xref:Microsoft.AspNetCore.Components.QuickGrid.QuickGrid%601.Items%2A> parameter receives a nullable `IQueryable<TGridItem>`, where `TGridItem` is the type of data represented by each row in the grid. In this case, the `TGridItem` is a `DbSet<Movie>` obtained from the injected `BlazorWebAppMoviesContext` (`DB`).

To make the `QuickGrid` component filter on the movie title, the `Index` component should:

* Set a filter string as a *component parameter* from the query string.
* If the parameter has a value, filter the movies returned from the database.
* Provide an input for the user to provide the filter string and a button to trigger a reload using the filter.

Start by adding the following `@code` block of C# code to the `Index` component:

```razor
@code {
    private IQueryable<Movie>? movies;

    [SupplyParameterFromQuery]
    public string? TitleFilter { get; set; }

    protected override void OnParametersSet()
    {
        if (!string.IsNullOrEmpty(TitleFilter))
        {
            movies = DB.Movie.Where(s => !string.IsNullOrEmpty(s.Title) ? s.Title.Contains(TitleFilter) : false);
        }
        else
        {
            movies = DB.Movie;
        }
    }
}
```

The `movies` collection is an `IQueryable<Movie>`, which is the type for assignment to the `QuickGrid`'s <xref:Microsoft.AspNetCore.Components.QuickGrid.QuickGrid%601.Items%2A> parameter.

`TitleFilter` is the filter string. The property is provided the [`[SupplyParameterFromQuery]` attribute](xref:Microsoft.AspNetCore.Components.SupplyParameterFromQueryAttribute), which lets Blazor know that the value of `TitleFilter` should be assigned from the query string when the query string contains a field of the same name (for example, `?titleFilter=road+warrior`). Note that query string field names aren't case sensitive.

The `OnParametersSet` Blazor component lifecycle method executes after parameters are set. The method checks if `TitleFilter` has a value and either:

* Filters the database for movies with a title that contains the filter string.
* Returns all of the movies if the filter string (`TitleFilter`) is `null` (`titleFilter` isn't present in the query string) or an empty string (no value is supplied for the field in the query string, `?titleFilter=`).

Change the `QuickGrid` component's <xref:Microsoft.AspNetCore.Components.QuickGrid.QuickGrid%601.Items%2A> parameter to use the `movies` collection:

```diff
- <QuickGrid Class="table" Items="DB.movies">
+ <QuickGrid Class="table" Items="@movies">
```

> [!NOTE]
> Scaffolded code doesn't prefix component parameter values with `@` as a convention, but documentation examples always do. In the preceding example, assigning only `movie` (`Items="movies"`) is valid Razor syntax, but documentation examples always show such assignments with the `@` symbol (`Items="@movies"`) to indicate that C# is provided. When the `@` is explicitly added, the markup makes it clear that the value isn't a string literal being passed to `string`-typed parameter.

The `s => s.Title.Contains()` code is a *lambda expression*. Lambdas are used in method-based LINQ queries as arguments to standard query operator methods such as the `Where` or `Contains` methods. LINQ queries aren't executed when they're defined or when they're modified by calling a method, such as `Where`, `Contains`, or `OrderBy`. Rather, query execution is deferred. The evaluation of an expression is delayed until its realized value is iterated.

The <xref:System.Data.Objects.DataClasses.EntityCollection%601.Contains%2A> method is run on the database, not in the C# code. The case sensitivity of the query depends on the database and the collation. On SQL Server, `Contains` maps to [SQL `LIKE`](/sql/t-sql/language-elements/like-transact-sql), which is case insensitive. SQLite with default collation provides a mixture of case sensitive and case ***insensitive*** filtering, depending on the query. For information on making case insensitive SQLite queries, see the [Additional resources](#additonal-resources) section of this article.

Run the app and navigate to the movies `Index` page at `/movies`. The movies in the database load:

![Mad Max movies before filtering in the movies Index page](~/blazor/tutorials/movie-database-app/part-6-search/_static/before-filtering.png)

Append a query string to the URL in the address bar: `?titleSearch=road+warrior`. For example, the full URL appears as `https://localhost:5001/movies?titleSearch=road+warrior`, assuming the port number is `5001`. The filtered movie is displayed:

![The Road Warrior Mad Max movie filtered](~/blazor/tutorials/movie-database-app/part-6-search/_static/query-string-filter-result.png)

Next, give users a way to provide the `titleSearch` filter string via the component's UI. Add the following HTML under the H1 heading (`<h1>Index</h1>`). The following HTML reloads the page with the contents of the textbox as a query string value:

```html
<p>
    <form action="/movies">
        <input type="text" name="titleFilter" />
        <input type="submit" value="Search" />
    </form>
</p>
```

Run the app again and type `road warrior` into the textbox:

![Mad Max movies before filtering in the movies Index page. The search field has the value 'road warrior'.](~/blazor/tutorials/movie-database-app/part-6-search/_static/before-filtering.png)

Select the **Search** button to filter the movies:

![The Road Warrior Mad Max movie filtered](~/blazor/tutorials/movie-database-app/part-6-search/_static/query-string-filter-result.png)

## Troubleshoot with the completed sample

[!INCLUDE[](~/blazor/tutorials/movie-database-app/includes/troubleshoot.md)]

## Additonal resources

* [LINQ documentation](/dotnet/csharp/programming-guide/concepts/linq/)
* [Write C# LINQ queries to query data (C# documentation)](/dotnet/csharp/programming-guide/concepts/linq/query-syntax-and-method-syntax-in-linq)
* [Lambda Expression (C# documentation](/dotnet/csharp/programming-guide/statements-expressions-operators/lambda-expressions)
* Case insensitive SQLite queries
  * [How to use case-insensitive query with Sqlite provider? (`dotnet/efcore` #11414)](https://github.com/dotnet/efcore/issues/11414)
  * [How to make a SQLite column case insensitive (`dotnet/AspNetCore.Docs` #22314)](https://github.com/dotnet/AspNetCore.Docs/issues/22314)
  * [Collations and Case Sensitivity](/ef/core/miscellaneous/collations-and-case-sensitivity)

## Next steps

> [!div class="step-by-step"]
> [Previous: Add validation](xref:blazor/tutorials/movie-database/validation)
> [Next: Add a new field](xref:blazor/tutorials/movie-database/new-field)
