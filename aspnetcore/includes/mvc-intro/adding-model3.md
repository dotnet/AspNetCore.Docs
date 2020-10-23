
## Test the app

* Run the app and tap the **Mvc Movie** link.
* Tap the **Create New** link and create a movie.

  ![Create view with fields for genre, price, release date, and title](~/tutorials/first-mvc-app/adding-model/_static/movies.png)

* You may not be able to enter decimal points or commas in the `Price` field. To support [jQuery validation](https://jqueryvalidation.org/) for non-English locales that use a comma (",") for a decimal point, and non US-English date formats, you must take steps to globalize your app. See [https://github.com/dotnet/AspNetCore.Docs/issues/4076](https://github.com/dotnet/AspNetCore.Docs/issues/4076) and [Additional resources](#additional-resources) for more information. For now, just enter whole numbers like 10.

<a name="displayformatdatelocal"></a>

* In some locales you need to specify the date format. See the highlighted code below.

[!code-csharp[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie/Models/MovieDateFormat.cs?name=snippet_1&highlight=2,10)]

We'll talk about `DataAnnotations` later in the tutorial.

Tapping **Create** causes the form to be posted to the server, where the movie information is saved in a database. The app redirects to the */Movies* URL, where the newly created movie information is displayed.

![Movies view showing newly created movie listing](~/tutorials/first-mvc-app/adding-model/_static/h.png)

Create a couple more movie entries. Try the **Edit**, **Details**, and **Delete** links, which are all functional.
