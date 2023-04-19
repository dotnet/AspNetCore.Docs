---
title: ASP.NET Core support for native AOT
author: mitchdenny
description: Learn about ASP.NET Core support for native AOT
monikerRange: '>= aspnetcore-8.0'
ms.author: midenn
ms.custom: mvc
ms.date: 04/10/2023
uid: fundamentals/native-aot
---
# ASP.NET Core support for native AOT

ASP.NET Core 8.0 introduces support for [.NET native ahead-of-time (AOT)](/dotnet/core/deploying/native-aot/). This article covers:

* How to get started.
* The benefits and potential drawbacks.
* Compatibility requirements.

> [!WARNING]
> In .NET 8, not all ASP.NET Core features are compatible with native AOT.

## Native AOT publishing

AOT compilation happens when the app is published. Native AOT is enabled with the `PublishAot` option:

```xml
<PropertyGroup>
  <PublishAot>true</PublishAot>
</PropertyGroup>
```

A project that uses native AOT publishing uses JIT compilation when running locally. The AOT app and JIT app have the following differences:

* Some features that aren't compatible with native AOT are disabled and throw exceptions at runtime.
* A source analyzer is enabled to highlight code that isn't compatible with native AOT. At publish time, the entire app, including NuGet packages, are analyzed for compatibility again.

Native AOT analysis includes all of the app's code and the libraries the app depends on. Review native AOT warnings and take corrective steps. It's a good idea to test publishing apps frequently to discover issues early in the development lifecycle.

## Get started

Native AOT is supported by ASP.NET Core minimal APIs and gRPC. For more information about getting started using native AOT with gRPC apps, see [gRPC and native AOT](xref:grpc/native-aot).

To get started with native AOT and a minimal API, use either:

* ASP.NET Core API Application template, which includes an option to enable publishing native AOT in the new project. The AOT option includes customizations to remove unsupported components from the app.
* ```dotnet new``` command to create a new ASP.NET Core API app that is configured to work with native AOT:

```cli
$ dotnet new api -aot -o MyFirstAotWebApi && cd MyFirstAotWebApi
The template "ASP.NET Core API" was created successfully.

Processing post-creation actions...
Restoring C:\Code\Demos\MyFirstAotWebApi\MyFirstAotWebApi.csproj:
  Determining projects to restore...
  Restored C:\Code\Demos\MyFirstAotWebApi\MyFirstAotWebApi.csproj (in 302 ms).
Restore succeeded.
```

Use the following command to verify an app can be published using native AOT:

```cli
$ dotnet publish
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

Note: The preceding output my differ from what you see depending on the version of .NET 8 used.
Review the contents of the output directory:

```
$ dir bin\Release\net8.0\win-x64\publish

    Directory: C:\Code\Demos\MyFirstAotWebApi\bin\Release\net8.0\win-x64\publish

Mode                 LastWriteTime         Length Name
----                 -------------         ------ ----
-a---          30/03/2023  1:41 PM        9480704 MyFirstAotWebApi.exe
-a---          30/03/2023  1:41 PM       43044864 MyFirstAotWebApi.pdb
```

The executable is self-contained and doesn't require a .NET runtime to run. When launched it should behave the same as the app run in the development environment:

```
$ .\bin\Release\net8.0\win-x64\publish\MyFirstAotWebApi.exe
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Production
info: Microsoft.Hosting.Lifetime[0]
      Content root path: C:\Code\Demos\MyFirstAotWebApi
```

The `Program.cs` source file contains some changes for publishing to native AOT. A significant difference is that `Microsoft.AspNetCore.Builder.WebApplication.CreateSlimBuilder` is used to create the web application builder.  The `CreateSlimBuilder` method initializes the <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder> with the minimal ASP.NET Core features necessary to run an application.
<!-- Update the preceding with the following when the .NET 8 API is published :
<xref:Microsoft.AspNetCore.Builder.WebApplication.CreateBuilderSlim%2A>
-->

```csharp
var builder = WebApplication.CreateSlimBuilder(args);
```

This template uses JSON to serialize responses. To enable JSON serialization with native AOT, provide a `JsonSerializerContext` which specifies the custom types that is need to serialize. The `JsonSerializerContext` is what the [JSON source generator](/dotnet/standard/serialization/system-text-json/source-generation) uses to produce code:

```csharp
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.AddContext<AppJsonSerializerContext>();
});

// Other code trimmed for brevity.

[JsonSerializable(typeof(Todo[]))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{

}
```

Because unused code is trimmed during publishing for native AOT, the app can't use unbounded reflection at runtime. Source generators are used to produce code to avoid the need for reflection. In some cases source generators produce code optimized for AOT even when a generator is not required. To view source code that is generated based on the code in `Program.cs` modify the `MyFirstAotWebApi.csproj` to include the `<EmitCompilerGeneratedFiles>true</EmitCompilerGeneratedFiles>` property:

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <!-- Other properties omitted for brevity -->
    <EmitCompilerGeneratedFiles>true</EmitCompilerGeneratedFiles>
  </PropertyGroup>

</Project>
```

Run the `dotnet build` command. `publish` isn't necessary to view generated code. The built output contains an `obj/Debug/net8.0/generated/` directory and all the generated files for the project.

When `dotnet publish` is run:

* The project source files and generated source files are compiled.
* Generated assemblies are passed to an native IL compiler which produces the native executable. The native executable contains the native machine code.
* The native app is ready to run.

## Benefits of using native AOT with ASP.NET Core

Publishing and deploying a native AOT app provides the following benefits:

* **Minimize disk footprint**: When publishing using native AOT a single executable is produced containing just the code from external dependencies that is used to support the program. Reduced executable size can lead to:
  * Smaller container images, for example in containerized deployment scenarios.
  * Reduce deployment time from smaller images.
* **Reduced startup time**: Native AOT applications can show reduced start-up times. Reduced start-up means:
  * The app is ready to service requests quicker.
  * Improved deployment where container orchestrators need manage transition from one version of the app to another.
* **Reduce memory demand**: Native AOT apps can have reduced memory demands depending on the work being performed by the app. Reduced memory consumption can lead to greater deployment density and improved scalability.

The template app was run in our benchmarking lab and shows the following improvements in size, memory, and startup time:

![Chart showing comparison of application size, memory use and startup time metrics of an AOT published app, a runtime app that is trimmed, and an untrimmed runtime app.](~/fundamentals/aot/_static/aot-runtime-trimmed-perf-chart.png)

The preceding chart shows the native AOT has a significantly lower app size, memory used, and startup time.

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

It'a important to test the app thoroughly when moving to a native AOT deployment model. The AOT deployed app should be tested to verify functionality hasn't changed fron the  untrimmed and JIT-compiled app. When building the app, examine and correct AOT warnings. An app that issues AOT warnings during publishing is not guaranteed to work correctly. If no AOT warnings are issued at publish time, the pubished AOT app should work the same as when run in develoment.

For more information on AOT warnings and how to address them see, [Introduction to AOT warnings](/dotnet/core/deploying/native-aot/fixing-warnings).

## Known issues

See [this GitHub issue](https://github.com/dotnet/core/issues/8288) to report or review know 
 known issues with native AOT support in ASP.NET Core.
