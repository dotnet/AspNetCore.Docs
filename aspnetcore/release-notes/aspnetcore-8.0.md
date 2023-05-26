---
title: What's new in ASP.NET Core 8.0
author: rick-anderson
description: Learn about the new features in ASP.NET Core 8.0.
ms.author: riande
ms.custom: mvc
ms.date: 05/26/2023
uid: aspnetcore-8
---
# What's new in ASP.NET Core 8.0

This article highlights the most significant changes in ASP.NET Core 8.0 with links to relevant documentation.

This article is under development and not complete. More information may be found in the ASP.NET Core 8.0 preview blogs and GitHub issue:

* [ASP.NET Core roadmap for .NET 8 on GitHub](https://github.com/dotnet/aspnetcore/issues/44984) 
* [What's new in .NET 8 Preview 1](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-preview-1/)
* [What's new in .NET 8 Preview 2](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-preview-2/)
* [What's new in .NET 8 Preview 3](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-preview-3/)
* [What's new in .NET 8 Preview 4](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-preview-4/)
<!--
* [What's new in .NET 8 Preview 5](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-preview-5/)
* [What's new in .NET 8 Preview 6](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-preview-6/)
* [What's new in .NET 8 Preview 7](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-preview-7/)
-->

<!--
## Blazor
-->

## Minimal APIs

### Binding to forms with IFormCollection, IFormFile, and IFormFileCollection

Binding to forms using <xref:Microsoft.AspNetCore.Http.IFormCollection>, <xref:Microsoft.AspNetCore.Http.IFormFile>, and <xref:Microsoft.AspNetCore.Http.IFormFileCollection> is now supported. [OpenAPI](xref:fundamentals/minimal-apis/openapi) metadata is inferred for form parameters to support integration with [Swagger UI](xref:tutorials/web-api-help-pages-using-swagger).

For more information, see [Binding to forms with IFormCollection, IFormFile, and IFormFileCollection](xref:fundamentals/minimal-apis/parameter-binding?view=aspnetcore-8.0&preserve-view=true#binding-to-forms-with-iformcollection-iformfile-and-iformfilecollection)

## Support for native AOT

Support for [.NET native ahead-of-time (AOT)](/dotnet/core/deploying/native-aot/) has been added. Apps that are published using AOT can have substantially better performance: smaller app size, less memory usage, and faster startup time. Native AOT is currently supported by gRPC, minimal API, and worker service apps. For more information, see [ASP.NET Core support for native AOT](xref:fundamentals/native-aot).

### New project template

The new **ASP.NET Core API** template in Visual Studio 2022 has an **Enable native AOT publish** option. The equivalent template and option in the CLI is the `dotnet new api` command and the `--aot` option. This template is intended to produce a project focused on cloud-native, API-first scenarios. For more information, see [The API template](xref:fundamentals/native-aot#the-api-template).

### New CreateSlimBuilder method

The <xref:Microsoft.AspNetCore.Builder.WebApplication.CreateSlimBuilder> method used in the API template initializes the <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder> with the minimum ASP.NET Core features necessary to run an app. It's used by the API template whether or not the AOT option is used. For more information, see [The `CreateSlimBuilder` method](xref:fundamentals/native-aot#the-createslimbuilder-method).

### JSON serialization of compiler-generated `IAsyncEnumerable<T>` types

New features were added to <xref:System.Text.Json> to better support native AOT. These new features add capabilities for the source generation mode of `System.Text.Json`, because reflection isn't supported by AOT.

One of the new features is support for JSON serialization of <xref:System.Collections.Generic.IAsyncEnumerable%601> implementations implemented by the C# compiler. This support opens up their use in ASP.NET Core projects configured to publish native AOT.

This API is useful in scenarios where a route handler uses `yield return` to asynchronously return an enumeration. For example, to materialize rows from a database query. For more information, see [Unspeakable type support](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-preview-4/#unspeakable-type-support) in the .NET 8 Preview 4 announcement.

For information abut other improvements in `System.Text.Json` source generation, see [Serialization improvements in .NET 8](/dotnet/core/whats-new/dotnet-8#serialization).

### Top-level APIs annotated for trim warnings

The main entry points to subsystems that don't work reliably with native AOT are now annotated. When these methods are called from an application with native AOT enabled, a warning is provided. For example, the following code produces a warning at the invocation of `AddControllers` because this API is not trim-safe and isn't supported by native AOT.

:::image type="content" source="../fundamentals/aot/_static/top-level-annnotations.png" alt-text="Visual Studio window showing IL2026 warning message on the AddControllers method that says MVC does not currently support native AOT.":::

## Miscellaneous

### HTTP/3 enabled by default

HTTP/3 is a new internet technology that was standardized in June 2022. HTTP/3 offers several advantages over older HTTP protocols, including:

* Faster connection setup.
* No head-of-line blocking.
* Better transitions between networks.

.NET 7 added support for HTTP/3 to ASP.NET Core and Kestrel. ASP.NET Core apps could choose to turn it on. In .NET 8 HTTP/3 is enabled by default for Kestrel, alongside HTTP/1.1 and HTTP/2. For more information about HTTP/3 and its requirements, see <xref:fundamentals/servers/kestrel/http3>.

### Code analysis in ASP.NET Core apps

The following new analyzers are available in ASP.NET Core 8.0:

| Diagnostic ID    | Breaking or non-breaking | Description |
|-------|-------|----------------------------|
| [ASP0020](xref:diagnostics/asp0020) | Non-breaking             | Complex types referenced by route parameters must be parsable |
| [ASP0021](xref:diagnostics/asp0021) | Non-breaking             | The return type of the BindAsync method must be `ValueTask<T>` |
| [ASP0022](xref:diagnostics/asp0022) | Non-breaking             | Route conflict detected between route handlers |
| [ASP0023](xref:diagnostics/asp0023) | Non-breaking             | MVC: Route conflict detected between route handlers |
| [ASP0024](xref:diagnostics/asp0024) | Non-breaking             | Route handler has multiple parameters with the `[FromBody]` attribute |
| [ASP0025](xref:diagnostics/asp0025) | Non-breaking             | Use AddAuthorizationBuilder |

<!--
## API controllers

## gRPC
-->
