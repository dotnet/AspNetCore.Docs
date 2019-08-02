---
title: ASP.NET Core Blazor hosting models
author: guardrex
description: Understand Blazor client-side and server-side hosting models.
monikerRange: '>= aspnetcore-3.0'
ms.author: riande
ms.custom: mvc
ms.date: 07/01/2019
uid: blazor/hosting-models
---
# ASP.NET Core Blazor hosting models

By [Daniel Roth](https://github.com/danroth27)

Blazor is a web framework designed to run client-side in the browser on a [WebAssembly](https://webassembly.org/)-based .NET runtime (*Blazor client-side*) or server-side in ASP.NET Core (*Blazor server-side*). Regardless of the hosting model, the app and component models *are the same*.

To create a project for the hosting models described in this article, see <xref:blazor/get-started>.

## Client-side

The principal hosting model for Blazor is running client-side in the browser on WebAssembly. The Blazor app, its dependencies, and the .NET runtime are downloaded to the browser. The app is executed directly on the browser UI thread. UI updates and event handling occur within the same process. The app's assets are deployed as static files to a web server or service capable of serving static content to clients.

![Blazor client-side: The Blazor app runs on a UI thread inside the browser.](hosting-models/_static/client-side.png)

To create a Blazor app using the client-side hosting model, use the **Blazor WebAssembly App** template ([dotnet new blazorwasm](/dotnet/core/tools/dotnet-new)).

After selecting the **Blazor WebAssembly App** template, you have the option of configuring the app to use an ASP.NET Core backend by selecting the **ASP.NET Core hosted** check box ([dotnet new blazorwasm --hosted](/dotnet/core/tools/dotnet-new)). The ASP.NET Core app serves the Blazor app to clients. The Blazor client-side app can interact with the server over the network using web API calls or [SignalR](xref:signalr/introduction).

The templates include the *blazor.webassembly.js* script that handles:

* Downloading the .NET runtime, the app, and the app's dependencies.
* Initialization of the runtime to run the app.

The client-side hosting model offers several benefits:

* There's no .NET server-side dependency. The app is fully functioning after downloaded to the client.
* Client resources and capabilities are fully leveraged.
* Work is offloaded from the server to the client.
* An ASP.NET Core web server isn't required to host the app. Serverless deployment scenarios are possible (for example, serving the app from a CDN).

There are downsides to client-side hosting:

* The app is restricted to the capabilities of the browser.
* Capable client hardware and software (for example, WebAssembly support) is required.
* Download size is larger, and apps take longer to load.
* .NET runtime and tooling support is less mature. For example, limitations exist in [.NET Standard](/dotnet/standard/net-standard) support and debugging.

## Server-side

With the server-side hosting model, the app is executed on the server from within an ASP.NET Core app. UI updates, event handling, and JavaScript calls are handled over a [SignalR](xref:signalr/introduction) connection.

![The browser interacts with the app (hosted inside of an ASP.NET Core app) on the server over a SignalR connection.](hosting-models/_static/server-side.png)

To create a Blazor app using the server-side hosting model, use the ASP.NET Core **Blazor Server App** template ([dotnet new blazorserver](/dotnet/core/tools/dotnet-new)). The ASP.NET Core app hosts the server-side app and creates the SignalR endpoint where clients connect.

The ASP.NET Core app references the app's `Startup` class to add:

* Server-side services.
* The app to the request handling pipeline.

The *blazor.server.js* script&dagger; establishes the client connection. It's the app's responsibility to persist and restore app state as required (for example, in the event of a lost network connection).

The server-side hosting model offers several benefits:

* Download size is significantly smaller than a client-side app, and the app loads much faster.
* The app takes full advantage of server capabilities, including use of any .NET Core compatible APIs.
* .NET Core on the server is used to run the app, so existing .NET tooling, such as debugging, works as expected.
* Thin clients are supported. For example, server-side apps work with browsers that don't support WebAssembly and on resource-constrained devices.
* The app's .NET/C# code base, including the app's component code, isn't served to clients.

There are downsides to server-side hosting:

* Higher latency usually exists. Every user interaction involves a network hop.
* There's no offline support. If the client connection fails, the app stops working.
* Scalability is challenging for apps with many users. The server must manage multiple client connections and handle client state.
* An ASP.NET Core server is required to serve the app. Serverless deployment scenarios aren't possible (for example, serving the app from a CDN).

&dagger;The *blazor.server.js* script is served from an embedded resource in the ASP.NET Core shared framework.

### Reconnection to the same server

Blazor server-side apps require an active SignalR connection to the server. If the connection is lost, the app attempts to reconnect to the server. As long as the client's state is still in memory, the client session resumes without losing state.
 
When the client detects that the connection has been lost, a default UI is displayed to the user while the client attempts to reconnect. If reconnection fails, the user is provided the option to retry. To customize the UI, define an element with `components-reconnect-modal` as its `id` in the *_Host.cshtml* Razor page. The client updates this element with one of the following CSS classes based on the state of the connection:
 
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
 
For example, the following Razor page renders a `Counter` component with an initial count that's specified using a form:
 
```cshtml
<h1>My Razor Page</h1>

<form>
    <input type="number" asp-for="InitialCount" />
    <button type="submit">Set initial count</button>
</form>
 
@(await Html.RenderComponentAsync<Counter>(new { InitialCount = InitialCount }))
 
@code {
    [BindProperty(SupportsGet=true)]
    public int InitialCount { get; set; }
}
```

### Detect when the app is prerendering
 
[!INCLUDE[](~/includes/blazor-prerendering.md)]

### Configure the SignalR client for Blazor server-side apps
 
Sometimes, you need to configure the SignalR client used by Blazor server-side apps. For example, you might want to configure logging on the SignalR client to diagnose a connection issue.
 
To configure the SignalR client in the *Pages/_Host.cshtml* file:

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

## Additional resources

* <xref:blazor/get-started>
* <xref:signalr/introduction>
