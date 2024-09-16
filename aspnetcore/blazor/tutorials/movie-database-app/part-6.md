---
title: Build a Blazor movie database app (Part 6 - Add search)
author: guardrex
description: This part of the Blazor movie database app tutorial explains how to add a search feature to filter movies by title.
monikerRange: '>= aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 08/26/2024
uid: blazor/tutorials/movie-database-app/part-6
zone_pivot_groups: tooling
---
# Build a Blazor movie database app (Part 6 - Add search)

<!-- UPDATE 9.0 Activate after release

[!INCLUDE[](~/includes/not-latest-version.md)]

-->

This article is the sixth part of the Blazor movie database app tutorial that teaches you the basics of building an ASP.NET Core Blazor Web App with features to manage a movie database.

This part of the tutorial series covers adding a search feature to the movies `Index` component to filter movies by title.

## Implement a filter feature for the `QuickGrid` component

The [`QuickGrid`](xref:Microsoft.AspNetCore.Components.QuickGrid) component is used by the movie `Index` component (`Components/MoviePages/Index.razor`) to display movies from the database:

```razor
<QuickGrid Class="table" Items="context.Movie">
    ...
</QuickGrid>
```

The <xref:Microsoft.AspNetCore.Components.QuickGrid.QuickGrid%601.Items%2A> parameter receives an `IQueryable<TGridItem>`, where `TGridItem` is the type of data represented by each row in the grid (`Movie`). <xref:Microsoft.AspNetCore.Components.QuickGrid.QuickGrid%601.Items%2A> is assigned a collection of movie entities (`DbSet<Movie>`) obtained from the created database context (<xref:Microsoft.EntityFrameworkCore.IDbContextFactory%601.CreateDbContext%2A>) of the injected database context factory (`DbFactory`).

To make the `QuickGrid` component filter on the movie title, the `Index` component should:

* Set a filter string as a *component parameter* from the query string.
* If the parameter has a value, filter the movies returned from the database.
* Provide an input for the user to provide the filter string and a button to trigger a reload using the filter.

Start by adding the following code to the `@code` block of the `Index` component (`MoviePages/Index.razor`):

```csharp
[SupplyParameterFromQuery]
private string? TitleFilter { get; set; }

private IQueryable<Movie> FilteredMovies => 
    context.Movie.Where(m => m.Title!.Contains(TitleFilter ?? string.Empty));
```

`TitleFilter` is the filter string. The property is provided the [`[SupplyParameterFromQuery]` attribute](xref:Microsoft.AspNetCore.Components.SupplyParameterFromQueryAttribute), which lets Blazor know that the value of `TitleFilter` should be assigned from the query string when the query string contains a field of the same name (for example, `?titleFilter=road+warrior` yields a `TitleFilter` value of `road warrior`). Note that query string field names, such as `titleFilter`, aren't case sensitive.

The `FilteredMovies` property is an `IQueryable<Movie>`, which is the type for assignment to the `QuickGrid`'s <xref:Microsoft.AspNetCore.Components.QuickGrid.QuickGrid%601.Items%2A> parameter. The property filters the list of movies based on the supplied `TitleFilter`. If a `TitleFilter` isn't assigned a value from the query string (`TitleFilter` is `null`), an empty string (`string.Empty`) is used for the <xref:System.String.Contains%2A> clause. Therefore, no movies are filtered for display.

Change the `QuickGrid` component's <xref:Microsoft.AspNetCore.Components.QuickGrid.QuickGrid%601.Items%2A> parameter to use the `movies` collection:

```diff
- <QuickGrid Class="table" Items="context.Movie">
+ <QuickGrid Class="table" Items="FilteredMovies">
```

The `movie => movie.Title!.Contains(...)` code is a *lambda expression*. Lambdas are used in method-based LINQ queries as arguments to standard query operator methods such as the <xref:System.Linq.Queryable.Where%2A> or <xref:System.String.Contains%2A> methods. LINQ queries aren't executed when they're defined or when they're modified by calling a method, such as <xref:System.Linq.Queryable.Where%2A>, <xref:System.String.Contains%2A>, or <xref:System.Linq.Queryable.OrderBy%2A>. Rather, query execution is deferred. The evaluation of an expression is delayed until its realized value is iterated.

The <xref:System.Data.Objects.DataClasses.EntityCollection%601.Contains%2A> method is run on the database, not in the C# code. The case sensitivity of the query depends on the database and the collation. For SQL Server, <xref:System.String.Contains%2A> maps to [SQL `LIKE`](/sql/t-sql/language-elements/like-transact-sql), which is case insensitive. SQLite with default collation provides a mixture of case sensitive and case insensitive filtering, depending on the query. For information on making case insensitive SQLite queries, see the [Additional resources](#additional-resources) section of this article.

