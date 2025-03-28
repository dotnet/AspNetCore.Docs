---
title: OpenAPI XML documentation comment support in ASP.NET Core
author: captainsafia
description: Learn how to integrate XML documentation comments on types by OpenAPI document generation in ASP.NET Core.
ms.author: safia
monikerRange: '>= aspnetcore-10.0'
ms.custom: mvc
ms.date: 10/26/2024
uid: fundamentals/openapi/openapi-comments
---
<!-- backup author: rick-anderson -->
# OpenAPI XML documentation comment support in ASP.NET Core

OpenAPI XML documentation integration is implemented as a source generator. The source generator runs at compile time and injects code that translates XML comments into OpenAPI metadata. No configuration is required in app code to enable XML documentation comment support. The source generator automatically detects XML documentation comments in the application assembly and any referenced assemblies that have XML documentation enabled.

This article includes a [sample app](#download10) that demonstrates the [`Microsoft.AspNetCore.OpenApi`](https://www.nuget.org/packages/Microsoft.AspNetCore.OpenApi) package's ability to integrate XML documentation comments on types into OpenAPI documents. The sample app is a minimal ASP.NET Core Web API project that uses the `Microsoft.AspNetCore.OpenApi` package to generate OpenAPI documents. The XML documentation comments are used to populate summaries, descriptions, parameter information, and response details in the generated OpenAPI document.

![screenshot of app with XML comments in sclaar UI](~/fundamentals/openapi/_static/screenshot.png)

## Customizing XML documentation behavior

The following sections describe how to enable and customize XML documentation support.

### Adding XML documentation sources

The [`Microsoft.AspNetCore.OpenApi`](https://www.nuget.org/packages/Microsoft.AspNetCore.OpenApi) NuGet package automatically resolves XML documentation comments from:

* The application assembly, when the `GenerateDocumentationFile` property is set. In the [sample app](#download10), the `API` project.

  :::code language="xml" source="~/fundamentals/openapi/samples/10.x/aspnet-openapi-xml/models/Models.csproj" highlight="7":::

* Any projects referenced via `ProjectReferences` that have the `GenerateDocumentationFile` property set. In the sample app, the `Models` project:

  :::code language="xml" source="~/fundamentals/openapi/samples/10.x/aspnet-openapi-xml/api/Api.csproj" highlight="7,16":::

The implementation discovers XML files statically at compile-time. The `AdditionalFiles` item group specifies additional sources for XML files:

  :::code language="xml" source="~/fundamentals/openapi/samples/10.x/aspnet-openapi-xml/api/AdditionalFiles.xml" highlight="7":::

#### Disabling XML documentation support

To turn off XML documentation integration, remove the source generator from the `Analyzers` item group. Removing the source generator prevents it from being used during compilation.

<!-- review: \aspnet-openapi-xml\api\obj\Debug\net10.0\Api.xml is generated using the following project file , that is, <Analyzer Remove="$(PkgMicro ... -->

:::code language="xml" source="~/fundamentals/openapi/samples/10.x/aspnet-openapi-xml/api/Api-remove.csproj.xml" highlight="7,19-23":::

<!-- review setting  <GenerateDocumentationFile>false</GenerateDocumentationFile> prevents the XML file from being generated.  Explain the difference between GenerateDocumentationFile = true and <Analyzer Remove -->

## Source generator implementation notes

The source generator implementation is open-source and can be found in the [ASP.NET Core repository](https://github.com/dotnet/aspnetcore/tree/main/src/OpenApi/gen).

The XML documentation feature is implemented as a source generator. The source generator analyzes XML documentation comments at compile time and injects code that translates these comments into OpenAPI metadata. The [`XmlCommentGenerator`](https://source.dot.net/#Microsoft.AspNetCore.OpenApi.SourceGenerators/XmlCommentGenerator.cs,30eb0aa73ef6306a) extracts XML comments from two sources:

* XML documentation files passed as `AdditionalFiles` via a [`ParseXmlFile`](https://source.dot.net/#Microsoft.AspNetCore.OpenApi.SourceGenerators/XmlCommentGenerator.Parser.cs,f7dff3af661aebc2) implementation.
* XML comments from the target assembly's own code via a [`ParseCompilation`](https://source.dot.net/#Microsoft.AspNetCore.OpenApi.SourceGenerators/XmlCommentGenerator.Parser.cs,45358a4d0fff76ac) implementation.

The distinction between these two sources is important. XML documentation files passed as `AdditionalFiles` are static. XML comments from the target assembly come from Roslyn's <!-- review `XmlDocumentationCommentProvider`--> [XML documentation comments provider](https://github.com/dotnet/roslyn/blob/main/src/Compilers/Core/Portable/MetadataReference/PortableExecutableReference.cs#L48-L62). The XML documentation comments provider enhances functionality for connecting an XML comment to the compilation symbol's that it's associated with. This has implications for the way `<inheritdoc />` resolution happens in the implementation, discussed in the next section.

XML comments are parsed into structured `XmlComment` objects with:

* Summary, description, remarks, returns, value sections.
* Parameter documentation with name, description, examples.
* Response documentation with status codes and descriptions.
* Support for examples and deprecated markers.

The `XmlComment` class processes [XML documentation tags](/dotnet/csharp/language-reference/xmldoc/recommended-tags) like: `<c>`, `<code>`, `<list>`, `<para>`, `<paramref>`, `<typeparamref>`, `<see>`, and `<seealso>`. For XML documentation tags that use references to other elements, like `<see cref="SomeOtherType">`, the implementation strips out the XML tag and maps the reference to plain text for inclusion in the OpenAPI document.

### Support for `<inheritdoc/>`

<!-- original - review my change 
`<inheritdoc />` tags present an important opportunity because they indicate that comments must be resolved from a base class or implemented interface. 
The source generator uses its knowledge of the symbol's present in the compilation to discover base classes and interfaces associated with the symbol a given `<inheritdoc />` is placed on and supports resolving them automatically
-->

`<inheritdoc />` tags indicate that comments must be resolved from a base class or implemented interface. When `<inheritdoc />` is placed on a symbol, The source generator:

* Uses its knowledge of the symbol in the compilation to discover base classes and interfaces associated with the symbol.
* Supports resolving them automatically

The automatic resolution behavior is currently available for XML documentation comments that exist in the assembly under compilation, and ***not*** XML documentation tags that are in referenced projects or packages. In the later scenario, XML documentation comments:

* Are only presented as text.
* There's no trivial strategy for:
  * Associating the text content to compilation symbols.
  * Developing an understanding of the inheritance hierarchy associated with the types.

### Member Identification

The source generator discovers XML comments statically and emits code that applies them to the document dynamically at runtime. The [`MemberKey`](https://source.dot.net/#Microsoft.AspNetCore.OpenApi.SourceGenerators/XmlComments/MemberKey.cs,d182ed147edb11d2) class acts as a bridge between compile-time and runtime representations of the same concept. It's a unique identifier for types, methods, and properties that works across:

* Different compilation environments.
* Generic types with proper handling of open generics.
* Method overloads with parameter signature matching.

The `MemberKey` definition attempts to encode as much information as possible to map a compile-time symbol to its runtime counterpart.

```csharp
internal sealed record MemberKey(
    string? DeclaringType,
    MemberType MemberKind,
    string? Name,
    string? ReturnType,
    string[]? Parameters) : IEquatable<MemberKey>
```

### Code Generation

The generator emits code that contains:

* A cache of XML comments mapped to member identifiers:
   <!-- REVIEW: In additon to the following, provide a concret example -->
   ```csharp
   _cache.Add(new MemberKey(/*...*/), new XmlComment(/*...*/));
   ```
* OpenAPI transformer implementations:
   * [`XmlCommentOperationTransformer`](https://github.com/dotnet/aspnetcore/blob/main/src/OpenApi/gen/XmlCommentGenerator.Emitter.cs#L229):  Applies comments to API operations (methods).
   * [`XmlCommentSchemaTransformer`](https://github.com/dotnet/aspnetcore/blob/main/src/OpenApi/gen/XmlCommentGenerator.Emitter.cs#L308): Applies comments to data models (types).
* Extension methods that intercept <xref:Microsoft.Extensions.DependencyInjection.OpenApiServiceCollectionExtensions.AddOpenApi*> calls to inject the transformers:

   ```csharp
   public static IServiceCollection AddOpenApi(this IServiceCollection services)
   {
       return services.AddOpenApi("v1", options =>
       {
           options.AddSchemaTransformer(new XmlCommentSchemaTransformer());
           options.AddOperationTransformer(new XmlCommentOperationTransformer());
       });
   }
   ```

### Interception mechanism

The generator uses the C# compiler's interceptor feature to intercept calls to the `<xref:Microsoft.Extensions.DependencyInjection.OpenApiServiceCollectionExtensions.AddOpenApi*> method. The generator:

1. Detects different `AddOpenApi` overloads.
2. Generates appropriate interceptor methods for each overload.
3. Adds the XML comment transformers to the OpenAPI options.

When the interceptor runs, it:

1. Adds the XML-specific transformers.
1. Applies any transformers the user has registered in their application code. This allows user transformers to inspect metadata that has been automatically set by the source generated transformer implementations.

### Runtime behavior

When the generated code runs:

1. The XML comment cache is populated on first use with structured comment data.
2. The intercepted `AddOpenApi` methods add the transformers to the OpenAPI options.
3. During API documentation generation, the transformers:
   * Look up documentation for API methods and apply summaries, descriptions, etc.
   * Apply parameter documentation to OpenAPI parameters.
   * Set response descriptions based on XML documentation.
   * Include [examples](#add-examples) when provided in the XML.

The generator processes standard XML code comments and adds them to the generated OpenAPI documentation.

## Frequently Asked Questions

### What is the OpenAPI XML documentation support feature?

The feature automatically extracts XML documentation comments from code and uses them to populate OpenAPI documentation. API documentation is generated directly from code comments, keeping them in sync.

### How does the XML documentation support work?

It uses a C# source generator, [`XmlCommentGenerator`](https://source.dot.net/#Microsoft.AspNetCore.OpenApi.SourceGenerators/XmlCommentGenerator.cs,30eb0aa73ef6306a), that analyzes XML documentation at compile time and injects code that translates those comments into OpenAPI specification metadata.

### Why is this implemented as a source generator?

Source generators allow us to implement [AOT](/aspnet/core/fundamentals/native-aot) compatible resolution of [`inheritdoc`](/dotnet/csharp/language-reference/xmldoc/recommended-tags) references in XML comments.

### How do I enable XML documentation in my ASP.NET Core API project?

1. Enable XML documentation in your project file:

  :::code language="xml" source="~/fundamentals/openapi/samples/10.x/aspnet-openapi-xml/models/Models.csproj" highlight="7":::

2. Use the `AddOpenApi` method in your service configuration. No configuration is needed, the source generator handles the rest.

  :::code language="csharp" source="~/fundamentals/openapi/samples/10.x/aspnet-openapi-xml/api/Program.cs" highlight="6":::

### Do I need to include XML documentation files from referenced assemblies?

Yes, for referenced assemblies with API types. Add them as `AdditionalFiles` in the project:

```xml
<ItemGroup>
  <AdditionalFiles Include="Path/To/AssemblyDoc.xml" />
</ItemGroup>
```

XML documentation comments from `ProjectReferences` are automatically resolved and don't require additional configuration.

### Supported XML documentation tags
<!-- review: removing defns for links, can revert -->
* [`<summary>`](/dotnet/csharp/language-reference/xmldoc/recommended-tags#summary) <!-- - Used for operation and type descriptions -->
* [`<remarks>`](/dotnet/csharp/language-reference/xmldoc/recommended-tags#remarks) <!-- - Used for additional operation details -->
* [`<param>`](/dotnet/csharp/language-reference/xmldoc/recommended-tags#param) <!-- - Used for parameter descriptions           -->
* [`<returns>`](/dotnet/csharp/language-reference/xmldoc/recommended-tags#returns) <!-- - Used for return value descriptions     -->
* [`<response>`](/dotnet/csharp/language-reference/xmldoc/recommended-tags#response) <!-- - Used for HTTP response documentation -->
* [`<example>`](/dotnet/csharp/language-reference/xmldoc/recommended-tags#example) <!-- - Used for examples in documentation      -->
* [`<deprecated>`](/dotnet/csharp/language-reference/xmldoc/recommended-tags#deprecated) <!-- - Marks operations as deprecated -->
* [`<inheritdoc>`](/dotnet/csharp/language-reference/xmldoc/recommended-tags#inheritdoc) <!-- - Inherits documentation from base classes/interfaces -->

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

### Document inheritance via `<inheritdoc/>` tags

The generator supports [`<inheritdoc>`](/dotnet/csharp/language-reference/xmldoc/recommended-tags#inheritdoc) tags, which inherit documentation from *as long as they exist in the compilation assembly*:

* Base classes
* Implemented interfaces
* Base methods for overrides

### How are generic type parameters handled when inheriting documentation?

The source generator substitutes generic type parameters in inherited documentation comments, preserving type references across inheritance boundaries.

### How does the source generator identify and track API members?

It uses the [`MemberKey`](https://github.com/dotnet/aspnetcore/blob/main/src/OpenApi/gen/XmlComments/MemberKey.cs) class to create a unique identifier for each API member that encodes:

* Declaring and property types.
* Method names.
* Generic types with proper handling of open generics.
* Method overloads with parameter signature matching.

### XML documentation processing and runtime performance

XML documentation processing doesn't impact runtime performance. The source generator processes XML documentation at compile time and caches the results, with minimal runtime overhead when rendering the OpenAPI documentation. Furthermore, the OpenAPI document can be cached at runtime using [output-caching](/aspnet/core/performance/caching/overview#output-caching) to further optimize performance.

### Source generator and interception of `AddOpenApi` calls

The source generator uses the [C# compiler's interceptor ](/dotnet/csharp/whats-new/csharp-12#interceptors)feature to detect calls to `AddOpenApi` and automatically injects the XML documentation transformers.

### What happens when I use different overloads of `AddOpenApi`?

The source generator detects all standard overloads:

* `AddOpenApi()`
* `AddOpenApi("v1")`
* `AddOpenApi(options => {})`
* `AddOpenApi("v1", options => {})`

Each overload is intercepted to automatically include the XML documentation transformers. The source generator doesn't handle overloads where the `documentName` parameter isn't a literal string expression. For example, the transformer isn't registered in the following scenarios:

```csharp
var documentName = "v1";
builder.Services.AddOpenApi(documentName); // No XML support
```

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
