---
title: ASP.NET Core support for native AOT
author: mitchdenny
description: Learn about ASP.NET Core support for native AOT
monikerRange: '>= aspnetcore-8.0'
ms.author: midenn
content_well_notification: AI-contribution
ms.custom: mvc, engagement-fy23
ms.date: 10/17/2023
uid: fundamentals/native-aot
---
# ASP.NET Core support for native AOT

ASP.NET Core 8.0 introduces support for [.NET native ahead-of-time (AOT)](/dotnet/core/deploying/native-aot/).

## Why use native AOT with ASP.NET Core

Publishing and deploying a native AOT app provides the following benefits:

* **Minimized disk footprint**: When publishing using native AOT, a single executable is produced containing just the code from external dependencies that is needed to support the program. Reduced executable size can lead to:
  * Smaller container images, for example in containerized deployment scenarios.
  * Reduced deployment time from smaller images.
* **Reduced startup time**: Native AOT applications can show reduced start-up times, which means
  * The app is ready to service requests quicker.
  * Improved deployment where container orchestrators need to manage transition from one version of the app to another.
* **Reduced memory demand**: Native AOT apps can have reduced memory demands, depending on the work done by the app. Reduced memory consumption can lead to greater deployment density and improved scalability.

The template app was run in our benchmarking lab to compare performance of an AOT published app, a trimmed runtime app, and an untrimmed runtime app. The following chart shows the results of the benchmarking:

![Chart showing comparison of application size, memory use, and startup time metrics of an AOT published app, a runtime app that is trimmed, and an untrimmed runtime app.](~/fundamentals/aot/_static/aot-runtime-trimmed-perf-chart.png)

The preceding chart shows that native AOT has lower app size, memory usage, and startup time.

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

For more information on limitations, see:

