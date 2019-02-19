---
title: Introduction to Blazor
author: guardrex
description: Explore ASP.NET Core Blazor, a new way to build interactive client-side apps with .NET that run in the browser with WebAssembly.
monikerRange: '>= aspnetcore-3.0'
ms.author: riande
ms.custom: mvc
ms.date: 02/11/2019
uid: spa/blazor/index
---
# Introduction to Blazor

By [Daniel Roth](https://github.com/danroth27) and [Luke Latham](https://github.com/guardrex)

[!INCLUDE[](~/includes/razor-components-preview-notice.md)]

Blazor is a single-page app framework for building interactive client-side Web apps with .NET. Blazor uses open web standards without plugins or code transpilation. Blazor works in all modern web browsers, including mobile browsers.

Using .NET in the browser for client-side web development offers many advantages:

* **C# language**: Write code in C# instead of JavaScript.
* **.NET Ecosystem**: Leverage the existing ecosystem of .NET libraries.
* **Full-stack development**: Share server and client-side logic.
* **Speed and scalability**: .NET was built for performance, reliability, and security.
* **Industry-leading tools**: Stay productive with Visual Studio on Windows, Linux, and macOS.
* **Stability and consistency**:  Build on a commonset of languages, frameworks, and tools that are stable, feature-rich, and easy to use.

Running .NET code inside web browsers is made possible by [WebAssembly](http://webassembly.org) (abbreviated *wasm*). WebAssembly is an open web standard and supported in web browsers without plugins. WebAssembly is a compact bytecode format optimized for fast download and maximum execution speed.

WebAssembly code can access the full functionality of the browser via JavaScript interop. At the same time, .NET code executed via WebAssembly runs in the same trusted sandbox as JavaScript to prevent malicious actions on the client machine.

![Blazor runs .NET code in the browser with WebAssembly.](index/_static/blazor.png)

When a Blazor app is built and run in a browser:

* C# code files and Razor files are compiled into .NET assemblies.
* The assemblies and the .NET runtime are downloaded to the browser.
* Blazor bootstraps the .NET runtime and configures the runtime to load the assemblies for the app. Document Object Model (DOM) manipulation and browser API calls are handled by the Blazor runtime via JavaScript interop.

Blazor supports core facilities required by most apps, including:

* Parameters
* Event handling
* Data binding
* Routing
* Dependency injection
* Layouts
* Templating
* Cascading values

To reduce the size of the downloaded app unused code stripped out of the app when it's published by the [Intermediate Language (IL) Linker](xref:host-and-deploy/razor-components/configure-linker).

Blazor is the client-side hosting model for Razor Components. Because Razor Components decouple a component's rendering logic from how UI updates are applied, there's flexibility in how Razor Components can be hosted. Use ASP.NET Core Razor Components to host Razor Components on the server in an ASP.NET Core app where UI updates are handled over a SignalR connection. For more information, see <xref:razor-components/hosting-models#server-side-hosting-model>. 

## Components

A *Razor Component* is a piece of UI, such as a page, dialog, or data entry form. Components handle user events and define flexible UI rendering logic. Components can be nested and reused.

Components are .NET classes built into .NET assemblies that can be shared and distributed as NuGet packages. The class can either be written in the form of a Razor markup page (*.cshtml*) or as a C# class (*.cs*).

[Razor](xref:mvc/views/razor) is a syntax for combining HTML markup with C# code. Razor is designed for developer productivity, allowing the developer to switch between markup and C# in the same file with [IntelliSense](/visualstudio/ide/using-intellisense) support. Razor Pages and MVC views also use Razor. Unlike Razor Pages and MVC views, which are built around a request/response model, components are used specifically for handling UI composition. Razor Components can be used specifically for client-side UI logic and composition.

The following markup is an example of a custom dialog component in a Razor file (*DialogComponent.cshtml*):

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

Components render into an in-memory representation of the browser DOM called a *render tree* that can then be used to update the UI in a flexible and efficient way.

## JavaScript interop

For apps that require third-party JavaScript libraries and browser APIs, Blazor interoperates with JavaScript. Components are capable of using any library or API that JavaScript is able to use. C# code can call into JavaScript code, and JavaScript code can call into C# code. For more information, see [JavaScript interop](xref:razor-components/javascript-interop).

## Code sharing and .NET Standard

Apps can reference and use existing [.NET Standard](/dotnet/standard/net-standard) libraries. .NET Standard is a formal specification of .NET APIs that are common across .NET implementations. .NET Standard 2.0 or higher is supported. APIs that aren't applicable inside a web browser (for example, accessing the file system, opening a socket, threading, and other features) throw <xref:System.PlatformNotSupportedException>. .NET Standard class libraries can be shared across server code and in browser-based apps.

## Optimization

Payload size is a critical performance factor for an app's useability. Blazor optimizes payload size to reduce download times:

* Unused parts of .NET assemblies are removed during the build process.
* HTTP responses are compressed.
* The .NET runtime and assemblies are cached in the browser.

[Server-side Razor Components](xref:razor-components/index) provides an even smaller payload size than Blazor by maintaining .NET assemblies, the app's assembly, and the runtime server-side. Razor Components apps only serve markup files and static assets to clients.

## Additional resources

* <xref:razor-components/index>
* [WebAssembly](http://webassembly.org/)
* [C# Guide](/dotnet/csharp/)
* <xref:mvc/views/razor>
* [HTML](https://www.w3.org/html/)
