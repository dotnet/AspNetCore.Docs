---
title: Persist Component State Tag Helper in ASP.NET Core
description: Learn how to use the ASP.NET Core Persist Component State Tag Helper to persist state when prerendering components.
monikerRange: '>= aspnetcore-6.0'
ms.date: 09/25/2023
---
# Persist Component State Tag Helper in ASP.NET Core

The Persist Component State Tag Helper saves the state of non-routable Razor components rendered in a page or view of a Razor Pages or MVC app.

## Prerequisites

:::moniker range=">= aspnetcore-8.0"

Follow the guidance in the *Use non-routable components in pages or views* section of the [Integrate ASP.NET Core Razor components with MVC or Razor Pages](../../../../blazor/components/integration.md#render-components-from-a-page-or-view) article.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

Follow the guidance in the *Configuration* section for either:

* [Blazor WebAssembly](../../../../blazor/components/integration.md?pivots=webassembly)
* [Blazor Server](../../../../blazor/components/integration.md?pivots=server)

:::moniker-end

## Persist state for prerendered components

:::moniker range=">= aspnetcore-8.0"

To persist state for prerendered components, use the [Persist Component State Tag Helper](persist-component-state.md) ([reference source](https://github.com/dotnet/aspnetcore/blob/main/src/Mvc/Mvc.TagHelpers/src/PersistComponentStateTagHelper.cs)). Add the Tag Helper's tag, `<persist-component-state />`, inside the closing `</body>` tag of the layout in an app that prerenders components.

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

In `Pages/Shared/_Layout.cshtml` for embedded components that are either WebAssembly prerendered (`WebAssemblyPrerendered`) or server prerendered (`ServerPrerendered`):

```cshtml
<body>
    ...

    <persist-component-state />
</body>
```

Decide what state to persist using the <xref:Microsoft.AspNetCore.Components.PersistentComponentState> service. [`PersistentComponentState.RegisterOnPersisting`](xref:Microsoft.AspNetCore.Components.PersistentComponentState.RegisterOnPersisting*) registers a callback to persist the component state before the app is paused. The state is retrieved when the application resumes.

For more information and examples, see <xref:blazor/state-management/prerendered-state-persistence>.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

To persist state for prerendered components, use the [Persist Component State Tag Helper](persist-component-state.md) ([reference source](https://github.com/dotnet/aspnetcore/blob/main/src/Mvc/Mvc.TagHelpers/src/PersistComponentStateTagHelper.cs)). Add the Tag Helper's tag, `<persist-component-state />`, inside the closing `</body>` tag of the `_Host` page in an app that prerenders components.

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

In `Pages/_Host.cshtml` of Blazor apps that are either WebAssembly prerendered (`WebAssemblyPrerendered`) in a hosted Blazor WebAssembly app or `ServerPrerendered` in a Blazor Server app:

```cshtml
<body>
    ...

    <persist-component-state />
</body>
```

Decide what state to persist using the <xref:Microsoft.AspNetCore.Components.PersistentComponentState> service. [`PersistentComponentState.RegisterOnPersisting`](xref:Microsoft.AspNetCore.Components.PersistentComponentState.RegisterOnPersisting*) registers a callback to persist the component state before the app is paused. The state is retrieved when the application resumes.

For more information and examples, see [Integrate ASP.NET Core Razor components with MVC or Razor Pages](../../../../blazor/components/integration.md#persist-prerendered-state).

:::moniker-end

## Related content

:::moniker range=">= aspnetcore-8.0"

* [Component Tag Helper in ASP.NET Core](component-tag-helper.md)
* [Prerender ASP.NET Core Razor components](../../../../blazor/components/prerender.md)
* <xref:Microsoft.AspNetCore.Mvc.TagHelpers.ComponentTagHelper>
* [Tag Helpers in ASP.NET Core](../intro.md)
* [ASP.NET Core Razor components](../../../../blazor/components/index.md)

:::moniker-end

:::moniker range="< aspnetcore-8.0"

* [Component Tag Helper in ASP.NET Core](component-tag-helper.md)
* [Integrate ASP.NET Core Razor components with MVC or Razor Pages](../../../../blazor/components/integration.md)
* <xref:Microsoft.AspNetCore.Mvc.TagHelpers.ComponentTagHelper>
* [Tag Helpers in ASP.NET Core](../intro.md)
* [ASP.NET Core Razor components](../../../../blazor/components/index.md)

:::moniker-end
