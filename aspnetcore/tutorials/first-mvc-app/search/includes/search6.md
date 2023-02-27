:::moniker range="= aspnetcore-6.0"

In this section, you add search capability to the `Index` action method that lets you search movies by *genre* or *name*.

Update the `Index` method found inside `Controllers/MoviesController.cs` with the following code:

[!code-csharp[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie60/Controllers/MoviesController.cs?name=IndexSearch1)]

The first line of the `Index` action method creates a [LINQ](/dotnet/standard/using-linq) query to select the movies:

```csharp
var movies = from m in _context.Movie
             select m;
```

The query is *only defined* at this point, it has **not** been run against the database.

If the `searchString` parameter contains a string, the movies query is modified to filter on the value of the search string:

[!code-csharp[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie60/Controllers/MoviesController.cs?name=IndexSearchCheckForNull)]

The `s => s.Title!.Contains(searchString)` code above is a [Lambda Expression](/dotnet/csharp/programming-guide/statements-expressions-operators/lambda-expressions). Lambdas are used in method-based [LINQ](/dotnet/standard/using-linq) queries as arguments to standard query operator methods such as the <xref:System.Linq.Enumerable.Where%2A> method or `Contains` (used in the code above). LINQ queries are not executed when they're defined or when they're modified by calling a method such as `Where`, `Contains`, or `OrderBy`. Rather, query execution is deferred.  That means that the evaluation of an expression is delayed until its realized value is actually iterated over or the `ToListAsync` method is called. For more information about deferred query execution, see [Query Execution](/dotnet/framework/data/adonet/ef/language-reference/query-execution).

Note: The <xref:System.Data.Objects.DataClasses.EntityCollection%601.Contains%2A> method is run on the database, not in the c# code shown above. The case sensitivity on the query depends on the database and the collation. On SQL Server, `Contains` maps to [SQL LIKE](/sql/t-sql/language-elements/like-transact-sql), which is case insensitive. In SQLite, with the default collation, it's case sensitive.

Navigate to `/Movies/Index`. Append a query string such as `?searchString=Ghost` to the URL. The filtered movies are displayed.

![Index view](~/tutorials/first-mvc-app/search/_static/ghost.png)

If you change the signature of the `Index` method to have a parameter named `id`, the `id` parameter will match the optional `{id}` placeholder for the default routes set in `Program.cs`.

[!code-csharp[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie60/Program.cs?highlight=3&name=MapControllerRoute)]

Change the parameter to `id` and change all occurrences of `searchString` to `id`.

The previous `Index` method:

[!code-csharp[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie60/Controllers/MoviesController.cs?name=IndexSearch1)]

The updated `Index` method with `id` parameter:

[!code-csharp[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie60/Controllers/MoviesController.cs?highlight=1,6,8&name=IndexSearchID)]

You can now pass the search title as route data (a URL segment) instead of as a query string value.

![Index view with the word ghost added to the Url and a returned movie list of two movies, Ghostbusters and Ghostbusters 2](~/tutorials/first-mvc-app/search/_static/g2.png)

However, you can't expect users to modify the URL every time they want to search for a movie. So now you'll add UI elements to help them filter movies. If you changed the signature of the `Index` method to test how to pass the route-bound `ID` parameter, change it back so that it takes a parameter named `searchString`:

[!code-csharp[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie60/Controllers/MoviesController.cs?highlight=1,6,8&name=IndexSearch1)]

Open the `Views/Movies/Index.cshtml` file, and add the `<form>` markup highlighted below:

[!code-cshtml[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie/Views/Movies/IndexForm1.cshtml?highlight=13-18&range=1-19)]

The HTML `<form>` tag uses the [Form Tag Helper](xref:mvc/views/working-with-forms), so when you submit the form, the filter string is posted to the `Index` action of the movies controller. Save your changes and then test the filter.

![Index view with the word ghost typed into the Title filter textbox](~/tutorials/first-mvc-app/search/_static/filter.png)

There's no `[HttpPost]` overload of the `Index` method as you might expect. You don't need it, because the method isn't changing the state of the app, just filtering data.

You could add the following `[HttpPost] Index` method.

[!code-csharp[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie60/Controllers/MoviesController.cs?highlight=1&name=IndexPost)]

The `notUsed` parameter is used to create an overload for the `Index` method. We'll talk about that later in the tutorial.

