---
title: ASP.NET Core Blazor fundamentals
author: guardrex
description: Learn foundational concepts of the Blazor application framework.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 02/08/2022
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/fundamentals/index
---
# ASP.NET Core Blazor fundamentals

*Fundamentals* articles provide guidance on foundational Blazor concepts. Some of the concepts are connected to a basic understanding of *Razor components*, which are described further in the next section of this article and covered in detail in the *Components* articles.

## Razor components

Blazor apps are based on *Razor components*, often referred to as just *components*. Components are covered in detail in the *Components* articles, but it's important to learn component basics and note conventions used in the articles before reading *Fundamentals* articles, which use components to demonstrate concepts.

A *component* is an element of UI, such as a page, dialog, or data entry form. Components are .NET C# classes built into [.NET assemblies](/dotnet/standard/assembly/).

*Razor* refers to how components are usually written in the form of a [Razor](xref:mvc/views/razor) markup page for client-side UI logic and composition. Razor is a syntax for combining HTML markup with C# code designed for developer productivity. Razor files use the `.razor` file extension.

Although some Blazor developers and online resources use the term "Blazor components," the documentation avoids that term and universally uses "Razor components" or "components."

Blazor documentation adopts several conventions for showing and discussing components:

* Project code, file paths and names, project template names, and other specialized terms are in United States English and usually code-fenced.
* Components are usually referred to by their C# class name (Pascal case) followed by the word "component." For example, a typical file upload component is referred to as the "`FileUpload` component."
* Usually, a component's C# class name is the same as its file name. Component paths within an app are usually indicated. For example, `Pages/FileUpload.razor`.
* Routable components usually set their relative URLs to the component's class name in kebab-case. For example, a `FileUpload` component includes routing configuration to reach the rendered component at the relative URL `/file-upload`. Routing and navigation is covered in <xref:blazor/fundamentals/routing>.
* When multiple versions of a component are used, they're numbered sequentially. For example, the `FileUpload3` component has a file name and location of `Pages/FileUpload3.razor` and is reached at `/file-upload-3`.
* Access modifiers are used in article examples. For example, fields are `private` by default but are explicitly present in component code. For example, `private` is stated for declaring a field named `maxAllowedFiles` as `private int maxAllowedFiles = 3;`.
* Generally, examples adhere to ASP.NET Core/C# coding conventions and engineering guidelines. For more information see the following resources:
  * [Engineering guidelines (`dotnet/aspnetcore` GitHub repository)](https://github.com/dotnet/aspnetcore/wiki/Engineering-guidelines)
  * [C# Coding Conventions (C# guide)](/dotnet/csharp/fundamentals/coding-style/coding-conventions)

The following is an example counter component and part of an app created from a Blazor project template. Detailed components coverage is found in the *Components* articles later in the documentation. The following example demonstrates component concepts seen in the *Fundamentals* articles before reaching the *Components* articles later in the documentation.

`Pages/Counter.razor`:

```razor
@page "/counter"

<PageTitle>Counter</PageTitle>

<h1>Counter</h1>

<p role="status">Current count: @currentCount</p>

<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>

@code {
    private int currentCount = 0;

    private void IncrementCount()
    {
        currentCount++;
    }
}
```

The preceding `Counter` component:

* Sets its route with the `@page` directive in the first line.
* Sets its page title and heading.
* Renders the current count with `@currentCount`. `currentCount` is an integer variable defined in the C# code of the `@code` block.
* Displays a button to trigger the `IncrementCount` method, which is also found in the `@code` block and increases the value of the `currentCount` variable.

## Sample apps

Documentation sample apps are available for inspection or download:

[`dotnet/blazor-samples` GitHub repository](https://github.com/dotnet/blazor-samples)

## Support requests

Only documentation-related issues are appropriate for the `dotnet/AspNetCore.Docs` repository. ***For product support, don't open a documentation issue.*** Seek assistance through one or more of the following support channels:

* [Stack Overflow (tagged: `blazor`)](https://stackoverflow.com/questions/tagged/blazor)
* [General ASP.NET Core Slack Team](http://tattoocoder.com/aspnet-slack-sign-up/)
* [Blazor Gitter](https://gitter.im/aspnet/Blazor)

For a potential bug in the framework or product feedback, open an issue for the ASP.NET Core product unit at [`dotnet/aspnetcore` issues](https://github.com/dotnet/aspnetcore/issues). Bug reports usually ***require*** the following:

* **Clear explanation of the problem**: Follow the instructions in the GitHub issue template provided by the product unit when opening the issue.
* **Minimal repro project**: Place a project on GitHub for the product unit engineers to download and run. Cross-link the project into the issue's opening comment.

For a potential problem with a Blazor article, open a documentation issue. To open a documentation issue, use the **This page** feedback button and form at the bottom of the article and leave the metadata in place when creating the opening comment. The metadata provides tracking data and automatically pings the author of the article. If the subject was discussed with the product unit, place a cross-link to the engineering issue in the documentation issue's opening comment.

For problems or feedback on Visual Studio or Visual Studio for Mac, use the [**Report a Problem**](/visualstudio/ide/how-to-report-a-problem-with-visual-studio) or [**Suggest a Feature**](/visualstudio/ide/suggest-a-feature) gestures from within Visual Studio, which open internal issues for Visual Studio teams. For more information, see [Visual Studio Feedback](https://developercommunity.visualstudio.com/home) or [How to report a problem in Visual Studio for Mac](/visualstudio/mac/report-a-problem).

For problems with Visual Studio Code, ask for support on community support forums. For bug reports and product feedback, open an issue on the [`microsoft/vscode` GitHub repo](https://github.com/microsoft/vscode/issues).

GitHub issues for Blazor documentation are automatically marked for triage on the [`Blazor.Docs` project (`dotnet/AspNetCore.Docs` GitHub repository)](https://github.com/dotnet/AspNetCore.Docs/projects/35). Please wait a short while for a response, especially over weekends and holidays. Usually, documentation authors respond within 24 hours on weekdays.

## Community links to Blazor resources

For a collection of links to Blazor resources maintained by the community, visit [Awesome Blazor](https://github.com/AdrienTorris/awesome-blazor).

> [!NOTE]
> Microsoft doesn't own, maintain, or support *Awesome Blazor* and most of the community products and services described and linked there.
