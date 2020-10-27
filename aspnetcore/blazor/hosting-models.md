---
title: ASP.NET Core Blazor hosting models
author: guardrex
description: Understand Blazor WebAssembly and Blazor Server hosting models.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 08/11/2020
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/hosting-models
---
# ASP.NET Core Blazor hosting models

By [Daniel Roth](https://github.com/danroth27)

Blazor is a web framework designed to run client-side in the browser on a [WebAssembly](https://webassembly.org/)-based .NET runtime (*Blazor WebAssembly*) or server-side in ASP.NET Core (*Blazor Server*). Regardless of the hosting model, the app and component models *are the same*.

## Blazor WebAssembly

The principal hosting model for Blazor is running client-side in the browser on WebAssembly. The Blazor app, its dependencies, and the .NET runtime are downloaded to the browser. The app is executed directly on the browser UI thread. UI updates and event handling occur within the same process. The app's assets are deployed as static files to a web server or service capable of serving static content to clients. Because the app is created for deployment without a backend ASP.NET Core app, it's called a *standalone Blazor WebAssembly app*.

![Blazor WebAssembly: The Blazor app runs on a UI thread inside the browser.](hosting-models/_static/blazor-webassembly.png)

To create a Blazor app using the client-side hosting model, use the **Blazor WebAssembly App** template ([`dotnet new blazorwasm`](/dotnet/core/tools/dotnet-new)).

After selecting the **Blazor WebAssembly App** template, you have the option of configuring the app to use an ASP.NET Core backend by selecting the **ASP.NET Core hosted** check box ([`dotnet new blazorwasm --hosted`](/dotnet/core/tools/dotnet-new)). The ASP.NET Core app serves the Blazor app to clients. An app with an ASP.NET Core backend is called a *hosted Blazor WebAssembly app*. The Blazor WebAssembly app can interact with the server over the network using web API calls or [SignalR](xref:signalr/introduction) (<xref:tutorials/signalr-blazor-webassembly>).

The `blazor.webassembly.js` script is provided by the framework and handles:

* Downloading the .NET runtime, the app, and the app's dependencies.
* Initialization of the runtime to run the app.

The Blazor WebAssembly hosting model offers several benefits:

* There's no .NET server-side dependency. The app is fully functioning after it's downloaded to the client.
* Client resources and capabilities are fully leveraged.
* Work is offloaded from the server to the client.
* An ASP.NET Core web server isn't required to host the app. Serverless deployment scenarios are possible (for example, serving the app from a CDN).

There are downsides to Blazor WebAssembly hosting:

* The app is restricted to the capabilities of the browser.
* Capable client hardware and software (for example, WebAssembly support) is required.
* Download size is larger, and apps take longer to load.
* .NET runtime and tooling support is less mature. For example, limitations exist in [.NET Standard](/dotnet/standard/net-standard) support and debugging.

The hosted Blazor app model supports [Docker containers](/dotnet/standard/microservices-architecture/container-docker-introduction/index). Right-click on the Server project in Visual Studio and select **Add** > **Docker Support**.

## Blazor Server

With the Blazor Server hosting model, the app is executed on the server from within an ASP.NET Core app. UI updates, event handling, and JavaScript calls are handled over a [SignalR](xref:signalr/introduction) connection.

![The browser interacts with the app (hosted inside of an ASP.NET Core app) on the server over a SignalR connection.](hosting-models/_static/blazor-server.png)

To create a Blazor app using the Blazor Server hosting model, use the ASP.NET Core **Blazor Server App** template ([`dotnet new blazorserver`](/dotnet/core/tools/dotnet-new)). The ASP.NET Core app hosts the Blazor Server app and creates the SignalR endpoint where clients connect.

The ASP.NET Core app references the app's `Startup` class to add:

* Server-side services.
* The app to the request handling pipeline.

On the client, the `blazor.server.js` script establishes the SignalR connection with the server. The script is served to the client-side app from an embedded resource in the ASP.NET Core shared framework. The client-side app is responsible for persisting and restoring app state as required. 

The Blazor Server hosting model offers several benefits:

* Download size is significantly smaller than a Blazor WebAssembly app, and the app loads much faster.
* The app takes full advantage of server capabilities, including use of any .NET Core compatible APIs.
* .NET Core on the server is used to run the app, so existing .NET tooling, such as debugging, works as expected.
* Thin clients are supported. For example, Blazor Server apps work with browsers that don't support WebAssembly and on resource-constrained devices.
* The app's .NET/C# code base, including the app's component code, isn't served to clients.

> [!IMPORTANT]
> A Blazor Server app prerenders in response to the first client request, which sets up the UI state on the server. When the client attempts to create a SignalR connection, **the client must reconnect to the same server**. Blazor Server apps that use more than one backend server should implement *sticky sessions* for SignalR connections. For more information, see the [Connection to the server](#connection-to-the-server) section.

There are downsides to Blazor Server hosting:

* Higher latency usually exists. Every user interaction involves a network hop.
* There's no offline support. If the client connection fails, the app stops working.
* Scalability is challenging for apps with many users. The server must manage multiple client connections and handle client state.
* An ASP.NET Core server is required to serve the app. Serverless deployment scenarios aren't possible (for example, serving the app from a CDN).

The Blazor Server app model supports [Docker containers](/dotnet/standard/microservices-architecture/container-docker-introduction/index). Right-click on the project in Visual Studio and select **Add** > **Docker Support**.

### Comparison to server-rendered UI

One way to understand Blazor Server apps is to understand how it differs from traditional models for rendering UI in ASP.NET Core apps using Razor views or Razor Pages. Both models use the Razor language to describe HTML content, but they significantly differ in how markup is rendered.

When a Razor Page or view is rendered, every line of Razor code emits HTML in text form. After rendering, the server disposes of the page or view instance, including any state that was produced. When another request for the page occurs, for instance when server validation fails and the validation summary is displayed:

* The entire page is rerendered to HTML text again.
* The page is sent to the client.

A Blazor app is composed of reusable elements of UI called *components*. A component contains C# code, markup, and other components. When a component is rendered, Blazor produces a graph of the included components similar to an HTML or XML Document Object Model (DOM). This graph includes component state held in properties and fields. Blazor evaluates the component graph to produce a binary representation of the markup. The binary format can be:

* Turned into HTML text (during prerendering&dagger;).
* Used to efficiently update the markup during regular rendering.

&dagger;*Prerendering*: The requested Razor component is compiled on the server into static HTML and sent to the client, where it's rendered to the user. After the connection is made between the client and the server, the component's static prerendered elements are replaced with interactive elements. Prerendering makes the app feel more responsive to the user.

A UI update in Blazor is triggered by:

* User interaction, such as selecting a button.
* App triggers, such as a timer.

The graph is rerendered, and a UI *diff* (difference) is calculated. This diff is the smallest set of DOM edits required to update the UI on the client. The diff is sent to the client in a binary format and applied by the browser.

A component is disposed after the user navigates away from it on the client. While a user is interacting with a component, the component's state (services, resources) must be held in the server's memory. Because the state of many components might be maintained by the server concurrently, memory exhaustion is a concern that must be addressed. For guidance on how to author a Blazor Server app to ensure the best use of server memory, see <xref:blazor/security/server/threat-mitigation>.

### Circuits

A Blazor Server app is built on top of [ASP.NET Core SignalR](xref:signalr/introduction). Each client communicates to the server over one or more SignalR connections called a *circuit*. A circuit is Blazor's abstraction over SignalR connections that can tolerate temporary network interruptions. When a Blazor client sees that the SignalR connection is disconnected, it attempts to reconnect to the server using a new SignalR connection.

Each browser screen (browser tab or iframe) that is connected to a Blazor Server app uses a SignalR connection. This is yet another important distinction compared to typical server-rendered apps. In a server-rendered app, opening the same app in multiple browser screens typically doesn't translate into additional resource demands on the server. In a Blazor Server app, each browser screen requires a separate circuit and separate instances of component state to be managed by the server.

Blazor considers closing a browser tab or navigating to an external URL a *graceful* termination. In the event of a graceful termination, the circuit and associated resources are immediately released. A client may also disconnect non-gracefully, for instance due to a network interruption. Blazor Server stores disconnected circuits for a configurable interval to allow the client to reconnect.

Blazor Server allows code to define a *circuit handler*, which allows running code on changes to the state of a user's circuit. For more information, see <xref:blazor/advanced-scenarios#blazor-server-circuit-handler>.

### UI Latency

UI latency is the time it takes from an initiated action to the time the UI is updated. Smaller values for UI latency are imperative for an app to feel responsive to a user. In a Blazor Server app, each action is sent to the server, processed, and a UI diff is sent back. Consequently, UI latency is the sum of network latency and the server latency in processing the action.

For a line of business app that's limited to a private corporate network, the effect on user perceptions of latency due to network latency are usually imperceptible. For an app deployed over the Internet, latency may become noticeable to users, particularly if users are widely distributed geographically.

Memory usage can also contribute to app latency. Increased memory usage results in frequent garbage collection or paging memory to disk, both of which degrade app performance and consequently increase UI latency.

Blazor Server apps should be optimized to minimize UI latency by reducing network latency and memory usage. For an approach to measuring network latency, see <xref:blazor/host-and-deploy/server#measure-network-latency>. For more information on SignalR and Blazor, see:

* <xref:blazor/host-and-deploy/server>
* <xref:blazor/security/server/threat-mitigation>

### Connection to the server

Blazor Server apps require an active SignalR connection to the server. If the connection is lost, the app attempts to reconnect to the server. As long as the client's state is still in memory, the client session resumes without losing state.

A Blazor Server app prerenders in response to the first client request, which sets up the UI state on the server. When the client attempts to create a SignalR connection, the client must reconnect to the same server. Blazor Server apps that use more than one backend server should implement *sticky sessions* for SignalR connections.

We recommend using the [Azure SignalR Service](/azure/azure-signalr) for Blazor Server apps. The service allows for scaling up a Blazor Server app to a large number of concurrent SignalR connections. Sticky sessions are enabled for the Azure SignalR Service by setting the service's `ServerStickyMode` option or configuration value to `Required`. For more information, see <xref:blazor/host-and-deploy/server#signalr-configuration>.

When using IIS, sticky sessions are enabled with Application Request Routing. For more information, see [HTTP Load Balancing using Application Request Routing](/iis/extensions/configuring-application-request-routing-arr/http-load-balancing-using-application-request-routing).

## Additional resources

* <xref:signalr/introduction>
* <xref:blazor/fundamentals/additional-scenarios>
* <xref:tutorials/signalr-blazor-webassembly>
