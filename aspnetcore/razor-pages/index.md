---
title: Introduction to Razor Pages in ASP.NET Core
author: Rick-Anderson
description: Learn how Razor Pages in ASP.NET Core makes coding page-focused scenarios easier and more productive than using MVC.
monikerRange: '>= aspnetcore-2.0'
ms.author: riande
ms.date: 02/12/2020
no-loc: [Blazor, "Identity", "Let's Encrypt", Razor, SignalR]
uid: razor-pages/index
---
# Introduction to Razor Pages in ASP.NET Core

::: moniker range=">= aspnetcore-3.0"

By [Rick Anderson](https://twitter.com/RickAndMSFT) and [Ryan Nowak](https://github.com/rynowak)

Razor Pages can make coding page-focused scenarios easier and more productive than using controllers and views.

If you're looking for a tutorial that uses the Model-View-Controller approach, see [Get started with ASP.NET Core MVC](xref:tutorials/first-mvc-app/start-mvc).

This document provides an introduction to Razor Pages. It's not a step by step tutorial. If you find some of the sections too advanced, see [Get started with Razor Pages](xref:tutorials/razor-pages/razor-pages-start). For an overview of ASP.NET Core, see the [Introduction to ASP.NET Core](xref:index).

## Prerequisites

# [Visual Studio](#tab/visual-studio)

[!INCLUDE[](~/includes/net-core-prereqs-vs-3.0.md)]

# [Visual Studio Code](#tab/visual-studio-code)

[!INCLUDE[](~/includes/net-core-prereqs-vsc-3.0.md)]

# [Visual Studio for Mac](#tab/visual-studio-mac)

[!INCLUDE[](~/includes/net-core-prereqs-mac-3.0.md)]

---

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

Razor Pages is enabled in *Startup.cs*:

[!code-cs[](index/3.0sample/RazorPagesIntro/Startup.cs?name=snippet_Startup&highlight=12,36)]

Consider a basic page:
<a name="OnGet"></a>

[!code-cshtml[](index/3.0sample/RazorPagesIntro/Pages/Index.cshtml?highlight=1)]

The preceding code looks a lot like a [Razor view file](xref:tutorials/first-mvc-app/adding-view) used in an ASP.NET Core app with controllers and views. What makes it different is the [`@page`](xref:mvc/views/razor#page) directive. `@page` makes the file into an MVC action - which means that it handles requests directly, without going through a controller. `@page` must be the first Razor directive on a page. `@page` affects the behavior of other [Razor](xref:mvc/views/razor) constructs. Razor Pages file names have a *.cshtml* suffix.

A similar page, using a `PageModel` class, is shown in the following two files. The *Pages/Index2.cshtml* file:

[!code-cshtml[](index/3.0sample/RazorPagesIntro/Pages/Index2.cshtml)]

The *Pages/Index2.cshtml.cs* page model:

[!code-cs[](index/3.0sample/RazorPagesIntro/Pages/Index2.cshtml.cs)]

By convention, the `PageModel` class file has the same name as the Razor Page file with *.cs* appended. For example, the previous Razor Page is *Pages/Index2.cshtml*. The file containing the `PageModel` class is named *Pages/Index2.cshtml.cs*.

The associations of URL paths to pages are determined by the page's location in the file system. The following table shows a Razor Page path and the matching URL:

| File name and path               | matching URL |
| ----------------- | ------------ |
| */Pages/Index.cshtml* | `/` or `/Index` |
| */Pages/Contact.cshtml* | `/Contact` |
| */Pages/Store/Contact.cshtml* | `/Store/Contact` |
| */Pages/Store/Index.cshtml* | `/Store` or `/Store/Index` |

Notes:

* The runtime looks for Razor Pages files in the *Pages* folder by default.
* `Index` is the default page when a URL doesn't include a page.

## Write a basic form

Razor Pages is designed to make common patterns used with web browsers easy to implement when building an app. [Model binding](xref:mvc/models/model-binding), [Tag Helpers](xref:mvc/views/tag-helpers/intro), and HTML helpers all *just work* with the properties defined in a Razor Page class. Consider a page that implements a basic "contact us" form for the `Contact` model:

For the samples in this document, the `DbContext` is initialized in the [Startup.cs](https://github.com/dotnet/AspNetCore.Docs/blob/master/aspnetcore/razor-pages/index/3.0sample/RazorPagesContacts/Startup.cs#L23-L24) file.

[!code-cs[](index/3.0sample/RazorPagesContacts/Startup.cs?name=snippet)]

The data model:

[!code-cs[](index/3.0sample/RazorPagesContacts/Models/Customer.cs)]

The db context:

[!code-cs[](index/3.0sample/RazorPagesContacts/Data/CustomerDbContext.cs)]

The *Pages/Create.cshtml* view file:

[!code-cshtml[](index/3.0sample/RazorPagesContacts/Pages/Customers/Create.cshtml)]

The *Pages/Create.cshtml.cs* page model:

[!code-cs[](index/3.0sample/RazorPagesContacts/Pages/Customers/Create.cshtml.cs?name=snippet_ALL)]

By convention, the `PageModel` class is called `<PageName>Model` and is in the same namespace as the page.

The `PageModel` class allows separation of the logic of a page from its presentation. It defines page handlers for requests sent to the page and the data used to render the page. This separation allows:

* Managing of page dependencies through [dependency injection](xref:fundamentals/dependency-injection).
* [Unit testing](xref:test/razor-pages-tests)

The page has an `OnPostAsync` *handler method*, which runs on `POST` requests (when a user posts the form). Handler methods for any HTTP verb can be added. The most common handlers are:

* `OnGet` to initialize state needed for the page. In the preceding code, the `OnGet` method displays the *CreateModel.cshtml* Razor Page.
* `OnPost` to handle form submissions.

The `Async` naming suffix is optional but is often used by convention for asynchronous functions. The preceding code is typical for Razor Pages.

If you're familiar with ASP.NET apps using controllers and views:

* The `OnPostAsync` code in the preceding example looks similar to typical controller code.
* Most of the MVC primitives like [model binding](xref:mvc/models/model-binding), [validation](xref:mvc/models/validation), and action results work the same with Controllers and Razor Pages. 

The previous `OnPostAsync` method:

[!code-cs[](index/3.0sample/RazorPagesContacts/Pages/Customers/Create.cshtml.cs?name=snippet_OnPostAsync)]

The basic flow of `OnPostAsync`:

Check for validation errors.

* If there are no errors, save the data and redirect.
* If there are errors, show the page again with validation messages. In many cases, validation errors would be detected on the client, and never submitted to the server.

The *Pages/Create.cshtml* view file:

[!code-cshtml[](index/3.0sample/RazorPagesContacts/Pages/Customers/Create.cshtml)]

The rendered HTML from *Pages/Create.cshtml*:

[!code-html[](index/3.0sample/RazorPagesContacts/Pages/Customers/Create4.html)]

In the previous code, posting the form:

* With valid data:

  * The `OnPostAsync` handler method calls the <xref:Microsoft.AspNetCore.Mvc.RazorPages.PageModel.RedirectToPage*> helper method. `RedirectToPage` returns an instance of <xref:Microsoft.AspNetCore.Mvc.RedirectToPageResult>. `RedirectToPage`:

    * Is an action result.
    * Is similar to `RedirectToAction` or `RedirectToRoute` (used in controllers and views).
    * Is customized for pages. In the preceding sample, it redirects to the root Index page (`/Index`). `RedirectToPage` is detailed in the [URL generation for Pages](#url_gen) section.

* With validation errors that are passed to the server:

  * The `OnPostAsync` handler method calls the <xref:Microsoft.AspNetCore.Mvc.RazorPages.PageBase.Page*> helper method. `Page` returns an instance of <xref:Microsoft.AspNetCore.Mvc.RazorPages.PageResult>. Returning `Page` is similar to how actions in controllers return `View`. `PageResult` is the default return type for a handler method. A handler method that returns `void` renders the page.
  * In the preceding example, posting the form with no value results in [ModelState.IsValid](xref:Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.IsValid) returning false. In this sample, no validation errors are displayed on the client. Validation error handing is covered later in this document.

  [!code-cs[](index/3.0sample/RazorPagesContacts/Pages/Customers/Create.cshtml.cs?name=snippet_OnPostAsync&highlight=3-6)]

* With validation errors detected by client side validation:

  * Data is **not** posted to the server.
  * Client-side validation is explained later in this document.

The `Customer` property uses [`[BindProperty]`](xref:Microsoft.AspNetCore.Mvc.BindPropertyAttribute) attribute to opt in to model binding:

[!code-cs[](index/3.0sample/RazorPagesContacts/Pages/Customers/Create.cshtml.cs?name=snippet_PageModel&highlight=15-16)]

`[BindProperty]` should **not** be used on models containing properties that should not be changed by the client. For more information, see [Overposting](xref:data/ef-rp/crud#overposting).

Razor Pages, by default, bind properties only with non-`GET` verbs. Binding to properties removes the need to writing code to convert HTTP data to the model type. Binding reduces code by using the same property to render form fields (`<input asp-for="Customer.Name">`) and accept the input.

[!INCLUDE[](~/includes/bind-get.md)]

Reviewing the *Pages/Create.cshtml* view file:

[!code-cshtml[](index/3.0sample/RazorPagesContacts/Pages/Customers/Create.cshtml?highlight=3,9)]

* In the preceding code, the [input tag helper](xref:mvc/views/working-with-forms#the-input-tag-helper) `<input asp-for="Customer.Name" />` binds the HTML `<input>` element to the `Customer.Name` model expression.
* [`@addTagHelper`](xref:mvc/views/tag-helpers/intro#addtaghelper-makes-tag-helpers-available) makes Tag Helpers available.

### The home page

*Index.cshtml* is the home page:

[!code-cshtml[](index/3.0sample/RazorPagesContacts/Pages/Customers/Index.cshtml)]

The associated `PageModel` class (*Index.cshtml.cs*):

[!code-cs[](index/3.0sample/RazorPagesContacts/Pages/Customers/Index.cshtml.cs?name=snippet)]

The *Index.cshtml* file contains the following markup:

[!code-cshtml[](index/3.0sample/RazorPagesContacts/Pages/Customers/Index.cshtml?range=21)]

The `<a /a>` [Anchor Tag Helper](xref:mvc/views/tag-helpers/builtin-th/anchor-tag-helper) used the `asp-route-{value}` attribute to generate a link to the Edit page. The link contains route data with the contact ID. For example, `https://localhost:5001/Edit/1`. [Tag Helpers](xref:mvc/views/tag-helpers/intro) enable server-side code to participate in creating and rendering HTML elements in Razor files.

The *Index.cshtml* file contains markup to create a delete button for each customer contact:

[!code-cshtml[](index/3.0sample/RazorPagesContacts/Pages/Customers/Index.cshtml?range=22-23)]

The rendered HTML:

```html
<button type="submit" formaction="/Customers?id=1&amp;handler=delete">delete</button>
```

When the delete button is rendered in HTML, its [formaction](https://developer.mozilla.org/docs/Web/HTML/Element/button#attr-formaction) includes parameters for:

* The customer contact ID, specified by the `asp-route-id` attribute.
* The `handler`, specified by the `asp-page-handler` attribute.

When the button is selected, a form `POST` request is sent to the server. By convention, the name of the handler method is selected based on the value of the `handler` parameter according to the scheme `OnPost[handler]Async`.

Because the `handler` is `delete` in this example, the `OnPostDeleteAsync` handler method is used to process the `POST` request. If the `asp-page-handler` is set to a different value, such as `remove`, a handler method with the name `OnPostRemoveAsync` is selected.

[!code-cs[](index/3.0sample/RazorPagesContacts/Pages/Customers/Index.cshtml.cs?name=snippet2)]

The `OnPostDeleteAsync` method:

* Gets the `id` from the query string.
* Queries the database for the customer contact with `FindAsync`.
* If the customer contact is found, it's removed and the database is updated.
* Calls <xref:Microsoft.AspNetCore.Mvc.RazorPages.PageModel.RedirectToPage*> to redirect to the root Index page (`/Index`).

### The Edit.cshtml file

[!code-cshtml[](index/3.0sample/RazorPagesContacts/Pages/Customers/Edit.cshtml?highlight=1)]

The first line contains the `@page "{id:int}"` directive. The routing constraint`"{id:int}"` tells the page to accept requests to the page that contain `int` route data. If a request to the page doesn't contain route data that can be converted to an `int`, the runtime returns an HTTP 404 (not found) error. To make the ID optional, append `?` to the route constraint:

 ```cshtml
@page "{id:int?}"
```

The *Edit.cshtml.cs* file:

[!code-cs[](index/3.0sample/RazorPagesContacts/Pages/Customers/Edit.cshtml.cs?name=snippet)]

## Validation

Validation rules:

* Are declaratively specified in the model class.
* Are enforced everywhere in the app.

The <xref:System.ComponentModel.DataAnnotations> namespace provides a set of built-in validation attributes that are applied declaratively to a class or property. DataAnnotations also contains formatting attributes like [`[DataType]`](xref:System.ComponentModel.DataAnnotations.DataTypeAttribute) that help with formatting and don't provide any validation.

Consider the `Customer` model:

[!code-cs[](index/3.0sample/RazorPagesContacts/Models/Customer.cs)]

Using the following *Create.cshtml* view file:

[!code-cshtml[](index/3.0sample/RazorPagesContacts/Pages/Customers/Create3.cshtml?highlight=3,8-9,15-99)]

The preceding code:

* Includes jQuery and jQuery validation scripts.
* Uses the `<div />` and `<span />` [Tag Helpers](xref:mvc/views/tag-helpers/intro) to enable:

  * Client-side validation.
  * Validation error rendering.

* Generates the following HTML:

  [!code-html[](index/3.0sample/RazorPagesContacts/Pages/Customers/Create5.html)]

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

[!code-cs[](index/3.0sample/RazorPagesContacts/Pages/Privacy.cshtml.cs?name=snippet)]

Razor Pages falls back to calling the `OnGet` handler if no `OnHead` handler is defined.

<a name="xsrf"></a>

## XSRF/CSRF and Razor Pages

Razor Pages are protected by [Antiforgery validation](xref:security/anti-request-forgery). The [FormTagHelper](xref:mvc/views/working-with-forms#the-form-tag-helper) injects antiforgery tokens into HTML form elements.

<a name="layout"></a>

## Using Layouts, partials, templates, and Tag Helpers with Razor Pages

Pages work with all the capabilities of the Razor view engine. Layouts, partials, templates, Tag Helpers, *_ViewStart.cshtml*, and *_ViewImports.cshtml* work in the same way they do for conventional Razor views.

Let's declutter this page by taking advantage of some of those capabilities.

Add a [layout page](xref:mvc/views/layout) to *Pages/Shared/_Layout.cshtml*:

[!code-cshtml[](index/3.0sample/RazorPagesContacts/Pages/Shared/_Layout2.cshtml?hightlight=12)]

The [Layout](xref:mvc/views/layout):

* Controls the layout of each page (unless the page opts out of layout).
* Imports HTML structures such as JavaScript and stylesheets.
* The contents of the Razor page are rendered where `@RenderBody()` is called.

For more information, see [layout page](xref:mvc/views/layout).

The [Layout](xref:mvc/views/layout#specifying-a-layout) property is set in *Pages/_ViewStart.cshtml*:

[!code-cshtml[](index/sample/RazorPagesContacts2/Pages/_ViewStart.cshtml)]

The layout is in the *Pages/Shared* folder. Pages look for other views (layouts, templates, partials) hierarchically, starting in the same folder as the current page. A layout in the *Pages/Shared* folder can be used from any Razor page under the *Pages* folder.

The layout file should go in the *Pages/Shared* folder.

We recommend you **not** put the layout file in the *Views/Shared* folder. *Views/Shared* is an MVC views pattern. Razor Pages are meant to rely on folder hierarchy, not path conventions.

View search from a Razor Page includes the *Pages* folder. The layouts, templates, and partials used with MVC controllers and conventional Razor views *just work*.

Add a *Pages/_ViewImports.cshtml* file:

[!code-cshtml[](index/sample/RazorPagesContacts2/Pages/_ViewImports.cshtml)]

`@namespace` is explained later in the tutorial. The `@addTagHelper` directive brings in the [built-in Tag Helpers](xref:mvc/views/tag-helpers/builtin-th/Index) to all the pages in the *Pages* folder.

<a name="namespace"></a>

The `@namespace` directive set on a page:

[!code-cshtml[](index/sample/RazorPagesIntro/Pages/Customers/Namespace2.cshtml?highlight=2)]

The `@namespace` directive sets the namespace for the page. The `@model` directive doesn't need to include the namespace.

When the `@namespace` directive is contained in *_ViewImports.cshtml*, the specified namespace supplies the prefix for the generated namespace in the Page that imports the `@namespace` directive. The rest of the generated namespace (the suffix portion) is the dot-separated relative path between the folder containing *_ViewImports.cshtml* and the folder containing the page.

For example, the `PageModel` class *Pages/Customers/Edit.cshtml.cs* explicitly sets the namespace:

[!code-cs[](index/sample/RazorPagesContacts2/Pages/Customers/Edit.cshtml.cs?name=snippet_namespace)]

The *Pages/_ViewImports.cshtml* file sets the following namespace:

[!code-cshtml[](index/sample/RazorPagesContacts2/Pages/_ViewImports.cshtml?highlight=1)]

The generated namespace for the *Pages/Customers/Edit.cshtml* Razor Page is the same as the `PageModel` class.

`@namespace` *also works with conventional Razor views.*

Consider the *Pages/Create.cshtml* view file:

[!code-cshtml[](index/3.0sample/RazorPagesContacts/Pages/Customers/Create3.cshtml?highlight=2-3)]

The updated *Pages/Create.cshtml* view file with *_ViewImports.cshtml* and the preceding layout file:

[!code-cshtml[](index/3.0sample/RazorPagesContacts/Pages/Customers/Create4.cshtml?highlight=2)]

In the preceding code, the *_ViewImports.cshtml* imported the namespace and Tag Helpers. The layout file imported the JavaScript files.

The [Razor Pages starter project](#rpvs17) contains the *Pages/_ValidationScriptsPartial.cshtml*, which hooks up client-side validation.

For more information on partial views, see <xref:mvc/views/partial>.

<a name="url_gen"></a>

## URL generation for Pages

The `Create` page, shown previously, uses `RedirectToPage`:

[!code-cs[](index/3.0sample/RazorPagesContacts/Pages/Customers/Create.cshtml.cs?name=snippet_PageModel&highlight=28)]

The app has the following file/folder structure:

* */Pages*

  * *Index.cshtml*
  * *Privacy.cshtml*
  * */Customers*

    * *Create.cshtml*
    * *Edit.cshtml*
    * *Index.cshtml*

The *Pages/Customers/Create.cshtml* and *Pages/Customers/Edit.cshtml* pages redirect to *Pages/Customers/Index.cshtml* after success. The string `./Index` is a relative page name used to access the preceding page. It is used to generate URLs to the *Pages/Customers/Index.cshtml* page. For example:

* `Url.Page("./Index", ...)`
* `<a asp-page="./Index">Customers Index Page</a>`
* `RedirectToPage("./Index")`

The absolute page name `/Index` is used to generate URLs to the *Pages/Index.cshtml* page. For example:

* `Url.Page("/Index", ...)`
* `<a asp-page="/Index">Home Index Page</a>`
* `RedirectToPage("/Index")`

The page name is the path to the page from the root */Pages* folder including a leading `/` (for example, `/Index`). The preceding URL generation samples offer enhanced options and functional capabilities over hard-coding a URL. URL generation uses [routing](xref:mvc/controllers/routing) and can generate and encode parameters according to how the route is defined in the destination path.

URL generation for pages supports relative names. The following table shows which Index page is selected using different `RedirectToPage` parameters in *Pages/Customers/Create.cshtml*.

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

ASP.NET Core exposes the <xref:Microsoft.AspNetCore.Mvc.Controller.TempData>. This property stores data until it's read. The <xref:Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionary.Keep*> and <xref:Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionary.Peek*> methods can be used to examine the data without deletion. `TempData` is useful for redirection, when data is needed for more than a single request.

The following code sets the value of `Message` using `TempData`:

[!code-cs[](index/sample/RazorPagesContacts2/Pages/Customers/CreateDot.cshtml.cs?highlight=10-11,25&name=snippet_Temp)]

The following markup in the *Pages/Customers/Index.cshtml* file displays the value of `Message` using `TempData`.

```cshtml
<h3>Msg: @Model.Message</h3>
```

The *Pages/Customers/Index.cshtml.cs* page model applies the `[TempData]` attribute to the `Message` property.

```csharp
[TempData]
public string Message { get; set; }
```

For more information, see [TempData](xref:fundamentals/app-state#tempdata).

<a name="mhpp"></a>

## Multiple handlers per page

The following page generates markup for two handlers using the `asp-page-handler` Tag Helper:

[!code-cshtml[](index/sample/RazorPagesContacts2/Pages/Customers/CreateFATH.cshtml?highlight=12-13)]

The form in the preceding example has two submit buttons, each using the `FormActionTagHelper` to submit to a different URL. The `asp-page-handler` attribute is a companion to `asp-page`. `asp-page-handler` generates URLs that submit to each of the handler methods defined by a page. `asp-page` isn't specified because the sample is linking to the current page.

The page model:

[!code-cs[](index/sample/RazorPagesContacts2/Pages/Customers/CreateFATH.cshtml.cs?highlight=20,32)]

The preceding code uses *named handler methods*. Named handler methods are created by taking the text in the name after `On<HTTP Verb>` and before `Async` (if present). In the preceding example, the page methods are OnPost**JoinList**Async and OnPost**JoinListUC**Async. With *OnPost* and *Async* removed, the handler names are `JoinList` and `JoinListUC`.

[!code-cshtml[](index/sample/RazorPagesContacts2/Pages/Customers/CreateFATH.cshtml?range=12-13)]

Using the preceding code, the URL path that submits to `OnPostJoinListAsync` is `https://localhost:5001/Customers/CreateFATH?handler=JoinList`. The URL path that submits to `OnPostJoinListUCAsync` is `https://localhost:5001/Customers/CreateFATH?handler=JoinListUC`.

## Custom routes

Use the `@page` directive to:

* Specify a custom route to a page. For example, the route to the About page can be set to `/Some/Other/Path` with `@page "/Some/Other/Path"`.
* Append segments to a page's default route. For example, an "item" segment can be added to a page's default route with `@page "item"`.
* Append parameters to a page's default route. For example, an ID parameter, `id`, can be required for a page with `@page "{id}"`.

A root-relative path designated by a tilde (`~`) at the beginning of the path is supported. For example, `@page "~/Some/Other/Path"` is the same as `@page "/Some/Other/Path"`.

If you don't like the query string `?handler=JoinList` in the URL, change the route to put the handler name in the path portion of the URL. The route can be customized by adding a route template enclosed in double quotes after the `@page` directive.

[!code-cshtml[](index/sample/RazorPagesContacts2/Pages/Customers/CreateRoute.cshtml?highlight=1)]

Using the preceding code, the URL path that submits to `OnPostJoinListAsync` is `https://localhost:5001/Customers/CreateFATH/JoinList`. The URL path that submits to `OnPostJoinListUCAsync` is `https://localhost:5001/Customers/CreateFATH/JoinListUC`.

The `?` following `handler` means the route parameter is optional.

## Advanced configuration and settings

The configuration and settings in following sections is not required by most apps.

To configure advanced options, use the extension method <xref:Microsoft.Extensions.DependencyInjection.MvcRazorPagesMvcBuilderExtensions.AddRazorPagesOptions*>:

[!code-cs[](index/3.0sample/RazorPagesContacts/StartupRPoptions.cs?name=snippet)]

Use the <xref:Microsoft.AspNetCore.Mvc.RazorPages.RazorPagesOptions> to set the root directory for pages, or add application model conventions for pages. For more information on conventions, see [Razor Pages authorization conventions](xref:security/authorization/razor-pages-authorization).

To precompile views, see [Razor view compilation](xref:mvc/views/view-compilation).

### Specify that Razor Pages are at the content root

By default, Razor Pages are rooted in the */Pages* directory. Add <xref:Microsoft.Extensions.DependencyInjection.MvcRazorPagesMvcBuilderExtensions.WithRazorPagesAtContentRoot*> to specify that your Razor Pages are at the [content root](xref:fundamentals/index#content-root) (<xref:Microsoft.AspNetCore.Hosting.IHostingEnvironment.ContentRootPath>) of the app:

[!code-cs[](index/3.0sample/RazorPagesContacts/StartupWithRazorPagesAtContentRoot.cs?name=snippet)]

### Specify that Razor Pages are at a custom root directory

Add <xref:Microsoft.Extensions.DependencyInjection.MvcRazorPagesMvcCoreBuilderExtensions.WithRazorPagesRoot*> to specify that Razor Pages are at a custom root directory in the app (provide a relative path):

[!code-cs[](index/3.0sample/RazorPagesContacts/StartupWithRazorPagesRoot.cs?name=snippet)]

## Additional resources

* See [Get started with Razor Pages](xref:tutorials/razor-pages/razor-pages-start), which builds on this introduction
* [Download or view sample code](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/razor-pages/index/3.0sample)
* <xref:index>
* <xref:mvc/views/razor>
* <xref:mvc/controllers/areas>
* <xref:tutorials/razor-pages/razor-pages-start>
* <xref:security/authorization/razor-pages-authorization>
* <xref:razor-pages/razor-pages-conventions>
* <xref:test/razor-pages-tests>
* <xref:mvc/views/partial>
* <xref:blazor/integrate-components>

::: moniker-end

::: moniker range="< aspnetcore-3.0"

By [Rick Anderson](https://twitter.com/RickAndMSFT) and [Ryan Nowak](https://github.com/rynowak)

Razor Pages is a new aspect of ASP.NET Core MVC that makes coding page-focused scenarios easier and more productive.

If you're looking for a tutorial that uses the Model-View-Controller approach, see [Get started with ASP.NET Core MVC](xref:tutorials/first-mvc-app/start-mvc).

This document provides an introduction to Razor Pages. It's not a step by step tutorial. If you find some of the sections too advanced, see [Get started with Razor Pages](xref:tutorials/razor-pages/razor-pages-start). For an overview of ASP.NET Core, see the [Introduction to ASP.NET Core](xref:index).

## Prerequisites

# [Visual Studio](#tab/visual-studio)

[!INCLUDE[](~/includes/net-core-prereqs-vs2019-2.2.md)]

# [Visual Studio Code](#tab/visual-studio-code)

[!INCLUDE[](~/includes/net-core-prereqs-vsc-2.2.md)]

# [Visual Studio for Mac](#tab/visual-studio-mac)

[!INCLUDE[](~/includes/net-core-prereqs-mac-2.2.md)]

---

<a name="rpvs17"></a>

## Create a Razor Pages project

# [Visual Studio](#tab/visual-studio)

See [Get started with Razor Pages](xref:tutorials/razor-pages/razor-pages-start) for detailed instructions on how to create a Razor Pages project.

# [Visual Studio for Mac](#tab/visual-studio-mac)

Run `dotnet new webapp` from the command line.

Open the generated *.csproj* file from Visual Studio for Mac.

# [Visual Studio Code](#tab/visual-studio-code)

Run `dotnet new webapp` from the command line.

---

## Razor Pages

Razor Pages is enabled in *Startup.cs*:

[!code-cs[](index/sample/RazorPagesIntro/Startup.cs?name=snippet_Startup)]

Consider a basic page:
<a name="OnGet"></a>

[!code-cshtml[](index/sample/RazorPagesIntro/Pages/Index.cshtml)]

The preceding code looks a lot like a [Razor view file](xref:tutorials/first-mvc-app/adding-view) used in an ASP.NET Core app with controllers and views. What makes it different is the `@page` directive. `@page` makes the file into an MVC action - which means that it handles requests directly, without going through a controller. `@page` must be the first Razor directive on a page. `@page` affects the behavior of other Razor constructs.

A similar page, using a `PageModel` class, is shown in the following two files. The *Pages/Index2.cshtml* file:

[!code-cshtml[](index/sample/RazorPagesIntro/Pages/Index2.cshtml)]

The *Pages/Index2.cshtml.cs* page model:

[!code-cs[](index/sample/RazorPagesIntro/Pages/Index2.cshtml.cs)]

By convention, the `PageModel` class file has the same name as the Razor Page file with *.cs* appended. For example, the previous Razor Page is *Pages/Index2.cshtml*. The file containing the `PageModel` class is named *Pages/Index2.cshtml.cs*.

The associations of URL paths to pages are determined by the page's location in the file system. The following table shows a Razor Page path and the matching URL:

| File name and path               | matching URL |
| ----------------- | ------------ |
| */Pages/Index.cshtml* | `/` or `/Index` |
| */Pages/Contact.cshtml* | `/Contact` |
| */Pages/Store/Contact.cshtml* | `/Store/Contact` |
| */Pages/Store/Index.cshtml* | `/Store` or `/Store/Index` |

Notes:

* The runtime looks for Razor Pages files in the *Pages* folder by default.
* `Index` is the default page when a URL doesn't include a page.

## Write a basic form

Razor Pages is designed to make common patterns used with web browsers easy to implement when building an app. [Model binding](xref:mvc/models/model-binding), [Tag Helpers](xref:mvc/views/tag-helpers/intro), and HTML helpers all *just work* with the properties defined in a Razor Page class. Consider a page that implements a basic "contact us" form for the `Contact` model:

For the samples in this document, the `DbContext` is initialized in the [Startup.cs](https://github.com/dotnet/AspNetCore.Docs/blob/master/aspnetcore/razor-pages/index/sample/RazorPagesContacts/Startup.cs#L15-L16) file.

[!code-cs[](index/sample/RazorPagesContacts/Startup.cs?highlight=15-16)]

The data model:

[!code-cs[](index/sample/RazorPagesContacts/Data/Customer.cs)]

The db context:

[!code-cs[](index/sample/RazorPagesContacts/Data/AppDbContext.cs)]

The *Pages/Create.cshtml* view file:

[!code-cshtml[](index/sample/RazorPagesContacts/Pages/Create.cshtml)]

The *Pages/Create.cshtml.cs* page model:

[!code-cs[](index/sample/RazorPagesContacts/Pages/Create.cshtml.cs?name=snippet_ALL)]

By convention, the `PageModel` class is called `<PageName>Model` and is in the same namespace as the page.

The `PageModel` class allows separation of the logic of a page from its presentation. It defines page handlers for requests sent to the page and the data used to render the page. This separation allows:

* Managing of page dependencies through [dependency injection](xref:fundamentals/dependency-injection).
* [Unit testing](xref:test/razor-pages-tests) the pages.

The page has an `OnPostAsync` *handler method*, which runs on `POST` requests (when a user posts the form). You can add handler methods for any HTTP verb. The most common handlers are:

* `OnGet` to initialize state needed for the page. [OnGet](#OnGet) sample.
* `OnPost` to handle form submissions.

The `Async` naming suffix is optional but is often used by convention for asynchronous functions. The preceding code is typical for Razor Pages.

If you're familiar with ASP.NET apps using controllers and views:

* The `OnPostAsync` code in the preceding example looks similar to typical controller code.
* Most of the MVC primitives like [model binding](xref:mvc/models/model-binding), [validation](xref:mvc/models/validation), [Validation](xref:mvc/models/validation),  and action results are shared.

The previous `OnPostAsync` method:

[!code-cs[](index/sample/RazorPagesContacts/Pages/Create.cshtml.cs?name=snippet_OnPostAsync)]

The basic flow of `OnPostAsync`:

Check for validation errors.

* If there are no errors, save the data and redirect.
* If there are errors, show the page again with validation messages. Client-side validation is identical to traditional ASP.NET Core MVC applications. In many cases, validation errors would be detected on the client, and never submitted to the server.

When the data is entered successfully, the `OnPostAsync` handler method calls the `RedirectToPage` helper method to return an instance of `RedirectToPageResult`. `RedirectToPage` is a new action result, similar to `RedirectToAction` or `RedirectToRoute`, but customized for pages. In the preceding sample, it redirects to the root Index page (`/Index`). `RedirectToPage` is detailed in the [URL generation for Pages](#url_gen) section.

When the submitted form has validation errors (that are passed to the server), the`OnPostAsync` handler method calls the `Page` helper method. `Page` returns an instance of `PageResult`. Returning `Page` is similar to how actions in controllers return `View`. `PageResult` is the default return type for a handler method. A handler method that returns `void` renders the page.

The `Customer` property uses `[BindProperty]` attribute to opt in to model binding.

[!code-cs[](index/sample/RazorPagesContacts/Pages/Create.cshtml.cs?name=snippet_PageModel&highlight=10-11)]

Razor Pages, by default, bind properties only with non-`GET` verbs. Binding to properties can reduce the amount of code you have to write. Binding reduces code by using the same property to render form fields (`<input asp-for="Customer.Name">`) and accept the input.

[!INCLUDE[](~/includes/bind-get.md)]

The home page (*Index.cshtml*):

[!code-cshtml[](index/sample/RazorPagesContacts/Pages/Index.cshtml)]

The associated `PageModel` class (*Index.cshtml.cs*):

[!code-cs[](index/sample/RazorPagesContacts/Pages/Index.cshtml.cs)]

The *Index.cshtml* file contains the following markup to create an edit link for each contact:

[!code-cshtml[](index/sample/RazorPagesContacts/Pages/Index.cshtml?range=21)]

The `<a asp-page="./Edit" asp-route-id="@contact.Id">Edit</a>` [Anchor Tag Helper](xref:mvc/views/tag-helpers/builtin-th/anchor-tag-helper) used the `asp-route-{value}` attribute to generate a link to the Edit page. The link contains route data with the contact ID. For example, `https://localhost:5001/Edit/1`. [Tag Helpers](xref:mvc/views/tag-helpers/intro) enable server-side code to participate in creating and rendering HTML elements in Razor files. Tag Helpers are enabled by `@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers`

The *Pages/Edit.cshtml* file:

[!code-cshtml[](index/sample/RazorPagesContacts/Pages/Edit.cshtml?highlight=1)]

The first line contains the `@page "{id:int}"` directive. The routing constraint`"{id:int}"` tells the page to accept requests to the page that contain `int` route data. If a request to the page doesn't contain route data that can be converted to an `int`, the runtime returns an HTTP 404 (not found) error. To make the ID optional, append `?` to the route constraint:

 ```cshtml
@page "{id:int?}"
```

The *Pages/Edit.cshtml.cs* file:

[!code-cs[](index/sample/RazorPagesContacts/Pages/Edit.cshtml.cs)]

The *Index.cshtml* file also contains markup to create a delete button for each customer contact:

[!code-cshtml[](index/sample/RazorPagesContacts/Pages/Index.cshtml?range=22-23)]

When the delete button is rendered in HTML, its `formaction` includes parameters for:

* The customer contact ID specified by the `asp-route-id` attribute.
* The `handler` specified by the `asp-page-handler` attribute.

Here is an example of a rendered delete button with a customer contact ID of `1`:

```html
<button type="submit" formaction="/?id=1&amp;handler=delete">delete</button>
```

When the button is selected, a form `POST` request is sent to the server. By convention, the name of the handler method is selected based on the value of the `handler` parameter according to the scheme `OnPost[handler]Async`.

Because the `handler` is `delete` in this example, the `OnPostDeleteAsync` handler method is used to process the `POST` request. If the `asp-page-handler` is set to a different value, such as `remove`, a handler method with the name `OnPostRemoveAsync` is selected. The following code shows the `OnPostDeleteAsync` handler:

[!code-cs[](index/sample/RazorPagesContacts/Pages/Index.cshtml.cs?range=26-37)]

The `OnPostDeleteAsync` method:

* Accepts the `id` from the query string. If the *Index.cshtml* page directive contained routing constraint `"{id:int?}"`, `id` would come from route data. The route data for `id` is specified in the URI such as `https://localhost:5001/Customers/2`.
* Queries the database for the customer contact with `FindAsync`.
* If the customer contact is found, they're removed from the list of customer contacts. The database is updated.
* Calls `RedirectToPage` to redirect to the root Index page (`/Index`).

## Mark page properties as required

Properties on a `PageModel` can be marked with the [Required](/dotnet/api/system.componentmodel.dataannotations.requiredattribute) attribute:

[!code-cs[](index/sample/Create.cshtml.cs?highlight=3,15-16)]

For more information, see [Model validation](xref:mvc/models/validation).

## Handle HEAD requests with an OnGet handler fallback

`HEAD` requests allow you to retrieve the headers for a specific resource. Unlike `GET` requests, `HEAD` requests don't return a response body.

Ordinarily, an `OnHead` handler is created and called for `HEAD` requests: 

```csharp
public void OnHead()
{
    HttpContext.Response.Headers.Add("HandledBy", "Handled by OnHead!");
}
```

In ASP.NET Core 2.1 or later, Razor Pages falls back to calling the `OnGet` handler if no `OnHead` handler is defined. This behavior is enabled by the call to [SetCompatibilityVersion](xref:mvc/compatibility-version) in `Startup.ConfigureServices`:

```csharp
services.AddMvc()
    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
```

The default templates generate the `SetCompatibilityVersion` call in ASP.NET Core 2.1 and 2.2. `SetCompatibilityVersion` effectively sets the Razor Pages option `AllowMappingHeadRequestsToGetHandler` to `true`.

Rather than opting in to all behaviors with `SetCompatibilityVersion`, you can explicitly opt in to *specific* behaviors. The following code opts in to allowing `HEAD` requests to be mapped to the `OnGet` handler:

```csharp
services.AddMvc()
    .AddRazorPagesOptions(options =>
    {
        options.AllowMappingHeadRequestsToGetHandler = true;
    });
```

<a name="xsrf"></a>

## XSRF/CSRF and Razor Pages

You don't have to write any code for [antiforgery validation](xref:security/anti-request-forgery). Antiforgery token generation and validation are automatically included in Razor Pages.

<a name="layout"></a>

## Using Layouts, partials, templates, and Tag Helpers with Razor Pages

Pages work with all the capabilities of the Razor view engine. Layouts, partials, templates, Tag Helpers, *_ViewStart.cshtml*, *_ViewImports.cshtml* work in the same way they do for conventional Razor views.

Let's declutter this page by taking advantage of some of those capabilities.

Add a [layout page](xref:mvc/views/layout) to *Pages/Shared/_Layout.cshtml*:

[!code-cshtml[](index/sample/RazorPagesContacts2/Pages/_LayoutSimple.cshtml)]

The [Layout](xref:mvc/views/layout):

* Controls the layout of each page (unless the page opts out of layout).
* Imports HTML structures such as JavaScript and stylesheets.

See [layout page](xref:mvc/views/layout) for more information.

The [Layout](xref:mvc/views/layout#specifying-a-layout) property is set in *Pages/_ViewStart.cshtml*:

[!code-cshtml[](index/sample/RazorPagesContacts2/Pages/_ViewStart.cshtml)]

The layout is in the *Pages/Shared* folder. Pages look for other views (layouts, templates, partials) hierarchically, starting in the same folder as the current page. A layout in the *Pages/Shared* folder can be used from any Razor page under the *Pages* folder.

The layout file should go in the *Pages/Shared* folder.

We recommend you **not** put the layout file in the *Views/Shared* folder. *Views/Shared* is an MVC views pattern. Razor Pages are meant to rely on folder hierarchy, not path conventions.

View search from a Razor Page includes the *Pages* folder. The layouts, templates, and partials you're using with MVC controllers and conventional Razor views *just work*.

Add a *Pages/_ViewImports.cshtml* file:

[!code-cshtml[](index/sample/RazorPagesContacts2/Pages/_ViewImports.cshtml)]

`@namespace` is explained later in the tutorial. The `@addTagHelper` directive brings in the [built-in Tag Helpers](xref:mvc/views/tag-helpers/builtin-th/Index) to all the pages in the *Pages* folder.

<a name="namespace"></a>

When the `@namespace` directive is used explicitly on a page:

[!code-cshtml[](index/sample/RazorPagesIntro/Pages/Customers/Namespace2.cshtml?highlight=2)]

The directive sets the namespace for the page. The `@model` directive doesn't need to include the namespace.

When the `@namespace` directive is contained in *_ViewImports.cshtml*, the specified namespace supplies the prefix for the generated namespace in the Page that imports the `@namespace` directive. The rest of the generated namespace (the suffix portion) is the dot-separated relative path between the folder containing *_ViewImports.cshtml* and the folder containing the page.

For example, the `PageModel` class *Pages/Customers/Edit.cshtml.cs* explicitly sets the namespace:

[!code-cs[](index/sample/RazorPagesContacts2/Pages/Customers/Edit.cshtml.cs?name=snippet_namespace)]

The *Pages/_ViewImports.cshtml* file sets the following namespace:

[!code-cshtml[](index/sample/RazorPagesContacts2/Pages/_ViewImports.cshtml?highlight=1)]

The generated namespace for the *Pages/Customers/Edit.cshtml* Razor Page is the same as the `PageModel` class.

`@namespace` *also works with conventional Razor views.*

The original *Pages/Create.cshtml* view file:

[!code-cshtml[](index/sample/RazorPagesContacts/Pages/Create.cshtml?highlight=2)]

The updated *Pages/Create.cshtml* view file:

[!code-cshtml[](index/sample/RazorPagesContacts2/Pages/Customers/Create.cshtml?highlight=2)]

The [Razor Pages starter project](#rpvs17) contains the *Pages/_ValidationScriptsPartial.cshtml*, which hooks up client-side validation.

For more information on partial views, see <xref:mvc/views/partial>.

<a name="url_gen"></a>

## URL generation for Pages

The `Create` page, shown previously, uses `RedirectToPage`:

[!code-cs[](index/sample/RazorPagesContacts/Pages/Create.cshtml.cs?name=snippet_OnPostAsync&highlight=10)]

The app has the following file/folder structure:

* */Pages*

  * *Index.cshtml*
  * */Customers*

    * *Create.cshtml*
    * *Edit.cshtml*
    * *Index.cshtml*

The *Pages/Customers/Create.cshtml* and *Pages/Customers/Edit.cshtml* pages redirect to *Pages/Index.cshtml* after success. The string `/Index` is part of the URI to access the preceding page. The string `/Index` can be used to generate URIs to the *Pages/Index.cshtml* page. For example:

* `Url.Page("/Index", ...)`
* `<a asp-page="/Index">My Index Page</a>`
* `RedirectToPage("/Index")`

The page name is the path to the page from the root */Pages* folder including a leading `/` (for example, `/Index`). The preceding URL generation samples offer enhanced options and functional capabilities over hardcoding a URL. URL generation uses [routing](xref:mvc/controllers/routing) and can generate and encode parameters according to how the route is defined in the destination path.

URL generation for pages supports relative names. The following table shows which Index page is selected with different `RedirectToPage` parameters from *Pages/Customers/Create.cshtml*:

| RedirectToPage(x)| Page |
| ----------------- | ------------ |
| RedirectToPage("/Index") | *Pages/Index* |
| RedirectToPage("./Index"); | *Pages/Customers/Index* |
| RedirectToPage("../Index") | *Pages/Index* |
| RedirectToPage("Index")  | *Pages/Customers/Index* |

`RedirectToPage("Index")`, `RedirectToPage("./Index")`, and `RedirectToPage("../Index")`  are *relative names*. The `RedirectToPage` parameter is *combined* with the path of the current page to compute the name of the destination page.  <!-- Review: Original had The provided string is combined with the page name of the current page to compute the name of the destination page.  page name, not page path -->

Relative name linking is useful when building sites with a complex structure. If you use relative names to link between pages in a folder, you can rename that folder. All the links still work (because they didn't include the folder name).

To redirect to a page in a different [Area](xref:mvc/controllers/areas), specify the area:

```csharp
RedirectToPage("/Index", new { area = "Services" });
```

For more information, see <xref:mvc/controllers/areas>.

## ViewData attribute

Data can be passed to a page with [ViewDataAttribute](/dotnet/api/microsoft.aspnetcore.mvc.viewdataattribute). Properties on controllers or Razor Page models with the `[ViewData]` attribute have their values stored and loaded from the [ViewDataDictionary](/dotnet/api/microsoft.aspnetcore.mvc.viewfeatures.viewdatadictionary).

In the following example, the `AboutModel` contains a `Title` property marked with `[ViewData]`. The `Title` property is set to the title of the About page:

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

ASP.NET Core exposes the [TempData](/dotnet/api/microsoft.aspnetcore.mvc.controller.tempdata?view=aspnetcore-2.0#Microsoft_AspNetCore_Mvc_Controller_TempData) property on a [controller](/dotnet/api/microsoft.aspnetcore.mvc.controller). This property stores data until it's read. The `Keep` and `Peek` methods can be used to examine the data without deletion. `TempData` is  useful for redirection, when data is needed for more than a single request.

The following code sets the value of `Message` using `TempData`:

[!code-cs[](index/sample/RazorPagesContacts2/Pages/Customers/CreateDot.cshtml.cs?highlight=10-11,25&name=snippet_Temp)]

The following markup in the *Pages/Customers/Index.cshtml* file displays the value of `Message` using `TempData`.

```cshtml
<h3>Msg: @Model.Message</h3>
```

The *Pages/Customers/Index.cshtml.cs* page model applies the `[TempData]` attribute to the `Message` property.

```csharp
[TempData]
public string Message { get; set; }
```

For more information, see [TempData](xref:fundamentals/app-state#tempdata) .

<a name="mhpp"></a>

## Multiple handlers per page

The following page generates markup for two handlers using the `asp-page-handler` Tag Helper:

[!code-cshtml[](index/sample/RazorPagesContacts2/Pages/Customers/CreateFATH.cshtml?highlight=12-13)]

<!-- Review: the FormActionTagHelper applies to all <form /> elements on a Razor page, even when there's no `asp-` attribute   -->

The form in the preceding example has two submit buttons, each using the `FormActionTagHelper` to submit to a different URL. The `asp-page-handler` attribute is a companion to `asp-page`. `asp-page-handler` generates URLs that submit to each of the handler methods defined by a page. `asp-page` isn't specified because the sample is linking to the current page.

The page model:

[!code-cs[](index/sample/RazorPagesContacts2/Pages/Customers/CreateFATH.cshtml.cs?highlight=20,32)]

The preceding code uses *named handler methods*. Named handler methods are created by taking the text in the name after `On<HTTP Verb>` and before `Async` (if present). In the preceding example, the page methods are OnPost**JoinList**Async and OnPost**JoinListUC**Async. With *OnPost* and *Async* removed, the handler names are `JoinList` and `JoinListUC`.

[!code-cshtml[](index/sample/RazorPagesContacts2/Pages/Customers/CreateFATH.cshtml?range=12-13)]

Using the preceding code, the URL path that submits to `OnPostJoinListAsync` is `https://localhost:5001/Customers/CreateFATH?handler=JoinList`. The URL path that submits to `OnPostJoinListUCAsync` is `https://localhost:5001/Customers/CreateFATH?handler=JoinListUC`.

## Custom routes

Use the `@page` directive to:

* Specify a custom route to a page. For example, the route to the About page can be set to `/Some/Other/Path` with `@page "/Some/Other/Path"`.
* Append segments to a page's default route. For example, an "item" segment can be added to a page's default route with `@page "item"`.
* Append parameters to a page's default route. For example, an ID parameter, `id`, can be required for a page with `@page "{id}"`.

A root-relative path designated by a tilde (`~`) at the beginning of the path is supported. For example, `@page "~/Some/Other/Path"` is the same as `@page "/Some/Other/Path"`.

If you don't like the query string `?handler=JoinList` in the URL, change the route to put the handler name in the path portion of the URL. The route can be customized by adding a route template enclosed in double quotes after the `@page` directive.

[!code-cshtml[](index/sample/RazorPagesContacts2/Pages/Customers/CreateRoute.cshtml?highlight=1)]

Using the preceding code, the URL path that submits to `OnPostJoinListAsync` is `https://localhost:5001/Customers/CreateFATH/JoinList`. The URL path that submits to `OnPostJoinListUCAsync` is `https://localhost:5001/Customers/CreateFATH/JoinListUC`.

The `?` following `handler` means the route parameter is optional.

## Configuration and settings

To configure advanced options, use the extension method `AddRazorPagesOptions` on the MVC builder:

[!code-cs[](index/sample/RazorPagesContacts/StartupAdvanced.cs?name=snippet_1)]

Currently you can use the `RazorPagesOptions` to set the root directory for pages, or add application model conventions for pages. We'll enable more extensibility this way in the future.

To precompile views, see [Razor view compilation](xref:mvc/views/view-compilation) .

[Download or view sample code](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/razor-pages/index/sample).

See [Get started with Razor Pages](xref:tutorials/razor-pages/razor-pages-start), which builds on this introduction.

### Specify that Razor Pages are at the content root

By default, Razor Pages are rooted in the */Pages* directory. Add [WithRazorPagesAtContentRoot](/dotnet/api/microsoft.extensions.dependencyinjection.mvcrazorpagesmvcbuilderextensions.withrazorpagesatcontentroot) to [AddMvc](/dotnet/api/microsoft.extensions.dependencyinjection.mvcservicecollectionextensions.addmvc#Microsoft_Extensions_DependencyInjection_MvcServiceCollectionExtensions_AddMvc_Microsoft_Extensions_DependencyInjection_IServiceCollection_) to specify that your Razor Pages are at the [content root](xref:fundamentals/index#content-root) ([ContentRootPath](/dotnet/api/microsoft.aspnetcore.hosting.ihostingenvironment.contentrootpath)) of the app:

```csharp
services.AddMvc()
    .AddRazorPagesOptions(options =>
    {
        ...
    })
    .WithRazorPagesAtContentRoot();
```

### Specify that Razor Pages are at a custom root directory

Add [WithRazorPagesRoot](/dotnet/api/microsoft.extensions.dependencyinjection.mvcrazorpagesmvccorebuilderextensions.withrazorpagesroot) to [AddMvc](/dotnet/api/microsoft.extensions.dependencyinjection.mvcservicecollectionextensions.addmvc#Microsoft_Extensions_DependencyInjection_MvcServiceCollectionExtensions_AddMvc_Microsoft_Extensions_DependencyInjection_IServiceCollection_) to specify that your Razor Pages are at a custom root directory in the app (provide a relative path):

```csharp
services.AddMvc()
    .AddRazorPagesOptions(options =>
    {
        ...
    })
    .WithRazorPagesRoot("/path/to/razor/pages");
```

## Additional resources

* <xref:index>
* <xref:mvc/views/razor>
* <xref:mvc/controllers/areas>
* <xref:tutorials/razor-pages/razor-pages-start>
* <xref:security/authorization/razor-pages-authorization>
* <xref:razor-pages/razor-pages-conventions>
* <xref:test/razor-pages-tests>
* <xref:mvc/views/partial>

::: moniker-end
