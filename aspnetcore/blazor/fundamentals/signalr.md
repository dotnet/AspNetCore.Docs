---
title: ASP.NET Core Blazor SignalR guidance
author: guardrex
description: Learn how to configure and manage Blazor SignalR connections.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 02/09/2024
uid: blazor/fundamentals/signalr
---
# ASP.NET Core Blazor SignalR guidance

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to configure and manage SignalR connections in Blazor apps.

For general guidance on ASP.NET Core SignalR configuration, see the topics in the <xref:signalr/introduction> area of the documentation, especially <xref:signalr/configuration#configure-server-options>.

Server-side apps use ASP.NET Core SignalR to communicate with the browser. [SignalR's hosting and scaling conditions](xref:signalr/publish-to-azure-web-app) apply to server-side apps.

Blazor works best when using WebSockets as the SignalR transport due to lower latency, reliability, and [security](xref:signalr/security). Long Polling is used by SignalR when WebSockets isn't available or when the app is explicitly configured to use Long Polling.

:::moniker range=">= aspnetcore-8.0"

<!-- UPDATE 9.0 Remove when support is present -->

## Azure SignalR Service with stateful reconnect

[Stateful reconnect](xref:signalr/configuration#configure-stateful-reconnect) (<xref:Microsoft.AspNetCore.SignalR.Client.HubConnectionBuilderHttpExtensions.WithStatefulReconnect%2A>) was released with .NET 8 but isn't currently supported for the Azure SignalR Service. For more information, see [Stateful Reconnect Support? (`Azure/azure-signalr` #1878)](https://github.com/Azure/azure-signalr/issues/1878).

:::moniker-end

:::moniker range=">= aspnetcore-9.0"

## WebSocket compression for Interactive Server components

<!-- UPDATE 9.0 Add API doc cross-links -->

By default, Interactive Server components:

* Enable compression for [WebSocket connections](xref:fundamentals/websockets). `ConfigureWebsocketOptions` controls WebSocket compression.

* Adopt a `frame-ancestors` [Content Security Policy (CSP)](https://developer.mozilla.org/docs/Web/HTTP/CSP) directive set to `'self'`, which only permits embedding the app in an `<iframe>` of the origin from which the app is served when compression is enabled or when a configuration for the WebSocket context is provided. `ContentSecurityFrameAncestorPolicy` controls the `frame-ancestors` CSP.

The `frame-ancestors` CSP can be removed manually by setting the value of `ConfigureWebSocketOptions` to `null`, as you may want to [configure the CSP in a centralized way](xref:blazor/security/content-security-policy). When the `frame-ancestors` CSP is managed in a centralized fashion, care must be taken to apply a policy whenever the first document is rendered. We don't recommend removing the policy completely, as it might make the app vulnerable to attack.

Usage examples:

Disable compression by setting `ConfigureWebSocketOptions` to `null`, which reduces the [vulnerability of the app to attack](xref:blazor/security/server/interactive-server-side-rendering#interactive-server-components-with-websocket-compression-enabled) but may result in reduced performance:

```csharp
builder.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode(o => o.ConfigureWebSocketOptions = null)
```

When compression is enabled, configure a stricter `frame-ancestors` CSP with a value of `'none'` (single quotes required), which allows WebSocket compression but prevents browsers from embedding the app into any `<iframe>`:

```csharp
builder.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode(o => o.ContentSecurityFrameAncestorsPolicy = "'none'")
```

When compression is enabled, remove the `frame-ancestors` CSP by setting `ContentSecurityFrameAncestorsPolicy` to `null`. This scenario is only recommended for apps that [set the CSP in a centralized way](xref:blazor/security/content-security-policy):

```csharp
builder.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode(o => o.ContentSecurityFrameAncestorsPolicy = null)
```

> [!IMPORTANT]
> Browsers apply CSP directives from multiple CSP headers using the strictest policy directive value. Therefore, a developer can't add a weaker `frame-ancestors` policy than `'self'` on purpose or by mistake.
>
> Single quotes are required on the string value passed to `ContentSecurityFrameAncestorsPolicy`:
>
> <span aria-hidden="true">❌</span><span class="visually-hidden">Unsupported values:</span> `none`, `self`
>
> <span aria-hidden="true">✔️</span><span class="visually-hidden">Supported values:</span> `'none'`, `'self'`
>
> Additional options include specifying one or more host sources and scheme sources.

For security implications, see <xref:blazor/security/server/interactive-server-side-rendering#interactive-server-components-with-websocket-compression-enabled>. For more information on the `frame-ancestors` directive, see [CSP: `frame-ancestors` (MDN documentation)](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/frame-ancestors).

:::moniker-end

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
* The reconnection UI on the client appears when the circuit fails. Recovery isn't possible.

To resolve the problem, use ***either*** of the following approaches:

* Reduce the amount of data that you are putting into the prerendered state.
* Increase the [SignalR message size limit](xref:blazor/fundamentals/signalr#server-side-circuit-handler-options). ***WARNING***: Increasing the limit may increase the risk of Denial of Service (DoS) attacks.

## Additional client-side resources

* [Secure a SignalR hub](xref:blazor/security/webassembly/index#secure-a-signalr-hub)
* <xref:signalr/introduction>
* <xref:signalr/configuration>
* [Blazor samples GitHub repository (`dotnet/blazor-samples`)](https://github.com/dotnet/blazor-samples) ([how to download](xref:blazor/fundamentals/index#sample-apps))

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

Configure the circuit with <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions>. View default values in the [reference source](https://github.com/dotnet/aspnetcore/blob/main/src/Components/Server/src/CircuitOptions.cs).

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

:::moniker range=">= aspnetcore-8.0"

Read or set the options in the `Program` file with an options delegate to <xref:Microsoft.Extensions.DependencyInjection.ServerRazorComponentsBuilderExtensions.AddInteractiveServerComponents%2A>. The `{OPTION}` placeholder represents the option, and the `{VALUE}` placeholder is the value.

In the `Program` file:

```csharp
builder.Services.AddRazorComponents().AddInteractiveServerComponents(options =>
{
    options.{OPTION} = {VALUE};
});
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

Read or set the options in the `Program` file with an options delegate to <xref:Microsoft.Extensions.DependencyInjection.ComponentServiceCollectionExtensions.AddServerSideBlazor%2A>. The `{OPTION}` placeholder represents the option, and the `{VALUE}` placeholder is the value.

In the `Program` file:

```csharp
builder.Services.AddServerSideBlazor(options =>
{
    options.{OPTION} = {VALUE};
});
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Read or set the options in `Startup.ConfigureServices` with an options delegate to <xref:Microsoft.Extensions.DependencyInjection.ComponentServiceCollectionExtensions.AddServerSideBlazor%2A>. The `{OPTION}` placeholder represents the option, and the `{VALUE}` placeholder is the value.

In `Startup.ConfigureServices` of `Startup.cs`:

```csharp
services.AddServerSideBlazor(options =>
{
    options.{OPTION} = {VALUE};
});
```

:::moniker-end

To configure the <xref:Microsoft.AspNetCore.SignalR.HubConnectionContext>, use <xref:Microsoft.AspNetCore.SignalR.HubConnectionContextOptions> with <xref:Microsoft.Extensions.DependencyInjection.ServerSideBlazorBuilderExtensions.AddHubOptions%2A>. View the defaults for the hub connection context options in [reference source](https://github.com/dotnet/aspnetcore/blob/main/src/SignalR/server/Core/src/HubConnectionContextOptions.cs). For option descriptions in the SignalR documentation, see <xref:signalr/configuration#configure-server-options>. The `{OPTION}` placeholder represents the option, and the `{VALUE}` placeholder is the value.

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

:::moniker range=">= aspnetcore-8.0"

In the `Program` file:

```csharp
builder.Services.AddRazorComponents().AddInteractiveServerComponents().AddHubOptions(options =>
{
    options.{OPTION} = {VALUE};
});
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

In the `Program` file:

```csharp
builder.Services.AddServerSideBlazor().AddHubOptions(options =>
{
    options.{OPTION} = {VALUE};
});
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

In `Startup.ConfigureServices` of `Startup.cs`:

```csharp
services.AddServerSideBlazor().AddHubOptions(options =>
{
    options.{OPTION} = {VALUE};
});
```

:::moniker-end

<!-- UPDATE 9.0 Check on a fix for the added 
                MaximumParallelInvocationsPerClient warning
                per https://github.com/dotnet/aspnetcore/issues/53951 
                and version if fixed. -->

> [!WARNING]
> The default value of <xref:Microsoft.AspNetCore.SignalR.HubOptions.MaximumReceiveMessageSize> is 32 KB. Increasing the value may increase the risk of [Denial of Service (DoS) attacks](xref:blazor/security/server/interactive-server-side-rendering#denial-of-service-dos-attacks).
>
> Blazor relies on <xref:Microsoft.AspNetCore.SignalR.HubOptions.MaximumParallelInvocationsPerClient%2A> set to 1, which is the default value. For more information, see [MaximumParallelInvocationsPerClient > 1 breaks file upload in Blazor Server mode (`dotnet/aspnetcore` #53951)](https://github.com/dotnet/aspnetcore/issues/53951).

For information on memory management, see <xref:blazor/host-and-deploy/server#memory-management>.

## Blazor hub options

Configure <xref:Microsoft.AspNetCore.Builder.ComponentEndpointRouteBuilderExtensions.MapBlazorHub%2A> options to control <xref:Microsoft.AspNetCore.Http.Connections.HttpConnectionDispatcherOptions> of the Blazor hub. View the defaults for the hub connection dispatcher options in [reference source](https://github.com/dotnet/aspnetcore/blob/main/src/SignalR/common/Http.Connections/src/HttpConnectionDispatcherOptions.cs). The `{OPTION}` placeholder represents the option, and the `{VALUE}` placeholder is the value.

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

:::moniker range=">= aspnetcore-8.0"

Place the call to `app.MapBlazorHub` after the call to `app.MapRazorComponents` in the app's `Program` file:

```csharp
app.MapBlazorHub(options =>
{
    options.{OPTION} = {VALUE};
});
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

Supply the options to `app.MapBlazorHub` in the app's `Program` file:

```csharp
app.MapBlazorHub(options =>
{
    options.{OPTION} = {VALUE};
});
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

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

Customize the delay before the reconnection UI appears by setting the `transition-delay` property in the site's CSS for the modal element. The following example sets the transition delay from 500 ms (default) to 1,000 ms (1 second).

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

For example, you can use a circuit activity handler to detect if the client is idle and log its circuit ID (<xref:Microsoft.AspNetCore.Components.Server.Circuits.Circuit.Id?displayProperty=nameWithType>):

```csharp
using Microsoft.AspNetCore.Components.Server.Circuits;
using Microsoft.Extensions.Options;
using Timer = System.Timers.Timer;

public sealed class IdleCircuitHandler : CircuitHandler, IDisposable
{
    private Circuit? currentCircuit;
    private readonly ILogger logger;
    private readonly Timer timer;

    public IdleCircuitHandler(ILogger<IdleCircuitHandler> logger, 
        IOptions<IdleCircuitOptions> options)
    {
        timer = new Timer
        {
            Interval = options.Value.IdleTimeout.TotalMilliseconds,
            AutoReset = false
        };

        timer.Elapsed += CircuitIdle;
        this.logger = logger;
    }

    private void CircuitIdle(object? sender, System.Timers.ElapsedEventArgs e)
    {
        logger.LogInformation("{CircuitId} is idle", currentCircuit?.Id);
    }

    public override Task OnCircuitOpenedAsync(Circuit circuit, 
        CancellationToken cancellationToken)
    {
        currentCircuit = circuit;

        return Task.CompletedTask;
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

    public void Dispose() => timer.Dispose();
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

Register the service in the `Program` file. The following example configures the default idle timeout of five minutes to five seconds in order to test the preceding `IdleCircuitHandler` implementation:

```csharp
builder.Services.AddIdleCircuitHandler(options => 
    options.IdleTimeout = TimeSpan.FromSeconds(5));
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

The following example for the `Pages/_Host.cshtml` file (Blazor Server, all versions except ASP.NET Core in .NET 6) or `Pages/_Layout.cshtml` file (Blazor Server, ASP.NET Core in .NET 6).

Blazor Server:

```html
<script src="{BLAZOR SCRIPT}" autostart="false"></script>
<script>
  Blazor.start({
    configureSignalR: function (builder) {
      builder.withServerTimeout(30000).withKeepAliveInterval(15000);
    }
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

The following example for the `Pages/_Host.cshtml` file (Blazor Server, all versions except ASP.NET Core in .NET 6) or `Pages/_Layout.cshtml` file (Blazor Server, ASP.NET Core in .NET 6):

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

When changing the values of the server timeout (<xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.ServerTimeout>) or the Keep-Alive interval (<xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.KeepAliveInterval>):

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

:::moniker range=">= aspnetcore-9.0"

When the user navigates back to an app with a disconnected circuit, reconnection is attempted immediately rather than waiting for the duration of the next reconnect interval. This behavior seeks to resume the connection as quickly as possible for the user.

The default reconnect timing uses a computed backoff strategy. The first several reconnection attempts occur in rapid succession before computed delays are introduced between attempts. The default logic for computing the retry interval is an implementation detail subject to change without notice, but you can find the default logic that the Blazor framework uses [in the `computeDefaultRetryInterval` function (reference source)](https://github.com/search?q=repo%3Adotnet%2Faspnetcore%20computeDefaultRetryInterval&type=code).

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

Customize the retry interval behavior by specifying a function to compute the retry interval. In the following exponential backoff example, the number of previous reconnection attempts is multiplied by 1,000 ms to calculate the retry interval. When the count of previous attempts to reconnect (`previousAttempts`) is greater than the maximum retry limit (`maxRetries`), `null` is assigned to the retry interval (`retryIntervalMilliseconds`) to cease further reconnection attempts:

```javascript
Blazor.start({
  circuit: {
    reconnectionOptions: {
      retryIntervalMilliseconds: (previousAttempts, maxRetries) => 
        previousAttempts >= maxRetries ? null : previousAttempts * 1000
    },
  },
});
```

An alternative is to specify the exact sequence of retry intervals. After the last specified retry interval, retries stop because the `retryIntervalMilliseconds` function returns `undefined`:

```javascript
Blazor.start({
  circuit: {
    reconnectionOptions: {
      retryIntervalMilliseconds: 
        Array.prototype.at.bind([0, 1000, 2000, 5000, 10000, 15000, 30000]),
    },
  },
});
```

:::moniker-end

For more information on Blazor startup, see <xref:blazor/fundamentals/startup>.

:::moniker range=">= aspnetcore-6.0"

## Control when the reconnection UI appears

Controlling when the reconnection UI appears can be useful in the following situations:

* A deployed app frequently displays the reconnection UI due to ping timeouts caused by internal network or Internet latency, and you would like to increase the delay.
* An app should report to users that the connection has dropped sooner, and you would like to shorten the delay.

The timing of the appearance of the reconnection UI is influenced by adjusting the Keep-Alive interval and timeouts on the client. The reconnection UI appears when the server timeout is reached on the client (`withServerTimeout`, [Client configuration](#client-configuration) section). However, changing the value of `withServerTimeout` requires changes to other Keep-Alive, timeout, and handshake settings described in the following guidance.

As general recommendations for the guidance that follows:

* The Keep-Alive interval should match between client and server configurations.
* Timeouts should be at least double the value assigned to the Keep-Alive interval.

### Server configuration

Set the following:

* <xref:Microsoft.AspNetCore.SignalR.HubOptions.ClientTimeoutInterval> (default: 30 seconds): The time window clients have to send a message before the server closes the connection.
* <xref:Microsoft.AspNetCore.SignalR.HubOptions.HandshakeTimeout> (default: 15 seconds): The interval used by the server to timeout incoming handshake requests by clients.
* <xref:Microsoft.AspNetCore.SignalR.HubOptions.KeepAliveInterval> (default: 15 seconds): The interval used by the server to send keep alive pings to connected clients. Note that there is also a Keep-Alive interval setting on the client, which should match the server's value.

The <xref:Microsoft.AspNetCore.SignalR.HubOptions.ClientTimeoutInterval> and <xref:Microsoft.AspNetCore.SignalR.HubOptions.HandshakeTimeout> can be increased, and the <xref:Microsoft.AspNetCore.SignalR.HubOptions.KeepAliveInterval> can remain the same. The important consideration is that if you change the values, make sure that the timeouts are at least double the value of the Keep-Alive interval and that the Keep-Alive interval matches between server and client. For more information, see the [Configure SignalR timeouts and Keep-Alive on the client](#configure-signalr-timeouts-and-keep-alive-on-the-client) section.

In the following example:

* The <xref:Microsoft.AspNetCore.SignalR.HubOptions.ClientTimeoutInterval> is increased to 60 seconds (default value: 30 seconds).
* The <xref:Microsoft.AspNetCore.SignalR.HubOptions.HandshakeTimeout> is increased to 30 seconds (default value: 15 seconds).
* The <xref:Microsoft.AspNetCore.SignalR.HubOptions.KeepAliveInterval> isn't set in developer code and uses its default value of 15 seconds. Decreasing the value of the Keep-Alive interval increases the frequency of communication pings, which increases the load on the app, server, and network. Care must be taken to avoid introducing poor performance when lowering the Keep-Alive interval.

**Blazor Web App** (.NET 8 or later) in the server project's `Program` file:

```csharp
builder.Services.AddRazorComponents().AddInteractiveServerComponents()
    .AddHubOptions(options =>
{
    options.ClientTimeoutInterval = TimeSpan.FromSeconds(60);
    options.HandshakeTimeout = TimeSpan.FromSeconds(30);
});
```

**Blazor Server** in the `Program` file:

```csharp
builder.Services.AddServerSideBlazor()
    .AddHubOptions(options =>
    {
        options.ClientTimeoutInterval = TimeSpan.FromSeconds(60);
        options.HandshakeTimeout = TimeSpan.FromSeconds(30);
    });
```

For more information, see the [Server-side circuit handler options](#server-side-circuit-handler-options) section.

### Client configuration

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

Set the following:

* `withServerTimeout` (default: 30 seconds): Configures the server timeout, specified in milliseconds, for the circuit's hub connection.
* `withKeepAliveInterval` (default: 15 seconds): The interval, specified in milliseconds, at which the connection sends Keep-Alive messages.

The server timeout can be increased, and the Keep-Alive interval can remain the same. The important consideration is that if you change the values, make sure that the server timeout is at least double the value of the Keep-Alive interval and that the Keep-Alive interval values match between server and client. For more information, see the [Configure SignalR timeouts and Keep-Alive on the client](#configure-signalr-timeouts-and-keep-alive-on-the-client) section.

In the following [startup configuration](xref:blazor/fundamentals/startup) example ([location of the Blazor script](xref:blazor/project-structure#location-of-the-blazor-script)), a custom value of 60 seconds is used for the server timeout. The Keep-Alive interval (`withKeepAliveInterval`) isn't set and uses its default value of 15 seconds.

Blazor Web App:

```html
<script src="{BLAZOR SCRIPT}" autostart="false"></script>
<script>
  Blazor.start({
    circuit: {
      configureSignalR: function (builder) {
        builder.withServerTimeout(60000);
      }
    }
  });
</script>
```

Blazor Server:

```html
<script src="{BLAZOR SCRIPT}" autostart="false"></script>
<script>
  Blazor.start({
    configureSignalR: function (builder) {
      builder.withServerTimeout(60000);
    }
  });
</script>
```

When creating a hub connection in a component, set the server timeout (<xref:Microsoft.AspNetCore.SignalR.Client.HubConnectionBuilderExtensions.WithServerTimeout%2A>, default: 30 seconds) on the <xref:Microsoft.AspNetCore.SignalR.Client.HubConnectionBuilder>. Set the <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.HandshakeTimeout> (default: 15 seconds) on the built <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection>. Confirm that the timeouts are at least double the Keep-Alive interval (<xref:Microsoft.AspNetCore.SignalR.Client.HubConnectionBuilderExtensions.WithKeepAliveInterval%2A>/<xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.KeepAliveInterval>) and that the Keep-Alive value matches between server and client.

The following example is based on the `Index` component in the [SignalR with Blazor tutorial](xref:blazor/tutorials/signalr-blazor). The server timeout is increased to 60 seconds, and the handshake timeout is increased to 30 seconds. The Keep-Alive interval isn't set and uses its default value of 15 seconds.

```csharp
protected override async Task OnInitializedAsync()
{
    hubConnection = new HubConnectionBuilder()
        .WithUrl(Navigation.ToAbsoluteUri("/chathub"))
        .WithServerTimeout(TimeSpan.FromSeconds(60))
        .Build();

    hubConnection.HandshakeTimeout = TimeSpan.FromSeconds(30);

    hubConnection.On<string, string>("ReceiveMessage", (user, message) => ...

    await hubConnection.StartAsync();
}
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

Set the following:

* `serverTimeoutInMilliseconds` (default: 30 seconds): Configures the server timeout, specified in milliseconds, for the circuit's hub connection.
* `keepAliveIntervalInMilliseconds` (default: 15 seconds): The interval, specified in milliseconds, at which the connection sends Keep-Alive messages.

The server timeout can be increased, and the Keep-Alive interval can remain the same. The important consideration is that if you change the values, make sure that the server timeout is at least double the value of the Keep-Alive interval and that the Keep-Alive interval values match between server and client. For more information, see the [Configure SignalR timeouts and Keep-Alive on the client](#configure-signalr-timeouts-and-keep-alive-on-the-client) section.

In the following [startup configuration](xref:blazor/fundamentals/startup) example ([location of the Blazor script](xref:blazor/project-structure#location-of-the-blazor-script)), a custom value of 60 seconds is used for the server timeout. The Keep-Alive interval (`keepAliveIntervalInMilliseconds`) isn't set and uses its default value of 15 seconds.

In `Pages/_Host.cshtml`:

```html
<script src="_framework/blazor.server.js" autostart="false"></script>
<script>
  Blazor.start({
    configureSignalR: function (builder) {
      let c = builder.build();
      c.serverTimeoutInMilliseconds = 60000;
      builder.build = () => {
        return c;
      };
    }
  });
</script>
```

When creating a hub connection in a component, set the <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.ServerTimeout> (default: 30 seconds) and <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.HandshakeTimeout> (default: 15 seconds) on the built <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection>. Confirm that the timeouts are at least double the Keep-Alive interval. Confirm that the Keep-Alive interval matches between server and client.

The following example is based on the `Index` component in the [SignalR with Blazor tutorial](xref:blazor/tutorials/signalr-blazor). The <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.ServerTimeout> is increased to 60 seconds, and the <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.HandshakeTimeout> is increased to 30 seconds. The Keep-Alive interval (<xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.KeepAliveInterval>) isn't set and uses its default value of 15 seconds.

```csharp
protected override async Task OnInitializedAsync()
{
    hubConnection = new HubConnectionBuilder()
        .WithUrl(Navigation.ToAbsoluteUri("/chathub"))
        .Build();

    hubConnection.ServerTimeout = TimeSpan.FromSeconds(60);
    hubConnection.HandshakeTimeout = TimeSpan.FromSeconds(30);

    hubConnection.On<string, string>("ReceiveMessage", (user, message) => ...

    await hubConnection.StartAsync();
}
```

:::moniker-end

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
* [Blazor samples GitHub repository (`dotnet/blazor-samples`)](https://github.com/dotnet/blazor-samples) ([how to download](xref:blazor/fundamentals/index#sample-apps))
