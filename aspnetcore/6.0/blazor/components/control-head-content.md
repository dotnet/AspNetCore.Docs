---
title: Control &lt;head&gt; content in ASP.NET Core Blazor apps
author: guardrex
description: Learn how to control &lt;head&gt; content in Blazor apps, including how to set the page title from a component.
monikerRange: 'aspnetcore-6.0'
ms.author: riande
ms.custom: mvc
ms.date: 08/03/2021
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/components/control-head-content
---
# Control \<head> content in ASP.NET Core Blazor apps

*This feature applies to ASP.NET Core 6.0 Preview 7 or later. ASP.NET Core 6.0 Preview 7 is scheduled for release in August, 2021. ASP.NET Core 6.0 is scheduled for release later this year.*

Razor components can modify the HTML \<head> element content of a page, including setting the page's title (`<title>` element) and modifying metadata (`<meta>` elements).

## Control \<head> content in a Razor component

Specify the page's title with the `PageTitle` component. Specify `<head>` element content with the `HeadContent` component. The following example, sets the page's title and description using Razor.

`Pages/SetTitleAndDescription.razor`:

```razor
@page "/set-title-and-description"

<h1>Set title &amp; description</h1>

<p>
    Title: @title
</p>

<p>
    Description: @description
</p>

<PageTitle>@title</PageTitle>

<HeadContent>
    <meta id="meta-description" name="description" content="@description">
</HeadContent>

@code {
    private string description = "Description set by component";
    private string title = "Title set by component";
}
```

## `HeadOutlet` component

The `HeadOutlet` component renders content provided by `HeadContent` components.

In an app created from the Blazor WebAssembly project template, the `HeadOutlet` component is added to the <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostBuilder.RootComponents> collection of the <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostBuilder> in `Program.Main`:

```csharp
builder.RootComponents.Add<HeadOutlet>("head::after");
```

When the [`::after` pseudo-selector](https://developer.mozilla.org/docs/Web/CSS/::after) is specified, the contents of the root component are appended to the existing head contents instead of replacing them. This allows the app to retain static head content in `wwwroot/index.html` without having to repeat it in the app's Razor components.

In Blazor Server apps created from the Blazor Server project template, a [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper) renders \<head> content for the `HeadOutlet` component in `Pages/_Layout.cshtml`:

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
