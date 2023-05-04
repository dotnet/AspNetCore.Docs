---
title: ASP.NET Core support for native AOT
author: mitchdenny
description: Learn about ASP.NET Core support for native AOT
monikerRange: '>= aspnetcore-8.0'
ms.author: midenn
ms.custom: mvc
ms.date: 5/5/2023
uid: fundamentals/native-aot
---
# ASP.NET Core support for native AOT

ASP.NET Core 8.0 introduces support for [.NET native ahead-of-time (AOT)](/dotnet/core/deploying/native-aot/).

> [!WARNING]
> In .NET 8, not all ASP.NET Core features are compatible with native AOT.

## Prerequisites

# [.NET Core CLI](#tab/netcore-cli) 

* [!INCLUDE[](~/includes/8.0-SDK.md)]
* From the Visual Studio installer, add the Desktop development with C++

![Workloads no VS](~/fundamentals/aot/_static/ddcpp.png)

# [Visual Studio](#tab/visual-studio)

* [!INCLUDE[](~/includes/8.0-SDK.md)]
* [Visual Studio 2022 Preview](https://visualstudio.microsoft.com/vs/preview/) 
  * Workloads:
    * ASP.NET and web development
    * Desktop development with C++

![Workloads](~/fundamentals/aot/_static/ddcpp.png)

---

## Native AOT publishing

AOT compilation happens when the app is published. Native AOT is enabled with the `PublishAot` option:

```xml
<PropertyGroup>
  <PublishAot>true</PublishAot>
</PropertyGroup>
```

A project that uses native AOT publishing uses JIT compilation when running locally. The AOT app has the following differences:

* Features that aren't compatible with native AOT are disabled and throw exceptions at runtime.
* A source analyzer is enabled to highlight code that isn't compatible with native AOT. At publish time, the entire app, including NuGet packages, are analyzed for compatibility again.

Native AOT analysis includes all of the app's code and the libraries the app depends on. Review native AOT warnings and take corrective steps. It's a good idea to test publishing apps frequently to discover issues early in the development lifecycle.

## Create a web app with native AOT

Native AOT is supported by ASP.NET Core minimal APIs and gRPC. For more information about getting started using native AOT with gRPC apps, see [gRPC and native AOT](xref:grpc/native-aot).

Create an ASP.NET Core API app that is configured to work with native AOT:

# [.NET Core CLI](#tab/netcore-cli) 

Run the following command:

```cli
dotnet new api -aot -o MyFirstAotWebApi && cd MyFirstAotWebApi
```

Output similar to the following is displayed:

```cli
The template "ASP.NET Core API" was created successfully.

Processing post-creation actions...
Restoring C:\Code\Demos\MyFirstAotWebApi\MyFirstAotWebApi.csproj:
  Determining projects to restore...
  Restored C:\Code\Demos\MyFirstAotWebApi\MyFirstAotWebApi.csproj (in 302 ms).
Restore succeeded.
```

# [Visual Studio](#tab/visual-studio)

1. Create a new ASP.NET Core API project. ***Note:*** The ASP.NET Core API project is different than the ASP.NET Core ***Web*** API project.
1. Select **Enable native AOT publish**

![Enable native AOT publish](~/fundamentals/aot/_static/aot.png)

---

## Publish the native AOT app

Verify the app can be published using native AOT:

# [.NET Core CLI](#tab/netcore-cli) 

```cli
dotnet publish
```

# [Visual Studio](#tab/visual-studio)

Visual studio doesn't currently support publishing an AOT app. Use the CLI command:

```cli
dotnet publish
```

---

Output similar to the following is displayed:

```cli
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

Note: The preceding output my differ depending on the version of .NET 8 used, directory used, etc.

Review the contents of the output directory:

```cli
dir bin\Release\net8.0\win-x64\publish
```

Output similar to the following is displayed:

```Output
    Directory: C:\Code\Demos\MyFirstAotWebApi\bin\Release\net8.0\win-x64\publish

Mode                 LastWriteTime         Length Name
----                 -------------         ------ ----
-a---          30/03/2023  1:41 PM        9480704 MyFirstAotWebApi.exe
-a---          30/03/2023  1:41 PM       43044864 MyFirstAotWebApi.pdb
```

The executable is self-contained and doesn't require a .NET runtime to run. When launched it should behave the same as the app run in the development environment. Run the AOT app:

```cli
.\bin\Release\net8.0\win-x64\publish\MyFirstAotWebApi.exe
```

Output similar to the following is displayed:

```Output
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Production
info: Microsoft.Hosting.Lifetime[0]
      Content root path: C:\Code\Demos\MyFirstAotWebApi
```

The following changes are made to the `Program.cs` when the `-aot` option is used:

```diff
+using System.Text.Json.Serialization;
using MyFirstAotWebApi;

var builder = WebApplication.CreateSlimBuilder(args);
builder.Logging.AddConsole();

+builder.Services.ConfigureHttpJsonOptions(options =>
+{
+    options.SerializerOptions.AddContext<AppJsonSerializerContext>();
+});

var app = builder.Build();

var sampleTodos = TodoGenerator.GenerateTodos().ToArray();

var todosApi = app.MapGroup("/todos");
todosApi.MapGet("/", () => sampleTodos);
todosApi.MapGet("/{id}", (int id) =>
    sampleTodos.FirstOrDefault(a => a.Id == id) is { } todo
        ? Results.Ok(todo)
        : Results.NotFound());

app.Run();

+[JsonSerializable(typeof(Todo[]))]
+internal partial class AppJsonSerializerContext : JsonSerializerContext
+{
+
+}
```

The AOT version of `launchSettings.json` file is simplified and has the `iisSettings` and `IIS Exoress` profile removed:

```diff
{
  "$schema": "http://json.schemastore.org/launchsettings.json",
-  "iisSettings": {
-     "windowsAuthentication": false,
-     "anonymousAuthentication": true,
-     "iisExpress": {
-       "applicationUrl": "http://localhost:11152",
-       "sslPort": 0
-     }
-   },
  "profiles": {
    "http": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "launchUrl": "todos",
      "applicationUrl": "http://localhost:5102",
        "environmentVariables": {
          "ASPNETCORE_ENVIRONMENT": "Development"
        }
      },
-     "IIS Express": {
-       "commandName": "IISExpress",
-       "launchBrowser": true,
-       "launchUrl": "todos",
-      "environmentVariables": {
-       "ASPNETCORE_ENVIRONMENT": "Development"
-      }
-    }
  }
}
```

<xref:System.Text.Json.Serialization.JsonSerializerContext>:

* Is used in the tempate and shown in the preceding highlighted code.
* Enables JSON serialization with native AOT.
* Specifies the custom types that are needed to serialize.
* Is used by the [JSON source generator](/dotnet/standard/serialization/system-text-json/source-generation) to produce code.

The <xref:Microsoft.AspNetCore.Builder.WebApplication.CreateSlimBuilder>:

* Initializes the <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder> with the minimal ASP.NET Core features necessary to run an app.
* Is added by the template whether or not the AOT option is used.

:::code language="csharp" source="~/fundamentals/aot/samples/Program.cs" highlight="4":::

Because unused code is trimmed during publishing for native AOT, the app can't use unbounded reflection at runtime. Source generators are used to produce code to avoid the need for reflection. In some cases source generators produce code optimized for AOT even when a generator is not required. To view source code that is generated based on the code in `Program.cs` add the []`<EmitCompilerGeneratedFiles>true</EmitCompilerGeneratedFiles>`](/dotnet/csharp/roslyn-sdk/source-generators-overview) property to `MyFirstAotWebApi.csproj`:

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <!-- Other properties omitted for brevity -->
    <EmitCompilerGeneratedFiles>true</EmitCompilerGeneratedFiles>
  </PropertyGroup>

</Project>
```

