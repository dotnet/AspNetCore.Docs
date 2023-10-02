---
title: Persist Component State Tag Helper in ASP.NET Core
author: guardrex
ms.author: riande
description: Learn how to use the ASP.NET Core Persist Component State Tag Helper to persist state when prerendering components.
monikerRange: '>= aspnetcore-6.0'
ms.custom: mvc
ms.date: 09/25/2023
uid: mvc/views/tag-helpers/builtin-th/persist-component-state-tag-helper
---
# Persist Component State Tag Helper in ASP.NET Core

The Persist Component State Tag Helper saves the state of non-routable Razor components rendered in a page or view of a Razor Pages or MVC app.

## Prerequisites

:::moniker range=">= aspnetcore-8.0"

Follow the guidance in the *Use non-routable components in pages or views* section of the <xref:blazor/components/integration#use-non-routable-components-in-pages-or-views> article.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

Follow the guidance in the *Configuration* section for either:

* [Blazor WebAssembly](xref:blazor/components/prerendering-and-integration?pivots=webassembly)
* [Blazor Server](xref:blazor/components/prerendering-and-integration?pivots=server)

:::moniker-end

## Persist state for prerendered components

:::moniker range=">= aspnetcore-8.0"

To persist state for prerendered components, use the [Persist Component State Tag Helper](xref:mvc/views/tag-helpers/builtin-th/persist-component-state-tag-helper) ([reference source](https://github.com/dotnet/aspnetcore/blob/main/src/Mvc/Mvc.TagHelpers/src/PersistComponentStateTagHelper.cs)). Add the Tag Helper's tag, `<persist-component-state />`, inside the closing `</body>` tag of the layout in an app that prerenders components.

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

In `Pages/Shared/_Layout.cshtml` for embedded components that are either WebAssembly prerendered (`WebAssemblyPrerendered`) or server prerendered (`ServerPrerendered`):

```cshtml
<body>
    ...

    <persist-component-state />
</body>
```

Decide what state to persist using the <xref:Microsoft.AspNetCore.Components.PersistentComponentState> service. [`PersistentComponentState.RegisterOnPersisting`](xref:Microsoft.AspNetCore.Components.PersistentComponentState.RegisterOnPersisting%2A) registers a callback to persist the component state before the app is paused. The state is retrieved when the application resumes.

For more information and examples, see <xref:blazor/components/prerender#persist-prerendered-state>.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

To persist state for prerendered components, use the [Persist Component State Tag Helper](xref:mvc/views/tag-helpers/builtin-th/persist-component-state-tag-helper) ([reference source](https://github.com/dotnet/aspnetcore/blob/main/src/Mvc/Mvc.TagHelpers/src/PersistComponentStateTagHelper.cs)). Add the Tag Helper's tag, `<persist-component-state />`, inside the closing `</body>` tag of the `_Host` page in an app that prerenders components.

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

In `Pages/_Host.cshtml` of Blazor apps that are either WebAssembly prerendered (`WebAssemblyPrerendered`) in a hosted Blazor WebAssembly app or `ServerPrerendered` in a Blazor Server app:

```cshtml
<body>
    ...

    <persist-component-state />
</body>
```

Decide what state to persist using the <xref:Microsoft.AspNetCore.Components.PersistentComponentState> service. [`PersistentComponentState.RegisterOnPersisting`](xref:Microsoft.AspNetCore.Components.PersistentComponentState.RegisterOnPersisting%2A) registers a callback to persist the component state before the app is paused. The state is retrieved when the application resumes.

For more information and examples, see <xref:blazor/components/prerendering-and-integration#persist-prerendered-state>.

:::moniker-end

## Additional resources

:::moniker range=">= aspnetcore-8.0"

* <xref:mvc/views/tag-helpers/builtin-th/component-tag-helper>
* <xref:blazor/components/prerender>
* <xref:Microsoft.AspNetCore.Mvc.TagHelpers.ComponentTagHelper>
* <xref:mvc/views/tag-helpers/intro>
* <xref:blazor/components/index>

:::moniker-end

:::moniker range="< aspnetcore-8.0"

* <xref:mvc/views/tag-helpers/builtin-th/component-tag-helper>
* <xref:blazor/components/prerendering-and-integration>
* <xref:Microsoft.AspNetCore.Mvc.TagHelpers.ComponentTagHelper>
* <xref:mvc/views/tag-helpers/intro>
* <xref:blazor/components/index>

:::moniker-end
