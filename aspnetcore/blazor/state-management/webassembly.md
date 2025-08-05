---
title: ASP.NET Core Blazor WebAssembly state management
author: guardrex
description: Learn how to persist user data (state) in Blazor WebAssembly apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.custom: mvc
ms.date: 08/05/2025
uid: blazor/state-management/webassembly
---
# ASP.NET Core Blazor WebAssembly state management

[!INCLUDE[](~/includes/not-latest-version.md)]

This article describes common approaches for maintaining a user's data (state) in Blazor WebAssembly apps.

## Maintain user state

User state created in a Blazor WebAssembly app is held in the browser's memory.

Examples of user state held in browser memory include:

* The hierarchy of component instances and their most recent render output in the rendered UI.
* The values of fields and properties in component instances.
* Data held in [dependency injection (DI)](xref:fundamentals/dependency-injection) service instances.
* Values set through [JavaScript interop](xref:blazor/js-interop/call-javascript-from-dotnet) calls.

When a user closes and reopens their browser or reloads the page, user state held in the browser's memory is lost.

> [!NOTE]
> [Protected Browser Storage](xref:blazor/state-management/protected-browser-storage#aspnet-core-protected-browser-storage) (<xref:Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage?displayProperty=fullName> namespace) relies on ASP.NET Core Data Protection and is only supported for server-side Blazor apps.

## Persist state across browser sessions

Generally, maintain state across browser sessions where users are actively creating data, not simply reading data that already exists.

To preserve state across browser sessions, the app must persist the data to some other storage location than the browser's memory. State persistence isn't automatic. You must take steps when developing the app to implement stateful data persistence.

Data persistence is typically only required for high-value state that users expended effort to create. In the following examples, persisting state either saves time or aids in commercial activities:

* Multi-step web forms: It's time-consuming for a user to re-enter data for several completed steps of a multi-step web form if their state is lost. A user loses state in this scenario if they navigate away from the form and return later.
* Shopping carts: Any commercially important component of an app that represents potential revenue can be maintained. A user who loses their state, and thus their shopping cart, may purchase fewer products or services when they return to the site later.

An app can only persist *app state*. UIs can't be persisted, such as component instances and their render trees. Components and render trees aren't generally serializable. To persist UI state, such as the expanded nodes of a tree view control, the app must use custom code to model the behavior of the UI state as serializable app state.

## Server-side storage

For permanent data persistence that spans multiple users and devices, the app can use independent server-side storage accessed via a web API. Options include:

* Blob storage
* Key-value storage
* Relational database
* Table storage

After data is saved, the user's state is retained and available in any new browser session.

Because Blazor WebAssembly apps run entirely in the user's browser, they require additional measures to access secure external systems, such as storage services and databases. Blazor WebAssembly apps are secured in the same manner as single-page applications (SPAs). Typically, an app authenticates a user via [OAuth](https://oauth.net)/[OpenID Connect (OIDC)](https://openid.net/developers/how-connect-works/) and then interacts with storage services and databases through web API calls to a server-side app. The server-side app mediates the transfer of data between the Blazor WebAssembly app and the storage service or database. The Blazor WebAssembly app maintains an ephemeral connection to the server-side app, while the server-side app has a persistent connection to storage.

For more information, see the following resources:

* <xref:blazor/call-web-api>
* <xref:blazor/security/webassembly/index>
* Blazor *Security and Identity* articles

For more information on Azure data storage options, see the following:

* [Azure Databases](https://azure.microsoft.com/product-categories/databases/)
* [Azure Storage Documentation](/azure/storage/)

## Additional resources

* [State management using the URL](xref:blazor/state-management/index#url)
* [In-memory state container service](xref:blazor/state-management/index#in-memory-state-container-service)
* [Cascading values and parameters](xref:blazor/state-management/index#cascading-values-and-parameters)
* [Save app state before an authentication operation (Blazor WebAssembly)](xref:blazor/security/webassembly/additional-scenarios#save-app-state-before-an-authentication-operation)
* Managing state via an external server API
  * <xref:blazor/call-web-api>
  * <xref:blazor/security/webassembly/index>