If you add this method, the action invoker would match the `[HttpPost] Index` method, and the `[HttpPost] Index` method would run as shown in the image below.

![Browser window with application response of From HttpPost Index: filter on ghost](~/tutorials/first-mvc-app/search/_static/fo.png)

However, even if you add this `[HttpPost]` version of the `Index` method, there's a limitation in how this has all been implemented. Imagine that you want to bookmark a particular search or you want to send a link to friends that they can click in order to see the same filtered list of movies. Notice that the URL for the HTTP POST request is the same as the URL for the GET request (localhost:{PORT}/Movies/Index) -- there's no search information in the URL. The search string information is sent to the server as a [form field value](https://developer.mozilla.org/docs/Learn/HTML/Forms/Sending_and_retrieving_form_data). You can verify that with the browser Developer tools or the excellent [Fiddler tool](https://www.telerik.com/fiddler). The image below shows the Chrome browser Developer tools:

![Network tab of Microsoft Edge Developer Tools showing a request body with a searchString value of ghost](~/tutorials/first-mvc-app/search/_static/f12_rb.png)

You can see the search parameter and [XSRF](xref:security/anti-request-forgery) token in the request body. Note, as mentioned in the previous tutorial, the [Form Tag Helper](xref:mvc/views/working-with-forms) generates an [XSRF](xref:security/anti-request-forgery) anti-forgery token. We're not modifying data, so we don't need to validate the token in the controller method.

Because the search parameter is in the request body and not the URL, you can't capture that search information to bookmark or share with others. Fix this by specifying the request should be `HTTP GET` found in the `Views/Movies/Index.cshtml` file.

[!code-cshtml[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie60/Views/Movies/IndexGet.cshtml?highlight=13&range=1-19)]

Now when you submit a search, the URL contains the search query string. Searching will also go to the `HttpGet Index` action method, even if you have a `HttpPost Index` method.

![Browser window showing the searchString=ghost in the Url and the movies returned, Ghostbusters and Ghostbusters 2, contain the word ghost](~/tutorials/first-mvc-app/search/_static/search_get.png)

The following markup shows the change to the `form` tag:

```cshtml
<form asp-controller="Movies" asp-action="Index" method="get">
```

## Add Search by genre

Add the following `MovieGenreViewModel` class to the *Models* folder:

[!code-csharp[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie60/Models/MovieGenreViewModel.cs)]

The movie-genre view model will contain:

* A list of movies.
* A `SelectList` containing the list of genres. This allows the user to select a genre from the list.
* `MovieGenre`, which contains the selected genre.
* `SearchString`, which contains the text users enter in the search text box.

Replace the `Index` method in `MoviesController.cs` with the following code:

[!code-csharp[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie60/Controllers/MoviesController.cs?name=IndexGenre)]

The following code is a `LINQ` query that retrieves all the genres from the database.

[!code-csharp[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie60/Controllers/MoviesController.cs?name=IndexGenreLINQ)]

The `SelectList` of genres is created by projecting the distinct genres (we don't want our select list to have duplicate genres).

When the user searches for the item, the search value is retained in the search box.

## Add search by genre to the Index view

Update `Index.cshtml` found in *Views/Movies/* as follows:

[!code-cshtml[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie60/Views/Movies/IndexFormGenreNoRating.cshtml?highlight=1,15,16,17,19,28,31,34,37,43)]

Examine the lambda expression used in the following HTML Helper:

`@Html.DisplayNameFor(model => model.Movies[0].Title)`

In the preceding code, the `DisplayNameFor` HTML Helper inspects the `Title` property referenced in the lambda expression to determine the display name. Since the lambda expression is inspected rather than evaluated, you don't receive an access violation when `model`, `model.Movies`, or `model.Movies[0]` are `null` or empty. When the lambda expression is evaluated (for example, `@Html.DisplayFor(modelItem => item.Title)`), the model's property values are evaluated.

Test the app by searching by genre, by movie title, and by both:

![Browser window showing results of https://localhost:5001/Movies?MovieGenre=Comedy&SearchString=2](~/tutorials/first-mvc-app/search/_static/s2.png)

> [!div class="step-by-step"]
> [Previous](~/tutorials/first-mvc-app/controller-methods-views.md)
> [Next](~/tutorials/first-mvc-app/new-field.md)

:::moniker-end
