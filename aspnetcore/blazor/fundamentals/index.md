---
title: ASP.NET Core Blazor fundamentals
author: guardrex
description: Learn foundational concepts of the Blazor application framework.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/08/2022
uid: blazor/fundamentals/index
---
# ASP.NET Core Blazor fundamentals

[!INCLUDE[](~/includes/not-latest-version.md)]

*Fundamentals* articles provide guidance on foundational Blazor concepts. Some of the concepts are connected to a basic understanding of *Razor components*, which are described further in the next section of this article and covered in detail in the *Components* articles.

## Razor components

Blazor apps are based on *Razor components*, often referred to as just *components*. A *component* is an element of UI, such as a page, dialog, or data entry form. Components are .NET C# classes built into [.NET assemblies](/dotnet/standard/assembly/).

*Razor* refers to how components are usually written in the form of a [Razor](xref:mvc/views/razor) markup page for client-side UI logic and composition. Razor is a syntax for combining HTML markup with C# code designed for developer productivity. Razor files use the `.razor` file extension.

Although some Blazor developers and online resources use the term "Blazor components," the documentation avoids that term and universally uses "Razor components" or "components."

Blazor documentation adopts several conventions for showing and discussing components:

* Project code, file paths and names, project template names, and other specialized terms are in United States English and usually code-fenced.
* Components are usually referred to by their C# class name (Pascal case) followed by the word "component." For example, a typical file upload component is referred to as the "`FileUpload` component."
* Usually, a component's C# class name is the same as its file name.
* Routable components usually set their relative URLs to the component's class name in kebab-case. For example, a `FileUpload` component includes routing configuration to reach the rendered component at the relative URL `/file-upload`. Routing and navigation is covered in <xref:blazor/fundamentals/routing>.
* When multiple versions of a component are used, they're numbered sequentially. For example, the `FileUpload3` component is reached at `/file-upload-3`.
* Access modifiers are used in article examples. For example, fields are `private` by default but are explicitly present in component code. For example, `private` is stated for declaring a field named `maxAllowedFiles` as `private int maxAllowedFiles = 3;`.
* Generally, examples adhere to ASP.NET Core/C# coding conventions and engineering guidelines. For more information see the following resources:
  * [Engineering guidelines (`dotnet/aspnetcore` GitHub repository)](https://github.com/dotnet/aspnetcore/wiki/Engineering-guidelines)
  * [C# Coding Conventions (C# guide)](/dotnet/csharp/fundamentals/coding-style/coding-conventions)

The following is an example counter component and part of an app created from a Blazor project template. Detailed components coverage is found in the *Components* articles later in the documentation. The following example demonstrates component concepts seen in the *Fundamentals* articles before reaching the *Components* articles later in the documentation.

`Counter.razor`:

:::moniker range=">= aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/Counter.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/Counter.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/Counter.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/Counter.razor":::

:::moniker-end

The preceding `Counter` component:

* Sets its route with the `@page` directive in the first line.
* Sets its page title and heading.
* Renders the current count with `@currentCount`. `currentCount` is an integer variable defined in the C# code of the `@code` block.
* Displays a button to trigger the `IncrementCount` method, which is also found in the `@code` block and increases the value of the `currentCount` variable.

## Document Object Model (DOM)

References to the *Document Object Model* use the abbreviation *DOM*.

For more information, see the following resources:

* [Introduction to the DOM (MDN documentation)](https://developer.mozilla.org/docs/Web/API/Document_Object_Model/Introduction)
* [Level 1 Document Object Model Specification (W3C)](https://www.w3.org/TR/WD-DOM/)

## Sample apps

Documentation sample apps are available for inspection and download:

[Blazor samples GitHub repository (`dotnet/blazor-samples`)](https://github.com/dotnet/blazor-samples)

The repo contains two types of samples:

:::moniker range=">= aspnetcore-8.0"

* Snippet sample apps provide the code examples that appear in articles. These apps compile but aren't necessarily runnable apps. These apps are useful for merely obtaining example code that appears in articles.
* Samples apps to accompany Blazor articles compile and run for the following scenarios:
  * Blazor Web App with with EF Core
  * Blazor Web App with SignalR
  * Blazor WebAssembly scopes-enabled logging

:::moniker-end

:::moniker range="< aspnetcore-8.0"

* Snippet sample apps provide the code examples that appear in articles. These apps compile but aren't necessarily runnable apps. These apps are useful for merely obtaining example code that appears in articles.
* Samples apps to accompany Blazor articles compile and run for the following scenarios:
  * Blazor Server with EF Core
  * Blazor Server and Blazor WebAssembly with SignalR
  * Blazor WebAssembly scopes-enabled logging

:::moniker-end

For more information, see the [Blazor samples GitHub repository README.md file](https://github.com/dotnet/blazor-samples).

The ASP.NET Core repository's Basic Test App is also a helpful set of samples for various Blazor scenarios:

[`BasicTestApp` in ASP.NET Core reference source (`dotnet/aspnetcore`)](https://github.com/dotnet/aspnetcore/tree/main/src/Components/test/testassets/BasicTestApp)

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

## Byte multiples

.NET byte sizes use metric prefixes for non-decimal multiples of bytes based on powers of 1024.

| Name (abbreviation) | Size                    | Example                    |
| ------------------- | ----------------------- | -------------------------- |
| Kilobyte (KB)       | 1,024 bytes             | 1 KB = 1,024 bytes         |
| Megabyte (MB)       | 1,024<sup>2</sup> bytes | 1 MB = 1,048,576 bytes     |
| Gigabyte (GB)       | 1,024<sup>3</sup> bytes | 1 GB = 1,073,741,824 bytes |

## Support requests

Only documentation-related issues are appropriate for the `dotnet/AspNetCore.Docs` repository. ***For product support, don't open a documentation issue.*** Seek assistance through one or more of the following support channels:

* [Stack Overflow (tagged: `blazor`)](https://stackoverflow.com/questions/tagged/blazor)
* [General ASP.NET Core Slack Team](https://join.slack.com/t/aspnetcore/shared_invite/zt-1mv5487zb-EOZxJ1iqb0A0ajowEbxByQ)
* [Blazor Gitter](https://gitter.im/aspnet/Blazor)

For a potential bug in the framework or product feedback, open an issue for the ASP.NET Core product unit at [`dotnet/aspnetcore` issues](https://github.com/dotnet/aspnetcore/issues). Bug reports usually ***require*** the following:

* **Clear explanation of the problem**: Follow the instructions in the GitHub issue template provided by the product unit when opening the issue.
* **Minimal repro project**: Place a project on GitHub for the product unit engineers to download and run. Cross-link the project into the issue's opening comment.

For a potential problem with a Blazor article, open a documentation issue. To open a documentation issue, use the **This page** feedback button and form at the bottom of the article and leave the metadata in place when creating the opening comment. The metadata provides tracking data and automatically pings the author of the article. If the subject was discussed with the product unit, place a cross-link to the engineering issue in the documentation issue's opening comment.

For problems or feedback on Visual Studio, use the [**Report a Problem**](/visualstudio/ide/how-to-report-a-problem-with-visual-studio) or [**Suggest a Feature**](/visualstudio/ide/suggest-a-feature) gestures from within Visual Studio, which open internal issues for Visual Studio. For more information, see [Visual Studio Feedback](https://developercommunity.visualstudio.com/home).

For problems with Visual Studio Code, ask for support on community support forums. For bug reports and product feedback, open an issue on the [`microsoft/vscode` GitHub repo](https://github.com/microsoft/vscode/issues).

GitHub issues for Blazor documentation are automatically marked for triage on the [`Blazor.Docs` project (`dotnet/AspNetCore.Docs` GitHub repository)](https://github.com/dotnet/AspNetCore.Docs/projects/35). Please wait a short while for a response, especially over weekends and holidays. Usually, documentation authors respond within 24 hours on weekdays.

## Community links to Blazor resources

For a collection of links to Blazor resources maintained by the community, visit [Awesome Blazor](https://github.com/AdrienTorris/awesome-blazor).

> [!NOTE]
> Microsoft doesn't own, maintain, or support *Awesome Blazor* and most of the community products and services described and linked there.
