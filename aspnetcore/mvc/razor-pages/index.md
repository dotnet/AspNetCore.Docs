---
title: Introduction to Razor Pages in ASP.NET Core
author: Rick-Anderson
description: Overview of Razor Pages in ASP.NET Core
keywords: ASP.NET Core, Razor Pages
ms.author: riande
manager: wpickett
ms.date: 08/15/2017
ms.topic: get-started-article
ms.technology: aspnet
ms.prod: asp.net-core
uid: mvc/razor-pages/index
---
# Introduction to Razor Pages in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT) and [Ryan Nowak](https://github.com/rynowak)

Razor Pages is a new feature of ASP.NET Core MVC that makes coding page-focused scenarios easier and more productive.

If you're looking for a tutorial that uses the Model-View-Controller approach, see [Getting started with ASP.NET Core MVC](xref:tutorials/first-mvc-app/start-mvc).

<a name="prerequisites"></a>

## ASP.NET Core 2.0 prerequisites

Install [.NET Core](https://www.microsoft.com/net/core) 2.0.0 or later.

If you're using Visual Studio, install [Visual Studio](https://www.visualstudio.com/vs/) 15.3 or later with the following workloads:

* **ASP.NET and web development**
* **.NET Core cross-platform development**

<a name="rpvs17"></a>

## Creating a Razor Pages project

# [Visual Studio](#tab/visual-studio) 

See [Getting started with Razor Pages](xref:tutorials/razor-pages/razor-pages-start) for detailed instructions on how to create a Razor Pages project using Visual Studio.

#	[Visual Studio for Mac](#tab/visual-studio-mac)

Run `dotnet new razor` from the command line.

Open the generated *.csproj* file from Visual Studio for Mac.

# [Visual Studio Code](#tab/visual-studio-code) 

Run `dotnet new razor` from the command line.

#	[.NET Core CLI](#tab/netcore-cli) 

Run `dotnet new razor` from the command line.

---

## Razor Pages

Razor Pages is enabled in *Startup.cs*:

[!code-cs[main](index/sample/RazorPagesIntro/Startup.cs?name=Startup)]

Consider a basic page:
<a name="OnGet"></a>

[!code-cshtml[main](index/sample/RazorPagesIntro/Pages/Index.cshtml)]

The preceding code looks a lot like a Razor view file. What makes it different is the `@page` directive. `@page` makes the file into an MVC action - which means that it handles requests directly, without going through a controller. `@page` must be the first Razor directive on a page. `@page` affects the behavior of other Razor constructs. The [@functions](xref:mvc/views/razor#functions) directive enables function-level content.

A similar page, with the `PageModel` in a separate file, is shown in the following two files. The *Pages/Index2.cshtml* file:

[!code-cshtml[main](index/sample/RazorPagesIntro/Pages/Index2.cshtml)]

The *Pages/Index2.cshtml.cs* 'code-behind' file:

[!code-cs[main](index/sample/RazorPagesIntro/Pages/Index2.cshtml.cs)]

By convention, the `PageModel` class file has the same name as the Razor Page file with *.cs* appended. For example, the previous Razor Page is *Pages/Index2.cshtml*. The file containing the `PageModel` class is named *Pages/Index2.cshtml.cs*.

For simple pages, mixing the `PageModel` class with the Razor markup is fine. For more complex code, it's a best practice to keep the page model code separate.

The associations of URL paths to pages are determined by the page's location in the file system. The following table shows a Razor Page path and the matching URL:

| File name and path               | matching URL |
| ----------------- | ------------ |
| */Pages/Index.cshtml* | `/` or `/Index` |
| */Pages/Contact.cshtml* | `/Contact` |
| */Pages/Store/Contact.cshtml* | `/Store/Contact` |
| */Pages/Store/Index.cshtml* | `/Store` or `/Store/Index`  |

Notes:

* The runtime looks for Razor Pages files in the *Pages* folder by default.
* `Index` is the default page when a URL doesn't include a page.

## Writing a basic form

Razor Pages features are designed to make common patterns used with web browsers easy. [Model binding](xref:mvc/models/model-binding), [Tag Helpers](xref:mvc/views/tag-helpers/intro), and HTML helpers all *just work* with the properties defined in a Razor Page class. Consider a page that implements a basic "contact us" form for the `Contact` model:

For the samples in this document, the `DbContext` is initialized in the [Startup.cs](https://github.com/aspnet/Docs/blob/master/aspnetcore/mvc/razor-pages/index/sample/RazorPagesContacts/Startup.cs#L15-L16) file.

[!code-cs[main](index/sample/RazorPagesContacts/Startup.cs?highlight=15-16)]

The data model:

[!code-cs[main](index/sample/RazorPagesContacts/Data/Customer.cs)]

The *Pages/Create.cshtml* view file:

[!code-cshtml[main](index/sample/RazorPagesContacts/Pages/Create.cshtml)]

The *Pages/Create.cshtml.cs* code-behind file for the view:

[!code-cs[main](index/sample/RazorPagesContacts/Pages/Create.cshtml.cs?name=ALL)]

By convention, the `PageModel` class is called `<PageName>Model` and is in the same namespace as the page. Not much change is needed to convert from a page using `@functions` to define handlers and a page using a `PageModel` class.

Using a `PageModel` code-behind file supports unit testing, but requires you to write an explicit constructor and class. Pages without `PageModel` code-behind files support runtime compilation, which can be an advantage in development.  <!-- review: advantage because you can make changes and refresh the browser without explicitly compiling the app -->

The page has an `OnPostAsync` *handler method*, which runs on `POST` requests (when a user posts the form). You can add handler methods for any HTTP verb. The most common handlers are:

* `OnGet` to initialize state needed for the page. [OnGet](#OnGet) sample.
* `OnPost` to handle form submissions.

The `Async` naming suffix is optional but is often used by convention for asynchronous functions. The `OnPostAsync` code in the preceding example looks similar to what you would normally write in a controller. The preceding code is typical for Razor Pages. Most of the MVC primitives like [model binding](xref:mvc/models/model-binding), [validation](xref:mvc/models/validation), and action results are shared.  <!-- Review: Ryan, can we get a list of what is shared and what isn't? -->

The previous `OnPostAsync` method:

[!code-cs[main](index/sample/RazorPagesContacts/Pages/Create.cshtml.cs?name=OnPostAsync)]

The basic flow of `OnPostAsync`:

Check for validation errors.

*  If there are no errors, save the data and redirect.
*  If there are errors, show the page again with validation messages. Client-side validation is identical to traditional ASP.NET Core MVC applications. In many cases, validation errors would be detected on the client, and never submitted to the server.

When the data is entered successfully, the `OnPostAsync` handler method calls the `RedirectToPage` helper method to return an instance of `RedirectToPageResult`. `RedirectToPage` is a new action result, similar to `RedirectToAction` or `RedirectToRoute`, but customized for pages. In the preceding sample, it redirects to the root Index page (`/Index`). `RedirectToPage` is detailed in the [URL generation for Pages](#url_gen) section.

When the submitted form has validation errors (that are passed to the server), the`OnPostAsync` handler method calls the `Page` helper method. `Page` returns an instance of `PageResult`. Returning `Page` is similar to how actions in controllers return `View`. `PageResult` is the default <!-- Review  --> return type for a handler method. A handler method that returns `void` renders the page.

The `Customer` property uses `[BindProperty]` attribute to opt in to model binding.

[!code-cs[main](index/sample/RazorPagesContacts/Pages/Create.cshtml.cs?name=PageModel&highlight=10-11)]

Razor Pages, by default, bind properties only with non-GET verbs. Binding to properties can reduce the amount of code you have to write. Binding reduces code by using the same property to render form fields (`<input asp-for="Customer.Name" />`) and accept the input.

The following code shows the combined version of the create page:

[!code-cshtml[main](index/sample/RazorPagesContacts/Pages/CreateCombined.cshtml)]

Rather than using `@model`, we're taking advantage of a new feature for Pages. By default, the generated `Page`-derived class *is* the model. Using a *view model* with Razor views is a best practice. With Pages, you get a view model *automatically*.

The main change is replacing constructor injection with injected (`@inject`) properties. This page uses [@inject](xref:mvc/views/razor#inject) for [constructor dependency injection](xref:mvc/controllers/dependency-injection#constructor-injection). The `@inject` statement generates and initializes the `Db` property that is used in `OnPostAsync`. Injected (`@inject`) properties are set before handler methods run.


The home page (*Index.cshtml*):

[!code-cshtml[main](index/sample/RazorPagesContacts/Pages/Index.cshtml)]

The code behind *Index.cshtml.cs* file:

[!code-cs[main](index/sample/RazorPagesContacts/Pages/Index.cshtml.cs)]

The *Index.cshtml* file contains the following markup to create an edit link for each contact:

```html
<a asp-page="./Edit" asp-route-id="@contact.Id">edit</a>
```

The [Anchor Tag Helper](xref:mvc/views/tag-helpers/builtin-th/AnchorTagHelper)
used the [asp-route-{value}](xref:mvc/views/tag-helpers/builtin-th/AnchorTagHelper#route)
attribute to generate a link to the Edit page. The link contains route data with the contact ID. For example, `http://localhost:5000/Edit/1`.

The *Pages/Edit.cshtml* file:

[!code-cshtml[main](index/sample/RazorPagesContacts/Pages/Edit.cshtml?highlight=1)]

The first line contains the `@page "{id:int}"` directive. The routing constraint`"{id:int}"` tells the page to accept requests to the page that contain `int` route data. If a request to the page doesn't contain route data that can be converted to an `int`, the runtime returns an HTTP 404 (not found) error.

The *Pages/Edit.cshtml.cs* file:

[!code-cs[main](index/sample/RazorPagesContacts/Pages/Edit.cshtml.cs)]

<a name="xsrf"></a>

## XSRF/CSRF and Razor Pages

You don't have to write any code for [antiforgery validation](xref:security/anti-request-forgery). Antiforgery token generation and validation are automatically included in Razor Pages.

<a name="layout"></a>
## Using Layouts, partials, templates, and Tag Helpers with Razor Pages

Pages work with all the features of the Razor view engine. Layouts, partials, templates, Tag Helpers, *_ViewStart.cshtml*, *_ViewImports.cshtml* work in the same way they do for conventional Razor views.

Let's declutter this page by taking advantage of some of those features.

Add a [layout page](xref:mvc/views/layout) to *Pages/_Layout.cshtml*:

[!code-cshtml[main](index/sample/RazorPagesContacts2/Pages/_LayoutSimple.cshtml)]

The [Layout](xref:mvc/views/layout):

* Controls the layout of each page (unless the page opts out of layout).
* Imports HTML structures such as JavaScript and stylesheets.

See [layout page](xref:mvc/views/layout) for more information.

The [Layout](xref:mvc/views/layout#specifying-a-layout) property is set in *Pages/_ViewStart.cshtml*:

[!code-cshtml[main](index/sample/RazorPagesContacts2/Pages/_ViewStart.cshtml)]

Note: The layout is in the *Pages* folder. Pages look for other views (layouts, templates, partials) hierarchically, starting in the same folder as the current page. A layout in the *Pages* folder can be used from any Razor page under the *Pages* folder.

We recommend you **not** put the layout file in the *Views/Shared* folder. *Views/Shared* is an MVC views pattern. Razor Pages are meant to rely on folder hierarchy, not path conventions.

View search from a Razor Page includes the *Pages* folder. The layouts, templates, and partials you're using with MVC controllers and conventional Razor views *just work*.

Add a *Pages/_ViewImports.cshtml* file:

[!code-cshtml[main](index/sample/RazorPagesContacts2/Pages/_ViewImports.cshtml)]

`@namespace` is explained later in the tutorial. The `@addTagHelper` directive brings in the [built-in Tag Helpers](xref:mvc/views/tag-helpers/builtin-th/Index) to all the pages in the *Pages* folder.

<a name="namespace"></a>

When the `@namespace` directive is used explicitly on a page:

[!code-cshtml[main](index/sample/RazorPagesIntro/Pages/Customers/Namespace2.cshtml?highlight=2)]

The directive sets the namespace for the page. The `@model` directive doesn't need to include the namespace.

When the `@namespace` directive is contained in *_ViewImports.cshtml*, the specified namespace supplies the prefix for the generated namespace in the Page that imports the `@namespace` directive. The rest of the generated namespace (the suffix portion) is the dot-separated relative path between the folder containing *_ViewImports.cshtml* and the folder containing the page.

For example, the code behind file *Pages/Customers/Edit.cshtml.cs* explicitly sets the namespace:

[!code-cs[main](index/sample/RazorPagesContacts2/Pages/Customers/Edit.cshtml.cs?name=namespace)]

The *Pages/_ViewImports.cshtml* file sets the following namespace:

[!code-cshtml[main](index/sample/RazorPagesContacts2/Pages/_ViewImports.cshtml?highlight=1)]

The generated namespace for the *Pages/Customers/Edit.cshtml* Razor Page is the same as the code behind file. The `@namespace` directive was designed so the C# classes added to a project and pages-generated code *just work* without having to add an `@using` directive for the code behind file.

Note: `@namespace` also works with conventional Razor views.

The original *Pages/Create.cshtml* view file:

[!code-cshtml[main](index/sample/RazorPagesContacts/Pages/Create.cshtml?highlight=2)]

The updated page:

The *Pages/Create.cshtml* view file:

[!code-cshtml[main](index/sample/RazorPagesContacts2/Pages/Customers/Create.cshtml?highlight=2)]

The [Razor Pages starter project](#rpvs17) contains the *Pages/_ValidationScriptsPartial.cshtml*, which hooks up client-side validation.

<a name="url_gen"></a>

## URL generation for Pages

The `Create` page, shown previously, uses `RedirectToPage`:

[!code-cs[main](index/sample/RazorPagesContacts/Pages/Create.cshtml.cs?name=OnPostAsync&highlight=10)]

The app has the following file/folder structure

* */Pages*

  * *Index.cshtml*
  * */Customer*

    * *Create.cshtml*
    * *Edit.cshtml*
    * *Index.cshtml*

The *Pages/Customers/Create.cshtml* and *Pages/Customers/Edit.cshtml* pages redirect to *Pages/Index.cshtml* after success. The string `/Index` is part of the URI to access the preceding page. The string `/Index` can be used to generate URIs to the *Pages/Index.cshtml* page. For example:

* `Url.Page("/Index", ...)`
* `<a asp-page="/Index">My Index Page</a>`
* `RedirectToPage("/Index")`

The page name is the path to the page from the root */Pages* folder (including a leading `/`, for example `/Index`). The preceding URL generation samples are much more feature rich than just hardcoding a URL. URL generation uses [routing](xref:mvc/controllers/routing) and can generate and encode parameters according to how the route is defined in the destination path.

URL generation for pages supports relative names. The following table shows which Index page is selected with different `RedirectToPage` parameters from *Pages/Customers/Create.cshtml*:

| RedirectToPage(x)| Page |
| ----------------- | ------------ |
| RedirectToPage("/Index") | *Pages/Index* |
| RedirectToPage("./Index"); | *Pages/Customers/Index* |
| RedirectToPage("../Index") | *Pages/Index* |
| RedirectToPage("Index")  | *Pages/Customers/Index* |

`RedirectToPage("Index")`, `RedirectToPage("./Index")`, and `RedirectToPage("../Index")`  are *relative names*. The `RedirectToPage` parameter is *combined* with the path of the current page to compute the name of the destination page.  <!-- Review: Original had The provided string is combined with the page name of the current page to compute the name of the destination page. -- page name, not page path -->

Relative name linking is useful when building sites with a complex structure. If you use relative names to link between pages in a folder, you can rename that folder. All the links still work (because they didn't include the folder name).

## TempData

ASP.NET Core exposes the [TempData](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.mvc.controller#Microsoft_AspNetCore_Mvc_Controller_TempData) property on a [controller](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.mvc.controller). This property stores data until it is read. The `Keep` and `Peek` methods can be used to examine the data without deletion. `TempData` is  useful for redirection, when data is needed for more than a single request.

The `[TempData]` attribute is new in ASP.NET Core 2.0 and is supported on controllers and pages.

The following code sets the value of `Message` using `TempData`.
[!code-cs[main](index/sample/RazorPagesContacts2/Pages/Customers/CreateDot.cshtml.cs?highlight=10-11,27-28&name=snippetTemp)]

The following markup in the *Pages/Customers/Index.cshtml* file displays the value of `Message` using `TempData`.

```cshtml
<h3>Msg: @Model.Message</h3>
```

The *Pages/Customers/Index.cshtml.cs* code-behind file applies the `[TempData]` attribute to the `Message` property.

```cs
[TempData]
public string Message { get; set; }
```

See [TempData](xref:fundamentals/app-state#temp) for more information.

<a name="mhpp"></a>
## Multiple handlers per page

The following page generates markup for two page handlers using the `asp-page-handler` Tag Helper:

[!code-cshtml[main](index/sample/RazorPagesContacts2/Pages/Customers/CreateFATH.cshtml?highlight=12-13)]

<!-- Review: the FormActionTagHelper applies to all <form /> elements on a Razor page, even when there is no `asp-` attribute   -->

The form in the preceding example has two submit buttons, each using the `FormActionTagHelper` to submit to a different URL. The `asp-page-handler` attribute is a companion to `asp-page`. `asp-page-handler` generates URLs that submit to each of the handler methods defined by a page. `asp-page` is not specified because the sample is linking to the current page.

The code-behind file:

[!code-cs[main](index/sample/RazorPagesContacts2/Pages/Customers/CreateFATH.cshtml.cs?highlight=20,32)]

The preceding code uses *named handler methods*. Named handler methods are created by taking the text in the name after `On<HTTP Verb>` and before `Async` (if present). In the preceding example, the page methods are OnPost**JoinList**Async and OnPost**JoinListUC**Async. With *OnPost* and *Async* removed, the handler names are `JoinList` and `JoinListUC`.

[!code-cshtml[main](index/sample/RazorPagesContacts2/Pages/Customers/CreateFATH.cshtml?highlight=12-13)]

Using the preceding code, the URL path that submits to `OnPostJoinListAsync` is `http://localhost:5000/Customers/CreateFATH?handler=JoinList`. The URL path that submits to `OnPostJoinListUCAsync` is `http://localhost:5000/Customers/CreateFATH?handler=JoinListUC`.

## Customizing Routing

If you don't like the query string `?handler=JoinList` in the URL, you can change the route to put the handler name in the path portion of the URL. You can customize the route by adding a route template enclosed in double quotes after the `@page` directive.

[!code-cshtml[main](index/sample/RazorPagesContacts2/Pages/Customers/CreateRoute.cshtml?highlight=1)]


The preceding route puts the handler name in the URL path instead of the query string. The `?` following `handler` means the route parameter is optional.

You can use `@page` to add additional segments and parameters to a page's route. Whatever's there is **appended** to the default route of the page. Using an absolute or virtual path to change the page's route (like `"~/Some/Other/Path"`) is not supported.

## Configuration and settings

To configure advanced options, use the extension method `AddRazorPagesOptions` on the MVC builder:

[!code-cs[main](index/sample/RazorPagesContacts/StartupAdvanced.cs?name=snippet1)]

Currently you can use the `RazorPagesOptions` to set the root directory for pages, or add application model conventions for pages. We hope to enable more extensibility this way in the future.

To precompile views, see [Razor view compilation](xref:mvc/views/view-compilation) .

[Download or view sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/mvc/razor-pages/index/sample).

See [Getting started with Razor Pages in ASP.NET Core](xref:tutorials/razor-pages/razor-pages-start), which builds on this introduction.
