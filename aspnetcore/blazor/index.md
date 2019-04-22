---
title: Introduction to Blazor in ASP.NET Core
author: guardrex
description: Explore ASP.NET Core Blazor, a way to build interactive client-side web UI with .NET in an ASP.NET Core app.
monikerRange: '>= aspnetcore-3.0'
ms.author: riande
ms.custom: "mvc, seoapril2019"
ms.date: 04/22/2019
uid: blazor/index
---
# Introduction to Blazor

By [Daniel Roth](https://github.com/danroth27) and [Luke Latham](https://github.com/guardrex)

*Welcome to Blazor!*

Blazor is a framework for building interactive client-side web UI with .NET:

* Create rich interactive UIs using C# instead of JavaScript.
* Share server-side and client-side app logic written with .NET.
* Render the UI as HTML and CSS for wide browser support, including mobile browsers.

Using .NET for client-side web development offers the following advantages:

* Write code in C# instead of JavaScript.
* Leverage the existing .NET ecosystem of .NET libraries.
* Share app logic across the server and client.
* Benefit from .NET's performance, reliability, and security.
* Stay productive with Visual Studio on Windows, Linux, and macOS.
* Build on a common set of languages, frameworks, and tools that are stable, feature-rich, and easy to use.

## Components

Blazor apps are based on *components*. A component in Blazor is an element of UI, such as a page, dialog, or data entry form. Components handle user events and define flexible UI rendering logic. Components can be nested and reused.

Components are .NET classes built into .NET assemblies that can be shared and distributed as [NuGet packages](/nuget/what-is-nuget). The component class is usually written in the form of a Razor markup page with a *.razor* file extension.

Components in Blazor are sometimes referred to as *Razor components*. [Razor](xref:mvc/views/razor) is a syntax for combining HTML markup with C# code designed for developer productivity. Razor allows you to switch between HTML markup and C# in the same file with [IntelliSense](/visualstudio/ide/using-intellisense) support. Razor Pages and MVC also use Razor. Unlike Razor Pages and MVC, which are built around a request/response model, components are used specifically for client-side UI logic and composition.

The following Razor markup demonstrates a component (*Dialog.razor*), which can be nested within another component:

```cshtml
<div>
    <h1>@Title</h1>

    @ChildContent

    <button onclick="@OnYes">Yes!</button>
</div>

@functions {
    [Parameter]
    public string Title { get; set; }

    [Parameter]
    public RenderFragment ChildContent { get; set; }

    private void OnYes()
    {
        Console.WriteLine("Write to the console in C#!");
    }
}
```

The dialog's body content (`ChildContent`) and title (`Title`) are provided by the component that uses this component in its UI. `OnYes` is a C# method triggered by the button's `onclick` event.

Blazor uses natural HTML tags for UI composition. HTML elements specify components, and a tag's attributes pass values to a component's properties. `ChildContent` and `Title` are set by the component that uses the Dialog component (*Index.razor*):

```cshtml
@page "/"

<h1>Hello, world!</h1>

Welcome to your new app.

<Dialog Title="Blazor">
    Do you want to <i>learn more</i> about Blazor?
</Dialog>
```

The dialog is rendered when the parent (*Index.razor*) is accessed in a browser:

![Dialog component rendered in the browser](index/_static/dialog.png)

When this component is used in the app, IntelliSense in [Visual Studio](/visualstudio/ide/using-intellisense) and [Visual Studio Code](https://code.visualstudio.com/docs/editor/intellisense) speeds development with syntax and parameter completion.

Components render into an in-memory representation of the browser DOM called a *render tree* that's used to update the UI in a flexible and efficient way.

## Blazor client-side

Blazor client-side is a single-page app framework for building interactive client-side web apps with .NET. Blazor client-side uses open web standards without plugins or code transpilation and works in all modern web browsers, including mobile browsers.

Running .NET code inside web browsers is made possible by [WebAssembly](http://webassembly.org) (abbreviated *wasm*). WebAssembly is an open web standard and supported in web browsers without plugins. WebAssembly is a compact bytecode format optimized for fast download and maximum execution speed.

WebAssembly code can access the full functionality of the browser via JavaScript, called *JavaScript interoperability* (or *JavaScript interop*). .NET code executed via WebAssembly in the browser runs in the same trusted sandbox as JavaScript, which virtually eliminates the opportunity for an app to perform malicious actions on the client machine.

![Blazor client-side runs .NET code in the browser with WebAssembly.](index/_static/blazor-client-side.png)

When a Blazor client-side app is built and run in a browser:

* C# code files and Razor files are compiled into .NET assemblies.
* The assemblies and the .NET runtime are downloaded to the browser.
* Blazor client-side bootstraps the .NET runtime and configures the runtime to load the assemblies for the app. The Blazor client-side runtime uses JavaScript interop to handle Document Object Model (DOM) manipulation and browser API calls.

The size of the published app, its *payload size*, is a critical performance factor for an app's useability. A large app takes a relatively long time to download to a browser, which hurts the user experience. Blazor client-side optimizes payload size to reduce download times:

* Unused code is stripped out of the app when it's published by the [Intermediate Language (IL) Linker](xref:host-and-deploy/blazor/configure-linker).
* HTTP responses are compressed.
* The .NET runtime and assemblies are cached in the browser.

For more information and guidance on choosing a hosting model, see <xref:blazor/hosting-models>.

## Blazor server-side

Blazor decouples component rendering logic from how UI updates are applied. Blazor server-side provides support for hosting Razor components on the server in an ASP.NET Core app. UI updates are handled over a [SignalR](xref:signalr/introduction) connection.

The runtime handles sending UI events from the browser to the server and applies UI updates sent by the server back to the browser after running the components.

The connection used by Blazor server-side to communicate with the browser is also used to handle JavaScript interop calls.

![Blazor server-side runs .NET code on the server and interacts with the Document Object Model on the client over a SignalR connection](index/_static/blazor-server-side.png)

For more information and guidance on choosing a hosting model, see <xref:blazor/hosting-models>.

## JavaScript interop

For apps that require third-party JavaScript libraries and browser APIs, components interoperate with JavaScript. Components are capable of using any library or API that JavaScript is able to use. C# code can call into JavaScript code, and JavaScript code can call into C# code. For more information, see <xref:blazor/javascript-interop>.

## Code sharing and .NET Standard

Apps can use [.NET Standard](/dotnet/standard/net-standard) libraries. .NET Standard is a formal specification of .NET APIs that are common across .NET implementations. Blazor implements .NET Standard 2.0. APIs that aren't applicable inside a web browser (for example, accessing the file system, opening a socket, and threading) throw a <xref:System.PlatformNotSupportedException>. .NET Standard class libraries can be shared across different .NET platforms, such as Blazor, .NET Framework, .NET Core, Xamarin, Mono, and Unity.

## Additional resources

* [WebAssembly](http://webassembly.org/)
* [C# Guide](/dotnet/csharp/)
* <xref:mvc/views/razor>
* [HTML](https://www.w3.org/html/)
