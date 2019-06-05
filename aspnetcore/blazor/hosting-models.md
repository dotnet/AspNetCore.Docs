---
title: Blazor hosting models
author: guardrex
description: Understand client-side and server-side Blazor hosting models.
monikerRange: '>= aspnetcore-3.0'
ms.author: riande
ms.custom: mvc
ms.date: 05/28/2019
uid: blazor/hosting-models
---
# Blazor hosting models

By [Daniel Roth](https://github.com/danroth27)

Blazor is a web framework designed to run client-side in the browser on a [WebAssembly](http://webassembly.org/)-based .NET runtime (*Blazor client-side*) or server-side in ASP.NET Core (*Blazor server-side*). Regardless of the hosting model, the app and component models *are the same*.

To create a project for the hosting models described in this article, see <xref:blazor/get-started>.

## Client-side

The principal hosting model for Blazor is running client-side in the browser on WebAssembly. The Blazor app, its dependencies, and the .NET runtime are downloaded to the browser. The app is executed directly on the browser UI thread. UI updates and event handling occur within the same process. The app's assets are deployed as static files to a web server or service capable of serving static content to clients.

![Blazor client-side: The Blazor app runs on a UI thread inside the browser.](hosting-models/_static/client-side.png)

To create a Blazor app using the client-side hosting model, use either of the following templates:

* **Blazor (client-side)** ([dotnet new blazor](/dotnet/core/tools/dotnet-new)) &ndash; Deployed as a set of static files.
* **Blazor (ASP.NET Core Hosted)** ([dotnet new blazorhosted](/dotnet/core/tools/dotnet-new)) &ndash; Hosted by an ASP.NET Core server. The ASP.NET Core app serves the Blazor app to clients. The client-side Blazor app can interact with the server over the network using web API calls or [SignalR](xref:signalr/introduction).

The templates include the *blazor.webassembly.js* script that handles:

* Downloading the .NET runtime, the app, and the app's dependencies.
* Initialization of the runtime to run the app.

The client-side hosting model offers several benefits. Client-side Blazor:

* Has no .NET server-side dependency.
* Fully leverages client resources and capabilities.
* Offloads work from the server to the client.
* Supports offline scenarios.

There are downsides to client-side hosting. Client-side Blazor:

* Restricts the app to the capabilities of the browser.
* Requires capable client hardware and software (for example, WebAssembly support).
* Has a larger download size and longer app load time.
* Has less mature .NET runtime and tooling support (for example, limitations in [.NET Standard](/dotnet/standard/net-standard) support and debugging).

## Server-side

With the server-side hosting model, the app is executed on the server from within an ASP.NET Core app. UI updates, event handling, and JavaScript calls are handled over a [SignalR](xref:signalr/introduction) connection.

![The browser interacts with the app (hosted inside of an ASP.NET Core app) on the server over a SignalR connection.](hosting-models/_static/server-side.png)

To create a Blazor app using the server-side hosting model, use the ASP.NET Core **Blazor (server-side)** template ([dotnet new blazorserverside](/dotnet/core/tools/dotnet-new)). The ASP.NET Core app hosts the server-side app and sets up the SignalR endpoint where clients connect.

The ASP.NET Core app references the app's `Startup` class to add:

* Server-side services.
* The app to the request handling pipeline.

The *blazor.server.js* script&dagger; establishes the client connection. It's the app's responsibility to persist and restore app state as required (for example, in the event of a lost network connection).

The server-side hosting model offers several benefits:

* Has a significantly smaller app size than a client-side app and loads much faster.
* Takes full advantage of server capabilities, including using any .NET Core compatible APIs.
* Runs on .NET Core on the server, so existing .NET tooling, such as debugging, works as expected.
* Works with thin clients. For example, works with browsers that don't support WebAssembly and resource constrained devices.
* The .NET/C# code base, including the app's component code, isn't served to clients.

There are downsides to server-side hosting:

* Higher latency: Every user interaction involves a network hop.
* No offline support: If the client connection fails, the app stops working.
* Reduced scalability: The server must manage multiple client connections and handle client state.
* An ASP.NET Core server is required to serve the app. Deployment without a server (for example, from a CDN) isn't possible.

&dagger;The *blazor.server.js* script is served from an embedded resource in the ASP.NET Core shared framework.

### Reconnection to the same server

Blazor server-side apps require an active SignalR connection to the server. If a connection is lost, the app attempts to reconnect to the server. As long as the client's state is still in memory, the client session resumes without losing state.
 
When the client detects that the connection has been lost, a default UI is displayed to the user while the client attempts to reconnect. If reconnection fails, the user is provided the option to retry. To customize the UI, define an element with `components-reconnect-modal` as its `id`. The client updates this element with one of the following CSS classes based on the state of the connection:
 
* `components-reconnect-show` &ndash; Show the UI to indicate the connection was lost and the client is attempting to reconnect.
* `components-reconnect-hide` &ndash; The client has an active connection, hide the UI.
* `components-reconnect-failed` &ndash; Reconnection failed. To attempt reconnection again, call `window.Blazor.reconnect()`.

### Stateful reconnection after prerendering
 
Blazor server-side apps are set up by default to prerender the UI on the server before the client connection to the server is established. This is set up in the *_Host.cshtml* Razor page:
 
```cshtml
<body>
    <app>@(await Html.RenderComponentAsync<App>())</app>
 
    <script src="_framework/blazor.server.js"></script>
</body>
```
 
The client reconnects to the server with the same state that was used to prerender the app. If the app's state is still in memory, the component state isn't rerendered after the SignalR connection is established.

### Render stateful interactive components from Razor pages and views
 
Stateful interactive components can be added to a Razor page or view. When the page or view renders, the component is prerendered with it. The app then reconnects to the component state once the client connection is established as long as the state is still in memory.
 
For example, the following Razor page renders a Counter component with an initial count that's specified using a form:
 
```cshtml
<h1>My Razor Page</h1>

<form>
    <input type="number" asp-for="InitialCount" />
    <button type="submit">Set initial count</button>
</form>
 
@(await Html.RenderComponentAsync<Counter>(new { InitialCount = InitialCount }))
 
@functions {
    [BindProperty(SupportsGet=true)]
    public int InitialCount { get; set; }
}
```

### Detect when the app is prerendering
 
[!INCLUDE[](~/includes/blazor-prerendering.md)]

### Configure the SignalR client for Blazor server-side apps
 
Sometimes, you need to configure the SignalR client used by Blazor server-side apps. For example, you might want to configure logging on the SignalR client to diagnose a connection issue.
 
To configure the SignalR client in the *Pages/\_Host.cshtml* file:

* Add an `autostart="false"` attribute to the `<script>` tag for the *blazor.server.js* script.
* Call `Blazor.start` and pass in a configuration object that specifies the SignalR builder.
 
```html
<script src="_framework/blazor.server.js" autostart="false"></script>
<script>
  Blazor.start({
    configureSignalR: function (builder) {
      builder.configureLogging(2); // LogLevel.Information
    }
  });
</script>
```

### Disconnect and reconnect handling

Before starting any reconnect attempts, the `HubConnection` transitions to the `Reconnecting` state and fires its `onreconnecting` callback. This provides an opportunity to warn users that the connection was lost, disable UI elements, and mitigate confusing user scenarios that might occur due to the disconnected state:

```javascript
connection.onreconnecting((error) => {
  console.assert(connection.state === signalR.HubConnectionState.Reconnecting);

  document.getElementById("messageInput").disabled = true;

  const li = document.createElement("li");
  li.textContent = `Connection lost due to error "${error}". Reconnecting.`;
  document.getElementById("messagesList").appendChild(li);
});
```

If the client successfully reconnects within its first four attempts, the `HubConnection` transitions back to the `Connected` state and fires `onreconnected` callback. This provides an opportunity to inform users that the connection is re-established:

```javascript
connection.onreconnected((connectionId) => {
  console.assert(connection.state === signalR.HubConnectionState.Connected);

  document.getElementById("messageInput").disabled = false;

  const li = document.createElement("li");
  li.textContent = `Connection reestablished. Connected with connectionId "${connectionId}".`;
  document.getElementById("messagesList").appendChild(li);
});
```

If the client doesn't successfully reconnect within its first four attempts, the `HubConnection` transitions to the `Disconnected` state and fires its `onclosed` callback. This is an opportunity to inform users that the connection is permanently lost and to recommend refreshing the page.

```javascript
connection.onclose((error) => {
  console.assert(connection.state === signalR.HubConnectionState.Disconnected);

  document.getElementById("messageInput").disabled = true;

  const li = document.createElement("li");
  li.textContent = `Connection closed due to error "${error}". Try refreshing this page to restart the connection.`;
  document.getElementById("messagesList").appendChild(li);
})
```

## Additional resources

* <xref:blazor/get-started>
* <xref:signalr/introduction>
