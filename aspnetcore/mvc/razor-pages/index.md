---
title: Introduction to Razor Pages in ASP.NET Core | Microsoft Docs
author: Rick-Anderson
description: Overview of Razor Pages in ASP.NET Core | Microsoft Docs
keywords: ASP.NET Core, Razor Pages
ms.author: riande
manager: wpickett
ms.date: 05/10/2017
ms.topic: get-started-article
ms.assetid: 30e4104c-0124-477b-86b3-beb7b34ed3f6
ms.technology: aspnet
ms.prod: asp.net-core
uid: mvc/razor-pages/index
---
## Introduction to Razor Pages in ASP.NET Core

By [Ryan Nowak](https://github.com/rynowak) and [Rick Anderson](https://twitter.com/RickAndMSFT)

Razor Pages is a new feature of ASP.NET Core MVC that makes coding page-focused scenarios easier and more productive.

Razor Pages requires ASP.NET Core 2.0.0 or later. Tooling support for Razor Pages ships in Visual Studio 2017 Update 3 or later.

## Getting started

Razor Pages is on by default in MVC. If you are using a typical *Startup.cs* like the following code, Razor Pages is enabled:

```c#
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc(); // Includes support for pages and controllers.
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseMvc();
    }
}
```

All the new Razor Pages types and features are included in the `Microsoft.AspNetCore.Mvc.RazorPages` assembly. If you are referencing the `Microsoft.AspNetCore.Mvc` package, then a reference to the Razor Pages assembly is already included.

Consider  a basic page:

```html
@page

@{
    var message = "Hello, World!";
}

<html>
<body>
    <p>@message</p>
</body>
</html>
```

The preceeding code looks a lot like a regular Razor view file. What makes it different is the new `@page` directive. Using `@page` makes this file into an MVC action - which means that it can handle requests directly, without going through a controller. `@page` must be the first Razor directive on a page. `@page` affects the behavior of other Razor constructs.

The associations of URL paths to pages are determined by the page's location in the file system. The following table shows a Razor Pages path and the matching URL:

| File name and path               | matching URL |
| ----------------- | ------------ | 
| */Pages/Index.cshtml* | `/` or `/Index` | 
| */Pages/Contact.cshtml* | `/Contact` |
| */Pages/Store/Contact.cshtml* | `/Store/Contact` |

The runtime looks for Razor Pages files in the *Pages* folder by default.

### Writing a basic form

The new Razor Pages features are designed to make common patterns used with web browsers easy. Consider a page that implements a basic 'contact us' form for the `Contact` model:

For the examples on this page, the `DbContext` is initialized in the *Startup.cs* file.

The *MyApp/Contact.cs* file:

```c#
using System.ComponentModel.DataAnnotations;

namespace MyApp 
{
    public class Contact
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
```

The *MyApp/Pages/Contact.cshtml* file:

```html
@page
@using MyApp
@using Microsoft.AspNetCore.Mvc.RazorPages
@addTagHelper "*, Microsoft.AspNetCore.Mvc.TagHelpers"
@inject ApplicationDbContext Db

@functions {
    [BindProperty]
    public Contact Contact { get; set; }
    
    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid)
        {
            Db.Contacts.Add(Contact);
            await Db.SaveChangesAsync();
            return RedirectToPage();
        }
        
        return Page();
    }
}

<html>
<body>
    <p>Enter your contact info here and we will email you about our fine products!</p> 
    <div asp-validation-summary="All"></div>
    <form method="POST">
      <div>Name: <input asp-for="Contact.Name" /></div>
      <div>Email: <input asp-for="Contact.Email" /></div>
      <input type="submit" />
    </form>
</body>
</html>
```

The  page has a `OnPostAsync` *handler method* which runs on `POST` requests (when a user posts the form). You can add handler methods for any HTTP verb. You most frequently use an `OnGet` handler to initialize any state a needed to show the HTML and `OnPost` to handle form submissions. The `Async` naming suffix is optional but is often used by convention. The code that's in `OnPostAsync` in the preceding example looks similar to what you would normally write in a controller. This is typical for pages. Most of the MVC primitives like model binding, validation, and action results are shared.

The basic flow of `OnPostAsync` is:

1. Check for validation errors.
1. If there are no errors, save the data and redirect -
1. Else, show the page again with the validation errors.

When the data is entered successfully, the `OnPostAsync` handler method calls the `RedirectToPage` helper method to return an instance of `RedirectToPageResult`. This is a new action result similar to `RedirectToAction` or `RedirectToRoute` but customized for pages. In the preceding sample it redirects back to the same URL as the current page (`/Contact`). Later I'll show how to redirect to a different page.

When the submitted form has validation errors, the`OnPostAsync` handler method calls the `Page` helper method. `Page` returns an instance of `PageResult`. This is similar to how actions in controllers return `View`. `PageResult` is the default for a handler method. A handler method that returns `void` will render the page.

The `Contact` property is using the new `[BindProperty]` attribute to opt-in to model binding. Pages, by default, bind properties only with non-GET verbs. Binding to properties can reduce the amount of code you have to write by using the same property to render form fields (`<input asp-for="Contacts.Name" />`) and accept the input.

Rather than using `@model` here, we're taking advantage of a special new feature for pages. By default, the generated `Page`-derived class *is* the model. This means that features like model binding, tag helpers, and HTML helpers all *just work* with the properties defined in `@functions`. Using a *view model* with Razor views is a best practice. With pages, you get a view model automatically. 

Notice that this Page also uses `@inject` for dependency injection, which is the same as traditional Razor views - this generates the `Db` property that is used in `OnPostAsync`. Injected (`@inject`) properties are set before handler methods run.

You don't have to write any code for antiforgery validation. Antiforgery token generation and validation is automatic for pages. No additional code or attributes are needed to get this security feature.

## Introducing PageModel

You could write this form by partitioning the view code and the handler method into separate files. The view code:

*MyApp/Pages/Contact.cshtml*

```html
@page
@using MyApp
@using MyApp.Pages
@using Microsoft.AspNetCore.Mvc.RazorPages
@addTagHelper "*, Microsoft.AspNetCore.Mvc.TagHelpers"
@model ContactModel

<html>
<body>
    <p>Enter your contact info here and we will email you about our fine products!</p> 
    <div asp-validation-summary="All"></div>
    <form method="POST">
      <div>Name: <input asp-for="Contact.Name" /></div>
      <div>Email: <input asp-for="Contact.Email" /></div>
      <input type="submit" />
    </form>
</body>
</html>
```

The `PageModel` class, a 'code-behind' file for the view code:

*MyApp/Pages/Contact.cshtml.cs*

```c#
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Pages
{
    public class ContactModel : PageModel
    {
        public ContactModel(ApplicationDbContext db)
        {
            Db = db;
        }

        [BindProperty]
        public Contact Contact { get; set; }
        
        private ApplicationDbContext Db { get; }
    
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                Db.Contacts.Add(Contact);
                await Db.SaveChangesAsync();
                return RedirectToPage();
            }
            
            return Page();
        }
    }
}
```

By convention the `PageModel` class is called `<PageName>Model` and is in the same namespace as the page. Not much change is needed to convert from a page using `@functions` to define handlers and a page using a `PageModel` class. The main change is to add constructor injection for all your injected (`@inject`) properties.

Using a `PageModel` supports unit testing, but requires you to write an explicit constructor and class. Pages without `PageModel` files support runtime compilation, which can be an advantage in development.

## Using the view engine

Pages work with all the features of the Razor view engine. Layouts, partials, templates, tag helpers, *_ViewStart.cshtml*, *_ViewImports.cshtml* all work in the same way they do for conventional Razor views. 

Let's declutter this page by taking advantage of some of those features. 

Add a layout page for the HTML skeleton, and set the `Layout` property from `_ViewStart.cshtml`:

*MyApp/Pages/_Layout.cshtml*

```html
<html>
    ...
</html>
```

*MyApp/Pages/_ViewStart.cshtml*

```c#
@{ Layout = "_Layout"; }
```

Note that we  placed the layout in the *MyApp/Pages* folder. Pages look for other views (layouts, templates, partials) hierarchically, starting in the same folder as the current page. This means that a layout in the *MyApp/Pages* folder can be used from any page.

View search from a page will include the *MyApp/Views/Shared* folder. The layouts, templates, and partials you're using with MVC controllers and conventional Razor views 'just work'.

Add a *_ViewImports.cshtml* file:

*MyApp/Pages/_ViewImports.cshtml*

```c#
@namespace MyApp.Pages
@using Microsoft.AspNetCore.Mvc.RazorPages
@addTagHelper "*, Microsoft.AspNetCore.Mvc.TagHelpers"
```

The `@namespace` directive is a new feature that controls the namespace of the generated code.  If the `@namespace` directive is used explicitly on a page, that page's namespace will match specified namespace exactly. If the `@namespace` directive is contained in *_ViewImports.cshtml*, the specified namespace is only the prefix. The suffix is the dot-seperated relative path between the folder containing *_ViewImports.cshtml* and the folder containing the page.

Because the *Customer.cshtml* and *_ViewImports.cshtml* files are both in the *MyApp/Pages* folder, there is no suffix, so the page will have the namespace *MyApp.Pages*. If the path was *MyApp/Pages/Store/Customer.cshtml*, the namespace of the generated code would be *MyApp.Pages.Store*. If the `@namespace` directive is also changed to `@namespace NotMyApp`, the namespace of the generated code is *NotMyApp.Store*. The `@namespace` directive was designed so the C# classes you add and pages generated code *just work* without having to add extra usings.

`@namespace` also works for conventional Razor views.

Here's what the page looks like after simplification:

*MyApp/Pages/Contact.cshtml*

```html
@page
@inject ApplicationDbContext Db

@functions {

    [BindProperty]
    public Contact Contact { get; set; }
    
    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid)
        {
            Db.Contacts.Add(Contact);
            await Db.SaveChangesAsync();
            return RedirectToPage();
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

We've  added another page (*MyApp/Pages/Index.cshtml*), and are redirecting to it using `RedirectToPage("/Index")`. The string `/Index` is the name of the page we just added, and can be used with `Url.Page(...)`, `<a asp-page="..." />` or `RedirectToPage`.

The page name is just the path to the page from the root *MyApp/Pages* folder (including a leading `/`). It seems simple, but this is much more feature rich than just hardcoding a URL. This is URL generation using [routing](xref:mvc/controllers/routing), and can generate and encode parameters according to how the route is defined in the destination path.

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

This route will now put the handler name in the URL path instead of the query string.

You can use `@page` to add additional segments and parameters to a page's route, whatever's there is **appended** to the default route of the page. Using an absolute or virtual path to change the page's route (like `"~/Some/Other/Path"`) is not supported.


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
