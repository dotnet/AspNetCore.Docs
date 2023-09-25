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

<!-- UPDATE 8.0 Content is TBD for the general concepts here -->

> [!IMPORTANT]
> This article is currently undergoing updates for .NET 8. Please check back periodically for new content or when .NET 8 is released.

## Prerequisites

:::moniker range=">= aspnetcore-8.0"

Follow the guidance in the *Configuration* section of the <xref:blazor/components/integration> article.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

Follow the guidance in the *Configuration* section for either:

* [Blazor WebAssembly](xref:blazor/components/prerendering-and-integration?pivots=webassembly)
* [Blazor Server](xref:blazor/components/prerendering-and-integration?pivots=server)

:::moniker-end

## Persist state for prerendered components

:::moniker range=">= aspnetcore-8.0"

<!-- UPDATE 8.0 Content is TBD for the general concepts here -->

> [!IMPORTANT]
> This section is currently undergoing updates for .NET 8.

<!-- UPDATE 8.0

For more information, see <xref:blazor/components/prerender#persist-prerendered-state>.

-->

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

## Prerendered state size and SignalR message size limit

*This section only applies to server-side Blazor apps.*

A large prerendered state size may exceed the SignalR circuit message size limit, which results in the following:

* The SignalR circuit fails to initialize with an error on the client: :::no-loc text="Circuit host not initialized.":::
* The reconnection dialog on the client appears when the circuit fails. Recovery isn't possible.

To resolve the problem, use ***either*** of the following approaches:

* Reduce the amount of data that you are putting into the prerendered state.
* Increase the [SignalR message size limit](xref:blazor/fundamentals/signalr#circuit-handler-options-for-blazor-server-apps). ***WARNING***: Increasing the limit may increase the risk of Denial of service (DoS) attacks.

## Additional resources

* <xref:Microsoft.AspNetCore.Mvc.TagHelpers.ComponentTagHelper>
* <xref:mvc/views/tag-helpers/intro>
* <xref:blazor/components/index>
