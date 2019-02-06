---
title: Frequently asked questions (FAQ) about Razor Components
author: guardrex
description: Find the answers to frequently asked questions about Razor Components and Blazor.
monikerRange: '>= aspnetcore-3.0'
ms.author: riande
ms.custom: mvc
ms.date: 02/06/2019
uid: razor-components/faq
---
# Frequently asked questions (FAQ) about Razor Components

[!INCLUDE[](~/includes/razor-components-preview-notice.md)]

## What are Razor Components and Blazor?

*ASP.NET Core Razor Components* a single-page web app framework built on .NET that executes server-side in ASP.NET Core.

*Blazor* is an experimental extension of Razor Components for client-side app execution that runs in the browser with WebAssembly. Blazor provides all of the benefits of a client-side web UI framework using .NET on the client.

## I'm new to .NET. What's .NET?

[.NET](https://www.microsoft.com/net) is a free, cross-platform, open source developer platform for building many different types of apps (desktop, mobile, games, web). .NET includes a managed runtime, a standard set of [libraries](/dotnet/api), and support for multiple modern programming languages: [C#](/dotnet/csharp/), [F#](/dotnet/fsharp/), and [VB](/dotnet/visual-basic/). You can [get started with .NET in 10 min](https://www.microsoft.com/net/learn/get-started/windows).

## Why would I use .NET for web development?

Using .NET in the browser offers many advantages that can help make web development easier and more productive:

* **Stable and consistent**: .NET offers standard APIs, tools, and build infrastructure across all .NET platforms that are stable, feature rich, and easy to use.
* **Modern innovative languages**: .NET languages like [C#](/dotnet/csharp/) and [F#](/dotnet/fsharp/) make programming a joy and keep getting better with innovative new language features.
* **Industry leading tools**: The [Visual Studio](https://www.visualstudio.com/) product family provides a great .NET development experience on Windows, Linux, and macOS.
* **Fast and scalable**: .NET has a long history of performance, reliability, and security on the server. Using .NET as a full-stack solution makes it easier to scale your apps.

## How can you run .NET in a web browser?

Running .NET in the browser is made possible by a relatively new standardized web technology called [WebAssembly](http://webassembly.org/). WebAssembly is a "portable, size- and load-time-efficient format suitable for compilation to the web." Code compiled to WebAssembly can run in any browser at native speeds. To run .NET binaries in a web browser, we use a .NET runtime (specifically [Mono](http://www.mono-project.com/news/2017/08/09/hello-webassembly/)) that has been compiled to WebAssembly.

## Does Blazor compile my entire .NET-based app to WebAssembly?

No, a Blazor app consists of normal compiled .NET assemblies that are downloaded and run in a web browser using a WebAssembly-based .NET runtime. Only the .NET runtime itself is compiled to WebAssembly. That said, support for full [static ahead of time (AoT) compilation](http://www.mono-project.com/news/2018/01/16/mono-static-webassembly-compilation/) of the app to WebAssembly may be something we add further down the road.

## Wouldn't the app download size be huge if it also includes a .NET runtime?

Not necessarily. .NET runtimes come in all shapes in sizes. Early Blazor prototypes used a compact .NET runtime (including assembly execution, garbage collection, and threading) that compiled to a mere 60KB of WebAssembly. Blazor now runs on Mono, which is currently significantly larger. However, opportunities for size optimization abound, including merging and trimming the runtime and application binaries. Other potential download size mitigations include caching and using a CDN.

## What features will Razor Components and Blazor support?

Razor Components and Blazor supports all of the features of a modern single-page app framework:

* A component model for building composable UI
* Routing
* Layouts
* Forms and validation
* Dependency injection
* JavaScript interop
* Live reloading in the browser during development
* Server-side rendering
* Full .NET debugging both in browsers and in the IDE
* Rich IntelliSense and tooling
* Ability to run on older (non-WebAssembly) browsers via ASP.NET Core Razor Components
* Publishing and app size trimming

## Can I use Blazor without running .NET on the server?

Yes, a Blazor app can be deployed as a set of static files without the need for any .NET support on the server.

## Can I use Blazor with ASP.NET Core on the server?

Yes! Blazor integrates with [ASP.NET Core](/aspnet/core) on the server as *ASP.NET Core Razor Components* to provide a seamless and consistent full-stack web development solution.

## Is Blazor a .NET port of an existing JavaScript framework?

Blazor is a *new framework* inspired by existing modern single-page app frameworks, such as React, Angular, and Vue.

## How can I try out Blazor?

To build your first Blazor web app check out our [getting started guide](xref:razor-components/get-started).

## Why is Blazor an "experimental" project?

Blazor is an experimental project because there are still many questions to answer about its viability and appeal. The purposes of this initial experimental phase are to:

* Work through technical issues.
* Gauge interest and to listen to feedback.

We're optimistic about Blazor's future; but at this time, Blazor isn't a committed product and should be considered pre-alpha.

ASP.NET Core Razor Components is supported in ASP.NET Core 3.0 or later.

## Is this Silverlight all over again?

No, Blazor is a .NET web framework based on HTML and CSS that runs in the browser using open web standards. It doesn't require a plugin, and it works on mobile devices and older browsers.

## Does Blazor use XAML?

No, Blazor is a web framework based on HTML, CSS, and other standard web technologies.

## Is WebAssembly supported in all browsers?

Yes, WebAssembly has achieved cross-browser consensus and [all modern browsers now support WebAssembly](https://caniuse.com/#search=webassembly).

## Does Blazor work on mobile browsers?

Yes, [modern mobile browsers also support WebAssembly](https://caniuse.com/#search=webassembly).

## What about older browsers that don't support WebAssembly? For example, does Blazor work in IE?

For older browsers that don't support WebAssembly, use the ASP.NET Core Razor Components [server-side hosting model](xref:razor-components/hosting-models#server-side-hosting-model). Server-side Razor Components apps provide excellent compatibility and performance with older browsers.

## Can I use .NET Standard libraries?

Yes, the .NET runtime used for Blazor supports .NET Standard 2.0. APIs that aren't supported in the browser with client-side Blazor throw *Not Supported* exceptions.

## Don't you need features like garbage collection and threading added to WebAssembly to make this work?

No, WebAssembly in its current state is sufficient. The .NET runtime handles its own garbage collection and threading concerns.

## Can I use existing JavaScript libraries?

Yes, apps can call into JavaScript through JavaScript interop APIs.

## Can I access the DOM from an app?

You can access the DOM through JavaScript interop from .NET code. However, the component-based framework minimizes the need to access the DOM directly.

## Why Mono? Why not .NET Core or CoreRT?

[Mono](http://www.mono-project.com/) is a Microsoft-sponsored open source implementation of the .NET Framework. Mono is used by [Xamarin](https://www.xamarin.com/) to build native client apps for Android, iOS, and macOS. Mono is also used by [Unity](https://unity3d.com/) for game development. Microsoft's Xamarin team [announced their plans](http://www.mono-project.com/news/2017/08/09/hello-webassembly/) to add support for WebAssembly to Mono, and they've been making steady progress ([Mono and WebAssembly - Updates on Static Compilation 1/16/2018](http://www.mono-project.com/news/2018/01/16/mono-static-webassembly-compilation/)). Because Blazor is a client-side web UI framework targeted at WebAssembly, Mono is a natural fit.

By comparison, [.NET Core](https://www.microsoft.com/net/learn/get-started/windows) is primarily used for server apps and for cross-platform console apps. .NET Core can be used for creating an ASP.NET Core backend for a Blazor app but not for building the client app itself. [CoreRT](https://github.com/dotnet/corert) is a .NET Core runtime optimized for AoT compilation; and while it has WebAssembly aspirations, the project is still a work-in-progress and not a shipping product.

## Where did the name "Blazor" come from?

Blazor makes heavy use of [Razor](xref:mvc/views/razor), a markup syntax for HTML and C#. **Browser + Razor = Blazor!** When pronounced, it's also the name of a swanky jacket worn by hipsters that have excellent taste in fashion, style, and programming languages.
