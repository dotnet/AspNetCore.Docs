:::moniker range="= aspnetcore-3.1"

# [Visual Studio](#tab/visual-studio)

[!INCLUDE[](~/includes/net-core-prereqs-vs-3.1.md)]

# [Visual Studio Code](#tab/visual-studio-code)

[!INCLUDE[](~/includes/net-core-prereqs-vsc-3.1.md)]

# [Visual Studio for Mac](#tab/visual-studio-mac)

[!INCLUDE[](~/includes/net-core-prereqs-mac-3.1.md)]

---

:::moniker-end

:::moniker range="= aspnetcore-5.0"

# [Visual Studio](#tab/visual-studio)

[!INCLUDE[](~/includes/net-core-prereqs-vs-5.0.md)]

# [Visual Studio Code](#tab/visual-studio-code)

[!INCLUDE[](~/includes/net-core-prereqs-vsc-5.0.md)]

# [Visual Studio for Mac](#tab/visual-studio-mac)

[!INCLUDE[](~/includes/net-core-prereqs-mac-5.0.md)]

---
:::moniker-end

:::moniker range="< aspnetcore-6.0"

<a name="rpvs17"></a>

## Create a Razor Pages project

# [Visual Studio](#tab/visual-studio)

See [Get started with Razor Pages](xref:tutorials/razor-pages/razor-pages-start) for detailed instructions on how to create a Razor Pages project.

# [Visual Studio Code](#tab/visual-studio-code)

Run `dotnet new webapp` from the command line.

# [Visual Studio for Mac](#tab/visual-studio-mac)

See [Get started with Razor Pages](xref:tutorials/razor-pages/razor-pages-start) for detailed instructions on how to create a Razor Pages project.

---

## Razor Pages

Razor Pages is enabled in `Startup.cs`:

[!code-csharp[](~/razor-pages/index/3.0sample/RazorPagesIntro/Startup.cs?name=snippet_Startup&highlight=12,36)]

Consider a basic page:
<a name="OnGet"></a>

[!code-cshtml[](~/razor-pages/index/3.0sample/RazorPagesIntro/Pages/Index.cshtml?highlight=1)]

