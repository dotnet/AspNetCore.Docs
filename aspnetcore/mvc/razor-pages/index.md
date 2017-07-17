---
title: Introduction to Razor Pages in ASP.NET Core
author: Rick-Anderson
description: Overview of Razor Pages in ASP.NET Core
keywords: ASP.NET Core, Razor Pages
ms.author: riande
manager: wpickett
ms.date: 07/28/2017
ms.topic: get-started-article
ms.technology: aspnet
ms.prod: asp.net-core
uid: mvc/razor-pages/index
---
# Introduction to Razor Pages in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT) and [Ryan Nowak](https://github.com/rynowak) 

Razor Pages is a new feature of ASP.NET Core MVC that makes coding page-focused scenarios easier and more productive.

Razor Pages requires ASP.NET Core 2.0.0 or later. Tooling support for Razor Pages ships in Visual Studio 2017 Update 3 or later.

[Download or view sample code](https://github.com/Rick-Anderson/razor-page-intro).

<a name="prerequisites"></a>

## ASP.NET Core 2.0 preview prerequisites

ASP.NET Core 2.0 preview  is included in .NET Core 2.0 preview. [Download .NET Core 2.0 Preview 2](https://www.microsoft.com/net/core/preview) 

Optional: [Visual Studio 2017 Preview](https://www.visualstudio.com/vs/preview/)

## Razor Pages

If you are using a typical *Startup.cs* like the following code, Razor Pages is enabled:

[!code-cs[main](index/sample/RazorPagesIntro/Startup.cs?name=Startup)]

All the Razor Pages types and features are in the `Microsoft.AspNetCore.Mvc.RazorPages` assembly. The `Microsoft.AspNetCore.Mvc` package includes the Razor Pages assembly. The `Microsoft.AspNetCore.All` metapackage includes all ASP.NET Core 2.x packages.

Consider a basic page:
<a name="OnGet"></a>

[!code-html[main](index/sample/RazorPagesIntro/Pages/Index.cshtml)]

The preceding code looks a lot like a Razor view file. What makes it different is the new `@page` directive. `@page` makes the file into an MVC action - which means that it can handle requests directly, without going through a controller. `@page` must be the first Razor directive on a page. `@page` affects the behavior of other Razor constructs. The [@functions](xref:mvc/views/razor#functions) directive enables function-level content.

A similar page, with the `PageModel` in a separate file, is shown in the following two files. The *Pages/Index2.cshtml* file:

[!code-html[main](index/sample/RazorPagesIntro/Pages/Index2.cshtml)]

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

The runtime looks for Razor Pages files in the *Pages* folder by default.

## Writing a basic form

The new Razor Pages features are designed to make common patterns used with web browsers easy. Consider a page that implements a basic "contact us" form for the `Contact` model:

For the examples in this document, the `DbContext` is initialized in the *Startup.cs* file.

[!code-cs[main](index/sample/RazorPagesContacts/Startup.cs?highlight=15-16)]

The data model:

[!code-cs[main](index/sample/RazorPagesContacts/Data/Customer.cs)]

The *Pages/Create.cshtml* view file:

[!code-html[main](index/sample/RazorPagesContacts/Pages/Create.cshtml)]

The *Pages/Create.cshtml.cs* code-behind file for the view:

[!code-cs[main](index/sample/RazorPagesContacts/Pages/Create.cshtml.cs?name=ALL)]

By convention, the `PageModel` class is called `<PageName>Model` and is in the same namespace as the page. Not much change is needed to convert from a page using `@functions` to define handlers and a page using a `PageModel` class. 

Using a `PageModel` code-behind file supports unit testing, but requires you to write an explicit constructor and class. Pages without `PageModel` code-behind files support runtime compilation, which can be an advantage in development.  <!-- review: advantage because you can make changes and refresh the browser without explicitly compiling the app -->

The page has an `OnPostAsync` *handler method* which runs on `POST` requests (when a user posts the form). You can add handler methods for any HTTP verb. The most common handlers are:

* `OnGet` to initialize state needed for the page. [OnGet](#OnGet) sample.
* `OnPost` to handle form submissions. 

The `Async` naming suffix is optional but is often used by convention. The `OnPostAsync` code in the preceding example looks similar to what you would normally write in a controller. This is typical for Razor Pages. Most of the MVC primitives like [model binding](xref:mvc/models/model-binding), [validation](xref:mvc/models/validation), and action results are shared.  <!-- Review: Ryan, can we get a list of what is shared and what isn't? -->

The previous `OnPostAsync` method:

[!code-cs[main](index/sample/RazorPagesContacts/Pages/Create.cshtml.cs?name=OnPostAsync)]

The basic flow of `OnPostAsync`: 

Check for validation errors.

*  If there are no errors, save the data and redirect.
*  If there are errors, show the page again with validation messages. Client-side validation is identical to traditional ASP.NET Core MVC applications. In many cases, validation errors would be caught on the client and never submitted to the server.

When the data is entered successfully, the `OnPostAsync` handler method calls the `RedirectToPage` helper method to return an instance of `RedirectToPageResult`.This is a new action result, similar to `RedirectToAction` or `RedirectToRoute`, but customized for pages. In the preceding sample, it redirects to the root Index page (`/Index`). `RedirectToPage` is detailed in the [URL generation for Pages](#url_gen) section.

When the submitted form has validation errors (that are passed to the server), the`OnPostAsync` handler method calls the `Page` helper method. `Page` returns an instance of `PageResult`. This is similar to how actions in controllers return `View`. `PageResult` is the default <!-- Review  --> return type for a handler method. A handler method that returns `void` will render the page.

The `Customer` property is using the new `[BindProperty]` attribute to opt-in to model binding. 

[!code-cs[main](index/sample/RazorPagesContacts/Pages/Create.cshtml.cs?name=PageModel&highlight=10-11)]

Razor Pages, by default, bind properties only with non-GET verbs. Binding to properties can reduce the amount of code you have to write by using the same property to render form fields (`<input asp-for="Customer.Name" />`) and accept the input.

Rather than using `@model`, we're taking advantage of a new feature for Pages. By default, the generated `Page`-derived class *is* the model. This means that features like [model binding](xref:mvc/models/model-binding), [Tag Helpers](xref:mvc/views/tag-helpers/intro), and HTML helpers all *just work* with the properties defined in `@functions`. Using a *view model* with Razor views is a best practice. With Pages, you get a view model *automatically*. 

The following code shows the combined version of the create page:

[!code-html[main](index/sample/RazorPagesContacts/Pages/CreateCombined.cshtml)]

The main change is to replace constructor injection with injected (`@inject`) properties. This page uses [@inject](xref:mvc/views/razor#inject) for dependency injection. The `@inject` statement generates and initializes the `Db` property that is used in `OnPostAsync`. Injected (`@inject`) properties are set before handler methods run.


The home page (*Index.cshtml*):

[!code-html[main](index/sample/RazorPagesContacts/Pages/Index.cshtml)]

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

[!code-html[main](index/sample/RazorPagesContacts/Pages/Edit.cshtml?highlight=1)]

<!-- REVIEW -->
The first line contains the `@page "{id:int}"` directive. `"{id:int}"` tells the page to accept requests to the page that contain `int` route data. If a request to the page doesn't contain route data that can be converted to an `int`, the runtime returns an HTTP 404 (not found) error.

The *Pages/Edit.cshtml.cs* file:

[!code-cs[main](index/sample/RazorPagesContacts/Pages/Edit.cshtml.cs)]

<a name="xsrf"></a>

## XSRF/CSRF and Razor Pages

You don't have to write any code for [antiforgery validation](xref:security/anti-request-forgery). Antiforgery token generation and validation is automatically included in Razor Pages.

## Using Layouts, partials, templates, and Tag Helpers with Razor Pages

Pages work with all the features of the Razor view engine. Layouts, partials, templates, Tag Helpers, *_ViewStart.cshtml*, *_ViewImports.cshtml* work in the same way they do for conventional Razor views. 

Let's declutter this page by taking advantage of some of those features. 

Add a [layout page](xref:mvc/views/layout) to Pages/_Layout.cshtml:

[!code-html[main](index/sample/RazorPagesContacts2/Pages/_LayoutSimple.cshtml)]

The [Layout](xref:mvc/views/layout#specifying-a-layout) property is set in *Pages/_ViewStart.cshtml*:

[!code-html[main](index/sample/RazorPagesContacts2/Pages/_ViewStart.cshtml)]

Note: The layout is in the *Pages* folder. Pages look for other views (layouts, templates, partials) hierarchically, starting in the same folder as the current page. This means that a layout in the *Pages* folder can be used from any Razor page under the *Pages* folder.

We recommend you **not** put the layout file in the *Views/Shared* folder. *Views/Shared* is an MVC views pattern. Razor Pages are meant to rely on folder hierarchy, not path conventions.

View search from a Razor Page will include the *Pages* folder. The layouts, templates, and partials you're using with MVC controllers and conventional Razor views *just work*.

Add a *Pages/_ViewImports.cshtml* file:

[!code-html[main](index/sample/RazorPagesContacts2/Pages/_ViewImports.cshtml)]

I'll explain the `@namespace` later. The `@addTagHelper` directive will bring in the [built-in Tag Helpers](https://docs.microsoft.com/aspnet/core/mvc/views/tag-helpers/built-in/) to all the pages in the *Pages* folder.

<a name="namespace"></a>

When the `@namespace` directive is used explicitly on a page:

[!code-html[main](index/sample/RazorPagesIntro/Pages/Customers/Namespace2.cshtml?highlight=2)]

The directive sets the namespace for the page. The `@model` directive doesn't need to include the namespace.

When the `@namespace` directive is contained in *_ViewImports.cshtml*, the specified namespace supplies the prefix for the generated namespace in the Page that imports the `@namespace` directive. The rest of the generated namespace (the suffix portion) is the dot-separated relative path between the folder containing *_ViewImports.cshtml* and the folder containing the page.

For example, the code behind file *Pages/Customers/Edit.cshtml.cs* explicitly sets the namespace:

[!code-cs[main](index/sample/RazorPagesContacts2/Pages/Customers/Edit.cshtml.cs?name=namespace)]

The *Pages/_ViewImports.cshtml* file sets the following namespace:

[!code-html[main](index/sample/RazorPagesContacts2/Pages/_ViewImports.cshtml?highlight=1)]

The generated namespace for the *Pages/Customers/Edit.cshtml* Razor Page is the same as the code behind file. The `@namespace` directive was designed so the C# classes you add and pages-generated code *just work* without having to add an `@using` directive for the code behind file.

Note: `@namespace` also works with conventional Razor views.

<!-- rick todo
Add a *Pages/_ValidationScriptsPartial.cshtml* file to enable client-side validation.

[!code-html[main](index/sample/RazorPagesContacts/Pages/_ValidationScriptsPartial.cshtml)]

-->

The original *Pages/Create.cshtml* view file:

[!code-html[main](index/sample/RazorPagesContacts/Pages/Create.cshtml?highlight=2)]

The updated page:

The *Pages/Create.cshtml* view file:

[!code-html[main](index/sample/RazorPagesContacts2/Pages/Customers/Create.cshtml?highlight=2)]

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

The *Pages/Customers/Create.cshtml*  and *Pages/Customers/Edit.cshtml* pages redirect to *Pages/Index.cshtml* after success. The string `/Index` is part of the URI to access the the preceding page. The string `/Index` can be used to generate URIs to the *Pages/Index.cshtml* page. For example:


* `Url.Page("/Index", ...)`
* `<a asp-page="/Index">My Index Page</a>`
* `RedirectToPage("/Index")`


The page name is the path to the page from the root */Pages* folder (including a leading `/`, for example `/Index`). This is much more feature-rich than just hardcoding a URL. This is URL generation using [routing](xref:mvc/controllers/routing), and can generate and encode parameters according to how the route is defined in the destination path.

URL generation for pages supports relative names. The following table shows which Index page is selected with different `RedirectToPage` parameters from *Pages/Customers/Create.cshtml*:

| `RedirectToPage(x)| Page |
| ----------------- | ------------ |  
|  RedirectToPage("/Index") | *Pages/Index* |
| RedirectToPage("./Index"); | *Pages/Customers/Index* |
| RedirectToPage("../Index") | *Pages/Index* |
| RedirectToPage("Index")  | *Pages/Customers/Index* |

`RedirectToPage("Index")`, `RedirectToPage("./Index")`, and `RedirectToPage("../Index")`  are *relative names*. The `RedirectToPage` parameter is *combined* with the path of the current page to compute the name of the destination page.  <!-- Review: Original had The provided string is combined with the page name of the current page to compute the name of the destination page. -- page name, not page path -->

Relative name linking is useful when building sites with a complex structure. If you use relative names to link between pages in a folder, you can rename that folder. All the links still work (because they didn't include the folder name).


## TempData

The `[TempData]` attribute is new in ASP.NET Core 2.0 and is supported on controllers and pages. In 2.0.0, the default storage for temp data is cookies. A session provider is no longer required by default.

TODO provide sample moving temp data bewteen pages.

<a name="mhpp"></a>
##  Multiple handlers per page

The following page generates markup for two page handlers using the `asp-page-handler` tag helper:

[!code-html[main](index/sample/RazorPagesContacts2/Pages/Customers/CreateFATH.cshtml?highlight=12-13)]

<!-- Review: Where is the FormActionTagHelper?  How is it used in conjunction? -->
The form in the preceding example has two submit buttons, each using the new `FormActionTagHelper` in conjunction to submit to a different URL. The `asp-handler` attribute is a companion to `asp-page` and generates URLs that submit to each of the handler methods defined by the page. We don't need to specify `asp-page` because we're linking to the current page.

The code-behind file:

[!code-cs[main](index/sample/RazorPagesContacts2/Pages/Customers/CreateFATH.cshtml.cs?highlight=20,32)]

The preceding code uses *named handler methods*. Named handler methods are created by taking the text in the name after `On<HTTP Verb>` and before `Async` (if present). In the preceding example, the page methods are OnPost**JoinList**Async and OnPost**JoinListUC**Async. With *OnPost* and *Async* removed, the handler names are `JoinList` and `JoinListUC`.

[!code-html[main](index/sample/RazorPagesContacts2/Pages/Customers/CreateFATH.cshtml?highlight=12-13)]

Using the preceding code, the URL path that submits to `OnPostJoinListAsync` is `http://localhost:5000/Customers/CreateFATH?handler=JoinList`. The URL path that submits to `OnPostJoinListUCAsync` is `http://localhost:5000/Customers/CreateFATH?handler=JoinListUC`. 

## Customizing Routing

If you don't like the query string `?handler=JoinList` in the URL, you can change the route to put the handler name in the path portion of the URL. You can customize the route by adding a route template enclosed in double quotes after the `@page` directive.

[!code-html[main](index/sample/RazorPagesContacts2/Pages/Customers/CreateRoute.cshtml?highlight=1)]


This route will now put the handler name in the URL path instead of the query string. The `?` following `handler` means this is an optional route parameter.

You can use `@page` to add additional segments and parameters to a page's route. Whatever's there is **appended** to the default route of the page. Using an absolute or virtual path to change the page's route (like `"~/Some/Other/Path"`) is not supported.

## Configuration and settings

Use the extension method `AddRazorPagesOptions` on the MVC builder to configure advanced options such as the following example:

<!-- Review - please update the sample code to configure advanced options  and I'll import the snippet
-->

```c#
public class Startup
{
    public void ConfigureServices(IServiceCollections services)
    {
        services.AddMvc().AddRazorPagesOptions(options =>
        {
           ... 
        });
    }

    ...
}
```

Currently you can use the `RazorPagesOptions` to set the root directory for pages, or add application model conventions for pages. We hope to enable more extensibility this way in the future.

See [Razor view compilation](xref:mvc/views/view-compilation) to precompile views.
