:::moniker range="= aspnetcore-5.0"

In this section, you modify the `HelloWorldController` class to use [Razor](xref:mvc/views/razor) view files. This cleanly encapsulates the process of generating HTML responses to a client.

View templates are created using Razor. Razor-based view templates:

* Have a `.cshtml` file extension.
* Provide an elegant way to create HTML output with C#.

Currently the `Index` method returns a string with a message in the controller class. In the `HelloWorldController` class, replace the `Index` method with the following code:

[!code-csharp[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie/Controllers/HelloWorldController.cs?name=snippet_4)]

The preceding code:

* Calls the controller's <xref:Microsoft.AspNetCore.Mvc.Controller.View*> method.
* Uses a view template to generate an HTML response.

Controller methods:

* Are referred to as *action methods*.  For example, the `Index` action method in the preceding code.
* Generally return an <xref:Microsoft.AspNetCore.Mvc.IActionResult> or a class derived from <xref:Microsoft.AspNetCore.Mvc.ActionResult>, not a type like `string`.

## Add a view

# [Visual Studio](#tab/visual-studio)

Right-click on the *Views* folder, and then **Add > New Folder** and name the folder *HelloWorld*.

Right-click on the *Views/HelloWorld* folder, and then **Add > New Item**.

In the **Add New Item - MvcMovie** dialog:

* In the search box in the upper-right, enter *view*
* Select **Razor View - Empty**
* Keep the **Name** box value, `Index.cshtml`.
* Select **Add**

![Add New Item dialog](~/tutorials/first-mvc-app/adding-view/_static/add_view50.png)

# [Visual Studio Code](#tab/visual-studio-code)

Add an `Index` view for the `HelloWorldController`:

* Add a new folder named *Views/HelloWorld*.
* Add a new file to the *Views/HelloWorld* folder name `Index.cshtml`.

# [Visual Studio for Mac](#tab/visual-studio-mac)

Control-click on the *Views* folder, and then **Add > New Folder** and name the folder *HelloWorld*.

Control-click on the *Views/HelloWorld* folder, and then **Add > New File**.

In the **New File** dialog:

* Select **ASP.NET Core** in the left pane.
* Select **Razor View - Empty** in the center pane.
* Type *Index* in the **Name** box.
* Select **New**.

  ![Add New Item dialog](~/tutorials/first-mvc-app/adding-view/_static/add_view_macVSM8.9.png)

---

Replace the contents of the `Views/HelloWorld/Index.cshtml` Razor view file with the following:

[!code-cshtml[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie22/Views/HelloWorld/Index1.cshtml?highlight=7)]

Navigate to `https://localhost:{PORT}/HelloWorld`:

* The `Index` method in the `HelloWorldController` ran the statement `return View();`, which specified that the method should use a view template file to render a response to the browser.
* A view template file name wasn't specified, so MVC defaulted to using the default view file. When the view file name isn't specified, the default view is returned. The default view has the same name as the action method, `Index` in this example. The view template `/Views/HelloWorld/Index.cshtml` is used.
* The following image shows the string "Hello from our View Template!" hard-coded in the view:

  ![Browser window](~/tutorials/first-mvc-app/adding-view/_static/hell_template.png)

## Change views and layout pages

Select the menu links **MvcMovie**, **Home**, and **Privacy**. Each page shows the same menu layout. The menu layout is implemented in the `Views/Shared/_Layout.cshtml` file.

Open the `Views/Shared/_Layout.cshtml` file.

[Layout](xref:mvc/views/layout) templates allows:

* Specifying the HTML container layout of a site in one place.
* Applying the HTML container layout across multiple pages in the site.

Find the `@RenderBody()` line. `RenderBody` is a placeholder where all the view-specific pages you create show up, *wrapped* in the layout page. For example, if you select the **Privacy** link, the *`Views/Home/Privacy.cshtml`* view is rendered inside the `RenderBody` method.

## Change the title, footer, and menu link in the layout file

Replace the content of the `Views/Shared/_Layout.cshtml` file with the following markup. The changes are highlighted:

[!code-cshtml[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie5/Views/Shared/_Layout.cshtml?highlight=6,14,40)]

The preceding markup made the following changes:

* Three occurrences of `MvcMovie` to `Movie App`.
* The anchor element `<a class="navbar-brand" asp-area="" asp-controller="Home" asp-action="Index">MvcMovie</a>` to `<a class="navbar-brand" asp-controller="Movies" asp-action="Index">Movie App</a>`.

In the preceding markup, the `asp-area=""` [anchor Tag Helper attribute](xref:mvc/views/tag-helpers/builtin-th/anchor-tag-helper) and attribute value was omitted because this app isn't using [Areas](xref:mvc/controllers/areas).

**Note**: The `Movies` controller hasn't been implemented. At this point, the `Movie App` link isn't functional.

Save the changes and select the **Privacy** link. Notice how the title on the browser tab displays **Privacy Policy - Movie App** instead of **Privacy Policy - MvcMovie**

