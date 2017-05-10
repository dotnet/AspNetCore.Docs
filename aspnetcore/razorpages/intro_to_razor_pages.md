## Introduction to Razor Pages

Razor Pages is a new feature to ASP.NET Core MVC that makes coding page-focused scenarios easier and more productive.

Razor Pages is included in version 2.0.0 of ASP.NET Core. Tooling support for Razor Pages ships in Visual Studio 2017 Update 3.

### Getting Started

Razor Pages is on by default by MVC. If you are using a typical *Startup.cs* like the following, Razor Pages is enabled:

```
public class Startup
{
    public void ConfigureServices(IServiceCollections services)
    {
        services.AddMvc(); // Includes support for pages and controllers.
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseMvc();
    }
}
```

All of the new Razor Pages types and features are included in the `Microsoft.AspNetCore.Mvc.RazorPages` assembly. If you are referencing the `Microsoft.AspNetCore.Mvc` package, then a reference to the Razor Pages assembly is already included.

Consider  a basic page:

```
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

This looks a lot like a regular Razor view file. What makes it different is the new `@page` directive. Using `@page` makes this file into an MVC action - which means that it can handle requests directly, without going through a controller. `@page` must occur first where it is used, as it affects the behavior of other Razor constructs.

The associations of URL paths to pages is determined by the page's location in the file system. The following table shows a Razor Pages file path and the matching URL:

| File name and path               | mathching URL |
| ----------------- | ------------ | 
| */Pages/Index.cshtml* | `/` or `/Index` | 
| */Pages/Contact.cshtml* | `/Contact` |
| */Pages/Store/Contact.cshtml* | `/Store/Contact` |

### Writing a Simple Form

The new Razor Pages features are designed to make common patterns used with web browsers simple. Consider a page that implements a basic 'contact us' form for a simple model:

For these examples the  model class, and a database/`DbContext` is set up.

The *MyApp/Contact.cs* file which contains the `Contact` model:

```
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

```
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

The  page has a `OnPostAsync` *handler method* which runs on `POST` requests (when a user posts the form). You can add handler methods for any HTTP verb. You most frequently use an `OnGet` handler to initialize any state a needed to show the HTML and `OnPost` to handle form submissions. The `Async` naming suffix is optional, it's often used by convention. The code that's in `OnPostAsync` in the preceeding example looks very similar to what you would normally write in a controller. This is typical for pages; most of the MVC primitives like model binding, validation, and action results are shared.

The basic flow of `OnPostAsync` is:

1. Check for validation errors.
1. If there are no errors, save the data and redirect -
1. Else, show the page again with the validation errors.

When the data is entered successfully, the `OnPostAsync` handler method calls the `RedirctToPage` helper method to return an instance of `RedirectToPageResult`. This is a new action result similar to `RedirectToAction` or `RedirectToRoute` but customized for pages. In the preceeding sample it redirects back to the same URL as the current page (`/Contact`).

When the submitted form has validation errors, the`OnPostAsync` handler method calls the `Page` helper method. `Page` returns an instance of `PageResult`. This is similar to how actions in controllers return `View`. `PageResult` is the default for a handler method. A handler method that returns `void` will render the page.

The `Contact` property is using the new `[BindProperty]` attribute to opt-in to model binding. Pages, by default, bind properties only with non-GET verbs. Binding to properties can reduce the amount of code you have to write by using the same property to render form fields (`<input asp-for="Contacts.Name" />`) and accept the input.

Rather than using `@model` here, we're taking advantage of a special new feature for pages. By default, the generated `Page`-derived class *is* the model. This means that features like model binding, tag helpers and HTML helpers all *just work* with the properties defined in `@functions`. Using a *view model* with Razor views is a best practice. With `Pages` you get getting a view model automatically. 

Notice that this Page also uses `@inject` for dependency injection, which is the same as traditional Razor views - this generates the `Db` property that is used in `OnPostAsync`. Injected (`@inject`)  properties will be set before handler methods run.

You don't have to write any code for antiforgery validation. Antiforgery token generation and validation is automatic for pages. No additional code or attributes are needed to get this security feature.

### Introducing PageModel

You could write this form by partitioning the the view code and the handler method into separate files. The view code:

*MyApp/Pages/Contact.chsml*
```
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

A  a 'code-behind' for the view code:

*MyApp/Pages/Contact.cshtml.cs*

```
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

By convention the `PageModel` class is called `<PageName>Model` and is in the same namespace as the page. Not much change is needed to convert from a page using `@functions` to define handlers and a page using a `PageModel` class. The main change,  add constructor injection for all of your  injected (`@inject`) properties.

Using a `PageModel` supports unit testing, but will require you to write an explicit constructor and class. Pages without `PageModel`s have support runtime compilation, which can be an advantage in development.

### Using the View Engine

Pages work with all of the features of the Razor view engine. That is: layouts, partials, templates, tag helpers, *_ViewStart.cshtml*, *_ViewImports.cstml* all work in the same ways they do for conventional Razor views. 

Let's declutter this page by taking advantage of some of those features. 

Add a layout page for the HTML skeleton, and set the `Layout` property from `_ViewStart.cshtml`:

*MyApp/Pages/_Layout.chsml*

```
<html>
    ...
