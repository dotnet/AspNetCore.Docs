---
title: ASP.NET Core Blazor SignalR guidance
author: guardrex
description: Learn how to configure and manage Blazor SignalR connections.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/14/2023
uid: blazor/fundamentals/signalr
---
# ASP.NET Core Blazor SignalR guidance

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to configure and manage SignalR connections in Blazor apps.

[!INCLUDE[](~/blazor/includes/location-client-and-server-pre-net8.md)]

For general guidance on ASP.NET Core SignalR configuration, see the topics in the <xref:signalr/introduction> area of the documentation, especially <xref:signalr/configuration#configure-server-options>.

[!INCLUDE[](~/blazor/includes/location-client-and-server-pre-net8.md)]

:::moniker range=">= aspnetcore-6.0"

## Disable response compression for Hot Reload

When using [Hot Reload](xref:test/hot-reload), disable Response Compression Middleware in the `Development` environment. Whether or not the default code from a project template is used, always call <xref:Microsoft.AspNetCore.Builder.ResponseCompressionBuilderExtensions.UseResponseCompression%2A> first in the request processing pipeline.

In the `Program` file:

```csharp
if (!app.Environment.IsDevelopment())
{
    app.UseResponseCompression();
}
```

:::moniker-end

## Client-side SignalR cross-origin negotiation for authentication

This section explains how to configure SignalR's underlying client to send credentials, such as cookies or HTTP authentication headers.

