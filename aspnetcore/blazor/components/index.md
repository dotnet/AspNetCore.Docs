---
title: ASP.NET Core Razor components
author: guardrex
description: Learn how to create and use Razor components in Blazor apps, including guidance on Razor syntax, component naming, namespaces, and component parameters.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/14/2023
uid: blazor/components/index
---
# ASP.NET Core Razor components

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to create and use Razor components in Blazor apps, including guidance on Razor syntax, component naming, namespaces, and component parameters.

[!INCLUDE[](~/blazor/includes/location-client-and-server-pre-net8.md)]

## Razor components

Blazor apps are built using *Razor components*, informally known as *Blazor components* or only *components*. A component is a self-contained portion of user interface (UI) with processing logic to enable dynamic behavior. Components can be nested, reused, shared among projects, and used in MVC and Razor Pages apps.

Components render into an in-memory representation of the browser's [Document Object Model (DOM)](https://developer.mozilla.org/docs/Web/API/Document_Object_Model/Introduction) called a *render tree*, which is used to update the UI in a flexible and efficient way.

## Component classes

Components are implemented using a combination of C# and HTML markup in [Razor](xref:mvc/views/razor) component files with the `.razor` file extension.

By default, <xref:Microsoft.AspNetCore.Components.ComponentBase> is the base class for components described by Razor component files. <xref:Microsoft.AspNetCore.Components.ComponentBase> implements the lowest abstraction of components, the <xref:Microsoft.AspNetCore.Components.IComponent> interface. <xref:Microsoft.AspNetCore.Components.ComponentBase> defines component properties and methods for basic functionality, for example, to process a set of built-in component lifecycle events.

