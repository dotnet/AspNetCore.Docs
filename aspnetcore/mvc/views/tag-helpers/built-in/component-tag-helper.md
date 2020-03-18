---
title: Component Tag Helper in ASP.NET Core
author: guardrex
ms.author: riande
description: Learn how to use the ASP.NET Core Component Tag Helper to render Razor components in pages and views.
ms.custom: mvc
ms.date: 03/17/2020
no-loc: [Blazor, SignalR]
uid: mvc/views/tag-helpers/builtin-th/component-tag-helper
---
# Component Tag Helper in ASP.NET Core

By [Daniel Roth](https://github.com/danroth27) and [Luke Latham](https://github.com/guardrex)

To render a component from a page or view, use the [Component Tag Helper](xref:Microsoft.AspNetCore.Mvc.TagHelpers.ComponentTagHelper).

The following Component Tag Helper renders the `Counter` component in a page or view:

```cshtml
<component type="typeof(Counter)" render-mode="ServerPrerendered" />
```

The Component Tag Helper can also pass parameters to components. For the following example, the `ColorfulCheckbox` component has `Size` (`int`) and `Color` (`string`) [component parameters](xref:blazor/components#component-parameters):

```cshtml
<component type="typeof(ColorfulCheckbox)" render-mode="ServerPrerendered" 
    param-Size="10" param-Color="@("blue")" />
```

Passing a quoted string requires an [explicit Razor expression](xref:mvc/views/razor#explicit-razor-expressions), as shown for `param-Color` in the preceding example. The Razor parsing behavior for a `string` type value doesn't apply to `param-*` attributes because the attribute is an `object` type.

The parameter type must be JSON serializable, which typically means that the type must have a default constructor and settable properties. For example, you can specify a value for `Size` and `Color` in the preceding example because the types of `Size` and `Color` are primitive types (`int` and `string`), which are supported by the JSON serializer.

`RenderMode` configures whether the component:

* Is prerendered into the page.
* Is rendered as static HTML on the page or if it includes the necessary information to bootstrap a Blazor app from the user agent.

| `RenderMode`        | Description |
| ------------------- | ----------- |
| `ServerPrerendered` | Renders the component into static HTML and includes a marker for a Blazor Server app. When the user-agent starts, this marker is used to bootstrap a Blazor app. |
| `Server`            | Renders a marker for a Blazor Server app. Output from the component isn't included. When the user-agent starts, this marker is used to bootstrap a Blazor app. |
| `Static`            | Renders the component into static HTML. |

While pages and views can use components, the converse isn't true. Components can't use view- and page-specific features, such as partial views and sections. To use logic from partial view in a component, factor out the partial view logic into a component.

Rendering server components from a static HTML page isn't supported.

## Additional resources

* <xref:Microsoft.AspNetCore.Mvc.TagHelpers.ComponentTagHelper>
* <xref:mvc/views/tag-helpers/intro>
* <xref:blazor/components>