Use <xref:Microsoft.AspNetCore.Components.WebAssembly.Http.WebAssemblyHttpRequestMessageExtensions.SetBrowserRequestCredentials%2A> to set <xref:Microsoft.AspNetCore.Components.WebAssembly.Http.BrowserRequestCredentials.Include> on cross-origin [`fetch`](https://developer.mozilla.org/docs/Web/API/Fetch_API/Using_Fetch) requests.

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

Where a hub connection is built, assign the <xref:System.Net.Http.HttpMessageHandler> to the <xref:Microsoft.AspNetCore.Http.Connections.Client.HttpConnectionOptions.HttpMessageHandlerFactory> option:

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

The preceding example configures the hub connection URL to the absolute URI address at `/chathub`. The URI can also be set via a string, for example `https://signalr.example.com`, or via [configuration](xref:blazor/fundamentals/configuration). `Navigation` is an injected <xref:Microsoft.AspNetCore.Components.NavigationManager>.

For more information, see <xref:signalr/configuration#configure-additional-options>.

## Client-side rendering

:::moniker range=">= aspnetcore-8.0"

If prerendering is configured, prerendering occurs before the client connection to the server is established. For more information, see <xref:blazor/components/prerender>.

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-8.0"

If prerendering is configured, prerendering occurs before the client connection to the server is established. For more information, see the following articles:

* <xref:mvc/views/tag-helpers/builtin-th/component-tag-helper>
* <xref:blazor/components/prerendering-and-integration>

:::moniker-end

## Prerendered state size and SignalR message size limit

A large prerendered state size may exceed the SignalR circuit message size limit, which results in the following:

* The SignalR circuit fails to initialize with an error on the client: :::no-loc text="Circuit host not initialized.":::
* The reconnection dialog on the client appears when the circuit fails. Recovery isn't possible.

To resolve the problem, use ***either*** of the following approaches:

* Reduce the amount of data that you are putting into the prerendered state.
* Increase the [SignalR message size limit](xref:blazor/fundamentals/signalr#server-side-circuit-handler-options). ***WARNING***: Increasing the limit may increase the risk of Denial of Service (DoS) attacks.

## Additional client-side resources

* [Secure a SignalR hub](xref:blazor/security/webassembly/index#secure-a-signalr-hub)
* <xref:blazor/host-and-deploy/webassembly#signalr-configuration>
* <xref:signalr/introduction>
* <xref:signalr/configuration>
* [Blazor samples GitHub repository (`dotnet/blazor-samples`)](https://github.com/dotnet/blazor-samples)

## Use sticky sessions for server-side webfarm hosting

A Blazor app prerenders in response to the first client request, which creates UI state on the server. When the client attempts to create a SignalR connection, **the client must reconnect to the same server**. When more than one backend server is in use, the app should implement *sticky sessions* for SignalR connections.

> [!NOTE]
> The following error is thrown by an app that hasn't enabled sticky sessions in a webfarm:
>
> > blazor.server.js:1 Uncaught (in promise) Error: Invocation canceled due to the underlying connection being closed.

## Server-side Azure SignalR Service

We recommend using the [Azure SignalR Service](xref:signalr/scale#azure-signalr-service) for server-side development hosted in Microsoft Azure. The service works in conjunction with the app's Blazor Hub for scaling up a server-side app to a large number of concurrent SignalR connections. In addition, the SignalR Service's global reach and high-performance data centers significantly aid in reducing latency due to geography.

Sticky sessions are enabled for the Azure SignalR Service by setting the service's `ServerStickyMode` option or configuration value to `Required`. For more information, see <xref:blazor/host-and-deploy/server#azure-signalr-service>.

## Server-side circuit handler options

Configure the circuit with the <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions> shown in the following table.

| Option | Default | Description |
| --- | --- | --- |
| <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.DetailedErrors> | `false` | Send detailed exception messages to JavaScript when an unhandled exception occurs on the circuit or when a .NET method invocation through JS interop results in an exception. |
| <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.DisconnectedCircuitMaxRetained> | 100 | Maximum number of disconnected circuits that the server holds in memory at a time. |
| <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.DisconnectedCircuitRetentionPeriod> | 3 minutes | Maximum amount of time a disconnected circuit is held in memory before being torn down. |
| <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.JSInteropDefaultCallTimeout> | 1 minute | Maximum amount of time the server waits before timing out an asynchronous JavaScript function invocation. |
| <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.MaxBufferedUnacknowledgedRenderBatches> | 10 | Maximum number of unacknowledged render batches the server keeps in memory per circuit at a given time to support robust reconnection. After reaching the limit, the server stops producing new render batches until one or more batches are acknowledged by the client. |

:::moniker range=">= aspnetcore-8.0"

Configure the options in the `Program` file with an options delegate to <xref:Microsoft.Extensions.DependencyInjection.ServerRazorComponentsBuilderExtensions.AddInteractiveServerComponents%2A>. The following example assigns the default option values shown in the preceding table. Confirm that the `Program` file uses the <xref:System> namespace (`using System;`).

In the `Program` file:

```csharp
builder.Services.AddRazorComponents().AddInteractiveServerComponents(options =>
{
    options.DetailedErrors = false;
    options.DisconnectedCircuitMaxRetained = 100;
    options.DisconnectedCircuitRetentionPeriod = TimeSpan.FromMinutes(3);
    options.JSInteropDefaultCallTimeout = TimeSpan.FromMinutes(1);
    options.MaxBufferedUnacknowledgedRenderBatches = 10;
});
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

Configure the options in the `Program` file with an options delegate to <xref:Microsoft.Extensions.DependencyInjection.ComponentServiceCollectionExtensions.AddServerSideBlazor%2A>. The following example assigns the default option values shown in the preceding table. Confirm that the `Program` file uses the <xref:System> namespace (`using System;`).

In the `Program` file:

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

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Configure the options in `Startup.ConfigureServices` with an options delegate to <xref:Microsoft.Extensions.DependencyInjection.ComponentServiceCollectionExtensions.AddServerSideBlazor%2A>. The following example assigns the default option values shown in the preceding table. Confirm that `Startup.cs` uses the <xref:System> namespace (`using System;`).

In `Startup.ConfigureServices` of `Startup.cs`:

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

:::moniker-end

To configure the <xref:Microsoft.AspNetCore.SignalR.HubConnectionContext>, use <xref:Microsoft.AspNetCore.SignalR.HubConnectionContextOptions> with <xref:Microsoft.Extensions.DependencyInjection.ServerSideBlazorBuilderExtensions.AddHubOptions%2A>. For option descriptions, see <xref:signalr/configuration#configure-server-options>. The following example assigns the default option values. Confirm that the file uses the <xref:System> namespace (`using System;`).

:::moniker range=">= aspnetcore-8.0"

In the `Program` file:

```csharp
builder.Services.AddRazorComponents().AddInteractiveServerComponents().AddHubOptions(options =>
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

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

In the `Program` file:

```csharp
builder.Services.AddServerSideBlazor().AddHubOptions(options =>
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

:::moniker-end

:::moniker range="< aspnetcore-6.0"

In `Startup.ConfigureServices` of `Startup.cs`:

```csharp
services.AddServerSideBlazor().AddHubOptions(options =>
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

:::moniker-end

> [!WARNING]
> The default value of <xref:Microsoft.AspNetCore.SignalR.HubOptions.MaximumReceiveMessageSize> is 32 KB. Increasing the value may increase the risk of [Denial of Service (DoS) attacks](xref:blazor/security/server/interactive-server-side-rendering#denial-of-service-dos-attacks).

For information on memory management, see <xref:blazor/host-and-deploy/server#memory-management>.

## Blazor hub options

Configure <xref:Microsoft.AspNetCore.Builder.ComponentEndpointRouteBuilderExtensions.MapBlazorHub%2A> options to control <xref:Microsoft.AspNetCore.Http.Connections.HttpConnectionDispatcherOptions> of the Blazor hub:

:::moniker range=">= aspnetcore-8.0"

* <xref:Microsoft.AspNetCore.Http.Connections.HttpConnectionDispatcherOptions.AllowStatefulReconnects>
* <xref:Microsoft.AspNetCore.Http.Connections.HttpConnectionDispatcherOptions.ApplicationMaxBufferSize>
* <xref:Microsoft.AspNetCore.Http.Connections.HttpConnectionDispatcherOptions.AuthorizationData> (*Read only*)
* <xref:Microsoft.AspNetCore.Http.Connections.HttpConnectionDispatcherOptions.CloseOnAuthenticationExpiration>
* <xref:Microsoft.AspNetCore.Http.Connections.HttpConnectionDispatcherOptions.LongPolling> (*Read only*)
* <xref:Microsoft.AspNetCore.Http.Connections.HttpConnectionDispatcherOptions.MinimumProtocolVersion>
* <xref:Microsoft.AspNetCore.Http.Connections.HttpConnectionDispatcherOptions.TransportMaxBufferSize>
* <xref:Microsoft.AspNetCore.Http.Connections.HttpConnectionDispatcherOptions.Transports>
* <xref:Microsoft.AspNetCore.Http.Connections.HttpConnectionDispatcherOptions.TransportSendTimeout>
* <xref:Microsoft.AspNetCore.Http.Connections.HttpConnectionDispatcherOptions.WebSockets> (*Read only*)

Place the call to `app.MapBlazorHub` after the call to `app.MapRazorComponents` in the app's `Program` file:

```csharp
app.MapBlazorHub(options =>
{
    options.{OPTION} = {VALUE};
});
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

* <xref:Microsoft.AspNetCore.Http.Connections.HttpConnectionDispatcherOptions.ApplicationMaxBufferSize>
* <xref:Microsoft.AspNetCore.Http.Connections.HttpConnectionDispatcherOptions.AuthorizationData> (*Read only*)
* <xref:Microsoft.AspNetCore.Http.Connections.HttpConnectionDispatcherOptions.CloseOnAuthenticationExpiration>
* <xref:Microsoft.AspNetCore.Http.Connections.HttpConnectionDispatcherOptions.LongPolling> (*Read only*)
* <xref:Microsoft.AspNetCore.Http.Connections.HttpConnectionDispatcherOptions.TransportMaxBufferSize>
* <xref:Microsoft.AspNetCore.Http.Connections.HttpConnectionDispatcherOptions.TransportSendTimeout>

Supply the options to `app.MapBlazorHub` in the app's `Program` file:

```csharp
app.MapBlazorHub(options =>
{
    options.{OPTION} = {VALUE};
});
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

* <xref:Microsoft.AspNetCore.Http.Connections.HttpConnectionDispatcherOptions.ApplicationMaxBufferSize>
* <xref:Microsoft.AspNetCore.Http.Connections.HttpConnectionDispatcherOptions.AuthorizationData> (*Read only*)
* <xref:Microsoft.AspNetCore.Http.Connections.HttpConnectionDispatcherOptions.LongPolling> (*Read only*)
* <xref:Microsoft.AspNetCore.Http.Connections.HttpConnectionDispatcherOptions.TransportMaxBufferSize>

Supply the options to `app.MapBlazorHub` in endpoint routing configuration:

```csharp
app.UseEndpoints(endpoints =>
{
    endpoints.MapBlazorHub(options =>
    {
        options.{OPTION} = {VALUE};
    });
    ...
});

:::moniker-end

In the preceding example, the `{OPTION}` placeholder is the option, and the `{VALUE}` placeholder is the value.

## Maximum receive message size

*This section only applies to projects that implement SignalR.*

The maximum incoming SignalR message size permitted for hub methods is limited by the <xref:Microsoft.AspNetCore.SignalR.HubOptions.MaximumReceiveMessageSize?displayProperty=nameWithType> (default: 32 KB). SignalR messages larger than <xref:Microsoft.AspNetCore.SignalR.HubOptions.MaximumReceiveMessageSize> throw an error. The framework doesn't impose a limit on the size of a SignalR message from the hub to a client.

When SignalR logging isn't set to [Debug](xref:Microsoft.Extensions.Logging.LogLevel) or [Trace](xref:Microsoft.Extensions.Logging.LogLevel), a message size error only appears in the browser's developer tools console:

> Error: Connection disconnected with error 'Error: Server returned an error on close: Connection closed with an error.'.

When [SignalR server-side logging](xref:signalr/diagnostics#server-side-logging) is set to [Debug](xref:Microsoft.Extensions.Logging.LogLevel) or [Trace](xref:Microsoft.Extensions.Logging.LogLevel), server-side logging surfaces an <xref:System.IO.InvalidDataException> for a message size error.

`appsettings.Development.json`:

```json
{
  "DetailedErrors": true,
  "Logging": {
    "LogLevel": {
      ...
      "Microsoft.AspNetCore.SignalR": "Debug"
    }
  }
}
```

Error:

> System.IO.InvalidDataException: The maximum message size of 32768B was exceeded. The message size can be configured in AddHubOptions.

:::moniker range=">= aspnetcore-8.0"

One approach involves increasing the limit by setting <xref:Microsoft.AspNetCore.SignalR.HubOptions.MaximumReceiveMessageSize> in the `Program` file. The following example sets the maximum receive message size to 64 KB:

```csharp
builder.Services.AddRazorComponents().AddInteractiveServerComponents()
    .AddHubOptions(options => options.MaximumReceiveMessageSize = 64 * 1024);
```

Increasing the SignalR incoming message size limit comes at the cost of requiring more server resources, and it increases the risk of [Denial of Service (DoS) attacks](xref:blazor/security/server/interactive-server-side-rendering#denial-of-service-dos-attacks). Additionally, reading a large amount of content in to memory as strings or byte arrays can also result in allocations that work poorly with the garbage collector, resulting in additional performance penalties.

A better option for reading large payloads is to send the content in smaller chunks and process the payload as a <xref:System.IO.Stream>. This can be used when reading large JavaScript (JS) interop JSON payloads or if JS interop data is available as raw bytes. For an example that demonstrates sending large binary payloads in server-side apps that uses techniques similar to the [`InputFile` component](xref:blazor/file-uploads), see the [Binary Submit sample app](https://github.com/aspnet/samples/tree/main/samples/aspnetcore/blazor/BinarySubmit) and the [Blazor `InputLargeTextArea` Component Sample](https://github.com/aspnet/samples/tree/main/samples/aspnetcore/blazor/InputLargeTextArea).

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

Forms that process large payloads over SignalR can also use streaming JS interop directly. For more information, see <xref:blazor/js-interop/call-dotnet-from-javascript#stream-from-javascript-to-net>. For a forms example that streams `<textarea>` data to the server, see <xref:blazor/forms/troubleshoot#large-form-payloads-and-the-signalr-message-size-limit>.

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

One approach involves increasing the limit by setting <xref:Microsoft.AspNetCore.SignalR.HubOptions.MaximumReceiveMessageSize> in the `Program` file. The following example sets the maximum receive message size to 64 KB:

```csharp
builder.Services.AddServerSideBlazor()
    .AddHubOptions(options => options.MaximumReceiveMessageSize = 64 * 1024);
```

Increasing the SignalR incoming message size limit comes at the cost of requiring more server resources, and it increases the risk of [Denial of Service (DoS) attacks](xref:blazor/security/server/interactive-server-side-rendering#denial-of-service-dos-attacks). Additionally, reading a large amount of content in to memory as strings or byte arrays can also result in allocations that work poorly with the garbage collector, resulting in additional performance penalties.

A better option for reading large payloads is to send the content in smaller chunks and process the payload as a <xref:System.IO.Stream>. This can be used when reading large JavaScript (JS) interop JSON payloads or if JS interop data is available as raw bytes. For an example that demonstrates sending large binary payloads in Blazor Server that uses techniques similar to the [`InputFile` component](xref:blazor/file-uploads), see the [Binary Submit sample app](https://github.com/aspnet/samples/tree/main/samples/aspnetcore/blazor/BinarySubmit) and the [Blazor `InputLargeTextArea` Component Sample](https://github.com/aspnet/samples/tree/main/samples/aspnetcore/blazor/InputLargeTextArea).

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

Forms that process large payloads over SignalR can also use streaming JS interop directly. For more information, see <xref:blazor/js-interop/call-dotnet-from-javascript#stream-from-javascript-to-net>. For a forms example that streams `<textarea>` data in a Blazor Server app, see <xref:blazor/forms/troubleshoot#large-form-payloads-and-the-signalr-message-size-limit>.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Increase the limit by setting <xref:Microsoft.AspNetCore.SignalR.HubOptions.MaximumReceiveMessageSize> in `Startup.ConfigureServices`:

```csharp
services.AddServerSideBlazor()
    .AddHubOptions(options => options.MaximumReceiveMessageSize = 64 * 1024);
```

Increasing the SignalR incoming message size limit comes at the cost of requiring more server resources, and it increases the risk of [Denial of Service (DoS) attacks](xref:blazor/security/server/interactive-server-side-rendering#denial-of-service-dos-attacks). Additionally, reading a large amount of content in to memory as strings or byte arrays can also result in allocations that work poorly with the garbage collector, resulting in additional performance penalties.

:::moniker-end

Consider the following guidance when developing code that transfers a large amount of data:

:::moniker range=">= aspnetcore-6.0"

* Leverage the native streaming JS interop support to transfer data larger than the SignalR incoming message size limit:
  * <xref:blazor/js-interop/call-javascript-from-dotnet#stream-from-net-to-javascript>
  * <xref:blazor/js-interop/call-dotnet-from-javascript#stream-from-javascript-to-net>
  * Form payload example: <xref:blazor/forms/troubleshoot#large-form-payloads-and-the-signalr-message-size-limit>
* General tips:
  * Don't allocate large objects in JS and C# code.
  * Free consumed memory when the process is completed or cancelled.
  * Enforce the following additional requirements for security purposes:
    * Declare the maximum file or data size that can be passed.
    * Declare the minimum upload rate from the client to the server.
  * After the data is received by the server, the data can be:
    * Temporarily stored in a memory buffer until all of the segments are collected.
    * Consumed immediately. For example, the data can be stored immediately in a database or written to disk as each segment is received.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

* Slice the data into smaller pieces, and send the data segments sequentially until all of the data is received by the server.
* Don't allocate large objects in JS and C# code.
* Don't block the main UI thread for long periods when sending or receiving data.
* Free consumed memory when the process is completed or cancelled.
* Enforce the following additional requirements for security purposes:
  * Declare the maximum file or data size that can be passed.
  * Declare the minimum upload rate from the client to the server.
* After the data is received by the server, the data can be:
  * Temporarily stored in a memory buffer until all of the segments are collected.
  * Consumed immediately. For example, the data can be stored immediately in a database or written to disk as each segment is received.

:::moniker-end

## Blazor server-side Hub endpoint route configuration

In the `Program` file, call <xref:Microsoft.AspNetCore.Builder.ComponentEndpointRouteBuilderExtensions.MapBlazorHub%2A> to map the Blazor <xref:Microsoft.AspNetCore.SignalR.Hub> to the app's default path. The Blazor script (`blazor.*.js`) automatically points to the endpoint created by <xref:Microsoft.AspNetCore.Builder.ComponentEndpointRouteBuilderExtensions.MapBlazorHub%2A>.

## Reflect the server-side connection state in the UI

When the client detects that the connection has been lost, a default UI is displayed to the user while the client attempts to reconnect. If reconnection fails, the user is provided the option to retry.

:::moniker range=">= aspnetcore-8.0"

To customize the UI, define a single element with an `id` of `components-reconnect-modal`. The following example places the element in the `App` component.

`App.razor`:

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

To customize the UI, define a single element with an `id` of `components-reconnect-modal`. The following example places the element in the host page.

`Pages/_Host.cshtml`:

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

To customize the UI, define a single element with an `id` of `components-reconnect-modal`. The following example places the element in the layout page.

`Pages/_Layout.cshtml`:

:::moniker-end

:::moniker range="< aspnetcore-6.0"

To customize the UI, define a single element with an `id` of `components-reconnect-modal`. The following example places the element in the host page.

`Pages/_Host.cshtml`:

:::moniker-end

```cshtml
<div id="components-reconnect-modal">
    There was a problem with the connection!
</div>
```

> [!NOTE]
> If more than one element with an `id` of `components-reconnect-modal` are rendered by the app, only the first rendered element receives CSS class changes to display or hide the element. 

Add the following CSS styles to the site's stylesheet.

:::moniker range=">= aspnetcore-8.0"

`wwwroot/app.css`:

:::moniker-end

:::moniker range="< aspnetcore-8.0"

`wwwroot/css/site.css`:

:::moniker-end

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

:::moniker range=">= aspnetcore-5.0"

Customize the delay before the reconnection display appears by setting the `transition-delay` property in the site's CSS for the modal element. The following example sets the transition delay from 500 ms (default) to 1,000 ms (1 second).

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

`wwwroot/app.css`:

:::moniker-end

:::moniker range="< aspnetcore-8.0"

`wwwroot/css/site.css`:

:::moniker-end

:::moniker range=">= aspnetcore-5.0"

```css
#components-reconnect-modal {
    transition: visibility 0s linear 1000ms;
}
```

To display the current reconnect attempt, define an element with an `id` of `components-reconnect-current-attempt`. To display the maximum number of reconnect retries, define an element with an `id` of `components-reconnect-max-retries`. The following example places these elements inside a reconnect attempt modal element following the previous example.

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

:::moniker-end

## Server-side rendering

:::moniker range=">= aspnetcore-8.0"

By default, components are prerendered on the server before the client connection to the server is established. For more information, see <xref:blazor/components/prerender>.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

By default, components are prerendered on the server before the client connection to the server is established. For more information, see <xref:mvc/views/tag-helpers/builtin-th/component-tag-helper>.

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

## Monitor server-side circuit activity

Monitor inbound circuit activity using the <xref:Microsoft.AspNetCore.Components.Server.Circuits.CircuitHandler.CreateInboundActivityHandler%2A> method on <xref:Microsoft.AspNetCore.Components.Server.Circuits.CircuitHandler>. Inbound circuit activity is any activity sent from the browser to the server, such as UI events or JavaScript-to-.NET interop calls.

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
        logger.LogInformation("{Circuit} is idle", nameof(CircuitIdle));
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

Circuit activity handlers also provide an approach for accessing scoped Blazor services from other non-Blazor dependency injection (DI) scopes. For more information and examples, see:

* <xref:blazor/fundamentals/dependency-injection#access-server-side-blazor-services-from-a-different-di-scope>
* <xref:blazor/security/server/additional-scenarios#access-authenticationstateprovider-in-outgoing-request-middleware>

:::moniker-end

## Blazor startup

:::moniker range=">= aspnetcore-8.0"

Configure the manual start of a Blazor app's SignalR circuit in the `App.razor` file of a Blazor Web App:

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

Configure the manual start of a Blazor app's SignalR circuit in the `Pages/_Host.cshtml` file (Blazor Server):

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

Configure the manual start of a Blazor app's SignalR circuit in the `Pages/_Layout.cshtml` file (Blazor Server):

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Configure the manual start of a Blazor app's SignalR circuit in the `Pages/_Host.cshtml` file (Blazor Server):

:::moniker-end

* Add an `autostart="false"` attribute to the `<script>` tag for the `blazor.*.js` script.
* Place a script that calls `Blazor.start()` after the Blazor script is loaded and inside the closing `</body>` tag.

When `autostart` is disabled, any aspect of the app that doesn't depend on the circuit works normally. For example, client-side routing is operational. However, any aspect that depends on the circuit isn't operational until `Blazor.start()` is called. App behavior is unpredictable without an established circuit. For example, component methods fail to execute while the circuit is disconnected.

For more information, including how to initialize Blazor when the document is ready and how to chain to a [JS `Promise`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise), see <xref:blazor/fundamentals/startup>.

## Configure SignalR timeouts and Keep-Alive on the client

:::moniker range=">= aspnetcore-8.0"

Configure the following values for the client:

* `withServerTimeout`: Configures the server timeout in milliseconds. If this timeout elapses without receiving any messages from the server, the connection is terminated with an error. The default timeout value is 30 seconds. The server timeout should be at least double the value assigned to the Keep-Alive interval (`withKeepAliveInterval`).
* `withKeepAliveInterval`: Configures the Keep-Alive interval in milliseconds (default interval at which to ping the server). This setting allows the server to detect hard disconnects, such as when a client unplugs their computer from the network. The ping occurs at most as often as the server pings. If the server pings every five seconds, assigning a value lower than `5000` (5 seconds) pings every five seconds. The default value is 15 seconds. The Keep-Alive interval should be less than or equal to half the value assigned to the server timeout (`withServerTimeout`).

The following example for the `App.razor` file (Blazor Web App) shows the assignment of default values.

Blazor Web App:

```html
<script src="{BLAZOR SCRIPT}" autostart="false"></script>
<script>
  Blazor.start({
    circuit: {
      configureSignalR: function (builder) {
        builder.withServerTimeout(30000).withKeepAliveInterval(15000);
      }
    }
  });
</script>
```

The following example for the `Pages/_Host.cshtml` file (Blazor Server, all versions except ASP.NET Core 6.0) or `Pages/_Layout.cshtml` file (Blazor Server, ASP.NET Core 6.0).

Blazor Server:

```html
<script src="{BLAZOR SCRIPT}" autostart="false"></script>
<script>
  Blazor.start({
    configureSignalR: function (builder) {
        builder.withServerTimeout(30000).withKeepAliveInterval(15000);
  });
</script>
```

**In the preceding example, the `{BLAZOR SCRIPT}` placeholder is the Blazor script path and file name.** For the location of the script and the path to use, see <xref:blazor/project-structure#location-of-the-blazor-script>.

When creating a hub connection in a component, set the <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.ServerTimeout> (default: 30 seconds) and <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.KeepAliveInterval> (default: 15 seconds) on the <xref:Microsoft.AspNetCore.SignalR.Client.HubConnectionBuilder>. Set the <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.HandshakeTimeout> (default: 15 seconds) on the built <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection>. The following example shows the assignment of default values:

```csharp
protected override async Task OnInitializedAsync()
{
    hubConnection = new HubConnectionBuilder()
        .WithUrl(Navigation.ToAbsoluteUri("/chathub"))
        .WithServerTimeout(TimeSpan.FromSeconds(30))
        .WithKeepAliveInterval(TimeSpan.FromSeconds(15))
        .Build();

    hubConnection.HandshakeTimeout = TimeSpan.FromSeconds(15);

    hubConnection.On<string, string>("ReceiveMessage", (user, message) => ...

    await hubConnection.StartAsync();
}
```

:::moniker-end

:::moniker range="< aspnetcore-8.0"

Configure the following values for the client:

* `serverTimeoutInMilliseconds`: The server timeout in milliseconds. If this timeout elapses without receiving any messages from the server, the connection is terminated with an error. The default timeout value is 30 seconds. The server timeout should be at least double the value assigned to the Keep-Alive interval (`keepAliveIntervalInMilliseconds`).
* `keepAliveIntervalInMilliseconds`: Default interval at which to ping the server. This setting allows the server to detect hard disconnects, such as when a client unplugs their computer from the network. The ping occurs at most as often as the server pings. If the server pings every five seconds, assigning a value lower than `5000` (5 seconds) pings every five seconds. The default value is 15 seconds. The Keep-Alive interval should be less than or equal to half the value assigned to the server timeout (`serverTimeoutInMilliseconds`).

The following example for the `Pages/_Host.cshtml` file (Blazor Server, all versions except ASP.NET Core 6.0) or `Pages/_Layout.cshtml` file (Blazor Server, ASP.NET Core 6.0):

```html
<script src="{BLAZOR SCRIPT}" autostart="false"></script>
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

**In the preceding example, the `{BLAZOR SCRIPT}` placeholder is the Blazor script path and file name.** For the location of the script and the path to use, see <xref:blazor/project-structure#location-of-the-blazor-script>.

When creating a hub connection in a component, set the <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.ServerTimeout> (default: 30 seconds), <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.HandshakeTimeout> (default: 15 seconds), and <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.KeepAliveInterval> (default: 15 seconds) on the built <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection>. The following example shows the assignment of default values:

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

:::moniker-end

When changing the values of the server timeout (<xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.ServerTimeout>) or the Keep-Alive interval (<xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.KeepAliveInterval>:

* The server timeout should be at least double the value assigned to the Keep-Alive interval.
* The Keep-Alive interval should be less than or equal to half the value assigned to the server timeout.

For more information, see the *Global deployment and connection failures* sections of the following articles:

* <xref:blazor/host-and-deploy/server#global-deployment-and-connection-failures>
* <xref:blazor/host-and-deploy/webassembly#global-deployment-and-connection-failures>

## Modify the server-side reconnection handler

The reconnection handler's circuit connection events can be modified for custom behaviors, such as:

* To notify the user if the connection is dropped.
* To perform logging (from the client) when a circuit is connected.

To modify the connection events, register callbacks for the following connection changes:

* Dropped connections use `onConnectionDown`.
* Established/re-established connections use `onConnectionUp`.

**Both `onConnectionDown` and `onConnectionUp` must be specified.**

:::moniker range=">= aspnetcore-8.0"

Blazor Web App:

```html
<script src="{BLAZOR SCRIPT}" autostart="false"></script>
<script>
  Blazor.start({
    circuit: {
      reconnectionHandler: {
        onConnectionDown: (options, error) => console.error(error),
        onConnectionUp: () => console.log("Up, up, and away!")
      }
    }
  });
</script>
```

Blazor Server:

:::moniker-end

```html
<script src="{BLAZOR SCRIPT}" autostart="false"></script>
<script>
  Blazor.start({
    reconnectionHandler: {
      onConnectionDown: (options, error) => console.error(error),
      onConnectionUp: () => console.log("Up, up, and away!")
    }
  });
</script>
```

**In the preceding example, the `{BLAZOR SCRIPT}` placeholder is the Blazor script path and file name.** For the location of the script and the path to use, see <xref:blazor/project-structure#location-of-the-blazor-script>.

:::moniker range=">= aspnetcore-7.0"

### Automatically refresh the page when server-side reconnection fails

The default reconnection behavior requires the user to take manual action to refresh the page after reconnection fails. However, a custom reconnection handler can be used to automatically refresh the page:

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

`App.razor`:

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

`Pages/_Host.cshtml`:

:::moniker-end

:::moniker range=">= aspnetcore-7.0"

```html
<div id="reconnect-modal" style="display: none;"></div>
<script src="{BLAZOR SCRIPT}" autostart="false"></script>
<script src="boot.js"></script>
```

**In the preceding example, the `{BLAZOR SCRIPT}` placeholder is the Blazor script path and file name.** For the location of the script and the path to use, see <xref:blazor/project-structure#location-of-the-blazor-script>.

Create the following `wwwroot/boot.js` file.

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

Blazor Web App:

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
    circuit: {
      reconnectionHandler: {
        onConnectionDown: () => currentReconnectionProcess ??= startReconnectionProcess(),
        onConnectionUp: () => {
          currentReconnectionProcess?.cancel();
          currentReconnectionProcess = null;
        }
      }
    }
  });
})();
```

Blazor Server:

:::moniker-end

:::moniker range=">= aspnetcore-7.0"

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
      }
    }
  });
})();
```

For more information on Blazor startup, see <xref:blazor/fundamentals/startup>.

:::moniker-end

## Adjust the server-side reconnection retry count and interval

To adjust the reconnection retry count and interval, set the number of retries (`maxRetries`) and period in milliseconds permitted for each retry attempt (`retryIntervalMilliseconds`).

:::moniker range=">= aspnetcore-8.0"

Blazor Web App:

```html
<script src="{BLAZOR SCRIPT}" autostart="false"></script>
<script>
  Blazor.start({
    circuit: {
      reconnectionOptions: {
        maxRetries: 3,
        retryIntervalMilliseconds: 2000
      }
    }
  });
</script>
```

Blazor Server:

:::moniker-end

```html
<script src="{BLAZOR SCRIPT}" autostart="false"></script>
<script>
  Blazor.start({
    reconnectionOptions: {
      maxRetries: 3,
      retryIntervalMilliseconds: 2000
    }
  });
</script>
```

**In the preceding example, the `{BLAZOR SCRIPT}` placeholder is the Blazor script path and file name.** For the location of the script and the path to use, see <xref:blazor/project-structure#location-of-the-blazor-script>.

For more information on Blazor startup, see <xref:blazor/fundamentals/startup>.

:::moniker range=">= aspnetcore-5.0"

## Disconnect the Blazor circuit from the client

By default, a Blazor circuit is disconnected when the [`unload` page event](https://developer.mozilla.org/docs/Web/API/Window/unload_event) is triggered. To disconnect the circuit for other scenarios on the client, invoke `Blazor.disconnect` in the appropriate event handler. In the following example, the circuit is disconnected when the page is hidden ([`pagehide` event](https://developer.mozilla.org/docs/Web/API/Window/pagehide_event)):

```javascript
window.addEventListener('pagehide', () => {
  Blazor.disconnect();
});
```

For more information on Blazor startup, see <xref:blazor/fundamentals/startup>.

:::moniker-end

## Server-side circuit handler

You can define a *circuit handler*, which allows running code on changes to the state of a user's circuit. A circuit handler is implemented by deriving from <xref:Microsoft.AspNetCore.Components.Server.Circuits.CircuitHandler> and registering the class in the app's service container. The following example of a circuit handler tracks open SignalR connections.

`TrackingCircuitHandler.cs`:

:::code language="csharp" source="~/../blazor-samples/7.0/BlazorSample_Server/TrackingCircuitHandler.cs":::

Circuit handlers are registered using DI. Scoped instances are created per instance of a circuit. Using the `TrackingCircuitHandler` in the preceding example, a singleton service is created because the state of all circuits must be tracked.

:::moniker range=">= aspnetcore-6.0"

In the `Program` file:

```csharp
builder.Services.AddSingleton<CircuitHandler, TrackingCircuitHandler>();
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

In `Startup.ConfigureServices` of `Startup.cs`:

```csharp
services.AddSingleton<CircuitHandler, TrackingCircuitHandler>();
```

:::moniker-end

If a custom circuit handler's methods throw an unhandled exception, the exception is fatal to the circuit. To tolerate exceptions in a handler's code or called methods, wrap the code in one or more [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statements with error handling and logging.

When a circuit ends because a user has disconnected and the framework is cleaning up the circuit state, the framework disposes of the circuit's DI scope. Disposing the scope disposes any circuit-scoped DI services that implement <xref:System.IDisposable?displayProperty=fullName>. If any DI service throws an unhandled exception during disposal, the framework logs the exception. For more information, see <xref:blazor/fundamentals/dependency-injection#service-lifetime>.

## Server-side circuit handler to capture users for custom services

Use a <xref:Microsoft.AspNetCore.Components.Server.Circuits.CircuitHandler> to capture a user from the <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> and set that user in a service. For more information and example code, see <xref:blazor/security/server/additional-scenarios#circuit-handler-to-capture-users-for-custom-services>.

:::moniker range=">= aspnetcore-8.0"

## Closure of circuits when there are no remaining Interactive Server components

[!INCLUDE[](~/blazor/includes/closure-of-circuits.md)]

:::moniker-end

## `IHttpContextAccessor`/`HttpContext` in Razor components

[!INCLUDE[](~/blazor/security/includes/httpcontext.md)]

## Additional server-side resources

* [Server-side host and deployment guidance: SignalR configuration](xref:blazor/host-and-deploy/server#signalr-configuration)
* <xref:signalr/introduction>
* <xref:signalr/configuration>
* Server-side security documentation
  * <xref:blazor/security/index>
  * <xref:blazor/security/server/index>
  * <xref:blazor/security/server/interactive-server-side-rendering>
  * <xref:blazor/security/server/additional-scenarios>
* [Server-side reconnection events and component lifecycle events](xref:blazor/components/lifecycle#blazor-server-reconnection-events)
* [What is Azure SignalR Service?](/azure/azure-signalr/signalr-overview)
* [Performance guide for Azure SignalR Service](/azure/azure-signalr/signalr-concept-performance)
* <xref:signalr/publish-to-azure-web-app>
* [Blazor samples GitHub repository (`dotnet/blazor-samples`)](https://github.com/dotnet/blazor-samples)
