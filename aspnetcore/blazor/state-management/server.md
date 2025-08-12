---
title: ASP.NET Core Blazor server-side state management
author: guardrex
description: Learn how to persist user data (state) in server-side Blazor apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.custom: mvc
ms.date: 08/05/2025
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

When a user can't be reconnected to their original circuit, the user receives a new circuit with newly initialized state. This is equivalent to closing and reopening a desktop app.

## When to persist user state

State persistence isn't automatic. You must take steps when developing the app to implement stateful data persistence.

Generally, maintain state across circuits where users are actively creating data, not simply reading data that already exists.

Data persistence is typically only required for high-value state that users expended effort to create. Persisting state either saves time or aids in commercial activities:

* Multi-step web forms: It's time-consuming for a user to re-enter data for several completed steps of a multi-step web form if their state is lost. A user loses state in this scenario if they navigate away from the form and return later.
* Shopping carts: Any commercially important component of an app that represents potential revenue can be maintained. A user who loses their state, and thus their shopping cart, may purchase fewer products or services when they return to the website later.

An app can only persist *app state*. UIs can't be persisted, such as component instances and their render trees. Components and render trees aren't generally serializable. To persist UI state, such as the expanded nodes of a tree view control, the app must use custom code to model the behavior of the UI state as serializable app state.

:::moniker range=">= aspnetcore-10.0"

## Circuit state persistence

During server-side rendering, Blazor Web Apps can persist a user's session (circuit) state when the connection to the server is lost for an extended period of time or proactively paused, as long as a full-page refresh isn't triggered. This allows users to resume their session without losing unsaved work in the following scenarios:

* Browser tab throttling
* Mobile device users switching apps
* Network interruptions
* Proactive resource management (pausing inactive circuits)

<!-- UPDATE 10.0 - Arriving for RC1 ...

                   Guidance changes for persistent component state with enhanced nav
                   will be on the upcoming docs PR for RC1.

                   API review for support persistent component state on enhanced navigation
                   https://github.com/dotnet/aspnetcore/issues/62773
                   -->

