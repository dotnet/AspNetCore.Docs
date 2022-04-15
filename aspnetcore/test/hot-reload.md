---
title: .NET Hot Reload support for ASP.NET Core
author: rick-anderson
description: Use .NET Hot Reload to apply code changes to a running app without restarting the app and without losing app state.
monikerRange: '>= aspnetcore-6.0'
ms.author: riande
ms.custom: mvc
ms.date: 10/27/2021
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: test/hot-reload
---
# .NET Hot Reload support for ASP.NET Core

.NET Hot Reload applies code changes, including changes to stylesheets, to a running app without restarting the app and without losing app state. Hot Reload is supported for all ASP.NET Core 6.0 and later projects.

Generally, updated code is rerun to take effect with the following conditions:

* Some startup logic is only run once:
  * Middleware, unless the code update is to an inline middleware delegate.
  * Configured services.
  * Route creation and configuration, unless the code update is to a route handler delegate (for example, `OnInitialized`).
* In [Blazor apps](xref:blazor/index), the framework triggers a [Razor component](xref:blazor/components/index) render automatically.
* In MVC and Razor Pages apps, Hot Reload triggers a browser refresh automatically.
* Removing a Razor [component parameter](xref:blazor/components/index#component-parameters) attribute doesn't cause the component to rerender. The app must be restarted.

For more information on supported scenarios, see [Supported code changes (C# and Visual Basic)](/visualstudio/debugger/supported-code-changes-csharp).

## Blazor WebAssembly

Blazor WebAssembly Hot Reload support has the following conditions:

* Hot Reload reacts to most changes to method bodies, such as adding, removing, and editing variables, expressions, and statements.
* Changes to the bodies of [lambda expressions](/dotnet/csharp/language-reference/operators/lambda-expressions) and [local functions](/dotnet/csharp/programming-guide/classes-and-structs/local-functions) are also supported.
* Adding new lambdas or local functions, adding a new [`await` operator](/dotnet/csharp/language-reference/operators/await) or [`yield` keyword](/dotnet/csharp/language-reference/keywords/yield) expression is ***not*** supported.
* Changing the names of method parameters is ***not*** supported.
* Changes outside of method bodies is ***not*** supported.

## .NET CLI

Hot Reload is activated using the [`dotnet watch`](xref:tutorials/dotnet-watch) command:

```dotnetcli
dotnet watch
```

To force the app to rebuild and restart, use the keyboard combination <kbd>Ctrl</kbd>+<kbd>R</kbd> in the command shell.

When an unsupported code edit is made, called a *rude edit*, `dotnet watch` asks you if you want to restart the app:

* **Yes**: Restarts the app.
* **No**: Doesn't restart the app and leaves the app running without the changes applied.
* **Always**: Restarts the app as needed when rude edits occur.
* **Never**: Doesn't restart the app and avoids future prompts.

To disable support for Hot Reload, pass the `--no-hot-reload` option to the `dotnet watch` command:

```dotnetcli
dotnet watch --no-hot-reload
```

## Additional resources

For more information, see the following resources in the Visual Studio documentation:

* YouTube video [.NET 6 Hot Reload in Visual Studio 2022, VS Code, and NOTEPAD?!?](https://www.youtube.com/watch?v=4S3vPzawnoQ)
* [Introducing the .NET Hot Reload experience for editing code at runtime](https://devblogs.microsoft.com/dotnet/introducing-net-hot-reload/)
* [Write and debug running code with Hot Reload in Visual Studio](/visualstudio/debugger/hot-reload)
* [Updates for Blazor & Razor editors + Hot Reload for ASP.NET](/visualstudio/ide/whats-new-visual-studio-2022#updates-for-blazor--razor-editors--hot-reload-for-aspnet)
* [Test Execution with Hot Reload](/visualstudio/test/test-execution-with-hot-reload)
