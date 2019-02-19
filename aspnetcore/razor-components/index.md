---
title: Introduction to Razor Components
author: guardrex
description: Explore ASP.NET Core Razor Components, a way to build interactive client-side web UI with .NET in an ASP.NET Core app.
monikerRange: '>= aspnetcore-3.0'
ms.author: riande
ms.custom: mvc
ms.date: 02/12/2019
uid: razor-components/index
---
# Introduction to Razor Components

By [Daniel Roth](https://github.com/danroth27) and [Luke Latham](https://github.com/guardrex)

*Razor Components* is a way to build interactive client-side web UI with .NET:

* Build rich interactive UIs using C# instead of JavaScript.
* Share server-side and client-side app logic all written with .NET.
* Render the UI as HTML and CSS for wide browser support, including mobile browsers.

Razor Components supports core facilities required by most apps, including:

* Parameters
* Event handling
* Data binding
* Routing
* Dependency injection
* Layouts
* Templating
* Cascading values

Razor Components decouples component rendering logic from how UI updates are applied. ASP.NET Core Razor Components in .NET Core 3.0 adds support for hosting Razor Components on the server in an ASP.NET Core app. UI updates are handled over a SignalR connection.

The runtime:

* Handles sending UI events from the browser to the server.
* Applies UI updates sent by the server back to the browser after running the components.

The connection used by Razor Components to communicate with the browser is also used to handle JavaScript interop calls.

![Razor Components runs .NET code on the server and interacts with the Document Object Model on the client over a SignalR connection](index/_static/aspnet-core-razor-components.png)

For more information, see <xref:razor-components/hosting-models#server-side-hosting-model>.

*Blazor* is the experimental client-side hosting model of Razor Components. Blazor runs on .NET in the browser using open web standards without plugins or code transpilation. For more information, see <xref:razor-components/hosting-models#client-side-hosting-model>.

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

For apps that require third-party JavaScript libraries and browser APIs, components interoperate with JavaScript. Components are capable of using any library or API that JavaScript is able to use. C# code can call into JavaScript code, and JavaScript code can call into C# code. For more information, see [JavaScript interop](xref:razor-components/javascript-interop).

## Additional resources

* <xref:spa/blazor/index>
* [WebAssembly](http://webassembly.org/)
* [C# Guide](/dotnet/csharp/)
* <xref:mvc/views/razor>
* [HTML](https://www.w3.org/html/)
