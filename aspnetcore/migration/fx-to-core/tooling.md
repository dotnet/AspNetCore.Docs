---
title: Learn to upgrade from ASP.NET MVC, Web API, and Web Forms to ASP.NET Core
ai-usage: ai-assisted
author: wadepickett
description: Learn how to upgrade ASP.NET Framework MVC, Web API, or Web Forms projects to ASP.NET Core using migration tooling.
ms.author: wpickett
ms.collection: ce-skilling-ai-copilot
ms.date: 07/07/2026
uid: migration/fx-to-core/tooling
---
# Use tooling to help migrate ASP.NET Framework to ASP.NET Core

## The GitHub Copilot app modernization

To upgrade ASP.NET Framework applications (MVC, Web API, and Web Forms) to ASP.NET Core, use the [GitHub Copilot app modernization Visual Studio extension](/dotnet/core/porting/github-copilot-app-modernization/overview).

The GitHub Copilot app modernization agent is a Visual Studio extension that leverages AI to simplify the process of upgrading legacy .NET applications. By integrating with GitHub Copilot Chat, this tool analyzes your solution to generate upgrade plans and assists in rewriting code to support ASP.NET Core. It streamlines the migration workflow by reducing manual effort, identifying dependencies, and providing interactive, automated guidance for modernizing your codebase. To learn how to upgrade your ASP.NET apps using the recommended tooling, see [How to upgrade a .NET app with GitHub Copilot app modernization](/dotnet/core/porting/github-copilot-app-modernization/how-to-upgrade-with-github-copilot).

If your .NET Framework project has supporting libraries in the solution that are required, upgrade them to .NET Standard 2.0, if possible. For more information, see [Upgrade supporting libraries](xref:migration/fx-to-core/start#upgrade-supporting-libraries).

## See also

* [Quickstart: Assess and migrate a .NET project with GitHub Copilot app modernization for .NET](/dotnet/azure/migration/appmod/quickstart)