![Privacy tab](~/tutorials/first-mvc-app/adding-view/_static/privacy50.png)

Select the **Home** link.

Notice that the title and anchor text display **Movie App**. The changes were made once in the layout template and all pages on the site reflect the new link text and new title.

Examine the `Views/_ViewStart.cshtml` file:

```cshtml
@{
    Layout = "_Layout";
}
```

The `Views/_ViewStart.cshtml` file brings in the `Views/Shared/_Layout.cshtml` file to each view. The `Layout` property can be used to set a different layout view, or set it to `null` so no layout file will be used.

Open the `Views/HelloWorld/Index.cshtml` view file.

Change the title and `<h2>` element as highlighted in the following:

[!code-cshtml[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie/Views/HelloWorld/Index2.cshtml?highlight=2,5)]

The title and `<h2>` element are slightly different so it's clear which part of the code changes the display.

`ViewData["Title"] = "Movie List";` in the code above sets the `Title` property of the `ViewData` dictionary to "Movie List". The `Title` property is used in the `<title>` HTML element in the layout page:

```cshtml
<title>@ViewData["Title"] - Movie App</title>
```

Save the change and navigate to `https://localhost:{PORT}/HelloWorld`.

Notice that the following have changed:

* Browser title.
* Primary heading.
* Secondary headings.

If there are no changes in the browser, it could be cached content that is being viewed. Press Ctrl+F5 in the browser to force the response from the server to be loaded. The browser title is created with `ViewData["Title"]` we set in the `Index.cshtml` view template and the additional "- Movie App" added in the layout file.

The content in the `Index.cshtml` view template is merged with the `Views/Shared/_Layout.cshtml` view template. A single HTML response is sent to the browser. Layout templates make it easy to make changes that apply across all of the pages in an app. To learn more, see [Layout](xref:mvc/views/layout).

![Movie List view](~/tutorials/first-mvc-app/adding-view/_static/hell50.png)

The small bit of "data", the "Hello from our View Template!" message, is hard-coded however. The MVC application has a "V" (view), a "C" (controller), but no "M" (model) yet.

## Passing Data from the Controller to the View

Controller actions are invoked in response to an incoming URL request. A controller class is where the code is written that handles the incoming browser requests. The controller retrieves data from a data source and decides what type of response to send back to the browser. View templates can be used from a controller to generate and format an HTML response to the browser.

Controllers are responsible for providing the data required in order for a view template to render a response.

View templates should **not**:

* Do business logic
* Interact with a database directly.

A view template should work only with the data that's provided to it by the controller. Maintaining this "separation of concerns" helps keep the code:

* Clean.
* Testable.
* Maintainable.

Currently, the `Welcome` method in the `HelloWorldController` class takes a `name` and an `ID` parameter and then outputs the values directly to the browser.

Rather than have the controller render this response as a string, change the controller to use a view template instead. The view template generates a dynamic response, which means that appropriate data must be passed from the controller to the view to generate the response. Do this by having the controller put the dynamic data (parameters) that the view template needs in a `ViewData` dictionary. The view template can then access the dynamic data.

In `HelloWorldController.cs`, change the `Welcome` method to add a `Message` and `NumTimes` value to the `ViewData` dictionary.

The `ViewData` dictionary is a dynamic object, which means any type can be used. The `ViewData` object has no defined properties until something is added. The [MVC model binding system](xref:mvc/models/model-binding) automatically maps the named parameters `name` and `numTimes` from the query string to parameters in the method. The complete `HelloWorldController`:

[!code-csharp[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie/Controllers/HelloWorldController.cs?name=snippet_5&highlight=13-19)]

The `ViewData` dictionary object contains data that will be passed to the view.

Create a Welcome view template named `Views/HelloWorld/Welcome.cshtml`.

You'll create a loop in the `Welcome.cshtml` view template that displays "Hello" `NumTimes`. Replace the contents of `Views/HelloWorld/Welcome.cshtml` with the following:

[!code-cshtml[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie/Views/HelloWorld/Welcome.cshtml)]

Save your changes and browse to the following URL:

`https://localhost:{PORT}/HelloWorld/Welcome?name=Rick&numtimes=4`

Data is taken from the URL and passed to the controller using the [MVC model binder](xref:mvc/models/model-binding). The controller packages the data into a `ViewData` dictionary and passes that object to the view. The view then renders the data as HTML to the browser.

![Privacy view showing a Welcome label and the phrase Hello Rick shown four times](~/tutorials/first-mvc-app/adding-view/_static/rick2_50.png)

In the preceding sample, the `ViewData` dictionary was used to pass data from the controller to a view. Later in the tutorial, a view model is used to pass data from a controller to a view. The view model approach to passing data is preferred over the `ViewData` dictionary approach.

In the next tutorial, a database of movies is created.

> [!div class="step-by-step"]
> [Previous: Add a Controller](~/tutorials/first-mvc-app/adding-controller.md)
> [Next: Add a Model](~/tutorials/first-mvc-app/adding-model.md)

:::moniker-end
