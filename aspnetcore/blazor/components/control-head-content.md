---
title: Control &lt;head&gt; content in ASP.NET Core Blazor apps
author: guardrex
description: Learn how to control &lt;head&gt; content in Blazor apps, including how to set the page title from a component.
monikerRange: '>= aspnetcore-6.0'
ms.author: riande
ms.custom: mvc
ms.date: 11/09/2021
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/components/control-head-content
---
# Control `<head>` content in ASP.NET Core Blazor apps

Razor components can modify the HTML `<head>` element content of a page, including setting the page's title (`<title>` element) and modifying metadata (`<meta>` elements).

## Control `<head>` content in a Razor component

Specify the page's title with the <xref:Microsoft.AspNetCore.Components.Web.PageTitle> component, which enables rendering an HTML `<title>` element to a [`HeadOutlet` component](#headoutlet-component).
    
Specify `<head>` element content with the <xref:Microsoft.AspNetCore.Components.Web.HeadContent> component, which provides content to a [`HeadOutlet` component](#headoutlet-component).

The following example sets the page's title and description using Razor.

`Pages/ControlHeadContent.razor`:

```razor
@page "/control-head-content"

<h1>Control &lt;head&gt; content</h1>

<p>
    Title: @title
</p>

<p>
    Description: @description
</p>

<PageTitle>@title</PageTitle>

<HeadContent>
    <meta name="description" content="@description">
</HeadContent>

@code {
    private string description = "Description set by component";
    private string title = "Title set by component";
}
```

## Control head content during prerendering

When [components are prerendered in a Blazor app](xref:blazor/components/prerendering-and-integration), the use of a layout page (`_Layout.cshtml`) is required to control head (`<head>`) content with the <xref:Microsoft.AspNetCore.Components.Web.PageTitle> and <xref:Microsoft.AspNetCore.Components.Web.HeadContent> components. The reason for this requirement is that components that control head content must be rendered before the layout with the <xref:Microsoft.AspNetCore.Components.Web.HeadOutlet> component. **This order of rendering is required to control head content.**

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

Mozilla MDN Web Docs documentation:

* [What's in the head? Metadata in HTML](https://developer.mozilla.org/docs/Learn/HTML/Introduction_to_HTML/The_head_metadata_in_HTML)
* [\<head>: The Document Metadata (Header) element](https://developer.mozilla.org/docs/Web/HTML/Element/head)
* [\<title>: The Document Title element](https://developer.mozilla.org/docs/Web/HTML/Element/title)
* [\<meta>: The metadata element](https://developer.mozilla.org/docs/Web/HTML/Element/meta)
