---
title: ASP.NET Core Blazor hosting models
author: guardrex
description: Learn about Blazor hosting models and how to pick which one to use.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/14/2023
uid: blazor/hosting-models
---
# ASP.NET Core Blazor hosting models

[!INCLUDE[](~/includes/not-latest-version.md)]

<!-- 

NOTE: Daggered lines under the table (&dagger;, &Dagger;) use a double-space at the ends of lines to generate a bare return across rendered lines.

-->

:::moniker range=">= aspnetcore-8.0"

This article explains Blazor hosting models, primarily focused on Blazor Server and Blazor WebAssembly apps in versions of .NET earlier than .NET 8. The guidance in this article is relevant under all .NET releases for Blazor Hybrid apps that run on native mobile and desktop platforms. Blazor Web Apps in .NET 8 or later are better conceptualized by how Razor components are rendered, which is described as their *render mode*. Render modes are briefly touched on in the *Fundamentals* overview article and covered in detail in <xref:blazor/components/render-modes> of the *Components* node.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

This article explains Blazor hosting models and how to choose which one to use.

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

Blazor is a web framework for building web UI components ([Razor components](xref:blazor/components/index)) that can be hosted in different ways. Razor components can run server-side in ASP.NET Core (*Blazor Server*) versus client-side in the browser on a [WebAssembly](https://webassembly.org/)-based .NET runtime (*Blazor WebAssembly*, *Blazor WASM*). You can also host Razor components in native mobile and desktop apps that render to an embedded Web View control (*Blazor Hybrid*). Regardless of the hosting model, the way you build Razor components *is the same*. The same Razor components can be used with any of the hosting models unchanged.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Blazor is a web framework for building web UI components ([Razor components](xref:blazor/components/index)) that can be hosted in different ways. Razor components can run server-side in ASP.NET Core (*Blazor Server*) versus client-side in the browser on a [WebAssembly](https://webassembly.org/)-based .NET runtime (*Blazor WebAssembly*, *Blazor WASM*). Regardless of the hosting model, the way you build Razor components *is the same*. The same Razor components can be used with any of the hosting models unchanged.

:::moniker-end

## Blazor Server

With the Blazor Server hosting model, components are executed on the server from within an ASP.NET Core app. UI updates, event handling, and JavaScript calls are handled over a [SignalR](xref:signalr/introduction) connection using the [WebSockets protocol](xref:fundamentals/websockets). The state on the server associated with each connected client is called a *circuit*. Circuits aren't tied to a specific network connection and can tolerate temporary network interruptions and attempts by the client to reconnect to the server when the connection is lost.

In a traditional server-rendered app, opening the same app in multiple browser screens (tabs or `iframes`) typically doesn't translate into additional resource demands on the server. For the Blazor Server hosting model, each browser screen requires a separate circuit and separate instances of server-managed component state. Blazor considers closing a browser tab or navigating to an external URL a *graceful* termination. In the event of a graceful termination, the circuit and associated resources are immediately released. A client may also disconnect non-gracefully, for instance due to a network interruption. Blazor Server stores disconnected circuits for a configurable interval to allow the client to reconnect.

![The browser interacts with Blazor (hosted inside of an ASP.NET Core app) on the server over a SignalR connection.](~/blazor/hosting-models/_static/blazor-server.png)

On the client, the Blazor script establishes the SignalR connection with the server. The script is served from an embedded resource in the ASP.NET Core shared framework.

The Blazor Server hosting model offers several benefits:

* Download size is significantly smaller than when the Blazor WebAssembly hosting model is used, and the app loads much faster.
* The app takes full advantage of server capabilities, including the use of .NET Core APIs.
* .NET Core on the server is used to run the app, so existing .NET tooling, such as debugging, works as expected.
* Thin clients are supported. For example, Blazor Server works with browsers that don't support WebAssembly and on resource-constrained devices.
* The app's .NET/C# code base, including the app's component code, isn't served to clients.

The Blazor Server hosting model has the following limitations:

* Higher latency usually exists. Every user interaction involves a network hop.
* There's no offline support. If the client connection fails, interactivity fails.
* Scaling apps with many users requires server resources to handle multiple client connections and client state.
* An ASP.NET Core server is required to serve the app. Serverless deployment scenarios aren't possible, such as serving the app from a Content Delivery Network (CDN).

We recommend using the [Azure SignalR Service](/azure/azure-signalr) for apps that adopt the Blazor Server hosting model. The service allows for scaling up a Blazor Server app to a large number of concurrent SignalR connections.

## Blazor WebAssembly

The Blazor WebAssembly hosting model runs components client-side in the browser on a WebAssembly-based .NET runtime. Razor components, their dependencies, and the .NET runtime are downloaded to the browser. Components are executed directly on the browser UI thread. UI updates and event handling occur within the same process. Assets are deployed as static files to a web server or service capable of serving static content to clients.

![Blazor WebAssembly: Blazor runs on a UI thread inside the browser.](~/blazor/hosting-models/_static/blazor-webassembly.png)

:::moniker range=">= aspnetcore-8.0"

Blazor web apps can use the Blazor WebAssembly hosting model to enable client-side interactivity. When an app is created that exclusively runs on the Blazor WebAssembly hosting model without server-side rendering and interactivity, the app is called a *standalone* Blazor WebAssembly app.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

When the Blazor WebAssembly app is created for deployment without a backend ASP.NET Core app to serve its files, the app is called a *standalone* Blazor WebAssembly app.

:::moniker-end

When a standalone Blazor WebAssembly app uses a backend ASP.NET Core app to serve its files, the app is called a *hosted* Blazor WebAssembly app. Using hosted Blazor WebAssembly, you get a full-stack web development experience with .NET, including the ability to share code between the client and server apps, support for prerendering, and integration with MVC and Razor Pages. A hosted client app can interact with its backend server app over the network using a variety of messaging frameworks and protocols, such as [web API](xref:web-api/index), [gRPC-web](xref:grpc/index), and [SignalR](xref:signalr/introduction) (<xref:blazor/tutorials/signalr-blazor>).

:::moniker range=">= aspnetcore-6.0"

A Blazor WebAssembly app built as a [Progressive Web App (PWA)](xref:blazor/progressive-web-app) uses modern browser APIs to enable many of the capabilities of a native client app, such as working offline, running in its own app window, launching from the host's operating system, receiving push notifications, and automatically updating in the background.

:::moniker-end

The Blazor script handles:

* Downloading the .NET runtime, Razor components, and the component's dependencies.
* Initialization of the runtime.

The size of the published app, its *payload size*, is a critical performance factor for an app's usability. A large app takes a relatively long time to download to a browser, which diminishes the user experience. Blazor WebAssembly optimizes payload size to reduce download times:

* Unused code is stripped out of the app when it's published by the [Intermediate Language (IL) Trimmer](xref:blazor/host-and-deploy/configure-trimmer).
* HTTP responses are compressed.
* The .NET runtime and assemblies are cached in the browser.

The Blazor WebAssembly hosting model offers several benefits:

* For standalone Blazor WebAssembly apps, there's no .NET server-side dependency after the app is downloaded from the server, so the app remains functional if the server goes offline.
* Client resources and capabilities are fully leveraged.
* Work is offloaded from the server to the client.
* For standalone Blazor WebAssembly apps, an ASP.NET Core web server isn't required to host the app. Serverless deployment scenarios are possible, such as serving the app from a Content Delivery Network (CDN).

The Blazor WebAssembly hosting model has the following limitations:

* Razor components are restricted to the capabilities of the browser.
* Capable client hardware and software (for example, WebAssembly support) is required.
* Download size is larger, and components take longer to load.
* Code sent to the client can't be protected from inspection and tampering by users.

:::moniker range=">= aspnetcore-8.0"

The .NET [Intermediate Language (IL)](/dotnet/standard/glossary#il) interpreter includes partial [just-in-time (JIT)](/dotnet/standard/glossary#jit) runtime support to achieve improved runtime performance. The JIT interpreter optimizes execution of interpreter bytecodes by replacing them with tiny blobs of WebAssembly code. The JIT interpreter is automatically enabled for Blazor WebAssembly apps except when debugging.

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

Blazor supports ahead-of-time (AOT) compilation, where you can compile your .NET code directly into WebAssembly. AOT compilation results in runtime performance improvements at the expense of a larger app size. For more information, see <xref:blazor/host-and-deploy/webassembly#ahead-of-time-aot-compilation>. 

The same [.NET WebAssembly build tools](xref:blazor/tooling#net-webassembly-build-tools) used for AOT compilation also [relink the .NET WebAssembly runtime](xref:blazor/host-and-deploy/webassembly#runtime-relinking) to trim unused runtime code. Blazor also trims unused code from .NET framework libraries. The .NET compiler further precompresses a standalone Blazor WebAssembly app for a smaller app payload.

WebAssembly-rendered Razor components can use [native dependencies](xref:blazor/webassembly-native-dependencies) built to run on WebAssembly.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Blazor WebAssembly includes support for trimming unused code from .NET Core framework libraries. For more information, see <xref:blazor/globalization-localization>.

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

## Blazor Hybrid

Blazor can also be used to build native client apps using a hybrid approach. Hybrid apps are native apps that leverage web technologies for their functionality. In a Blazor Hybrid app, Razor components run directly in the native app (not on WebAssembly) along with any other .NET code and render web UI based on HTML and CSS to an embedded Web View control through a local interop channel.

![Hybrid apps with .NET and Blazor render UI in a Web View control, where the HTML DOM interacts with Blazor and .NET of the native desktop or mobile app.](~/blazor/hosting-models/_static/hybrid-apps-1.png)

Blazor Hybrid apps can be built using different .NET native app frameworks, including .NET MAUI, WPF, and Windows Forms. Blazor provides `BlazorWebView` controls for adding Razor components to apps built with these frameworks. Using Blazor with .NET MAUI offers a convenient way to build cross-platform Blazor Hybrid apps for mobile and desktop, while Blazor integration with WPF and Windows Forms can be a great way to modernize existing apps.

Because Blazor Hybrid apps are native apps, they can support functionality that isn't available with only the web platform. Blazor Hybrid apps have full access to native platform capabilities through normal .NET APIs. Blazor Hybrid apps can also share and reuse components with existing Blazor Server or Blazor WebAssembly apps. Blazor Hybrid apps combine the benefits of the web, native apps, and the .NET platform.

The Blazor Hybrid hosting model offers several benefits:

* Reuse existing components that can be shared across mobile, desktop, and web.
* Leverage web development skills, experience, and resources.
* Apps have full access to the native capabilities of the device.

The Blazor Hybrid hosting model has the following limitations:

* Separate native client apps must be built, deployed, and maintained for each target platform.
* Native client apps usually take longer to find, download, and install over accessing a web app in a browser.

For more information, see <xref:blazor/hybrid/index>.

For more information on Microsoft native client frameworks, see the following resources:

* [.NET Multi-platform App UI (.NET MAUI)](/dotnet/maui/what-is-maui)
* [Windows Presentation Foundation (WPF)](/dotnet/desktop/wpf/overview/)
* [Windows Forms](/dotnet/desktop/winforms/overview/)

:::moniker-end

## Which Blazor hosting model should I choose?

:::moniker range=">= aspnetcore-8.0"

A component's hosting model is set by its *render mode*, either at compile time or runtime, which is described with examples in <xref:blazor/components/render-modes>. The following table shows the primary considerations for setting the render mode to determine a component's hosting model. For standalone Blazor WebAssembly apps, all of the app's components are rendered on the client with the Blazor WebAssembly hosting model.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

Select the Blazor hosting model based on the app's feature requirements. The following table shows the primary considerations for selecting the hosting model.

:::moniker-end

:::moniker range=">= aspnetcore-6.0" 

Blazor Hybrid apps include .NET MAUI, WPF, and Windows Forms framework apps.

| Feature | Blazor Server | Blazor WebAssembly (WASM) | Blazor Hybrid |
| --- | :---: | :---: | :---: |
| [Complete .NET API compatibility](#complete-net-api-compatibility) | <span aria-hidden="true">✔️</span><span class="visually-hidden">Supported</span> | <span aria-hidden="true">❌</span><span class="visually-hidden">Not supported</span> | <span aria-hidden="true">✔️</span><span class="visually-hidden">Supported</span> |
| [Direct access to server and network resources](#direct-access-to-server-and-network-resources) | <span aria-hidden="true">✔️</span><span class="visually-hidden">Supported</span> | <span aria-hidden="true">❌</span><span class="visually-hidden">Not supported</span>&dagger; | <span aria-hidden="true">❌</span><span class="visually-hidden">Not supported</span>&dagger; |
| [Small payload size with fast initial load time](#small-payload-size-with-fast-initial-load-time) | <span aria-hidden="true">✔️</span><span class="visually-hidden">Supported</span> | <span aria-hidden="true">❌</span><span class="visually-hidden">Not supported</span> | <span aria-hidden="true">❌</span><span class="visually-hidden">Not supported</span> |
| [Near native execution speed](#near-native-execution-speed) | <span aria-hidden="true">✔️</span><span class="visually-hidden">Supported</span> | <span aria-hidden="true">✔️</span><span class="visually-hidden">Supported</span>&Dagger; | <span aria-hidden="true">✔️</span><span class="visually-hidden">Supported</span> |
| [App code secure and private on the server](#app-code-secure-and-private-on-the-server) | <span aria-hidden="true">✔️</span><span class="visually-hidden">Supported</span> | <span aria-hidden="true">❌</span><span class="visually-hidden">Not supported</span>&dagger; | <span aria-hidden="true">❌</span><span class="visually-hidden">Not supported</span>&dagger; |
| [Run apps offline once downloaded](#run-apps-offline-once-downloaded) | <span aria-hidden="true">❌</span><span class="visually-hidden">Not supported</span> | <span aria-hidden="true">✔️</span><span class="visually-hidden">Supported</span> | <span aria-hidden="true">✔️</span><span class="visually-hidden">Supported</span> |
| [Static site hosting](#static-site-hosting) | <span aria-hidden="true">❌</span><span class="visually-hidden">Not supported</span> | <span aria-hidden="true">✔️</span><span class="visually-hidden">Supported</span> | <span aria-hidden="true">❌</span><span class="visually-hidden">Not supported</span> |
| [Offloads processing to clients](#offloads-processing-to-clients) | <span aria-hidden="true">❌</span><span class="visually-hidden">Not supported</span> | <span aria-hidden="true">✔️</span><span class="visually-hidden">Supported</span> | <span aria-hidden="true">✔️</span><span class="visually-hidden">Supported</span> |
| [Full access to native client capabilities](#full-access-to-native-client-capabilities) | <span aria-hidden="true">❌</span><span class="visually-hidden">Not supported</span> | <span aria-hidden="true">❌</span><span class="visually-hidden">Not supported</span> | <span aria-hidden="true">✔️</span><span class="visually-hidden">Supported</span> |
| [Web-based deployment](#web-based-deployment) | <span aria-hidden="true">✔️</span><span class="visually-hidden">Supported</span> | <span aria-hidden="true">✔️</span><span class="visually-hidden">Supported</span> | <span aria-hidden="true">❌</span><span class="visually-hidden">Not supported</span> |

&dagger;Blazor WebAssembly and Blazor Hybrid apps can use server-based APIs to access server/network resources and access private and secure app code.  
&Dagger;Blazor WebAssembly only reaches near-native performance with [ahead-of-time (AOT) compilation](xref:blazor/host-and-deploy/webassembly#ahead-of-time-aot-compilation).

:::moniker-end

:::moniker range="< aspnetcore-6.0"

| Feature | Blazor Server | Blazor WebAssembly (WASM) |
| --- | :---: | :---: |
| [Complete .NET API compatibility](#complete-net-api-compatibility) | <span aria-hidden="true">✔️</span><span class="visually-hidden">Supported</span> | <span aria-hidden="true">❌</span><span class="visually-hidden">Not supported</span> |
| [Direct access to server and network resources](#direct-access-to-server-and-network-resources) | <span aria-hidden="true">✔️</span><span class="visually-hidden">Supported</span> | <span aria-hidden="true">❌</span><span class="visually-hidden">Not supported</span>&dagger; |
| [Small payload size with fast initial load time](#small-payload-size-with-fast-initial-load-time) | <span aria-hidden="true">✔️</span><span class="visually-hidden">Supported</span> | <span aria-hidden="true">❌</span><span class="visually-hidden">Not supported</span> |
| [App code secure and private on the server](#app-code-secure-and-private-on-the-server) | <span aria-hidden="true">✔️</span><span class="visually-hidden">Supported</span> | <span aria-hidden="true">❌</span><span class="visually-hidden">Not supported</span>&dagger; |
| [Run apps offline once downloaded](#run-apps-offline-once-downloaded) | <span aria-hidden="true">❌</span><span class="visually-hidden">Not supported</span> | <span aria-hidden="true">✔️</span><span class="visually-hidden">Supported</span> |
| [Static site hosting](#static-site-hosting) | <span aria-hidden="true">❌</span><span class="visually-hidden">Not supported</span> | <span aria-hidden="true">✔️</span><span class="visually-hidden">Supported</span> |
| [Offloads processing to clients](#offloads-processing-to-clients) | <span aria-hidden="true">❌</span><span class="visually-hidden">Not supported</span> | <span aria-hidden="true">✔️</span><span class="visually-hidden">Supported</span> |

&dagger;Blazor WebAssembly apps can use server-based APIs to access server/network resources and access private and secure app code.

:::moniker-end

After you choose the app's hosting model, you can generate a Blazor Server or Blazor WebAssembly app from a Blazor project template. For more information, see <xref:blazor/tooling#blazor-template-options>.

:::moniker range=">= aspnetcore-6.0"

To create a Blazor Hybrid app, see the articles under <xref:blazor/hybrid/tutorials/index>.

:::moniker-end

### Complete .NET API compatibility

:::moniker range=">= aspnetcore-8.0"

Components rendered for the Blazor Server hosting model and Blazor Hybrid apps have complete .NET API compatibility, while components rendered for Blazor WebAssembly are limited to a subset of .NET APIs. When an app's specification requires one or more .NET APIs that are unavailable to WebAssembly-rendered components, then choose to render components for Blazor Server or use Blazor Hybrid.

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

Blazor Server and Blazor Hybrid apps have complete .NET API compatibility, while Blazor WebAssembly apps are limited to a subset of .NET APIs. When an app's specification requires one or more .NET APIs that are unavailable to Blazor WebAssembly apps, then choose Blazor Server or Blazor Hybrid.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Blazor Server apps have complete .NET API compatibility, while Blazor WebAssembly apps are limited to a subset of .NET APIs. When an app's specification requires one or more .NET APIs that are unavailable to Blazor WebAssembly apps, then choose Blazor Server.

:::moniker-end

### Direct access to server and network resources

:::moniker range=">= aspnetcore-8.0"

Components rendered for the Blazor Server hosting model have direct access to server and network resources where the app is executing. Because components hosted using Blazor WebAssembly or Blazor Hybrid execute on a client, they don't have direct access to server and network resources. Components can access server and network resources *indirectly* via protected server-based APIs. Server-based APIs might be available via third-party libraries, packages, and services. Take into account the following considerations:

* Third-party libraries, packages, and services might be costly to implement and maintain, weakly supported, or introduce security risks.
* If one or more server-based APIs are developed internally by your organization, additional resources are required to build and maintain them.

Use the Blazor Server hosting model to avoid the need to expose APIs from the server environment.

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

Blazor Server apps have direct access to server and network resources where the app is executing. Because Blazor WebAssembly and Blazor Hybrid apps execute on a client, they don't have direct access to server and network resources. Blazor WebAssembly and Blazor Hybrid apps can access server and network resources *indirectly* via protected server-based APIs. Server-based APIs might be available via third-party libraries, packages, and services. Take into account the following considerations:

* Third-party libraries, packages, and services might be costly to implement and maintain, weakly supported, or introduce security risks.
* If one or more server-based APIs are developed internally by your organization, additional resources are required to build and maintain them.

To avoid server-based APIs for Blazor WebAssembly or Blazor Hybrid apps, adopt Blazor Server, which can access server and network resources directly.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Blazor Server apps have direct access to server and network resources where the app is executing. Because Blazor WebAssembly apps execute on a client, they don't have direct access to server and network resources. Blazor WebAssembly apps can access server and network resources *indirectly* via protected server-based APIs. Server-based APIs might be available via third-party libraries, packages, and services. Take into account the following considerations:

* Third-party libraries, packages, and services might be costly to implement and maintain, weakly supported, or introduce security risks.
* If one or more server-based APIs are developed internally by your organization, additional resources are required to build and maintain them.

To avoid server-based APIs for Blazor WebAssembly apps, adopt Blazor Server, which can access server and network resources directly.

:::moniker-end

### Small payload size with fast initial load time

:::moniker range=">= aspnetcore-8.0"

Rendering components from the server reduces the app payload size and improves initial load times. When a fast initial load time is desired, use the Blazor Server hosting model or consider static server-side rendering.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

Blazor Server apps have relatively small payload sizes with faster initial load times. When a fast initial load time is desired, adopt Blazor Server.

:::moniker-end

### Near native execution speed

:::moniker range=">= aspnetcore-8.0"

Blazor Hybrid apps run using the .NET runtime natively on the target platform, which offers the best possible speed.

Components rendered for the Blazor WebAssembly hosting model, including Progressive Web Apps (PWAs), and standalone Blazor WebAssembly apps run using the .NET runtime for WebAssembly, which is slower than running directly on the platform. Consider using [ahead-of-time (AOT) compiled](xref:blazor/host-and-deploy/webassembly#ahead-of-time-aot-compilation) to improve runtime performance when using Blazor WebAssembly.

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

Blazor Hybrid apps run using the .NET runtime natively on the target platform, which offers the best possible speed.

Blazor WebAssembly, including Progressive Web Apps (PWAs), apps run using the .NET runtime for WebAssembly, which is slower than running directly on the platform, even for apps that are [ahead-of-time (AOT) compiled](xref:blazor/host-and-deploy/webassembly#ahead-of-time-aot-compilation) for WebAssembly in the browser.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Blazor Server apps generally execute on the server quickly.

Blazor WebAssembly apps run using the .NET runtime for WebAssembly, which is slower than running directly on the platform.

:::moniker-end

### App code secure and private on the server

:::moniker range=">= aspnetcore-8.0"

Maintaining app code securely and privately on the server is a built-in feature of components rendered for the Blazor Server hosting model. Components rendered using the Blazor WebAssembly or Blazor Hybrid hosting models can use server-based APIs to access functionality that must be kept private and secure. The considerations for developing and maintaining server-based APIs described in the [Direct access to server and network resources](#direct-access-to-server-and-network-resources) section apply. If the development and maintenance of server-based APIs isn't desirable for maintaining secure and private app code, render components for the Blazor Server hosting model.

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

Maintaining app code securely and privately on the server is a built-in feature of Blazor Server. Blazor WebAssembly and Blazor Hybrid apps can use server-based APIs to access functionality that must be kept private and secure. The considerations for developing and maintaining server-based APIs described in the [Direct access to server and network resources](#direct-access-to-server-and-network-resources) section apply. If the development and maintenance of server-based APIs isn't desirable for maintaining secure and private app code, adopt the Blazor Server hosting model.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Maintaining app code securely and privately on the server is a built-in feature of Blazor Server. Blazor WebAssembly apps can use server-based APIs to access functionality that must be kept private and secure. The considerations for developing and maintaining server-based APIs described in the [Direct access to server and network resources](#direct-access-to-server-and-network-resources) section apply. If the development and maintenance of server-based APIs isn't desirable for maintaining secure and private app code, adopt the Blazor Server hosting model.

:::moniker-end

### Run apps offline once downloaded

:::moniker range=">= aspnetcore-8.0"

Standalone Blazor WebAssembly apps built as Progressive Web Apps (PWAs) and Blazor Hybrid apps can run offline, which is particularly useful when clients aren't able to connect to the Internet. Components rendered for the Blazor Server hosting model fail to run when the connection to the server is lost. If an app must run offline, standalone Blazor WebAssembly and Blazor Hybrid are the best choices.

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

Blazor WebAssembly apps built as Progressive Web Apps (PWAs) and Blazor Hybrid apps can run offline, which is particularly useful when clients aren't able to connect to the Internet. Blazor Server apps fail to run when the connection to the server is lost. If an app must run offline, Blazor WebAssembly and Blazor Hybrid are the best choices.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Blazor WebAssembly apps can run offline, which is particularly useful when clients aren't able to connect to the Internet. Blazor Server apps fail to run when the connection to the server is lost. If an app must run offline, Blazor WebAssembly is the best choice.

:::moniker-end

### Static site hosting

Static site hosting is possible with standalone Blazor WebAssembly apps because they're downloaded to clients as a set of static files. Standalone Blazor WebAssembly apps don't require a server to execute server-side code in order to download and run and can be delivered via a [Content Delivery Network (CDN)](https://developer.mozilla.org/docs/Glossary/CDN) (for example, [Azure CDN](https://azure.microsoft.com/services/cdn/)).

:::moniker range=">= aspnetcore-6.0"

Although Blazor Hybrid apps are compiled into one or more self-contained deployment assets, the assets are usually provided to clients through a third-party app store. If static hosting is an app requirement, select standalone Blazor WebAssembly.

:::moniker-end

### Offloads processing to clients

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

Components rendered using the Blazor WebAssembly or Blazor Hybrid hosting models execute on clients and thus offload processing to clients. Components rendered for the Blazor Server hosting model execute on a server, so server resource demand typically increases with the number of users and the amount of processing required per user. When it's possible to offload most or all of an app's processing to clients and the app processes a significant amount of data, Blazor WebAssembly or Blazor Hybrid is the best choice.

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

Blazor WebAssembly and Blazor Hybrid apps execute on clients and thus offload processing to clients. Blazor Server apps execute on a server, so server resource demand typically increases with the number of users and the amount of processing required per user. When it's possible to offload most or all of an app's processing to clients and the app processes a significant amount of data, Blazor WebAssembly or Blazor Hybrid is the best choice.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Blazor WebAssembly apps execute on clients and thus offload processing to clients. Blazor Server apps execute on a server, so server resource demand typically increases with the number of users and the amount of processing required per user. When it's possible to offload most or all of an app's processing to clients and the app processes a significant amount of data, Blazor WebAssembly is the best choice.

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

### Full access to native client capabilities

Blazor Hybrid apps have full access to native client API capabilities via .NET native app frameworks. In Blazor Hybrid apps, Razor components run directly in the native app, not on [WebAssembly](https://developer.mozilla.org/docs/WebAssembly). When full client capabilities are a requirement, Blazor Hybrid is the best choice.

:::moniker-end

### Web-based deployment

Blazor web apps are updated on the next app refresh from the browser.

:::moniker range=">= aspnetcore-6.0"

Blazor Hybrid apps are native client apps that typically require an installer and platform-specific deployment mechanism.

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

## Setting a component's hosting model

To set a component's hosting model to Blazor Server or Blazor WebAssembly at compile-time or dynamically at runtime, you set its *render mode*. Render modes are fully explained and demonstrated in the <xref:blazor/components/render-modes> article. We don't recommend that you jump from this article directly to the *Render modes* article without reading the content in the articles between these two articles. For example, render modes are more easily understood by looking at Razor component examples, but basic Razor component structure and function isn't covered until the <xref:blazor/fundamentals/index> article is reached. It's also helpful to learn about Blazor's project templates and tooling before working with the component examples in the *Render modes* article.

:::moniker-end