Run the `dotnet build` command. `publish` isn't necessary to view generated code. The built output contains an `obj/Debug/net8.0/generated/` directory and all the generated files for the project.

The `dotnet publish` command:

* Compiles the source files.
* Generates files which are are compiled.
* Passes generated assemblies to a native IL compiler. The IL compiler produces the native executable. The native executable contains the native machine code.

## Benefits of using native AOT with ASP.NET Core

Publishing and deploying a native AOT app provides the following benefits:

* **Minimized disk footprint**: When publishing using native AOT a single executable is produced containing just the code from external dependencies that is used to support the program. Reduced executable size can lead to:
  * Smaller container images, for example in containerized deployment scenarios.
  * Reduced deployment time from smaller images.
* **Reduced startup time**: Native AOT applications can show reduced start-up times. Reduced start-up means:
  * The app is ready to service requests quicker.
  * Improved deployment where container orchestrators need to manage transition from one version of the app to another.
* **Reduced memory demand**: Native AOT apps can have reduced memory demands depending on the work being performed by the app. Reduced memory consumption can lead to greater deployment density and improved scalability.

The template app was run in our benchmarking lab and shows the following improvements in size, memory, and startup time:

![Chart showing comparison of application size, memory use, and startup time metrics of an AOT published app, a runtime app that is trimmed, and an untrimmed runtime app.](~/fundamentals/aot/_static/aot-runtime-trimmed-perf-chart.png)

