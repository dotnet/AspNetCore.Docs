---
title: "Tutorial: Publish an ASP.NET Core app using native AOT"
author: mitchdenny
description: Learn about how to publish an ASP.NET Core app using native AOT.
monikerRange: '>= aspnetcore-8.0'
ms.topic: tutorial
content_well_notification: AI-contribution
ms.author: midenn
ms.custom: mvc
ms.date: 08/10/2023
uid: fundamentals/native-aot-tutorial
---
# Tutorial: Publish an ASP.NET Core app using native AOT

ASP.NET Core 8.0 introduces support for [.NET native ahead-of-time (AOT)](/dotnet/core/deploying/native-aot/).

> [!NOTE]
> * The native AOT feature is currently in preview.
> * In .NET 8, not all ASP.NET Core features are compatible with native AOT.
> * Tabs are provided for the [.NET Core CLI](/dotnet/core/tools/) and [Visual Studio](https://visualstudio.microsoft.com/vs/preview/) instructions:
>   * Visual Studio is a prerequisite even if the CLI tab is selected.
>   * The CLI must be used to publish even if the Visual Studio tab is selected.

## Prerequisites

# [.NET Core CLI](#tab/netcore-cli) 

* [!INCLUDE[](~/includes/8.0-SDK.md)]
* On Linux, see [Prerequisites for native AOT deployment](/dotnet/core/deploying/native-aot/?tabs=net8plus#prerequisites-for-native-aot-deployment).
* [Visual Studio 2022 Preview](https://visualstudio.microsoft.com/vs/preview/) with the **Desktop development with C++** workload installed.

  ![Visual Studio workload selection dialog showing "Desktop development with C++" selected.](~/fundamentals/aot/_static/cpponly.png)

> [!NOTE]
> Visual Studio 2022 Preview is required because native AOT requires [link.exe](/cpp/build/reference/linker-options) and the Visual C++ static runtime libraries. There are no plans to support native AOT ***without*** Visual Studio.

# [Visual Studio](#tab/visual-studio)

* [!INCLUDE[](~/includes/8.0-SDK.md)]

* [Visual Studio 2022 Preview](https://visualstudio.microsoft.com/vs/preview/) with the following workloads installed:
  * **ASP.NET and web development**
  * **Desktop development with C++**

  ![Visual Studio workload selection dialog showing "ASP.NET and web development" and "Desktop development with C++" selected.](~/fundamentals/aot/_static/ddcpp.png)

---

## Create a web app with native AOT

Create an ASP.NET Core API app that is configured to work with native AOT:

# [.NET Core CLI](#tab/netcore-cli) 

Run the following commands:

```dotnetcli
dotnet new webapiaot -o MyFirstAotWebApi && cd MyFirstAotWebApi
```

Output similar to the following example is displayed:

```output
The template "ASP.NET Core Web API (native AOT)" was created successfully.

Processing post-creation actions...
Restoring C:\Code\Demos\MyFirstAotWebApi\MyFirstAotWebApi.csproj:
  Determining projects to restore...
  Restored C:\Code\Demos\MyFirstAotWebApi\MyFirstAotWebApi.csproj (in 302 ms).
Restore succeeded.
```

# [Visual Studio](#tab/visual-studio)

1. Create a new `ASP.NET Core Web API (native AOT)` project.
1. Name the project **MyFirstAotWebApi**.
1. Select **Create**.

---

## Publish the native AOT app

Verify the app can be published using native AOT:

# [.NET Core CLI](#tab/netcore-cli) 

```dotnetcli
dotnet publish
```

# [Visual Studio](#tab/visual-studio)

Visual studio doesn't support publishing an AOT app. Use the CLI command:

```dotnetcli
dotnet publish
```

---

The `dotnet publish` command:

* Compiles the source files.
* Generates source code files that are compiled.
* Passes generated assemblies to a native IL compiler. The IL compiler produces the native executable. The native executable contains the native machine code.

Output similar to the following example is displayed:

```output
MSBuild version 17.<version> for .NET
  Determining projects to restore...
  Restored C:\Code\Demos\MyFirstAotWebApi\MyFirstAotWebApi.csproj (in 241 ms).
C:\Code\dotnet\aspnetcore\.dotnet\sdk\8.0.<version>\Sdks\Microsoft.NET.Sdk\targets\Microsoft.NET.RuntimeIde
ntifierInference.targets(287,5): message NETSDK1057: You are using a preview version of .NET. See: https://aka.ms/dotne
t-support-policy [C:\Code\Demos\MyFirstAotWebApi\MyFirstAotWebApi.csproj]
  MyFirstAotWebApi -> C:\Code\Demos\MyFirstAotWebApi\bin\Release\net8.0\win-x64\MyFirstAotWebApi.dll
  Generating native code
  MyFirstAotWebApi -> C:\Code\Demos\MyFirstAotWebApi\bin\Release\net8.0\win-x64\publish\
```

The output may differ from the preceding example depending on the version of .NET 8 used, directory used, and other factors.

Review the contents of the output directory:

```
dir bin\Release\net8.0\win-x64\publish
```

Output similar to the following example is displayed:

```Output
    Directory: C:\Code\Demos\MyFirstAotWebApi\bin\Release\net8.0\win-x64\publish

Mode                 LastWriteTime         Length Name
----                 -------------         ------ ----
-a---          30/03/2023  1:41 PM        9480704 MyFirstAotWebApi.exe
-a---          30/03/2023  1:41 PM       43044864 MyFirstAotWebApi.pdb
```

The executable is self-contained and doesn't require a .NET runtime to run. When launched, it behaves the same as the app run in the development environment. Run the AOT app:

```
.\bin\Release\net8.0\win-x64\publish\MyFirstAotWebApi.exe
```

Output similar to the following example is displayed:

```output
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Production
info: Microsoft.Hosting.Lifetime[0]
      Content root path: C:\Code\Demos\MyFirstAotWebApi
```

[!INCLUDE[](~/fundamentals/aot/includes/aot_lib.md)]

## See also

* <xref:fundamentals/native-aot>
* [Native AOT deployment](/dotnet/core/deploying/native-aot/)
* [Using the configuration binder source generator](https://andrewlock.net/exploring-the-dotnet-8-preview-using-the-new-configuration-binder-source-generator/)
* [The minimal API AOT compilation template](https://andrewlock.net/exploring-the-dotnet-8-preview-the-minimal-api-aot-template/)
* [Comparing `WebApplication.CreateBuilder` to `CreateSlimBuilder`](https://andrewlock.net/exploring-the-dotnet-8-preview-comparing-createbuilder-to-the-new-createslimbuilder-method/)
* [Exploring the new minimal API source generator](https://andrewlock.net/exploring-the-dotnet-8-preview-exploring-the-new-minimal-api-source-generator/)
* [Replacing method calls with Interceptors](https://andrewlock.net/exploring-the-dotnet-8-preview-changing-method-calls-with-interceptors/)
* [Configuration-binding source generator](/dotnet/core/whats-new/dotnet-8#configuration-binding-source-generator)
