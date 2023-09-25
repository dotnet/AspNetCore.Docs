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

For more information, see <xref:blazor/components/prerender#persist-prerendered-state>.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

For more information, see <xref:blazor/components/prerendering-and-integration#persist-prerendered-state>.

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