</html>
```

*MyApp/Pages/_ViewStart.chsml*

```
@{ Layout = "_Layout"; }
```

Notice that we  placed the layout in the *MyApp/Pages* folder. Pages look for other views (layouts, templates, partials) hierarchically, starting in the same folder as the current page. This means that a layout in the *MyApp/Pages* folder can be used from any page.

View search from a page also will include the *MyApp/Views/Shared* folder. Layouts, templates, and partials you're using with MVC controllers and conventional Razor views 'just work'.

Add a *_ViewImports.cshtml* file:

*MyApp/Pages/_ViewImports.chsml*

```
@namespace MyApp.Pages
@using Microsoft.AspNetCore.Mvc.RazorPages
@addTagHelper "*, Microsoft.AspNetCore.Mvc.TagHelpers"
```

The `@namespace` directive is a new feature that will control the namespace of the generated code. The `@namespace` directive allows us to get rid of `@using` directives from the page. The `@namespace` directive works by computing the different in folders between your view code and the `_ViewImports.cshtml` where it appears. Because our *Customer.cshtml* is also in the *MyApp/Pages* folder it will have the namespace `MyApp.Pages`. If the path was  *MyApp/Pages/Store/Customer.cshtml*, the namespace of the generated code would be *MyApp.Pages.Store*. This is intended so that the C# classes you add and pages generated code *just work* without having to add extra usings.

`@namespace` also works for conventional Razor views.

Here's what the page looks like after simplication:

*MyApp/Pages/Contact.chsml*

```
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

### URL Generation for Pages

Let's suppose we want to do something more useful than showing the same page again when the visitor submits their contact information. We can use `RedirectToPage(...)` to redirect to other pages in a few useful ways.

This example adds a confirmation message and redirects back to the home page:

*MyApp/Pages/Contact.chsml*

```
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

**MyApp/Pages/Index.chsml**
```
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

The page name is just the path to the page from the root *MyApp/Pages* folder (including a leading `/`). It seems simple, but this is much more feature rich than just hardcoding a URL. This is URL generation using [routing](xref:mvc/controllers/routing), and can generate and encode parameters accoring to how the route is defined in the destination path.

URL generation for pages supports relative names. From *MyApp/Pages/Contact.cshtml* you could also redirect to *MyApp/Pages/Index.cshtml* using `RedirectToPage("Index")` or `RedirectToPage("./Index")`. These are both *relative names*. The provided string is *combined* with the page name of the current page to compute the name of the destination page. You can also use the directory traversal `..` operator. 

Relative name linking is useful when building sites with a complex structure. If you use relative names to link between pages in a folder, you can you rename that folder. All the links still work (because they didn't include the folder name).


Since we have another page here we're also taking advantage of the `[TempData]` attribute to pass data across pages. `[TempData]` is a more convenient way to use the existing MVC temp data features. The `[TempData]` attribute is new in 2.0.0 and is supported on controlers and pages. In 2.0.0, the default storage for temp data is now cookies. A session provider is no longer required by default.

### Using Multiple Handlers

Let's update this form to support multiple operations. A visitor to the site can either join the mailing list, or ask for a free quote.

If you want one page to handle multiple logical actions you can use *named handler methods*. Any text in the name after `On<Verb>` and before `Async` (if present) in the method name is considered a handler name. The handler methods in the following example have the handler names `JoinMailingList` and `RequestQuote`:

*MyApp/Pages/Contact.chsml*

```
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

The form in this example has two submit buttons, each using the new `FormActionTagHelper` in conjunction to submit to a different URL. The `asp-handler` attribute is a companion to `asp-page` and will generate URLs that will submit to each of the handler methods defined by the page. We don't need to specify `asp-page` because we're linking to the current page.

In this case the URL path that submits to `OnPostJoinMailingListAsync` is `/Contact?handler=JoinMailingList` and the URL path that submits to `OnPostRequestQuoteAsync` is `/Contact?handler=RequestQuote`.

### Customizing Routing

If you don't like seeing `?handler=RequestQuote` in the URL, you can change the route to put the handler name in the path portion of the URL. You can customize the route by adding a route template enclosed in quotes after the `@page` directive.

```
@page "{handler?}"
@inject ApplicationDbContext Db

...
```

This route will now put the handler name in the URL path instead of the query string.

You can use `@page` to add additional segments and parameters to a page's route, whatever's there will be **appended** to the default route of the page. Using an absolute or virtual path to change the page's route (like `"~/Some/Other/Path"`) is not supported.


### Configuration and Settings

Use the extension method `AddRazorPagesOptions` on the MVC builder to configure advanced options such as the following example:

```
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

## Razor Pages: A Manifesto

We think that Razor Pages is a good way to lower the overhead of MVC for simple page-centric scenarios. We're of course interested in your feedback and experiences trying it out.

A few more words about our philosophy for Razor Pages. 

We are trying to:

* Make dynamic HTML and forms with ASP.NET Core easier. For example, how many files and concepts required to print Hello World in a page, build a CRUD form, etc.
* Reduce the number of files and folder-structure required for page-focused MVC scenarios.
*Simplify the code required to implement common page-focused patterns, e.g. dynamic pages, CRUD forms, PRG, etc.
*Allow straightforward migration to and from traditional MVC organization.
* Enable the ability to return non-HTML responses when necessary, for example, 404s.
*Share the existing MVC features as much as possible:

  - MVC's Model Binding and Validation
  - Filters
  - Action Results
  - HTML Helpers and Tag Helpers
  - Existing Razor features like `@inherits`, `@model`, `@inject`
  - Layouts & partials
  - *_ViewStart.cshtml* and *_ViewImports.cshtml*

We are not trying to:

* Create a scripted page framework to compete with PHP, etc.
* Hide C# with a DSL in Razor or otherwise.
* Create new Razor Pages primitives that don't work in controllers.
* Create undue burdens for the ASP.NET team with regards to forking our user-base, tooling support, etc.