The preceding chart shows that native AOT has significantly lower app size, memory usage, and startup time.

## ASP.NET Core and native AOT compatibility

Not all features in ASP.NET Core are currently compatible with native AOT. The following table summarizes ASP.NET Core feature compatibility with native AOT:

| Feature | Fully Supported | Partially Supported | Not Supported |
| - | - | - | - |
| gRPC | <span aria-hidden="true">✔️</span><span class="visually-hidden">Fully supported</span> | | |
| Minimal APIs | | <span aria-hidden="true">✔️</span><span class="visually-hidden">Partially supported</span> | |
| MVC | | | <span aria-hidden="true">❌</span><span class="visually-hidden">Not supported</span> |
| Blazor Server | | |<span aria-hidden="true">❌</span><span class="visually-hidden">Not supported</span> |
| SignalR | | | <span aria-hidden="true">❌</span><span class="visually-hidden">Not supported</span> |
| Authentication | | | <span aria-hidden="true">❌</span><span class="visually-hidden">Not supported</span> (JWT soon) |
| CORS | <span aria-hidden="true">✔️</span><span class="visually-hidden">Fully supported</span> | | |
| HealthChecks | <span aria-hidden="true">✔️</span><span class="visually-hidden">Fully supported</span> | | |
| HttpLogging | <span aria-hidden="true">✔️</span><span class="visually-hidden">Fully supported</span> | | |
| Localization | <span aria-hidden="true">✔️</span><span class="visually-hidden">Fully supported</span> | | |
| OutputCaching | <span aria-hidden="true">✔️</span><span class="visually-hidden">Fully supported</span> | | |
| RateLimiting | <span aria-hidden="true">✔️</span><span class="visually-hidden">Fully supported</span> | | |
| RequestDecompression | <span aria-hidden="true">✔️</span><span class="visually-hidden">Fully supported</span> | | |
| ResponseCaching | <span aria-hidden="true">✔️</span><span class="visually-hidden">Fully supported</span> | | |
| ResponseCompression | <span aria-hidden="true">✔️</span><span class="visually-hidden">Fully supported</span> | | |
| Rewrite | <span aria-hidden="true">✔️</span><span class="visually-hidden">Fully supported</span> | | |
| Session | | |<span aria-hidden="true">❌</span><span class="visually-hidden">Not supported</span> |
| Spa | | |<span aria-hidden="true">❌</span><span class="visually-hidden">Not supported</span> |
| StaticFiles | <span aria-hidden="true">✔️</span><span class="visually-hidden">Fully supported</span> | | |
| WebSockets | <span aria-hidden="true">✔️</span><span class="visually-hidden">Fully supported</span> | | |

It's important to test the app thoroughly when moving to a native AOT deployment model. The AOT deployed app should be tested to verify functionality hasn't changed fron the  untrimmed and JIT-compiled app. When building the app, review and correct AOT warnings. An app that issues AOT warnings during publishing is not guaranteed to work correctly. If no AOT warnings are issued at publish time, the pubished AOT app should work the same as when run in development.

For more information on AOT warnings and how to address them see [Introduction to AOT warnings](/dotnet/core/deploying/native-aot/fixing-warnings).

## Known issues

See [this GitHub issue](https://github.com/dotnet/core/issues/8288) to report or review issues with native AOT support in ASP.NET Core.
