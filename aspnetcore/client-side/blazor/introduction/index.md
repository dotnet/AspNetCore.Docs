---
title: Introduction to Blazor
author: guardrex
description: Learn how Blazor runs in the browser to execute C#/Razor code with WebAssembly and the Mono runtime in this introduction.
manager: wpickett
ms.author: riande
ms.custom: mvc
ms.date: 03/26/2018
ms.prod: asp.net-core
ms.technology: aspnet
ms.topic: article
uid: client-side/blazor/introduction/index
---
# Introduction to Blazor

By [Steve Sanderson](http://blog.stevensanderson.com), [Daniel Roth](https://github.com/danroth27), and [Luke Latham](https://github.com/guardrex)

[!INCLUDE[](~/includes/blazor-preview-notice.md)]

Blazor is an experimental .NET web framework using C#/Razor and HTML that runs in the browser with [WebAssembly](http://webassembly.org). Blazor provides all of the benefits of a client-side web UI framework using .NET on both the server and the client.

## Why use .NET for client-side apps?

Web development has improved in many ways over the years, but building modern web apps still poses challenges. Using .NET in the browser offers many advantages that can help make web development easier and more productive: 

* Stability and consistency: .NET provides standardized programming frameworks across platforms that are stable, feature-rich, and easy to use.
* Modern innovative languages: .NET languages are constantly improving with innovative new language features.
* Industry-leading tools: The Visual Studio product family provides a fantastic .NET development experience across platforms on Windows, Linux, and macOS.
* Speed and scalability: .NET has a strong history of performance, reliability, and security for app development. Using .NET as a full-stack solution makes it easier to build fast, reliable, and secure apps.
* Full-stack development that leverages existing skills: C#/Razor developers use their existing C#/Razor skills to write client-side code and share server and client-side logic among apps.
* Wide browser support: Blazor runs on .NET using open web standards in the browser with no plugins and no code transpilation. It works in all modern web browsers, including mobile browsers.

## Running .NET in the browser

Running .NET code inside web browsers is made possible by a relatively new technology, WebAssembly (abbreviated *wasm*). WebAssembly is an open web standard and is supported in web browsers without plugins. WebAssembly is a compact bytecode format optimized for fast download and maximum execution speed.

Security isn't a major concern because WebAssembly isn't ordinary assembly code (for example, x86/x64)&mdash;WebAssembly is a new bytecode format that accesses browser functionality with the same capabilities as JavaScript.

When a Blazor app is built and run in a browser:

1. C# code files and Razor files are compiled into .NET assemblies.
1. The assemblies and the .NET runtime are downloaded to the browser.
1. Blazor uses JavaScript to bootstrap the .NET runtime and configures the runtime to load required assembly references. Document object model (DOM) manipulation and browser API calls are handled by the Blazor runtime via JavaScript interoperability.

## Browsers that don't support WebAssembly

The .NET runtime is supplied as a WebAssembly binary and an [asm.js](https://wikipedia.org/wiki/Asm.js)-based implementation. *asm.js* is a subset of JavaScript and can be executed by JavaScript runtimes in browsers going back several years. When Blazor loads in the browser, it checks for WebAssembly support. If WebAssembly isn't supported, the *asm.js* runtime is loaded. *asm.js* isn't always used because it's larger and slower than the WebAssembly runtime.

## Blazor components

In client-side web UI frameworks, apps are built with *components*. A component usually represents a piece of UI, such as a page, dialog, or data entry form. Components can be nested, reused, and shared between projects.

In Blazor, a component is a .NET class. The class can either be written directly, as a C# class (*\*.cs*), or more commonly in the form of a Razor markup page (*\*.cshtml*).

Many design patterns are possible using [Razor](xref:mvc/views/razor) as a foundation for Blazor. Razor is a syntax for combining HTML markup with C# code. Razor is designed for developer productivity, allowing the developer to switch between markup and C# in the same file with IntelliSense support. The following markup is an example of a basic custom dialog component in a Razor file:

```cshtml
<div>
    <h2>@Title</h2>
    @RenderContent(Body)
    <button onclick=@OnOK>OK</button>
</div>

@functions {
    public string Title { get; set; }
    public Content Body { get; set; }
    public Action OnOK { get; set; }
}
```

When this component is used elsewhere in the app, IntelliSense speeds development with syntax completion and parameter info.

Components can be:

* Nested.
* Generated procedurally in code.
* Shared via class libraries.
* Unit tested without requiring a browser DOM.

## Infrastructure

Blazor offers the core facilities that most apps require, including:

* Layouts
* Routing
* Dependency injection
* Lazy loading (loading parts of the app on demand as a user navigates the app)
* Unit testing

All of these features are optional. When one of these features isn't used in an app, the implementation is stripped out of the app when published by the IL linker.

A few low-level elements are included in the framework. For example, routing and layouts aren't built-in. Routing and layouts are implemented in *user space*, code that an app developer can write without using internal APIs. These features can be replaced with different systems to suit the app's requirements. The current layouts prototype is implemented in about 30 lines of C# code, so a developer can understand and replace it if desired.

## Code sharing and .NET Standard

The [.NET Standard](/dotnet/standard/net-standard) is a formal specification of .NET APIs that are intended to be available on all .NET implementations. Mono on WebAssembly supports `netstandard2.0` or higher. .NET Standard class libraries can be shared across server code and in browser-based apps.

Browsers support the APIs that developers use to build web apps. Not all .NET APIs are callable from the browser. For example, arbitrary TCP sockets can't be accessed in a browser, so [System.Net.Sockets.TcpListener](/dotnet/api/system.net.sockets.tcplistener) can't perform any useful task. For BCL APIs that don't apply to a given platform, the BCL throws a [PlatformNotSupported](/dotnet/api/system.platformnotsupportedexception) exception.

## JavaScript/TypeScript interop

For apps that require third-party JavaScript libraries and browser APIs, WebAssembly is designed to interoperate with JavaScript. Blazor is capable of using any library or API that JavaScript is able to use. The Mono team is working on a library that exposes standard browser APIs to .NET.

## Optimization

Traditionally, .NET has focused on platforms where the app's binary size isn't a major concern. It doesn't really matter whether a server-side ASP.NET app is 1MB or 50MB. It's only a moderate concern for native desktop or mobile apps. But for client-side apps, payload size is critical.

Development efforts are aimed at reducing the download size of the Mono runtime and .NET app assemblies. Here are three phases of size optimization the Blazor engineering team has in mind:

1. Mono runtime stripping

   The Mono runtime contains many desktop-specific features. We hope that the Blazor packages will contain a trimmed version of Mono that is substantially smaller than the full-fat distribution. In an optimization experiment, the Mono runtime was pruned of unnecessary code. Over 70% of the Mono *wasm* file was removed while keeping a basic app working.

1. Publish-time IL stripping

   The .NET IL linker (originally based on the Mono linker) performs static analysis to determine which parts of .NET assemblies can ever get called by an app, then it strips out everything else.

   This is equivalent to *tree shaking* in JavaScript, except the IL linker is much more fine-grained, operating at the level of individual methods. The IL Linker removes all of the system library code that the app isn't using, which often results in a 70% or greater reduction in code size.

1. Compression

   Most web servers support HTTP compression, which typically cuts the remaining payload size by a further 75%.

Overall, a .NET-based client-side app is never going to be as tiny as a minimal React app, but the goal is to make it small enough that a typical user with average Internet bandwidth won't notice or care about an app's first load time. After first load, the app's assemblies are fully cached.

## Deployment

Developers have the option of using Blazor for only client-side development or for full-stack .NET development. Full-stack development offers many advantages&mdash;client- and server-side development uses the same tooling, build infrastructure, and language. Code can be shared between client and server apps.

For ASP.NET Core, [middleware](xref:fundamentals/middleware/index) offers an easy path to serve a Blazor UI seamlessly from an ASP.NET Core app. Equally important are developers who don't yet use ASP.NET Core. To make Blazor a viable consideration for developers using Node.js, Rails, PHP, or even for serverless web apps, ASP.NET Core isn't required on the server. When a Blazor app is built, a *dist* directory is produced containing nothing but static files. The contents of the *dist* folder can be hosted on the Azure CDN, GitHub Pages, Node.js servers, and many other servers and services.
