---
title: Introduction to Razor Pages in ASP.NET Core
author: Rick-Anderson
description: Learn how Razor Pages in ASP.NET Core makes coding page-focused scenarios easier and more productive than using MVC.
monikerRange: '>= aspnetcore-2.0'
ms.author: riande
ms.date: 05/12/2018
uid: razor-pages/index
---
# Introduction to Razor Pages in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT) and [Ryan Nowak](https://github.com/rynowak)

Razor Pages is a new aspect of ASP.NET Core MVC that makes coding page-focused scenarios easier and more productive.

If you're looking for a tutorial that uses the Model-View-Controller approach, see [Get started with ASP.NET Core MVC](xref:tutorials/first-mvc-app/start-mvc).

This document provides an introduction to Razor Pages. It's not a step by step tutorial. If you find some of the sections too advanced, see [Get started with Razor Pages](xref:tutorials/razor-pages/razor-pages-start). For an overview of ASP.NET Core, see the [Introduction to ASP.NET Core](xref:index).

## Prerequisites

[!INCLUDE [](~/includes/net-core-prereqs.md)]

<a name="rpvs17"></a>

## Creating a Razor Pages project

# [Visual Studio](#tab/visual-studio)

See [Get started with Razor Pages](xref:tutorials/razor-pages/razor-pages-start) for detailed instructions on how to create a Razor Pages project using Visual Studio.

# [Visual Studio for Mac](#tab/visual-studio-mac)

::: moniker range=">= aspnetcore-2.1"

Run `dotnet new webapp` from the command line.

[!INCLUDE[](~/includes/webapp-alias-notice.md)]

::: moniker-end

::: moniker range="= aspnetcore-2.0"

Run `dotnet new razor` from the command line.

::: moniker-end

Open the generated *.csproj* file from Visual Studio for Mac.

# [Visual Studio Code](#tab/visual-studio-code)

::: moniker range=">= aspnetcore-2.1"

Run `dotnet new webapp` from the command line.

[!INCLUDE[](~/includes/webapp-alias-notice.md)]

::: moniker-end

::: moniker range="= aspnetcore-2.0"

Run `dotnet new razor` from the command line.

::: moniker-end

# [.NET Core CLI](#tab/netcore-cli)

::: moniker range=">= aspnetcore-2.1"

Run `dotnet new webapp` from the command line.

[!INCLUDE[](~/includes/webapp-alias-notice.md)]

::: moniker-end

::: moniker range="= aspnetcore-2.0"

Run `dotnet new razor` from the command line.

::: moniker-end

---

## Razor Pages

Razor Pages is enabled in *Startup.cs*:

[!code-cs[](index/sample/RazorPagesIntro/Startup.cs?name=snippet_Startup)]

Consider a basic page:
<a name="OnGet"></a>

[!code-cshtml[](index/sample/RazorPagesIntro/Pages/Index.cshtml)]

The preceding code looks a lot like a Razor view file. What makes it different is the `@page` directive. `@page` makes the file into an MVC action - which means that it handles requests directly, without going through a controller. `@page` must be the first Razor directive on a page. `@page` affects the behavior of other Razor constructs.

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

## Writing a basic form

Razor Pages is designed to make common patterns used with web browsers easy to implement when building an app. [Model binding](xref:mvc/models/model-binding), [Tag Helpers](xref:mvc/views/tag-helpers/intro), and HTML helpers all *just work* with the properties defined in a Razor Page class. Consider a page that implements a basic "contact us" form for the `Contact` model:

