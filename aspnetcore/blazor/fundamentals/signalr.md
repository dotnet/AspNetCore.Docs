---
title: ASP.NET Core Blazor SignalR guidance
author: guardrex
description: Learn how to configure and manage Blazor SignalR connections.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 02/16/2023
uid: blazor/fundamentals/signalr
---
# ASP.NET Core Blazor SignalR guidance

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to configure and manage SignalR connections in Blazor apps.

:::moniker range=">= aspnetcore-7.0"

For general guidance on ASP.NET Core SignalR configuration, see the topics in the <xref:signalr/introduction> area of the documentation. To configure SignalR added to a hosted Blazor WebAssembly app, for example in the <xref:blazor/tutorials/signalr-blazor?pivots=webassembly> tutorial, or a standalone Blazor WebAssembly app that uses SignalR, see <xref:signalr/configuration#configure-server-options>.

## Disable response compression for Hot Reload

When using [Hot Reload](xref:test/hot-reload), disable Response Compression Middleware in the `Development` environment. The following examples use the existing environment check in a project created from a Blazor project template. Whether or not the default code from a project template is used, always call <xref:Microsoft.AspNetCore.Builder.ResponseCompressionBuilderExtensions.UseResponseCompression%2A> first in the request processing pipeline.

In `Program.cs` of a Blazor Server app:

```csharp
if (!app.Environment.IsDevelopment())
{
    app.UseResponseCompression();
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
```

In `Program.cs` of the **:::no-loc text="Client":::** project in a hosted Blazor WebAssembly solution:

```csharp
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseResponseCompression();
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
```

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
  private HubConnectionBuilder? hubConnection;

  ...

  hubConnection = new HubConnectionBuilder()
      .WithUrl(new Uri(Navigation.ToAbsoluteUri("/chathub")), options =>
      {
          options.HttpMessageHandlerFactory = innerHandler => 
              new IncludeRequestCredentialsMessageHandler { InnerHandler = innerHandler };
      }).Build();
  ```

  The preceding example configures the hub connection URL to the absolute URI address at `/chathub`, which is the URL used in the [SignalR with Blazor tutorial](xref:blazor/tutorials/signalr-blazor) in the `Index` component (`Pages/Index.razor`). The URI can also be set via a string, for example `https://signalr.example.com`, or via [configuration](xref:blazor/fundamentals/configuration). `Navigation` is an injected <xref:Microsoft.AspNetCore.Components.NavigationManager>.

For more information, see <xref:signalr/configuration#configure-additional-options>.

## Render mode (Blazor WebAssembly)

If a Blazor WebAssembly app that uses SignalR is configured to prerender on the server, prerendering occurs before the client connection to the server is established. For more information, see the following articles:

* <xref:mvc/views/tag-helpers/builtin-th/component-tag-helper>
* <xref:blazor/components/prerendering-and-integration>

## Additional resources for Blazor WebAssembly apps

