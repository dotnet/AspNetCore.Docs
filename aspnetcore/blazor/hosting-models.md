---
title: ASP.NET Core Blazor hosting models
author: guardrex
description: Understand Blazor WebAssembly and Blazor Server hosting models.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/09/2021
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/hosting-models
---
# ASP.NET Core Blazor hosting models

Blazor is a web framework designed to run server-side in ASP.NET Core (*Blazor Server*) or client-side in the browser on a [WebAssembly](https://webassembly.org/)-based .NET runtime (*Blazor WebAssembly*). Regardless of the hosting model, the app and component models *are the same*.

## Blazor Server

With the Blazor Server hosting model, the app is executed on the server from within an ASP.NET Core app. UI updates, event handling, and JavaScript calls are handled over a [SignalR](xref:signalr/introduction) connection. The state on the server associated with each connected client is called a *circuit*. A circuit can tolerate temporary network interruptions and attempts by the client to reconnect to the server when the connection is lost.

In a traditional server-rendered app, opening the same app in multiple browser screens (tabs or iframes) typically doesn't translate into additional resource demands on the server. In a Blazor Server app, each browser screen requires a separate circuit and separate instances of server-managed component state. Blazor considers closing a browser tab or navigating to an external URL a *graceful* termination. In the event of a graceful termination, the circuit and associated resources are immediately released. A client may also disconnect non-gracefully, for instance due to a network interruption. Blazor Server stores disconnected circuits for a configurable interval to allow the client to reconnect.

![The browser interacts with the app (hosted inside of an ASP.NET Core app) on the server over a SignalR connection.](~/blazor/hosting-models/_static/blazor-server.png)

On the client, the Blazor script (`blazor.server.js`) establishes the SignalR connection with the server. The script is served to the client-side app from an embedded resource in the ASP.NET Core shared framework. The client-side app is responsible for persisting and restoring app state as required. 

The Blazor Server hosting model offers several benefits:

* Download size is significantly smaller than a Blazor WebAssembly app, and the app loads much faster.
* The app takes full advantage of server capabilities, including the use of .NET Core APIs.
* .NET Core on the server is used to run the app, so existing .NET tooling, such as debugging, works as expected.
* Thin clients are supported. For example, Blazor Server apps work with browsers that don't support WebAssembly and on resource-constrained devices.
* The app's .NET/C# code base, including the app's component code, isn't served to clients.

The Blazor Server hosting model has the following limitations:

* Higher latency usually exists. Every user interaction involves a network hop.
* There's no offline support. If the client connection fails, the app stops working.
* Scaling apps with many users requires server resources to handle multiple client connections and client state.
* An ASP.NET Core server is required to serve the app. Serverless deployment scenarios aren't possible, such as serving the app from a Content Delivery Network (CDN).

We recommend using the [Azure SignalR Service](/azure/azure-signalr) for Blazor Server apps. The service allows for scaling up a Blazor Server app to a large number of concurrent SignalR connections.

## Blazor WebAssembly

Blazor WebAssembly apps run client-side in the browser on a WebAssembly-based .NET runtime. The Blazor app, its dependencies, and the .NET runtime are downloaded to the browser. The app is executed directly on the browser UI thread. UI updates and event handling occur within the same process. The app's assets are deployed as static files to a web server or service capable of serving static content to clients.

![Blazor WebAssembly: The Blazor app runs on a UI thread inside the browser.](~/blazor/hosting-models/_static/blazor-webassembly.png)

When the Blazor WebAssembly app is created for deployment without a backend ASP.NET Core app to serve its files, the app is called a *standalone* Blazor WebAssembly app. When the app is created for deployment with a backend app to serve its files, the app is called a *hosted* Blazor WebAssembly app.

Using hosted Blazor WebAssembly, you get a full-stack web development experience with .NET, including the ability to share code between the client and server apps, support for prerendering, and integration with MVC and Razor Pages. A hosted client app can interact with its backend server app over the network using a variety of messaging frameworks and protocols, such as [web API](xref:web-api/index), [gRPC-web](xref:grpc/index), and [SignalR](xref:signalr/introduction) (<xref:tutorials/signalr-blazor>).

The `blazor.webassembly.js` script is provided by the framework and handles:

* Downloading the .NET runtime, the app, and the app's dependencies.
* Initialization of the runtime to run the app.

The Blazor WebAssembly hosting model offers several benefits:

* There's no .NET server-side dependency after the app is downloaded from the server, so the app remains functional if the client goes offline.
* Client resources and capabilities are fully leveraged.
* Work is offloaded from the server to the client.
* An ASP.NET Core web server isn't required to host the app. Serverless deployment scenarios are possible, such as serving the app from a Content Delivery Network (CDN).

The Blazor WebAssembly hosting model has the following limitations:

* The app is restricted to the capabilities of the browser.
* Capable client hardware and software (for example, WebAssembly support) is required.
* Download size is larger, and apps take longer to load.

::: moniker range=">= aspnetcore-6.0"

Blazor WebAssembly supports [ahead-of-time (AOT) compilation](/dotnet/standard/glossary#aot), where you can compile your .NET code directly into WebAssembly. AOT compilation results in runtime performance improvements at the expense of a larger app size. For more information, see <xref:blazor/host-and-deploy/webassembly#ahead-of-time-aot-compilation>. 

The same .NET WebAssembly build tools used for AOT compilation also [relink the .NET WebAssembly runtime](xref:blazor/host-and-deploy/webassembly#runtime-relinking) to trim unused runtime code resulting in a smaller app size and thus improved download speed. 

Blazor WebAssembly includes support for trimming unused code from .NET Core framework libraries. For more information, see <xref:blazor/globalization-localization>. The .NET compiler further precompresses a Blazor WebAssembly app for a smaller app payload.

Blazor WebAssembly apps can use [native dependencies](xref:blazor/webassembly-native-dependencies) built to run on WebAssembly.

::: moniker-end

::: moniker range="< aspnetcore-6.0"

Blazor WebAssembly includes support for trimming unused code from .NET Core framework libraries. For more information, see <xref:blazor/globalization-localization>.

::: moniker-end

## Hosting model selection

Choice of the Blazor hosting model is an early consideration for Blazor app development. The following table shows the primary considerations for selecting the hosting model.

| &nbsp; | Blazor Server | Blazor WebAssembly |
| --- | :---: | :---: |
| Complete .NET Core API compatibility           | ✔️ | ❌ |
| Direct access to server sources                | ✔️ | ❌ |
| Small payload size with fast initial load time | ✔️ | ❌ |
| App code secure and private on the server      | ✔️ | ❌&dagger; |
| Run apps offline once downloaded               | ❌ | ✔️ |
| Static site hosting                            | ❌ | ✔️ |
| Offloads processing to clients                 | ❌ | ✔️ |

&dagger;Blazor WebAssembly apps can use server-hosted APIs to access functionality that must be kept private and secure.

## Additional resources

* <xref:blazor/tooling>
* <xref:blazor/project-structure>
* <xref:signalr/introduction>
* <xref:blazor/fundamentals/signalr>
* <xref:tutorials/signalr-blazor>
