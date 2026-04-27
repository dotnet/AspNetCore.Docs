---
title: ASP.NET Core support for Native AOT
author: tdykstra
ms.author: tdykstra
description: Review ASP.NET Core support for Native ahead-of-time (AOT) applications, including publishing and deployment.
content_well_notification: AI-contribution
ms.custom: mvc, engagement-fy23
ms.date: 04/27/2026
uid: fundamentals/native-aot
ai-usage: ai-assisted

# ms.author: midenn (Mitch Denny)
# customer intent: As an ASP.NET developer, I want to explore ASP.NET Core support for Native AOT, so I can publish and deploy my Native AOT app.
---
# ASP.NET Core support for Native AOT

By [Mitch Denny](https://github.com/mitchdenny)

<!-- UPDATE 9.0 Activate after release and INCLUDE is updated

[!INCLUDE[](~/includes/not-latest-version.md)]

-->
:::moniker range=">= aspnetcore-9.0"

Publishing and deploying Native ahead-of-time (AOT) applications in ASP.NET Core offers several benefits:

- **Minimized disk footprint**. When you publish an app by using Native AOT, the process produces a single executable file. The executable contains only the code from the external dependencies required to support the app. The reduced executable size can lead to:
  * Smaller container images, for example in containerized deployment scenarios.
  * Reduced deployment time from smaller images.

- **Reduced startup time**. Native AOT apps can require less startup time, which enables:
  * The app to service requests quicker.
  * Improved deployment, where the container orchestrators manage the transition from one app version to another.

- **Reduced memory demand**. Native AOT apps can require less memory, depending on the work done by the app. Reduced memory consumption can lead to greater deployment density and improved scalability.

The following chart shows the results of a benchmarking test on the various template apps. The benchmark compares performance for an AOT published app (orange bar), a trimmed runtime app (green bar), and an untrimmed runtime app (yellow bar). The test revealed that the Native AOT app demonstrates lower app size, memory usage, and startup time.

:::image type="content" source="~/fundamentals/aot/_static/aot-runtime-trimmed-perf-chart.png" border="false" alt-text="Chart showing a comparison of app size, memory use, and startup time metrics. The chart compares a published Native AOT app, a trimmed runtime app, and an untrimmed runtime app."

This article describes support for Native AOT apps in ASP.NET Core, including an overview of publishing and deployment.

For ASP.NET Core Blazor WebAssembly Native AOT guidance, which adds to or supersedes the guidance in this article, see [ASP.NET Core Blazor WebAssembly build tools and ahead-of-time (AOT) compilation](xref:blazor/tooling/webassembly).

## Review ASP.NET Core and Native AOT compatibility

Not all features in ASP.NET Core are currently compatible with Native AOT.

The following table summarizes ASP.NET Core feature compatibility with Native AOT:

| Feature | Supported | Partial support | Not supported |
|---|:---:|:---:|:---:|
| Blazor Server        |  |  | ❌ |
| CORS                 | ✔️ |  |  |
| gRPC                 | ✔️ |  |  |
| HealthChecks         | ✔️ |  |  |
| HttpLogging          | ✔️ |  |  |
| JWT Authentication   | ✔️ |  |  |
| Localization         | ✔️ |  |  |
| Minimal APIs         |  | ✔️ |  |
| MVC                  |  |  | ❌ |
| Other Authentication |  |  | ❌ |
| OutputCaching        | ✔️ |  |  |
| RateLimiting         | ✔️ |  |  |
| RequestDecompression | ✔️ |  |  |
| ResponseCaching      | ✔️ |  |  |
| ResponseCompression  | ✔️ |  |  |
| Rewrite              | ✔️ |  |  |
| Session              |  |  | ❌ |
| SignalR              |  | ✔️ |  |
| Spa                  |  |  | ❌ |
| StaticFiles          | ✔️ |  |  |
| WebSockets           | ✔️ |  |  |

For more information on limitations, see:

* [Limitations of Native AOT deployment](/dotnet/core/deploying/native-aot#limitations-of-native-aot-deployment)
* [AOT warnings](/dotnet/core/deploying/native-aot/fixing-warnings)
* [Known trimming incompatibilities](/dotnet/core/deploying/trimming/incompatibilities)
* [Fix trimming warnings](/dotnet/core/deploying/trimming/fixing-warnings)

### Verify app on the Native AOT deployment model

It's important to test an app thoroughly when you move to a Native AOT deployment model. Test the AOT deployed app and confirm the functionality is unchanged from the untrimmed and just-in-time (JIT) compiled app.

When you build the app, review and correct any AOT warnings. An app that issues [AOT warnings](/dotnet/core/deploying/trimming/fixing-warnings) during publishing might not work correctly. If no AOT warnings are issued at publish time, you can expect the published AOT app to work the same as the untrimmed and JIT-compiled app.

## Publish a Native AOT app (PublishAot)

Enable Native AOT for your application by using the `PublishAot` MSBuild property. The following example shows how to enable Native AOT in a project file:

```xml
<PropertyGroup>
  <PublishAot>true</PublishAot>
</PropertyGroup>
```

The `PublishAot` property enables Native AOT compilation during the publish process, and enables dynamic code usage analysis during build and editing. A project that uses Native AOT publishing implements JIT compilation when it runs locally.

An AOT app has the following differences from a JIT-compiled app:

* Features that aren't compatible with Native AOT are disabled and throw exceptions at run time.
* A source analyzer is enabled to highlight code that isn't compatible with Native AOT. At publish time, the entire app, including NuGet packages, are analyzed for compatibility again.

Native AOT analysis includes all of the application code and the libraries the app depends on. Review Native AOT warnings and take corrective steps. It's a good idea to publish apps frequently to discover issues early in the development lifecycle.

In .NET 8 and later, the following ASP.NET Core app types support Native AOT:

* **Minimal APIs** - For more information, see [Review the Web API (Native AOT) template](#review-the-web-api-native-aot-template) later in this article.
* **gRPC** - For more information, see [gRPC and Native AOT](xref:grpc/native-aot).
* **Worker services** - For more information, see [Background tasks with hosted services in ASP.NET Core > Native AOT](xref:fundamentals/host/hosted-services#native-aot).

## Review the Web API (Native AOT) template

The ASP.NET Core **Web API (Native AOT)** template (short name `webapiaot`) creates a project with AOT enabled. The template differs from a standard **Web API** project template in the following ways:

* Uses Minimal APIs only, as MVC isn't yet compatible with Native AOT.
* Uses the <xref:Microsoft.AspNetCore.Builder.WebApplication.CreateSlimBuilder> API to ensure only the essential features are enabled by default, which minimizes the app's deployed size.
* Is configured to listen on HTTP only. HTTPS traffic is commonly handled by an ingress service in cloud-native deployments.
* Doesn't include a launch profile for running under IIS or IIS Express.
* Creates an [.http file](xref:test/http-files) configured with sample HTTP requests that can be sent to the app's endpoints.
* Includes a sample `Todo` API instead of the weather forecast sample.
* Adds the `PublishAot` property to the project file, as [described earlier](#publish-a-native-aot-app-publishaot).
* Enables the [JSON serializer source generators](/dotnet/standard/serialization/system-text-json/source-generation). The source generator is used to generate serialization code at build time, which is required for Native AOT compilation.

### Code updates for JSON serialization (Program.cs)

The code in the _Program.cs_ file is modified to provide support for JSON serialization source generation.

The following snippet shows the changes to the code:

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

If you don't modify the code, `System.Text.Json` uses reflection to serialize and deserialize JSON. Reflection isn't supported in Native AOT.

For more information, see:

* [Combine source generators](/dotnet/standard/serialization/system-text-json/source-generation#combine-source-generators)
* <xref:System.Text.Json.JsonSerializerOptions.TypeInfoResolverChain>

### Code changes for launch profile (launchSettings.json)

The **Web API (Native AOT)** template creates a _launchSettings.json_ file. In contrast to a standard launch file, the generated file doesn't include the `iisSettings` section or the `IIS Express` profile.

The following snippet shows the excluded sections (colored red):

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

### CreateSlimBuilder() called for minimal app defaults

The **Web API (Native AOT)** template uses the <xref:Microsoft.AspNetCore.Builder.WebApplication.CreateSlimBuilder> method instead of the <xref:Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder> method.

:::code language="csharp" source="~/fundamentals/aot/samples/Program.cs" highlight="4":::

The `CreateSlimBuilder` method initializes the <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder> with the minimum ASP.NET Core features necessary to run an app.

As described earlier, the `CreateSlimBuilder` method doesn't include support for HTTPS or HTTP/3. These protocols typically aren't required for apps that run behind a TLS termination proxy. For example, see [TLS termination and end to end TLS with Application Gateway](/azure/application-gateway/ssl-overview). You can enable HTTPS by calling the 
[builder.WebHost.UseKestrelHttpsConfiguration](/dotnet/api/microsoft.aspnetcore.hosting.webhostbuilderkestrelextensions.usekestrelhttpsconfiguration) method, or enable HTTP/3 by calling the [builder.WebHost.UseQuic](xref:Microsoft.AspNetCore.Hosting.WebHostBuilderQuicExtensions.UseQuic%2A).

## Compare CreateSlimBuilder() and CreateBuilder()

The `CreateSlimBuilder` method provides access to a portion of the application features available with the `CreateBuilder` method. As described earlier, the **Web API (Native AOT)** template calls `CreateSlimBuilder` to initialize <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder>, so the builder uses the minimum ASP.NET Core features necessary to run the app.

Both methods provide the necessary features for an efficient development experience:

* Configuration for the _appsettings.json_ and _appsettings.{EnvironmentName}.json_ files
* User secrets configuration
* Console logging
* Logging configuration

Including minimal features has benefits for trimming as well as AOT. For more information, see [Trim self-contained deployments and executables](/dotnet/core/deploying/trimming/trim-self-contained).

If you prefer to use a builder that omits all features, see the [WebApplication.CreateEmptyBuilder](/dotnet/api/microsoft.aspnetcore.builder.webapplication.createemptybuilder) method.

### Unavailable features in CreateSlimBuilder

The `CreateSlimBuilder` method **doesn't** provide the following features, which are available in `CreateBuilder`:

* [Hosting startup assemblies](xref:fundamentals/configuration/platform-specific-configuration)
* [UseStartup](xref:Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.UseStartup%2A) method
* Logging providers:
    * [Windows EventLog](/aspnet/core/fundamentals/logging#windows-eventlog)
    * [Debug](/aspnet/core/fundamentals/logging#debug)
    * [EventSource](/aspnet/core/fundamentals/logging#eventsource)
* Web hosting features:
    * [UseStaticWebAssets](xref:Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.UseStaticWebAssets%2A) method
    * [IIS integration](xref:host-and-deploy/iis/index)
* Kestrel configuration:
    * [HTTPS endpoints](xref:fundamentals/servers/kestrel/endpoints#configure-https)
    * [QUIC (HTTP/3)](xref:fundamentals/servers/kestrel/http3#http3-benefits)
* [Regex and alpha constraints used in routing (GitHub /dotnet/aspnetcore/issues #46142)](https://github.com/dotnet/aspnetcore/issues/46142)

For more detailed information, see [Comparing WebApplication.CreateBuilder to CreateSlimBuilder](https://andrewlock.net/exploring-the-dotnet-8-preview-comparing-createbuilder-to-the-new-createslimbuilder-method/)

## Use source generators and avoid reflection

During the publishing process for Native AOT, any unused code is trimmed. As a result, an app can't use unbounded reflection at runtime. You can use [source generators](/dotnet/csharp/roslyn-sdk/#source-generators) that produce code that avoids the need for reflection. In some cases, source generators output code optimized for AOT even when a generator isn't required.

- To view the generated source code, add the [EmitCompilerGeneratedFiles](/dotnet/core/extensions/configuration-generator) property to the application project (_.csproj_) file:

   ```xml
   <Project Sdk="Microsoft.NET.Sdk.Web">

     <PropertyGroup>
       <!-- Other properties omitted for brevity -->
       <EmitCompilerGeneratedFiles>true</EmitCompilerGeneratedFiles>
     </PropertyGroup>

   </Project>
   ```

- To see the generated code, run the `dotnet build` command. The command compiles the source files and generates the intermediate files needed to run the app in a development environment. The output includes an _obj/Debug/<.NET version>/generated/_ directory that contains all the generated files for the project.

- To prepare the app for deployment, run the `dotnet publish` command. The command compiles the source files and generates all files required to deploy the app. It passes the generated assemblies to a native IL compiler, which produces the native executable. The native executable contains the native machine code.

[!INCLUDE[](~/fundamentals/aot/includes/aot_lib.md)]

## Work with Minimal APIs and JSON payloads

The Minimal API framework is optimized for receiving and returning JSON payloads by using the <xref:System.Text.Json>.

* The namespace imposes compatibility requirements for JSON and Native AOT.
* It requires the use of the [System.Text.Json source generator](/dotnet/standard/serialization/system-text-json/source-generation).

All types transmitted as part of the HTTP body or returned from request delegates in Minimal APIs apps must be configured on a <xref:System.Text.Json.Serialization.JsonSerializerContext> instance. The instance must be registered with ASP.NET Core dependency injection:

:::code language="csharp" source="~/fundamentals/aot/samples/Program.cs" highlight="7-10,25-99":::

* The JSON serializer context is registered with the [DI container](xref:fundamentals/dependency-injection). For more information, see [Combine source generators](/dotnet/standard/serialization/system-text-json/source-generation#combine-source-generators) and the <xref:System.Text.Json.JsonSerializerOptions.TypeInfoResolverChain>.

* The custom `JsonSerializerContext` is annotated with the [JsonSerializable](/dotnet/api/system.text.json.serialization.jsonserializableattribute) attribute, which enables source generated JSON serializer code for the `ToDo` type.

A parameter on the delegate that isn't bound to the body **doesn't** need to be serializable. For example, a query string parameter can be a rich object type that implements `IParsable<T>`.

:::code language="csharp" source="~/fundamentals/aot/samples/Todo.cs" id="snippet_1":::

## Review known issues

To report or review issues with Native AOT support in ASP.NET Core, see [GitHub /dotnet/core/issues #8288)](https://github.com/dotnet/core/issues/8288).

## Related content

* [Publish an ASP.NET Core app with Native AOT](xref:fundamentals/native-aot-tutorial)
* [Native AOT deployment](/dotnet/core/deploying/native-aot/)
* [Optimize AOT deployments](/dotnet/core/deploying/native-aot/optimizing)

:::moniker-end

[!INCLUDE[](~/fundamentals/native-aot/includes/native-aot8.md)]