* [Hosted Blazor WebAssembly: Secure a SignalR hub](xref:blazor/security/webassembly/index#secure-a-signalr-hub)
* <xref:blazor/host-and-deploy/webassembly#signalr-configuration>
* <xref:signalr/introduction>
* <xref:signalr/configuration>
* [Blazor samples GitHub repository (`dotnet/blazor-samples`)](https://github.com/dotnet/blazor-samples)

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

> [!WARNING]
> The default value of <xref:Microsoft.AspNetCore.SignalR.HubOptions.MaximumReceiveMessageSize> is 32 KB. Increasing the value may increase the risk of [Denial of service (DoS) attacks](xref:blazor/security/server/threat-mitigation#denial-of-service-dos-attacks).

For information on Blazor Server's memory model, see <xref:blazor/host-and-deploy/server#blazor-server-memory-model>.

## Blazor Hub endpoint route configuration (Blazor Server)

In `Program.cs`, Blazor Server apps call <xref:Microsoft.AspNetCore.Builder.ComponentEndpointRouteBuilderExtensions.MapBlazorHub%2A> to map the Blazor <xref:Microsoft.AspNetCore.SignalR.Hub> to the app's default path. The Blazor Server script (`blazor.server.js`) automatically points to the endpoint created by <xref:Microsoft.AspNetCore.Builder.ComponentEndpointRouteBuilderExtensions.MapBlazorHub%2A>.

## Reflect the connection state in the UI (Blazor Server)

When the client detects that the connection has been lost, a default UI is displayed to the user while the client attempts to reconnect. If reconnection fails, the user is provided the option to retry.

To customize the UI, define a single element with an `id` of `components-reconnect-modal`. The following example places the element in the host page.

`Pages/_Host.cshtml`:

```cshtml
<div id="components-reconnect-modal">
    There was a problem with the connection!
</div>
```

> [!NOTE]
> If more than one element with an `id` of `components-reconnect-modal` are rendered by the app, only the first rendered element receives CSS class changes to display or hide the element. 

Add the following CSS styles to the site's stylesheet.

`wwwroot/css/site.css`:

```css
#components-reconnect-modal {
    display: none;
}

#components-reconnect-modal.components-reconnect-show, 
#components-reconnect-modal.components-reconnect-failed, 
#components-reconnect-modal.components-reconnect-rejected {
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

To display the current reconnect attempt, define an element with an `id` of `components-reconnect-current-attempt`. To display the maximum number of reconnect retries, define an element with an `id` of `components-reconnect-max-retries`. The following example places these elements inside a reconnect attempt modal element in the host page following the previous example.

`Pages/_Host.cshtml`:

```cshtml
<div id="components-reconnect-modal">
    There was a problem with the connection!
    (Current reconnect attempt: 
    <span id="components-reconnect-current-attempt"></span> /
    <span id="components-reconnect-max-retries"></span>)
</div>
```

When the custom reconnect modal appears, it renders content similar to the following based on the preceding code:

```html
There was a problem with the connection! (Current reconnect attempt: 3 / 8)
```

## Render mode (Blazor Server)

By default, Blazor Server apps prerender the UI on the server before the client connection to the server is established. For more information, see <xref:mvc/views/tag-helpers/builtin-th/component-tag-helper>.

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

## Monitor circuit activity (Blazor Server)

Monitor inbound circuit activity in Blazor Server apps using the `CreateInboundActivityHandler` method on <xref:Microsoft.AspNetCore.Components.Server.Circuits.CircuitHandler>. Inbound circuit activity is any activity sent from the browser to the server, such as UI events or JavaScript-to-.NET interop calls.

For example, you can use a circuit activity handler to detect if the client is idle:

```csharp
public sealed class IdleCircuitHandler : CircuitHandler, IDisposable
{
    readonly Timer timer;
    readonly ILogger logger;

    public IdleCircuitHandler(IOptions<IdleCircuitOptions> options, 
        ILogger<IdleCircuitHandler> logger)
    {
        timer = new Timer();
        timer.Interval = options.Value.IdleTimeout.TotalMilliseconds;
        timer.AutoReset = false;
        timer.Elapsed += CircuitIdle;
        this.logger = logger;
    }

    private void CircuitIdle(object? sender, System.Timers.ElapsedEventArgs e)
    {
        logger.LogInformation(nameof(CircuitIdle));
    }

    public override Func<CircuitInboundActivityContext, Task> CreateInboundActivityHandler(
        Func<CircuitInboundActivityContext, Task> next)
    {
        return context =>
        {
            timer.Stop();
            timer.Start();
            return next(context);
        };
    }

    public void Dispose()
    {
        timer.Dispose();
    }
}

public class IdleCircuitOptions
{
    public TimeSpan IdleTimeout { get; set; } = TimeSpan.FromMinutes(5);
}

public static class IdleCircuitHandlerServiceCollectionExtensions
{
    public static IServiceCollection AddIdleCircuitHandler(
        this IServiceCollection services, 
        Action<IdleCircuitOptions> configureOptions)
    {
        services.Configure(configureOptions);
        services.AddIdleCircuitHandler();
        return services;
    }

    public static IServiceCollection AddIdleCircuitHandler(
        this IServiceCollection services)
    {
        services.AddScoped<CircuitHandler, IdleCircuitHandler>();
        return services;
    }
}
```

Circuit activity handlers also provide a way to access scoped Blazor services from other non-Blazor dependency injection (DI) scopes, such as scopes created using <xref:System.Net.Http.IHttpClientFactory>. There's an existing pattern for accessing circuit-scoped services from other dependency injection scopes, but it requires using a custom base component type. With circuit activity handlers, we can use a better approach, which is demonstrated by the following example:

```csharp
public class CircuitServicesAccessor
{
    static readonly AsyncLocal<IServiceProvider> blazorServices = new();

    public IServiceProvider? Services
    {
        get => blazorServices.Value;
        set => blazorServices.Value = value;
    }
}

public class ServicesAccessorCircuitHandler : CircuitHandler
{
    readonly IServiceProvider services;
    readonly CircuitServicesAccessor circuitServicesAccessor;

    public ServicesAccessorCircuitHandler(IServiceProvider services, 
        CircuitServicesAccessor servicesAccessor)
    {
        this.services = services;
        this.circuitServicesAccessor = servicesAccessor;
    }

    public override Func<CircuitInboundActivityContext, Task> CreateInboundActivityHandler(
        Func<CircuitInboundActivityContext, Task> next)
    {
        return async context =>
        {
            circuitServicesAccessor.Services = services;
            await next(context);
            circuitServicesAccessor.Services = null;
        };
    }
}

public static class CircuitServicesServiceCollectionExtensions
{
    public static IServiceCollection AddCircuitServicesAccessor(
        this IServiceCollection services)
    {
        services.AddScoped<CircuitServicesAccessor>();
        services.AddScoped<CircuitHandler, ServicesAccessorCircuitHandler>();

        return services;
    }
}
```

Next, access the circuit-scoped services by injecting the `CircuitServicesAccessor` where it's needed. For example, here's how you can access the <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> from a <xref:System.Net.Http.DelegatingHandler> setup using <xref:System.Net.Http.IHttpClientFactory>:

```csharp
public class AuthenticationStateHandler : DelegatingHandler
{
    readonly CircuitServicesAccessor circuitServicesAccessor;

    public AuthenticationStateHandler(
        CircuitServicesAccessor circuitServicesAccessor)
    {
        this.circuitServicesAccessor = circuitServicesAccessor;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var authStateProvider = circuitServicesAccessor.Services
            .GetRequiredService<AuthenticationStateProvider>();
        var authState = await authStateProvider.GetAuthenticationStateAsync();

        ...

        return await base.SendAsync(request, cancellationToken);
    }
}
```

:::moniker-end

:::moniker range=">= aspnetcore-7.0"

## Blazor startup

Configure the manual start of a Blazor app's SignalR circuit in the `Pages/_Host.cshtml` file (Blazor Server) or `wwwroot/index.html` (hosted Blazor WebAssembly with SignalR implemented):

* Add an `autostart="false"` attribute to the `<script>` tag for the `blazor.{server|webassembly}.js` script.
* Place a script that calls `Blazor.start()` after the Blazor script is loaded and inside the closing `</body>` tag.

When `autostart` is disabled, any aspect of the app that doesn't depend on the circuit works normally. For example, client-side routing is operational. However, any aspect that depends on the circuit isn't operational until `Blazor.start()` is called. App behavior is unpredictable without an established circuit. For example, component methods fail to execute while the circuit is disconnected.

For more information, including how to initialize Blazor when the document is ready and how to chain to a [JS `Promise`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise), see <xref:blazor/fundamentals/startup>.

## Configure SignalR timeouts and Keep-Alive on the client

Configure the following values for the client:

* `serverTimeoutInMilliseconds`: The server timeout in milliseconds. If this timeout elapses without receiving any messages from the server, the connection is terminated with an error. The default timeout value is 30 seconds. The server timeout should be at least double the value assigned to the Keep-Alive interval (`keepAliveIntervalInMilliseconds`).
* `keepAliveIntervalInMilliseconds`: Default interval at which to ping the server. This setting allows the server to detect hard disconnects, such as when a client unplugs their computer from the network. The ping occurs at most as often as the server pings. If the server pings every five seconds, assigning a value lower than `5000` (5 seconds) pings every five seconds. The default value is 15 seconds. The Keep-Alive interval should be less than or equal to half the value assigned to the server timeout (`serverTimeoutInMilliseconds`).

The following example for either `Pages/_Host.cshtml` (Blazor Server) or `wwwroot/index.html` (Blazor WebAssembly) uses default values:

```html
<script src="_framework/blazor.{HOSTING MODEL}.js" autostart="false"></script>
<script>
  Blazor.start({
    configureSignalR: function (builder) {
      let c = builder.build();
      c.serverTimeoutInMilliseconds = 30000;
      c.keepAliveIntervalInMilliseconds = 15000;
      builder.build = () => {
        return c;
      };
    }
  });
</script>
```

In the preceding markup, the `{HOSTING MODEL}` placeholder is either `server` for a Blazor Server app or `webassembly` for a Blazor WebAssembly app.

When creating a hub connection in a component, set the <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.ServerTimeout> (default: 30 seconds), <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.HandshakeTimeout> (default: 15 seconds), and <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.KeepAliveInterval> (default: 15 seconds) on the built <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection>. The following example, based on the `Index` component in the [SignalR with Blazor tutorial](xref:blazor/tutorials/signalr-blazor), uses default values:

```csharp
protected override async Task OnInitializedAsync()
{
    hubConnection = new HubConnectionBuilder()
        .WithUrl(Navigation.ToAbsoluteUri("/chathub"))
        .Build();

    hubConnection.ServerTimeout = TimeSpan.FromSeconds(30);
    hubConnection.HandshakeTimeout = TimeSpan.FromSeconds(15);
    hubConnection.KeepAliveInterval = TimeSpan.FromSeconds(15);

    hubConnection.On<string, string>("ReceiveMessage", (user, message) => ...

    await hubConnection.StartAsync();
}
```

When changing the values of the server timeout (<xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.ServerTimeout>) or the Keep-Alive interval (<xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.KeepAliveInterval>:

* The server timeout should be at least double the value assigned to the Keep-Alive interval.
* The Keep-Alive interval should be less than or equal to half the value assigned to the server timeout.

For more information, see the *Global deployment and connection failures* sections of the following articles:

* <xref:blazor/host-and-deploy/server#global-deployment-and-connection-failures>
* <xref:blazor/host-and-deploy/webassembly#global-deployment-and-connection-failures>

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

### Automatically refresh the page when reconnection fails (Blazor Server)

The default reconnection behavior requires the user to take manual action to refresh the page after reconnection fails. However, a custom reconnection handler can be used to automatically refresh the page:

`Pages/_Host.cshtml`:

```cshtml
<body>
    ...

    <div id="reconnect-modal" style="display: none;"></div>
    <script src="_framework/blazor.server.js" autostart="false"></script>
    <script src="boot.js"></script>
</body>
```

`wwwroot/boot.js`:

```javascript
(() => {
  const maximumRetryCount = 3;
  const retryIntervalMilliseconds = 5000;
  const reconnectModal = document.getElementById('reconnect-modal');
  
  const startReconnectionProcess = () => {
    reconnectModal.style.display = 'block';

    let isCanceled = false;

    (async () => {
      for (let i = 0; i < maximumRetryCount; i++) {
        reconnectModal.innerText = `Attempting to reconnect: ${i + 1} of ${maximumRetryCount}`;

        await new Promise(resolve => setTimeout(resolve, retryIntervalMilliseconds));

        if (isCanceled) {
          return;
        }

        try {
          const result = await Blazor.reconnect();
          if (!result) {
            // The server was reached, but the connection was rejected; reload the page.
            location.reload();
            return;
          }

          // Successfully reconnected to the server.
          return;
        } catch {
          // Didn't reach the server; try again.
        }
      }

      // Retried too many times; reload the page.
      location.reload();
    })();

    return {
      cancel: () => {
        isCanceled = true;
        reconnectModal.style.display = 'none';
      },
    };
  };

  let currentReconnectionProcess = null;

  Blazor.start({
    reconnectionHandler: {
      onConnectionDown: () => currentReconnectionProcess ??= startReconnectionProcess(),
      onConnectionUp: () => {
        currentReconnectionProcess?.cancel();
        currentReconnectionProcess = null;
      },
    },
  });
})();
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

:::code language="csharp" source="~/../blazor-samples/7.0/BlazorSample_Server/TrackingCircuitHandler.cs":::

Circuit handlers are registered using DI. Scoped instances are created per instance of a circuit. Using the `TrackingCircuitHandler` in the preceding example, a singleton service is created because the state of all circuits must be tracked.

In `Program.cs`:

```csharp
builder.Services.AddSingleton<CircuitHandler, TrackingCircuitHandler>();
```

If a custom circuit handler's methods throw an unhandled exception, the exception is fatal to the Blazor Server circuit. To tolerate exceptions in a handler's code or called methods, wrap the code in one or more [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statements with error handling and logging.

When a circuit ends because a user has disconnected and the framework is cleaning up the circuit state, the framework disposes of the circuit's DI scope. Disposing the scope disposes any circuit-scoped DI services that implement <xref:System.IDisposable?displayProperty=fullName>. If any DI service throws an unhandled exception during disposal, the framework logs the exception. For more information, see <xref:blazor/fundamentals/dependency-injection#service-lifetime>.

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

For general guidance on ASP.NET Core SignalR configuration, see the topics in the <xref:signalr/introduction> area of the documentation. To configure SignalR added to a hosted Blazor WebAssembly app, for example in the <xref:blazor/tutorials/signalr-blazor?pivots=webassembly> tutorial, or a standalone Blazor WebAssembly app that uses SignalR, see <xref:signalr/configuration#configure-server-options>.

## Disable response compression for Hot Reload

When using [Hot Reload](xref:test/hot-reload), disable Response Compression Middleware in the `Development` environment. The following examples use the existing environment check in a project created from a Blazor project template. Whether or not the default code from a project template is used, always call <xref:Microsoft.AspNetCore.Builder.ResponseCompressionBuilderExtensions.UseResponseCompression%2A> first in the request processing pipeline.

In `Program.cs` of a Blazor Server app:

```csharp
if (!app.Environment.IsDevelopment())
{
    app.UseResponseCompression();
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
```

In `Program.cs` of the **:::no-loc text="Client":::** project in a hosted Blazor WebAssembly solution:

```csharp
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseResponseCompression();
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
```

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
  private HubConnectionBuilder? hubConnection;

  ...

  hubConnection = new HubConnectionBuilder()
      .WithUrl(new Uri(Navigation.ToAbsoluteUri("/chathub")), options =>
      {
          options.HttpMessageHandlerFactory = innerHandler => 
              new IncludeRequestCredentialsMessageHandler { InnerHandler = innerHandler };
      }).Build();
  ```

  The preceding example configures the hub connection URL to the absolute URI address at `/chathub`, which is the URL used in the [SignalR with Blazor tutorial](xref:blazor/tutorials/signalr-blazor) in the `Index` component (`Pages/Index.razor`). The URI can also be set via a string, for example `https://signalr.example.com`, or via [configuration](xref:blazor/fundamentals/configuration). `Navigation` is an injected <xref:Microsoft.AspNetCore.Components.NavigationManager>.
  
> [!NOTE]
> To authenticate users for SignalR hubs, see <xref:blazor/security/webassembly/index#secure-a-signalr-hub>.

For more information, see <xref:signalr/configuration#configure-additional-options>.

## Render mode (Blazor WebAssembly)

If a Blazor WebAssembly app that uses SignalR is configured to prerender on the server, prerendering occurs before the client connection to the server is established. For more information, see the following articles:

* <xref:mvc/views/tag-helpers/builtin-th/component-tag-helper>
* <xref:blazor/components/prerendering-and-integration>

## Additional resources for Blazor WebAssembly apps

* [Hosted Blazor WebAssembly: Secure a SignalR hub](xref:blazor/security/webassembly/index#secure-a-signalr-hub)
* <xref:blazor/host-and-deploy/webassembly#signalr-configuration>
* <xref:signalr/introduction>
* <xref:signalr/configuration>
* [Blazor samples GitHub repository (`dotnet/blazor-samples`)](https://github.com/dotnet/blazor-samples)

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

> [!WARNING]
> The default value of <xref:Microsoft.AspNetCore.SignalR.HubOptions.MaximumReceiveMessageSize> is 32 KB. Increasing the value may increase the risk of [Denial of service (DoS) attacks](xref:blazor/security/server/threat-mitigation#denial-of-service-dos-attacks).

For information on Blazor Server's memory model, see <xref:blazor/host-and-deploy/server#blazor-server-memory-model>.

## Blazor Hub endpoint route configuration (Blazor Server)

In `Program.cs`, Blazor Server apps call <xref:Microsoft.AspNetCore.Builder.ComponentEndpointRouteBuilderExtensions.MapBlazorHub%2A> to map the Blazor <xref:Microsoft.AspNetCore.SignalR.Hub> to the app's default path. The Blazor Server script (`blazor.server.js`) automatically points to the endpoint created by <xref:Microsoft.AspNetCore.Builder.ComponentEndpointRouteBuilderExtensions.MapBlazorHub%2A>.

## Reflect the connection state in the UI (Blazor Server)

When the client detects that the connection has been lost, a default UI is displayed to the user while the client attempts to reconnect. If reconnection fails, the user is provided the option to retry.

To customize the UI, define a single element with an `id` of `components-reconnect-modal`. The following example places the element in the layout page.

`Pages/_Layout.cshtml`:

```cshtml
<div id="components-reconnect-modal">
    There was a problem with the connection!
</div>
```

> [!NOTE]
> If more than one element with an `id` of `components-reconnect-modal` are rendered by the app, only the first rendered element receives CSS class changes to display or hide the element. 

Add the following CSS styles to the site's stylesheet.

`wwwroot/css/site.css`:

```css
#components-reconnect-modal {
    display: none;
}

#components-reconnect-modal.components-reconnect-show, 
#components-reconnect-modal.components-reconnect-failed, 
#components-reconnect-modal.components-reconnect-rejected {
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

To display the current reconnect attempt, define an element with an `id` of `components-reconnect-current-attempt`. To display the maximum number of reconnect retries, define an element with an `id` of `components-reconnect-max-retries`. The following example places these elements inside a reconnect attempt modal element in the layout page following the previous example.

`Pages/_Layout.cshtml`:

```cshtml
<div id="components-reconnect-modal">
    There was a problem with the connection!
    (Current reconnect attempt: 
    <span id="components-reconnect-current-attempt"></span> /
    <span id="components-reconnect-max-retries"></span>)
</div>
```

When the custom reconnect modal appears, it renders content similar to the following based on the preceding code:

```html
There was a problem with the connection! (Current reconnect attempt: 3 / 8)
```

## Render mode (Blazor Server)

By default, Blazor Server apps prerender the UI on the server before the client connection to the server is established. For more information, see <xref:mvc/views/tag-helpers/builtin-th/component-tag-helper>.

## Blazor startup

Configure the manual start of a Blazor app's SignalR circuit in the `Pages/_Layout.cshtml` file (Blazor Server) or `wwwroot/index.html` (hosted Blazor WebAssembly with SignalR implemented):

* Add an `autostart="false"` attribute to the `<script>` tag for the `blazor.{server|webassembly}.js` script.
* Place a script that calls `Blazor.start()` after the Blazor script is loaded and inside the closing `</body>` tag.

When `autostart` is disabled, any aspect of the app that doesn't depend on the circuit works normally. For example, client-side routing is operational. However, any aspect that depends on the circuit isn't operational until `Blazor.start()` is called. App behavior is unpredictable without an established circuit. For example, component methods fail to execute while the circuit is disconnected.

For more information, including how to initialize Blazor when the document is ready and how to chain to a [JS `Promise`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise), see <xref:blazor/fundamentals/startup>.

## Configure SignalR server timeout and Keep-Alive on the client

### Blazor Server hub

*This section only applies to Blazor Server.*

Configure the following values for the Blazor Server hub connection on the client:

* `serverTimeoutInMilliseconds`: The server timeout in milliseconds. If this timeout elapses without receiving any messages from the server, the connection is terminated with an error. The default timeout value is 30 seconds. The server timeout should be at least double the value assigned to the Keep-Alive interval (`keepAliveIntervalInMilliseconds`).
* `keepAliveIntervalInMilliseconds`: Default interval at which to ping the server. This setting allows the server to detect hard disconnects, such as when a client unplugs their computer from the network. The ping occurs at most as often as the server pings. If the server pings every five seconds, assigning a value lower than `5000` (5 seconds) pings every five seconds. The default value is 15 seconds. The Keep-Alive interval should be less than or equal to half the value assigned to the server timeout (`serverTimeoutInMilliseconds`).

The following example for either `Pages/_Layout.cshtml` (Blazor Server) or `wwwroot/index.html` (Blazor WebAssembly) uses default values:

```html
<script src="_framework/blazor.server.js" autostart="false"></script>
<script>
  Blazor.start({
    configureSignalR: function (builder) {
      let c = builder.build();
      c.serverTimeoutInMilliseconds = 30000;
      c.keepAliveIntervalInMilliseconds = 15000;
      builder.build = () => {
        return c;
      };
    }
  });
</script>
```

### Hub connections created in Razor components

*This section only applies to Blazor Server components and components in the :::no-loc text="Client"::: project of a hosted Blazor WebAssembly solution.*

When creating a hub connection in a component, set the <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.ServerTimeout> (default: 30 seconds), <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.HandshakeTimeout> (default: 15 seconds), and <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.KeepAliveInterval> (default: 15 seconds) on the built <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection>. The following example, based on the `Index` component in the [SignalR with Blazor tutorial](xref:blazor/tutorials/signalr-blazor), uses default values:

```csharp
protected override async Task OnInitializedAsync()
{
    hubConnection = new HubConnectionBuilder()
        .WithUrl(Navigation.ToAbsoluteUri("/chathub"))
        .Build();

    hubConnection.ServerTimeout = TimeSpan.FromSeconds(30);
    hubConnection.HandshakeTimeout = TimeSpan.FromSeconds(15);
    hubConnection.KeepAliveInterval = TimeSpan.FromSeconds(15);

    hubConnection.On<string, string>("ReceiveMessage", (user, message) => ...

    await hubConnection.StartAsync();
}
```

When changing the values of the server timeout (<xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.ServerTimeout>) or the Keep-Alive interval (<xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.KeepAliveInterval>:

* The server timeout should be at least double the value assigned to the Keep-Alive interval.
* The Keep-Alive interval should be less than or equal to half the value assigned to the server timeout.

For more information, see the *Global deployment and connection failures* sections of the following articles:

* <xref:blazor/host-and-deploy/server#global-deployment-and-connection-failures>
* <xref:blazor/host-and-deploy/webassembly#global-deployment-and-connection-failures>

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

:::code language="csharp" source="~/../blazor-samples/6.0/BlazorSample_Server/TrackingCircuitHandler.cs":::

Circuit handlers are registered using DI. Scoped instances are created per instance of a circuit. Using the `TrackingCircuitHandler` in the preceding example, a singleton service is created because the state of all circuits must be tracked.

In `Program.cs`:

```csharp
builder.Services.AddSingleton<CircuitHandler, TrackingCircuitHandler>();
```

If a custom circuit handler's methods throw an unhandled exception, the exception is fatal to the Blazor Server circuit. To tolerate exceptions in a handler's code or called methods, wrap the code in one or more [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statements with error handling and logging.

When a circuit ends because a user has disconnected and the framework is cleaning up the circuit state, the framework disposes of the circuit's DI scope. Disposing the scope disposes any circuit-scoped DI services that implement <xref:System.IDisposable?displayProperty=fullName>. If any DI service throws an unhandled exception during disposal, the framework logs the exception. For more information, see <xref:blazor/fundamentals/dependency-injection#service-lifetime>.

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

For general guidance on ASP.NET Core SignalR configuration, see the topics in the <xref:signalr/introduction> area of the documentation. To configure SignalR added to a hosted Blazor WebAssembly app, for example in the <xref:blazor/tutorials/signalr-blazor?pivots=webassembly> tutorial, or a standalone Blazor WebAssembly app that uses SignalR, see <xref:signalr/configuration#configure-server-options>.

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
  HubConnectionBuilder hubConnection;

  ...

  hubConnection = new HubConnectionBuilder()
      .WithUrl(new Uri(Navigation.ToAbsoluteUri("/chathub")), options =>
      {
          options.HttpMessageHandlerFactory = innerHandler => 
              new IncludeRequestCredentialsMessageHandler { InnerHandler = innerHandler };
      }).Build();
  ```

  The preceding example configures the hub connection URL to the absolute URI address at `/chathub`, which is the URL used in the [SignalR with Blazor tutorial](xref:blazor/tutorials/signalr-blazor) in the `Index` component (`Pages/Index.razor`). The URI can also be set via a string, for example `https://signalr.example.com`, or via [configuration](xref:blazor/fundamentals/configuration). `Navigation` is an injected <xref:Microsoft.AspNetCore.Components.NavigationManager>.
  
> [!NOTE]
> To authenticate users for SignalR hubs, see <xref:blazor/security/webassembly/index#secure-a-signalr-hub>.

For more information, see <xref:signalr/configuration#configure-additional-options>.

## Render mode (Blazor WebAssembly)

If a Blazor WebAssembly app that uses SignalR is configured to prerender on the server, prerendering occurs before the client connection to the server is established. For more information, see the following articles:

* <xref:mvc/views/tag-helpers/builtin-th/component-tag-helper>
* <xref:blazor/components/prerendering-and-integration>

## Additional resources for Blazor WebAssembly apps

* [Hosted Blazor WebAssembly: Secure a SignalR hub](xref:blazor/security/webassembly/index#secure-a-signalr-hub)
* <xref:signalr/introduction>
* <xref:signalr/configuration>
* [Blazor samples GitHub repository (`dotnet/blazor-samples`)](https://github.com/dotnet/blazor-samples)

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

> [!WARNING]
> The default value of <xref:Microsoft.AspNetCore.SignalR.HubOptions.MaximumReceiveMessageSize> is 32 KB. Increasing the value may increase the risk of [Denial of service (DoS) attacks](xref:blazor/security/server/threat-mitigation#denial-of-service-dos-attacks).

For information on Blazor Server's memory model, see <xref:blazor/host-and-deploy/server#blazor-server-memory-model>.

## Blazor Hub endpoint route configuration (Blazor Server)

In `Startup.Configure`, Blazor Server apps call <xref:Microsoft.AspNetCore.Builder.ComponentEndpointRouteBuilderExtensions.MapBlazorHub%2A> on the <xref:Microsoft.AspNetCore.Routing.IEndpointRouteBuilder> of <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseEndpoints%2A> to map the Blazor <xref:Microsoft.AspNetCore.SignalR.Hub> to the app's default path. The Blazor Server script (`blazor.server.js`) automatically points to the endpoint created by <xref:Microsoft.AspNetCore.Builder.ComponentEndpointRouteBuilderExtensions.MapBlazorHub%2A>.

## Reflect the connection state in the UI (Blazor Server)

When the client detects that the connection has been lost, a default UI is displayed to the user while the client attempts to reconnect. If reconnection fails, the user is provided the option to retry.

To customize the UI, define a single element with an `id` of `components-reconnect-modal`. The following example places the element in the host page.

`Pages/_Host.cshtml`:

```cshtml
<div id="components-reconnect-modal">
    There was a problem with the connection!
</div>
```

> [!NOTE]
> If more than one element with an `id` of `components-reconnect-modal` are rendered by the app, only the first rendered element receives CSS class changes to display or hide the element. 

Add the following CSS styles to the site's stylesheet.

`wwwroot/css/site.css`:

```css
#components-reconnect-modal {
    display: none;
}

#components-reconnect-modal.components-reconnect-show, 
#components-reconnect-modal.components-reconnect-failed, 
#components-reconnect-modal.components-reconnect-rejected {
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

To display the current reconnect attempt, define an element with an `id` of `components-reconnect-current-attempt`. To display the maximum number of reconnect retries, define an element with an `id` of `components-reconnect-max-retries`. The following example places these elements inside a reconnect attempt modal element in the host page following the previous example.

`Pages/_Host.cshtml`:

```cshtml
<div id="components-reconnect-modal">
    There was a problem with the connection!
    (Current reconnect attempt: 
    <span id="components-reconnect-current-attempt"></span> /
    <span id="components-reconnect-max-retries"></span>)
</div>
```

When the custom reconnect modal appears, it renders content similar to the following based on the preceding code:

```html
There was a problem with the connection! (Current reconnect attempt: 3 / 8)
```

## Render mode (Blazor Server)

By default, Blazor Server apps prerender the UI on the server before the client connection to the server is established. For more information, see <xref:mvc/views/tag-helpers/builtin-th/component-tag-helper>.

## Blazor startup

Configure the manual start of a Blazor app's SignalR circuit in the `Pages/_Host.cshtml` file (Blazor Server) or `wwwroot/index.html` (hosted Blazor WebAssembly with SignalR implemented):

* Add an `autostart="false"` attribute to the `<script>` tag for the `blazor.{server|webassembly}.js` script.
* Place a script that calls `Blazor.start()` after the Blazor script is loaded and inside the closing `</body>` tag.

When `autostart` is disabled, any aspect of the app that doesn't depend on the circuit works normally. For example, client-side routing is operational. However, any aspect that depends on the circuit isn't operational until `Blazor.start()` is called. App behavior is unpredictable without an established circuit. For example, component methods fail to execute while the circuit is disconnected.

For more information, including how to initialize Blazor when the document is ready and how to chain to a [JS `Promise`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise), see <xref:blazor/fundamentals/startup>.

## Configure SignalR server timeout and Keep-Alive on the client

### Blazor Server hub

*This section only applies to Blazor Server.*

Configure the following values for the Blazor Server hub connection on the client:

* `serverTimeoutInMilliseconds`: The server timeout in milliseconds. If this timeout elapses without receiving any messages from the server, the connection is terminated with an error. The default timeout value is 30 seconds. The server timeout should be at least double the value assigned to the Keep-Alive interval (`keepAliveIntervalInMilliseconds`).
* `keepAliveIntervalInMilliseconds`: Default interval at which to ping the server. This setting allows the server to detect hard disconnects, such as when a client unplugs their computer from the network. The ping occurs at most as often as the server pings. If the server pings every five seconds, assigning a value lower than `5000` (5 seconds) pings every five seconds. The default value is 15 seconds. The Keep-Alive interval should be less than or equal to half the value assigned to the server timeout (`serverTimeoutInMilliseconds`).

The following example for either `Pages/_Host.cshtml` (Blazor Server) or `wwwroot/index.html` (Blazor WebAssembly) uses default values:

```html
<script src="_framework/blazor.server.js" autostart="false"></script>
<script>
  Blazor.start({
    configureSignalR: function (builder) {
      let c = builder.build();
      c.serverTimeoutInMilliseconds = 30000;
      c.keepAliveIntervalInMilliseconds = 15000;
      builder.build = () => {
        return c;
      };
    }
  });
</script>
```

### Hub connections created in Razor components

*This section only applies to Blazor Server components and components in the :::no-loc text="Client"::: project of a hosted Blazor WebAssembly solution.*

When creating a hub connection in a component, set the <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.ServerTimeout> (default: 30 seconds), <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.HandshakeTimeout> (default: 15 seconds), and <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.KeepAliveInterval> (default: 15 seconds) on the built <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection>. The following example, based on the `Index` component in the [SignalR with Blazor tutorial](xref:blazor/tutorials/signalr-blazor), uses default values:

```csharp
protected override async Task OnInitializedAsync()
{
    hubConnection = new HubConnectionBuilder()
        .WithUrl(Navigation.ToAbsoluteUri("/chathub"))
        .Build();

    hubConnection.ServerTimeout = TimeSpan.FromSeconds(30);
    hubConnection.HandshakeTimeout = TimeSpan.FromSeconds(15);
    hubConnection.KeepAliveInterval = TimeSpan.FromSeconds(15);

    hubConnection.On<string, string>("ReceiveMessage", (user, message) => ...

    await hubConnection.StartAsync();
}
```

When changing the values of the server timeout (<xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.ServerTimeout>) or the Keep-Alive interval (<xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.KeepAliveInterval>:

* The server timeout should be at least double the value assigned to the Keep-Alive interval.
* The Keep-Alive interval should be less than or equal to half the value assigned to the server timeout.

For more information, see the *Global deployment and connection failures* sections of the following articles:

* <xref:blazor/host-and-deploy/server#global-deployment-and-connection-failures>
* <xref:blazor/host-and-deploy/webassembly#global-deployment-and-connection-failures>

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

:::code language="csharp" source="~/../blazor-samples/5.0/BlazorSample_Server/TrackingCircuitHandler.cs":::

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

:::moniker-end

:::moniker range="< aspnetcore-5.0"

For general guidance on ASP.NET Core SignalR configuration, see the topics in the <xref:signalr/introduction> area of the documentation. To configure SignalR added to a hosted Blazor WebAssembly app, for example in the <xref:blazor/tutorials/signalr-blazor?pivots=webassembly> tutorial, or a standalone Blazor WebAssembly app that uses SignalR, see <xref:signalr/configuration#configure-server-options>.

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
  HubConnectionBuilder hubConnection;

  ...

  hubConnection = new HubConnectionBuilder()
      .WithUrl(new Uri(Navigation.ToAbsoluteUri("/chathub")), options =>
      {
          options.HttpMessageHandlerFactory = innerHandler => 
              new IncludeRequestCredentialsMessageHandler { InnerHandler = innerHandler };
      }).Build();
  ```

  The preceding example configures the hub connection URL to the absolute URI address at `/chathub`, which is the URL used in the [SignalR with Blazor tutorial](xref:blazor/tutorials/signalr-blazor) in the `Index` component (`Pages/Index.razor`). The URI can also be set via a string, for example `https://signalr.example.com`, or via [configuration](xref:blazor/fundamentals/configuration). `Navigation` is an injected <xref:Microsoft.AspNetCore.Components.NavigationManager>.
  
> [!NOTE]
> To authenticate users for SignalR hubs, see <xref:blazor/security/webassembly/index#secure-a-signalr-hub>.

For more information, see <xref:signalr/configuration#configure-additional-options>.

## Additional resources for Blazor WebAssembly apps

* [Hosted Blazor WebAssembly: Secure a SignalR hub](xref:blazor/security/webassembly/index#secure-a-signalr-hub)
* <xref:signalr/introduction>
* <xref:signalr/configuration>
* [Blazor samples GitHub repository (`dotnet/blazor-samples`)](https://github.com/dotnet/blazor-samples)

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

> [!WARNING]
> The default value of <xref:Microsoft.AspNetCore.SignalR.HubOptions.MaximumReceiveMessageSize> is 32 KB. Increasing the value may increase the risk of [Denial of service (DoS) attacks](xref:blazor/security/server/threat-mitigation#denial-of-service-dos-attacks).

For information on Blazor Server's memory model, see <xref:blazor/host-and-deploy/server#blazor-server-memory-model>.

## Blazor Hub endpoint route configuration (Blazor Server)

In `Startup.Configure`, Blazor Server apps call <xref:Microsoft.AspNetCore.Builder.ComponentEndpointRouteBuilderExtensions.MapBlazorHub%2A> on the <xref:Microsoft.AspNetCore.Routing.IEndpointRouteBuilder> of <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseEndpoints%2A> to map the Blazor <xref:Microsoft.AspNetCore.SignalR.Hub> to the app's default path. The Blazor Server script (`blazor.server.js`) automatically points to the endpoint created by <xref:Microsoft.AspNetCore.Builder.ComponentEndpointRouteBuilderExtensions.MapBlazorHub%2A>.

## Reflect the connection state in the UI (Blazor Server)

When the client detects that the connection has been lost, a default UI is displayed to the user while the client attempts to reconnect. If reconnection fails, the user is provided the option to retry.

To customize the UI, define a single element with an `id` of `components-reconnect-modal`. The following example places the element in the host page.

`Pages/_Host.cshtml`:

```cshtml
<div id="components-reconnect-modal">
    There was a problem with the connection!
</div>
```

> [!NOTE]
> If more than one element with an `id` of `components-reconnect-modal` are rendered by the app, only the first rendered element receives CSS class changes to display or hide the element. 

Add the following CSS styles to the site's stylesheet.

`wwwroot/css/site.css`:

```css
#components-reconnect-modal {
    display: none;
}

#components-reconnect-modal.components-reconnect-show, 
#components-reconnect-modal.components-reconnect-failed, 
#components-reconnect-modal.components-reconnect-rejected {
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

## Blazor startup

Configure the manual start of a Blazor app's SignalR circuit in the `Pages/_Host.cshtml` file (Blazor Server) or `wwwroot/index.html` (hosted Blazor WebAssembly with SignalR implemented):

* Add an `autostart="false"` attribute to the `<script>` tag for the `blazor.{server|webassembly}.js` script.
* Place a script that calls `Blazor.start()` after the Blazor script is loaded and inside the closing `</body>` tag.

When `autostart` is disabled, any aspect of the app that doesn't depend on the circuit works normally. For example, client-side routing is operational. However, any aspect that depends on the circuit isn't operational until `Blazor.start()` is called. App behavior is unpredictable without an established circuit. For example, component methods fail to execute while the circuit is disconnected.

For more information, including how to initialize Blazor when the document is ready and how to chain to a [JS `Promise`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise), see <xref:blazor/fundamentals/startup>.

## Configure SignalR server timeout and Keep-Alive on the client

### Blazor Server hub

*This section only applies to Blazor Server.*

Configure the following values for the Blazor Server hub connection on the client:

* `serverTimeoutInMilliseconds`: The server timeout in milliseconds. If this timeout elapses without receiving any messages from the server, the connection is terminated with an error. The default timeout value is 30 seconds. The server timeout should be at least double the value assigned to the Keep-Alive interval (`keepAliveIntervalInMilliseconds`).
* `keepAliveIntervalInMilliseconds`: Default interval at which to ping the server. This setting allows the server to detect hard disconnects, such as when a client unplugs their computer from the network. The ping occurs at most as often as the server pings. If the server pings every five seconds, assigning a value lower than `5000` (5 seconds) pings every five seconds. The default value is 15 seconds. The Keep-Alive interval should be less than or equal to half the value assigned to the server timeout (`serverTimeoutInMilliseconds`).

The following example for either `Pages/_Host.cshtml` (Blazor Server) or `wwwroot/index.html` (Blazor WebAssembly) uses default values:

```html
<script src="_framework/blazor.server.js" autostart="false"></script>
<script>
  Blazor.start({
    configureSignalR: function (builder) {
      let c = builder.build();
      c.serverTimeoutInMilliseconds = 30000;
      c.keepAliveIntervalInMilliseconds = 15000;
      builder.build = () => {
        return c;
      };
    }
  });
</script>
```

### Hub connections created in Razor components

*This section only applies to Blazor Server components and components in the :::no-loc text="Client"::: project of a hosted Blazor WebAssembly solution.*

When creating a hub connection in a component, set the <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.ServerTimeout> (default: 30 seconds), <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.HandshakeTimeout> (default: 15 seconds), and <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.KeepAliveInterval> (default: 15 seconds) on the built <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection>. The following example, based on the `Index` component in the [SignalR with Blazor tutorial](xref:blazor/tutorials/signalr-blazor), uses default values:

```csharp
protected override async Task OnInitializedAsync()
{
    hubConnection = new HubConnectionBuilder()
        .WithUrl(Navigation.ToAbsoluteUri("/chathub"))
        .Build();

    hubConnection.ServerTimeout = TimeSpan.FromSeconds(30);
    hubConnection.HandshakeTimeout = TimeSpan.FromSeconds(15);
    hubConnection.KeepAliveInterval = TimeSpan.FromSeconds(15);

    hubConnection.On<string, string>("ReceiveMessage", (user, message) => ...

    await hubConnection.StartAsync();
}
```

When changing the values of the server timeout (<xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.ServerTimeout>) or the Keep-Alive interval (<xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.KeepAliveInterval>:

* The server timeout should be at least double the value assigned to the Keep-Alive interval.
* The Keep-Alive interval should be less than or equal to half the value assigned to the server timeout.

For more information, see the *Global deployment and connection failures* sections of the following articles:

* <xref:blazor/host-and-deploy/server#global-deployment-and-connection-failures>
* <xref:blazor/host-and-deploy/webassembly#global-deployment-and-connection-failures>

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

:::code language="csharp" source="~/../blazor-samples/3.1/BlazorSample_Server/TrackingCircuitHandler.cs":::

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

:::moniker-end

## Blazor Server circuit handler to capture users for custom services

Use a <xref:Microsoft.AspNetCore.Components.Server.Circuits.CircuitHandler> to capture a user from the <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> and set that user in a service. For more information and example code, see <xref:blazor/security/server/additional-scenarios#circuit-handler-to-capture-users-for-custom-services>.

## Avoid `IHttpContextAccessor`/`HttpContext` in Razor components

[!INCLUDE[](~/blazor/security/includes/httpcontext.md)]

## Additional resources for Blazor Server apps

* [Blazor Server host and deployment guidance: SignalR configuration](xref:blazor/host-and-deploy/server#signalr-configuration)
* <xref:signalr/introduction>
* <xref:signalr/configuration>
* Blazor Server security documentation
  * <xref:blazor/security/index>
  * <xref:blazor/security/server/index>
  * <xref:blazor/security/server/threat-mitigation>
  * <xref:blazor/security/server/additional-scenarios>
* [Blazor Server reconnection events and component lifecycle events](xref:blazor/components/lifecycle#blazor-server-reconnection-events)
* [What is Azure SignalR Service?](/azure/azure-signalr/signalr-overview)
* [Performance guide for Azure SignalR Service](/azure/azure-signalr/signalr-concept-performance)
* <xref:signalr/publish-to-azure-web-app>
* [Blazor samples GitHub repository (`dotnet/blazor-samples`)](https://github.com/dotnet/blazor-samples)
