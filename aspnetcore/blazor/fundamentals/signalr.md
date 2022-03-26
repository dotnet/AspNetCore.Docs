---
title: ASP.NET Core Blazor SignalR guidance
author: guardrex
description: Learn how to configure and manage Blazor SignalR connections.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/09/2021
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/fundamentals/signalr
---
# ASP.NET Core Blazor SignalR guidance

This article explains how to configure and manage SignalR connections in Blazor apps.

:::moniker range=">= aspnetcore-6.0"

For general guidance on ASP.NET Core SignalR configuration, see the topics in the <xref:signalr/introduction> area of the documentation. To configure SignalR [added to a hosted Blazor WebAssembly solution](xref:blazor/tutorials/signalr-blazor), see <xref:signalr/configuration#configure-server-options>.

## SignalR cross-origin negotiation for authentication (Blazor WebAssembly)

To configure SignalR's underlying client to send credentials, such as cookies or HTTP authentication headers:

* Use <xref:Microsoft.AspNetCore.Components.WebAssembly.Http.WebAssemblyHttpRequestMessageExtensions.SetBrowserRequestCredentials%2A> to set <xref:Microsoft.AspNetCore.Components.WebAssembly.Http.BrowserRequestCredentials.Include> on cross-origin [`fetch`](https://developer.mozilla.org/docs/Web/API/Fetch_API/Using_Fetch) requests.

  `IncludeRequestCredentialsMessageHandler.cs`:

  ```csharp
  using System.Net.Http;
  using System.Threading;
  using System.Threading.Tasks;
  using Microsoft.AspNetCore.Components.WebAssembly.Http;

  public class IncludeRequestCredentialsMessageHandler : DelegatingHandler
  {
      protected override Task<HttpResponseMessage> SendAsync(
          HttpRequestMessage request, CancellationToken cancellationToken)
      {
          request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
          return base.SendAsync(request, cancellationToken);
      }
  }
  ```

* Where a hub connection is built, assign the <xref:System.Net.Http.HttpMessageHandler> to the <xref:Microsoft.AspNetCore.Http.Connections.Client.HttpConnectionOptions.HttpMessageHandlerFactory> option:

  ```csharp
  private HubConnectionBuilder? hubConnecton;

  ...

  hubConnecton = new HubConnectionBuilder()
      .WithUrl(new Uri(NavigationManager.ToAbsoluteUri("/chathub")), options =>
      {
          options.HttpMessageHandlerFactory = innerHandler => 
              new IncludeRequestCredentialsMessageHandler { InnerHandler = innerHandler };
      }).Build();
  ```

  The preceding example configures the hub connection URL to the absolute URI address at `/chathub`, which is the URL used in the [SignalR with Blazor tutorial](xref:blazor/tutorials/signalr-blazor) in the `Index` component (`Pages/Index.razor`). The URI can also be set via a string, for example `https://signalr.example.com`, or via [configuration](xref:blazor/fundamentals/configuration).

For more information, see <xref:signalr/configuration#configure-additional-options>.

## Render mode (Blazor WebAssembly)

If a Blazor WebAssembly app that uses SignalR is configured to prerender on the server, prerendering occurs before the client connection to the server is established. For more information, see the following articles:

* <xref:mvc/views/tag-helpers/builtin-th/component-tag-helper>
* <xref:blazor/components/prerendering-and-integration>

## Additional resources for Blazor WebAssembly apps

* <xref:signalr/introduction>
* <xref:signalr/configuration>

## Use sticky sessions for webfarm hosting (Blazor Server)

A Blazor Server app prerenders in response to the first client request, which creates UI state on the server. When the client attempts to create a SignalR connection, **the client must reconnect to the same server**. Blazor Server apps that use more than one backend server should implement *sticky sessions* for SignalR connections.

> [!NOTE]
> The following error is thrown by an app that hasn't enabled sticky sessions in a webfarm:
>
> > blazor.server.js:1 Uncaught (in promise) Error: Invocation canceled due to the underlying connection being closed.

## Azure SignalR Service (Blazor Server)

We recommend using the [Azure SignalR Service](xref:signalr/scale#azure-signalr-service) for Blazor Server apps hosted in Microsoft Azure. The service works in conjunction with the app's Blazor Hub for scaling up a Blazor Server app to a large number of concurrent SignalR connections. In addition, the SignalR Service's global reach and high-performance data centers significantly aid in reducing latency due to geography.

Sticky sessions are enabled for the Azure SignalR Service by setting the service's `ServerStickyMode` option or configuration value to `Required`. For more information, see <xref:blazor/host-and-deploy/server#azure-signalr-service>.

## Circuit handler options for Blazor Server apps

Configure the Blazor Server circuit with the <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions> shown in the following table.

| Option | Default | Description |
| --- | --- | --- |
| <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.DetailedErrors> | `false` | Send detailed exception messages to JavaScript when an unhandled exception occurs on the circuit or when a .NET method invocation through JS interop results in an exception. |
| <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.DisconnectedCircuitMaxRetained> | 100 | Maximum number of disconnected circuits that the server holds in memory at a time. |
| <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.DisconnectedCircuitRetentionPeriod> | 3 minutes | Maximum amount of time a disconnected circuit is held in memory before being torn down. |
| <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.JSInteropDefaultCallTimeout> | 1 minute | Maximum amount of time the server waits before timing out an asynchronous JavaScript function invocation. |
| <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.MaxBufferedUnacknowledgedRenderBatches> | 10 | Maximum number of unacknowledged render batches the server keeps in memory per circuit at a given time to support robust reconnection. After reaching the limit, the server stops producing new render batches until one or more batches are acknowledged by the client. |

Configure the options in `Program.cs` with an options delegate to <xref:Microsoft.Extensions.DependencyInjection.ComponentServiceCollectionExtensions.AddServerSideBlazor%2A>. The following example assigns the default option values shown in the preceding table. Confirm that `Program.cs` uses the <xref:System> namespace (`using System;`).

In `Program.cs`:

```csharp
builder.Services.AddServerSideBlazor(options =>
{
    options.DetailedErrors = false;
    options.DisconnectedCircuitMaxRetained = 100;
    options.DisconnectedCircuitRetentionPeriod = TimeSpan.FromMinutes(3);
    options.JSInteropDefaultCallTimeout = TimeSpan.FromMinutes(1);
    options.MaxBufferedUnacknowledgedRenderBatches = 10;
});
```

To configure the <xref:Microsoft.AspNetCore.SignalR.HubConnectionContext>, use <xref:Microsoft.AspNetCore.SignalR.HubConnectionContextOptions> with <xref:Microsoft.Extensions.DependencyInjection.ServerSideBlazorBuilderExtensions.AddHubOptions%2A>. For option descriptions, see <xref:signalr/configuration#configure-server-options>. The following example assigns the default option values. Confirm that `Program.cs` uses the <xref:System> namespace (`using System;`).

In `Program.cs`:

```csharp
builder.Services.AddServerSideBlazor()
    .AddHubOptions(options =>
    {
        options.ClientTimeoutInterval = TimeSpan.FromSeconds(30);
        options.EnableDetailedErrors = false;
        options.HandshakeTimeout = TimeSpan.FromSeconds(15);
        options.KeepAliveInterval = TimeSpan.FromSeconds(15);
        options.MaximumParallelInvocationsPerClient = 1;
        options.MaximumReceiveMessageSize = 32 * 1024;
        options.StreamBufferCapacity = 10;
    });
```

## Blazor Hub endpoint route configuration (Blazor Server)

In `Program.cs`, Blazor Server apps call <xref:Microsoft.AspNetCore.Builder.ComponentEndpointRouteBuilderExtensions.MapBlazorHub%2A> to map the Blazor <xref:Microsoft.AspNetCore.SignalR.Hub> to the app's default path. The Blazor Server script (`blazor.server.js`) automatically points to the endpoint created by <xref:Microsoft.AspNetCore.Builder.ComponentEndpointRouteBuilderExtensions.MapBlazorHub%2A>.

## Reflect the connection state in the UI (Blazor Server)

When the client detects that the connection has been lost, a default UI is displayed to the user while the client attempts to reconnect. If reconnection fails, the user is provided the option to retry.

To customize the UI, define an element with an `id` of `components-reconnect-modal` in the `<body>` of the `_Layout.cshtml` Razor page.

`Pages/_Layout.cshtml`:

```cshtml
<div id="components-reconnect-modal">
    ...
</div>
```

Add the following CSS styles to the site's stylesheet.

`wwwroot/css/site.css`:

```css
#components-reconnect-modal {
    display: none;
}

#components-reconnect-modal.components-reconnect-show {
    display: block;
}
```

The following table describes the CSS classes applied to the `components-reconnect-modal` element by the Blazor framework.

| CSS class                       | Indicates&hellip; |
| ------------------------------- | ----------------- |
| `components-reconnect-show`     | A lost connection. The client is attempting to reconnect. Show the modal. |
| `components-reconnect-hide`     | An active connection is re-established to the server. Hide the modal. |
| `components-reconnect-failed`   | Reconnection failed, probably due to a network failure. To attempt reconnection, call `window.Blazor.reconnect()` in JavaScript. |
| `components-reconnect-rejected` | Reconnection rejected. The server was reached but refused the connection, and the user's state on the server is lost. To reload the app, call `location.reload()` in JavaScript. This connection state may result when:<ul><li>A crash in the server-side circuit occurs.</li><li>The client is disconnected long enough for the server to drop the user's state. Instances of the user's components are disposed.</li><li>The server is restarted, or the app's worker process is recycled.</li></ul> |

Customize the delay before the reconnection display appears by setting the `transition-delay` property in the site's CSS for the modal element. The following example sets the transition delay from 500 ms (default) to 1,000 ms (1 second).

`wwwroot/css/site.css`:

```css
#components-reconnect-modal {
    transition: visibility 0s linear 1000ms;
}
```

## Render mode (Blazor Server)

By default, Blazor Server apps prerender the UI on the server before the client connection to the server is established. For more information, see <xref:mvc/views/tag-helpers/builtin-th/component-tag-helper>.

## Blazor startup (Blazor Server)

Configure the manual start of a Blazor Server app's SignalR circuit in the `Pages/_Layout.cshtml` file:

* Add an `autostart="false"` attribute to the `<script>` tag for the `blazor.server.js` script.
* Place a script that calls `Blazor.start` after the `blazor.server.js` script's `<script>` tag and inside the closing `</body>` tag.

When `autostart` is disabled, any aspect of the app that doesn't depend on the circuit works normally. For example, client-side routing is operational. However, any aspect that depends on the circuit isn't operational until `Blazor.start` is called. App behavior is unpredictable without an established circuit. For example, component methods fail to execute while the circuit is disconnected.

For more information, including how to initialize Blazor when the document is ready and how to chain to a [JS Promise](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise), see <xref:blazor/fundamentals/startup>.

## Configure SignalR client logging (Blazor Server)

On the client builder, pass in the `configureSignalR` configuration object that calls `configureLogging` with the log level.

`Pages/_Layout.cshtml`:

```cshtml
<body>
    ...

    <script src="_framework/blazor.server.js" autostart="false"></script>
    <script>
      Blazor.start({
        configureSignalR: function (builder) {
          builder.configureLogging("information");
        }
      });
    </script>
</body>
```

In the preceding example, `information` is equivalent to a log level of <xref:Microsoft.Extensions.Logging.LogLevel.Information?displayProperty=nameWithType>.

For more information on Blazor startup, see <xref:blazor/fundamentals/startup>.

## Modify the reconnection handler (Blazor Server)

The reconnection handler's circuit connection events can be modified for custom behaviors, such as:

* To notify the user if the connection is dropped.
* To perform logging (from the client) when a circuit is connected.

To modify the connection events, register callbacks for the following connection changes:

* Dropped connections use `onConnectionDown`.
* Established/re-established connections use `onConnectionUp`.

**Both `onConnectionDown` and `onConnectionUp` must be specified.**

`Pages/_Layout.cshtml`:

```cshtml
<body>
    ...

    <script src="_framework/blazor.server.js" autostart="false"></script>
    <script>
      Blazor.start({
        reconnectionHandler: {
          onConnectionDown: (options, error) => console.error(error),
          onConnectionUp: () => console.log("Up, up, and away!")
        }
      });
    </script>
</body>
```

For more information on Blazor startup, see <xref:blazor/fundamentals/startup>.

## Adjust the reconnection retry count and interval (Blazor Server)

To adjust the reconnection retry count and interval, set the number of retries (`maxRetries`) and period in milliseconds permitted for each retry attempt (`retryIntervalMilliseconds`).

`Pages/_Layout.cshtml`:

```cshtml
<body>
    ...

    <script src="_framework/blazor.server.js" autostart="false"></script>
    <script>
      Blazor.start({
        reconnectionOptions: {
          maxRetries: 3,
          retryIntervalMilliseconds: 2000
        }
      });
    </script>
</body>
```

For more information on Blazor startup, see <xref:blazor/fundamentals/startup>.

## Disconnect the Blazor circuit from the client (Blazor Server)

By default, a Blazor circuit is disconnected when the [`unload` page event](https://developer.mozilla.org/docs/Web/API/Window/unload_event) is triggered. To disconnect the circuit for other scenarios on the client, invoke `Blazor.disconnect` in the appropriate event handler. In the following example, the circuit is disconnected when the page is hidden ([`pagehide` event](https://developer.mozilla.org/docs/Web/API/Window/pagehide_event)):

```javascript
window.addEventListener('pagehide', () => {
  Blazor.disconnect();
});
```

For more information on Blazor startup, see <xref:blazor/fundamentals/startup>.

## Blazor Server circuit handler

Blazor Server allows code to define a *circuit handler*, which allows running code on changes to the state of a user's circuit. A circuit handler is implemented by deriving from <xref:Microsoft.AspNetCore.Components.Server.Circuits.CircuitHandler> and registering the class in the app's service container. The following example of a circuit handler tracks open SignalR connections.

`TrackingCircuitHandler.cs`:

[!code-csharp[](~/blazor/samples/6.0/BlazorSample_Server/TrackingCircuitHandler.cs)]

Circuit handlers are registered using DI. Scoped instances are created per instance of a circuit. Using the `TrackingCircuitHandler` in the preceding example, a singleton service is created because the state of all circuits must be tracked.

In `Program.cs`:

```csharp
builder.Services.AddSingleton<CircuitHandler, TrackingCircuitHandler>();
```

If a custom circuit handler's methods throw an unhandled exception, the exception is fatal to the Blazor Server circuit. To tolerate exceptions in a handler's code or called methods, wrap the code in one or more [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statements with error handling and logging.

When a circuit ends because a user has disconnected and the framework is cleaning up the circuit state, the framework disposes of the circuit's DI scope. Disposing the scope disposes any circuit-scoped DI services that implement <xref:System.IDisposable?displayProperty=fullName>. If any DI service throws an unhandled exception during disposal, the framework logs the exception. For more information, see <xref:blazor/fundamentals/dependency-injection#service-lifetime>.

## Additional resources for Blazor Server apps

* <xref:signalr/introduction>
* <xref:signalr/configuration>
* <xref:blazor/security/server/threat-mitigation>
* [Blazor Server reconnection events and component lifecycle events](xref:blazor/components/lifecycle#blazor-server-reconnection-events)
* [What is Azure SignalR Service?](/azure/azure-signalr/signalr-overview)
* [Performance guide for Azure SignalR Service](/azure/azure-signalr/signalr-concept-performance)
* <xref:signalr/publish-to-azure-web-app>

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

For general guidance on ASP.NET Core SignalR configuration, see the topics in the <xref:signalr/introduction> area of the documentation. To configure SignalR [added to a hosted Blazor WebAssembly solution](xref:blazor/tutorials/signalr-blazor), see <xref:signalr/configuration#configure-server-options>.

## SignalR cross-origin negotiation for authentication (Blazor WebAssembly)

To configure SignalR's underlying client to send credentials, such as cookies or HTTP authentication headers:

* Use <xref:Microsoft.AspNetCore.Components.WebAssembly.Http.WebAssemblyHttpRequestMessageExtensions.SetBrowserRequestCredentials%2A> to set <xref:Microsoft.AspNetCore.Components.WebAssembly.Http.BrowserRequestCredentials.Include> on cross-origin [`fetch`](https://developer.mozilla.org/docs/Web/API/Fetch_API/Using_Fetch) requests.

  `IncludeRequestCredentialsMessageHandler.cs`:

  ```csharp
  using System.Net.Http;
  using System.Threading;
  using System.Threading.Tasks;
  using Microsoft.AspNetCore.Components.WebAssembly.Http;

  public class IncludeRequestCredentialsMessageHandler : DelegatingHandler
  {
      protected override Task<HttpResponseMessage> SendAsync(
          HttpRequestMessage request, CancellationToken cancellationToken)
      {
          request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
          return base.SendAsync(request, cancellationToken);
      }
  }
  ```

* Where a hub connection is built, assign the <xref:System.Net.Http.HttpMessageHandler> to the <xref:Microsoft.AspNetCore.Http.Connections.Client.HttpConnectionOptions.HttpMessageHandlerFactory> option:

  ```csharp
  HubConnectionBuilder hubConnecton;

  ...

  hubConnecton = new HubConnectionBuilder()
      .WithUrl(new Uri(NavigationManager.ToAbsoluteUri("/chathub")), options =>
      {
          options.HttpMessageHandlerFactory = innerHandler => 
              new IncludeRequestCredentialsMessageHandler { InnerHandler = innerHandler };
      }).Build();
  ```

  The preceding example configures the hub connection URL to the absolute URI address at `/chathub`, which is the URL used in the [SignalR with Blazor tutorial](xref:blazor/tutorials/signalr-blazor) in the `Index` component (`Pages/Index.razor`). The URI can also be set via a string, for example `https://signalr.example.com`, or via [configuration](xref:blazor/fundamentals/configuration).

For more information, see <xref:signalr/configuration#configure-additional-options>.

## Render mode (Blazor WebAssembly)

If a Blazor WebAssembly app that uses SignalR is configured to prerender on the server, prerendering occurs before the client connection to the server is established. For more information, see the following articles:

* <xref:mvc/views/tag-helpers/builtin-th/component-tag-helper>
* <xref:blazor/components/prerendering-and-integration>

## Additional resources for Blazor WebAssembly apps

* <xref:signalr/introduction>
* <xref:signalr/configuration>

## Use sticky sessions for webfarm hosting (Blazor Server)

A Blazor Server app prerenders in response to the first client request, which creates the UI state on the server. When the client attempts to create a SignalR connection, **the client must reconnect to the same server**. Blazor Server apps that use more than one backend server should implement *sticky sessions* for SignalR connections.

> [!NOTE]
> The following error is thrown by an app that hasn't enabled sticky sessions in a webfarm:
>
> > blazor.server.js:1 Uncaught (in promise) Error: Invocation canceled due to the underlying connection being closed.

## Azure SignalR Service (Blazor Server)

We recommend using the [Azure SignalR Service](xref:signalr/scale#azure-signalr-service) for Blazor Server apps hosted in Microsoft Azure. The service works in conjunction with the app's Blazor Hub for scaling up a Blazor Server app to a large number of concurrent SignalR connections. In addition, the SignalR Service's global reach and high-performance data centers significantly aid in reducing latency due to geography.

For prerendering support with the Azure SignalR Service, configure the app to use *sticky sessions*. For more information, see <xref:blazor/host-and-deploy/server#azure-signalr-service>.

## Circuit handler options for Blazor Server apps

Configure the Blazor Server circuit with the <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions> shown in the following table.

| Option | Default | Description |
| --- | --- | --- |
| <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.DetailedErrors> | `false` | Send detailed exception messages to JavaScript when an unhandled exception occurs on the circuit or when a .NET method invocation through JS interop results in an exception. |
| <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.DisconnectedCircuitMaxRetained> | 100 | Maximum number of disconnected circuits that the server holds in memory at a time. |
| <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.DisconnectedCircuitRetentionPeriod> | 3 minutes | Maximum amount of time a disconnected circuit is held in memory before being torn down. |
| <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.JSInteropDefaultCallTimeout> | 1 minute | Maximum amount of time the server waits before timing out an asynchronous JavaScript function invocation. |
| <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.MaxBufferedUnacknowledgedRenderBatches> | 10 | Maximum number of unacknowledged render batches the server keeps in memory per circuit at a given time to support robust reconnection. After reaching the limit, the server stops producing new render batches until one or more batches are acknowledged by the client. |

Configure the options in `Startup.ConfigureServices` with an options delegate to <xref:Microsoft.Extensions.DependencyInjection.ComponentServiceCollectionExtensions.AddServerSideBlazor%2A>. The following example assigns the default option values shown in the preceding table. Confirm that `Startup.cs` uses the <xref:System> namespace (`using System;`).

`Startup.ConfigureServices`:

```csharp
services.AddServerSideBlazor(options =>
{
    options.DetailedErrors = false;
    options.DisconnectedCircuitMaxRetained = 100;
    options.DisconnectedCircuitRetentionPeriod = TimeSpan.FromMinutes(3);
    options.JSInteropDefaultCallTimeout = TimeSpan.FromMinutes(1);
    options.MaxBufferedUnacknowledgedRenderBatches = 10;
});
```

To configure the <xref:Microsoft.AspNetCore.SignalR.HubConnectionContext>, use <xref:Microsoft.AspNetCore.SignalR.HubConnectionContextOptions> with <xref:Microsoft.Extensions.DependencyInjection.ServerSideBlazorBuilderExtensions.AddHubOptions%2A>. For option descriptions, see <xref:signalr/configuration#configure-server-options>. The following example assigns the default option values. Confirm that `Startup.cs` uses the <xref:System> namespace (`using System;`).

`Startup.ConfigureServices`:

```csharp
services.AddServerSideBlazor()
    .AddHubOptions(options =>
    {
        options.ClientTimeoutInterval = TimeSpan.FromSeconds(30);
        options.EnableDetailedErrors = false;
        options.HandshakeTimeout = TimeSpan.FromSeconds(15);
        options.KeepAliveInterval = TimeSpan.FromSeconds(15);
        options.MaximumParallelInvocationsPerClient = 1;
        options.MaximumReceiveMessageSize = 32 * 1024;
        options.StreamBufferCapacity = 10;
    });
```

## Blazor Hub endpoint route configuration (Blazor Server)

In `Startup.Configure`, Blazor Server apps call <xref:Microsoft.AspNetCore.Builder.ComponentEndpointRouteBuilderExtensions.MapBlazorHub%2A> on the <xref:Microsoft.AspNetCore.Routing.IEndpointRouteBuilder> of <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseEndpoints%2A> to map the Blazor <xref:Microsoft.AspNetCore.SignalR.Hub> to the app's default path. The Blazor Server script (`blazor.server.js`) automatically points to the endpoint created by <xref:Microsoft.AspNetCore.Builder.ComponentEndpointRouteBuilderExtensions.MapBlazorHub%2A>.

## Reflect the connection state in the UI (Blazor Server)

When the client detects that the connection has been lost, a default UI is displayed to the user while the client attempts to reconnect. If reconnection fails, the user is provided the option to retry.

To customize the UI, define an element with an `id` of `components-reconnect-modal` in the `<body>` of the `_Host.cshtml` Razor page.

`Pages/_Host.cshtml`:

```cshtml
<div id="components-reconnect-modal">
    ...
</div>
```

Add the following CSS styles to the site's stylesheet.

`wwwroot/css/site.css`:

```css
#components-reconnect-modal {
    display: none;
}

#components-reconnect-modal.components-reconnect-show {
    display: block;
}
```

The following table describes the CSS classes applied to the `components-reconnect-modal` element by the Blazor framework.

| CSS class                       | Indicates&hellip; |
| ------------------------------- | ----------------- |
| `components-reconnect-show`     | A lost connection. The client is attempting to reconnect. Show the modal. |
| `components-reconnect-hide`     | An active connection is re-established to the server. Hide the modal. |
| `components-reconnect-failed`   | Reconnection failed, probably due to a network failure. To attempt reconnection, call `window.Blazor.reconnect()` in JavaScript. |
| `components-reconnect-rejected` | Reconnection rejected. The server was reached but refused the connection, and the user's state on the server is lost. To reload the app, call `location.reload()` in JavaScript. This connection state may result when:<ul><li>A crash in the server-side circuit occurs.</li><li>The client is disconnected long enough for the server to drop the user's state. Instances of the user's components are disposed.</li><li>The server is restarted, or the app's worker process is recycled.</li></ul> |

Customize the delay before the reconnection display appears by setting the `transition-delay` property in the site's CSS for the modal element. The following example sets the transition delay from 500 ms (default) to 1,000 ms (1 second).

`wwwroot/css/site.css`:

```css
#components-reconnect-modal {
    transition: visibility 0s linear 1000ms;
}
```

## Render mode (Blazor Server)

By default, Blazor Server apps prerender the UI on the server before the client connection to the server is established. For more information, see <xref:mvc/views/tag-helpers/builtin-th/component-tag-helper>.

## Blazor startup (Blazor Server)

Configure the manual start of a Blazor Server app's SignalR circuit in the `Pages/_Host.cshtml` file:

* Add an `autostart="false"` attribute to the `<script>` tag for the `blazor.server.js` script.
* Place a script that calls `Blazor.start` after the `blazor.server.js` script's `<script>` tag and inside the closing `</body>` tag.

When `autostart` is disabled, any aspect of the app that doesn't depend on the circuit works normally. For example, client-side routing is operational. However, any aspect that depends on the circuit isn't operational until `Blazor.start` is called. App behavior is unpredictable without an established circuit. For example, component methods fail to execute while the circuit is disconnected.

For more information, including how to initialize Blazor when the document is ready and how to chain to a [JS Promise](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise), see <xref:blazor/fundamentals/startup>.

## Configure SignalR client logging (Blazor Server)

On the client builder, pass in the `configureSignalR` configuration object that calls `configureLogging` with the log level.

`Pages/_Host.cshtml`:

```cshtml
<body>
    ...

    <script src="_framework/blazor.server.js" autostart="false"></script>
    <script>
      Blazor.start({
        configureSignalR: function (builder) {
          builder.configureLogging("information");
        }
      });
    </script>
</body>
```

In the preceding example, `information` is equivalent to a log level of <xref:Microsoft.Extensions.Logging.LogLevel.Information?displayProperty=nameWithType>.

For more information on Blazor startup, see <xref:blazor/fundamentals/startup>.

## Modify the reconnection handler (Blazor Server)

The reconnection handler's circuit connection events can be modified for custom behaviors, such as:

* To notify the user if the connection is dropped.
* To perform logging (from the client) when a circuit is connected.

To modify the connection events, register callbacks for the following connection changes:

* Dropped connections use `onConnectionDown`.
* Established/re-established connections use `onConnectionUp`.

**Both `onConnectionDown` and `onConnectionUp` must be specified.**

`Pages/_Host.cshtml`:

```cshtml
<body>
    ...

    <script src="_framework/blazor.server.js" autostart="false"></script>
    <script>
      Blazor.start({
        reconnectionHandler: {
          onConnectionDown: (options, error) => console.error(error),
          onConnectionUp: () => console.log("Up, up, and away!")
        }
      });
    </script>
</body>
```

For more information on Blazor startup, see <xref:blazor/fundamentals/startup>.

## Adjust the reconnection retry count and interval (Blazor Server)

To adjust the reconnection retry count and interval, set the number of retries (`maxRetries`) and period in milliseconds permitted for each retry attempt (`retryIntervalMilliseconds`).

`Pages/_Host.cshtml`:

```cshtml
<body>
    ...

    <script src="_framework/blazor.server.js" autostart="false"></script>
    <script>
      Blazor.start({
        reconnectionOptions: {
          maxRetries: 3,
          retryIntervalMilliseconds: 2000
        }
      });
    </script>
</body>
```

For more information on Blazor startup, see <xref:blazor/fundamentals/startup>.

## Disconnect the Blazor circuit from the client (Blazor Server)

By default, a Blazor circuit is disconnected when the [`unload` page event](https://developer.mozilla.org/docs/Web/API/Window/unload_event) is triggered. To disconnect the circuit for other scenarios on the client, invoke `Blazor.disconnect` in the appropriate event handler. In the following example, the circuit is disconnected when the page is hidden ([`pagehide` event](https://developer.mozilla.org/docs/Web/API/Window/pagehide_event)):

```javascript
window.addEventListener('pagehide', () => {
  Blazor.disconnect();
});
```

For more information on Blazor startup, see <xref:blazor/fundamentals/startup>.

## Blazor Server circuit handler

Blazor Server allows code to define a *circuit handler*, which allows running code on changes to the state of a user's circuit. A circuit handler is implemented by deriving from <xref:Microsoft.AspNetCore.Components.Server.Circuits.CircuitHandler> and registering the class in the app's service container. The following example of a circuit handler tracks open SignalR connections.

`TrackingCircuitHandler.cs`:

[!code-csharp[](~/blazor/samples/5.0/BlazorSample_Server/TrackingCircuitHandler.cs)]

Circuit handlers are registered using DI. Scoped instances are created per instance of a circuit. Using the `TrackingCircuitHandler` in the preceding example, a singleton service is created because the state of all circuits must be tracked.

`Startup.cs`:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    ...
    services.AddSingleton<CircuitHandler, TrackingCircuitHandler>();
}
```

If a custom circuit handler's methods throw an unhandled exception, the exception is fatal to the Blazor Server circuit. To tolerate exceptions in a handler's code or called methods, wrap the code in one or more [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statements with error handling and logging.

When a circuit ends because a user has disconnected and the framework is cleaning up the circuit state, the framework disposes of the circuit's DI scope. Disposing the scope disposes any circuit-scoped DI services that implement <xref:System.IDisposable?displayProperty=fullName>. If any DI service throws an unhandled exception during disposal, the framework logs the exception. For more information, see <xref:blazor/fundamentals/dependency-injection#service-lifetime>.

## Additional resources for Blazor Server apps

* <xref:signalr/introduction>
* <xref:signalr/configuration>
* <xref:blazor/security/server/threat-mitigation>
* [Blazor Server reconnection events and component lifecycle events](xref:blazor/components/lifecycle#blazor-server-reconnection-events)
* [What is Azure SignalR Service?](/azure/azure-signalr/signalr-overview)
* [Performance guide for Azure SignalR Service](/azure/azure-signalr/signalr-concept-performance)
* <xref:signalr/publish-to-azure-web-app>

:::moniker-end

:::moniker range="< aspnetcore-5.0"

For general guidance on ASP.NET Core SignalR configuration, see the topics in the <xref:signalr/introduction> area of the documentation. To configure SignalR [added to a hosted Blazor WebAssembly solution](xref:blazor/tutorials/signalr-blazor), see <xref:signalr/configuration#configure-server-options>.

## SignalR cross-origin negotiation for authentication (Blazor WebAssembly)

To configure SignalR's underlying client to send credentials, such as cookies or HTTP authentication headers:

* Use <xref:Microsoft.AspNetCore.Components.WebAssembly.Http.WebAssemblyHttpRequestMessageExtensions.SetBrowserRequestCredentials%2A> to set <xref:Microsoft.AspNetCore.Components.WebAssembly.Http.BrowserRequestCredentials.Include> on cross-origin [`fetch`](https://developer.mozilla.org/docs/Web/API/Fetch_API/Using_Fetch) requests.

  `IncludeRequestCredentialsMessageHandler.cs`:

  ```csharp
  using System.Net.Http;
  using System.Threading;
  using System.Threading.Tasks;
  using Microsoft.AspNetCore.Components.WebAssembly.Http;

  public class IncludeRequestCredentialsMessageHandler : DelegatingHandler
  {
      protected override Task<HttpResponseMessage> SendAsync(
          HttpRequestMessage request, CancellationToken cancellationToken)
      {
          request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
          return base.SendAsync(request, cancellationToken);
      }
  }
  ```

* Where a hub connection is built, assign the <xref:System.Net.Http.HttpMessageHandler> to the <xref:Microsoft.AspNetCore.Http.Connections.Client.HttpConnectionOptions.HttpMessageHandlerFactory> option:

  ```csharp
  HubConnectionBuilder hubConnecton;

  ...

  hubConnecton = new HubConnectionBuilder()
      .WithUrl(new Uri(NavigationManager.ToAbsoluteUri("/chathub")), options =>
      {
          options.HttpMessageHandlerFactory = innerHandler => 
              new IncludeRequestCredentialsMessageHandler { InnerHandler = innerHandler };
      }).Build();
  ```

  The preceding example configures the hub connection URL to the absolute URI address at `/chathub`, which is the URL used in the [SignalR with Blazor tutorial](xref:blazor/tutorials/signalr-blazor) in the `Index` component (`Pages/Index.razor`). The URI can also be set via a string, for example `https://signalr.example.com`, or via [configuration](xref:blazor/fundamentals/configuration).

For more information, see <xref:signalr/configuration#configure-additional-options>.

## Additional resources for Blazor WebAssembly apps

* <xref:signalr/introduction>
* <xref:signalr/configuration>

## Use sticky sessions for webfarm hosting (Blazor Server)

A Blazor Server app prerenders in response to the first client request, which creates the UI state on the server. When the client attempts to create a SignalR connection, **the client must reconnect to the same server**. Blazor Server apps that use more than one backend server should implement *sticky sessions* for SignalR connections. For more information, see <xref:blazor/host-and-deploy/server#configuration>.

> [!NOTE]
> The following error is thrown by an app that hasn't enabled sticky sessions in a webfarm:
>
> > blazor.server.js:1 Uncaught (in promise) Error: Invocation canceled due to the underlying connection being closed.

## Azure SignalR Service (Blazor Server)

We recommend using the [Azure SignalR Service](xref:signalr/scale#azure-signalr-service) for Blazor Server apps hosted in Microsoft Azure. The service works in conjunction with the app's Blazor Hub for scaling up a Blazor Server app to a large number of concurrent SignalR connections. In addition, the SignalR Service's global reach and high-performance data centers significantly aid in reducing latency due to geography.

For prerendering support with the Azure SignalR Service, configure the app to use *sticky sessions*. For more information, see <xref:blazor/host-and-deploy/server#azure-signalr-service>.

## Circuit handler options for Blazor Server apps

Configure the Blazor Server circuit with the <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions> shown in the following table.

| Option | Default | Description |
| --- | --- | --- |
| <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.DetailedErrors> | `false` | Send detailed exception messages to JavaScript when an unhandled exception occurs on the circuit or when a .NET method invocation through JS interop results in an exception. |
| <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.DisconnectedCircuitMaxRetained> | 100 | Maximum number of disconnected circuits that the server holds in memory at a time. |
| <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.DisconnectedCircuitRetentionPeriod> | 3 minutes | Maximum amount of time a disconnected circuit is held in memory before being torn down. |
| <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.JSInteropDefaultCallTimeout> | 1 minute | Maximum amount of time the server waits before timing out an asynchronous JavaScript function invocation. |
| <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.MaxBufferedUnacknowledgedRenderBatches> | 10 | Maximum number of unacknowledged render batches the server keeps in memory per circuit at a given time to support robust reconnection. After reaching the limit, the server stops producing new render batches until one or more batches are acknowledged by the client. |

Configure the options in `Startup.ConfigureServices` with an options delegate to <xref:Microsoft.Extensions.DependencyInjection.ComponentServiceCollectionExtensions.AddServerSideBlazor%2A>. The following example assigns the default option values shown in the preceding table. Confirm that `Startup.cs` uses the <xref:System> namespace (`using System;`).

`Startup.ConfigureServices`:

```csharp
services.AddServerSideBlazor(options =>
{
    options.DetailedErrors = false;
    options.DisconnectedCircuitMaxRetained = 100;
    options.DisconnectedCircuitRetentionPeriod = TimeSpan.FromMinutes(3);
    options.JSInteropDefaultCallTimeout = TimeSpan.FromMinutes(1);
    options.MaxBufferedUnacknowledgedRenderBatches = 10;
});
```

To configure the <xref:Microsoft.AspNetCore.SignalR.HubConnectionContext>, use <xref:Microsoft.AspNetCore.SignalR.HubConnectionContextOptions> with <xref:Microsoft.Extensions.DependencyInjection.ServerSideBlazorBuilderExtensions.AddHubOptions%2A>. For option descriptions, see <xref:signalr/configuration#configure-server-options>. The following example assigns the default option values. Confirm that `Startup.cs` uses the <xref:System> namespace (`using System;`).

`Startup.ConfigureServices`:

```csharp
services.AddServerSideBlazor()
    .AddHubOptions(options =>
    {
        options.ClientTimeoutInterval = TimeSpan.FromSeconds(30);
        options.EnableDetailedErrors = false;
        options.HandshakeTimeout = TimeSpan.FromSeconds(15);
        options.KeepAliveInterval = TimeSpan.FromSeconds(15);
        options.MaximumParallelInvocationsPerClient = 1;
        options.MaximumReceiveMessageSize = 32 * 1024;
        options.StreamBufferCapacity = 10;
    });
```

## Blazor Hub endpoint route configuration (Blazor Server)

In `Startup.Configure`, Blazor Server apps call <xref:Microsoft.AspNetCore.Builder.ComponentEndpointRouteBuilderExtensions.MapBlazorHub%2A> on the <xref:Microsoft.AspNetCore.Routing.IEndpointRouteBuilder> of <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseEndpoints%2A> to map the Blazor <xref:Microsoft.AspNetCore.SignalR.Hub> to the app's default path. The Blazor Server script (`blazor.server.js`) automatically points to the endpoint created by <xref:Microsoft.AspNetCore.Builder.ComponentEndpointRouteBuilderExtensions.MapBlazorHub%2A>.

## Reflect the connection state in the UI (Blazor Server)

When the client detects that the connection has been lost, a default UI is displayed to the user while the client attempts to reconnect. If reconnection fails, the user is provided the option to retry.

To customize the UI, define an element with an `id` of `components-reconnect-modal` in the `<body>` of the `_Host.cshtml` Razor page.

`Pages/_Host.cshtml`:

```cshtml
<div id="components-reconnect-modal">
    ...
</div>
```

Add the following CSS styles to the site's stylesheet.

`wwwroot/css/site.css`:

```css
#components-reconnect-modal {
    display: none;
}

#components-reconnect-modal.components-reconnect-show {
    display: block;
}
```

The following table describes the CSS classes applied to the `components-reconnect-modal` element by the Blazor framework.

| CSS class                       | Indicates&hellip; |
| ------------------------------- | ----------------- |
| `components-reconnect-show`     | A lost connection. The client is attempting to reconnect. Show the modal. |
| `components-reconnect-hide`     | An active connection is re-established to the server. Hide the modal. |
| `components-reconnect-failed`   | Reconnection failed, probably due to a network failure. To attempt reconnection, call `window.Blazor.reconnect()` in JavaScript. |
| `components-reconnect-rejected` | Reconnection rejected. The server was reached but refused the connection, and the user's state on the server is lost. To reload the app, call `location.reload()` in JavaScript. This connection state may result when:<ul><li>A crash in the server-side circuit occurs.</li><li>The client is disconnected long enough for the server to drop the user's state. Instances of the user's components are disposed.</li><li>The server is restarted, or the app's worker process is recycled.</li></ul> |

## Render mode (Blazor Server)

By default, Blazor Server apps prerender the UI on the server before the client connection to the server is established. For more information, see <xref:mvc/views/tag-helpers/builtin-th/component-tag-helper>.

## Blazor startup (Blazor Server)

Configure the manual start of a Blazor Server app's SignalR circuit in the `Pages/_Host.cshtml` file:

* Add an `autostart="false"` attribute to the `<script>` tag for the `blazor.server.js` script.
* Place a script that calls `Blazor.start` after the `blazor.server.js` script's `<script>` tag and inside the closing `</body>` tag.

When `autostart` is disabled, any aspect of the app that doesn't depend on the circuit works normally. For example, client-side routing is operational. However, any aspect that depends on the circuit isn't operational until `Blazor.start` is called. App behavior is unpredictable without an established circuit. For example, component methods fail to execute while the circuit is disconnected.

For more information, including how to initialize Blazor when the document is ready and how to chain to a [JS Promise](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise), see <xref:blazor/fundamentals/startup>.

## Configure SignalR client logging (Blazor Server)

On the client builder, pass in the `configureSignalR` configuration object that calls `configureLogging` with the log level.

`Pages/_Host.cshtml`:

```cshtml
<body>
    ...

    <script src="_framework/blazor.server.js" autostart="false"></script>
    <script>
      Blazor.start({
        configureSignalR: function (builder) {
          builder.configureLogging("information");
        }
      });
    </script>
</body>
```

In the preceding example, `information` is equivalent to a log level of <xref:Microsoft.Extensions.Logging.LogLevel.Information?displayProperty=nameWithType>.

For more information on Blazor startup, see <xref:blazor/fundamentals/startup>.

## Modify the reconnection handler (Blazor Server)

The reconnection handler's circuit connection events can be modified for custom behaviors, such as:

* To notify the user if the connection is dropped.
* To perform logging (from the client) when a circuit is connected.

To modify the connection events, register callbacks for the following connection changes:

* Dropped connections use `onConnectionDown`.
* Established/re-established connections use `onConnectionUp`.

**Both `onConnectionDown` and `onConnectionUp` must be specified.**

`Pages/_Host.cshtml`:

```cshtml
<body>
    ...

    <script src="_framework/blazor.server.js" autostart="false"></script>
    <script>
      Blazor.start({
        reconnectionHandler: {
          onConnectionDown: (options, error) => console.error(error),
          onConnectionUp: () => console.log("Up, up, and away!")
        }
      });
    </script>
</body>
```

For more information on Blazor startup, see <xref:blazor/fundamentals/startup>.

## Adjust the reconnection retry count and interval (Blazor Server)

To adjust the reconnection retry count and interval, set the number of retries (`maxRetries`) and period in milliseconds permitted for each retry attempt (`retryIntervalMilliseconds`).

`Pages/_Host.cshtml`:

```cshtml
<body>
    ...

    <script src="_framework/blazor.server.js" autostart="false"></script>
    <script>
      Blazor.start({
        reconnectionOptions: {
          maxRetries: 3,
          retryIntervalMilliseconds: 2000
        }
      });
    </script>
</body>
```

For more information on Blazor startup, see <xref:blazor/fundamentals/startup>.

## Blazor Server circuit handler

Blazor Server allows code to define a *circuit handler*, which allows running code on changes to the state of a user's circuit. A circuit handler is implemented by deriving from <xref:Microsoft.AspNetCore.Components.Server.Circuits.CircuitHandler> and registering the class in the app's service container. The following example of a circuit handler tracks open SignalR connections.

`TrackingCircuitHandler.cs`:

[!code-csharp[](~/blazor/samples/3.1/BlazorSample_Server/TrackingCircuitHandler.cs)]

Circuit handlers are registered using DI. Scoped instances are created per instance of a circuit. Using the `TrackingCircuitHandler` in the preceding example, a singleton service is created because the state of all circuits must be tracked.

`Startup.cs`:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    ...
    services.AddSingleton<CircuitHandler, TrackingCircuitHandler>();
}
```

If a custom circuit handler's methods throw an unhandled exception, the exception is fatal to the Blazor Server circuit. To tolerate exceptions in a handler's code or called methods, wrap the code in one or more [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statements with error handling and logging.

When a circuit ends because a user has disconnected and the framework is cleaning up the circuit state, the framework disposes of the circuit's DI scope. Disposing the scope disposes any circuit-scoped DI services that implement <xref:System.IDisposable?displayProperty=fullName>. If any DI service throws an unhandled exception during disposal, the framework logs the exception. For more information, see <xref:blazor/fundamentals/dependency-injection#service-lifetime>.

## Additional resources for Blazor Server apps

* <xref:signalr/introduction>
* <xref:signalr/configuration>
* <xref:blazor/security/server/threat-mitigation>
* [Blazor Server reconnection events and component lifecycle events](xref:blazor/components/lifecycle#blazor-server-reconnection-events)
* [What is Azure SignalR Service?](/azure/azure-signalr/signalr-overview)
* [Performance guide for Azure SignalR Service](/azure/azure-signalr/signalr-concept-performance)
* <xref:signalr/publish-to-azure-web-app>

:::moniker-end
