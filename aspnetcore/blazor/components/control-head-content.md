---
title: Control head content in ASP.NET Core Blazor apps
author: guardrex
description: Learn how to control head content in Blazor apps, including how to set the page title from a component.
monikerRange: '>= aspnetcore-6.0'
ms.author: riande
ms.custom: mvc
ms.date: 11/09/2021
uid: blazor/components/control-head-content
---
# Control `<head>` content in ASP.NET Core Blazor apps

Razor components can modify the HTML `<head>` element content of a page, including setting the page's title (`<title>` element) and modifying metadata (`<meta>` elements).

:::moniker range="< aspnetcore-7.0"

## Control `<head>` content in a Razor component

Specify the page's title with the <xref:Microsoft.AspNetCore.Components.Web.PageTitle> component, which enables rendering an HTML `<title>` element to a [`HeadOutlet` component](#headoutlet-component).
    
Specify `<head>` element content with the <xref:Microsoft.AspNetCore.Components.Web.HeadContent> component, which provides content to a [`HeadOutlet` component](#headoutlet-component).

The following example sets the page's title and description using Razor.

`Pages/ControlHeadContent.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/control-head-content/ControlHeadContent.razor" highlight="13,15-17":::

## Control `<head>` content during prerendering

*This section applies to prerendered Blazor WebAssembly apps and Blazor Server apps.*

When [Razor components are prerendered](xref:blazor/components/prerendering-and-integration), the use of a layout page (`_Layout.cshtml`) is required to control `<head>` content with the <xref:Microsoft.AspNetCore.Components.Web.PageTitle> and <xref:Microsoft.AspNetCore.Components.Web.HeadContent> components. The reason for this requirement is that components that control `<head>` content must be rendered before the layout with the <xref:Microsoft.AspNetCore.Components.Web.HeadOutlet> component. **This order of rendering is required to control head content.**

If the shared `_Layout.cshtml` file doesn't have a [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper) for a <xref:Microsoft.AspNetCore.Components.Web.HeadOutlet> component, add it to the `<head>` elements.

In a **required**, shared `_Layout.cshtml` file of a Blazor Server app or Razor Pages/MVC app that embeds components into pages or views:

```cshtml
<component type="typeof(HeadOutlet)" render-mode="ServerPrerendered" />
```

In a **required**, shared `_Layout.cshtml` file of a prerendered hosted Blazor WebAssembly app:

```cshtml
<component type="typeof(HeadOutlet)" render-mode="WebAssemblyPrerendered" />
```

## `HeadOutlet` component

The <xref:Microsoft.AspNetCore.Components.Web.HeadOutlet> component renders content provided by <xref:Microsoft.AspNetCore.Components.Web.PageTitle> and <xref:Microsoft.AspNetCore.Components.Web.HeadContent> components.

In an app created from the Blazor WebAssembly project template, the <xref:Microsoft.AspNetCore.Components.Web.HeadOutlet> component is added to the <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostBuilder.RootComponents> collection of the <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostBuilder> in `Program.cs`:

```csharp
builder.RootComponents.Add<HeadOutlet>("head::after");
```

When the [`::after` pseudo-selector](https://developer.mozilla.org/docs/Web/CSS/::after) is specified, the contents of the root component are appended to the existing head contents instead of replacing the content. This allows the app to retain static head content in `wwwroot/index.html` without having to repeat the content in the app's Razor components.

In Blazor Server apps created from the Blazor Server project template, a [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper) renders `<head>` content for the <xref:Microsoft.AspNetCore.Components.Web.HeadOutlet> component in `Pages/_Layout.cshtml`:

```cshtml
<head>
    ...
    <component type="typeof(HeadOutlet)" render-mode="ServerPrerendered" />
</head>
```

## Not found page title

In Blazor apps created from Blazor project templates, the `NotFound` component template in the `App` component (`App.razor`) sets the page title to `Not found`.

`App.razor`:

```razor
<PageTitle>Not found</PageTitle>
```

## Additional resources

* [Control headers in C# code at startup](xref:blazor/fundamentals/startup#control-headers-in-c-code)
* [Blazor samples GitHub repository (`dotnet/blazor-samples`)](https://github.com/dotnet/blazor-samples)

Mozilla MDN Web Docs documentation:

* [What's in the head? Metadata in HTML](https://developer.mozilla.org/docs/Learn/HTML/Introduction_to_HTML/The_head_metadata_in_HTML)
* [`<head>`: The Document Metadata (Header) element](https://developer.mozilla.org/docs/Web/HTML/Element/head)
* [`<title>`: The Document Title element](https://developer.mozilla.org/docs/Web/HTML/Element/title)
* [`<meta>`: The metadata element](https://developer.mozilla.org/docs/Web/HTML/Element/meta)

:::moniker-end

:::moniker range=">= aspnetcore-7.0"

## Control `<head>` content in a Razor component

Specify the page's title with the <xref:Microsoft.AspNetCore.Components.Web.PageTitle> component, which enables rendering an HTML `<title>` element to a [`HeadOutlet` component](#headoutlet-component).
    
Specify `<head>` element content with the <xref:Microsoft.AspNetCore.Components.Web.HeadContent> component, which provides content to a [`HeadOutlet` component](#headoutlet-component).

The following example sets the page's title and description using Razor.

`Pages/ControlHeadContent.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/control-head-content/ControlHeadContent.razor" highlight="13,15-17":::

## `HeadOutlet` component

The <xref:Microsoft.AspNetCore.Components.Web.HeadOutlet> component renders content provided by <xref:Microsoft.AspNetCore.Components.Web.PageTitle> and <xref:Microsoft.AspNetCore.Components.Web.HeadContent> components.

In an app created from the Blazor WebAssembly project template, the <xref:Microsoft.AspNetCore.Components.Web.HeadOutlet> component is added to the <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostBuilder.RootComponents> collection of the <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostBuilder> in `Program.cs`:

```csharp
builder.RootComponents.Add<HeadOutlet>("head::after");
```

When the [`::after` pseudo-selector](https://developer.mozilla.org/docs/Web/CSS/::after) is specified, the contents of the root component are appended to the existing head contents instead of replacing the content. This allows the app to retain static head content in `wwwroot/index.html` without having to repeat the content in the app's Razor components.

In Blazor Server apps created from the Blazor Server project template, a [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper) renders `<head>` content for the <xref:Microsoft.AspNetCore.Components.Web.HeadOutlet> component in `Pages/_Host.cshtml`:

```cshtml
<head>
    ...
    <component type="typeof(HeadOutlet)" render-mode="ServerPrerendered" />
</head>
```

## Not found page title

In Blazor apps created from Blazor project templates, the `NotFound` component template in the `App` component (`App.razor`) sets the page title to `Not found`.

`App.razor`:

```razor
<PageTitle>Not found</PageTitle>
```

## Additional resources

* [Control headers in C# code at startup](xref:blazor/fundamentals/startup#control-headers-in-c-code)
* [Blazor samples GitHub repository (`dotnet/blazor-samples`)](https://github.com/dotnet/blazor-samples)

Mozilla MDN Web Docs documentation:

* [What's in the head? Metadata in HTML](https://developer.mozilla.org/docs/Learn/HTML/Introduction_to_HTML/The_head_metadata_in_HTML)
* [`<head>`: The Document Metadata (Header) element](https://developer.mozilla.org/docs/Web/HTML/Element/head)
* [`<title>`: The Document Title element](https://developer.mozilla.org/docs/Web/HTML/Element/title)
* [`<meta>`: The metadata element](https://developer.mozilla.org/docs/Web/HTML/Element/meta)


:::moniker-end
