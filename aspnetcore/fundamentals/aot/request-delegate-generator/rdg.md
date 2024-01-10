---

title: ASP.NET Core Request Delegate Generator (RDG) for native AOT
description: Turn Map methods into request delegates with the ASP.NET Core Request Delegate Generator (RDG) for native AOT.
author: rick-anderson
ms.author: riande
content_well_notification: AI-contribution
monikerRange: '>= aspnetcore-8.0'
ms.topic: article
ms.date: 9/21/2023
uid: fundamentals/aot/rdg
---
# Turn Map methods into request delegates with the ASP.NET Core Request Delegate Generator

The ASP.NET Core Request Delegate Generator (RDG) is a compile-time source generator that compiles route handlers provided to a minimal API to request delegates that can be processed by ASP.NET Core's routing infrastructure. The RDG is implicitly enabled when applications are published with AoT enabled and generated trim and native AoT-friendly code.

> [!NOTE]
> * The native AOT feature is currently in preview.
> * In .NET 8, not all ASP.NET Core features are compatible with native AOT.

The RDG:

* Is a [source generator](/dotnet/csharp/roslyn-sdk/source-generators-overview)
* Turns each `Map` method into a <xref:Microsoft.AspNetCore.Http.RequestDelegate> associated with the specific route. `Map` methods include the methods in the <xref:Microsoft.AspNetCore.Builder.EndpointRouteBuilderExtensions> such as <xref:Microsoft.AspNetCore.Builder.EndpointRouteBuilderExtensions.MapGet%2A>, <xref:Microsoft.AspNetCore.Builder.EndpointRouteBuilderExtensions.MapPost%2A>, <xref:Microsoft.AspNetCore.Builder.EndpointRouteBuilderExtensions.MapPatch%2A>, <xref:Microsoft.AspNetCore.Builder.EndpointRouteBuilderExtensions.MapPut%2A>, and <xref:Microsoft.AspNetCore.Builder.EndpointRouteBuilderExtensions.MapDelete%2A>.

When publishing and native AOT is ***not*** enabled:

* `Map` methods associated with a specific route are compiled in memory into a request delegate when the app starts, not when the app is built.
* The request delegates are generated at runtime.

When publishing with native AOT enabled:

* `Map` methods associated with a specific route are compiled when the app is built. The RDG creates the request delegate for the route and the request delegate is compiled into the app's native image.
* Eliminates the need to generate the request delegate at runtime.
* Ensures:
  * The types used in the app's APIs are rooted in the app code in a way that is statically analyzable by the native AOT tool-chain.
  * The required code isn't trimmed away.

The RDG:

* Is enabled automatically in projects when publishing with native AOT is enabled.
* Can be manually enabled even when not using native AOT by setting `<EnableRequestDelegateGenerator>true</EnableRequestDelegateGenerator>` in the project file:

:::code language="xml" source="~/fundamentals/aot/samples/rdg/RDG.csproj" highlight="7":::

Manually enabling RDG can be useful for:

* Evaluating a project's compatibility with native AOT.
* To reduce the app's startup time by pregenerating the request delegates.

Minimal APIs are optimized for using <xref:System.Text.Json?displayProperty=fullName>, which requires using the [System.Text.Json source generator](/dotnet/standard/serialization/system-text-json/source-generation). All types accepted as parameters to or returned from request delegates in Minimal APIs must be configured on a <xref:System.Text.Json.Serialization.JsonSerializerContext> that is registered via ASP.NET Core’s dependency injection:

:::code language="csharp" source="~/fundamentals/aot/samples/rdg/Program.cs" highlight="5-9,32-99":::

## Diagnostics emitted for unsupported RDG scenarios

The RDG emits [diagnostics](xref:fundamentals/aot/request-delegate-generator/rdg-ids) for scenarios that aren't supported by native AOT. The diagnostics are emitted when the app is built. The diagnostics are emitted as warnings and don't prevent the app from building. <!-- tempory stub https://github.com/dotnet/aspnetcore/pull/49417  Once this API is published, replace with <xref> link --> The [DiagnosticDescriptors](https://source.dot.net/#Microsoft.AspNetCore.Http.RequestDelegateGenerator/DiagnosticDescriptors.cs,44128aef6daa9b5e) class contains the diagnostics emitted by the RDG.

See <xref:fundamentals/aot/request-delegate-generator/rdg-ids> for a list of diagnostics emitted by the RDG.
