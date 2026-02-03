---
title: ASP.NET Core OpenAPI XML documentation comment support in ASP.NET Core
ai-usage: ai-assisted
author: wadepickett
description: Learn how to integrate XML documentation comments on types by OpenAPI document generation in ASP.NET Core.
monikerRange: '>= aspnetcore-10.0'
ms.author: wpickett
ms.custom: mvc
ms.date: 08/25/2025
uid: fundamentals/openapi/aspnet-openapi-xml
---
# OpenAPI XML documentation comment support in ASP.NET Core

ASP.NET Core XML documentation processing extracts code comments automatically to populate API documentation, ensuring the code and documentation remain synchronized. Metadata from XML documentation comments is included in the generated OpenAPI document without requiring changes to the app code, as long as the project is configured to generate the XML documentation file. XML documentation comments are automatically detected in the application assembly and referenced assemblies with XML documentation enabled.

ASP.NET Core processes [XML documentation tags](/dotnet/csharp/language-reference/xmldoc/recommended-tags) like: `<c>`, `<code>`, `<list>`, `<para>`, `<paramref>`, `<typeparamref>`, `<see>`, and `<seealso>`. For XML documentation tags that use references to other elements, like `<see cref="SomeOtherType">`, the implementation strips out the XML tag and maps the reference to plain text for inclusion in the OpenAPI document.

ASP.NET Core XML documentation processing doesn't affect runtime performance. The source generator processes XML documentation at compile time and caches the results, with minimal runtime overhead when rendering the OpenAPI documentation. Furthermore, the OpenAPI document can be cached at runtime using [output-caching](/aspnet/core/performance/caching/overview#output-caching) to further optimize performance.