The preceding code looks a lot like a [Razor view file](xref:tutorials/first-mvc-app/adding-view) used in an ASP.NET Core app with controllers and views. What makes it different is the [`@page`](xref:mvc/views/razor#page) directive. `@page` makes the file into an MVC action - which means that it handles requests directly, without going through a controller. `@page` must be the first Razor directive on a page. `@page` affects the behavior of other [Razor](xref:mvc/views/razor) constructs. Razor Pages file names have a `.cshtml` suffix.

A similar page, using a `PageModel` class, is shown in the following two files. The `Pages/Index2.cshtml` file:

[!code-cshtml[](~/razor-pages/index/3.0sample/RazorPagesIntro/Pages/Index2.cshtml)]

The `Pages/Index2.cshtml.cs` page model:

[!code-csharp[](~/razor-pages/index/3.0sample/RazorPagesIntro/Pages/Index2.cshtml.cs)]

By convention, the `PageModel` class file has the same name as the Razor Page file with `.cs` appended. For example, the previous Razor Page is `Pages/Index2.cshtml`. The file containing the `PageModel` class is named `Pages/Index2.cshtml.cs`.

The associations of URL paths to pages are determined by the page's location in the file system. The following table shows a Razor Page path and the matching URL:

| File name and path               | matching URL |
| ----------------- | ------------ |
| `/Pages/Index.cshtml` | `/` or `/Index` |
| `/Pages/Contact.cshtml` | `/Contact` |
| `/Pages/Store/Contact.cshtml` | `/Store/Contact` |
| `/Pages/Store/Index.cshtml` | `/Store` or `/Store/Index` |

Notes:

* The runtime looks for Razor Pages files in the *Pages* folder by default.
* `Index` is the default page when a URL doesn't include a page.

## Write a basic form

Razor Pages is designed to make common patterns used with web browsers easy to implement when building an app. [Model binding](xref:mvc/models/model-binding), [Tag Helpers](xref:mvc/views/tag-helpers/intro), and HTML helpers all *just work* with the properties defined in a Razor Page class. Consider a page that implements a basic "contact us" form for the `Contact` model:

For the samples in this document, the `DbContext` is initialized in the [Startup.cs](https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/razor-pages/index/3.0sample/RazorPagesContacts/Startup.cs#L23-L24) file.

The in memory database requires the `Microsoft.EntityFrameworkCore.InMemory` NuGet package.

[!code-csharp[](~/razor-pages/index/3.0sample/RazorPagesContacts/Startup.cs?name=snippet)]

The data model:

[!code-csharp[](~/razor-pages/index/3.0sample/RazorPagesContacts/Models/Customer.cs)]

The db context:

[!code-csharp[](~/razor-pages/index/3.0sample/RazorPagesContacts/Data/CustomerDbContext.cs)]

The `Pages/Create.cshtml` view file:

[!code-cshtml[](~/razor-pages/index/3.0sample/RazorPagesContacts/Pages/Customers/Create.cshtml)]

The `Pages/Create.cshtml.cs` page model:

[!code-csharp[](~/razor-pages/index/3.0sample/RazorPagesContacts/Pages/Customers/Create.cshtml.cs?name=snippet_ALL)]

By convention, the `PageModel` class is called `<PageName>Model` and is in the same namespace as the page.

The `PageModel` class allows separation of the logic of a page from its presentation. It defines page handlers for requests sent to the page and the data used to render the page. This separation allows:

* Managing of page dependencies through [dependency injection](xref:fundamentals/dependency-injection).
* [Unit testing](xref:test/razor-pages-tests)

The page has an `OnPostAsync` *handler method*, which runs on `POST` requests (when a user posts the form). Handler methods for any HTTP verb can be added. The most common handlers are:

* `OnGet` to initialize state needed for the page. In the preceding code, the `OnGet` method displays the `CreateModel.cshtml` Razor Page.
* `OnPost` to handle form submissions.

The `Async` naming suffix is optional but is often used by convention for asynchronous functions. The preceding code is typical for Razor Pages.

If you're familiar with ASP.NET apps using controllers and views:

* The `OnPostAsync` code in the preceding example looks similar to typical controller code.
* Most of the MVC primitives like [model binding](xref:mvc/models/model-binding), [validation](xref:mvc/models/validation), and action results work the same with Controllers and Razor Pages. 

The previous `OnPostAsync` method:

[!code-csharp[](~/razor-pages/index/3.0sample/RazorPagesContacts/Pages/Customers/Create.cshtml.cs?name=snippet_OnPostAsync)]

The basic flow of `OnPostAsync`:

Check for validation errors.

* If there are no errors, save the data and redirect.
* If there are errors, show the page again with validation messages. In many cases, validation errors would be detected on the client, and never submitted to the server.

The `Pages/Create.cshtml` view file:

[!code-cshtml[](~/razor-pages/index/3.0sample/RazorPagesContacts/Pages/Customers/Create.cshtml)]

The rendered HTML from `Pages/Create.cshtml`:

[!code-html[](~/razor-pages/index/3.0sample/RazorPagesContacts/Pages/Customers/Create4.html)]

In the previous code, posting the form:

* With valid data:

  * The `OnPostAsync` handler method calls the <xref:Microsoft.AspNetCore.Mvc.RazorPages.PageModel.RedirectToPage%2A> helper method. `RedirectToPage` returns an instance of <xref:Microsoft.AspNetCore.Mvc.RedirectToPageResult>. `RedirectToPage`:

    * Is an action result.
    * Is similar to `RedirectToAction` or `RedirectToRoute` (used in controllers and views).
    * Is customized for pages. In the preceding sample, it redirects to the root Index page (`/Index`). `RedirectToPage` is detailed in the [URL generation for Pages](#url_gen) section.

* With validation errors that are passed to the server:

  * The `OnPostAsync` handler method calls the <xref:Microsoft.AspNetCore.Mvc.RazorPages.PageBase.Page%2A> helper method. `Page` returns an instance of <xref:Microsoft.AspNetCore.Mvc.RazorPages.PageResult>. Returning `Page` is similar to how actions in controllers return `View`. `PageResult` is the default return type for a handler method. A handler method that returns `void` renders the page.
  * In the preceding example, posting the form with no value results in [ModelState.IsValid](xref:Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.IsValid) returning false. In this sample, no validation errors are displayed on the client. Validation error handling is covered later in this document.

  [!code-csharp[](~/razor-pages/index/3.0sample/RazorPagesContacts/Pages/Customers/Create.cshtml.cs?name=snippet_OnPostAsync&highlight=3-6)]

* With validation errors detected by client side validation:

  * Data is **not** posted to the server.
  * Client-side validation is explained later in this document.

The `Customer` property uses [`[BindProperty]`](xref:Microsoft.AspNetCore.Mvc.BindPropertyAttribute) attribute to opt in to model binding:

[!code-csharp[](~/razor-pages/index/3.0sample/RazorPagesContacts/Pages/Customers/Create.cshtml.cs?name=snippet_PageModel&highlight=15-16)]

`[BindProperty]` should **not** be used on models containing properties that should not be changed by the client. For more information, see [Overposting](xref:data/ef-rp/crud#overposting).

Razor Pages, by default, bind properties only with non-`GET` verbs. Binding to properties removes the need to writing code to convert HTTP data to the model type. Binding reduces code by using the same property to render form fields (`<input asp-for="Customer.Name">`) and accept the input.

[!INCLUDE[](~/includes/bind-get.md)]

Reviewing the `Pages/Create.cshtml` view file:

[!code-cshtml[](~/razor-pages/index/3.0sample/RazorPagesContacts/Pages/Customers/Create.cshtml?highlight=3,9)]

* In the preceding code, the [input tag helper](xref:mvc/views/working-with-forms#the-input-tag-helper) `<input asp-for="Customer.Name" />` binds the HTML `<input>` element to the `Customer.Name` model expression.
* [`@addTagHelper`](xref:mvc/views/tag-helpers/intro#addtaghelper-makes-tag-helpers-available) makes Tag Helpers available.

### The home page

`Index.cshtml` is the home page:

[!code-cshtml[](~/razor-pages/index/3.0sample/RazorPagesContacts/Pages/Customers/Index.cshtml)]

The associated `PageModel` class (`Index.cshtml.cs`):

[!code-csharp[](~/razor-pages/index/3.0sample/RazorPagesContacts/Pages/Customers/Index.cshtml.cs?name=snippet)]

The `Index.cshtml` file contains the following markup:

[!code-cshtml[](~/razor-pages/index/3.0sample/RazorPagesContacts/Pages/Customers/Index.cshtml?name=snippet_Edit)]

The `<a /a>` [Anchor Tag Helper](xref:mvc/views/tag-helpers/builtin-th/anchor-tag-helper) used the `asp-route-{value}` attribute to generate a link to the Edit page. The link contains route data with the contact ID. For example, `https://localhost:5001/Edit/1`. [Tag Helpers](xref:mvc/views/tag-helpers/intro) enable server-side code to participate in creating and rendering HTML elements in Razor files.

The `Index.cshtml` file contains markup to create a delete button for each customer contact:

[!code-cshtml[](~/razor-pages/index/3.0sample/RazorPagesContacts/Pages/Customers/Index.cshtml?name=snippet_Delete)]

The rendered HTML:

```html
<button type="submit" formaction="/Customers?id=1&amp;handler=delete">delete</button>
```

When the delete button is rendered in HTML, its [formaction](https://developer.mozilla.org/docs/Web/HTML/Element/button#attr-formaction) includes parameters for:

* The customer contact ID, specified by the `asp-route-id` attribute.
* The `handler`, specified by the `asp-page-handler` attribute.

When the button is selected, a form `POST` request is sent to the server. By convention, the name of the handler method is selected based on the value of the `handler` parameter according to the scheme `OnPost[handler]Async`.

Because the `handler` is `delete` in this example, the `OnPostDeleteAsync` handler method is used to process the `POST` request. If the `asp-page-handler` is set to a different value, such as `remove`, a handler method with the name `OnPostRemoveAsync` is selected.

[!code-csharp[](~/razor-pages/index/3.0sample/RazorPagesContacts/Pages/Customers/Index.cshtml.cs?name=snippet2)]

The `OnPostDeleteAsync` method:

* Gets the `id` from the query string.
* Queries the database for the customer contact with `FindAsync`.
* If the customer contact is found, it's removed and the database is updated.
* Calls <xref:Microsoft.AspNetCore.Mvc.RazorPages.PageModel.RedirectToPage%2A> to redirect to the root Index page (`/Index`).

### The Edit.cshtml file

[!code-cshtml[](~/razor-pages/index/3.0sample/RazorPagesContacts/Pages/Customers/Edit.cshtml?highlight=1)]

The first line contains the `@page "{id:int}"` directive. The routing constraint `"{id:int}"` tells the page to accept requests to the page that contain `int` route data. If a request to the page doesn't contain route data that can be converted to an `int`, the runtime returns an HTTP 404 (not found) error. To make the ID optional, append `?` to the route constraint:

 ```cshtml
@page "{id:int?}"
```

The `Edit.cshtml.cs` file:

[!code-csharp[](~/razor-pages/index/3.0sample/RazorPagesContacts/Pages/Customers/Edit.cshtml.cs?name=snippet)]

## Validation

Validation rules:

* Are declaratively specified in the model class.
* Are enforced everywhere in the app.

The <xref:System.ComponentModel.DataAnnotations> namespace provides a set of built-in validation attributes that are applied declaratively to a class or property. DataAnnotations also contains formatting attributes like [`[DataType]`](xref:System.ComponentModel.DataAnnotations.DataTypeAttribute) that help with formatting and don't provide any validation.

Consider the `Customer` model:

[!code-csharp[](~/razor-pages/index/3.0sample/RazorPagesContacts/Models/Customer.cs)]

Using the following `Create.cshtml` view file:

[!code-cshtml[](~/razor-pages/index/3.0sample/RazorPagesContacts/Pages/Customers/Create3.cshtml?highlight=3,8-9,15-99)]

The preceding code:

* Includes jQuery and jQuery validation scripts.
* Uses the `<div />` and `<span />` [Tag Helpers](xref:mvc/views/tag-helpers/intro) to enable:

  * Client-side validation.
  * Validation error rendering.

* Generates the following HTML:

  [!code-html[](~/razor-pages/index/3.0sample/RazorPagesContacts/Pages/Customers/Create5.html)]

Posting the Create form without a name value displays the error message "The Name field is required." on the form. If JavaScript is enabled on the client, the browser displays the error without posting to the server.

The `[StringLength(10)]` attribute generates `data-val-length-max="10"` on the rendered HTML. `data-val-length-max` prevents browsers from entering more than the maximum length specified. If a tool such as [Fiddler](https://www.telerik.com/fiddler) is used to edit and replay the post:

* With the name longer than 10.
* The error message "The field Name must be a string with a maximum length of 10." is returned.

Consider the following `Movie` model:

[!code-csharp[](~/tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie30/Models/MovieDateRatingDA.cs?name=snippet1)]

The validation attributes specify behavior to enforce on the model properties they're applied to:

* The `Required` and `MinimumLength` attributes indicate that a property must have a value, but nothing prevents a user from entering white space to satisfy this validation.
* The `RegularExpression` attribute is used to limit what characters can be input. In the preceding code, "Genre":

  * Must only use letters.
  * The first letter is required to be uppercase. White space, numbers, and special
   characters are not allowed.

* The `RegularExpression` "Rating":

  * Requires that the first character be an uppercase letter.
  * Allows special characters and numbers in subsequent spaces. "PG-13" is valid for a rating, but fails for a "Genre".

* The `Range` attribute constrains a value to within a specified range.
* The `StringLength` attribute sets the maximum length of a string property, and optionally its minimum length.
* Value types (such as `decimal`, `int`, `float`, `DateTime`) are inherently required and don't need the `[Required]` attribute.

The Create page for the `Movie` model shows displays errors with invalid values:

![Movie view form with multiple jQuery client-side validation errors](~/tutorials/razor-pages/validation/_static/val.png)

For more information, see:

* [Add validation to the Movie app](xref:tutorials/razor-pages/validation)
* [Model validation in ASP.NET Core](xref:mvc/models/validation).

## Handle HEAD requests with an OnGet handler fallback

`HEAD` requests allow retrieving the headers for a specific resource. Unlike `GET` requests, `HEAD` requests don't return a response body.

Ordinarily, an `OnHead` handler is created and called for `HEAD` requests:

[!code-csharp[](~/razor-pages/index/3.0sample/RazorPagesContacts/Pages/Privacy.cshtml.cs?name=snippet)]

Razor Pages falls back to calling the `OnGet` handler if no `OnHead` handler is defined.

<a name="xsrf"></a>

## XSRF/CSRF and Razor Pages

Razor Pages are protected by [Antiforgery validation](xref:security/anti-request-forgery). The [FormTagHelper](xref:mvc/views/working-with-forms#the-form-tag-helper) injects antiforgery tokens into HTML form elements.

<a name="layout"></a>

## Using Layouts, partials, templates, and Tag Helpers with Razor Pages

Pages work with all the capabilities of the Razor view engine. Layouts, partials, templates, Tag Helpers, `_ViewStart.cshtml`, and `_ViewImports.cshtml` work in the same way they do for conventional Razor views.

Let's declutter this page by taking advantage of some of those capabilities.

Add a [layout page](xref:mvc/views/layout) to `Pages/Shared/_Layout.cshtml`:

[!code-cshtml[](~/razor-pages/index/3.0sample/RazorPagesContacts/Pages/Shared/_Layout2.cshtml?highlight=12)]

The [Layout](xref:mvc/views/layout):

* Controls the layout of each page (unless the page opts out of layout).
* Imports HTML structures such as JavaScript and stylesheets.
* The contents of the Razor page are rendered where `@RenderBody()` is called.

For more information, see [layout page](xref:mvc/views/layout).

The [Layout](xref:mvc/views/layout#specifying-a-layout) property is set in `Pages/_ViewStart.cshtml`:

[!code-cshtml[](~/razor-pages/index/sample/RazorPagesContacts2/Pages/_ViewStart.cshtml)]

The layout is in the *Pages/Shared* folder. Pages look for other views (layouts, templates, partials) hierarchically, starting in the same folder as the current page. A layout in the *Pages/Shared* folder can be used from any Razor page under the *Pages* folder.

The layout file should go in the *Pages/Shared* folder.

We recommend you **not** put the layout file in the *Views/Shared* folder. *Views/Shared* is an MVC views pattern. Razor Pages are meant to rely on folder hierarchy, not path conventions.

View search from a Razor Page includes the *Pages* folder. The layouts, templates, and partials used with MVC controllers and conventional Razor views *just work*.

Add a `Pages/_ViewImports.cshtml` file:

[!code-cshtml[](~/razor-pages/index/sample/RazorPagesContacts2/Pages/_ViewImports.cshtml)]

`@namespace` is explained later in the tutorial. The `@addTagHelper` directive brings in the [built-in Tag Helpers](xref:mvc/views/tag-helpers/builtin-th/Index) to all the pages in the *Pages* folder.

<a name="namespace"></a>

The `@namespace` directive set on a page:

[!code-cshtml[](~/razor-pages/index/sample/RazorPagesIntro/Pages/Customers/Namespace2.cshtml?highlight=2)]

The `@namespace` directive sets the namespace for the page. The `@model` directive doesn't need to include the namespace.

When the `@namespace` directive is contained in `_ViewImports.cshtml`, the specified namespace supplies the prefix for the generated namespace in the Page that imports the `@namespace` directive. The rest of the generated namespace (the suffix portion) is the dot-separated relative path between the folder containing `_ViewImports.cshtml` and the folder containing the page.

For example, the `PageModel` class `Pages/Customers/Edit.cshtml.cs` explicitly sets the namespace:

[!code-csharp[](~/razor-pages/index/sample/RazorPagesContacts2/Pages/Customers/Edit.cshtml.cs?name=snippet_namespace)]

The `Pages/_ViewImports.cshtml` file sets the following namespace:

[!code-cshtml[](~/razor-pages/index/sample/RazorPagesContacts2/Pages/_ViewImports.cshtml?highlight=1)]

The generated namespace for the `Pages/Customers/Edit.cshtml` Razor Page is the same as the `PageModel` class.

`@namespace` *also works with conventional Razor views.*

Consider the `Pages/Create.cshtml` view file:

[!code-cshtml[](~/razor-pages/index/3.0sample/RazorPagesContacts/Pages/Customers/Create3.cshtml?highlight=2-3)]

The updated `Pages/Create.cshtml` view file with `_ViewImports.cshtml` and the preceding layout file:

[!code-cshtml[](~/razor-pages/index/3.0sample/RazorPagesContacts/Pages/Customers/Create4.cshtml?highlight=2)]

In the preceding code, the `_ViewImports.cshtml` imported the namespace and Tag Helpers. The layout file imported the JavaScript files.

The [Razor Pages starter project](#rpvs17) contains the `Pages/_ValidationScriptsPartial.cshtml`, which hooks up client-side validation.

For more information on partial views, see <xref:mvc/views/partial>.

<a name="url_gen"></a>

## URL generation for Pages

The `Create` page, shown previously, uses `RedirectToPage`:

[!code-csharp[](~/razor-pages/index/3.0sample/RazorPagesContacts/Pages/Customers/Create.cshtml.cs?name=snippet_PageModel&highlight=28)]

The app has the following file/folder structure:

* */Pages*

  * `Index.cshtml`
  * `Privacy.cshtml`
  * */Customers*

    * `Create.cshtml`
    * `Edit.cshtml`
    * `Index.cshtml`

The `Pages/Customers/Create.cshtml` and `Pages/Customers/Edit.cshtml` pages redirect to `Pages/Customers/Index.cshtml` after success. The string `./Index` is a relative page name used to access the preceding page. It is used to generate URLs to the `Pages/Customers/Index.cshtml` page. For example:

* `Url.Page("./Index", ...)`
* `<a asp-page="./Index">Customers Index Page</a>`
* `RedirectToPage("./Index")`

The absolute page name `/Index` is used to generate URLs to the `Pages/Index.cshtml` page. For example:

* `Url.Page("/Index", ...)`
* `<a asp-page="/Index">Home Index Page</a>`
* `RedirectToPage("/Index")`

The page name is the path to the page from the root */Pages* folder including a leading `/` (for example, `/Index`). The preceding URL generation samples offer enhanced options and functional capabilities over hard-coding a URL. URL generation uses [routing](xref:mvc/controllers/routing) and can generate and encode parameters according to how the route is defined in the destination path.

URL generation for pages supports relative names. The following table shows which Index page is selected using different `RedirectToPage` parameters in `Pages/Customers/Create.cshtml`.

| RedirectToPage(x)| Page |
| ----------------- | ------------ |
| RedirectToPage("/Index") | *Pages/Index* |
| RedirectToPage("./Index"); | *Pages/Customers/Index* |
| RedirectToPage("../Index") | *Pages/Index* |
| RedirectToPage("Index")  | *Pages/Customers/Index* |

<!-- Test via ~/razor-pages/index/3.0sample/RazorPagesContacts/Pages/Customers/Details.cshtml.cs -->

`RedirectToPage("Index")`, `RedirectToPage("./Index")`, and `RedirectToPage("../Index")` are *relative names*. The `RedirectToPage` parameter is *combined* with the path of the current page to compute the name of the destination page.

Relative name linking is useful when building sites with a complex structure. When relative names are used to link between pages in a folder:

* Renaming a folder doesn't break the relative links.
* Links are not broken because they don't include the folder name.

To redirect to a page in a different [Area](xref:mvc/controllers/areas), specify the area:

```csharp
RedirectToPage("/Index", new { area = "Services" });
```

For more information, see <xref:mvc/controllers/areas> and <xref:razor-pages/razor-pages-conventions>.

## ViewData attribute

Data can be passed to a page with <xref:Microsoft.AspNetCore.Mvc.ViewDataAttribute>. Properties with the `[ViewData]` attribute have their values stored and loaded from the <xref:Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary>.

In the following example, the `AboutModel` applies the `[ViewData]` attribute to the `Title` property:

```csharp
public class AboutModel : PageModel
{
    [ViewData]
    public string Title { get; } = "About";

    public void OnGet()
    {
    }
}
```

In the About page, access the `Title` property as a model property:

```cshtml
<h1>@Model.Title</h1>
```

In the layout, the title is read from the ViewData dictionary:

```cshtml
<!DOCTYPE html>
<html lang="en">
<head>
    <title>@ViewData["Title"] - WebApplication</title>
    ...
```

## TempData

ASP.NET Core exposes the <xref:Microsoft.AspNetCore.Mvc.Controller.TempData>. This property stores data until it's read. The <xref:Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionary.Keep%2A> and <xref:Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionary.Peek%2A> methods can be used to examine the data without deletion. `TempData` is useful for redirection, when data is needed for more than a single request.

The following code sets the value of `Message` using `TempData`:

[!code-csharp[](~/razor-pages/index/sample/RazorPagesContacts2/Pages/Customers/CreateDot.cshtml.cs?highlight=10-11,25&name=snippet_Temp)]

The following markup in the `Pages/Customers/Index.cshtml` file displays the value of `Message` using `TempData`.

```cshtml
<h3>Msg: @Model.Message</h3>
```

The `Pages/Customers/Index.cshtml.cs` page model applies the `[TempData]` attribute to the `Message` property.

```csharp
[TempData]
public string Message { get; set; }
```

For more information, see [TempData](xref:fundamentals/app-state#tempdata).

<a name="mhpp"></a>

## Multiple handlers per page

The following page generates markup for two handlers using the `asp-page-handler` Tag Helper:

[!code-cshtml[](~/razor-pages/index/sample/RazorPagesContacts2/Pages/Customers/CreateFATH.cshtml?highlight=12-13)]

The form in the preceding example has two submit buttons, each using the `FormActionTagHelper` to submit to a different URL. The `asp-page-handler` attribute is a companion to `asp-page`. `asp-page-handler` generates URLs that submit to each of the handler methods defined by a page. `asp-page` isn't specified because the sample is linking to the current page.

The page model:

[!code-csharp[](~/razor-pages/index/sample/RazorPagesContacts2/Pages/Customers/CreateFATH.cshtml.cs?highlight=20,32)]

The preceding code uses *named handler methods*. Named handler methods are created by taking the text in the name after `On<HTTP Verb>` and before `Async` (if present). In the preceding example, the page methods are OnPost**JoinList**Async and OnPost**JoinListUC**Async. With *OnPost* and *Async* removed, the handler names are `JoinList` and `JoinListUC`.

[!code-cshtml[](~/razor-pages/index/sample/RazorPagesContacts2/Pages/Customers/CreateFATH.cshtml?name=snippet_Handlers)]

Using the preceding code, the URL path that submits to `OnPostJoinListAsync` is `https://localhost:5001/Customers/CreateFATH?handler=JoinList`. The URL path that submits to `OnPostJoinListUCAsync` is `https://localhost:5001/Customers/CreateFATH?handler=JoinListUC`.

## Custom routes

Use the `@page` directive to:

* Specify a custom route to a page. For example, the route to the About page can be set to `/Some/Other/Path` with `@page "/Some/Other/Path"`.
* Append segments to a page's default route. For example, an "item" segment can be added to a page's default route with `@page "item"`.
* Append parameters to a page's default route. For example, an ID parameter, `id`, can be required for a page with `@page "{id}"`.

A root-relative path designated by a tilde (`~`) at the beginning of the path is supported. For example, `@page "~/Some/Other/Path"` is the same as `@page "/Some/Other/Path"`.

If you don't like the query string `?handler=JoinList` in the URL, change the route to put the handler name in the path portion of the URL. The route can be customized by adding a route template enclosed in double quotes after the `@page` directive.

[!code-cshtml[](~/razor-pages/index/sample/RazorPagesContacts2/Pages/Customers/CreateRoute.cshtml?highlight=1)]

Using the preceding code, the URL path that submits to `OnPostJoinListAsync` is `https://localhost:5001/Customers/CreateFATH/JoinList`. The URL path that submits to `OnPostJoinListUCAsync` is `https://localhost:5001/Customers/CreateFATH/JoinListUC`.

The `?` following `handler` means the route parameter is optional.

## Advanced configuration and settings

The configuration and settings in following sections is not required by most apps.

To configure advanced options, use the <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddRazorPages%2A> overload that configures <xref:Microsoft.AspNetCore.Mvc.RazorPages.RazorPagesOptions>:

[!code-csharp[](~/razor-pages/index/3.0sample/RazorPagesContacts/StartupRPoptions.cs?name=snippet)]

Use the <xref:Microsoft.AspNetCore.Mvc.RazorPages.RazorPagesOptions> to set the root directory for pages, or add application model conventions for pages. For more information on conventions, see [Razor Pages authorization conventions](xref:security/authorization/razor-pages-authorization).

To precompile views, see [Razor view compilation](xref:mvc/views/view-compilation).

### Specify that Razor Pages are at the content root

By default, Razor Pages are rooted in the */Pages* directory. Add <xref:Microsoft.Extensions.DependencyInjection.MvcRazorPagesMvcBuilderExtensions.WithRazorPagesAtContentRoot%2A> to specify that your Razor Pages are at the [content root](xref:fundamentals/index#content-root) (<xref:Microsoft.AspNetCore.Hosting.IHostingEnvironment.ContentRootPath>) of the app:

[!code-csharp[](~/razor-pages/index/3.0sample/RazorPagesContacts/StartupWithRazorPagesAtContentRoot.cs?name=snippet)]

### Specify that Razor Pages are at a custom root directory

Add <xref:Microsoft.Extensions.DependencyInjection.MvcRazorPagesMvcCoreBuilderExtensions.WithRazorPagesRoot%2A> to specify that Razor Pages are at a custom root directory in the app (provide a relative path):

[!code-csharp[](~/razor-pages/index/3.0sample/RazorPagesContacts/StartupWithRazorPagesRoot.cs?name=snippet)]

## Additional resources

* See [Get started with Razor Pages](xref:tutorials/razor-pages/razor-pages-start), which builds on this introduction.
* [Authorize attribute and Razor Pages](xref:security/authorization/simple#aarp)
* [Download or view sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/razor-pages/index/3.0sample)
* <xref:index>
* <xref:mvc/views/razor>
* <xref:mvc/controllers/areas>
* <xref:tutorials/razor-pages/razor-pages-start>
* <xref:security/authorization/razor-pages-authorization>
* <xref:razor-pages/razor-pages-conventions>
* <xref:test/razor-pages-tests>
* <xref:mvc/views/partial>

:::moniker-end
