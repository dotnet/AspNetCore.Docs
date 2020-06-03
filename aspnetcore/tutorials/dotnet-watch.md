---
title: Develop ASP.NET Core apps using a file watcher
author: rick-anderson
description: This tutorial demonstrates how to install and use the .NET Core CLI's file watcher (dotnet watch) tool in an ASP.NET Core app.
ms.author: riande
ms.date: 05/31/2018
no-loc: [Blazor, "Identity", "Let's Encrypt", Razor, SignalR]
uid: tutorials/dotnet-watch
---
# Develop ASP.NET Core apps using a file watcher

By [Rick Anderson](https://twitter.com/RickAndMSFT) and [Victor Hurdugaci](https://twitter.com/victorhurdugaci)

[dotnet watch](https://www.nuget.org/packages/dotnet-watch) is a tool that runs a [.NET Core CLI](/dotnet/core/tools) command when source files change. For example, a file change can trigger compilation, test execution, or deployment.

This tutorial uses an existing web API with two endpoints: one that returns a sum and one that returns a product. The product method has a bug, which is fixed in this tutorial.

Download the [sample app](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/tutorials/dotnet-watch/sample). It consists of two projects: *WebApp* (an ASP.NET Core web API) and *WebAppTests* (unit tests for the web API).

In a command shell, navigate to the *WebApp* folder. Run the following command:

```dotnetcli
dotnet run
```

> [!NOTE]
> You can use `dotnet run --project <PROJECT>` to specify a project to run. For example, running `dotnet run --project WebApp` from the root of the sample app will also run the *WebApp* project.

The console output shows messages similar to the following (indicating that the app is running and awaiting requests):

```console
$ dotnet run
Hosting environment: Development
Content root path: C:/Docs/aspnetcore/tutorials/dotnet-watch/sample/WebApp
Now listening on: http://localhost:5000
Application started. Press Ctrl+C to shut down.
```

In a web browser, navigate to `http://localhost:<port number>/api/math/sum?a=4&b=5`. You should see the result of `9`.

Navigate to the product API (`http://localhost:<port number>/api/math/product?a=4&b=5`). It returns `9`, not `20` as you'd expect. That problem is fixed later in the tutorial.

::: moniker range="<= aspnetcore-2.0"

## Add `dotnet watch` to a project

The `dotnet watch` file watcher tool is included with version 2.1.300 of the .NET Core SDK. The following steps are required when using an earlier version of the .NET Core SDK.

1. Add a `Microsoft.DotNet.Watcher.Tools` package reference to the *.csproj* file:

    ```xml
    <ItemGroup>
        <DotNetCliToolReference Include="Microsoft.DotNet.Watcher.Tools" Version="2.0.0" />
    </ItemGroup>
    ```

1. Install the `Microsoft.DotNet.Watcher.Tools` package by running the following command:

    ```dotnetcli
    dotnet restore
    ```

::: moniker-end

## Run .NET Core CLI commands using `dotnet watch`

Any [.NET Core CLI command](/dotnet/core/tools#cli-commands) can be run with `dotnet watch`. For example:

| Command | Command with watch |
| ---- | ----- |
| dotnet run | dotnet watch run |
| dotnet run -f netcoreapp2.0 | dotnet watch run -f netcoreapp2.0 |
| dotnet run -f netcoreapp2.0 -- --arg1 | dotnet watch run -f netcoreapp2.0 -- --arg1 |
| dotnet test | dotnet watch test |

Run `dotnet watch run` in the *WebApp* folder. The console output indicates `watch` has started.

> [!NOTE]
> You can use `dotnet watch --project <PROJECT>` to specify a project to watch. For example, running `dotnet watch --project WebApp run` from the root of the sample app will also run and watch the *WebApp* project.

## Make changes with `dotnet watch`

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

## Run tests using `dotnet watch`

1. Change the `Product` method of *MathController.cs* back to returning the sum. Save the file.
1. In a command shell, navigate to the *WebAppTests* folder.
1. Run [dotnet restore](/dotnet/core/tools/dotnet-restore).
1. Run `dotnet watch test`. Its output indicates that a test failed and that the watcher is awaiting file changes:

     ```console
     Total tests: 2. Passed: 1. Failed: 1. Skipped: 0.
     Test Run Failed.
     ```

1. Fix the `Product` method code so it returns the product. Save the file.

`dotnet watch` detects the file change and reruns the tests. The console output indicates the tests passed.

## Customize files list to watch

By default, `dotnet-watch` tracks all files matching the following glob patterns:

* `**/*.cs`
* `*.csproj`
* `**/*.resx`

More items can be added to the watch list by editing the *.csproj* file. Items can be specified individually or by using glob patterns.

```xml
<ItemGroup>
    <!-- extends watching group to include *.js files -->
    <Watch Include="**\*.js" Exclude="node_modules\**\*;**\*.js.map;obj\**\*;bin\**\*" />
</ItemGroup>
```

## Opt-out of files to be watched

`dotnet-watch` can be configured to ignore its default settings. To ignore specific files, add the `Watch="false"` attribute to an item's definition in the *.csproj* file:

```xml
<ItemGroup>
    <!-- exclude Generated.cs from dotnet-watch -->
    <Compile Include="Generated.cs" Watch="false" />

    <!-- exclude Strings.resx from dotnet-watch -->
    <EmbeddedResource Include="Strings.resx" Watch="false" />

    <!-- exclude changes in this referenced project -->
    <ProjectReference Include="..\ClassLibrary1\ClassLibrary1.csproj" Watch="false" />
</ItemGroup>
```

## Custom watch projects

`dotnet-watch` isn't restricted to C# projects. Custom watch projects can be created to handle different scenarios. Consider the following project layout:

* **test/**
  * *UnitTests/UnitTests.csproj*
  * *IntegrationTests/IntegrationTests.csproj*

If the goal is to watch both projects, create a custom project file configured to watch both projects:

```xml
<Project>
    <ItemGroup>
        <TestProjects Include="**\*.csproj" />
        <Watch Include="**\*.cs" />
    </ItemGroup>

    <Target Name="Test">
        <MSBuild Targets="VSTest" Projects="@(TestProjects)" />
    </Target>

    <Import Project="$(MSBuildExtensionsPath)\Microsoft.Common.targets" />
</Project>
```

To start file watching on both projects, change to the *test* folder. Execute the following command:

```dotnetcli
dotnet watch msbuild /t:Test
```

VSTest executes when any file changes in either test project.

## `dotnet-watch` in GitHub

`dotnet-watch` is part of the GitHub [dotnet/AspNetCore repository](https://github.com/dotnet/AspNetCore/tree/master/src/Tools/dotnet-watch).
