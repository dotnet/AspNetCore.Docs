---
title: Razor syntax reference for ASP.NET Core
author: rick-anderson
description: Learn about Razor markup syntax for embedding server-based code into webpages.
ms.author: riande
ms.date: 02/12/2020
uid: mvc/views/razor
---
# Razor syntax reference for ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT), [Taylor Mullen](https://twitter.com/ntaylormullen), and [Dan Vicarel](https://github.com/Rabadash8820)

Razor is a markup syntax for embedding .NET based code into webpages. The Razor syntax consists of Razor markup, C#, and HTML. Files containing Razor generally have a `.cshtml` file extension. Razor is also found in [Razor component](xref:blazor/components/index) files (`.razor`). Razor syntax is similar to the templating engines of various JavaScript single-page application (SPA) frameworks, such as Angular, React, VueJs, and Svelte. For more information see, <xref:client-side/spa-services>.

[Introduction to ASP.NET Web Programming Using the Razor Syntax](/aspnet/web-pages/overview/getting-started/introducing-razor-syntax-c) provides many samples of programming with Razor syntax. Although the topic was written for ASP.NET rather than ASP.NET Core, most of the samples apply to ASP.NET Core.

## Rendering HTML

The default Razor language is HTML. Rendering HTML from Razor markup is no different than rendering HTML from an HTML file. HTML markup in `.cshtml` Razor files is rendered by the server unchanged.

## Razor syntax

Razor supports C# and uses the `@` symbol to transition from HTML to C#. Razor evaluates C# expressions and renders them in the HTML output.

