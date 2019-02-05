---
title: Introduction to ASP.NET Core Razor Components
author: guardrex
description: Explore ASP.NET Core Razor Components, a .NET web framework using C#/Razor and HTML.
monikerRange: '>= aspnetcore-3.0'
ms.author: riande
ms.custom: mvc
ms.date: 02/05/2019
uid: razor-components/index
---
# Introduction to ASP.NET Core Razor Components

By [Steve Sanderson](http://blog.stevensanderson.com), [Daniel Roth](https://github.com/danroth27), and [Luke Latham](https://github.com/guardrex)

[!INCLUDE[](~/includes/razor-components-preview-notice.md)]

*ASP.NET Core Razor Components* is a .NET web framework using C#/Razor and HTML. *Blazor* is the client-side hosting model of Razor Components.

Web development has improved over the years, but building modern web apps still poses challenges. Razor Components provides advantages to help make web development easier and more productive:

* **Stability and consistency**: .NET provides standardized programming frameworks across platforms that are stable, feature-rich, and easy to use.
* **Modern innovative languages**: .NET languages are constantly improving with innovative new language features.
* **Industry-leading tools**: The Visual Studio product family provides a fantastic .NET development experience across platforms on Windows, Linux, and macOS.
* **Speed and scalability**: .NET has a strong history of performance, reliability, and security for app development. Using .NET as a full-stack solution makes it easier to build fast, reliable, and secure apps.
* **Full-stack development that leverages existing skills**: C#/Razor developers use their existing skills to write client-side code and share server and client-side logic among apps.
* **Wide browser support**: Razor Components render the UI as HTML markup and JavaScript. Blazor runs on .NET in the browser using open web standards without plugins or code transpilation. Blazor works in all modern web browsers, including mobile browsers.

## Components

Apps are built with *components*. A component is a piece of UI, such as a page, dialog, or data entry form. Components can be nested, reused, and shared between projects.

A *component* is a .NET class. The class can either be written in the form of a Razor markup page (*.cshtml*) or as a C# class (*.cs*).

[Razor](/aspnet/core/mvc/views/razor) is a syntax for combining HTML markup with C# code. Razor is designed for developer productivity, allowing the developer to switch between markup and C# in the same file with [IntelliSense](/visualstudio/ide/using-intellisense) support. The following markup is an example of a custom dialog component in a Razor file (*DialogComponent.cshtml*):

```cshtml
<div>
    <h2>@Title</h2>
    @BodyContent
    <button onclick=@OnOK>OK</button>
</div>

@functions {
    public string Title { get; set; }
    public RenderFragment BodyContent { get; set; }
    public Action OnOK { get; set; }
}
```

When this component is used elsewhere in the app, IntelliSense speeds development with syntax and parameter completion.

Components can be:

* Nested.
* Created with Razor (*.cshtml*) or C# (*.cs*) code.
* Shared via class libraries.
* Unit tested without requiring a browser DOM.

## Hosting models

### Server-side hosting model

Because Razor Components decouple a component's rendering logic from how UI updates are applied, there's flexibility in how Razor Components can be hosted. ASP.NET Core Razor Components in .NET Core 3.0 adds support for hosting Razor Components on the server in an ASP.NET Core app. UI updates are handled over a SignalR connection.

The runtime:

* Handles sending UI events from the browser to the server.
* Applies UI updates sent by the server back to the browser after running the components.

The connection used by Razor Components to communicate with the browser is also used to handle JavaScript interop calls.

![Razor Components runs .NET code on the server and interacts with the Document Object Model on the client over a SignalR connection](index/_static/aspnet-core-razor-components.png)

For more information, see <xref:razor-components/hosting-models#server-side-hosting-model>.

### Client-side hosting model

Running .NET code inside web browsers is made possible by a relatively new technology, [WebAssembly](http://webassembly.org) (abbreviated *wasm*). WebAssembly is an open web standard and supported in web browsers without plugins. WebAssembly is a compact bytecode format optimized for fast download and maximum execution speed.

WebAssembly code can access the full functionality of the browser via JavaScript interop. At the same time, WebAssembly code runs in the same trusted sandbox as JavaScript to prevent malicious actions on the client machine.

![Blazor runs .NET code in the browser with WebAssembly.](index/_static/blazor.png)

When a Blazor app is built and run in a browser:

* C# code files and Razor files are compiled into .NET assemblies.
* The assemblies and the .NET runtime are downloaded to the browser.
* Blazor uses JavaScript to bootstrap the .NET runtime and configures the runtime to load assemblies. Document Object Model (DOM) manipulation and browser API calls are handled by the Blazor runtime via JavaScript interop.

To support older browsers that don't support WebAssembly, use the [server-side hosting model](#server-side-hosting-model).

For more information, see <xref:razor-components/hosting-models#client-side-hosting-model>.

## Infrastructure

Core facilities that most apps require are provided by the framework, including:

* Layouts
* Routing
* Dependency injection

These scenarios are optional. When one of these scenarios isn't used by a Blazor app, the implementation is stripped out of the app when it's published by the [Intermediate Language (IL) Linker](xref:host-and-deploy/razor-components/configure-linker).

## Code sharing and .NET Standard

Apps can reference and use existing [.NET Standard](/dotnet/standard/net-standard) libraries. .NET Standard is a formal specification of .NET APIs that are common across .NET implementations. .NET Standard 2.0 or higher is supported. APIs that aren't applicable inside a web browser (for example, accessing the file system, opening a socket, threading, and other features) throw [PlatformNotSupportedException](/dotnet/api/system.platformnotsupportedexception). .NET Standard class libraries can be shared across server code and in browser-based apps.

## JavaScript interop

For apps that require third-party JavaScript libraries and browser APIs, Razor Components interoperate with JavaScript. Razor Components are capable of using any library or API that JavaScript is able to use. C# code can call into JavaScript code, and JavaScript code can call into C# code. For more information, see [JavaScript interop](xref:razor-components/javascript-interop).

## Optimization

Payload size is a critical performance factor for an app's useability. Blazor optimizes payload size to reduce download times:

* Unused parts of .NET assemblies are removed during the build process.
* HTTP responses are compressed.
* The .NET runtime and assemblies are cached in the browser.

Server-side Razor Components provides an even smaller payload size than Blazor by maintaining .NET assemblies, the app's assembly, and the runtime server-side. Razor Components apps only serve markup files and static assets to clients.

## Deployment

Build and deploy apps using either of two hosting models:

* In a **Razor Components full-stack ASP.NET Core app**, host the app on any cloud or on-premise host supported by ASP.NET Core.
* In a **standalone client-side Blazor app**, the app is compiled into a *dist* folder that only contains static files. Host the files on Azure App Service, GitHub Pages, IIS (configured as a static file server), Node.js, or any other server or service capable of serving static files. .NET isn't required on the server in production.

For more information, see <xref:host-and-deploy/razor-components/index>.

## Suggest a feature or file a bug report

To make suggestions and file bug reports on Razor Components, [open an issue at the aspnet/AspNetCore GitHub repository](https://github.com/aspnet/AspNetCore/issues/new). For general help and assistance from the community, join the conversation on [Gitter](https://gitter.im/aspnet/Blazor). To provide feedback on documentation, open an aspnet/Docs GitHub repository issue using the **Content feedback** button at the bottom of any topic.

## Additional resources

* [WebAssembly](http://webassembly.org/)
* [C# Guide](/dotnet/csharp/)
* [Razor](/aspnet/core/mvc/views/razor)
* [HTML](https://www.w3.org/html/)