*[Enhanced navigation](xref:blazor/fundamentals/routing#enhanced-navigation-and-form-handling) with circuit state persistence isn't currently supported but planned for a future release.*

Server resources can be freed up if the circuit state can be persisted and then resumed later:

* Even if disconnected, a circuit might continue to perform work and consume CPU, memory, and other resources. Persisted state only consumes a fixed amount of memory that the developer controls.
* Persisted state represents a subset of the memory consumed by the app, so the server isn't required to keep track of the app's components and other server-side objects.

State is persisted for two scenarios:

* Component state: State that components use for Interactive Server rendering, for example, a list of items retrieved from the database or a form that the user is filling out.
* Scoped services: State held inside of a server-side service, for example, the current user.

Conditions:

* The feature is only effective for Interactive Server rendering.
* If the user refreshes the page (app), the persisted state is lost.
* The state must be JSON serializable. Cyclic references or ORM entities may not serialize correctly.
* Use `@key` for uniqueness when rendering components in a loop to avoid key conflicts.
* Persist only necessary state. Storing excessive data may impact performance.
* No automatic hibernation. You must opt-in and configure state persistence explicitly.
* No guarantee of recovery. If state persistence fails, the app falls back to the default disconnected experience.

State persistence is enabled by default when <xref:Microsoft.Extensions.DependencyInjection.ServerRazorComponentsBuilderExtensions.AddInteractiveServerComponents%2A> is called on <xref:Microsoft.Extensions.DependencyInjection.RazorComponentsServiceCollectionExtensions.AddRazorComponents%2A> in the `Program` file. <xref:Microsoft.Extensions.Caching.Memory.MemoryCache> is the default storage implementation for single app instances and stores up to 1,000 persisted circuits for two hours, which are configurable.

Use the following options to change the default values of the in-memory provider:

* `PersistedCircuitInMemoryMaxRetained` (`{CIRCUIT COUNT}` placeholder): The maximum number of circuits to retain. The default is 1,000 circuits. For example, use `2000` to retain state for up to 2,000 circuits.
* `PersistedCircuitInMemoryRetentionPeriod` (`{RETENTION PERIOD}` placeholder): The maximum retention period as a <xref:System.TimeSpan>. The default is two hours. For example, use `TimeSpan.FromHours(3)` for a three-hour retention period.

```csharp
services.Configure<CircuitOptions>(options =>
{
    options.PersistedCircuitInMemoryMaxRetained = {CIRCUIT COUNT};
    options.PersistedCircuitInMemoryRetentionPeriod = {RETENTION PERIOD};
});
```

Persisting component state across circuits is built on top of the existing <xref:Microsoft.AspNetCore.Components.PersistentComponentState> API, which continues to persist state for prerendered components that adopt an interactive render mode. For more information, see <xref:blazor/state-management/prerendered-state-persistence>.

> [NOTE]
> Persisting component state for prerendering works for any interactive render mode, but circuit state persistence only works for the **Interactive Server** render mode.

Annotate component properties with `[PersistentState]` to enable circuit state persistence. The following example also keys the items with the [`@key` directive attribute](xref:blazor/components/key) to provide a unique identifier for each component instance:

```razor
@foreach (var item in Items)
{
    <ItemDisplay @key="@($"unique-prefix-{item.Id}")" Item="item" />
}

@code {
    [PersistentState]
    public List<Item> Items { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Items ??= await LoadItemsAsync();
    }
}
```

To persist state for scoped services, annotate service properties with `[PersistentState]`, add the service to the service collection, and call the <xref:Microsoft.Extensions.DependencyInjection.RazorComponentsRazorComponentBuilderExtensions.RegisterPersistentService%2A> extension method with the service:

```csharp
public class CustomUserService
{
    [PersistentState]
    public string UserData { get; set; }
}

services.AddScoped<CustomUserService>();

services.AddRazorComponents()
  .AddInteractiveServerComponents()
  .RegisterPersistentService<CustomUserService>(RenderMode.InteractiveAuto);
```

> [NOTE]
> The preceding example persists `UserData` state when the service is used in component prerendering for both Interactive Server and Interactive WebAssembly rendering because `RenderMode.InteractiveAuto` is specified to `RegisterPersistentService`. However, circuit state persistence is only available for the **Interactive Server** render mode.

To handle distributed state persistence (and to act as the default state persistence mechanism when configured), assign a [`HybridCache`](xref:performance/caching/overview#hybridcache) (API: <xref:Microsoft.Extensions.Caching.Hybrid.HybridCache>) to the app, which configures its own persistence period (`PersistedCircuitDistributedRetentionPeriod`, eight hours by default). `HybridCache` is used because it provides a unified approach to distributed storage that doesn't require separate packages for each storage provider.

In the following example, a <xref:Microsoft.Extensions.Caching.Hybrid.HybridCache> is implemented with the [Redis](https://redis.io/) storage provider:

```csharp
services.AddHybridCache()
    .AddRedis("{CONNECTION STRING}");

services.AddRazorComponents()
    .AddInteractiveServerComponents();
```

In the preceding example, the `{CONNECTION STRING}` placeholder represents the Redis cache connection string, which should be provided using a secure approach, such as the [Secret Manager](xref:security/app-secrets#secret-manager) tool in the Development environment or [Azure Key Vault](/azure/key-vault/) with [Azure Managed Identities](/entra/identity/managed-identities-azure-resources/overview) for Azure-deployed apps in any environment.

## Pause and resume circuits

Pause and resume circuits to implement custom policies that improve the scalability of an app.

Pausing a circuit stores details about the circuit in client-side browser storage and evicts the circuit, which frees server resources. Resuming the circuit establishes a new circuit and initializes it using the persisted state.

From a JavaScript event handler:

* Call `Blazor.pause` to pause a circuit.
* Call `Blazor.resume` to resume a circuit.

The following example assumes that a circuit isn't required for an app that isn't visible:

```javascript
window.addEventListener('visibilitychange', () => {
  if (document.visibilityState === 'hidden') {
    Blazor.pause();
  } else if (document.visibilityState === 'visible') {
    Blazor.resume();
  }
});
```

:::moniker-end

:::moniker range="< aspnetcore-10.0"

## Persist state across circuits

Generally, maintain state across circuits where users are actively creating data, not simply reading data that already exists.

To preserve state across circuits, the app must persist the data to some other storage location than the server's memory. State persistence isn't automatic. You must take steps when developing the app to implement stateful data persistence.

Data persistence is typically only required for high-value state that users expended effort to create. In the following examples, persisting state either saves time or aids in commercial activities:

* Multi-step web forms: It's time-consuming for a user to re-enter data for several completed steps of a multi-step web form if their state is lost. A user loses state in this scenario if they navigate away from the form and return later.
* Shopping carts: Any commercially important component of an app that represents potential revenue can be maintained. A user who loses their state, and thus their shopping cart, may purchase fewer products or services when they return to the site later.

An app can only persist *app state*. UIs can't be persisted, such as component instances and their render trees. Components and render trees aren't generally serializable. To persist UI state, such as the expanded nodes of a tree view control, the app must use custom code to model the behavior of the UI state as serializable app state.

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

## Browser storage

For more information, see <xref:blazor/state-management/protected-browser-storage>.

## Additional resources

* [State management using the URL](xref:blazor/state-management/index#url)
* [In-memory state container service](xref:blazor/state-management/index#in-memory-state-container-service)
* [Cascading values and parameters](xref:blazor/state-management/index#cascading-values-and-parameters)
* [Managing state via an external server API](xref:blazor/call-web-api)