When an `@` symbol is followed by a [Razor reserved keyword](#razor-reserved-keywords), it transitions into Razor-specific markup. Otherwise, it transitions into plain HTML.

To escape an `@` symbol in Razor markup, use a second `@` symbol:

```cshtml
<p>@@Username</p>
```

The code is rendered in HTML with a single `@` symbol:

```html
<p>@Username</p>
```

HTML attributes and content containing email addresses don't treat the `@` symbol as a transition character. The email addresses in the following example are untouched by Razor parsing:

```cshtml
<a href="mailto:Support@contoso.com">Support@contoso.com</a>
```


:::moniker range=">= aspnetcore-6.0"

### Scalable Vector Graphics (SVG)

[SVG](https://developer.mozilla.org/docs/Web/SVG) [foreignObject](https://developer.mozilla.org/docs/Web/SVG/Element/foreignObject) elements are supported:

```html
@{
    string message = "foreignObject example with Scalable Vector Graphics (SVG)";
}

<svg width="200" height="200" xmlns="http://www.w3.org/2000/svg">
    <rect x="0" y="0" rx="10" ry="10" width="200" height="200" stroke="black" 
        fill="none" />
    <foreignObject x="20" y="20" width="160" height="160">
        <p>@message</p>
    </foreignObject>
</svg>
```

:::moniker-end

## Implicit Razor expressions

Implicit Razor expressions start with `@` followed by C# code:

```cshtml
<p>@DateTime.Now</p>
<p>@DateTime.IsLeapYear(2016)</p>
```

With the exception of the C# `await` keyword, implicit expressions must not contain spaces. If the C# statement has a clear ending, spaces can be intermingled:

```cshtml
<p>@await DoSomething("hello", "world")</p>
```

Implicit expressions **cannot** contain C# generics, as the characters inside the brackets (`<>`) are interpreted as an HTML tag. The following code is **not** valid:

```cshtml
<p>@GenericMethod<int>()</p>
```

The preceding code generates a compiler error similar to one of the following:

* The "int" element wasn't closed. All elements must be either self-closing or have a matching end tag.
* Cannot convert method group 'GenericMethod' to non-delegate type 'object'. Did you intend to invoke the method?`

Generic method calls must be wrapped in an [explicit Razor expression](#explicit-razor-expressions) or a [Razor code block](#razor-code-blocks).

## Explicit Razor expressions

Explicit Razor expressions consist of an `@` symbol with balanced parenthesis. To render last week's time, the following Razor markup is used:

```cshtml
<p>Last week this time: @(DateTime.Now - TimeSpan.FromDays(7))</p>
```

Any content within the `@()` parenthesis is evaluated and rendered to the output.

Implicit expressions, described in the previous section, generally can't contain spaces. In the following code, one week isn't subtracted from the current time:

[!code-cshtml[](razor/sample/Views/Home/Contact.cshtml?range=17)]

The code renders the following HTML:

```html
<p>Last week: 7/7/2016 4:39:52 PM - TimeSpan.FromDays(7)</p>
```

Explicit expressions can be used to concatenate text with an expression result:

```cshtml
@{
    var joe = new Person("Joe", 33);
}

<p>Age@(joe.Age)</p>
```

Without the explicit expression, `<p>Age@joe.Age</p>` is treated as an email address, and `<p>Age@joe.Age</p>` is rendered. When written as an explicit expression, `<p>Age33</p>` is rendered.

Explicit expressions can be used to render output from generic methods in `.cshtml` files. The following markup shows how to correct the error shown earlier caused by the brackets of a C# generic. The code is written as an explicit expression:

```cshtml
<p>@(GenericMethod<int>())</p>
```

## Expression encoding

C# expressions that evaluate to a string are HTML encoded. C# expressions that evaluate to `IHtmlContent` are rendered directly through `IHtmlContent.WriteTo`. C# expressions that don't evaluate to `IHtmlContent` are converted to a string by `ToString` and encoded before they're rendered.

```cshtml
@("<span>Hello World</span>")
```

The preceding code renders the following HTML:

```html
&lt;span&gt;Hello World&lt;/span&gt;
```

The HTML is shown in the browser as plain text:

&lt;span&gt;Hello World&lt;/span&gt;

`HtmlHelper.Raw` output isn't encoded but rendered as HTML markup.

> [!WARNING]
> Using `HtmlHelper.Raw` on unsanitized user input is a security risk. User input might contain malicious JavaScript or other exploits. Sanitizing user input is difficult. Avoid using `HtmlHelper.Raw` with user input.

```cshtml
@Html.Raw("<span>Hello World</span>")
```

The code renders the following HTML:

```html
<span>Hello World</span>
```

## Razor code blocks

Razor code blocks start with `@` and are enclosed by `{}`. Unlike expressions, C# code inside code blocks isn't rendered. Code blocks and expressions in a view share the same scope and are defined in order:

```cshtml
@{
    var quote = "The future depends on what you do today. - Mahatma Gandhi";
}

<p>@quote</p>

@{
    quote = "Hate cannot drive out hate, only love can do that. - Martin Luther King, Jr.";
}

<p>@quote</p>
```

The code renders the following HTML:

```html
<p>The future depends on what you do today. - Mahatma Gandhi</p>
<p>Hate cannot drive out hate, only love can do that. - Martin Luther King, Jr.</p>
```

In code blocks, declare [local functions](/dotnet/csharp/programming-guide/classes-and-structs/local-functions) with markup to serve as templating methods:

```cshtml
@{
    void RenderName(string name)
    {
        <p>Name: <strong>@name</strong></p>
    }

    RenderName("Mahatma Gandhi");
    RenderName("Martin Luther King, Jr.");
}
```

The code renders the following HTML:

```html
<p>Name: <strong>Mahatma Gandhi</strong></p>
<p>Name: <strong>Martin Luther King, Jr.</strong></p>
```

### Implicit transitions

The default language in a code block is C#, but the Razor Page can transition back to HTML:

```cshtml
@{
    var inCSharp = true;
    <p>Now in HTML, was in C# @inCSharp</p>
}
```

### Explicit delimited transition

To define a subsection of a code block that should render HTML, surround the characters for rendering with the Razor `<text>` tag:

```cshtml
@for (var i = 0; i < people.Length; i++)
{
    var person = people[i];
    <text>Name: @person.Name</text>
}
```

Use this approach to render HTML that isn't surrounded by an HTML tag. Without an HTML or Razor tag, a Razor runtime error occurs.

The `<text>` tag is useful to control whitespace when rendering content:

* Only the content between the `<text>` tag is rendered.
* No whitespace before or after the `<text>` tag appears in the HTML output.

### Explicit line transition

To render the rest of an entire line as HTML inside a code block, use `@:` syntax:

```cshtml
@for (var i = 0; i < people.Length; i++)
{
    var person = people[i];
    @:Name: @person.Name
}
```

Without the `@:` in the code, a Razor runtime error is generated.

Extra `@` characters in a Razor file can cause compiler errors at statements later in the block. These extra `@` compiler errors:

* Can be difficult to understand because the actual error occurs before the reported error.
* Is common after combining multiple implicit and explicit expressions into a single code block.

### Conditional attribute rendering

Razor automatically omits attributes that aren't needed. If the value passed in is `null` or `false`, the attribute isn't rendered.

For example,  consider the following razor:

```cshtml
<div class="@false">False</div>
<div class="@null">Null</div>
<div class="@("")">Empty</div>
<div class="@("false")">False String</div>
<div class="@("active")">String</div>
<input type="checkbox" checked="@true" name="true" />
<input type="checkbox" checked="@false" name="false" />
<input type="checkbox" checked="@null" name="null" />
```

The preceding Razor markup generates the following HTML:

```html
<div>False</div>
<div>Null</div>
<div class="">Empty</div>
<div class="false">False String</div>
<div class="active">String</div>
<input type="checkbox" checked="checked" name="true">
<input type="checkbox" name="false">
<input type="checkbox" name="null">
```

## Control structures

Control structures are an extension of code blocks. All aspects of code blocks (transitioning to markup, inline C#) also apply to the following structures:

### Conditionals `@if, else if, else, and @switch`

`@if` controls when code runs:

```cshtml
@if (value % 2 == 0)
{
    <p>The value was even.</p>
}
```

`else` and `else if` don't require the `@` symbol:

```cshtml
@if (value % 2 == 0)
{
    <p>The value was even.</p>
}
else if (value >= 1337)
{
    <p>The value is large.</p>
}
else
{
    <p>The value is odd and small.</p>
}
```

The following markup shows how to use a switch statement:

```cshtml
@switch (value)
{
    case 1:
        <p>The value is 1!</p>
        break;
    case 1337:
        <p>Your number is 1337!</p>
        break;
    default:
        <p>Your number wasn't 1 or 1337.</p>
        break;
}
```

### Looping `@for, @foreach, @while, and @do while`

Templated HTML can be rendered with looping control statements. To render a list of people:

```cshtml
@{
    var people = new Person[]
    {
          new Person("Weston", 33),
          new Person("Johnathon", 41),
          ...
    };
}
```

The following looping statements are supported:

`@for`

```cshtml
@for (var i = 0; i < people.Length; i++)
{
    var person = people[i];
    <p>Name: @person.Name</p>
    <p>Age: @person.Age</p>
}
```

`@foreach`

```cshtml
@foreach (var person in people)
{
    <p>Name: @person.Name</p>
    <p>Age: @person.Age</p>
}
```

`@while`

```cshtml
@{ var i = 0; }
@while (i < people.Length)
{
    var person = people[i];
    <p>Name: @person.Name</p>
    <p>Age: @person.Age</p>

    i++;
}
```

`@do while`

```cshtml
@{ var i = 0; }
@do
{
    var person = people[i];
    <p>Name: @person.Name</p>
    <p>Age: @person.Age</p>

    i++;
} while (i < people.Length);
```

### Compound `@using`

In C#, a `using` statement is used to ensure an object is disposed. In Razor, the same mechanism is used to create HTML Helpers that contain additional content. In the following code, HTML Helpers render a `<form>` tag with the `@using` statement:

```cshtml
@using (Html.BeginForm())
{
    <div>
        Email: <input type="email" id="Email" value="">
        <button>Register</button>
    </div>
}
```

### `@try, catch, finally`

Exception handling is similar to C#:

[!code-cshtml[](razor/sample/Views/Home/Contact7.cshtml)]

### `@lock`

Razor has the capability to protect critical sections with lock statements:

```cshtml
@lock (SomeLock)
{
    // Do critical section work
}
```

### Comments

Razor supports C# and HTML comments:

```cshtml
@{
    /* C# comment */
    // Another C# comment
}
<!-- HTML comment -->
```

The code renders the following HTML:

```html
<!-- HTML comment -->
```

Razor comments are removed by the server before the webpage is rendered. Razor uses `@*  *@` to delimit comments. The following code is commented out, so the server doesn't render any markup:

```cshtml
@*
    @{
        /* C# comment */
        // Another C# comment
    }
    <!-- HTML comment -->
*@
```

## Directives

Razor directives are represented by implicit expressions with reserved keywords following the `@` symbol. A directive typically changes the way a view is parsed or enables different functionality.

Understanding how Razor generates code for a view makes it easier to understand how directives work.

[!code-cshtml[](razor/sample/Views/Home/Contact8.cshtml)]

The code generates a class similar to the following:

```csharp
public class _Views_Something_cshtml : RazorPage<dynamic>
{
    public override async Task ExecuteAsync()
    {
        var output = "Getting old ain't for wimps! - Anonymous";

        WriteLiteral("/r/n<div>Quote of the Day: ");
        Write(output);
        WriteLiteral("</div>");
    }
}
```

Later in this article, the section [Inspect the Razor C# class generated for a view](#inspect-the-razor-c-class-generated-for-a-view) explains how to view this generated class.

### `@attribute`

The `@attribute` directive adds the given attribute to the class of the generated page or view. The following example adds the `[Authorize]` attribute:

```cshtml
@attribute [Authorize]
```

The `@attribute` directive can also be used to supply a constant-based route template in a Razor component. In the following example, the `@page` directive in a component is replaced with the `@attribute` directive and the constant-based route template in `Constants.CounterRoute`, which is set elsewhere in the app to "`/counter`":

```diff
- @page "/counter"
+ @attribute [Route(Constants.CounterRoute)]
```

### `@code`

*This scenario only applies to Razor components (`.razor`).*

The `@code` block enables a [Razor component](xref:blazor/components/index) to add C# members (fields, properties, and methods) to a component:

```razor
@code {
    // C# members (fields, properties, and methods)
}
```

For Razor components, `@code` is an alias of [`@functions`](#functions) and recommended over `@functions`. More than one `@code` block is permissible.

### `@functions`

The `@functions` directive enables adding C# members (fields, properties, and methods) to the generated class:

```cshtml
@functions {
    // C# members (fields, properties, and methods)
}
```

In [Razor components](xref:blazor/components/index), use `@code` over `@functions` to add C# members.

For example:

[!code-cshtml[](razor/sample/Views/Home/Contact6.cshtml)]

The code generates the following HTML markup:

```html
<div>From method: Hello</div>
```

The following code is the generated Razor C# class:

[!code-csharp[](razor/sample/Classes/Views_Home_Test_cshtml.cs?range=1-19)]

`@functions` methods serve as templating methods when they have markup:

```cshtml
@{
    RenderName("Mahatma Gandhi");
    RenderName("Martin Luther King, Jr.");
}

@functions {
    private void RenderName(string name)
    {
        <p>Name: <strong>@name</strong></p>
    }
}
```

The code renders the following HTML:

```html
<p>Name: <strong>Mahatma Gandhi</strong></p>
<p>Name: <strong>Martin Luther King, Jr.</strong></p>
```

### `@implements`

The `@implements` directive implements an interface for the generated class.

The following example implements <xref:System.IDisposable?displayProperty=fullName> so that the <xref:System.IDisposable.Dispose*> method can be called:

```cshtml
@implements IDisposable

<h1>Example</h1>

@functions {
    private bool _isDisposed;

    ...

    public void Dispose() => _isDisposed = true;
}
```

### `@inherits`

The `@inherits` directive provides full control of the class the view inherits:

```cshtml
@inherits TypeNameOfClassToInheritFrom
```

The following code is a custom Razor page type:

[!code-csharp[](razor/sample/Classes/CustomRazorPage.cs)]

The `CustomText` is displayed in a view:

[!code-cshtml[](razor/sample/Views/Home/Contact10.cshtml)]

The code renders the following HTML:

```html
<div>
    Custom text: Gardyloo! - A Scottish warning yelled from a window before dumping
    a slop bucket on the street below.
</div>
```

 `@model` and `@inherits` can be used in the same view. `@inherits` can be in a `_ViewImports.cshtml` file that the view imports:

[!code-cshtml[](razor/sample/Views/_ViewImportsModel.cshtml)]

The following code is an example of a strongly-typed view:

[!code-cshtml[](razor/sample/Views/Home/Login1.cshtml)]

If "rick@contoso.com" is passed in the model, the view generates the following HTML markup:

```html
<div>The Login Email: rick@contoso.com</div>
<div>
    Custom text: Gardyloo! - A Scottish warning yelled from a window before dumping
    a slop bucket on the street below.
</div>
```

### `@inject`

The `@inject` directive enables the Razor Page to inject a service from the [service container](xref:fundamentals/dependency-injection) into a view. For more information, see [Dependency injection into views](xref:mvc/views/dependency-injection).

### `@layout`

*This scenario only applies to Razor components (`.razor`).*

The `@layout` directive specifies a layout for routable Razor components that have an [`@page`](#page) directive. Layout components are used to avoid code duplication and inconsistency. For more information, see <xref:blazor/components/layouts>.

### `@model`

*This scenario only applies to MVC views and Razor Pages (`.cshtml`).*

The `@model` directive specifies the type of the model passed to a view or page:

```cshtml
@model TypeNameOfModel
```

In an ASP.NET Core MVC or Razor Pages app created with individual user accounts, `Views/Account/Login.cshtml` contains the following model declaration:

```cshtml
@model LoginViewModel
```

The class generated inherits from `RazorPage<LoginViewModel>`:

```csharp
public class _Views_Account_Login_cshtml : RazorPage<LoginViewModel>
```

Razor exposes a `Model` property for accessing the model passed to the view:

```cshtml
<div>The Login Email: @Model.Email</div>
```

The `@model` directive specifies the type of the `Model` property. The directive specifies the `T` in `RazorPage<T>` that the generated class that the view derives from. If the `@model` directive isn't specified, the `Model` property is of type `dynamic`. For more information, see [Strongly typed models and the @model keyword](xref:tutorials/first-mvc-app/adding-model#strongly-typed-models-and-the--keyword).

### `@namespace`

The `@namespace` directive:

* Sets the namespace of the class of the generated Razor page, MVC view, or Razor component.
* Sets the root derived namespaces of a pages, views, or components classes from the closest imports file in the directory tree, `_ViewImports.cshtml` (views or pages) or `_Imports.razor` (Razor components).

```cshtml
@namespace Your.Namespace.Here
```

For the Razor Pages example shown in the following table:

* Each page imports `Pages/_ViewImports.cshtml`.
* `Pages/_ViewImports.cshtml` contains `@namespace Hello.World`.
* Each page has `Hello.World` as the root of it's namespace.

| Page                                        | Namespace                             |
| ------------------------------------------- | ------------------------------------- |
| `Pages/Index.cshtml`                        | `Hello.World`                         |
| `Pages/MorePages/Page.cshtml`               | `Hello.World.MorePages`               |
| `Pages/MorePages/EvenMorePages/Page.cshtml` | `Hello.World.MorePages.EvenMorePages` |

The preceding relationships apply to import files used with MVC views and Razor components.

When multiple import files have a `@namespace` directive, the file closest to the page, view, or component in the directory tree is used to set the root namespace.

If the `EvenMorePages` folder in the preceding example has an imports file with `@namespace Another.Planet` (or the `Pages/MorePages/EvenMorePages/Page.cshtml` file contains `@namespace Another.Planet`), the result is shown in the following table.

| Page                                        | Namespace               |
| ------------------------------------------- | ----------------------- |
| `Pages/Index.cshtml`                        | `Hello.World`           |
| `Pages/MorePages/Page.cshtml`               | `Hello.World.MorePages` |
| `Pages/MorePages/EvenMorePages/Page.cshtml` | `Another.Planet`        |

### `@page`

The `@page` directive has different effects depending on the type of the file where it appears. The directive:

* In a `.cshtml` file indicates that the file is a Razor Page. For more information, see [Custom routes](xref:razor-pages/index#custom-routes) and <xref:razor-pages/index>.
* Specifies that a Razor component should handle requests directly. For more information, see <xref:blazor/fundamentals/routing>.

:::moniker range=">= aspnetcore-5.0"

### `@preservewhitespace`

*This scenario only applies to Razor components (`.razor`).*

When set to `false` (default), whitespace in the rendered markup from Razor components (`.razor`) is removed if:

* Leading or trailing within an element.
* Leading or trailing within a `RenderFragment` parameter. For example, child content passed to another component.
* It precedes or follows a C# code block, such as `@if` or `@foreach`.

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

### `@rendermode`

*This scenario only applies to Razor components (`.razor`).*

Sets the render mode of a Razor component:

* `InteractiveServer`: Applies interactive server rendering using Blazor Server.
* `InteractiveWebAssembly`: Applies interactive WebAssembly rendering using Blazor WebAssembly.
* `InteractiveAuto`: Initially applies interactive WebAssembly rendering using Blazor Server, and then applies interactive WebAssembly rendering using WebAssembly on subsequent visits after the Blazor bundle is downloaded.

For a component instance:

```razor
<... @rendermode="InteractiveServer" />
```

In the component definition:

```razor
@rendermode InteractiveServer
```

> [!NOTE]
> Blazor templates include a static `using` directive for <xref:Microsoft.AspNetCore.Components.Web.RenderMode> in the app's `_Imports` file (`Components/_Imports.razor`) for shorter `@rendermode` syntax:
>
> ```razor
> @using static Microsoft.AspNetCore.Components.Web.RenderMode
> ```
>
> Without the preceding directive, components must specify the static <xref:Microsoft.AspNetCore.Components.Web.RenderMode> class in `@rendermode` syntax explicitly:
>
> ```razor
> <Dialog @rendermode="RenderMode.InteractiveServer" />
> ```

For more information, including guidance on disabling prerendering with the directive/directive attribute, see <xref:blazor/components/render-modes>.

:::moniker-end

### `@section`

*This scenario only applies to MVC views and Razor Pages (`.cshtml`).*

The `@section` directive is used in conjunction with [MVC and Razor Pages layouts](xref:mvc/views/layout) to enable views or pages to render content in different parts of the HTML page. For more information, see <xref:mvc/views/layout>.

### `@typeparam`

*This scenario only applies to Razor components (`.razor`).*

The `@typeparam` directive declares a [generic type parameter](/dotnet/csharp/programming-guide/generics/generic-type-parameters) for the generated component class:

```razor
@typeparam TEntity
```

:::moniker range=">= aspnetcore-6.0"

Generic types with [`where`](/dotnet/csharp/language-reference/keywords/where-generic-type-constraint) type constraints are supported:

```razor
@typeparam TEntity where TEntity : IEntity
```

:::moniker-end

For more information, see the following articles:

* <xref:blazor/components/generic-type-support>
* <xref:blazor/components/templated-components>

### `@using`

The `@using` directive adds the C# `using` directive to the generated view:

[!code-cshtml[](razor/sample/Views/Home/Contact9.cshtml)]

In [Razor components](xref:blazor/components/index), `@using` also controls which components are in scope.

## Directive attributes

Razor directive attributes are represented by implicit expressions with reserved keywords following the `@` symbol. A directive attribute typically changes the way an element is parsed or enables different functionality.

### `@attributes`

*This scenario only applies to Razor components (`.razor`).*

`@attributes` allows a component to render non-declared attributes. For more information, see <xref:blazor/components/attribute-splatting>.

### `@bind`

*This scenario only applies to Razor components (`.razor`).*

Data binding in components is accomplished with the `@bind` attribute. For more information, see <xref:blazor/components/data-binding>.

### `@bind:culture`

*This scenario only applies to Razor components (`.razor`).*

Use the `@bind:culture` attribute with the [`@bind`](#bind) attribute to provide a <xref:System.Globalization.CultureInfo?displayProperty=fullName> for parsing and formatting a value. For more information, see <xref:blazor/globalization-localization#globalization>.

### `@on{EVENT}`

*This scenario only applies to Razor components (`.razor`).*

Razor provides event handling features for components. For more information, see <xref:blazor/components/event-handling>.

### `@on{EVENT}:preventDefault`

*This scenario only applies to Razor components (`.razor`).*

Prevents the default action for the event.

### `@on{EVENT}:stopPropagation`

*This scenario only applies to Razor components (`.razor`).*

Stops event propagation for the event.

### `@key`

*This scenario only applies to Razor components (`.razor`).*

The `@key` directive attribute causes the components diffing algorithm to guarantee preservation of elements or components based on the key's value. For more information, see <xref:blazor/components/key>.

### `@ref`

*This scenario only applies to Razor components (`.razor`).*

Component references (`@ref`) provide a way to reference a component instance so that you can issue commands to that instance. For more information, see <xref:blazor/components/index#capture-references-to-components>.

## Templated Razor delegates

*This scenario only applies to MVC views and Razor Pages (`.cshtml`).*

Razor templates allow you to define a UI snippet with the following format:

```cshtml
@<tag>...</tag>
```

The following example illustrates how to specify a templated Razor delegate as a <xref:System.Func%602>. The [dynamic type](/dotnet/csharp/programming-guide/types/using-type-dynamic) is specified for the parameter of the method that the delegate encapsulates. An [object type](/dotnet/csharp/language-reference/keywords/object) is specified as the return value of the delegate. The template is used with a <xref:System.Collections.Generic.List%601> of `Pet` that has a `Name` property.

```csharp
public class Pet
{
    public string Name { get; set; }
}
```

```cshtml
@{
    Func<dynamic, object> petTemplate = @<p>You have a pet named <strong>@item.Name</strong>.</p>;

    var pets = new List<Pet>
    {
        new Pet { Name = "Rin Tin Tin" },
        new Pet { Name = "Mr. Bigglesworth" },
        new Pet { Name = "K-9" }
    };
}
```

The template is rendered with `pets` supplied by a `foreach` statement:

```cshtml
@foreach (var pet in pets)
{
    @petTemplate(pet)
}
```

Rendered output:

```html
<p>You have a pet named <strong>Rin Tin Tin</strong>.</p>
<p>You have a pet named <strong>Mr. Bigglesworth</strong>.</p>
<p>You have a pet named <strong>K-9</strong>.</p>
```

You can also supply an inline Razor template as an argument to a method. In the following example, the `Repeat` method receives a Razor template. The method uses the template to produce HTML content with repeats of items supplied from a list:

```cshtml
@using Microsoft.AspNetCore.Html

@functions {
    public static IHtmlContent Repeat(IEnumerable<dynamic> items, int times,
        Func<dynamic, IHtmlContent> template)
    {
        var html = new HtmlContentBuilder();

        foreach (var item in items)
        {
            for (var i = 0; i < times; i++)
            {
                html.AppendHtml(template(item));
            }
        }

        return html;
    }
}
```

Using the list of pets from the prior example, the `Repeat` method is called with:

* <xref:System.Collections.Generic.List%601> of `Pet`.
* Number of times to repeat each pet.
* Inline template to use for the list items of an unordered list.

```cshtml
<ul>
    @Repeat(pets, 3, @<li>@item.Name</li>)
</ul>
```

Rendered output:

```html
<ul>
    <li>Rin Tin Tin</li>
    <li>Rin Tin Tin</li>
    <li>Rin Tin Tin</li>
    <li>Mr. Bigglesworth</li>
    <li>Mr. Bigglesworth</li>
    <li>Mr. Bigglesworth</li>
    <li>K-9</li>
    <li>K-9</li>
    <li>K-9</li>
</ul>
```

## Tag Helpers

*This scenario only applies to MVC views and Razor Pages (`.cshtml`).*

There are three directives that pertain to [Tag Helpers](xref:mvc/views/tag-helpers/intro).

| Directive | Function |
| --------- | -------- |
| [`@addTagHelper`](xref:mvc/views/tag-helpers/intro#add-helper-label) | Makes Tag Helpers available to a view. |
| [`@removeTagHelper`](xref:mvc/views/tag-helpers/intro#remove-razor-directives-label) | Removes Tag Helpers previously added from a view. |
| [`@tagHelperPrefix`](xref:mvc/views/tag-helpers/intro#prefix-razor-directives-label) | Specifies a tag prefix to enable Tag Helper support and to make Tag Helper usage explicit. |

## Razor reserved keywords

### Razor keywords

* `page`
* `namespace`
* `functions`
* `inherits`
* `model`
* `section`
* `helper` (Not currently supported by ASP.NET Core)

Razor keywords are escaped with `@(Razor Keyword)` (for example, `@(functions)`).

### C# Razor keywords

* `case`
* `do`
* `default`
* `for`
* `foreach`
* `if`
* `else`
* `lock`
* `switch`
* `try`
* `catch`
* `finally`
* `using`
* `while`

C# Razor keywords must be double-escaped with `@(@C# Razor Keyword)` (for example, `@(@case)`). The first `@` escapes the Razor parser. The second `@` escapes the C# parser.

### Reserved keywords not used by Razor

* `class`

## Inspect the Razor C# class generated for a view

::: moniker range=">= aspnetcore-5.0"

The [Razor SDK](xref:razor-pages/sdk) handles compilation of Razor files. By default, the generated code files aren't emitted. To enable emitting the code files, set the `EmitCompilerGeneratedFiles` directive in the project file (`.csproj`) to `true`:

```xml
<PropertyGroup>
  <EmitCompilerGeneratedFiles>true</EmitCompilerGeneratedFiles>
</PropertyGroup>
```

When building a 6.0 project (`net6.0`) in the `Debug` build configuration, the Razor SDK generates an `obj/Debug/net6.0/generated/` directory in the project root. Its subdirectory contains the emitted Razor page code files.

::: moniker-end

::: moniker range="< aspnetcore-5.0"

The [Razor SDK](xref:razor-pages/sdk) handles compilation of Razor files. When building a project, the Razor SDK generates an `obj/{BUILD CONFIGURATION}/{TARGET FRAMEWORK MONIKER}/Razor` directory in the project root. The directory structure within the `Razor` directory mirrors the project's directory structure.

Consider the following directory structure in an ASP.NET Core Razor Pages 2.1 project:

```
 Areas/
   Admin/
     Pages/
       Index.cshtml
       Index.cshtml.cs
 Pages/
   Shared/
     _Layout.cshtml
   _ViewImports.cshtml
   _ViewStart.cshtml
   Index.cshtml
   Index.cshtml.cs
```

Building the project in `Debug` configuration yields the following `obj` directory:

```
 obj/
   Debug/
     netcoreapp2.1/
       Razor/
         Areas/
           Admin/
             Pages/
               Index.g.cshtml.cs
         Pages/
           Shared/
             _Layout.g.cshtml.cs
           _ViewImports.g.cshtml.cs
           _ViewStart.g.cshtml.cs
           Index.g.cshtml.cs
```

To view the generated class for `Pages/Index.cshtml`, open `obj/Debug/netcoreapp2.1/Razor/Pages/Index.g.cshtml.cs`.

::: moniker-end

## View lookups and case sensitivity

The Razor view engine performs case-sensitive lookups for views. However, the actual lookup is determined by the underlying file system:

* File based source:
  * On operating systems with case insensitive file systems (for example, Windows), physical file provider lookups are case insensitive. For example, `return View("Test")` results in matches for `/Views/Home/Test.cshtml`, `/Views/home/test.cshtml`, and any other casing variant.
  * On case-sensitive file systems (for example, Linux, OSX, and with `EmbeddedFileProvider`), lookups are case-sensitive. For example, `return View("Test")` specifically matches `/Views/Home/Test.cshtml`.
* Precompiled views: With ASP.NET Core 2.0 and later, looking up precompiled views is case insensitive on all operating systems. The behavior is identical to physical file provider's behavior on Windows. If two precompiled views differ only in case, the result of lookup is non-deterministic.

Developers are encouraged to match the casing of file and directory names to the casing of:

* Area, controller, and action names.
* Razor Pages.

Matching case ensures the deployments find their views regardless of the underlying file system.

## Imports used by Razor

The following imports are generated by the ASP.NET Core web templates to support Razor Files:

```
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
```

## Additional resources

[Introduction to ASP.NET Web Programming Using the Razor Syntax](/aspnet/web-pages/overview/getting-started/introducing-razor-syntax-c) provides many samples of programming with Razor syntax.
