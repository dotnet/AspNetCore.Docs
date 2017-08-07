---
title: Razor Syntax Reference for ASP.NET Core
author: rick-anderson
description: Details Razor syntax
keywords: ASP.NET Core, Razor
ms.author: riande
manager: wpickett
ms.date: 07/4/2017
ms.topic: article
ms.technology: aspnet
ms.prod: asp.net-core
uid: mvc/views/razor
---
# Razor syntax for ASP.NET Core

By [Taylor Mullen](https://twitter.com/ntaylormullen) and [Rick Anderson](https://twitter.com/RickAndMSFT)

## What is Razor?

Razor is a markup syntax for embedding server based code into web pages. The Razor syntax consists of Razor markup, C# and HTML. Files containing Razor generally have a *.cshtml* file extension.

## Rendering HTML

The default Razor language is HTML. Rendering HTML from Razor is no different than in an HTML file. A Razor file with the following markup:

```html
<p>Hello World</p>
   ```

Is rendered unchanged as `<p>Hello World</p>` by the server.

## Razor syntax

Razor supports C# and uses the `@` symbol to transition from HTML to C#. Razor evaluates C# expressions and renders them in the HTML output. Razor can transition from HTML into C# or into Razor-specific markup. When an `@` symbol is followed by a [Razor reserved keyword](#razor-reserved-keywords) it transitions into Razor-specific markup, otherwise it transitions into plain C#.

<a name=escape-at-label></a>

HTML containing `@` symbols may need to be escaped with a second `@` symbol. For example:

```html
<p>@@Username</p>
   ```

would render the following HTML:

```html
<p>@Username</p>
   ```

<a name=razor-email-ref></a>

HTML attributes and content containing email addresses don’t treat the `@` symbol as a transition character.

   `<a href="mailto:Support@contoso.com">Support@contoso.com</a>`

## Implicit Razor expressions

Implicit Razor expressions start with `@` followed by C# code. For example:

```html
<p>@DateTime.Now</p>
<p>@DateTime.IsLeapYear(2016)</p>
```

With the exception of the C# `await` keyword implicit expressions must not contain spaces. For example, you can intermingle spaces as long as the C# statement has a clear ending:

```html
<p>@await DoSomething("hello", "world")</p>
```

## Explicit Razor expressions

Explicit Razor expressions consists of an @ symbol with balanced parenthesis. For example, to render last week's time:

```html
<p>Last week this time: @(DateTime.Now - TimeSpan.FromDays(7))</p>
```

Any content within the @() parenthesis is evaluated and rendered to the output.

Implicit expressions generally cannot contain spaces. For example, in the code below, one week is not subtracted from the current time:

[!code-html[Main](razor/sample/Views/Home/Contact.cshtml?range=20)]

Which renders the following HTML:

```html
<p>Last week: 7/7/2016 4:39:52 PM - TimeSpan.FromDays(7)</p>
   ```

You can use an explicit expression to concatenate text with an expression result:

<!-- literal_block {"ids": [], "linenos": false, "xml:space": "preserve", "language": "none", "highlight_args": {"hl_lines": [5]}} -->

```none
@{
    var joe = new Person("Joe", 33);
 }

<p>Age@(joe.Age)</p>
```

Without the explicit expression, `<p>Age@joe.Age</p>` would be treated as an email address and `<p>Age@joe.Age</p>` would be rendered. When written as an explicit expression, `<p>Age33</p>` is rendered.

<a name=expression-encoding-label></a>

## Expression encoding

C# expressions that evaluate to a string are HTML encoded. C# expressions that evaluate to `IHtmlContent` are rendered directly through *IHtmlContent.WriteTo*. C# expressions that don't evaluate to *IHtmlContent* are converted to a string (by *ToString*) and encoded before they are rendered. For example, the following Razor markup:

```html
@("<span>Hello World</span>")
   ```

Renders this HTML:

```html
&lt;span&gt;Hello World&lt;/span&gt;
   ```

Which the browser renders as:

`<span>Hello World</span>`

`HtmlHelper` `Raw` output is not encoded but rendered as HTML markup.

>[!WARNING]
> Using `HtmlHelper.Raw` on unsanitized user input is a security risk. User input might contain malicious JavaScript or other exploits. Sanitizing user input is difficult, avoid using `HtmlHelper.Raw` on user input.

The following Razor markup:

```html
@Html.Raw("<span>Hello World</span>")
   ```

Renders this HTML:

```html
<span>Hello World</span>
   ```

<a name=razor-code-blocks-label></a>

## Razor code blocks

Razor code blocks start with `@` and are enclosed by `{}`. Unlike expressions, C# code inside code blocks is not rendered. Code blocks and expressions in a Razor page share the same scope and are defined in order (that is, declarations in a code block will be in scope for later code blocks and expressions).

```none
@{
    var output = "Hello World";
}

<p>The rendered result: @output</p>
```

Would render:

```html
<p>The rendered result: Hello World</p>
   ```

<a name=implicit-transitions-label></a>

### Implicit transitions

The default language in a code block is C#, but you can transition back to HTML. HTML within a code block will transition back into rendering HTML:

```none
@{
    var inCSharp = true;
    <p>Now in HTML, was in C# @inCSharp</p>
}
```

<a name=explicit-delimited-transition-label></a>

### Explicit delimited transition

To define a sub-section of a code block that should render HTML, surround the characters to be rendered with the Razor `<text>` tag:

<!-- literal_block {"ids": [], "linenos": false, "xml:space": "preserve", "language": "none", "highlight_args": {"hl_lines": [4]}} -->

```none
@for (var i = 0; i < people.Length; i++)
{
    var person = people[i];
    <text>Name: @person.Name</text>
}
```

You generally use this approach when you want to render HTML that is not surrounded by an HTML tag. Without an HTML or Razor tag, you get a Razor runtime error.

<a name=explicit-line-transition-with-label></a>

### Explicit Line Transition with `@:`

To render the rest of an entire line as HTML inside a code block, use the `@:` syntax:

<!-- literal_block {"ids": [], "linenos": false, "xml:space": "preserve", "language": "none", "highlight_args": {"hl_lines": [4]}} -->

```none
@for (var i = 0; i < people.Length; i++)
{
    var person = people[i];
    @:Name: @person.Name
}
```

Without the `@:` in the code above, you'd get a Razor run time error.

<a name=control-structures-razor-label></a>

## Control Structures

Control structures are an extension of code blocks. All aspects of code blocks (transitioning to markup, inline C#) also apply to the following structures.

### Conditionals `@if`, `else if`, `else` and `@switch`

The `@if` family controls when code runs:

```none
@if (value % 2 == 0)
{
    <p>The value was even</p>
}
```

`else` and `else if` don't require the `@` symbol:

```none
@if (value % 2 == 0)
{
    <p>The value was even</p>
}
else if (value >= 1337)
{
    <p>The value is large.</p>
}
else
{
    <p>The value was not large and is odd.</p>
}
```

You can use a switch statement like this:

```none
@switch (value)
{
    case 1:
        <p>The value is 1!</p>
        break;
    case 1337:
        <p>Your number is 1337!</p>
        break;
    default:
        <p>Your number was not 1 or 1337.</p>
        break;
}
```

### Looping `@for`, `@foreach`, `@while`, and `@do while`

You can render templated HTML with looping control statements. For example, to render a list of people:

```none
@{
    var people = new Person[]
    {
          new Person("John", 33),
          new Person("Doe", 41),
    };
}
```

You can use any of the following looping statements:

`@for`

```none
@for (var i = 0; i < people.Length; i++)
{
    var person = people[i];
    <p>Name: @person.Name</p>
    <p>Age: @person.Age</p>
}
```

`@foreach`

```none
@foreach (var person in people)
{
    <p>Name: @person.Name</p>
    <p>Age: @person.Age</p>
}
```

`@while`

```none
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

```none
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

In C# a using statement is used to ensure an object is disposed. In Razor this same mechanism can be used to create HTML helpers that contain additional content. For instance, we can utilize HTML Helpers to render a form tag with the `@using` statement:

```none
@using (Html.BeginForm())
{
    <div>
        email:
        <input type="email" id="Email" name="Email" value="" />
        <button type="submit"> Register </button>
    </div>
}
```

You can also perform scope level actions like the above with [Tag Helpers](tag-helpers/index.md).

### `@try`, `catch`, `finally`

Exception handling is similar to  C#:

[!code-html[Main](razor/sample/Views/Home/Contact7.cshtml)]

### `@lock`

Razor has the capability to protect critical sections with lock statements:

```none
@lock (SomeLock)
{
    // Do critical section work
}
```

### Comments

Razor supports C# and HTML comments. The following markup:

```none
@{
    /* C# comment. */
    // Another C# comment.
}
<!-- HTML comment -->
```

Is rendered by the server as:

```none
<!-- HTML comment -->
```

Razor comments are removed by the server before the page is rendered. Razor uses `@*  *@` to delimit comments. The following code is commented out, so the server will not render any markup:

```none
 @*
 @{
     /* C# comment. */
     // Another C# comment.
 }
 <!-- HTML comment -->
*@
```

<a name=razor-directives-label></a>

## Directives

Razor directives are represented by implicit expressions with reserved keywords following the `@` symbol. A directive will typically change the way a page is parsed or enable different functionality within your Razor page.

Understanding how Razor generates code for a view will make it easier to understand how directives work. A Razor page is used to generate a C# file. For example, this Razor page:

[!code-html[Main](razor/sample/Views/Home/Contact8.cshtml)]

Generates a class similar to the following:

```csharp
public class _Views_Something_cshtml : RazorPage<dynamic>
{
    public override async Task ExecuteAsync()
    {
        var output = "Hello World";

        WriteLiteral("/r/n<div>Output: ");
        Write(output);
        WriteLiteral("</div>");
    }
}
```

[Viewing the Razor C# class generated for a view](#razor-customcompilationservice-label) explains how to view this generated class.

### `@using`

The `@using` directive will add the c# `using` directive to the generated razor page:

[!code-html[Main](razor/sample/Views/Home/Contact9.cshtml)]

### `@model`

The `@model` directive specifies the type of the model passed to the Razor page. It uses the following syntax:

```none
@model TypeNameOfModel
   ```

For example, if you create an ASP.NET Core MVC app with individual user accounts, the *Views/Account/Login.cshtml* Razor view contains the following model declaration:

```csharp
@model LoginViewModel
   ```

In the preceding class example, the class generated inherits from `RazorPage<dynamic>`. By adding an `@model` you control what’s inherited. For example

```csharp
@model LoginViewModel
   ```

Generates the following class

```csharp
public class _Views_Account_Login_cshtml : RazorPage<LoginViewModel>
   ```

Razor pages expose a `Model` property for accessing the model passed to the page.

```html
<div>The Login Email: @Model.Email</div>
   ```

The `@model` directive specified the type of this property (by specifying the `T` in `RazorPage<T>` that the generated class for your page derives from). If you don't specify the `@model` directive the `Model` property will be of type `dynamic`. The value of the model is passed from the controller to the view. See [Strongly typed models and the @model keyword](../../tutorials/first-mvc-app/adding-model.md#strongly-typed-models-keyword-label) for more information.

### `@inherits`

The `@inherits` directive gives you full control of the class your Razor page inherits:

```none
@inherits TypeNameOfClassToInheritFrom
   ```

For instance, let’s say we had the following custom Razor page type:

[!code-csharp[Main](razor/sample/Classes/CustomRazorPage.cs)]

The following Razor would generate `<div>Custom text: Hello World</div>`.

[!code-html[Main](razor/sample/Views/Home/Contact10.cshtml)]

You can't use `@model` and `@inherits` on the same page. You can have `@inherits` in a *_ViewImports.cshtml* file that the Razor page imports. For example, if your Razor view imported the following *_ViewImports.cshtml* file:

[!code-html[Main](razor/sample/Views/_ViewImportsModel.cshtml)]

The following strongly typed Razor page

[!code-html[Main](razor/sample/Views/Home/Login1.cshtml)]

Generates this HTML markup:

```none
<div>The Login Email: Rick@contoso.com</div>
<div>Custom text: Hello World</div>
```

When passed "[Rick@contoso.com](mailto:Rick@contoso.com)" in the model:

   See [Layout](layout.md) for more information.

### `@inject`

The `@inject` directive enables you to inject a service from your [service container](../../fundamentals/dependency-injection.md)  into your Razor page for use. See [Dependency injection into views](dependency-injection.md).

<a name="functions"></a>

### `@functions`

The `@functions` directive enables you to add function level content to your Razor page. The syntax is:

```none
@functions { // C# Code }
   ```

For example:

[!code-html[Main](razor/sample/Views/Home/Contact6.cshtml)]

Generates the following HTML markup:

```none
<div>From method: Hello</div>
   ```

The generated Razor C# looks like:

[!code-csharp[Main](razor/sample/Classes/Views_Home_Test_cshtml.cs?range=1-19)]

### `@section`

The `@section` directive is used in conjunction with the [layout page](layout.md) to enable views to render content in different parts of the rendered HTML page. See [Sections](layout.md#layout-sections-label) for more information.

## Tag Helpers

The following [Tag Helpers](tag-helpers/index.md) directives are detailed in the links provided.

* [@addTagHelper](tag-helpers/intro.md#add-helper-label)
* [@removeTagHelper](tag-helpers/intro.md#remove-razor-directives-label)
* [@tagHelperPrefix](tag-helpers/intro.md#prefix-razor-directives-label)

<a name=razor-reserved-keywords-label></a>

## Razor reserved keywords

### Razor keywords

* page (Requires ASP.NET Core 2.0 and later)
* functions
* inherits
* model
* section
* helper   (Not supported by ASP.NET Core.)

Razor keywords can be escaped with `@(Razor Keyword)`, for example `@(functions)`. See the complete sample below.

### C# Razor keywords

* case
* do
* default
* for
* foreach
* if
* else
* lock
* switch
* try
* catch
* finally
* using
* while

C# Razor keywords need to be double escaped with `@(@C# Razor Keyword)`, for example `@(@case)`. The first `@` escapes the Razor parser, the second `@` escapes the C# parser. See the complete sample below.

### Reserved keywords not used by Razor

* namespace
* class

<a name=razor-customcompilationservice-label></a>

## Viewing the Razor C# class generated for a view

Add the following class to your ASP.NET Core MVC project:

[!code-csharp[Main](razor/sample/Services/CustomCompilationService.cs)]

Override the `ICompilationService` added by MVC with the above class;

[!code-csharp[Main](razor/sample/Startup.cs?highlight=4&range=29-33)]

Set a break point on the `Compile` method of `CustomCompilationService` and view `compilationContent`.

![Text Visualizer view of compilationContent](razor/_static/tvr.png)

<a name="case"></a>
## View lookups and case sensitivity

The Razor view engine performs case-sensitive lookups for views. However, the actual lookup is determined by the underlying source:

* File based source: 

    * On operating systems with case insensitive file systems (like Windows), physical file provider lookups are case insensitive. For example `return View("Test")` would result in `/Views/Home/Test.cshtml`, `/Views/home/test.cshtml` and all other casing variants would be discovered.
    * On case sensitive file systems, which includes Linux, OSX and `EmbeddedFileProvider`, lookups are case sensitive. For example, `return View("Test")` would specifically look for `/Views/Home/Test.cshtml`.
        
* Precompiled views:

   * With ASP.Net Core 2.0 and later, looking up precompiled views is case insensitive on all operating systems. The behavior is identical to physical file provider's behavior on Windows. 
   Note: If two precompiled views differ only in case, the result of lookup is non-deterministic.

Developers are encouraged to match the casing of file and directory names to the casing of area, controller and action names. This would ensure your deployments remain agnostic of the underlying file system.