* [Limitations of Native AOT deployment](/dotnet/core/deploying/native-aot#limitations-of-native-aot-deployment)
* [Introduction to AOT warnings](/dotnet/core/deploying/native-aot/fixing-warnings)
* [Known trimming incompatibilities](/dotnet/core/deploying/trimming/incompatibilities)
* [Introduction to trim warnings](/dotnet/core/deploying/trimming/fixing-warnings)
* [GitHub issue dotnet/core #8288](https://github.com/dotnet/core/issues/8288)

It's important to test an app thoroughly when moving to a native AOT deployment model. The AOT deployed app should be tested to verify functionality hasn't changed from the untrimmed and JIT-compiled app. When building the app, review and correct AOT warnings. An app that issues [AOT warnings](/dotnet/core/deploying/trimming/fixing-warnings) during publishing may not work correctly. If no AOT warnings are issued at publish time, the published AOT app should work the same as the untrimmed and JIT-compiled app.

## Native AOT publishing

Native AOT is enabled with the `PublishAot` MSBuild property. The following example shows how to enable native AOT in a project file:

```xml
<PropertyGroup>
  <PublishAot>true</PublishAot>
</PropertyGroup>
```

This setting enables native AOT compilation during publish and enables dynamic code usage analysis during build and editing. A project that uses native AOT publishing uses JIT compilation when running locally. An AOT app has the following differences from a JIT-compiled app:

* Features that aren't compatible with native AOT are disabled and throw exceptions at run time.
* A source analyzer is enabled to highlight code that isn't compatible with native AOT. At publish time, the entire app, including NuGet packages, are analyzed for compatibility again.

Native AOT analysis includes all of the app's code and the libraries the app depends on. Review native AOT warnings and take corrective steps. It's a good idea to publish apps frequently to discover issues early in the development lifecycle.

In .NET 8, native AOT is supported by the following ASP.NET Core app types:

* minimal APIs - For more information, see the [The Web API (native AOT) template](#the-web-api-native-aot-template) section later in this article.
* gRPC - For more information, see [gRPC and native AOT](xref:grpc/native-aot).
* Worker services - For more information, see [AOT in Worker Service templates](xref:fundamentals/host/hosted-services?view=aspnetcore-8.0&preserve-view=true#native-aot).

## The Web API (native AOT) template

The **ASP.NET Core Web API (native AOT)** template (short name `webapiaot`) creates a project with AOT enabled. The template differs from the **Web API** project template in the following ways:

* Uses minimal APIs only, as MVC isn't yet compatible with native AOT.
* Uses the <xref:Microsoft.AspNetCore.Builder.WebApplication.CreateSlimBuilder> API to ensure only the essential features are enabled by default, minimizing the app's deployed size.
* Is configured to listen on HTTP only, as HTTPS traffic is commonly handled by an ingress service in cloud-native deployments.
* Doesn't include a launch profile for running under IIS or IIS Express.
* Creates an [`.http` file](xref:test/http-files) configured with sample HTTP requests that can be sent to the app's endpoints.
* Includes a sample `Todo` API instead of the weather forecast sample.
* Adds `PublishAot` to the project file, as shown [earlier in this article](#native-aot-publishing).
* Enables the [JSON serializer source generators](/dotnet/standard/serialization/system-text-json/source-generation). The source generator is used to generate serialization code at build time, which is required for native AOT compilation.

### Changes to support source generation

The following example shows the code added to the `Program.cs` file to support JSON serialization source generation:

```diff
using MyFirstAotWebApi;
+using System.Text.Json.Serialization;

-var builder = WebApplication.CreateBuilder();
+var builder = WebApplication.CreateSlimBuilder(args);

+builder.Services.ConfigureHttpJsonOptions(options =>
+{
+  options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
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

Without this added code, `System.Text.Json` uses reflection to serialize and deserialize JSON. Reflection isn't supported in native AOT.

For more information, see:

* [Combine source generators](/dotnet/standard/serialization/system-text-json/source-generation?pivots=dotnet-8-0#combine-source-generators)
* <xref:System.Text.Json.JsonSerializerOptions.TypeInfoResolverChain>

### Changes to `launchSettings.json`

The `launchSettings.json` file created by the **Web API (native AOT)** template has the `iisSettings` section and `IIS Express` profile removed:

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

<a name="csb"></a>

### The `CreateSlimBuilder` method

The template uses the <xref:Microsoft.AspNetCore.Builder.WebApplication.CreateSlimBuilder> method instead of the <xref:Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder> method.

:::code language="csharp" source="~/fundamentals/aot/samples/Program.cs" highlight="4":::

The `CreateSlimBuilder` method initializes the <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder> with the minimum ASP.NET Core features necessary to run an app.

As noted earlier, the `CreateSlimBuilder` method doesn't include support for HTTPS or HTTP/3. These protocols typically aren't required for apps that run behind a TLS termination proxy. For example, see [TLS termination and end to end TLS with Application Gateway](/azure/application-gateway/ssl-overview). HTTPS can be enabled by calling [builder.WebHost.UseKestrelHttpsConfiguration](https://source.dot.net/#Microsoft.AspNetCore.Server.Kestrel/WebHostBuilderKestrelExtensions.cs,fcec859000ccaa50) <!-- TODO replace with xref: (xref:Microsoft.AspNetCore.Hosting.WebHostBuilderKestrelExtensions.UseKestrel%2A) --> HTTP/3 can be enabled by calling [builder.WebHost.UseQuic](xref:Microsoft.AspNetCore.Hosting.WebHostBuilderQuicExtensions.UseQuic%2A).

The `CreateSlimBuilder` method does include the following features needed for an efficient development experience:

* JSON file configuration for `appsettings.json` and `appsettings.{EnvironmentName}.json`.
* User secrets configuration.
* Console logging.
* Logging configuration.

For a builder that omits even these features, see [The `CreateEmptyBuilder` method](xref:aspnetcore-8#new-createemptybuilder-method).

Including minimal features has benefits for trimming as well as AOT. For more information, see [Trim self-contained deployments and executables](/dotnet/core/deploying/trimming/trim-self-contained).

For more information on `CreateSlimBuilder`, see [Comparing `WebApplication.CreateBuilder` to `CreateSlimBuilder`](https://andrewlock.net/exploring-the-dotnet-8-preview-comparing-createbuilder-to-the-new-createslimbuilder-method/)

## Source generators

Because unused code is trimmed during publishing for native AOT, the app can't use unbounded reflection at runtime. [Source generators](/dotnet/csharp/roslyn-sdk/source-generators-overview) are used to produce code that avoids the need for reflection. In some cases, source generators produce code optimized for AOT even when a generator isn't required.

To view the source code that is generated, add the [`EmitCompilerGeneratedFiles`](/dotnet/csharp/roslyn-sdk/source-generators-overview) property to an app's `.csproj` file, as shown in the following example:

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <!-- Other properties omitted for brevity -->
    <EmitCompilerGeneratedFiles>true</EmitCompilerGeneratedFiles>
  </PropertyGroup>

</Project>
```

Run the `dotnet build` command to see the generated code. The output includes an `obj/Debug/net8.0/generated/` directory that contains all the generated files for the project.

The `dotnet publish` command also compiles the source files and generates files that are compiled. In addition, `dotnet publish` passes the generated assemblies to a native IL compiler. The IL compiler produces the native executable. The native executable contains the native machine code.

[!INCLUDE[](~/fundamentals/aot/includes/aot_lib.md)]

## Minimal APIs and JSON payloads

The Minimal API framework is optimized for receiving and returning JSON payloads using <xref:System.Text.Json?displayProperty=fullName>. `System.Text.Json`:

* Imposes compatibility requirements for JSON and native AOT.
* Requires the use of the [`System.Text.Json` source generator](/dotnet/standard/serialization/system-text-json/source-generation).

All types that are transmitted as part of the HTTP body or returned from request delegates in Minimal APIs apps must be configured on a <xref:System.Text.Json.Serialization.JsonSerializerContext> that is registered via ASP.NET Core’s dependency injection:

:::code language="csharp" source="~/fundamentals/aot/samples/Program.cs" highlight="7-10,25-99":::

In the preceding highlighted code:

* The JSON serializer context is registered with the [DI container](xref:fundamentals/dependency-injection). For more information, see:
  * [Combine source generators](/dotnet/standard/serialization/system-text-json/source-generation?pivots=dotnet-8-0#combine-source-generators)
  * <xref:System.Text.Json.JsonSerializerOptions.TypeInfoResolverChain>
* The custom `JsonSerializerContext` is annotated with the [`[JsonSerializable]`](/dotnet/api/system.text.json.serialization.jsonserializableattribute) attribute to enable source generated JSON serializer code for the `ToDo` type.

A parameter on the delegate that isn't bound to the body and does ***not*** need to be serializable. For example, a query string parameter that is a rich object type and implements `IParsable<T>`.

:::code language="csharp" source="~/fundamentals/aot/samples/Todo.cs" id="snippet_1":::

## Known issues

See [this GitHub issue](https://github.com/dotnet/core/issues/8288) to report or review issues with native AOT support in ASP.NET Core.

## See also

* <xref:fundamentals/native-aot-tutorial>
* [Native AOT deployment](/dotnet/core/deploying/native-aot/)
* [Optimize AOT deployments](/dotnet/core/deploying/native-aot/optimizing)
* [Configuration-binding source generator](/dotnet/core/whats-new/dotnet-8#configuration-binding-source-generator)
* [Using the configuration binder source generator](https://andrewlock.net/exploring-the-dotnet-8-preview-using-the-new-configuration-binder-source-generator/)
* [The minimal API AOT compilation template](https://andrewlock.net/exploring-the-dotnet-8-preview-the-minimal-api-aot-template/)
* [Comparing `WebApplication.CreateBuilder` to `CreateSlimBuilder`](https://andrewlock.net/exploring-the-dotnet-8-preview-comparing-createbuilder-to-the-new-createslimbuilder-method/)
* [Exploring the new minimal API source generator](https://andrewlock.net/exploring-the-dotnet-8-preview-exploring-the-new-minimal-api-source-generator/)
* [Replacing method calls with Interceptors](https://andrewlock.net/exploring-the-dotnet-8-preview-changing-method-calls-with-interceptors/)