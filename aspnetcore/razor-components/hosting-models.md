---
title: Razor Components hosting models
author: guardrex
description: Understand client-side Blazor and server-side ASP.NET Core Razor Components hosting models.
monikerRange: '>= aspnetcore-3.0'
ms.author: riande
ms.custom: mvc
ms.date: 03/28/2019
uid: razor-components/hosting-models
---
# Razor Components hosting models

By [Daniel Roth](https://github.com/danroth27)

Razor Components is a web framework designed to run client-side in the browser on a [WebAssembly](http://webassembly.org/)-based .NET runtime (*Blazor*) or server-side in ASP.NET Core (*ASP.NET Core Razor Components*). Regardless of the hosting model, the app and component models *remain the same*. This article discusses the available hosting models:

* [Client-side Blazor](#client-side-hosting-model)
* [Server-side ASP.NET Core Razor Components](#server-side-hosting-model)

## Client-side hosting model

[!INCLUDE[](~/includes/razor-components-preview-notice.md)]

The principal hosting model for Blazor is running client-side in the browser on WebAssembly. The Blazor app, its dependencies, and the .NET runtime are downloaded to the browser. The app is executed directly on the browser UI thread. UI updates and event handling occur within the same process. The app's assets are deployed as static files to a web server or service capable of serving static content to clients.

![Blazor client-side: The Blazor app runs on a UI thread inside the browser.](hosting-models/_static/client-side.png)

To create a Blazor app using the client-side hosting model, use either of the following templates:

* **Blazor** ([dotnet new blazor](/dotnet/core/tools/dotnet-new)) &ndash; Deployed as a set of static files.
* **Blazor (ASP.NET Core Hosted)** ([dotnet new blazorhosted](/dotnet/core/tools/dotnet-new)) &ndash; Hosted by an ASP.NET Core server. The ASP.NET Core app serves the Blazor app to clients. The client-side Blazor app can interact with the server over the network using web API calls or [SignalR](xref:signalr/introduction).

The templates include the *components.webassembly.js* script that handles:

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

## Server-side hosting model

With the ASP.NET Core Razor Components server-side hosting model, the app is executed on the server from within an ASP.NET Core app. UI updates, event handling, and JavaScript calls are handled over a [SignalR](xref:signalr/introduction) connection.

![ASP.NET Core Razor Components server-side: The browser interacts with the app (hosted inside of an ASP.NET Core app) on the server over a SignalR connection.](hosting-models/_static/server-side.png)

To create a Razor Components app using the server-side hosting model, use the ASP.NET Core **Razor Components** template ([dotnet new razorcomponents](/dotnet/core/tools/dotnet-new)). The ASP.NET Core app hosts the Razor Components server-side app and sets up the SignalR endpoint where clients connect. The ASP.NET Core app references the app's `Startup` class to add:

* Server-side Razor Components services.
* The app to the request handling pipeline.

[!code-csharp[](hosting-models/samples_snapshot/Startup.cs?highlight=5,27)]

The *components.server.js* script&dagger; establishes the client connection. It's the app's responsibility to persist and restore app state as required (for example, in the event of a lost network connection).

The server-side hosting model offers several benefits. Server-side Razor Components:

* Have a significantly smaller app size than a client-side Blazor app and load much faster.
* Can take full advantage of server capabilities, including using any .NET Core compatible APIs.
* Run on .NET Core on the server, so existing .NET tooling, such as debugging, works as expected.
* Works with thin clients (for example, browsers that don't support WebAssembly and resource constrained devices).
* .NET/C# code base, including the app's component code, isn't served to clients.

There are downsides to server-side hosting. Server-side Razor Components:

* Have higher latency: Every user interaction involves a network hop.
* Offer no offline support: If the client connection fails, the app stops working.
* Have reduced scalability: The server must manage multiple client connections and handle client state.
* Require an ASP.NET Core server to serve the app. Deployment without a server (for example, from a CDN) isn't possible.

&dagger;The *components.server.js* script is published to the following path: *bin/{Debug|Release}/{TARGET FRAMEWORK}/publish/{APPLICATION NAME}.App/dist/_framework*.
