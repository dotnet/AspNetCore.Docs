---
author: tdykstra
ms.author: tdykstra
ms.date: 09/12/2023
ms.topic: include
---
## Newer vs. older SPA templates

The SPA templates that use the special project type for JavaScript and TypeScript are available in Visual Studio 2022 version 17.7 or later with the **ASP.NET and web development** workload installed. They are available only in Visual Studio, not by using the `dotnet new` command of the .NET CLI.

There are older SPA templates that don't use the special project type for JavaScript and TypeScript. The newer Visual Studio templates offer the following benefits compared to the older templates:

* Clean project separation for the frontend and backend.
* Stay up-to-date with the latest frontend framework versions.
* Integrate with the latest frontend framework command-line tooling, such as [Vite](https://vitejs.dev/).
* Templates for both JavaScript & TypeScript (only TypeScript for Angular).
* Rich JavaScript and TypeScript code editing experience.
* Integrate JavaScript build tools with the .NET build.
* npm dependency management UI.
* Compatible with Visual Studio Code debugging and launch configuration.
* Run frontend unit tests in [Test Explorer](/visualstudio/test/run-unit-tests-with-test-explorer) using JavaScript test frameworks.

## How to get the old templates

Install the [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) or [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0) to make the old SPA project templates available via the `dotnet new angular` or `dotnet new react` commands. For documentation on these older templates, see the ASP.NET Core 7.0 version of the [SPA overview](xref:spa/angular?view=aspnetcore-7.0&tabs=netcore-cli) and the [Angular](xref:spa/angular?view=aspnetcore-7.0&tabs=netcore-cli) and [React](xref:spa/react?view=aspnetcore-7.0&tabs=netcore-cli) articles.
