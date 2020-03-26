# Scaffolded Razor Pages in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT)

This tutorial examines the Razor Pages created by scaffolding in the previous tutorial.

[View or download](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie21) sample.

## The Create, Delete, Details, and Edit pages.

Examine the *Pages/Movies/Index.cshtml.cs* Page Model:

::: moniker range="= aspnetcore-2.0"

[!code-csharp[](~/tutorials/razor-pages/razor-pages-start/snapshot_sample/RazorPagesMovie/Pages/Movies/Index.cshtml.cs)]

::: moniker-end

::: moniker range=">= aspnetcore-2.1"

[!code-csharp[](~/tutorials/razor-pages/razor-pages-start/snapshot_sample/RazorPagesMovie/Pages/Movies/Index21.cshtml.cs)]

::: moniker-end

Razor Pages are derived from `PageModel`. By convention, the `PageModel`-derived class is called `<PageName>Model`. The constructor uses [dependency injection](xref:fundamentals/dependency-injection) to add the `MovieContext` to the page. All the scaffolded pages follow this pattern. See [Asynchronous code](xref:data/ef-rp/intro#asynchronous-code) for more information on asynchronous programming with Entity Framework.

When a request is made for the page, the `OnGetAsync` method returns a list of movies to the Razor Page. `OnGetAsync` or `OnGet` is called on a Razor Page to initialize the state for the page. In this case, `OnGetAsync` gets a list of movies and displays them.

When `OnGet` returns `void` or `OnGetAsync` returns`Task`, no return method is used. When the return type is `IActionResult` or `Task<IActionResult>`, a return statement must be provided. For example, the *Pages/Movies/Create.cshtml.cs* `OnPostAsync` method:

[!code-csharp[](~/tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie21/Pages/Movies/Create.cshtml.cs?name=snippet)]

<a name="index"></a>
Examine the *Pages/Movies/Index.cshtml* Razor Page:

[!code-cshtml[](~/tutorials/razor-pages/razor-pages-start/snapshot_sample/RazorPagesMovie/Pages/Movies/Index.cshtml)]

Razor can transition from HTML into C# or into Razor-specific markup. When an `@` symbol is followed by a [Razor reserved keyword](xref:mvc/views/razor#razor-reserved-keywords), it transitions into Razor-specific markup, otherwise it transitions into C#.

The `@page` Razor directive makes the file into an MVC action &mdash; which means that it can handle requests. `@page` must be the first Razor directive on a page. `@page` is an example of transitioning into Razor-specific markup. See [Razor syntax](xref:mvc/views/razor#razor-syntax) for more information.

Examine the lambda expression used in the following HTML Helper:

```cshtml
@Html.DisplayNameFor(model => model.Movie[0].Title))
```

The `DisplayNameFor` HTML Helper inspects the `Title` property referenced in the lambda expression to determine the display name. The lambda expression is inspected rather than evaluated. That means there is no access violation when `model`, `model.Movie`, or `model.Movie[0]` are `null` or empty. When the lambda expression is evaluated (for example, with `@Html.DisplayFor(modelItem => item.Title)`), the model's property values are evaluated.

<a name="md"></a>

### The @model directive

[!code-cshtml[](~/tutorials/razor-pages/razor-pages-start/snapshot_sample/RazorPagesMovie/Pages/Movies/Index.cshtml?range=1-2&highlight=2)]

The `@model` directive specifies the type of the model passed to the Razor Page. In the preceding example, the `@model` line makes the `PageModel`-derived class available to the Razor Page. The model is used in the `@Html.DisplayNameFor` and `@Html.DisplayFor` [HTML Helpers](/aspnet/mvc/overview/older-versions-1/views/creating-custom-html-helpers-cs#understanding-html-helpers) on the page.

<!-- why don't xref links work?
[HTML Helpers 2](xref:aspnet/mvc/overview/older-versions-1/views/creating-custom-html-helpers-cs)
-->

<a name="vd"></a>

### ViewData and layout

Consider the following code:

[!code-cshtml[](~/tutorials/razor-pages/razor-pages-start/snapshot_sample/RazorPagesMovie/Pages/Movies/Index.cshtml?range=1-6&highlight=4-999)]

The preceding highlighted code is an example of Razor transitioning into C#. The `{` and `}` characters enclose a block of C# code.

The `PageModel` base class has a `ViewData` dictionary property that can be used to add data that you want to pass to a View. You add objects into the `ViewData` dictionary using a key/value pattern. In the preceding sample, the "Title" property is added to the `ViewData` dictionary.

::: moniker range="= aspnetcore-2.0"

The "Title" property is used in the *Pages/Shared/_Layout.cshtml* file. The following markup shows the first few lines of the *Pages/Shared/_Layout.cshtml* file.

::: moniker-end

::: moniker range=">= aspnetcore-2.1"

The "Title" property is used in the *Pages/Shared/_Layout.cshtml* file. The following markup shows the first few lines of the *_Layout.cshtml* file.

::: moniker-end

[!code-cshtml[](~/tutorials/razor-pages/razor-pages-start/snapshot_sample/RazorPagesMovie/Pages/NU/_Layout1.cshtml?highlight=6-999)]

The line `@*Markup removed for brevity.*@` is a Razor comment. Unlike HTML comments (`<!-- -->`), Razor comments are not sent to the client.

Run the app and test the links in the project (**Home**, **About**, **Contact**, **Create**, **Edit**, and **Delete**). Each page sets the title, which you can see in the browser tab. When you bookmark a page, the title is used for the bookmark. *Pages/Index.cshtml* and *Pages/Movies/Index.cshtml* currently have the same title, but you can modify them to have different values.

> [!NOTE]
> You may not be able to enter decimal commas in the `Price` field. To support [jQuery validation](https://jqueryvalidation.org/) for non-English locales that use a comma (",") for a decimal point, and non US-English date formats, you must take steps to globalize your app. This [GitHub issue 4076](https://github.com/dotnet/AspNetCore.Docs/issues/4076#issuecomment-326590420) for instructions on adding decimal comma.

The `Layout` property is set in the *Pages/_ViewStart.cshtml* file:

[!code-cshtml[](~/tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie/Pages/_ViewStart.cshtml)]

The preceding markup sets the layout file to *Pages/Shared/_Layout.cshtml* for all Razor files under the *Pages* folder. See [Layout](xref:razor-pages/index#layout) for more information.

### Update the layout

Change the `<title>` element in the *Pages/Shared/_Layout.cshtml* file to use a shorter string.

[!code-cshtml[](~/tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie/Pages/_Layout.cshtml?range=1-6&highlight=6)]

Find the following anchor element in the *Pages/Shared/_Layout.cshtml* file.

```cshtml
<a asp-page="/Index" class="navbar-brand">RazorPagesMovie</a>
```

Replace the preceding element with the following markup.

```cshtml
<a asp-page="/Movies/Index" class="navbar-brand">RpMovie</a>
```

The preceding anchor element is a [Tag Helper](xref:mvc/views/tag-helpers/intro). In this case, it's the [Anchor Tag Helper](xref:mvc/views/tag-helpers/builtin-th/anchor-tag-helper). The `asp-page="/Movies/Index"` Tag Helper attribute and value creates a link to the `/Movies/Index` Razor Page.

Save your changes, and test the app by clicking on the **RpMovie** link. See the [_Layout.cshtml](https://github.com/dotnet/AspNetCore.Docs/blob/master/aspnetcore/tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie/Pages/Shared/_Layout.cshtml) file in GitHub.

### The Create page model

Examine the *Pages/Movies/Create.cshtml.cs* page model:

::: moniker range="= aspnetcore-2.0"

[!code-csharp[](~/tutorials/razor-pages/razor-pages-start/snapshot_sample/RazorPagesMovie/Pages/Movies/Create.cshtml.cs?name=snippetALL)]

::: moniker-end

::: moniker range=">= aspnetcore-2.1"

[!code-csharp[](~/tutorials/razor-pages/razor-pages-start/snapshot_sample/RazorPagesMovie/Pages/Movies/Create21.cshtml.cs?name=snippetALL)]

::: moniker-end

The `OnGet` method initializes any state needed for the page. The Create page doesn't have any state to initialize, so `Page` is returned. Later in the tutorial you see `OnGet` method initialize state. The `Page` method creates a `PageResult` object that renders the *Create.cshtml* page.

The `Movie` property uses the `[BindProperty]` attribute to opt-in to [model binding](xref:mvc/models/model-binding). When the Create form posts the form values, the ASP.NET Core runtime binds the posted values to the `Movie` model.

The `OnPostAsync` method is run when the page posts form data:

[!code-csharp[](~/tutorials/razor-pages/razor-pages-start/snapshot_sample/RazorPagesMovie/Pages/Movies/Create.cshtml.cs?name=snippetPost)]

If there are any model errors, the form is redisplayed, along with any form data posted. Most model errors can be caught on the client-side before the form is posted. An example of a model error is posting a value for the date field that cannot be converted to a date. We'll talk more about client-side validation and model validation later in the tutorial.

If there are no model errors, the data is saved, and the browser is redirected to the Index page.

### The Create Razor Page

Examine the *Pages/Movies/Create.cshtml* Razor Page file:

[!code-cshtml[](~/tutorials/razor-pages/razor-pages-start/snapshot_sample/RazorPagesMovie/Pages/Movies/Create.cshtml)]

<!--
Visual Studio displays the `<form method="post">` tag in a distinctive font used for Tag Helpers. The `<form method="post">` element is a [Form Tag Helper](xref:mvc/views/working-with-forms#the-form-tag-helper). The Form Tag Helper automatically includes an [antiforgery token](xref:security/anti-request-forgery).

![VS17 view of Create.cshtml page](page/_static/th.png)
-->
