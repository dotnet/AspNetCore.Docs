---
title: ASP.NET Core Blazor server-side state management
ai-usage: ai-assisted
author: guardrex
description: Learn how to persist user data (state) in server-side Blazor apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.date: 07/23/2026
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
* [Enhanced navigation](xref:blazor/fundamentals/navigation#enhanced-navigation-and-form-handling)

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

* <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.PersistedCircuitInMemoryMaxRetained%2A> (`{CIRCUIT COUNT}` placeholder): The maximum number of circuits to retain. The default is 1,000 circuits. For example, use `2000` to retain state for up to 2,000 circuits.
* <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.PersistedCircuitInMemoryRetentionPeriod%2A> (`{RETENTION PERIOD}` placeholder): The maximum retention period as a <xref:System.TimeSpan>. The default is two hours. For example, use `TimeSpan.FromHours(3)` for a three-hour retention period.

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

Annotate component `public` properties with the [`[PersistentState]` attribute](xref:Microsoft.AspNetCore.Components.PersistentStateAttribute) to enable circuit state persistence. The following example also keys the items with the [`@key` directive attribute](xref:blazor/components/key) to provide a unique identifier for each component instance:

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

To persist state for a scoped service:

* Annotate the `public` service property with the [`[PersistentState]` attribute](xref:Microsoft.AspNetCore.Components.PersistentStateAttribute).
* Add the service to the service collection.
* Call the <xref:Microsoft.Extensions.DependencyInjection.RazorComponentsRazorComponentBuilderExtensions.RegisterPersistentService%2A> extension method with the service.

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
> The preceding example persists `UserData` state when the service is used in component prerendering for both Interactive Server and Interactive WebAssembly rendering because `RenderMode.InteractiveAuto` is specified to <xref:Microsoft.Extensions.DependencyInjection.RazorComponentsRazorComponentBuilderExtensions.RegisterPersistentService%2A>. However, circuit state persistence is only available for the **Interactive Server** render mode.

To handle distributed state persistence (and to act as the default state persistence mechanism when configured), assign a [`HybridCache`](xref:performance/caching/overview#hybridcache) (API: <xref:Microsoft.Extensions.Caching.Hybrid.HybridCache>) to the app, which configures its own persistence period (<xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.PersistedCircuitDistributedRetentionPeriod%2A>, eight hours by default). `HybridCache` is used because it provides a unified approach to distributed storage that doesn't require separate packages for each storage provider.

In the following example, a <xref:Microsoft.Extensions.Caching.Hybrid.HybridCache> is implemented with the [Redis](https://redis.io/) storage provider:

```csharp
services.AddHybridCache()
    .AddRedis("{CONNECTION STRING}");

services.AddRazorComponents()
    .AddInteractiveServerComponents();
```

In the preceding example, the `{CONNECTION STRING}` placeholder represents the Redis cache connection string, which should be provided using a secure approach, such as the [Secret Manager](xref:security/app-secrets#secret-manager) tool in the `Development` environment or [Azure Key Vault](/azure/key-vault/) with [Azure Managed Identities](/entra/identity/managed-identities-azure-resources/overview) for Azure-deployed apps in any environment.

For more information on the [`[PersistentState]` attribute](xref:Microsoft.AspNetCore.Components.PersistentStateAttribute), see <xref:blazor/state-management/prerendered-state-persistence>.

## Pause and resume circuits

Pause and resume circuits to implement custom policies that improve the scalability of an app.

Pausing a circuit stores details about the circuit in client-side browser storage and evicts the circuit, which frees server resources. Resuming the circuit establishes a new circuit and initializes it using the persisted state.

From a JavaScript event handler:

* Call `Blazor.pauseCircuit()` to pause a circuit.
* Call `Blazor.resumeCircuit()` to resume a circuit.

The following example assumes that a circuit isn't required for an app that isn't visible:

```javascript
window.addEventListener('visibilitychange', () => {
  if (document.visibilityState === 'hidden') {
    Blazor.pauseCircuit();
  } else if (document.visibilityState === 'visible') {
    Blazor.resumeCircuit();
  }
});
```

:::moniker-end

:::moniker range=">= aspnetcore-11.0"

## Automatic circuit pause on tab inactivity

<!-- UPDATE 11.0 - API browser cross-links -->

Auto-pause can pause a circuit when the browser tab becomes hidden, freeing server memory and SignalR connections held by inactive users. It's an opt-in feature provided by the `Microsoft.AspNetCore.Components.Server.AutoPause` package. After adding a package reference, enable the feature by calling `AddAutoPause` when the app's root component is mapped:

```csharp
app.MapRazorComponents<App>()
    .WithBrowserOptions(options => options.AddAutoPause(p => p.HiddenDelay = TimeSpan.FromSeconds(30)));
```

`AddAutoPause` configures an `AutoPauseBrowserOptions` instance with the following properties:

* `Enabled`: Whether auto-pause is enabled. Defaults to `true`, so calling `AddAutoPause` is what enables the feature.
* `HiddenDelay`: The delay after the tab becomes hidden before the circuit pauses. Defaults to two minutes (`TimeSpan.FromMinutes(2)`) and must be greater than `TimeSpan.Zero`.

After the tab is hidden for `HiddenDelay`, the circuit pauses. If the user returns before the delay elapses, the pause doesn't occur.

> [!NOTE]
> Auto-pause triggers on the [Page Visibility API](https://developer.mozilla.org/docs/Web/API/Page_Visibility_API) `visibilitychange` event, whose meaning differs by platform:
>
> * On desktop, the tab becomes hidden when the user switches tabs or minimizes the window. The pause timer runs reliably, and the circuit pauses gracefully after the delay.
> * On mobile, the page also becomes hidden when the *whole app* is backgrounded (switching apps, returning to the home screen, or locking the screen), not just when switching browser tabs.
>
> On mobile, the operating system suspends the page's JavaScript shortly after the app is backgrounded (within seconds on Android, up to about 30 seconds on iOS). If `HiddenDelay` is longer than that window, the pause timer never fires, and the circuit is dropped by the OS-initiated disconnect instead of pausing gracefully. The session is still preserved through the normal reconnection and [circuit state persistence](#circuit-state-persistence) path, but the client-side veto and deferral logic doesn't run. For this reason, graceful auto-pause isn't guaranteed and isn't a supported scenario on mobile when the app is backgrounded.

The package defers the pause while circuit-owned work is in progress (downloads, uploads, JS interop calls, Web Locks, Picture-in-Picture). It vetoes the pause entirely while focused text `<input>` elements with Blazor `@bind` bindings are edited or audio/video is playing.

For elements without Blazor bindings (for example, `<canvas>`, WebRTC connections, or custom elements), the app is responsible for handling state. Register a circuit handler with an `onCircuitPausing` callback in the [Blazor startup configuration](xref:blazor/fundamentals/startup):

```razor
<script src="{BLAZOR SCRIPT}" autostart="false"></script>
<script>
  Blazor.start({
    circuit: {
      circuitHandlers: [
        {
          onCircuitPausing: async (signal /* AbortSignal */) => {
            // Example: save canvas state before the pause proceeds.
            const canvas = document.getElementById('drawing-canvas');
            if (canvas) {
              localStorage.setItem('canvasData', canvas.toDataURL());
            }

            // Example: close an active WebRTC connection gracefully.
            if (window.activePeerConnection && !signal.aborted) {
              window.activePeerConnection.close();
              await new Promise(resolve => {
                signal.addEventListener('abort', resolve);
                setTimeout(resolve, 100);
              });
            }
          }
        }
      ]
    }
  });
</script>
```

> [!NOTE]
> The `<input type="file">` element can't have its value restored after pause/resume due to browser security restrictions. Using `[PersistentState]` on a property bound to a file `<input>` element causes an `InvalidStateError` that crashes the circuit. Instead, capture the file name in a separate property. Because the browser doesn't expose the file name through the native `change` event, read it with a small JS interop helper:
>
> ```razor
> @inject IJSRuntime JS
>
> <input id="persist-upload" type="file" @onchange="HandleFileSelected" />
> <span>@SelectedFileName</span>
>
> @code {
>     [PersistentState(AllowUpdates = true)]
>     public string? SelectedFileName { get; set; }
>
>     private async Task HandleFileSelected(ChangeEventArgs e)
>     {
>         SelectedFileName = await JS.InvokeAsync<string>("getFileName", "persist-upload");
>     }
> }
> ```
>
> ```javascript
> window.getFileName = (id) => document.getElementById(id)?.files?.[0]?.name ?? '';
> ```

:::moniker-end

:::moniker range=">= aspnetcore-11.0"

## Server-triggered circuit pause

A server-side Blazor app that adopts the Interactive Server render mode can implement server-triggered circuit pause, which allows the app to gracefully pause client circuits, preserving client state for seamless reconnection.

This feature is useful in the following scenarios:

* Planned shutdowns and deployments.
* Instance draining.
* App maintenance windows.

`Circuit.RequestCircuitPauseAsync(CancellationToken)` is used to request that the connected client begin the graceful circuit-pause flow. The `CancellationToken` cancels the request before it is accepted by the framework. The method returns `true` if the request was accepted and the client was asked to begin pausing.

<!-- UPDATE 11.0 - API doc cross-links

<xref:Microsoft.AspNetCore.Components.Server.Circuits.Circuit.RequestCircuitPauseAsync%2A>

-->
                       
When a server-side Blazor application shuts down (for example, during deployment), connected clients lose their SignalR connection. The approach in this section:

* Detects shutdown before the server closes connections.
* Triggers a pause on connected circuits via `Microsoft.AspNetCore.Components.Server.Circuits.Circuit.RequestCircuitPauseAsync`.
* Preserves state using [`[PersistentState]` attribute](xref:Microsoft.AspNetCore.Components.PersistentStateAttribute) on component properties.

In the following example implementation, the following code files are placed in a `Shutdown` folder at the root of the app:

* `CircuitShutdownService.cs`: A singleton service that coordinates shutdown.
* `ShutdownCircuitHandler.cs`: A scoped service for each active circuit.
* `ShutdownCircuitOptions.cs`: Configuration options.

`Shutdown/ShutdownCircuitOptions.cs`:

```csharp
namespace PauseResumeOnShutdown.Shutdown;

public class ShutdownCircuitOptions
{
    public TimeSpan ShutdownTimeout { get; set; } = TimeSpan.FromSeconds(10);
}
```

Using the following approach, the fact that the code sends the `RequestCircuitPauseAsync` asynchronously doesn't mean that upon returning the value that the client is already paused. It's only a request to pause the client, which the client can defer. That's why the code includes the <xref:System.Threading.Tasks.TaskCompletionSource> (`_shutdownTcs`), which is set when there aren't any circuits connected (all of them are successfully shut down). In case a client requests a deferral longer than the server allows, longer than `ShutdownTimeout`, the client doesn't persist state and experiences a normal connection loss. Other clients that don't defer the pause request have their connections re-established after the app goes back online with state persisted.

`Shutdown/CircuitShutdownService.cs`:

```csharp
using System.Collections.Concurrent;
using Microsoft.AspNetCore.Components.Server.Circuits;
using Microsoft.Extensions.Options;

namespace PauseResumeOnShutdown.Shutdown;

public class CircuitShutdownService
{
    private readonly ConcurrentDictionary<string, Circuit> 
        _circuits = new();
    private readonly ShutdownCircuitOptions _options;
    private bool _isShuttingDown;
    private TaskCompletionSource _shutdownTcs = new();

    public CircuitShutdownService(IHostApplicationLifetime appLifetime, 
        IOptions<ShutdownCircuitOptions> options)
    {
        _options = options.Value;
        appLifetime.ApplicationStopping.Register(OnApplicationStopping);
    }

    private void OnApplicationStopping()
    {
        _isShuttingDown = true;

        if (_circuits.IsEmpty)
        {
            return;
        }

        var pauseTasks = _circuits.Values
            .Select(c => c.RequestCircuitPauseAsync().AsTask())
            .Append(_shutdownTcs.Task);

        Task.WhenAll(pauseTasks).Wait(_options.ShutdownTimeout);

        _shutdownTcs.Task.Wait(_options.ShutdownTimeout);
    }

    public void Register(string circuitId, Circuit circuit)
    {
        _circuits.TryAdd(circuitId, circuit);
    }

    public void Unregister(string circuitId)
    {
        _circuits.TryRemove(circuitId, out _);

        if (_isShuttingDown && _circuits.IsEmpty)
        {
            _shutdownTcs.TrySetResult();
        }
    }
}
```

`Shutdown/ShutdownCircuitHandler.cs`:

```csharp
using Microsoft.AspNetCore.Components.Server.Circuits;

namespace PauseResumeOnShutdown.Shutdown;

public class ShutdownCircuitHandler(CircuitShutdownService shutdownService) 
    : CircuitHandler
{
    public override Task OnConnectionUpAsync(Circuit circuit, 
        CancellationToken cancellationToken)
    {
        shutdownService.Register(circuit.Id, circuit);

        return Task.CompletedTask;
    }

    public override Task OnConnectionDownAsync(Circuit circuit, 
        CancellationToken cancellationToken)
    {
        shutdownService.Unregister(circuit.Id);

        return Task.CompletedTask;
    }
}
```

`Program.cs`:

```csharp
using Microsoft.AspNetCore.Components.Server.Circuits;
using Microsoft.Extensions.DependencyInjection.Extensions;
using PauseResumeOnShutdown.Components;
using PauseResumeOnShutdown.Shutdown;

var builder = WebApplication.CreateBuilder(args);

// Increase host shutdown timeout to allow time for pause operations
// Must be greater than `ShutdownTimeout` in `ShutdownCircuitOptions` 
// otherwise the host terminates connections before circuits finish 
// pausing
builder.Host.ConfigureHostOptions(options =>
    options.ShutdownTimeout = TimeSpan.FromSeconds(30));

builder.Services.Configure<ShutdownCircuitOptions>(options =>
    options.ShutdownTimeout = TimeSpan.FromSeconds(10));

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register CircuitShutdownService as a singleton
builder.Services.AddSingleton<CircuitShutdownService>();

// Register ShutdownCircuitHandler as a scoped CircuitHandler
builder.Services.TryAddEnumerable(
    ServiceDescriptor.Scoped<CircuitHandler, ShutdownCircuitHandler>());

var app = builder.Build();

// ... rest of pipeline
```

Optionally, to defer pause on the client until critical work completes (for example, an in-flight payment), configure the `onPauseRequested` callback in the [Blazor startup configuration](xref:blazor/fundamentals/startup). Place the following after the [server-side Blazor script reference](xref:blazor/project-structure#location-of-the-blazor-script):

```razor
<script> 
  Blazor.start({
    circuit: {
      onPauseRequested: async () => {
        // Perform any critical cleanup or wait for in-flight operations.
        // Return true to allow the pause or false to reject it.
        return true;
      }
    }
  });
</script>
```

Without the `onPauseRequested` callback, the client pauses immediately when the server requests it.

In a component, use the [`[PersistentState]` attribute](xref:Microsoft.AspNetCore.Components.PersistentStateAttribute) to persist component state across pause/resume. In the following `Counter` component example, the current count (`CurrentCount`) is preserved across server restarts using the preceding approach:

```razor
@page "/counter"
@rendermode InteractiveServer

<PageTitle>Counter</PageTitle>

<h1>Counter</h1>

<p role="status">Current count: @CurrentCount</p>

<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>

@code {
    [PersistentState]
    public int CurrentCount { get; set; }

    private void IncrementCount()
    {
        CurrentCount++;
    }
}
```

For more information on the [`[PersistentState]` attribute](xref:Microsoft.AspNetCore.Components.PersistentStateAttribute), see <xref:blazor/state-management/prerendered-state-persistence>.

-->

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

:::moniker range=">= aspnetcore-11.0"

Data can be stored temporarily or permanently in server-side scenarios.

### Temporary data persistence

<!-- UPDATE 11.0 - API cross-links -->

To persist temporary data between HTTP requests during static server-side rendering (static SSR), Blazor supports `TempData`. `TempData` is ideal for scenarios such as flash messages after form submissions, passing data during redirects (POST-Redirect-GET pattern), and one-time notifications.

> [!IMPORTANT]
> This feature is only available during static server-side rendering (static SSR). During interactive SSR and interactive client-side rendering (CSR), the `TempData` value isn't supplied, and the property retains its default value.
`TempData`:

* Is available when <xref:Microsoft.Extensions.DependencyInjection.RazorComponentsServiceCollectionExtensions.AddRazorComponents%2A> is called in the app's `Program` file.
* Is provided as a cascading value with the [`[CascadingParameter]` attribute](xref:blazor/components/cascading-values-and-parameters#cascadingparameter-attribute) or the `[SupplyParameterFromTempData]` parameter attribute.
* Is accessed by key (string).
* Supports primitives, <xref:System.DateTime>, <xref:System.Guid>, enums, and collections (arrays, <xref:System.Collections.Generic.List%601>, <xref:System.Collections.Generic.Dictionary%602>).
* Stores `object?` values, requiring runtime casting (example: `var message = TempData["Message"] as string`). IntelliSense and type checking aren't supported.
* Uses case-insensitive keys, so `TempData["message"]` and `TempData["Message"]` retrieve the same value.

```csharp
[CascadingParameter]
public ITempData? TempData { get; set; }
```

When supplied to a parameter for simple read/write of a single value, use the `[SupplyParameterFromTempData]` attribute without or with a key (string):

```csharp
[SupplyParameterFromTempData]
public string? Message { get; set; }

[SupplyParameterFromTempData(Name = "flash_message")]
public string? FlashMessage { get; set; }
```

A key (string) is useful to distinguish multiple parameters because properties can't share a temporary data value.

The `ITempData` interface provides the following methods for controlling value lifecycle:

* `Get`: Gets the value associated with the specified key and schedules the data for deletion.
* `Peek`: Returns the value associated with the specified key without marking the data for deletion.
* `Keep`: Marks all keys in the dictionary for retention. Values are available on the next request.
* `Keep(string)`: Marks a specified key (string) for retention. The value is available on the next request.

Data stored in `TempData` is automatically removed after the data is read unless `Keep`/`Keep(string)` is called or the data is accessed via `Peek`.

The default cookie-based provider uses [Data Protection](xref:security/data-protection/introduction) for encryption.

Call `AddCookieTempDataValueProvider` on the service collection in the app's `Program` file passing `CookieTempDataProviderOptions` to change the cookie's parameters in the following table.

Parameter | API | Notes
--- | --- | ---
Name | `Name` | The default value is `.AspNetCore.Components.TempData`.
[HTTP Only](https://developer.mozilla.org/docs/Web/Security/Practical_implementation_guides/Cookies#httponly) | `HttpOnly` | The default value is `true`.
[SameSite value](https://developer.mozilla.org/docs/Web/HTTP/Headers/Set-Cookie#samesitesamesite-value) | `SameSite` | <xref:Microsoft.AspNetCore.Http.SameSiteMode.Strict?displayProperty=nameWithType>
[Secure policy](https://developer.mozilla.org/docs/Web/HTTP/Reference/Headers/Set-Cookie#secure) | `SecurePolicy` | Some browsers don't allow insecure endpoints to set cookies with a 'secure' flag or overwrite cookies whose 'secure' flag is set. Since mixing secure and insecure endpoints is a common scenario in apps, the framework relaxes the restriction on secure policy on some cookies by setting them to 'None'. Cookies related to authentication or authorization use a stronger policy than 'None'. The default value is [`CookieSecurePolicy.None`](xref:Microsoft.AspNetCore.Http.CookieSecurePolicy).

Example (sets default values):

```csharp
builder.Services.AddRazorComponents(options =>
{
    options.TempDataCookie.Name = ".AspNetCore.Components.TempData";
    options.TempDataCookie.HttpOnly = true;
    options.TempDataCookie.SameSite = SameSiteMode.Strict;
    options.TempDataCookie.SecurePolicy = CookieSecurePolicy.None;
});
```

> [!NOTE]

Only JSON-serializable primitives and collections are supported. User-defined classes and custom object serialization aren't supported. Blazor WebAssembly and Blazor Server aren't supported.

Browsers enforce a 4 KB cookie size limit. `TempData` automatically uses <xref:Microsoft.AspNetCore.Authentication.Cookies.ChunkingCookieManager> to split cookies across multiple cookie headers, but developers storing a large amount of data must switch to session storage, which introduces session affinity requirements.

In the following example, a form displays a message that's retained in `TempData` after the form is submitted (a new request).

`Pages/TempDataExample1.razor`:

```razor
@page "/tempdata-example-1"
@inject NavigationManager NavigationManager

<p>@message</p>

<form method="post" @formname="SetMessage" @onsubmit="Submit">
    <AntiforgeryToken />
    <button type="submit">Submit</button>
</form>

@code {
    [CascadingParameter]
    public ITempData? TempData { get; set; }

    private string? message;

    protected override void OnInitialized()
    {
        // Get removes the value after reading (one-time use)
        message = TempData?.Get("Message") as string ?? "No message";
    }

    private void Submit()
    {
        TempData!["Message"] = "Form submitted successfully!";
        NavigationManager.NavigateTo("/tempdata-example-1", forceLoad: true);
    }
}
```

Reading without deleting (`Peek`):

```csharp
protected override void OnInitialized()
{
    var notification = TempData?.Peek("Message") as string;
}
```

Keep a specific value for another request (`Keep(string)`):

```csharp
protected override void OnInitialized()
{
    var message = TempData?.Get("Message") as string;
    TempData?.Keep("Message");
}
```

Keep all values for another request (`Keep`):

```csharp
protected override void OnInitialized()
{
    TempData?.Keep();
}
```

Similar to the preceding example but when only simple read/write of a single value is required, the following example uses the `[SupplyParameterFromTempData]` attribute.

`Pages/TempDataExample2.razor`:

```razor
@page "/tempdata-example-2"
@inject NavigationManager NavigationManager

<p>@Message</p>

<form method="post" @formname="SetMessage" @onsubmit="Submit">
    <AntiforgeryToken />
    <button type="submit">Submit</button>
</form>

@code {
    [SupplyParameterFromTempData]
    public string? Message { get; set; }

    private void Submit()
    {
        Message = "Form submitted successfully!";
        NavigationManager.NavigateTo("/tempdata-example-2", forceLoad: true);
    }
}
```

### Session data persistence

<!-- UPDATE 11.0 - API Browser cross-links -->

Session data persistence reads and writes cookie-based HTTP session values during static server-side rendering (static SSR), which is useful for scenarios such as shopping cart IDs or multi-step form progress. Unlike [temporary data persistence (`ITempData`)](#temporary-data-persistence), session values aren't cleared after reading. Values persist across multiple requests for the session lifetime.

> [!IMPORTANT]
> This feature is only available during static server-side rendering (static SSR). During interactive SSR and interactive client-side rendering (CSR), the session value isn't supplied, and the property retains its default value.

Session storage:

* Requires explicit session state configuration.
* Has no practical size limits (within session constraints).
* Serializes values with <xref:System.Text.Json> with <xref:System.Text.Json.JsonSerializerDefaults?displayProperty=nameWithType>.
* Requires session affinity (sticky sessions) in load-balanced environments. Without it, users may lose data. For more information, see <xref:blazor/fundamentals/signalr#use-session-affinity-sticky-sessions-for-server-side-web-farm-hosting>.

When supplied to a parameter, use the `[SupplyParameterFromSession]` attribute without or with a key (string):

```csharp
[SupplyParameterFromSession]
public string? Message { get; set; }

[SupplyParameterFromSession(Name = "flash_message")]
public string? FlashMessage { get; set; }
```

A key (string) is useful to distinguish multiple parameters because properties can't share a session value.

Call `AddSession` on the service collection in the app's `Program` file passing `SessionOptions` to change the cookie's parameters.

Parameter | API | Notes
--- | --- | ---
Name | `Name` | The default value is <xref:Microsoft.AspNetCore.Session.SessionDefaults.CookieName%2A?displayProperty=nameWithType> (`.AspNetCore.Session`).
Path | `Path` | The default value is <xref:Microsoft.AspNetCore.Session.SessionDefaults.CookiePath%2A?displayProperty=nameWithType> (`/`).
[HTTP Only](https://developer.mozilla.org/docs/Web/Security/Practical_implementation_guides/Cookies#httponly) | `HttpOnly` | The default value is `true`.
[SameSite value](https://developer.mozilla.org/docs/Web/HTTP/Headers/Set-Cookie#samesitesamesite-value) | `SameSite` | The default value is <xref:Microsoft.AspNetCore.Http.SameSiteMode.Lax?displayProperty=nameWithType>.
[Secure policy](https://developer.mozilla.org/docs/Web/HTTP/Reference/Headers/Set-Cookie#secure) | `SecurePolicy` | Some browsers don't allow insecure endpoints to set cookies with a 'secure' flag or overwrite cookies whose 'secure' flag is set. Since mixing secure and insecure endpoints is a common scenario in apps, the framework relaxes the restriction on secure policy on some cookies by setting them to 'None'. Cookies related to authentication or authorization use a stronger policy than 'None'. The default value is [`CookieSecurePolicy.None`](xref:Microsoft.AspNetCore.Http.CookieSecurePolicy).
Is Essential | `IsEssential` | Session is considered non-essential, as it's designed for ephemeral data. The default value is `false`.
Idle Timeout | `IdleTimeout` | Indicates how long the session can be idle before its contents are abandoned (default value: 20 minutes). Each session access resets the timeout. This setting only applies to the content of the session, not the cookie.
IO Timeout | `IOTimeout` | The maximum amount of time allowed to load a session from the store or to commit it back to the store (default value: 1 minute). This may only apply to asynchronous operations. The timeout is disabled using <xref:System.Threading.Timeout.InfiniteTimeSpan%2A?displayProperty=nameWithType>.

After configuring session services with `AddSession`, call `UseSession` in the request processing pipeline. The following example demonstrates default values:

<!-- UPDATE 11.0 - Is AddDistributedMemoryCache required? What happens if
                   it isn't used? -->

```csharp
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.Name = ".AspNetCore.Session";
    options.Path = "/";
    options.HttpOnly = true;
    options.SecurePolicy = CookieSecurePolicy.None;
    options.SameSite = SameSiteMode.Lax;
    options.IsEssential = false;
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.IOTimeout =  TimeSpan.FromMinutes(1);
});

builder.Services.AddRazorComponents();

var app = builder.Build();

app.UseSession();
```

`Pages/Checkout.razor`:

```razor
@page "/checkout"

<p>Current step: @CurrentStep</p>

<EditForm Model="Input" FormName="checkout" OnSubmit="NextStep">
    <button type="submit">Next</button>
</EditForm>

@code {
    [SupplyParameterFromSession(Name = "checkout_step")]
    public int CurrentStep { get; set; }

    private object Input { get; } = new();

    private void NextStep() => CurrentStep++;
}
```

### Permanent data persistence

:::moniker-end

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