For the samples in this document, the `DbContext` is initialized in the [Startup.cs](https://github.com/aspnet/Docs/blob/master/aspnetcore/razor-pages/index/sample/RazorPagesContacts/Startup.cs#L15-L16) file.

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

The `PageModel` class allows separation of the logic of a page from its presentation. It defines page handlers for requests sent to the page and the data used to render the page. This separation allows you to manage page dependencies through [dependency injection](xref:fundamentals/dependency-injection) and to [unit test](xref:test/razor-pages-tests) the pages.

The page has an `OnPostAsync` *handler method*, which runs on `POST` requests (when a user posts the form). You can add handler methods for any HTTP verb. The most common handlers are:

* `OnGet` to initialize state needed for the page. [OnGet](#OnGet) sample.
* `OnPost` to handle form submissions.

The `Async` naming suffix is optional but is often used by convention for asynchronous functions. The `OnPostAsync` code in the preceding example looks similar to what you would normally write in a controller. The preceding code is typical for Razor Pages. Most of the MVC primitives like [model binding](xref:mvc/models/model-binding), [validation](xref:mvc/models/validation), and action results are shared.  <!-- Review: Ryan, can we get a list of what is shared and what isn't? -->

The previous `OnPostAsync` method:

[!code-cs[](index/sample/RazorPagesContacts/Pages/Create.cshtml.cs?name=snippet_OnPostAsync)]

The basic flow of `OnPostAsync`:

Check for validation errors.

*  If there are no errors, save the data and redirect.
*  If there are errors, show the page again with validation messages. Client-side validation is identical to traditional ASP.NET Core MVC applications. In many cases, validation errors would be detected on the client, and never submitted to the server.

When the data is entered successfully, the `OnPostAsync` handler method calls the `RedirectToPage` helper method to return an instance of `RedirectToPageResult`. `RedirectToPage` is a new action result, similar to `RedirectToAction` or `RedirectToRoute`, but customized for pages. In the preceding sample, it redirects to the root Index page (`/Index`). `RedirectToPage` is detailed in the [URL generation for Pages](#url_gen) section.

When the submitted form has validation errors (that are passed to the server), the`OnPostAsync` handler method calls the `Page` helper method. `Page` returns an instance of `PageResult`. Returning `Page` is similar to how actions in controllers return `View`. `PageResult` is the default <!-- Review  --> return type for a handler method. A handler method that returns `void` renders the page.

The `Customer` property uses `[BindProperty]` attribute to opt in to model binding.

[!code-cs[](index/sample/RazorPagesContacts/Pages/Create.cshtml.cs?name=snippet_PageModel&highlight=10-11)]

Razor Pages, by default, bind properties only with non-GET verbs. Binding to properties can reduce the amount of code you have to write. Binding reduces code by using the same property to render form fields (`<input asp-for="Customer.Name" />`) and accept the input.

> [!NOTE]
> For security reasons, you must opt in to binding GET request data to page model properties. Verify user input before mapping it to properties. Opting in to this behavior is useful when addressing scenarios which rely on query string or route values.
>
> To bind a property on GET requests, set the `[BindProperty]` attribute's `SupportsGet` property to `true`:
> `[BindProperty(SupportsGet = true)]`

The home page (*Index.cshtml*):

[!code-cshtml[](index/sample/RazorPagesContacts/Pages/Index.cshtml)]

The associated `PageModel` class (*Index.cshtml.cs*):

[!code-cs[](index/sample/RazorPagesContacts/Pages/Index.cshtml.cs)]

The *Index.cshtml* file contains the following markup to create an edit link for each contact:

[!code-cshtml[](index/sample/RazorPagesContacts/Pages/Index.cshtml?range=21)]

The [Anchor Tag Helper](xref:mvc/views/tag-helpers/builtin-th/anchor-tag-helper) used the `asp-route-{value}` attribute to generate a link to the Edit page. The link contains route data with the contact ID. For example, `http://localhost:5000/Edit/1`.

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

When the button is selected, a form `POST` request is sent to the server. By convention, the name of the handler method is selected based the value of the `handler` parameter according to the scheme `OnPost[handler]Async`.

Because the `handler` is `delete` in this example, the `OnPostDeleteAsync` handler method is used to process the `POST` request. If the `asp-page-handler` is set to a different value, such as `remove`, a page handler method with the name `OnPostRemoveAsync` is selected.

[!code-cs[](index/sample/RazorPagesContacts/Pages/Index.cshtml.cs?range=26-37)]

The `OnPostDeleteAsync` method:

* Accepts the `id` from the query string.
* Queries the database for the customer contact with `FindAsync`.
* If the customer contact is found, they're removed from the list of customer contacts. The database is updated.
* Calls `RedirectToPage` to redirect to the root Index page (`/Index`).

::: moniker range=">= aspnetcore-2.1"

## Mark page properties required

Properties on a `PageModel` can be decorated with the [Required](/dotnet/api/system.componentmodel.dataannotations.requiredattribute) attribute:

[!code-cs[](index/sample/Create.cshtml.cs?highlight=3,15-16)]

See [Model validation](xref:mvc/models/validation) for more information.

## Manage HEAD requests with the OnGet handler

Ordinarily, a HEAD handler is created and called for HEAD requests:

```csharp
public void OnHead()
{
    HttpContext.Response.Headers.Add("HandledBy", "Handled by OnHead!");
}
```

If no HEAD handler (`OnHead`) is defined, Razor Pages falls back to calling the GET page handler (`OnGet`) in ASP.NET Core 2.1 or later. Opt in to this behavior with the [SetCompatibilityVersion method](xref:fundamentals/startup#setcompatibilityversion-for-aspnet-core-mvc) in `Startup.Configure` for ASP.NET Core 2.1 to 2.x:

```csharp
services.AddMvc()
    .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);
```

`SetCompatibilityVersion` effectively sets the Razor Pages option `AllowMappingHeadRequestsToGetHandler` to `true`.

Rather than opting into all 2.1 behaviors with `SetCompatibilityVersion`, you can explicitly opt-in to specific behaviors. The following code opts into the mapping HEAD requests to the GET handler.


```csharp
services.AddMvc()
    .AddRazorPagesOptions(options =>
    {
        options.AllowMappingHeadRequestsToGetHandler = true;
    });
```
::: moniker-end

<a name="xsrf"></a>

## XSRF/CSRF and Razor Pages

You don't have to write any code for [antiforgery validation](xref:security/anti-request-forgery). Antiforgery token generation and validation are automatically included in Razor Pages.

<a name="layout"></a>
## Using Layouts, partials, templates, and Tag Helpers with Razor Pages

Pages work with all the capabilities of the Razor view engine. Layouts, partials, templates, Tag Helpers, *_ViewStart.cshtml*, *_ViewImports.cshtml* work in the same way they do for conventional Razor views.

Let's declutter this page by taking advantage of some of those capabilities.

::: moniker range=">= aspnetcore-2.1"

Add a [layout page](xref:mvc/views/layout) to *Pages/Shared/_Layout.cshtml*:

::: moniker-end

::: moniker range="= aspnetcore-2.0"

Add a [layout page](xref:mvc/views/layout) to *Pages/_Layout.cshtml*:

::: moniker-end

[!code-cshtml[](index/sample/RazorPagesContacts2/Pages/_LayoutSimple.cshtml)]

The [Layout](xref:mvc/views/layout):

* Controls the layout of each page (unless the page opts out of layout).
* Imports HTML structures such as JavaScript and stylesheets.

See [layout page](xref:mvc/views/layout) for more information.

The [Layout](xref:mvc/views/layout#specifying-a-layout) property is set in *Pages/_ViewStart.cshtml*:

[!code-cshtml[](index/sample/RazorPagesContacts2/Pages/_ViewStart.cshtml)]

::: moniker range=">= aspnetcore-2.1"

The layout is in the *Pages/Shared* folder. Pages look for other views (layouts, templates, partials) hierarchically, starting in the same folder as the current page. A layout in the *Pages/Shared* folder can be used from any Razor page under the *Pages* folder.

The layout file should go in the *Pages/Shared* folder.

::: moniker-end

::: moniker range="= aspnetcore-2.0"

The layout is in the *Pages* folder. Pages look for other views (layouts, templates, partials) hierarchically, starting in the same folder as the current page. A layout in the *Pages* folder can be used from any Razor page under the *Pages* folder.

::: moniker-end

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

`RedirectToPage("Index")`, `RedirectToPage("./Index")`, and `RedirectToPage("../Index")`  are <em>relative names</em>. The `RedirectToPage` parameter is <em>combined</em> with the path of the current page to compute the name of the destination page.  <!-- Review: Original had The provided string is combined with the page name of the current page to compute the name of the destination page.  page name, not page path -->

Relative name linking is useful when building sites with a complex structure. If you use relative names to link between pages in a folder, you can rename that folder. All the links still work (because they didn't include the folder name).

::: moniker range=">= aspnetcore-2.1"
## ViewData attribute

Data can be passed to a page with [ViewDataAttribute](/dotnet/api/microsoft.aspnetcore.mvc.viewdataattribute). Properties on controllers or Razor Page models decorated with `[ViewData]` have their values stored and loaded from the [ViewDataDictionary](/dotnet/api/microsoft.aspnetcore.mvc.viewfeatures.viewdatadictionary).

In the following example, the `AboutModel` contains a `Title` property decorated with `[ViewData]`. The `Title` property is set to the title of the About page:

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
::: moniker-end

## TempData

ASP.NET Core exposes the [TempData](/dotnet/api/microsoft.aspnetcore.mvc.controller.tempdata?view=aspnetcore-2.0#Microsoft_AspNetCore_Mvc_Controller_TempData) property on a [controller](/dotnet/api/microsoft.aspnetcore.mvc.controller). This property stores data until it's read. The `Keep` and `Peek` methods can be used to examine the data without deletion. `TempData` is  useful for redirection, when data is needed for more than a single request.

The `[TempData]` attribute is new in ASP.NET Core 2.0 and is supported on controllers and pages.

The following code sets the value of `Message` using `TempData`:

[!code-cs[](index/sample/RazorPagesContacts2/Pages/Customers/CreateDot.cshtml.cs?highlight=10-11,25&name=snippet_Temp)]

The following markup in the *Pages/Customers/Index.cshtml* file displays the value of `Message` using `TempData`.

```cshtml
<h3>Msg: @Model.Message</h3>
```

The *Pages/Customers/Index.cshtml.cs* page model applies the `[TempData]` attribute to the `Message` property.

```cs
[TempData]
public string Message { get; set; }
```

See [TempData](xref:fundamentals/app-state#tempdata) for more information.

<a name="mhpp"></a>
## Multiple handlers per page

The following page generates markup for two page handlers using the `asp-page-handler` Tag Helper:

[!code-cshtml[](index/sample/RazorPagesContacts2/Pages/Customers/CreateFATH.cshtml?highlight=12-13)]

<!-- Review: the FormActionTagHelper applies to all <form /> elements on a Razor page, even when there's no `asp-` attribute   -->

The form in the preceding example has two submit buttons, each using the `FormActionTagHelper` to submit to a different URL. The `asp-page-handler` attribute is a companion to `asp-page`. `asp-page-handler` generates URLs that submit to each of the handler methods defined by a page. `asp-page` isn't specified because the sample is linking to the current page.

The page model:

[!code-cs[](index/sample/RazorPagesContacts2/Pages/Customers/CreateFATH.cshtml.cs?highlight=20,32)]

The preceding code uses *named handler methods*. Named handler methods are created by taking the text in the name after `On<HTTP Verb>` and before `Async` (if present). In the preceding example, the page methods are OnPost**JoinList**Async and OnPost**JoinListUC**Async. With *OnPost* and *Async* removed, the handler names are `JoinList` and `JoinListUC`.

[!code-cshtml[](index/sample/RazorPagesContacts2/Pages/Customers/CreateFATH.cshtml?range=12-13)]

Using the preceding code, the URL path that submits to `OnPostJoinListAsync` is `http://localhost:5000/Customers/CreateFATH?handler=JoinList`. The URL path that submits to `OnPostJoinListUCAsync` is `http://localhost:5000/Customers/CreateFATH?handler=JoinListUC`.

## Custom routes

Use the `@page` directive to:

* Specify a custom route to a page. For example, the route to the About page can be set to `/Some/Other/Path` with `@page "/Some/Other/Path"`.
* Append segments to a page's default route. For example, an "item" segment can be added to a page's default route with `@page "item"`.
* Append parameters to a page's default route. For example, an ID parameter, `id`, can be required for a page with `@page "{id}"`.

A root-relative path designated by a tilde (`~`) at the beginning of the path is supported. For example, `@page "~/Some/Other/Path"` is the same as `@page "/Some/Other/Path"`.

You can change the query string `?handler=JoinList` in the URL to a route segment `/JoinList` by specifying the route template `@page "{handler?}"`.

If you don't like the query string `?handler=JoinList` in the URL, you can change the route to put the handler name in the path portion of the URL. You can customize the route by adding a route template enclosed in double quotes after the `@page` directive.

[!code-cshtml[](index/sample/RazorPagesContacts2/Pages/Customers/CreateRoute.cshtml?highlight=1)]

Using the preceding code, the URL path that submits to `OnPostJoinListAsync` is `http://localhost:5000/Customers/CreateFATH/JoinList`. The URL path that submits to `OnPostJoinListUCAsync` is `http://localhost:5000/Customers/CreateFATH/JoinListUC`.

The `?` following `handler` means the route parameter is optional.

## Configuration and settings

To configure advanced options, use the extension method `AddRazorPagesOptions` on the MVC builder:

[!code-cs[](index/sample/RazorPagesContacts/StartupAdvanced.cs?name=snippet_1)]

Currently you can use the `RazorPagesOptions` to set the root directory for pages, or add application model conventions for pages. We'll enable more extensibility this way in the future.

To precompile views, see [Razor view compilation](xref:mvc/views/view-compilation) .

[Download or view sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/razor-pages/index/sample).

See [Get started with Razor Pages](xref:tutorials/razor-pages/razor-pages-start), which builds on this introduction.

### Specify that Razor Pages are at the content root

By default, Razor Pages are rooted in the */Pages* directory. Add [WithRazorPagesAtContentRoot](/dotnet/api/microsoft.extensions.dependencyinjection.mvcrazorpagesmvcbuilderextensions.withrazorpagesatcontentroot) to [AddMvc](/dotnet/api/microsoft.extensions.dependencyinjection.mvcservicecollectionextensions.addmvc#Microsoft_Extensions_DependencyInjection_MvcServiceCollectionExtensions_AddMvc_Microsoft_Extensions_DependencyInjection_IServiceCollection_) to specify that your Razor Pages are at the content root ([ContentRootPath](/dotnet/api/microsoft.aspnetcore.hosting.ihostingenvironment.contentrootpath)) of the app:

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

## See also

* [Introduction to ASP.NET Core](xref:index)
* [Razor syntax](xref:mvc/views/razor)
* [Get started with Razor Pages](xref:tutorials/razor-pages/razor-pages-start)
* [Razor Pages authorization conventions](xref:security/authorization/razor-pages-authorization)
* [Razor Pages custom route and page model providers](xref:razor-pages/razor-pages-conventions)
* [Razor Pages unit tests](xref:test/razor-pages-tests)
