---
title: ASP.NET Core Blazor hosting models
author: guardrex
description: Learn about Blazor hosting models and how to pick which one to use.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 03/02/2022
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/hosting-models
---
# ASP.NET Core Blazor hosting models

This article explains the different Blazor hosting models and how to choose which one to use.

:::moniker range=">= aspnetcore-6.0"

Blazor is a web framework for building web UI components ([Razor components](xref:blazor/components/index)) that can be hosted in different ways. Razor components can run server-side in ASP.NET Core (*Blazor Server*) versus client-side in the browser on a [WebAssembly](https://webassembly.org/)-based .NET runtime (*Blazor WebAssembly*, *Blazor WASM*). You can also host Razor components in native mobile and desktop apps that render to an embedded :::no-loc text="Web View"::: control (*Blazor Hybrid*). Regardless of the hosting model, the way you build Razor components *is the same*. The same Razor components can be used with any of the hosting models unchanged.

## Blazor Server

With the Blazor Server hosting model, the app is executed on the server from within an ASP.NET Core app. UI updates, event handling, and JavaScript calls are handled over a [SignalR](xref:signalr/introduction) connection. The state on the server associated with each connected client is called a *circuit*. A circuit can tolerate temporary network interruptions and attempts by the client to reconnect to the server when the connection is lost.

In a traditional server-rendered app, opening the same app in multiple browser screens (tabs or `iframes`) typically doesn't translate into additional resource demands on the server. In a Blazor Server app, each browser screen requires a separate circuit and separate instances of server-managed component state. Blazor considers closing a browser tab or navigating to an external URL a *graceful* termination. In the event of a graceful termination, the circuit and associated resources are immediately released. A client may also disconnect non-gracefully, for instance due to a network interruption. Blazor Server stores disconnected circuits for a configurable interval to allow the client to reconnect.

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

Blazor WebAssembly (WASM) apps run client-side in the browser on a WebAssembly-based .NET runtime. The Blazor app, its dependencies, and the .NET runtime are downloaded to the browser. The app is executed directly on the browser UI thread. UI updates and event handling occur within the same process. The app's assets are deployed as static files to a web server or service capable of serving static content to clients.

![Blazor WebAssembly: The Blazor app runs on a UI thread inside the browser.](~/blazor/hosting-models/_static/blazor-webassembly.png)

When the Blazor WebAssembly app is created for deployment without a backend ASP.NET Core app to serve its files, the app is called a *standalone* Blazor WebAssembly app. When the app is created for deployment with a backend app to serve its files, the app is called a *hosted* Blazor WebAssembly app.

Using hosted Blazor WebAssembly, you get a full-stack web development experience with .NET, including the ability to share code between the client and server apps, support for prerendering, and integration with MVC and Razor Pages. A hosted client app can interact with its backend server app over the network using a variety of messaging frameworks and protocols, such as [web API](xref:web-api/index), [gRPC-web](xref:grpc/index), and [SignalR](xref:signalr/introduction) (<xref:blazor/tutorials/signalr-blazor>).

The `blazor.webassembly.js` script is provided by the framework and handles:

* Downloading the .NET runtime, the app, and the app's dependencies.
* Initialization of the runtime to run the app.

The Blazor WebAssembly (WASM) hosting model offers several benefits:

* There's no .NET server-side dependency after the app is downloaded from the server, so the app remains functional if the server goes offline.
* Client resources and capabilities are fully leveraged.
* Work is offloaded from the server to the client.
* An ASP.NET Core web server isn't required to host the app. Serverless deployment scenarios are possible, such as serving the app from a Content Delivery Network (CDN).

The Blazor WebAssembly hosting model has the following limitations:

* The app is restricted to the capabilities of the browser.
* Capable client hardware and software (for example, WebAssembly support) is required.
* Download size is larger, and apps take longer to load.

Blazor WebAssembly supports ahead-of-time (AOT) compilation, where you can compile your .NET code directly into WebAssembly. AOT compilation results in runtime performance improvements at the expense of a larger app size. For more information, see <xref:blazor/host-and-deploy/webassembly#ahead-of-time-aot-compilation>. 

The same .NET WebAssembly build tools used for AOT compilation also [relink the .NET WebAssembly runtime](xref:blazor/host-and-deploy/webassembly#runtime-relinking) to trim unused runtime code. 

Blazor WebAssembly includes support for trimming unused code from .NET Core framework libraries. For more information, see <xref:blazor/globalization-localization>. The .NET compiler further precompresses a Blazor WebAssembly app for a smaller app payload.

Blazor WebAssembly apps can use [native dependencies](xref:blazor/webassembly-native-dependencies) built to run on WebAssembly.

## Blazor Hybrid

[!INCLUDE[](~/blazor/includes/blazor-hybrid-preview-notice.md)]

Blazor can also be used to build native client apps using a hybrid approach. Hybrid apps are native apps that leverage web technologies for their functionality. In a Blazor Hybrid app, Razor components run directly in the native app (not on WebAssembly) along with any other .NET code and render web UI based on HTML and CSS to an embedded :::no-loc text="Web View"::: control through a local interop channel.

![Hybrid apps with .NET and Blazor render UI in a Web View control, where the HTML Document Object Model (DOM) interacts with Blazor and .NET of the native desktop or mobile app.](~/blazor/hosting-models/_static/hybrid-apps-1.png)

Blazor Hybrid apps can be built using different .NET native app frameworks, including .NET MAUI, WPF, and Windows Forms. Blazor provides `BlazorWebView` controls for adding Razor components to apps built with these frameworks. Using Blazor with .NET MAUI offers a convenient way to build cross-platform Blazor Hybrid apps for mobile and desktop, while Blazor integration with WPF and Windows Forms can be a great way to modernize existing apps.

Because Blazor Hybrid apps are native apps, they can support functionality that isn't available with only the web platform. Blazor Hybrid apps have full access to native platform capabilities through normal .NET APIs. Blazor Hybrid apps can also share and reuse components with existing Blazor Server or Blazor WebAssembly apps. Blazor Hybrid apps combine the benefits of the web, native apps, and the .NET platform.

The Blazor Hybrid hosting model offers several benefits:

* Reuse existing components that can be shared across mobile, desktop, and web.
* Leverage web development skills, experience, and resources.
* Apps have full access to the native capabilities of the device.

The Blazor Hybrid hosting model has the following limitations:

* Separate native client apps must be built, deployed, and maintained for each target platform.
* Native client apps usually take longer to find, download, and install than accessing a web app in a browser.

For more information, see <xref:blazor/hybrid/index>.

For more information on Microsoft native client frameworks, see the following resources:

* [.NET Multi-platform App UI (.NET MAUI)](/dotnet/maui/what-is-maui)
* [Windows Presentation Foundation (WPF)](/dotnet/desktop/wpf/overview/)
* [Windows Forms](/dotnet/desktop/winforms/overview/)

## Which Blazor hosting model should I choose?

[!INCLUDE[](~/blazor/includes/blazor-hybrid-preview-notice.md)]

Select the Blazor hosting model based on the app's feature requirements. The following table shows the primary considerations for selecting the hosting model.

| Feature | Blazor Server | Blazor WebAssembly (WASM) | Blazor Hybrid |
| --- | :---: | :---: | :---: |
| [Complete .NET API compatibility](#complete-net-api-compatibility) | ✔️ | ❌ | ✔️ |
| [Direct access to server and network resources](#direct-access-to-server-and-network-resources) | ✔️ | ❌&dagger; | ❌&dagger; |
| [Small payload size with fast initial load time](#small-payload-size-with-fast-initial-load-time) | ✔️ | ❌ | ❌ |
| [App code secure and private on the server](#app-code-secure-and-private-on-the-server) | ✔️ | ❌&dagger; | ❌&dagger; |
| [Run apps offline once downloaded](#run-apps-offline-once-downloaded) | ❌ | ✔️ | ✔️ |
| [Static site hosting](#static-site-hosting) | ❌ | ✔️ | ❌ |
| [Offloads processing to clients](#offloads-processing-to-clients) | ❌ | ✔️ | ✔️ |
| [Full access to native client capabilities](#full-access-to-native-client-capabilities) | ❌ | ❌ | ✔️ |

&dagger;Blazor WebAssembly and Blazor Hybrid apps can use server-based APIs to access server/network resources and access private and secure app code.

After you choose the app's hosting model, you can generate a Blazor Server or Blazor WebAssembly app from a Blazor project template. For more information, see <xref:blazor/tooling#blazor-template-options>.

To create a Blazor Hybrid app, see the articles under <xref:blazor/hybrid/tutorials/index>.

### Complete .NET API compatibility

Blazor Server and Blazor Hybrid apps have complete .NET API compatibility, while Blazor WebAssembly apps are limited to a subset of .NET APIs. When an app's specification requires one or more .NET APIs that are unavailable to Blazor WebAssembly apps, then choose Blazor Server or Blazor Hybrid.

### Direct access to server and network resources

Blazor Server apps have direct access to server and network resources where the app is executing. Because Blazor WebAssembly and Blazor Hybrid apps execute on a client, they don't have direct access to server and network resources. Blazor WebAssembly and Blazor Hybrid apps can access server and network resources *indirectly* via protected server-based APIs. Server-based APIs might be available via third-party libraries, packages, and services. Take into account the following considerations:

* Third-party libraries, packages, and services might be costly to implement and maintain, weakly supported, or introduce security risks.
* If one or more server-based APIs are developed internally by your organization, additional resources are required to build and maintain them.

To avoid server-based APIs for Blazor WebAssembly or Blazor Hybrid apps, adopt Blazor Server, which can access server and network resources directly.

### Small payload size with fast initial load time

Blazor Server apps have relatively small payload sizes with faster initial load times. When a fast initial load time is desired, adopt Blazor Server.

### App code secure and private on the server

Maintaining app code securely and privately on the server is a built-in feature of Blazor Server. Blazor WebAssembly and Blazor Hybrid apps can use server-based APIs to access functionality that must be kept private and secure. The considerations for developing and maintaining server-based APIs described in the [Direct access to server and network resources](#direct-access-to-server-and-network-resources) section apply. If the development and maintenance of server-based APIs isn't desirable for maintaining secure and private app code, adopt the Blazor Server hosting model.

### Run apps offline once downloaded

Blazor WebAssembly and Blazor Hybrid apps can run offline, which is particularly useful when clients aren't able to connect to the Internet. Blazor Server apps fail to run when the connection to the server is lost. If an app must run offline, Blazor WebAssembly and Blazor Hybrid are the best choices.

### Static site hosting

Static site hosting is possible with Blazor WebAssembly apps because they're downloaded to clients as a set of static files. Blazor WebAssembly apps don't require a server to execute server-side code in order to download and run. Blazor WebAssembly apps can be delivered via a [Content Delivery Network (CDN)](https://developer.mozilla.org/docs/Glossary/CDN) (for example, [Azure CDN](https://azure.microsoft.com/services/cdn/)). Although Blazor Hybrid apps are compiled into one or more self-contained deployment assets, the assets are usually provided to clients through a third-party app store. If static hosting is an app requirement, select Blazor WebAssembly.

### Offloads processing to clients

Blazor WebAssembly and Blazor Hybrid apps execute on clients and thus offload processing to clients. Blazor Server apps execute on a server, so server resource demand typically increases with the number of users and the amount of processing required per user. When it's possible to offload most or all of an app's processing to clients and the app processes a significant amount of data, Blazor WebAssembly or Blazor Hybrid is the best choice.

### Full access to native client capabilities

Blazor Hybrid apps have full access to native client API capabilities via .NET native app frameworks. In Blazor Hybrid apps, Razor components run directly in the native app, not on [WebAssembly](https://developer.mozilla.org/docs/WebAssembly). When full client capabilities are a requirement, Blazor Hybrid is the best choice.

## Additional resources

* <xref:blazor/hybrid/index>
* <xref:blazor/tooling>
* <xref:blazor/project-structure>
* <xref:signalr/introduction>
* <xref:blazor/fundamentals/signalr>
* <xref:blazor/tutorials/signalr-blazor>

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Blazor is a web framework for building web UI components ([Razor components](xref:blazor/components/index)) that can be hosted in different ways. Razor components can run server-side in ASP.NET Core (*Blazor Server*) versus client-side in the browser on a [WebAssembly](https://webassembly.org/)-based .NET runtime (*Blazor WebAssembly*, *Blazor WASM*). Regardless of the hosting model, the way you build Razor components *is the same*. The same Razor components can be used with any of the hosting models unchanged.

## Blazor Server

With the Blazor Server hosting model, the app is executed on the server from within an ASP.NET Core app. UI updates, event handling, and JavaScript calls are handled over a [SignalR](xref:signalr/introduction) connection. The state on the server associated with each connected client is called a *circuit*. A circuit can tolerate temporary network interruptions and attempts by the client to reconnect to the server when the connection is lost.

In a traditional server-rendered app, opening the same app in multiple browser screens (tabs or `iframes`) typically doesn't translate into additional resource demands on the server. In a Blazor Server app, each browser screen requires a separate circuit and separate instances of server-managed component state. Blazor considers closing a browser tab or navigating to an external URL a *graceful* termination. In the event of a graceful termination, the circuit and associated resources are immediately released. A client may also disconnect non-gracefully, for instance due to a network interruption. Blazor Server stores disconnected circuits for a configurable interval to allow the client to reconnect.

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

Blazor WebAssembly (WASM) apps run client-side in the browser on a WebAssembly-based .NET runtime. The Blazor app, its dependencies, and the .NET runtime are downloaded to the browser. The app is executed directly on the browser UI thread. UI updates and event handling occur within the same process. The app's assets are deployed as static files to a web server or service capable of serving static content to clients.

![Blazor WebAssembly: The Blazor app runs on a UI thread inside the browser.](~/blazor/hosting-models/_static/blazor-webassembly.png)

When the Blazor WebAssembly app is created for deployment without a backend ASP.NET Core app to serve its files, the app is called a *standalone* Blazor WebAssembly app. When the app is created for deployment with a backend app to serve its files, the app is called a *hosted* Blazor WebAssembly app.

Using hosted Blazor WebAssembly, you get a full-stack web development experience with .NET, including the ability to share code between the client and server apps, support for prerendering, and integration with MVC and Razor Pages. A hosted client app can interact with its backend server app over the network using a variety of messaging frameworks and protocols, such as [web API](xref:web-api/index), [gRPC-web](xref:grpc/index), and [SignalR](xref:signalr/introduction) (<xref:blazor/tutorials/signalr-blazor>).

The `blazor.webassembly.js` script is provided by the framework and handles:

* Downloading the .NET runtime, the app, and the app's dependencies.
* Initialization of the runtime to run the app.

The Blazor WebAssembly (WASM) hosting model offers several benefits:

* There's no .NET server-side dependency after the app is downloaded from the server, so the app remains functional if the server goes offline.
* Client resources and capabilities are fully leveraged.
* Work is offloaded from the server to the client.
* An ASP.NET Core web server isn't required to host the app. Serverless deployment scenarios are possible, such as serving the app from a Content Delivery Network (CDN).

The Blazor WebAssembly hosting model has the following limitations:

* The app is restricted to the capabilities of the browser.
* Capable client hardware and software (for example, WebAssembly support) is required.
* Download size is larger, and apps take longer to load.

Blazor WebAssembly includes support for trimming unused code from .NET Core framework libraries. For more information, see <xref:blazor/globalization-localization>.

## Which Blazor hosting model should I choose?

Select the Blazor hosting model based on the app's feature requirements. The following table shows the primary considerations for selecting the hosting model.

| Feature | Blazor Server | Blazor WebAssembly (WASM) |
| --- | :---: | :---: |
| [Complete .NET API compatibility](#complete-net-api-compatibility) | ✔️ | ❌ |
| [Direct access to server and network resources](#direct-access-to-server-and-network-resources) | ✔️ | ❌&dagger; |
| [Small payload size with fast initial load time](#small-payload-size-with-fast-initial-load-time) | ✔️ | ❌ |
| [App code secure and private on the server](#app-code-secure-and-private-on-the-server) | ✔️ | ❌&dagger; |
| [Run apps offline once downloaded](#run-apps-offline-once-downloaded) | ❌ | ✔️ |
| [Static site hosting](#static-site-hosting) | ❌ | ✔️ |
| [Offloads processing to clients](#offloads-processing-to-clients) | ❌ | ✔️ |

&dagger;Blazor WebAssembly apps can use server-based APIs to access server/network resources and access private and secure app code.

After you choose the app's hosting model, you can generate a Blazor Server or Blazor WebAssembly app from a Blazor project template. For more information, see <xref:blazor/tooling#blazor-template-options>.

### Complete .NET API compatibility

Blazor Server apps have complete .NET API compatibility, while Blazor WebAssembly apps are limited to a subset of .NET APIs. When an app's specification requires one or more .NET APIs that are unavailable to Blazor WebAssembly apps, then choose Blazor Server.

### Direct access to server and network resources

Blazor Server apps have direct access to server and network resources where the app is executing. Because Blazor WebAssembly apps execute on a client, they don't have direct access to server and network resources. Blazor WebAssembly apps can access server and network resources *indirectly* via protected server-based APIs. Server-based APIs might be available via third-party libraries, packages, and services. Take into account the following considerations:

* Third-party libraries, packages, and services might be costly to implement and maintain, weakly supported, or introduce security risks.
* If one or more server-based APIs are developed internally by your organization, additional resources are required to build and maintain them.

To avoid server-based APIs for Blazor WebAssembly apps, adopt Blazor Server, which can access server and network resources directly.

### Small payload size with fast initial load time

Blazor Server apps have relatively small payload sizes with faster initial load times. When a fast initial load time is desired, adopt Blazor Server.

### App code secure and private on the server

Maintaining app code securely and privately on the server is a built-in feature of Blazor Server. Blazor WebAssembly apps can use server-based APIs to access functionality that must be kept private and secure. The considerations for developing and maintaining server-based APIs described in the [Direct access to server and network resources](#direct-access-to-server-and-network-resources) section apply. If the development and maintenance of server-based APIs isn't desirable for maintaining secure and private app code, adopt the Blazor Server hosting model.

### Run apps offline once downloaded

Blazor WebAssembly apps can run offline, which is particularly useful when clients aren't able to connect to the Internet. Blazor Server apps fail to run when the connection to the server is lost. If an app must run offline, Blazor WebAssembly is the best choice.

### Static site hosting

Static site hosting is possible with Blazor WebAssembly apps because they're downloaded to clients as a set of static files. Blazor WebAssembly apps don't require a server to execute server-side code in order to download and run. Blazor WebAssembly apps can be delivered via a [Content Delivery Network (CDN)](https://developer.mozilla.org/docs/Glossary/CDN) (for example, [Azure CDN](https://azure.microsoft.com/services/cdn/)). If static hosting is an app requirement, select Blazor WebAssembly.

### Offloads processing to clients

Blazor WebAssembly apps execute on clients and thus offload processing to clients. Blazor Server apps execute on a server, so server resource demand typically increases with the number of users and the amount of processing required per user. When it's possible to offload most or all of an app's processing to clients and the app processes a significant amount of data, Blazor WebAssembly  is the best choice.

## Additional resources

* <xref:blazor/tooling>
* <xref:blazor/project-structure>
* <xref:signalr/introduction>
* <xref:blazor/fundamentals/signalr>
* <xref:blazor/tutorials/signalr-blazor>

:::moniker-end
