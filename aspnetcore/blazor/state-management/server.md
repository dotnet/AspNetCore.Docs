---
title: ASP.NET Core Blazor server-side state management
author: guardrex
description: Learn how to persist user data (state) in server-side Blazor apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.custom: mvc
ms.date: 07/31/2025
uid: blazor/state-management/server
---
# ASP.NET Core Blazor server-side state management

[!INCLUDE[](~/includes/not-latest-version.md)]

This article describes common approaches for maintaining a user's data (state) in server-side Blazor scenarios.

## Maintain user state

Server-side Blazor is a stateful app framework. Most of the time, the app maintains a connection to the server. The user's state is held in the server's memory in a *circuit*.

Examples of user state held in a circuit include:

* The hierarchy of component instances and their most recent render output in the rendered UI.
* The values of fields and properties in component instances.
* Data held in [dependency injection (DI)](xref:fundamentals/dependency-injection) service instances that are scoped to the circuit.

User state might also be found in JavaScript variables in the browser's memory set via [JavaScript interop](xref:blazor/js-interop/call-javascript-from-dotnet) calls.

If a user experiences a temporary network connection loss, Blazor attempts to reconnect the user to their original circuit with their original state. However, reconnecting a user to their original circuit in the server's memory isn't always possible:

* The server can't retain a disconnected circuit forever. The server must release a disconnected circuit after a timeout or when the server is under memory pressure.
* In multi-server, load-balanced deployment environments, individual servers may fail or be automatically removed when no longer required to handle the overall volume of requests. The original server processing requests for a user may become unavailable when the user attempts to reconnect.
* The user might close and reopen their browser or reload the page, which removes any state held in the browser's memory. For example, JavaScript variable values set through JavaScript interop calls are lost.

When a user can't be reconnected to their original circuit, the user receives a new circuit with an empty state. This is equivalent to closing and reopening a desktop app.

:::moniker range="< aspnetcore-10.0"

## Persist state across circuits

Generally, maintain state across circuits where users are actively creating data, not simply reading data that already exists.

To preserve state across circuits, the app must persist the data to some other storage location than the server's memory. State persistence isn't automatic. You must take steps when developing the app to implement stateful data persistence.

Data persistence is typically only required for high-value state that users expended effort to create. In the following examples, persisting state either saves time or aids in commercial activities:

* Multi-step web forms: It's time-consuming for a user to re-enter data for several completed steps of a multi-step web form if their state is lost. A user loses state in this scenario if they navigate away from the form and return later.
* Shopping carts: Any commercially important component of an app that represents potential revenue can be maintained. A user who loses their state, and thus their shopping cart, may purchase fewer products or services when they return to the site later.

An app can only persist *app state*. UIs can't be persisted, such as component instances and their render trees. Components and render trees aren't generally serializable. To persist UI state, such as the expanded nodes of a tree view control, the app must use custom code to model the behavior of the UI state as serializable app state.

:::moniker-end

## Where to persist state

This article covers common locations for persisting state:

:::moniker range=">= aspnetcore-10.0"

* [Circuit state (and prerendering state) preservation](#circuit-state-and-prerendering-state-preservation)
* [Declarative model for persistent state](#declarative-model-for-persisting-state)
* [Server-side storage](#server-side-storage)
* [URL](#url)

:::moniker-end

:::moniker range="< aspnetcore-10.0"

* [Server-side storage](#server-side-storage)
* [URL](#url)

:::moniker-end

For guidance on using browser storage in server-side Blazor apps, see <xref:blazor/state-management/browser-storage>.

Additional locations available for both server-side Blazor apps and Blazor WebAssembly apps (covered in the overview):

* [In-memory state container service](xref:blazor/state-management/index#in-memory-state-container-service)
* [Cascading values and parameters](xref:blazor/state-management/index#cascading-values-and-parameters)

:::moniker range=">= aspnetcore-10.0"

## Circuit state (and prerendering state) preservation








## Declarative model for persisting state

Establish declarative state in a dependency injection service for use around the app by calling <xref:Microsoft.Extensions.DependencyInjection.RazorComponentsRazorComponentBuilderExtensions.RegisterPersistentService%2A> on the Razor components builder (<xref:Microsoft.Extensions.DependencyInjection.RazorComponentsServiceCollectionExtensions.AddRazorComponents%2A>) with a custom service type and render mode. For more information, see <xref:blazor/components/prerender#persist-prerendered-state>.

:::moniker-end

## Server-side storage

For permanent data persistence that spans multiple users and devices, the app can use server-side storage. Options include:

* Blob storage
* Key-value storage
* Relational database
* Table storage

After data is saved, the user's state is retained and available in any new circuit.

For more information on Azure data storage options, see the following:

* [Azure Databases](https://azure.microsoft.com/product-categories/databases/)
* [Azure Storage Documentation](/azure/storage/)

## URL

For transient data representing navigation state, model the data as a part of the URL. Examples of user state modeled in the URL include:

* The ID of a viewed entity.
* The current page number in a paged grid.

The contents of the browser's address bar are retained:

* If the user manually reloads the page.
* If the web server becomes unavailable, and the user is forced to reload the page in order to connect to a different server.

For information on defining URL patterns with the [`@page`](xref:mvc/views/razor#page) directive, see <xref:blazor/fundamentals/routing>.



## Additional resources

[Managing state via an external server API](xref:blazor/call-web-api)
