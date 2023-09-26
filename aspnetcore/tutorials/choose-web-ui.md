---
title: Choose an ASP.NET Core UI
author: wadepickett
description: Learn when to use which ASP.NET Core web UI technologies. Understand the server, client and hybrid options.
ms.author: wpickett
ms.date: 12/29/2022
uid: tutorials/choose-web-ui
---
# Choose an ASP.NET Core web UI

ASP.NET Core is a complete UI framework. Choose which functionalities to combine that fit the app's web UI needs.

## Benefits vs. costs of server and client rendered UI

There are three general approaches to building modern web UI with ASP.NET Core:

* Apps that render UI from the server.
* Apps that render UI on the client in the browser.
* Hybrid apps that take advantage of both server and client UI rendering approaches. For example, most of the web UI is rendered on the server, and client rendered components are added as needed.

There are benefits and drawbacks to consider when rendering UI on the server or on the client.

### Server rendered UI

A web UI app that renders on the server dynamically generates the page's HTML and CSS on the server in response to a browser request. The page arrives at the client ready to display.

Benefits:

* The client requirements are minimal because the server does the work of logic and page generation:
  * Great for low-end devices and low-bandwidth connections.
  * Allows for a broad range of browser versions at the client.
  * Quick initial page load times.
  * Minimal to no JavaScript to pull to the client.
* Flexibility of access to protected server resources:
  * Database access.
  * Access to secrets, such as values for API calls to Azure storage.
* Static site analysis advantages, such as search engine optimization.

Examples of common server rendered web UI app scenarios:

* Dynamic sites such as those that provide personalized pages, data, and forms.
* Display read-only data such as transaction lists. 
* Display static blog pages.
* A public-facing content management system.

Drawbacks:

* The cost of compute and memory use are concentrated on the server, rather than each client.
* User interactions require a round trip to the server to generate UI updates.

### Client rendered UI

A client rendered app dynamically renders web UI on the client, directly updating the browser DOM as necessary.

Benefits:

* Allows for rich interactivity that is nearly instant, without requiring a round trip to the server. UI event handling and logic run locally on the user's device with minimal latency. 
* Supports incremental updates, saving partially completed forms or documents without the user having to select a button to submit a form.
* Can be designed to run in a disconnected mode. Updates to the client-side model are eventually synchronized back to the server once a connection is re-established.
* Reduced server load and cost, the work is offloaded to the client. Many client rendered apps can also be hosted as static websites.
* Takes advantage of the capabilities of the user’s device.

Examples of client rendered web UI:

* An interactive dashboard.
* An app featuring drag-and-drop functionality
* A responsive and collaborative social app.

Drawbacks:

* Code for the logic has to be downloaded and executed on the client, adding to the initial load time.
* Client requirements may exclude users who have low-end devices, older browser versions, or low-bandwidth connections.

## Choose a server rendered ASP.NET Core UI solution

The following section explains the ASP.NET Core web UI server rendered models available and provides links to get started. ASP.NET Core Razor Pages and ASP.NET Core MVC are server-based frameworks for building web apps with .NET.

### ASP.NET Core Razor Pages

Razor Pages is a page-based model. UI and business logic concerns are kept separate, but within the page. Razor Pages is the recommended way to create new page-based or form-based apps for developers new to ASP.NET Core. Razor Pages provides an easier starting point than ASP.NET Core MVC.

Razor Pages benefits, in addition to the server rendering benefits:

* Quickly build and update UI. Code for the page is kept with the page, while keeping UI and business logic concerns separate.
* Testable and scales to large apps.
* Keep your ASP.NET Core pages organized in a simpler way than ASP.NET MVC:
  * View specific logic and view models can be kept together in their own namespace and directory.
  * Groups of related pages can be kept in their own namespace and directory.

To get started with your first ASP.NET Core Razor Pages app, see <xref:tutorials/razor-pages/razor-pages-start>. For a complete overview of ASP.NET Core Razor Pages, its architecture and benefits, see: <xref:razor-pages/index>.

### ASP.NET Core MVC

ASP.NET MVC renders UI on the server and uses a Model-View-Controller (MVC) architectural pattern. The MVC pattern separates an app into three main groups of components: Models, Views, and Controllers. User requests are routed to a controller. The controller is responsible for working with the model to perform user actions or retrieve results of queries. The controller chooses the view to display to the user, and provides it with any model data it requires. Support for Razor Pages is built on ASP.NET Core MVC.

MVC benefits, in addition to the server rendering benefits:

* Based on a scalable and mature model for building large web apps.
* Clear [separation of concerns](/dotnet/standard/modern-web-apps-azure-architecture/architectural-principles#separation-of-concerns) for maximum flexibility.
* The Model-View-Controller separation of responsibilities ensures that the business model can evolve without being tightly coupled to low-level implementation details.

To get started with  ASP.NET Core MVC, see <xref:tutorials/first-mvc-app/start-mvc>. For an overview of ASP.NET Core MVC's architecture and benefits, see <xref:mvc/overview>.

### Server-side Blazor

Blazor is a framework for building interactive client-side web UI with [.NET](/dotnet/standard/tour):

* Create rich interactive UIs using [C#](/dotnet/csharp/) instead of [JavaScript](https://www.javascript.com).
* Share server-side and client-side app logic written in .NET.
* Render the UI as HTML and CSS for wide browser support, including mobile browsers.
* Integrate with modern hosting platforms, such as [Docker](/dotnet/standard/microservices-architecture/container-docker-introduction/index).
* Build hybrid desktop and mobile apps with .NET and Blazor.

Using .NET for client-side web development offers the following advantages:

* Write code in C# instead of JavaScript.
* Leverage the existing .NET ecosystem of [.NET libraries](/dotnet/standard/class-libraries).
* Share app logic across server and client.
* Benefit from .NET's performance, reliability, and security.
* Stay productive on Windows, Linux, or macOS with a development environment, such as [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/).
* Build on a common set of languages, frameworks, and tools that are stable, feature-rich, and easy to use.

Server-side Blazor provides support for hosting server-rendered UI in an ASP.NET Core app. Client UI updates are handled over a [SignalR](xref:signalr/introduction) connection. The runtime stays on the server and handles executing the app's C# code.

For more information, see <xref:blazor/index> and <xref:blazor/hosting-models>. The client-side Blazor hosting model is described in the [Blazor WebAssembly](#blazor-webassembly) section later in this article.

## Choose a client rendered ASP.NET Core solution

The following section briefly explains the ASP.NET Core web UI client rendered models available and provides links to get started.

### Blazor WebAssembly

Blazor WebAssembly is a [single-page app (SPA) framework](/dotnet/architecture/modern-web-apps-azure/choose-between-traditional-web-and-single-page-apps) for building interactive client-side web apps with the general characteristics described in the [Server-side Blazor](#server-side-blazor) section earlier in this article.

Running .NET code inside web browsers is made possible by [WebAssembly](https://webassembly.org) (abbreviated `wasm`). WebAssembly is a compact bytecode format optimized for fast download and maximum execution speed. WebAssembly is an open web standard and supported in web browsers without plugins. Blazor WebAssembly works in all modern web browsers, including mobile browsers.

When a Blazor WebAssembly app is built and run:

* C# code files and Razor files are compiled into .NET assemblies.
* The assemblies and the [.NET runtime](/dotnet/framework/get-started/overview) are downloaded to the browser.
* Blazor WebAssembly bootstraps the .NET runtime and configures the runtime to load the assemblies for the app. The Blazor WebAssembly runtime uses JavaScript interop to handle DOM manipulation and browser API calls.

For more information, see <xref:blazor/index> and <xref:blazor/hosting-models>. The server-side Blazor hosting model is described in the [Server-side Blazor](#server-side-blazor) section earlier in this article.

### ASP.NET Core Single Page Application (SPA) with JavaScript Frameworks such as Angular and React

Build client-side logic for ASP.NET Core apps using popular JavaScript frameworks, like [Angular](https://angular.io/) or [React](https://facebook.github.io/react/). ASP.NET Core provides project templates for Angular and React, and can be used with other JavaScript frameworks as well.

Benefits of ASP.NET Core SPA with JavaScript Frameworks, in addition to the client rendering benefits previously listed:

* The JavaScript runtime environment is already provided with the browser.
* Large community and mature ecosystem.
* Build client-side logic for ASP.NET Core apps using popular JS frameworks, like Angular and React.

Downsides:

* More coding languages, frameworks, and tools required.
* Difficult to share code so some logic may be duplicated.

To get started, see:

* <xref:spa/angular>
* <xref:spa/react>

## Choose a hybrid solution: ASP.NET Core MVC or Razor Pages plus Blazor

MVC, Razor Pages, and Blazor are part of the ASP.NET Core framework and are designed to be used together. Razor components can be integrated into Razor Pages and MVC apps. When a view or page is rendered, components can be prerendered at the same time.

Benefits for MVC or Razor Pages plus Blazor, in addition to MVC or Razor Pages benefits:

* Prerendering executes Razor components on the server and renders them into a view or page, which improves the perceived load time of the app.
* Add interactivity to existing views or pages with the [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper).

:::moniker range=">= aspnetcore-8.0"

To get started with ASP.NET Core MVC or Razor Pages plus Blazor, see <xref:blazor/components/integration>.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

To get started with ASP.NET Core MVC or Razor Pages plus Blazor, see <xref:blazor/components/prerendering-and-integration>.

:::moniker-end

## Next steps

For more information, see:

:::moniker range=">= aspnetcore-8.0"

* <xref:blazor/index>
* <xref:blazor/hosting-models>
* <xref:blazor/components/integration>
* <xref:grpc/comparison>

:::moniker-end

:::moniker range="< aspnetcore-8.0"

* <xref:blazor/index>
* <xref:blazor/hosting-models>
* <xref:blazor/components/prerendering-and-integration>
* <xref:grpc/comparison>

:::moniker-end
