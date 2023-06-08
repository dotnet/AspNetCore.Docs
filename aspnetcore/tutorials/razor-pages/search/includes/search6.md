:::moniker range="= aspnetcore-6.0"

In the following sections, searching movies by *genre* or *name* is added.

Add the following highlighted code to `Pages/Movies/Index.cshtml.cs`:

[!code-csharp[](~/tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie60/Pages/Movies/Index.cshtml.cs?name=snippet_newProps&highlight=3,22-27)]

In the previous code:

* `SearchString`: Contains the text users enter in the search text box. `SearchString` has the [`[BindProperty]`](xref:Microsoft.AspNetCore.Mvc.BindPropertyAttribute) attribute. `[BindProperty]` binds form values and query strings with the same name as the property. `[BindProperty(SupportsGet = true)]` is required for binding on HTTP GET requests.
* `Genres`: Contains the list of genres. `Genres` allows the user to select a genre from the list. `SelectList` requires `using Microsoft.AspNetCore.Mvc.Rendering;`
* `MovieGenre`: Contains the specific genre the user selects. For example, "Western".
* `Genres` and `MovieGenre` are used later in this tutorial.

[!INCLUDE[](~/includes/bind-get.md)]

Update the Index page's `OnGetAsync` method with the following code:

[!code-csharp[](~/tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie30/Pages/Movies/Index.cshtml.cs?name=snippet_1stSearch)]

The first line of the `OnGetAsync` method creates a [LINQ](/dotnet/csharp/programming-guide/concepts/linq/) query to select the movies:

```csharp
// using System.Linq;
var movies = from m in _context.Movie
             select m;
```

The query is only ***defined*** at this point, it has ***not*** been run against the database.

If the `SearchString` property is not null or empty, the movies query is modified to filter on the search string:

[!code-csharp[](~/tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie60/Pages/Movies/Index.cshtml.cs?name=snippet_SearchNull)]

The `s => s.Title.Contains()` code is a [Lambda Expression](/dotnet/csharp/programming-guide/statements-expressions-operators/lambda-expressions). Lambdas are used in method-based [LINQ](/dotnet/csharp/programming-guide/concepts/linq/) queries as arguments to standard query operator methods such as the [Where](/dotnet/csharp/programming-guide/concepts/linq/query-syntax-and-method-syntax-in-linq) method or `Contains`. LINQ queries are not executed when they're defined or when they're modified by calling a method, such as `Where`, `Contains`, or `OrderBy`. Rather, query execution is deferred. The evaluation of an expression is delayed until its realized value is iterated over or the `ToListAsync` method is called. See [Query Execution](/dotnet/framework/data/adonet/ef/language-reference/query-execution) for more information.

> [!NOTE]
> The <xref:System.Data.Objects.DataClasses.EntityCollection%601.Contains%2A> method is run on the database, not in the C# code. The case sensitivity on the query depends on the database and the collation. On SQL Server, `Contains` maps to [SQL LIKE](/sql/t-sql/language-elements/like-transact-sql), which is case insensitive. SQLite with the default collation is a mixture of case sensitive and case ***IN***sensitive, depending on the query. For information on making case insensitive SQLite queries, see the following:

* [This GitHub issue](https://github.com/dotnet/efcore/issues/11414)
* [This GitHub issue](https://github.com/dotnet/AspNetCore.Docs/issues/22314)
* [Collations and Case Sensitivity](/ef/core/miscellaneous/collations-and-case-sensitivity)

Navigate to the Movies page and append a query string such as `?searchString=Ghost` to the URL. For example, `https://localhost:5001/Movies?searchString=Ghost`. The filtered movies are displayed.

![Index view](~/tutorials/razor-pages/search/_static/ghost.png)

If the following route template is added to the Index page, the search string can be passed as a URL segment. For example, `https://localhost:5001/Movies/Ghost`.

```cshtml
@page "{searchString?}"
```

The preceding route constraint allows searching the title as route data (a URL segment) instead of as a query string value.  The `?` in `"{searchString?}"` means this is an optional route parameter.

![Index view with the word ghost added to the Url and a returned movie list of two movies, Ghostbusters and Ghostbusters 2](~/tutorials/razor-pages/search/_static/g2.png)

The ASP.NET Core runtime uses [model binding](xref:mvc/models/model-binding) to set the value of the `SearchString` property from the query string (`?searchString=Ghost`) or route data (`https://localhost:5001/Movies/Ghost`). Model binding is ***not*** case sensitive.

However, users cannot be expected to modify the URL to search for a movie. In this step, UI is added to filter movies. If you added the route constraint `"{searchString?}"`, remove it.

Open the `Pages/Movies/Index.cshtml` file, and add the markup highlighted in the following code:

[!code-cshtml[](~/tutorials/razor-pages/razor-pages-start/snapshot_sample6/Pages/Movies/Index2.cshtml?highlight=14-19&range=1-22)]

The HTML `<form>` tag uses the following [Tag Helpers](xref:mvc/views/tag-helpers/intro):

* [Form Tag Helper](xref:mvc/views/working-with-forms#the-form-tag-helper). When the form is submitted, the filter string is sent to the *Pages/Movies/Index* page via query string.
* [Input Tag Helper](xref:mvc/views/working-with-forms#the-input-tag-helper)

Save the changes and test the filter.

![Index view with the word ghost typed into the Title filter textbox](~/tutorials/razor-pages/search/_static/filter2.png)

## Search by genre

Update the Index page's `OnGetAsync` method with the following code:

   [!code-csharp[](~/tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie60/Pages/Movies/Index.cshtml.cs?name=snippet_SearchGenre)]

The following code is a LINQ query that retrieves all the genres from the database.

```csharp
// Use LINQ to get list of genres.
IQueryable<string> genreQuery = from m in _context.Movie
                                orderby m.Genre
                                select m.Genre;
```

The `SelectList` of genres is created by projecting the distinct genres.

```csharp
Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
```

### Add search by genre to the Razor Page

Update the `Index.cshtml` [`<form>` element](https://developer.mozilla.org/docs/Web/HTML/Element/form) as highlighted in the following markup:

[!code-cshtml[](~/tutorials/razor-pages/razor-pages-start/snapshot_sample6/Pages/Movies/IndexFormGenreNoRating.cshtml?highlight=16-18&range=1-22)]

Test the app by searching by genre, by movie title, and by both.

## Next steps

> [!div class="step-by-step"]
> [Previous: Update the pages](xref:tutorials/razor-pages/da1)
> [Next: Add a new field](xref:tutorials/razor-pages/new-field)

:::moniker-end