[`ComponentBase` in `dotnet/aspnetcore` reference source](https://github.com/dotnet/aspnetcore/blob/main/src/Components/Components/src/ComponentBase.cs): The reference source contains additional remarks on the built-in lifecycle events. However, keep in mind that the internal implementations of component features are subject to change at any time without notice.

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

Developers typically create Razor components from Razor component files (`.razor`) or base their components on <xref:Microsoft.AspNetCore.Components.ComponentBase>, but components can also be built by implementing <xref:Microsoft.AspNetCore.Components.IComponent>. Developer-built components that implement <xref:Microsoft.AspNetCore.Components.IComponent> can take low-level control over rendering at the cost of having to manually trigger rendering with events and lifecycle methods that the developer must create and maintain.

### Razor syntax

Components use [Razor syntax](xref:mvc/views/razor). Two Razor features are extensively used by components, *directives* and *directive attributes*. These are reserved keywords prefixed with `@` that appear in Razor markup:

* [Directives](xref:mvc/views/razor#directives): Change the way component markup is parsed or functions. For example, the [`@page`][9] directive specifies a routable component with a route template and can be reached directly by a user's request in the browser at a specific URL.

  By convention, a component's directives at the top of a component definition (`.razor` file) are placed in a consistent order. For repeated directives, directives are placed alphabetically by namespace or type, except `@using` directives, which have special second-level ordering.
  
  The following order is adopted by Blazor sample apps and documentation. Components provided by a Blazor project template may differ from the following order and use a different format. For example, Blazor framework Identity components include blank lines between blocks of `@using` directives and blocks of `@inject` directives. You're free to use a custom ordering scheme and format in your own apps.

  Documentation and sample app Razor directive order:

  * `@page`
  * `@rendermode` (.NET 8 or later)
  * `@using`
    * `System` namespaces (alphabetical order)
    * `Microsoft` namespaces (alphabetical order)
    * Third-party API namespaces (alphabetical order)
    * App namespaces (alphabetical order)
  * Other directives (alphabetical order)

  No blank lines appear among the directives. One blank line appears between the directives and the first line of Razor markup.

  Example:

  ```razor
  @page "/doctor-who-episodes/{season:int}"
  @rendermode InteractiveWebAssembly
  @using System.Globalization
  @using System.Text.Json
  @using Microsoft.AspNetCore.Localization
  @using Mandrill
  @using BlazorSample.Components.Layout
  @attribute [Authorize]
  @implements IAsyncDisposable
  @inject IJSRuntime JS
  @inject ILogger<DoctorWhoEpisodes> Logger

  <PageTitle>Doctor Who Episode List</PageTitle>

  ...
  ```

* [Directive attributes](xref:mvc/views/razor#directive-attributes): Change the way a component element is parsed or functions.

  Example:

  ```razor
  <input @bind="episodeId" />
  ```

Directives and directive attributes used in components are explained further in this article and other articles of the Blazor documentation set. For general information on Razor syntax, see <xref:mvc/views/razor>.

### Component name, class name, and namespace

:::moniker range=">= aspnetcore-8.0"

A component's name must start with an uppercase character:

<span aria-hidden="true">✔️</span><span class="visually-hidden">Supported:</span> `ProductDetail.razor`

<span aria-hidden="true">❌</span><span class="visually-hidden">Unsupported:</span> `productDetail.razor`

Common Blazor naming conventions used throughout the Blazor documentation include:

* File paths and file names use Pascal case&dagger; and appear before showing code examples. If a path is present, it indicates the typical folder location. For example, `Components/Pages/ProductDetail.razor` indicates that the `ProductDetail` component has a file name of `ProductDetail.razor` and resides in the `Pages` folder of the `Components` folder of the app.
* Component file paths for routable components match their URLs in kebab case&Dagger; with hyphens appearing between words in a component's route template. For example, a `ProductDetail` component with a route template of `/product-detail` (`@page "/product-detail"`) is requested in a browser at the relative URL `/product-detail`.

&dagger;Pascal case (upper camel case) is a naming convention without spaces and punctuation and with the first letter of each word capitalized, including the first word.  
&Dagger;Kebab case is a naming convention without spaces and punctuation that uses lowercase letters and dashes between words.

Components are ordinary [C# classes](/dotnet/csharp/programming-guide/classes-and-structs/classes) and can be placed anywhere within a project. Components that produce webpages usually reside in the `Components/Pages` folder. Non-page components are frequently placed in the `Components` folder or a custom folder added to the project.

Typically, a component's namespace is derived from the app's root namespace and the component's location (folder) within the app. If the app's root namespace is `BlazorSample` and the `Counter` component resides in the `Components/Pages` folder:

* The `Counter` component's namespace is `BlazorSample.Components.Pages`.
* The fully qualified type name of the component is `BlazorSample.Components.Pages.Counter`.

For custom folders that hold components, add an [`@using`][2] directive to the parent component or to the app's `_Imports.razor` file. The following example makes components in the `AdminComponents` folder available:

```razor
@using BlazorSample.AdminComponents
```

> [!NOTE]
> [`@using`][2] directives in the `_Imports.razor` file are only applied to Razor files (`.razor`), not C# files (`.cs`).

Aliased [`using`](/dotnet/csharp/language-reference/keywords/using-directive) statements are supported. In the following example, the public `WeatherForecast` class of the `GridRendering` component is made available as `WeatherForecast` in a component elsewhere in the app:

```razor
@using WeatherForecast = Components.Pages.GridRendering.WeatherForecast
```

Components can also be referenced using their fully qualified names, which doesn't require an [`@using`][2] directive. The following example directly references the `ProductDetail` component in the `AdminComponents/Pages` folder of the app:

```razor
<BlazorSample.AdminComponents.Pages.ProductDetail />
```

The namespace of a component authored with Razor is based on the following (in priority order):

* The [`@namespace`][8] directive in the Razor file's markup (for example, `@namespace BlazorSample.CustomNamespace`).
* The project's `RootNamespace` in the project file (for example, `<RootNamespace>BlazorSample</RootNamespace>`).
* The project namespace and the path from the project root to the component. For example, the framework resolves `{PROJECT NAMESPACE}/Components/Pages/Home.razor` with a project namespace of `BlazorSample` to the namespace `BlazorSample.Components.Pages` for the `Home` component. `{PROJECT NAMESPACE}` is the project namespace. Components follow C# name binding rules. For the `Home` component in this example, the components in scope are all of the components:
  * In the same folder, `Components/Pages`.
  * The components in the project's root that don't explicitly specify a different namespace.

The following are **not** supported:

* The [`global::`](/dotnet/csharp/language-reference/operators/namespace-alias-qualifier) qualification.
* Partially-qualified names. For example, you can't add `@using BlazorSample.Components` to a component and then reference the `NavMenu` component in the app's `Components/Layout` folder (`Components/Layout/NavMenu.razor`) with `<Layout.NavMenu></Layout.NavMenu>`.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

A component's name must start with an uppercase character:

<span aria-hidden="true">✔️</span><span class="visually-hidden">Supported:</span> `ProductDetail.razor`

<span aria-hidden="true">❌</span><span class="visually-hidden">Unsupported:</span> `productDetail.razor`

Common Blazor naming conventions used throughout the Blazor documentation include:

* File paths and file names use Pascal case&dagger; and appear before showing code examples. If a path is present, it indicates the typical folder location. For example, `Pages/ProductDetail.razor` indicates that the `ProductDetail` component has a file name of `ProductDetail.razor` and resides in the `Pages` folder of the app.
* Component file paths for routable components match their URLs in kebab case&Dagger; with hyphens appearing between words in a component's route template. For example, a `ProductDetail` component with a route template of `/product-detail` (`@page "/product-detail"`) is requested in a browser at the relative URL `/product-detail`.

&dagger;Pascal case (upper camel case) is a naming convention without spaces and punctuation and with the first letter of each word capitalized, including the first word.  
&Dagger;Kebab case is a naming convention without spaces and punctuation that uses lowercase letters and dashes between words.

Components are ordinary [C# classes](/dotnet/csharp/programming-guide/classes-and-structs/classes) and can be placed anywhere within a project. Components that produce webpages usually reside in the `Pages` folder. Non-page components are frequently placed in the `Shared` folder or a custom folder added to the project.

Typically, a component's namespace is derived from the app's root namespace and the component's location (folder) within the app. If the app's root namespace is `BlazorSample` and the `Counter` component resides in the `Pages` folder:

* The `Counter` component's namespace is `BlazorSample.Pages`.
* The fully qualified type name of the component is `BlazorSample.Pages.Counter`.

For custom folders that hold components, add an [`@using`][2] directive to the parent component or to the app's `_Imports.razor` file. The following example makes components in the `AdminComponents` folder available:

```razor
@using BlazorSample.AdminComponents
```

> [!NOTE]
> [`@using`][2] directives in the `_Imports.razor` file are only applied to Razor files (`.razor`), not C# files (`.cs`).

Aliased [`using`](/dotnet/csharp/language-reference/keywords/using-directive) statements are supported. In the following example, the public `WeatherForecast` class of the `GridRendering` component is made available as `WeatherForecast` in a component elsewhere in the app:

```razor
@using WeatherForecast = Pages.GridRendering.WeatherForecast
```

Components can also be referenced using their fully qualified names, which doesn't require an [`@using`][2] directive. The following example directly references the `ProductDetail` component in the `Components` folder of the app:

```razor
<BlazorSample.Components.ProductDetail />
```

The namespace of a component authored with Razor is based on the following (in priority order):

* The [`@namespace`][8] directive in the Razor file's markup (for example, `@namespace BlazorSample.CustomNamespace`).
* The project's `RootNamespace` in the project file (for example, `<RootNamespace>BlazorSample</RootNamespace>`).
* The project namespace and the path from the project root to the component. For example, the framework resolves `{PROJECT NAMESPACE}/Pages/Index.razor` with a project namespace of `BlazorSample` to the namespace `BlazorSample.Pages` for the `Index` component. `{PROJECT NAMESPACE}` is the project namespace. Components follow C# name binding rules. For the `Index` component in this example, the components in scope are all of the components:
  * In the same folder, `Pages`.
  * The components in the project's root that don't explicitly specify a different namespace.

The following are **not** supported:

* The [`global::`](/dotnet/csharp/language-reference/operators/namespace-alias-qualifier) qualification.
* Partially-qualified names. For example, you can't add `@using BlazorSample` to a component and then reference the `NavMenu` component in the app's `Shared` folder (`Shared/NavMenu.razor`) with `<Shared.NavMenu></Shared.NavMenu>`.

:::moniker-end

### Partial class support

Components are generated as [C# partial classes](/dotnet/csharp/programming-guide/classes-and-structs/partial-classes-and-methods) and are authored using either of the following approaches:

* A single file contains C# code defined in one or more [`@code`][1] blocks, HTML markup, and Razor markup. Blazor project templates define their components using this single-file approach.
* HTML and Razor markup are placed in a Razor file (`.razor`). C# code is placed in a code-behind file defined as a partial class (`.cs`).

:::moniker range=">= aspnetcore-5.0"

> [!NOTE]
> A component stylesheet that defines component-specific styles is a separate file (`.css`). Blazor CSS isolation is described later in <xref:blazor/components/css-isolation>.

:::moniker-end

The following example shows the default `Counter` component with an [`@code`][1] block in an app generated from a Blazor project template. Markup and C# code are in the same file. This is the most common approach taken in component authoring.

`Counter.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/Counter.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/Counter.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/Counter.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/Counter.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/Counter.razor":::

:::moniker-end

The following `Counter` component splits presentation HTML and Razor markup from the C# code using a code-behind file with a partial class. Splitting the markup from the C# code is favored by some organizations and developers to organize their component code to suit how they prefer to work. For example, the organization's UI expert can work on the presentation layer independently of another developer working on the component's C# logic. The approach is also useful when working with automatically-generated code or source generators. For more information, see [Partial Classes and Methods (C# Programming Guide)](/dotnet/csharp/programming-guide/classes-and-structs/partial-classes-and-methods).

`CounterPartialClass.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/CounterPartialClass.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/index/CounterPartialClass.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/index/CounterPartialClass.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/index/CounterPartialClass.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/index/CounterPartialClass.razor":::

:::moniker-end

`CounterPartialClass.razor.cs`:

:::moniker range=">= aspnetcore-8.0"

:::code language="csharp" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/CounterPartialClass.razor.cs":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

```csharp
namespace BlazorSample.Pages;

public partial class CounterPartialClass
{
    private int currentCount = 0;

    private void IncrementCount()
    {
        currentCount++;
    }
}
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```csharp
namespace BlazorSample.Pages
{
    public partial class CounterPartialClass
    {
        private int currentCount = 0;

        private void IncrementCount()
        {
            currentCount++;
        }
    }
}
```

:::moniker-end

[`@using`][2] directives in the `_Imports.razor` file are only applied to Razor files (`.razor`), not C# files (`.cs`). Add namespaces to a partial class file as needed.

Typical namespaces used by components:

:::moniker range=">= aspnetcore-8.0"

```csharp
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Sections
using Microsoft.AspNetCore.Components.Web;
using static Microsoft.AspNetCore.Components.Web.RenderMode;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
```

Typical namespaces also include the namespace of the app and the namespace corresponding to the app's `Components` folder:

```csharp
using BlazorSample;
using BlazorSample.Components;
```

Additional folders can also be included, such as the `Layout` folder:

```razor
using BlazorSample.Components.Layout;
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

```csharp
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
```

Typical namespaces also include the namespace of the app and the namespace corresponding to the app's `Shared` folder:

```csharp
using BlazorSample;
using BlazorSample.Shared;
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```csharp
using System.Net.Http;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
```

Typical namespaces also include the namespace of the app and the namespace corresponding to the app's `Shared` folder:

```csharp
using BlazorSample;
using BlazorSample.Shared;
```

:::moniker-end

### Specify a base class

The [`@inherits`][6] directive is used to specify a base class for a component. Unlike using [partial classes](#partial-class-support), which only split markup from C# logic, using a base class allows you to inherit C# code for use across a group of components that share the base class's properties and methods. Using base classes reduce code redundancy in apps and are useful when supplying base code from class libraries to multiple apps. For more information, see [Inheritance in C# and .NET](/dotnet/csharp/fundamentals/tutorials/inheritance).

In the following example, the `BlazorRocksBase1` base class derives from <xref:Microsoft.AspNetCore.Components.ComponentBase>.

`BlazorRocks1.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/BlazorRocks1.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/index/BlazorRocks1.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/index/BlazorRocks1.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/index/BlazorRocks1.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/index/BlazorRocks1.razor":::

:::moniker-end

`BlazorRocksBase1.cs`:

:::moniker range=">= aspnetcore-8.0"

:::code language="csharp" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/BlazorRocksBase1.cs":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="csharp" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/BlazorRocksBase1.cs":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="csharp" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/BlazorRocksBase1.cs":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="csharp" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/BlazorRocksBase1.cs":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="csharp" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/BlazorRocksBase1.cs":::

:::moniker-end

### Routing

Routing in Blazor is achieved by providing a route template to each accessible component in the app with an [`@page`][9] directive. When a Razor file with an [`@page`][9] directive is compiled, the generated class is given a <xref:Microsoft.AspNetCore.Mvc.RouteAttribute> specifying the route template. At runtime, the router searches for component classes with a <xref:Microsoft.AspNetCore.Mvc.RouteAttribute> and renders whichever component has a route template that matches the requested URL.

The following `HelloWorld` component uses a route template of `/hello-world`, and the rendered webpage for the component is reached at the relative URL `/hello-world`.

`HelloWorld.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/HelloWorld.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/index/HelloWorld.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/index/HelloWorld.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/index/HelloWorld.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/index/HelloWorld.razor":::

:::moniker-end

The preceding component loads in the browser at `/hello-world` regardless of whether or not you add the component to the app's UI navigation. Optionally, components can be added to the `NavMenu` component so that a link to the component appears in the app's UI-based navigation.

For the preceding `HelloWorld` component, you can add a `NavLink` component to the `NavMenu` component. For more information, including descriptions of the `NavLink` and `NavMenu` components, see <xref:blazor/fundamentals/routing>.

### Markup

A component's UI is defined using [Razor syntax](xref:mvc/views/razor), which consists of Razor markup, C#, and HTML. When an app is compiled, the HTML markup and C# rendering logic are converted into a component class. The name of the generated class matches the name of the file.

Members of the component class are defined in one or more [`@code`][1] blocks. In [`@code`][1] blocks, component state is specified and processed with C#:

* Property and field initializers.
* Parameter values from arguments passed by parent components and route parameters.
* Methods for user event handling, lifecycle events, and custom component logic.

Component members are used in rendering logic using C# expressions that start with the `@` symbol. For example, a C# field is rendered by prefixing `@` to the field name. The following `Markup` component evaluates and renders:

* `headingFontStyle` for the CSS property value `font-style` of the heading element.
* `headingText` for the content of the heading element.

`Markup.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/Markup.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/index/Markup.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/index/Markup.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/index/Markup.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/index/Markup.razor":::

:::moniker-end

> [!NOTE]
> Examples throughout the Blazor documentation specify the [`private` access modifier](/dotnet/csharp/language-reference/keywords/private) for private members. Private members are scoped to a component's class. However, C# assumes the `private` access modifier when no access modifier is present, so explicitly marking members "`private`" in your own code is optional. For more information on access modifiers, see [Access Modifiers (C# Programming Guide)](/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers).

The Blazor framework processes a component internally as a [*render tree*](https://developer.mozilla.org/docs/Web/Performance/How_browsers_work#render), which is the combination of a component's DOM and [Cascading Style Sheet Object Model (CSSOM)](https://developer.mozilla.org/docs/Web/API/CSS_Object_Model). After the component is initially rendered, the component's render tree is regenerated in response to events. Blazor compares the new render tree against the previous render tree and applies any modifications to the browser's DOM for display. For more information, see <xref:blazor/components/rendering>.

Razor syntax for C# control structures, directives, and directive attributes are lowercase (examples: [`@if`](xref:mvc/views/razor#conditionals-if-else-if-else-and-switch), [`@code`](xref:mvc/views/razor#code), [`@bind`](xref:mvc/views/razor#bind)). Property names are uppercase (example: `@Body` for <xref:Microsoft.AspNetCore.Components.LayoutComponentBase.Body?displayProperty=nameWithType>).

### Asynchronous methods (`async`) don't support returning `void`

The Blazor framework doesn't track `void`-returning asynchronous methods (`async`). As a result, exceptions aren't caught if `void` is returned. Always return a <xref:System.Threading.Tasks.Task> from asynchronous methods.

### Nested components

Components can include other components by declaring them using HTML syntax. The markup for using a component looks like an HTML tag where the name of the tag is the component type.

Consider the following `Heading` component, which can be used by other components to display a heading.

`Heading.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Heading.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Shared/index/Heading.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Shared/index/Heading.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Shared/index/Heading.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Shared/index/Heading.razor":::

:::moniker-end

The following markup in the `HeadingExample` component renders the preceding `Heading` component at the location where the `<Heading />` tag appears.

`HeadingExample.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/HeadingExample.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/index/HeadingExample.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/index/HeadingExample.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/index/HeadingExample.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/index/HeadingExample.razor":::

:::moniker-end

If a component contains an HTML element with an uppercase first letter that doesn't match a component name within the same namespace, a warning is emitted indicating that the element has an unexpected name. Adding an [`@using`][2] directive for the component's namespace makes the component available, which resolves the warning. For more information, see the [Component name, class name, and namespace](#component-name-class-name-and-namespace) section.

The `Heading` component example shown in this section doesn't have an [`@page`][9] directive, so the `Heading` component isn't directly accessible to a user via a direct request in the browser. However, any component with an [`@page`][9] directive can be nested in another component. If the `Heading` component was directly accessible by including `@page "/heading"` at the top of its Razor file, then the component would be rendered for browser requests at both `/heading` and `/heading-example`.

## Component parameters

*Component parameters* pass data to components and are defined using public [C# properties](/dotnet/csharp/programming-guide/classes-and-structs/properties) on the component class with the [`[Parameter]` attribute](xref:Microsoft.AspNetCore.Components.ParameterAttribute). In the following example, a built-in reference type (<xref:System.String?displayProperty=fullName>) and a user-defined reference type (`PanelBody`) are passed as component parameters.

`PanelBody.cs`:

:::moniker range=">= aspnetcore-8.0"

:::code language="csharp" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/PanelBody.cs":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="csharp" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/PanelBody.cs":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="csharp" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/PanelBody.cs":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="csharp" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/PanelBody.cs":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="csharp" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/PanelBody.cs":::

:::moniker-end

`ParameterChild.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/ParameterChild.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Shared/index/ParameterChild.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Shared/index/ParameterChild.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Shared/index/ParameterChild.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Shared/index/ParameterChild.razor":::

:::moniker-end

> [!WARNING]
> Providing initial values for component parameters is supported, but don't create a component that writes to its own parameters after the component is rendered for the first time. For more information, see <xref:blazor/components/overwriting-parameters>.

The `Title` and `Body` component parameters of the `ParameterChild` component are set by arguments in the HTML tag that renders the instance of the component. The following `ParameterParent` component renders two `ParameterChild` components:

* The first `ParameterChild` component is rendered without supplying parameter arguments.
* The second `ParameterChild` component receives values for `Title` and `Body` from the `ParameterParent` component, which uses an [explicit C# expression](xref:mvc/views/razor#explicit-razor-expressions) to set the values of the `PanelBody`'s properties.

:::moniker range=">= aspnetcore-8.0"

`Parameter1.razor`:

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/Parameter1.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

`ParameterParent.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/index/ParameterParent.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

`ParameterParent.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/index/ParameterParent.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

`ParameterParent.razor`:

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/index/ParameterParent.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

`ParameterParent.razor`:

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/index/ParameterParent.razor":::

:::moniker-end

The following rendered HTML markup from the `ParameterParent` component shows `ParameterChild` component default values when the `ParameterParent` component doesn't supply component parameter values. When the `ParameterParent` component provides component parameter values, they replace the `ParameterChild` component's default values.

> [!NOTE]
> For clarity, rendered CSS style classes aren't shown in the following rendered HTML markup.

```html
<h1>Child component (without attribute values)</h1>

<div>
    <div>Set By Child</div>
    <div>Set by child.</div>
</div>

<h1>Child component (with attribute values)</h1>

<div>
    <div>Set by Parent</div>
    <div>Set by parent.</div>
</div>
```

Assign a C# field, property, or result of a method to a component parameter as an HTML attribute value. The value of the attribute can typically be any C# expression that matches the type of the parameter. The value of the attribute can optionally lead with a [Razor reserved `@` symbol](xref:mvc/views/razor#razor-syntax), but it isn't required.

If the component parameter is of type string, then the attribute value is instead treated as a C# string literal by default. If you want to specify a C# expression instead, then use the `@` prefix.

The following `ParameterParent2` component displays four instances of the preceding `ParameterChild` component and sets their `Title` parameter values to:

* The value of the `title` field.
* The result of the `GetTitle` C# method.
* The current local date in long format with <xref:System.DateTime.ToLongDateString%2A>, which uses an [implicit C# expression](xref:mvc/views/razor#implicit-razor-expressions).
* The `panelData` object's `Title` property.

We don't recommend the use of the `@` prefix for literals (for example, boolean values), keywords (for example, `this`), or `null`, but you can choose to use them if you wish. For example, `IsFixed="@true"` is uncommon but supported.

Quotes around parameter attribute values are optional in most cases per the HTML5 specification. For example, `Value=this` is supported, instead of `Value="this"`. However, we recommend using quotes because it's easier to remember and widely adopted across web-based technologies.

Throughout the documentation, code examples:

* Always use quotes. Example: `Value="this"`.
* Use the `@` prefix with nonliterals, ***even when it's optional***. Example: `Count="@ct"`, where `ct` is a number-typed variable. `Count="ct"` is a valid stylistic approach, but the documentation and examples don't adopt the convention.
* Always avoid `@` for literals, outside of Razor expressions. Example: `IsFixed="true"`.

:::moniker range=">= aspnetcore-8.0"

`Parameter2.razor`:

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/Parameter2.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

`ParameterParent2.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/index/ParameterParent2.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

`ParameterParent2.razor`:

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/index/ParameterParent2.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

`ParameterParent2.razor`:

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/index/ParameterParent2.razor":::

:::moniker-end

> [!NOTE]
> When assigning a C# member to a component parameter, don't prefix the parameter's HTML attribute with `@`.
>
> Correct (`Title` is a string parameter, `Count` is a number-typed parameter):
>
> ```razor
> <ParameterChild Title="@title" Count="@ct" />
> ```
>
> ```razor
> <ParameterChild Title="@title" Count="ct" />
> ```
>
> Incorrect:
>
> ```razor
> <ParameterChild @Title="@title" @Count="@ct" />
> ```
>
> ```razor
> <ParameterChild @Title="@title" @Count="ct" />
> ```

Unlike in Razor pages (`.cshtml`), Blazor can't perform asynchronous work in a Razor expression while rendering a component. This is because Blazor is designed for rendering interactive UIs. In an interactive UI, the screen must always display something, so it doesn't make sense to block the rendering flow. Instead, asynchronous work is performed during one of the [asynchronous lifecycle events](xref:blazor/components/lifecycle). After each asynchronous lifecycle event, the component may render again. The following Razor syntax is **not** supported:

```razor
<ParameterChild Title="@await ..." />
```

The code in the preceding example generates a *compiler error* when the app is built:

> The 'await' operator can only be used within an async method. Consider marking this method with the 'async' modifier and changing its return type to 'Task'.

To obtain a value for the `Title` parameter in the preceding example asynchronously, the component can use the [`OnInitializedAsync` lifecycle event](xref:blazor/components/lifecycle#component-initialization-oninitializedasync), as the following example demonstrates:

```razor
<ParameterChild Title="@title" />

@code {
    private string? title;
    
    protected override async Task OnInitializedAsync()
    {
        title = await ...;
    }
}
```

For more information, see <xref:blazor/components/lifecycle>.

Use of an explicit Razor expression to concatenate text with an expression result for assignment to a parameter is **not** supported. The following example seeks to concatenate the text "`Set by `" with an object's property value. Although this syntax is supported in a Razor page (`.cshtml`), it isn't valid for assignment to the child's `Title` parameter in a component. The following Razor syntax is **not** supported:

```razor
<ParameterChild Title="Set by @(panelData.Title)" />
```

The code in the preceding example generates a *compiler error* when the app is built:

> Component attributes do not support complex content (mixed C# and markup).

To support the assignment of a composed value, use a method, field, or property. The following example performs the concatenation of "`Set by `" and an object's property value in the C# method `GetTitle`:

:::moniker range=">= aspnetcore-8.0"

`Parameter3.razor`:

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/Parameter3.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

`ParameterParent3.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/index/ParameterParent3.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

`ParameterParent3.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/index/ParameterParent3.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

`ParameterParent3.razor`:

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/index/ParameterParent3.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

`ParameterParent3.razor`:

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/index/ParameterParent3.razor":::

:::moniker-end

For more information, see <xref:mvc/views/razor>.

> [!WARNING]
> Providing initial values for component parameters is supported, but don't create a component that writes to its own parameters after the component is rendered for the first time. For more information, see <xref:blazor/components/overwriting-parameters>.

Component parameters should be declared as *auto-properties*, meaning that they shouldn't contain custom logic in their `get` or `set` accessors. For example, the following `StartData` property is an auto-property:

```csharp
[Parameter]
public DateTime StartData { get; set; }
```

Don't place custom logic in the `get` or `set` accessor because component parameters are purely intended for use as a channel for a parent component to flow information to a child component. If a `set` accessor of a child component property contains logic that causes rerendering of the parent component, an infinite rendering loop results.

To transform a received parameter value:

* Leave the parameter property as an auto-property to represent the supplied raw data.
* Create a different property or method to supply the transformed data based on the parameter property.

Override [`OnParametersSetAsync`](xref:blazor/components/lifecycle#after-parameters-are-set-onparameterssetasync) to transform a received parameter each time new data is received.

Writing an initial value to a component parameter is supported because initial value assignments don't interfere with the Blazor's automatic component rendering. The following assignment of the current local <xref:System.DateTime> with <xref:System.DateTime.Now?displayProperty=nameWithType> to `StartData` is valid syntax in a component:

```csharp
[Parameter]
public DateTime StartData { get; set; } = DateTime.Now;
```

After the initial assignment of <xref:System.DateTime.Now?displayProperty=nameWithType>, do **not** assign a value to `StartData` in developer code. For more information, see <xref:blazor/components/overwriting-parameters>.

:::moniker range=">= aspnetcore-6.0"

Apply the [`[EditorRequired]` attribute](xref:Microsoft.AspNetCore.Components.EditorRequiredAttribute) to specify a required component parameter. If a parameter value isn't provided, editors or build tools may display warnings to the user. This attribute is only valid on properties also marked with the [`[Parameter]` attribute](xref:Microsoft.AspNetCore.Components.ParameterAttribute). The <xref:Microsoft.AspNetCore.Components.EditorRequiredAttribute> is enforced at design-time and when the app is built. The attribute isn't enforced at runtime, and it doesn't guarantee a non-`null` parameter value.

```csharp
[Parameter]
[EditorRequired]
public string? Title { get; set; }
```

Single-line attribute lists are also supported:

```csharp
[Parameter, EditorRequired]
public string? Title { get; set; }
```

:::moniker-end

:::moniker range=">= aspnetcore-7.0"

Don't use the [`required` modifier](/dotnet/csharp/language-reference/keywords/required) or [`init` accessor](/dotnet/csharp/language-reference/keywords/init) on component parameter properties. Components are usually instantiated and assigned parameter values using [reflection](/dotnet/csharp/advanced-topics/reflection-and-attributes/), which bypasses the guarantees that `init` and `required` are designed to make. Instead, use the [`[EditorRequired]` attribute](xref:Microsoft.AspNetCore.Components.EditorRequiredAttribute) to specify a required component parameter.

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

Don't use the [`init` accessor](/dotnet/csharp/language-reference/keywords/init) on component parameter properties because setting component parameter values with <xref:Microsoft.AspNetCore.Components.ParameterView.SetParameterProperties%2A?displayProperty=nameWithType> uses [reflection](/dotnet/csharp/advanced-topics/reflection-and-attributes/), which bypasses the init-only setter restriction. Use the [`[EditorRequired]` attribute](xref:Microsoft.AspNetCore.Components.EditorRequiredAttribute) to specify a required component parameter.

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

Don't use the [`init` accessor](/dotnet/csharp/language-reference/keywords/init) on component parameter properties because setting component parameter values with <xref:Microsoft.AspNetCore.Components.ParameterView.SetParameterProperties%2A?displayProperty=nameWithType> uses [reflection](/dotnet/csharp/advanced-topics/reflection-and-attributes/), which bypasses the init-only setter restriction.

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

[`Tuples`](/dotnet/csharp/language-reference/builtin-types/value-tuples) ([API documentation](xref:System.Tuple)) are supported for component parameters and [`RenderFragment`](#child-content-render-fragments) types. The following component parameter example passes three values in a `Tuple`:

`RenderTupleChild.razor`:

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/RenderTupleChild.razor":::

`RenderTupleParent.razor`:

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/RenderTupleParent.razor":::
    
[Named tuples](/dotnet/csharp/language-reference/builtin-types/value-tuples#tuple-field-names) are supported, as seen in the following example:

`NamedTupleChild.razor`:

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/NamedTupleChild.razor":::

`NamedTuples.razor`:

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/NamedTuples.razor":::

Quote &copy;2005 [Universal Pictures](https://www.uphe.com): [Serenity](https://www.uphe.com/movies/serenity-2005) ([Nathan Fillion](https://www.imdb.com/name/nm0277213/))

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

[`Tuples`](/dotnet/csharp/language-reference/builtin-types/value-tuples) ([API documentation](xref:System.Tuple)) are supported for component parameters and [`RenderFragment`](#child-content-render-fragments) types. The following component parameter example passes three values in a `Tuple`:

`RenderTupleChild.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_Server/Shared/index/RenderTupleChild.razor":::

`RenderTupleParent.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_Server/Pages/index/RenderTupleParent.razor":::
    
[Named tuples](/dotnet/csharp/language-reference/builtin-types/value-tuples#tuple-field-names) are supported, as seen in the following example:

`RenderNamedTupleChild.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_Server/Shared/index/RenderNamedTupleChild.razor":::

`RenderNamedTupleParent.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_Server/Pages/index/RenderNamedTupleParent.razor":::

Quote &copy;2005 [Universal Pictures](https://www.uphe.com): [Serenity](https://www.uphe.com/movies/serenity-2005) ([Nathan Fillion](https://www.imdb.com/name/nm0277213/))

:::moniker-end

## Route parameters

Components can specify route parameters in the route template of the [`@page`][9] directive. The [Blazor router](xref:blazor/fundamentals/routing) uses route parameters to populate corresponding component parameters.

:::moniker range=">= aspnetcore-5.0"

Optional route parameters are supported. In the following example, the `text` optional parameter assigns the value of the route segment to the component's `Text` property. If the segment isn't present, the value of `Text` is set to "`fantastic`" in the [`OnInitialized` lifecycle method](xref:blazor/components/lifecycle#component-initialization-oninitializedasync).

:::moniker-end

:::moniker range="< aspnetcore-5.0"

Optional route parameters aren't supported, so two [`@page`][9] directives are applied in the following example. The first [`@page`][9] directive permits navigation to the component without a route parameter. The second [`@page`][9] directive receives the `{text}` route parameter and assigns the value to the `Text` property.

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

`OptionalParameter.razor`:

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/OptionalParameter.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

`RouteParameter.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/index/RouteParameter.razor" highlight="1,6-7":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

`RouteParameter.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/index/RouteParameter.razor" highlight="1,6-7":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

`RouteParameter.razor`:

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/index/RouteParameter.razor" highlight="1,6-7":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

`RouteParameter.razor`:

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/index/RouteParameter.razor" highlight="2,7-8":::

:::moniker-end

For information on catch-all route parameters (`{*pageRoute}`), which capture paths across multiple folder boundaries, see <xref:blazor/fundamentals/routing#catch-all-route-parameters>.

## Child content render fragments

Components can set the content of another component. The assigning component provides the content between the child component's opening and closing tags.

In the following example, the `RenderFragmentChild` component has a `ChildContent` component parameter that represents a segment of the UI to render as a <xref:Microsoft.AspNetCore.Components.RenderFragment>. The position of `ChildContent` in the component's Razor markup is where the content is rendered in the final HTML output.

`RenderFragmentChild.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/RenderFragmentChild.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Shared/index/RenderFragmentChild.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Shared/index/RenderFragmentChild.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Shared/index/RenderFragmentChild.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Shared/index/RenderFragmentChild.razor":::

:::moniker-end

> [!IMPORTANT]
> The property receiving the <xref:Microsoft.AspNetCore.Components.RenderFragment> content must be named `ChildContent` by convention.
>
> [Event callbacks](xref:blazor/components/event-handling#eventcallback) aren't supported for <xref:Microsoft.AspNetCore.Components.RenderFragment>.

The following component provides content for rendering the `RenderFragmentChild` by placing the content inside the child component's opening and closing tags.

:::moniker range=">= aspnetcore-8.0"

`RenderFragments.razor`:

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/RenderFragments.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

`RenderFragmentParent.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/index/RenderFragmentParent.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

`RenderFragmentParent.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/index/RenderFragmentParent.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

`RenderFragmentParent.razor`:

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/index/RenderFragmentParent.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

`RenderFragmentParent.razor`:

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/index/RenderFragmentParent.razor":::

:::moniker-end

Due to the way that Blazor renders child content, rendering components inside a [`for`](/dotnet/csharp/language-reference/keywords/for) loop requires a local index variable if the incrementing loop variable is used in the `RenderFragmentChild` component's content. The following example can be added to the preceding parent component:

```razor
<h1>Three children with an index variable</h1>

@for (int c = 0; c < 3; c++)
{
    var current = c;

    <RenderFragmentChild>
        Count: @current
    </RenderFragmentChild>
}
```

Alternatively, use a [`foreach`](/dotnet/csharp/language-reference/keywords/foreach-in) loop with <xref:System.Linq.Enumerable.Range%2A?displayProperty=nameWithType> instead of a [`for`](/dotnet/csharp/language-reference/keywords/for) loop. The following example can be added to the preceding parent component:

```razor
<h1>Second example of three children with an index variable</h1>

@foreach (var c in Enumerable.Range(0,3))
{
    <RenderFragmentChild>
        Count: @c
    </RenderFragmentChild>
}
```

Render fragments are used to render child content throughout Blazor apps and are described with examples in the following articles and article sections:

* [Blazor layouts](xref:blazor/components/layouts)
* [Pass data across a component hierarchy](xref:blazor/components/cascading-values-and-parameters#pass-data-across-a-component-hierarchy)
* [Templated components](xref:blazor/components/templated-components)
* [Global exception handling](xref:blazor/fundamentals/handle-errors#global-exception-handling)

> [!NOTE]
> Blazor framework's [built-in Razor components](xref:blazor/components/built-in-components) use the same `ChildContent` component parameter convention to set their content. You can see the components that set child content by searching for the component parameter property name `ChildContent` in the [API documentation (filters API with the search term "ChildContent")](/dotnet/api/?term=ChildContent).

## Render fragments for reusable rendering logic

You can factor out child components purely as a way of reusing rendering logic. In any component's `@code` block, define a <xref:Microsoft.AspNetCore.Components.RenderFragment> and render the fragment from any location as many times as needed:

```razor
@RenderWelcomeInfo

<p>Render the welcome info a second time:</p>

@RenderWelcomeInfo

@code {
    private RenderFragment RenderWelcomeInfo =  @<p>Welcome to your new app!</p>;
}
```

For more information, see [Reuse rendering logic](xref:blazor/performance#define-reusable-renderfragments-in-code).

## Capture references to components

Component references provide a way to reference a component instance for issuing commands. To capture a component reference:

* Add an [`@ref`][4] attribute to the child component.
* Define a field with the same type as the child component.

When the component is rendered, the field is populated with the component instance. You can then invoke .NET methods on the instance.

Consider the following `ReferenceChild` component that logs a message when its `ChildMethod` is called.

`ReferenceChild.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/ReferenceChild.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Shared/index/ReferenceChild.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Shared/index/ReferenceChild.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Shared/index/ReferenceChild.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Shared/index/ReferenceChild.razor":::

:::moniker-end

A component reference is only populated after the component is rendered and its output includes `ReferenceChild`'s element. Until the component is rendered, there's nothing to reference.

To manipulate component references after the component has finished rendering, use the [`OnAfterRender` or `OnAfterRenderAsync` methods](xref:blazor/components/lifecycle#after-component-render-onafterrenderasync).

To use a reference variable with an event handler, use a lambda expression or assign the event handler delegate in the [`OnAfterRender` or `OnAfterRenderAsync` methods](xref:blazor/components/lifecycle#after-component-render-onafterrenderasync). This ensures that the reference variable is assigned before the event handler is assigned.

The following lambda approach uses the preceding `ReferenceChild` component.

`ReferenceParent1.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/ReferenceParent1.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/index/ReferenceParent1.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/index/ReferenceParent1.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/index/ReferenceParent1.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/index/ReferenceParent1.razor":::

:::moniker-end

The following delegate approach uses the preceding `ReferenceChild` component.

`ReferenceParent2.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/ReferenceParent2.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/index/ReferenceParent2.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/index/ReferenceParent2.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/index/ReferenceParent2.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/index/ReferenceParent2.razor":::

:::moniker-end

While capturing component references use a similar syntax to [capturing element references](xref:blazor/js-interop/call-javascript-from-dotnet#capture-references-to-elements), capturing component references isn't a JavaScript interop feature. Component references aren't passed to JavaScript code. Component references are only used in .NET code.

> [!IMPORTANT]
> Do **not** use component references to mutate the state of child components. Instead, use normal declarative component parameters to pass data to child components. Use of component parameters result in child components that rerender at the correct times automatically. For more information, see the [component parameters](#component-parameters) section and the <xref:blazor/components/data-binding> article.

## Apply an attribute

Attributes can be applied to components with the [`@attribute`][7] directive. The following example applies the [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) to the component's class:

```razor
@page "/"
@attribute [Authorize]
```

## Conditional HTML element attributes

HTML element attribute properties are conditionally set based on the .NET value. If the value is `false` or `null`, the property isn't set. If the value is `true`, the property is set.

In the following example, `IsCompleted` determines if the `<input>` element's `checked` property is set.

`ConditionalAttribute.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/ConditionalAttribute.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/index/ConditionalAttribute.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/index/ConditionalAttribute.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/index/ConditionalAttribute.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/index/ConditionalAttribute.razor":::

:::moniker-end

For more information, see <xref:mvc/views/razor>.

> [!WARNING]
> Some HTML attributes, such as [`aria-pressed`](https://developer.mozilla.org/docs/Web/Accessibility/ARIA/Roles/button_role#Toggle_buttons), don't function properly when the .NET type is a `bool`. In those cases, use a `string` type instead of a `bool`.

## Raw HTML

Strings are normally rendered using DOM text nodes, which means that any markup they may contain is ignored and treated as literal text. To render raw HTML, wrap the HTML content in a <xref:Microsoft.AspNetCore.Components.MarkupString> value. The value is parsed as HTML or SVG and inserted into the DOM.

> [!WARNING]
> Rendering raw HTML constructed from any untrusted source is a **security risk** and should **always** be avoided.

The following example shows using the <xref:Microsoft.AspNetCore.Components.MarkupString> type to add a block of static HTML content to the rendered output of a component.

:::moniker range=">= aspnetcore-8.0"

`MarkupStrings.razor`:

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/MarkupStrings.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

`MarkupStringExample.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/index/MarkupStringExample.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

`MarkupStringExample.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/index/MarkupStringExample.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

`MarkupStringExample.razor`:

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/index/MarkupStringExample.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

`MarkupStringExample.razor`:

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/index/MarkupStringExample.razor":::

:::moniker-end

## Razor templates

Render fragments can be defined using Razor template syntax to define a UI snippet. Razor templates use the following format:

```razor
@<{HTML tag}>...</{HTML tag}>
```

The following example illustrates how to specify <xref:Microsoft.AspNetCore.Components.RenderFragment> and <xref:Microsoft.AspNetCore.Components.RenderFragment%601> values and render templates directly in a component. Render fragments can also be passed as arguments to [templated components](xref:blazor/components/templated-components).

`RazorTemplate.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/RazorTemplate.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/index/RazorTemplate.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/index/RazorTemplate.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/index/RazorTemplate.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/index/RazorTemplate.razor":::

:::moniker-end

Rendered output of the preceding code:

```html
<p>The time is 4/19/2021 8:54:46 AM.</p>
<p>Pet: Nutty Rex</p>
```

## Static assets

Blazor follows the convention of ASP.NET Core apps for static assets. Static assets are located in the project's [`web root` (`wwwroot`) folder](xref:fundamentals/index#web-root) or folders under the `wwwroot` folder.

Use a base-relative path (`/`) to refer to the web root for a static asset. In the following example, `logo.png` is physically located in the `{PROJECT ROOT}/wwwroot/images` folder. `{PROJECT ROOT}` is the app's project root.

```razor
<img alt="Company logo" src="/images/logo.png" />
```

Components do **not** support tilde-slash notation (`~/`).

For information on setting an app's base path, see <xref:blazor/host-and-deploy/index#app-base-path>.

## Tag Helpers aren't supported in components

[`Tag Helpers`](xref:mvc/views/tag-helpers/intro) aren't supported in components. To provide Tag Helper-like functionality in Blazor, create a component with the same functionality as the Tag Helper and use the component instead.

## Scalable Vector Graphics (SVG) images

Since Blazor renders HTML, browser-supported images, including [Scalable Vector Graphics (SVG) images (`.svg`)](https://developer.mozilla.org/docs/Web/SVG), are supported via the `<img>` tag:

```html
<img alt="Example image" src="image.svg" />
```

Similarly, SVG images are supported in the CSS rules of a stylesheet file (`.css`):

```css
.element-class {
    background-image: url("image.svg");
}
```

:::moniker range=">= aspnetcore-6.0"

Blazor supports the [`<foreignObject>`](https://developer.mozilla.org/docs/Web/SVG/Element/foreignObject) element to display arbitrary HTML within an SVG. The markup can represent arbitrary HTML, a <xref:Microsoft.AspNetCore.Components.RenderFragment>, or a Razor component.

The following example demonstrates:

* Display of a `string` (`@message`).
* Two-way binding with an `<input>` element and a `value` field.
* A `Robot` component.

```razor
<svg width="200" height="200" xmlns="http://www.w3.org/2000/svg">
    <rect x="0" y="0" rx="10" ry="10" width="200" height="200" stroke="black" 
        fill="none" />
    <foreignObject x="20" y="20" width="160" height="160">
        <p>@message</p>
    </foreignObject>
</svg>

<svg xmlns="http://www.w3.org/2000/svg">
    <foreignObject width="200" height="200">
        <label>
            Two-way binding:
            <input @bind="value" @bind:event="oninput" />
        </label>
    </foreignObject>
</svg>

<svg xmlns="http://www.w3.org/2000/svg">
    <foreignObject>
        <Robot />
    </foreignObject>
</svg>

@code {
    private string message = "Lorem ipsum dolor sit amet, consectetur adipiscing " +
        "elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";

    private string? value;
}
```

:::moniker-end

## Whitespace rendering behavior

:::moniker range=">= aspnetcore-5.0"

Unless the [`@preservewhitespace`](xref:mvc/views/razor#preservewhitespace) directive is used with a value of `true`, extra whitespace is removed by default if:

* Leading or trailing within an element.
* Leading or trailing within a <xref:Microsoft.AspNetCore.Components.RenderFragment>/<xref:Microsoft.AspNetCore.Components.RenderFragment%601> parameter (for example, child content passed to another component).
* It precedes or follows a C# code block, such as `@if` or `@foreach`.

Whitespace removal might affect the rendered output when using a CSS rule, such as `white-space: pre`. To disable this performance optimization and preserve the whitespace, take one of the following actions:

* Add the `@preservewhitespace true` directive at the top of the Razor file (`.razor`) to apply the preference to a specific component.
* Add the `@preservewhitespace true` directive inside an `_Imports.razor` file to apply the preference to a subdirectory or to the entire project.

In most cases, no action is required, as apps typically continue to behave normally (but faster). If stripping whitespace causes a rendering problem for a particular component, use `@preservewhitespace true` in that component to disable this optimization.

:::moniker-end

:::moniker range="< aspnetcore-5.0"

Whitespace is retained in a component's source markup. Whitespace-only text renders in the browser's DOM even when there's no visual effect.

Consider the following component markup:

```razor
<ul>
    @foreach (var item in Items)
    {
        <li>
            @item.Text
        </li>
    }
</ul>
```

The preceding example renders the following unnecessary whitespace:

* Outside of the `@foreach` code block.
* Around the `<li>` element.
* Around the `@item.Text` output.

A list of 100 items results in over 400 areas of whitespace. None of the extra whitespace visually affects the rendered output.

When rendering static HTML for components, whitespace inside a tag isn't preserved. For example, view the rendered output of the following `<img>` tag in a component Razor file (`.razor`):

```razor
<img     alt="Example image"   src="img.png"     />
```

Whitespace isn't preserved from the preceding markup:

```razor
<img alt="Example image" src="img.png" />
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

## Root component

A *root Razor component* (*root component*) is the first component loaded of any component hierarchy created by the app.

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

In an app created from the Blazor Web App project template, the `App` component (`App.razor`) is specified as the default root component by the type parameter declared for the call to [`MapRazorComponents<TRootComponent>`](xref:Microsoft.AspNetCore.Builder.RazorComponentsEndpointRouteBuilderExtensions.MapRazorComponents%2A) in the server-side `Program` file. The following example shows the use of the `App` component as the root component, which is the default for an app created from the Blazor project template:

```csharp
app.MapRazorComponents<App>();
```

> [!NOTE]
> Making a root component interactive, such as the `App` component, isn't supported.

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

In an app created from the Blazor Server project template, the `App` component (`App.razor`) is specified as the default root component in `Pages/_Host.cshtml` using the [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper):

```cshtml
<component type="typeof(App)" render-mode="ServerPrerendered" />
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

In an app created from the Blazor WebAssembly project template, the `App` component (`App.razor`) is specified as the default root component in the `Program` file:

```csharp
builder.RootComponents.Add<App>("#app");
```

In the preceding code, the CSS selector, `#app`, indicates that the `App` component is specified for the `<div>` in `wwwroot/index.html` with an `id` of `app`:

```html
<div id="app">...</app>
```

:::moniker-end

MVC and Razor Pages apps can also use the [Component Tag Helper](xref:Microsoft.AspNetCore.Mvc.TagHelpers.ComponentTagHelper) to register statically-rendered Blazor WebAssembly root components:

:::moniker range=">= aspnetcore-6.0"

```cshtml
<component type="typeof(App)" render-mode="WebAssemblyPrerendered" />
```

Statically-rendered components can only be added to the app. They can't be removed or updated afterwards.

For more information, see the following resources:

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

* <xref:mvc/views/tag-helpers/builtin-th/component-tag-helper>
* <xref:blazor/components/integration>

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

* <xref:mvc/views/tag-helpers/builtin-th/component-tag-helper>
* <xref:blazor/components/prerendering-and-integration>

:::moniker-end

<!--Reference links in article-->
[1]: <xref:mvc/views/razor#code>
[2]: <xref:mvc/views/razor#using>
[3]: <xref:mvc/views/razor#attributes>
[4]: <xref:mvc/views/razor#ref>
[5]: <xref:mvc/views/razor#key>
[6]: <xref:mvc/views/razor#inherits>
[7]: <xref:mvc/views/razor#attribute>
[8]: <xref:mvc/views/razor#namespace>
[9]: <xref:mvc/views/razor#page>
[10]: <xref:mvc/views/razor#bind>
