---
title: Developing ASP.NET Core apps using dotnet watch
author: rick-anderson
description: This tutorial demonstrates how to install and use the .NET Core CLI's file watcher (dotnet watch) tool in an ASP.NET Core application.
keywords: ASP.NET Core,using dotnet watch
ms.author: riande
manager: wpickett
ms.date: 10/05/2017
ms.topic: article
ms.assetid: 563ffb3f-d369-4aa5-bf0a-7300b4e7832c
ms.technology: aspnet
ms.prod: asp.net-core
uid: tutorials/dotnet-watch
---
# Developing ASP.NET Core apps using dotnet watch

By [Rick Anderson](https://twitter.com/RickAndMSFT) and [Victor Hurdugaci](https://twitter.com/victorhurdugaci)

`dotnet watch` is a tool that runs a [.NET Core CLI](/dotnet/core/tools) command when source files change. For example, a file change can trigger compilation, tests, or deployment.

In this tutorial, we use an existing Web API app with two endpoints: one that returns a sum and one that returns a product. The product method contains a bug that we'll fix as part of this tutorial.

Download the [sample app](https://github.com/aspnet/Docs/tree/master/aspnetcore/tutorials/dotnet-watch/sample). It contains two projects: *WebApp* (an ASP.NET Core Web API) and *WebAppTests* (unit tests for the Web API).

In a command shell, navigate to the *WebApp* folder and run the following command:

```console
dotnet run
```

The console output shows messages similar to the following (indicating that the app is running and awaiting requests):

```console
$ dotnet run
Hosting environment: Development
Content root path: C:/Docs/aspnetcore/tutorials/dotnet-watch/sample/WebApp
Now listening on: http://localhost:5000
Application started. Press Ctrl+C to shut down.
```

In a web browser, navigate to `http://localhost:<port number>/api/math/sum?a=4&b=5`. You should see the result `9`.

Navigate to the product API (`http://localhost:<port number>/api/math/product?a=4&b=5`). It returns `9`, not `20` as you'd expect. We'll fix that later in the tutorial.

## Add `dotnet watch` to a project

- Add a `Microsoft.DotNet.Watcher.Tools` package reference to the *.csproj* file:

 ```xml
 <ItemGroup>
     <DotNetCliToolReference Include="Microsoft.DotNet.Watcher.Tools" Version="2.0.0" />
 </ItemGroup> 
 ```

- Run `dotnet restore`.

## Running .NET Core CLI commands using `dotnet watch`

Any .NET Core CLI command can be run with `dotnet watch`. For example:

| Command | Command with watch |
| ---- | ----- |
| dotnet run | dotnet watch run |
| dotnet run -f net461 | dotnet watch run -f net461 |
| dotnet run -f net461 -- --arg1 | dotnet watch run -f net461 -- --arg1 |
| dotnet test | dotnet watch test |

Run `dotnet watch run` in the *WebApp* folder. The console output indicates `watch` has started.

## Making changes with `dotnet watch`

Make sure `dotnet watch` is running.

Fix the bug in the `Product` method of *MathController.cs* so it returns the product and not the sum:

```csharp
public static int Product(int a, int b)
{
  return a * b;
} 
```

Save the file. The console output indicates that `dotnet watch` detected a file change and restarted the app.

Verify `http://localhost:<port number>/api/math/product?a=4&b=5` returns the correct result.

## Running tests using `dotnet watch`

- Change the `Product` method of the `MathController` back to returning the sum and save the file.
- In a command window, navigate to the *WebAppTests* folder.
- Run `dotnet restore`
- Run `dotnet watch test`. You see output indicating that a test failed and that watcher is waiting for file changes:

 ```console
 Total tests: 2. Passed: 1. Failed: 1. Skipped: 0.
 Test Run Failed.
 ```

- Fix the `Product` method code so it returns the product. Save the file.

`dotnet watch` detects the file change and reruns the tests. The console output indicates the tests passed.

## dotnet-watch in GitHub

dotnet-watch is part of the GitHub [DotNetTools repository](https://github.com/aspnet/DotNetTools/tree/dev/src/Microsoft.DotNet.Watcher.Tools).

The [MSBuild section](https://github.com/aspnet/DotNetTools/blob/dev/src/Microsoft.DotNet.Watcher.Tools/README.md#msbuild) of the [dotnet-watch ReadMe](https://github.com/aspnet/DotNetTools/blob/dev/src/Microsoft.DotNet.Watcher.Tools/README.md) explains how dotnet-watch can be configured from the MSBuild project file being watched. The [dotnet-watch ReadMe](https://github.com/aspnet/DotNetTools/blob/dev/src/Microsoft.DotNet.Watcher.Tools/README.md) contains information on dotnet-watch not covered in this tutorial.
