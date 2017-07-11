---
title: Introduction to Razor Pages in ASP.NET Core
author: Rick-Anderson
description: Overview of Razor Pages in ASP.NET Core
keywords: ASP.NET Core, Razor Pages
ms.author: riande
manager: wpickett
ms.date: 07/28/2017
ms.topic: get-started-article
ms.assetid: 30e4104c-0124-477b-86b3-beb7b34ed3f6
ms.technology: aspnet
ms.prod: asp.net-core
uid: mvc/razor-pages/index
---
## Introduction to Razor Pages in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT) and [Ryan Nowak](https://github.com/rynowak) 

Razor Pages is a new feature of ASP.NET Core MVC that makes coding page-focused scenarios easier and more productive.

Razor Pages requires ASP.NET Core 2.0.0 or later. Tooling support for Razor Pages ships in Visual Studio 2017 Update 3 or later.

[Download or view sample code](https://github.com/Rick-Anderson/razor-page-intro).

## Getting started

Razor Pages is on by default in MVC. If you are using a typical *Startup.cs* like the following code, Razor Pages is enabled:

[!code-cs[main](../../../razor-page-intro/RazorPagesIntro/Startup.cs?name=Startup "Startup ")]

All the new Razor Pages types and features are included in the `Microsoft.AspNetCore.Mvc.RazorPages` assembly. If you are referencing the `Microsoft.AspNetCore.Mvc` package, a reference to the Razor Pages assembly is included.

Consider a basic page:
<a name="OnGet"></a>

[!code-html[main](../../../razor-page-intro/RazorPagesIntro/Pages/Index.cshtml "Index ")]

The preceeding code looks a lot like a Razor view file. What makes it different is the new `@page` directive. `@page` makes the file into an MVC action - which means that it can handle requests directly, without going through a controller. `@page` must be the first Razor directive on a page. `@page` affects the behavior of other Razor constructs. The [@functions](xref:mvc/views/razor#functions) directive enables function level content.

A similar page, with the `PageModel` in a separate file, is shown in the following two files:

[!code-html[main](../../../razor-page-intro/RazorPagesIntro/Pages/Index2.cshtml "Index2 ")]

The `PageModel` class *Pages/Index2.cshtml.cs*, a 'code-behind' file for the view code:

[!code-cs[main](../../../razor-page-intro/RazorPagesIntro/Pages/Index2.cshtml.cs "Index2.cs ")]

By convention, the `PageModel` class file has the same name as the Razor Page file with *.cs* appended. For example, the previous Razor Page is *Pages/Index2.cshtml*. The file containing the `PageModel` class is named *Pages/Index2.cshtml.cs*.

For simple pages, mixing the `PageModel` class with the Razor markup is fine. For more complex code, it's a best practice to keep the page model code seperate.

The associations of URL paths to pages are determined by the page's location in the file system. The following table shows a Razor Pages path and the matching URL:

| File name and path               | matching URL |
| ----------------- | ------------ | 
| */Pages/Index.cshtml* | `/` or `/Index` | 
| */Pages/Contact.cshtml* | `/Contact` |
| */Pages/Store/Contact.cshtml* | `/Store/Contact` |

The runtime looks for Razor Pages files in the *Pages* folder by default.

### Writing a basic form

The new Razor Pages features are designed to make common patterns used with web browsers easy. Consider a page that implements a basic 'contact us' form for the `Contact` model:

For the examples in this document, the `DbContext` is initialized in the *Startup.cs* file.

[!code-cs[main](../../../razor-page-intro/RazorPagesContacts/Startup.cs?highlight=15-16 "Startup ")]

The data model:

[!code-cs[main](../../../razor-page-intro/RazorPagesContacts/Data/Customer.cs "model ")]

The *Pages/Create.cshtml* view file:

[!code-html[main](../../../razor-page-intro/RazorPagesContacts/Pages/Create.cshtml)]

The `PageModel` class *Pages/Create.cshtml.cs* 'code-behind' file for the view:

[!code-cs[main](../../../razor-page-intro/RazorPagesContacts/Pages/Create.cshtml.cs?name=ALL)]

By convention, the `PageModel` class is called `<PageName>Model` and is in the same namespace as the page. Not much change is needed to convert from a page using `@functions` to define handlers and a page using a `PageModel` class. 

Using a `PageModel` 'code-behind' file supports unit testing, but requires you to write an explicit constructor and class. Pages without `PageModel` 'code-behind' files support runtime compilation, which can be an advantage in development.  <!-- review: why? -->

The page has an `OnPostAsync` *handler method* which runs on `POST` requests (when a user posts the form). You can add handler methods for any HTTP verb. The most common handlers are:

* `OnGet` to initialize state needed for the page. [OnGet](#OnGet) sample.
* `OnPost` to handle form submissions. 

The `Async` naming suffix is optional but is often used by convention. The code that's in `OnPostAsync` in the preceding example looks similar to what you would normally write in a controller. This is typical for Razor Pages. Most of the MVC primitives like [model binding](xref:mvc/models/model-binding), [validation](xref:mvc/models/validation), and action results are shared.  <!-- Review: Ryan, can we get a list of what is shared and what isn't? -->

The previous `OnPostAsync` method:

[!code-cs[main](../../../razor-page-intro/RazorPagesContacts/Pages/Create.cshtml.cs?name=OnPostAsync)]

The basic flow of `OnPostAsync`: 

Check for validation errors.

*  If there are no errors, save the data and redirect.
*  If there are errors, show the page again with validation messages. Client side validation is identical to traditonal ASP.NET Core MVC applications. In many cases validation errors would be caught on the client and never submitted to the server.

When the data is entered successfully, the `OnPostAsync` handler method calls the `RedirectToPage` helper method to return an instance of `RedirectToPageResult`. This is a new action result similar to `RedirectToAction` or `RedirectToRoute` but customized for pages. In the preceding sample, it redirects to the Index page (`/Index`).

When the submitted form has validation errors (that are passed to the server), the`OnPostAsync` handler method calls the `Page` helper method. `Page` returns an instance of `PageResult`. This is similar to how actions in controllers return `View`. `PageResult` is the default <!-- Review default what? Return type?? --> for a handler method. A handler method that returns `void` will render the page.

The `Customer` property is using the new `[BindProperty]` attribute to opt-in to model binding. 

[!code-cs[main](../../../razor-page-intro/RazorPagesContacts/Pages/Create.cshtml.cs?name=PageModel&highlight=10-11)]

Razor Pages, by default, bind properties only with non-GET verbs. Binding to properties can reduce the amount of code you have to write by using the same property to render form fields (`<input asp-for="Customer.Name" />`) and accept the input.

Rather than using `@model`, we're taking advantage of a new feature for Pages. By default, the generated `Page`-derived class *is* the model. This means that features like [model binding](xref:mvc/models/model-binding), [tag helpers](xref:mvc/views/tag-helpers/intro), and HTML helpers all *just work* with the properties defined in `@functions`. Using a *view model* with Razor views is a best practice. With Pages, you get a view model **automatically**. 

The following code shows the combined version of the create page:

[!code-html[main](../../../razor-page-intro/RazorPagesContacts/Pages/CreateCombined.cshtml "CreateCombined ")]

The main change is to replace constructor injection with injected (`@inject`) properties. This page uses [@inject](xref:mvc/views/razor#inject) for dependency injection. The `@inject` statement generates and initializes the `Db` property that is used in `OnPostAsync`. Injected (`@inject`) properties are set before handler methods run.

<a name="xsrf"></a>

### XSRF/CSRF and Razor Pages

You don't have to write any code for [antiforgery validation](xref:security/anti-request-forgery). Antiforgery token generation and validation is automatically included in Razor Pages.

## Using Layouts, partials, templates, and tag helpers with Razor Pages

Pages work with all the features of the Razor view engine. Layouts, partials, templates, tag helpers, *_ViewStart.cshtml*, *_ViewImports.cshtml* work in the same way they do for conventional Razor views. 

Let's declutter this page by taking advantage of some of those features. 

Add a [layout page](xref:mvc/views/layout) to [Pages/_Layout.cshtm](https://github.com/Rick-Anderson/razor-page-intro/blob/master/RazorPagesContacts2/Pages/_Layout.cshtml)

<!-- that layout file is pretty big, consider posting only the link or part of it -->

[!code-html[main](../../../razor-page-intro/RazorPagesContacts2/Pages/_Layout.cshtml)]

The [Layout](xref:mvc/views/layout#specifying-a-layout) property is set in *Pages/_ViewStart.cshtml*:

[!code-html[main](../../../razor-page-intro/RazorPagesContacts2/Pages/_ViewStart.cshtml)]

Note: The layout is in the *Pages* folder. Pages look for other views (layouts, templates, partials) hierarchically, starting in the same folder as the current page. This means that a layout in the *Pages* folder can be used from any Razor page under the *Pages* folder.

We recommend you **not** put the layout file in the *Views/Shared* folder. *Views/Shared* is an MVC views pattern. Razor Pages are meant to rely on folder hierarchy, not path conventions.

View search from a Razor Page will include the *Pages* folder. The layouts, templates, and partials you're using with MVC controllers and conventional Razor views *just work*.

Add a *Pages/_ViewImports.cshtml* file:

[!code-cs[main](../../../razor-page-intro/RazorPagesContacts2/Pages/_ViewImports.cshtml)]

The `@addTagHelper` directive will bring in the [built-in tag helpers](https://docs.microsoft.com/aspnet/core/mvc/views/tag-helpers/built-in/) to all the pages in the *Pages* folder.

<a name="namespace"></a>

When the `@namespace` directive is used explicitly on a page:

[!code-cs[main](../../../razor-page-intro/RazorPagesSample/Pages/NameSpace.cshtml?highlight=2)]

The directive sets the namespace for the page.

When the `@namespace` directive is contained in *_ViewImports.cshtml*, the specified namespace supplies the prefix for the generated namespace in the Page that imports the `@namespace` directive. The rest of the generated namespace (the suffix portion) is the dot-separated relative path between the folder containing *_ViewImports.cshtml* and the folder containing the page.

For example, the code behind file *Pages/Customers/Edit.cshtml.cs* explicityly sets the namespace:

[!code-cs[main](../../../razor-page-intro/RazorPagesContacts2/Pages/Customers/Edit.cshtml.cs?name=namespace)]

The *Pages/_ViewImports.cshtml* file sets the following namespace:

[!code-cs[main](../../../razor-page-intro/RazorPagesContacts2/Pages/_ViewImports.cshtml?highlight=1)]

The generated namespace for the *Pages/Customers/Edit.cshtml* Razor Page is the same as the code behind file. The `@namespace` directive was designed so the C# classes you add and pages-generated code *just work* without having to add an `@using` statement for the code behind file.

Notes: `@namespace` works with conventional Razor views.

<!--
Add a *Pages/_ValidationScriptsPartial.cshtml* file to enable client side validation.

[!code-cs[main](../../../razor-page-intro/RazorPagesSample/Pages/_ValidationScriptsPartial.cshtml)]

-->

The original *Pages/Create.cshtml* view file:

[!code-html[main](../../../razor-page-intro/RazorPagesContacts/Pages/Create.cshtml)]

The updated page:

The *Pages/Create.cshtml* view file:

[!code-html[main](../../../razor-page-intro/RazorPagesContacts2/Pages/Customers/Create.cshtml)]


## URL generation for Pages

Let's suppose we want to do something more useful than showing the same page again when the visitor submits their contact information. We can use `RedirectToPage("/Index")` to redirect to the `Index` page.

This example adds a confirmation message and redirects back to the home page:

*MyApp/Pages/Contact.cshtml*

```html
@page
@inject ApplicationDbContext Db

@functions {

    [BindProperty]
    public Contact Contact { get; set; }
    
    [TempData]
    public string Message { get; set; }
    
    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid)
        {
            Db.Contacts.Add(Contact);
            await Db.SaveChangesAsync();
            
            Message = "Thanks, we'll be in touch shortly.";
            return RedirectToPage("/Index");
        }
        
        return Page();
    }
}


<div class="row">
    <div class="col-md-3">
        <p>Enter your contact info here and we will email you about our fine products!</p> 
        <div asp-validation-summary="All"></div>
        <form method="POST">
            <div>Name: <input asp-for="Contact.Name" /></div>
            <div>Email: <input asp-for="Contact.Email" /></div>
            <input type="submit" />
        </form>
    </div>
</div>
```

*MyApp/Pages/Index.cshtml*

```html
@page

@functions {
    [TempData]
    public string Message { get; set; }
}


<div class="row">
    <div class="col-md-3">
        @if (Message != null)
        {
            <h3>@Message</h3>
        }

        <p>Hi, welcome to our website!</p>
    </div>
</div>
```

We've added another page (*MyApp/Pages/Index.cshtml*), and are redirecting to it using `RedirectToPage("/Index")`. The string `/Index` is part of the URI to access the the preceding page. The string `/Index` can be used to generate URIs to this page. For example:


* `Url.Page("/Index", ...)`
* `<a asp-page="/Index">My Index Page</a>`
* `RedirectToPage("/Index")`


The page name is the path to the page from the root *MyApp/Pages* folder (including a leading `/`, for example `/Index`). It seems simple, but this is much more feature-rich than just hardcoding a URL. This is URL generation using [routing](xref:mvc/controllers/routing), and can generate and encode parameters according to how the route is defined in the destination path.

URL generation for pages supports relative names. From *MyApp/Pages/Contact.cshtml*, you could also redirect to *MyApp/Pages/Index.cshtml* using `RedirectToPage("Index")` or `RedirectToPage("./Index")`. These are both *relative names*. The provided string is *combined* with the page name of the current page to compute the name of the destination page. You can also use the directory traversal `..` operator. 

Relative name linking is useful when building sites with a complex structure. If you use relative names to link between pages in a folder, you can rename that folder. All the links still work (because they didn't include the folder name).

Since we have another page here, we're also taking advantage of the `[TempData]` attribute to pass data across pages. `[TempData]` is a more convenient way to use the existing MVC temp data features. The `[TempData]` attribute is new in 2.0.0 and is supported on controllers and pages. In 2.0.0, the default storage for temp data is now cookies. A session provider is no longer required by default.

### Using multiple handlers

Let's update this form to support multiple operations. A visitor to the site can either join the mailing list or ask for a free quote.

If you want one page to handle multiple logical actions, you can use *named handler methods*. Any text in the name after `On<Verb>` and before `Async` (if present) in the method name is considered a handler name. The handler methods in the following example have the handler names `JoinMailingList` and `RequestQuote`:

*MyApp/Pages/Contact.cshtml*

```html
@page
@inject ApplicationDbContext Db

@functions {

    [BindProperty]
    public Contact Contact { get; set; }
    
    public async Task<IActionResult> OnPostJoinMailingListAsync()
    {
        ...
    }

    public async Task<IActionResult> OnPostRequestQuoteAsync()
    {
        ...
    }
}
<div class="row">
    <div class="col-md-3">
        <p>Enter your contact info here we will email you about our fine products! Or get a free quote!</p>
        <div asp-validation-summary="All"></div>
        <form method="POST">
            <div>Name: <input asp-for="Contact.Name" /></div>
            <div>Email: <input asp-for="Contact.Email" /></div>
            <input type="submit" asp-page-handler="JoinMailingList" value="Join our mailing list"/>
            <input type="submit" asp-page-handler="RequestQuote" value="Get a free quote"/>
        </form>
    </div>
</div>
```

The form in this example has two submit buttons, each using the new `FormActionTagHelper` in conjunction to submit to a different URL. The `asp-handler` attribute is a companion to `asp-page` and generates URLs that submit to each of the handler methods defined by the page. We don't need to specify `asp-page` because we're linking to the current page.

In this case, the URL path that submits to `OnPostJoinMailingListAsync` is `/Contact?handler=JoinMailingList` and the URL path that submits to `OnPostRequestQuoteAsync` is `/Contact?handler=RequestQuote`.

## Customizing Routing

If you don't like seeing `?handler=RequestQuote` in the URL, you can change the route to put the handler name in the path portion of the URL. You can customize the route by adding a route template enclosed in quotes after the `@page` directive.

```c#
@page "{handler?}"
@inject ApplicationDbContext Db

...
```

This route will now put the handler name in the URL path instead of the query string. The `?` following `handler` means this is an optional route parameter.

You can use `@page` to add additional segments and parameters to a page's route. Whatever's there is **appended** to the default route of the page. Using an absolute or virtual path to change the page's route (like `"~/Some/Other/Path"`) is not supported.

### Configuration and settings

Use the extension method `AddRazorPagesOptions` on the MVC builder to configure advanced options such as the following example:

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