This article includes a [sample app](#download10) that demonstrates the [`Microsoft.AspNetCore.OpenApi`](https://www.nuget.org/packages/Microsoft.AspNetCore.OpenApi) package's ability to integrate XML documentation comments on types into OpenAPI documents. The sample app is a minimal ASP.NET Core Web API project to generate OpenAPI documents. The XML documentation comments are used to populate summaries, descriptions, parameter information, and response details in the generated OpenAPI document.

The following image shows the Scalar UI with XML documentation comments integrated into the OpenAPI document of the sample app:

![screenshot of app with XML comments in sclaar UI](~/fundamentals/openapi/_static/screenshot.png)

### Supported XML documentation tags

* [`<summary>`](/dotnet/csharp/language-reference/xmldoc/recommended-tags#summary) 
* [`<remarks>`](/dotnet/csharp/language-reference/xmldoc/recommended-tags#remarks)
* [`<param>`](/dotnet/csharp/language-reference/xmldoc/recommended-tags#param)
* [`<returns>`](/dotnet/csharp/language-reference/xmldoc/recommended-tags#returns)
* [`<response>`](/dotnet/csharp/language-reference/xmldoc/recommended-tags#response)
* [`<example>`](/dotnet/csharp/language-reference/xmldoc/recommended-tags#example)
* [`<deprecated>`](/dotnet/csharp/language-reference/xmldoc/recommended-tags#deprecated)
* [`<inheritdoc>`](/dotnet/csharp/language-reference/xmldoc/recommended-tags#inheritdoc)

### Document HTTP responses

Document HTTP responses with the `<response>` tag and the `code` attribute:

:::code language="csharp" source="~/fundamentals/openapi/samples/10.x/aspnet-openapi-xml/api/ProjectBoardApis.cs" id="snippet_1" highlight="6-7":::

<!--```csharp
/// <response code="200">Success response with data</response>
/// <response code="404">Resource not found</response>
```-->

### Add examples

To add examples to documentation, use the [`<example>`](/dotnet/csharp/language-reference/xmldoc/recommended-tags#example) tag for types or the `example` attribute for parameters:

```csharp
/// <example>{"name":"Sample","value":42}</example>
/// <param name="id" example="42">The unique identifier</param>
```

## Customizing XML documentation behavior

The following sections describe how to enable and customize XML documentation support.

### Enable XML documentation in an ASP.NET Core API project

1. Enable XML documentation in the project file:

    :::code language="xml" source="~/fundamentals/openapi/samples/10.x/aspnet-openapi-xml/models/Models.csproj" highlight="7":::

2. Use the [AddOpenApi](xref:Microsoft.Extensions.DependencyInjection.OpenApiServiceCollectionExtensions.AddOpenApi*) method in the service configuration. No configuration is needed, the source generator handles the rest.

    :::code language="csharp" source="~/fundamentals/openapi/samples/10.x/aspnet-openapi-xml/api/Program.cs" highlight="6":::

The source generator detects all standard overloads:

* [`AddOpenApi()`](xref:Microsoft.Extensions.DependencyInjection.OpenApiServiceCollectionExtensions.AddOpenApi(Microsoft.Extensions.DependencyInjection.IServiceCollection))
* [`AddOpenApi("v1")`](xref:Microsoft.Extensions.DependencyInjection.OpenApiServiceCollectionExtensions.AddOpenApi(Microsoft.Extensions.DependencyInjection.IServiceCollection,System.String))
* [`AddOpenApi(options => {})`](xref:Microsoft.Extensions.DependencyInjection.OpenApiServiceCollectionExtensions.AddOpenApi(Microsoft.Extensions.DependencyInjection.IServiceCollection,System.Action{Microsoft.AspNetCore.OpenApi.OpenApiOptions}))
* [`AddOpenApi("v1", options => {})`](xref:Microsoft.Extensions.DependencyInjection.OpenApiServiceCollectionExtensions.AddOpenApi(Microsoft.Extensions.DependencyInjection.IServiceCollection,System.String,System.Action{Microsoft.AspNetCore.OpenApi.OpenApiOptions}))

Each overload is intercepted to automatically include the XML documentation transformers. The source generator doesn't handle overloads where the `documentName` parameter isn't a literal string expression. For example, the transformer isn't registered in the following scenarios:

```csharp
var documentName = "v1";
builder.Services.AddOpenApi(documentName); // No XML support
```

### Add XML documentation sources

The [`Microsoft.AspNetCore.OpenApi`](https://www.nuget.org/packages/Microsoft.AspNetCore.OpenApi) NuGet package automatically resolves XML documentation comments from:

* The application assembly, when the `GenerateDocumentationFile` property is set. In the [sample app](#download10), the `API` project.

  :::code language="xml" source="~/fundamentals/openapi/samples/10.x/aspnet-openapi-xml/models/Models.csproj" highlight="7":::

* Any projects referenced via `ProjectReferences` that have the `GenerateDocumentationFile` property set. In the sample app, the `Models` project:

  :::code language="xml" source="~/fundamentals/openapi/samples/10.x/aspnet-openapi-xml/api/Api.csproj" highlight="7,16":::

The implementation discovers XML files statically at compile-time. The `AdditionalFiles` item group specifies additional sources for XML files:

  :::code language="xml" source="~/fundamentals/openapi/samples/10.x/aspnet-openapi-xml/api/AdditionalFiles.xml" highlight="7":::

To include XML documentation files from referenced assemblies, add them as `AdditionalFiles` in the project:

```xml
<ItemGroup>
  <AdditionalFiles Include="Path/To/AssemblyDoc.xml" />
</ItemGroup>
```

XML doc comment processing can be configured to access XML comments in other assemblies. This is useful for generating documentation for types that are defined outside the current assembly, such as the `ProblemDetails` type in the `Microsoft.AspNetCore.Http` namespace. This configuration is done with directives in the project build file. The following example shows how to configure the XML comment generator to access XML comments for types in the `Microsoft.AspNetCore.Http` assembly, which includes the `ProblemDetails` class:

```xml
<Target Name="AddOpenApiDependencies" AfterTargets="ResolveReferences">
  <ItemGroup>
    <AdditionalFiles
          Include="@(ReferencePath->'
            %(RootDir)%(Directory)%(Filename).xml')"
          Condition="'%(ReferencePath.Filename)' ==
           'Microsoft.AspNetCore.Http.Abstractions'"
          KeepMetadata="Identity;HintPath" />
  </ItemGroup>
</Target>
```

#### Disabling XML documentation support

To turn off XML documentation integration, remove the source generator from the `Analyzers` item group. Removing the source generator prevents it from being used during compilation.

:::code language="xml" source="~/fundamentals/openapi/samples/10.x/aspnet-openapi-xml/api/Api-remove.csproj.xml" highlight="7,19-23":::

<!-- review setting  <GenerateDocumentationFile>false</GenerateDocumentationFile> prevents the XML file from being generated.  Explain the difference between GenerateDocumentationFile = true and <Analyzer Remove -->

## Source generator implementation

The XML documentation feature is implemented as a source generator. The source generator analyzes XML documentation comments at compile time and injects code that translates these comments into OpenAPI metadata. The [`XmlCommentGenerator`](https://source.dot.net/#Microsoft.AspNetCore.OpenApi.SourceGenerators/XmlCommentGenerator.cs,30eb0aa73ef6306a) extracts XML comments from two sources:

* XML documentation files passed as `AdditionalFiles` via a [`ParseXmlFile`](https://source.dot.net/#Microsoft.AspNetCore.OpenApi.SourceGenerators/XmlCommentGenerator.Parser.cs,f7dff3af661aebc2) implementation.
* XML comments from the target assembly's own code via a [`ParseCompilation`](https://source.dot.net/#Microsoft.AspNetCore.OpenApi.SourceGenerators/XmlCommentGenerator.Parser.cs,45358a4d0fff76ac) implementation.

The distinction between these two sources is important. XML documentation files passed as `AdditionalFiles` are static. XML comments from the target assembly come from Roslyn's <!-- review `XmlDocumentationCommentProvider`--> [XML documentation comments provider](https://github.com/dotnet/roslyn/blob/main/src/Compilers/Core/Portable/MetadataReference/PortableExecutableReference.cs#L48-L62). The XML documentation comments provider enhances functionality for connecting an XML comment to the compilation symbol's that it's associated with. This has implications for the way `<inheritdoc />` resolution happens in the implementation, discussed in the next section.

XML comments are parsed into structured `XmlComment` objects with:

* Summary, description, remarks, returns, value sections.
* Parameter documentation with name, description, examples.
* Response documentation with status codes and descriptions.
* Support for examples and deprecated markers.

### Handling of complex types

XML comment processing produces accurate and complete OpenApi descriptions for a wide range of types and supports complex scenarios. But if an error is encountered when processing a complex types, the process bypasses the type gracefully.

In this way, scenarios that might have resulted in build errors now simply result in missing metadata, helping to avoid build failures.

XML documentation comments from referenced assemblies are correctly merged even when their documentation IDs include return type suffixes. As a result, all valid XML comments are reliably included in generated OpenAPI documentation, improving documentation accuracy and completeness for APIs using referenced assemblies.

### `<inheritdoc/>`

The generator supports [`<inheritdoc>`](/dotnet/csharp/language-reference/xmldoc/recommended-tags#inheritdoc) tags, which inherit documentation *as long as they exist in the compilation assembly*. `<inheritdoc />` tags indicate that comments must be resolved from:

* Base classes
* Implemented interfaces
* Base methods for overrides

When `<inheritdoc />` is placed on a symbol, The source generator:

* Uses its knowledge of the symbol in the compilation to discover base classes and interfaces associated with the symbol.
* Supports resolving them automatically
* Substitutes generic type parameters in inherited documentation comments, preserving type references across inheritance boundaries.

The automatic resolution behavior is currently available for XML documentation comments that exist in the assembly under compilation, and ***not*** XML documentation tags that are in referenced projects or packages. In the later scenario, XML documentation comments:

* Are only presented as text.
* Don't provide a trivial strategy for:
  * Associating the text content to compilation symbols.
  * Developing an understanding of the inheritance hierarchy associated with the types.

XML documentation comments from `ProjectReferences` are automatically resolved and don't require additional configuration.

<a name="download10"></a>

## Download and run the API sample

<!-- TODO, fix sample link -->
Download the [sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/openapi/samples) for this article.

To run the sample, navigate to the `api` directory and enter `dotnet run`.

```dotnetcli
cd api
dotnet run
```

Output similar to the following is displayed:

```dotnetcli
Building...
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5052
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: ~/git/aspnet-openapi-xml/api
```

Navigate to [http://localhost:5052/](http://localhost:5052/) to view the Scalar UI for interacting with the app. The Scalar UI includes summaries and descriptions on various elements sourced from XML documentation comments.

## Additional resources

* [Source generator implementation notes](https://github.com/captainsafia/aspnet-openapi-xml#implementation-notes)
* The source generator implementation can be found in the [ASP.NET Core repository](https://github.com/dotnet/aspnetcore/tree/main/src/OpenApi/gen).
* <xref:fundamentals/openapi/aspnetcore-openapi>
* <xref:fundamentals/openapi/using-openapi-documents>
* <xref:fundamentals/openapi/openapi-tools>