Run the app and navigate to the movies `Index` page at `/movies`. The movies in the database load:

![Mad Max movies before filtering in the movies Index page](~/blazor/tutorials/movie-database-app/part-6/_static/before-filtering.png)

Append a query string to the URL in the address bar: `?titleFilter=road+warrior`. For example, the full URL appears as `https://localhost:7073/movies?titleFilter=road+warrior`, assuming the port number is `7073`. The filtered movie is displayed:

!['The Road Warrior' Mad Max movie filtered using a query string in the browser's address bar](~/blazor/tutorials/movie-database-app/part-6/_static/query-string-filter-result.png)

Next, give users a way to provide the `titleFilter` filter string via the component's UI. Add the following HTML under the H1 heading (`<h1>Index</h1>`). The following HTML reloads the page with the contents of the textbox as a query string value:

```html
<p>
    <form action="/movies" data-enhance>
        <input type="search" name="titleFilter" />
        <input type="submit" value="Search" />
    </form>
</p>
```

The `data-enhance` attribute applies *enhanced navigation* to the component, where Blazor intercepts the GET request and performs a fetch request instead. Blazor then patches the response content into the page, which avoids a full-page reload and preserves more of the page state. The page loads faster, usually without losing the user's scroll position.

:::zone pivot="vs"

Save the file that you're working on. Apply the change by either restarting the app or using [Hot Reload](/visualstudio/debugger/hot-reload) to apply the change to the running app.

:::zone-end

:::zone pivot="vsc"

Close the browser window and in VS Code select **Run** > **Restart Debugging** or press <kbd>Ctrl</kbd>+<kbd>Shift</kbd>+<kbd>F5</kbd> on the keyboard. VS Code recompiles and runs the app with your saved changes and spawns a new browser window for the app.

:::zone-end

:::zone pivot="cli"

Because the app is currently running with `dotnet watch`, saved changes are detected automatically and reflected in the existing browser window.

:::zone-end

Type "`road warrior`" into the search box and select the **:::no-loc text="Search":::** button to filter the movies:

![Mad Max movies before filtering in the movies Index page. The search field has the value 'road warrior'.](~/blazor/tutorials/movie-database-app/part-6/_static/form-filter.png)

The result after searching on `road warrior`:

!['The Road Warrior' Mad Max movie filtered using a GET request via an HTML form action](~/blazor/tutorials/movie-database-app/part-6/_static/form-filter-result.png)

Notice that the search box loses the search value ("`road warrior`") when the movies are filtered. If you want to preserve the searched value, add the `data-permanent` attribute:

```diff
- <form action="/movies" data-enhance>
+ <form action="/movies" data-enhance data-permanent>
```

## Stop the app

:::zone pivot="vs"

Stop the app by closing the browser's window.

:::zone-end

:::zone pivot="vsc"

Stop the app by closing the browser's window and pressing <kbd>Shift</kbd>+<kbd>F5</kbd> on the keyboard in VS Code.

:::zone-end

:::zone pivot="cli"

Stop the app by closing the browser's window and pressing <kbd>Ctrl</kbd>+<kbd>C</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>C</kbd> (macOS) in the command shell.

:::zone-end

## Troubleshoot with the completed sample

[!INCLUDE[](~/blazor/tutorials/movie-database-app/includes/troubleshoot.md)]

## Additional resources

* [LINQ documentation](/dotnet/csharp/programming-guide/concepts/linq/)
* [Write C# LINQ queries to query data (C# documentation)](/dotnet/csharp/programming-guide/concepts/linq/query-syntax-and-method-syntax-in-linq)
* [Lambda Expression (C# documentation](/dotnet/csharp/programming-guide/statements-expressions-operators/lambda-expressions)
* Case insensitive SQLite queries
  * [How to use case-insensitive query with Sqlite provider? (`dotnet/efcore` #11414)](https://github.com/dotnet/efcore/issues/11414)
  * [How to make a SQLite column case insensitive (`dotnet/AspNetCore.Docs` #22314)](https://github.com/dotnet/AspNetCore.Docs/issues/22314)
  * [Collations and Case Sensitivity](/ef/core/miscellaneous/collations-and-case-sensitivity)

## Legal

[*Mad Max*, *The Road Warrior*, *Mad Max: Beyond Thunderdome*, *Mad Max: Fury Road*, and *Furiosa: A Mad Max Saga*](https://warnerbros.fandom.com/wiki/Mad_Max_(franchise)) are trademarks and copyrights of [Warner Bros. Entertainment](https://www.warnerbros.com/).

## Next steps

> [!div class="step-by-step"]
> [Previous: Add validation](xref:blazor/tutorials/movie-database-app/part-5)
> [Next: Add a new field](xref:blazor/tutorials/movie-database-app/part-7)
