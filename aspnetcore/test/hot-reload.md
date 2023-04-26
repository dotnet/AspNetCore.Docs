---
title: .NET Hot Reload support for ASP.NET Core
author: tdykstra
description: Use .NET Hot Reload to apply code changes to a running app without restarting the app and without losing app state.
monikerRange: '>= aspnetcore-6.0'
ms.author: riande
ms.custom: mvc
ms.date: 11/10/2022
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

::: moniker range=">= aspnetcore-8.0"

Blazor WebAssembly Hot Reload supports the following code changes:

* New types.
* Nested classes.
* Most changes to method bodies, such as adding, removing, and editing variables, expressions, and statements.
* Changes to the bodies of [lambda expressions](/dotnet/csharp/language-reference/operators/lambda-expressions) and [local functions](/dotnet/csharp/programming-guide/classes-and-structs/local-functions).
* Adding static and instance methods to existing types.
* Adding static and instance fields, events, and properties to existing types.
* Adding static lambdas to existing methods.
* Adding lambdas that capture `this` to existing methods that already captured `this` previously.

Note that when an attribute is removed that previously set the value of a component parameter, the component is disposed and re-initialized to set the removed parameter back to its default value.

The following code changes aren't supported for Blazor WebAssembly apps:

* Adding a new [`await` operator](/dotnet/csharp/language-reference/operators/await) or [`yield` keyword](/dotnet/csharp/language-reference/keywords/yield) expression.
* Changing the names of method parameters.

::: moniker-end

::: moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

Blazor WebAssembly Hot Reload supports the following code changes:

* New types.
* Nested classes.
* Most changes to method bodies, such as adding, removing, and editing variables, expressions, and statements.
* Changes to the bodies of [lambda expressions](/dotnet/csharp/language-reference/operators/lambda-expressions) and [local functions](/dotnet/csharp/programming-guide/classes-and-structs/local-functions).
* Adding static and instance methods to existing types.
* Adding static fields to existing types.
* Adding static lambdas to existing methods.
* Adding lambdas that capture `this` to existing methods that already captured `this` previously.

Note that when an attribute is removed that previously set the value of a component parameter, the component is disposed and re-initialized to set the removed parameter back to its default value.

The following code changes aren't supported for Blazor WebAssembly apps:

* Adding a new [`await` operator](/dotnet/csharp/language-reference/operators/await) or [`yield` keyword](/dotnet/csharp/language-reference/keywords/yield) expression.
* Changing the names of method parameters.
* Adding instance (non-`static`) fields, events, or properties.

::: moniker-end

::: moniker range="< aspnetcore-7.0"

Blazor WebAssembly Hot Reload supports the following code changes:

* Most changes to method bodies, such as adding, removing, and editing variables, expressions, and statements.
* Changes to the bodies of [lambda expressions](/dotnet/csharp/language-reference/operators/lambda-expressions) and [local functions](/dotnet/csharp/programming-guide/classes-and-structs/local-functions).

The following code changes aren't supported for Blazor WebAssembly apps:

* Adding new lambdas or local functions.
* Adding a new [`await` operator](/dotnet/csharp/language-reference/operators/await) or [`yield` keyword](/dotnet/csharp/language-reference/keywords/yield) expression.
* Changing the names of method parameters.
* Changes outside of method bodies.
* Adding instance (non-`static`) fields, events, or properties.

::: moniker-end

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

## Disable Hot Reload

The following setting in `Properties/launchSettings.json` disables Hot Reload:

```json
"hotReloadEnabled" : false
```

## Additional resources

For more information, see the following resources in the Visual Studio documentation:

* YouTube video [.NET 6 Hot Reload in Visual Studio 2022, VS Code, and NOTEPAD?!?](https://www.youtube.com/watch?v=4S3vPzawnoQ)
* [Introducing the .NET Hot Reload experience for editing code at runtime](https://devblogs.microsoft.com/dotnet/introducing-net-hot-reload/)
* [Write and debug running code with Hot Reload in Visual Studio](/visualstudio/debugger/hot-reload)
* [Updates for Blazor & Razor editors + Hot Reload for ASP.NET](/visualstudio/ide/whats-new-visual-studio-2022#updates-for-blazor--razor-editors--hot-reload-for-aspnet)
* [Test Execution with Hot Reload](/visualstudio/test/test-execution-with-hot-reload)
