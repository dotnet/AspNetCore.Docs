# XML Documentation Comment Support for OpenAPI in ASP.NET Core

This app demonstrates the `Microsoft.AspNetCore.OpenApi` package's ability to integration XML documentation comments on types into OpenAPI documents.

![screenshot of app with XML comments in sclaar UI](./screenshot.png)

## Run Sample App

To run the API, navigate to the `api` directory and execute `dotnet run`.

```
$ cd api
$ dotnet run
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

Navigate to http://localhost:5052/ to view the Scalar UI for interacting with the application. Note that the Scalar UI includes summaries and descriptions on various elements sourced from XML documentation comments.

## Customizing XML Documentation Behavior

#### Adding XML Documentation Sources

The `Microsoft.AspNetCore.OpenApi` package will automatically resolve XML documentation comments from the application assembly (the `API` project in this case) and any projects referenced via `ProjectReferences` (like the `Models` project) if these projects have the `GenerateDocumentationFile` property set.

```
<PropertyGroup>
  <GenerateDocumentationFile>true</GenerateDocumentationFile>
</PropertyGroup>
```

Since the implementation discovers XML files statically at compile-time, you can indicate additional sources for XML files by setting the `AdditionalFiles` item group. For example, to include XML documentation from a package reference.

```xml
<ItemGroup>
    <PackageReference Include="Some.Package" Version="10.0.0" GeneratePathProperty="true" />
</ItemGroup>
<ItemGroup>
    <AdditionalFiles Include="$(PkgSome_Package)/lib/net10.0/Some.Package.xml">
</ItemGroup>
```

#### Disabling XML Documentation Support

Since the functionality is implemented as a source generator, to turn off XML documentation integration, you can remove the source generator from the `Analyzers` item group to prevent it from being used in the compilation.

```xml
<ItemGroup>
  <PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="10.0.0-preview.2.*" GeneratePathProperty="true" />
</ItemGroup>

<Target Name="DisableCompileTimeOpenApiXmlGenerator" BeforeTargets="CoreCompile">
  <ItemGroup>
    <Analyzer Remove="$(PkgMicrosoft_AspNetCore_OpenApi)/analyzers/dotnet/cs/Microsoft.AspNetCore.OpenApi.SourceGenerators.dll" />
  </ItemGroup>
</Target>
```

## Implementation Notes

> [!NOTE]
> The implementation described here is open-source and can be found in the [ASP.NET Core repo](https://github.com/dotnet/aspnetcore/tree/f3555640d3b0d049856947c4f2bd0b869adf5c5e/src/OpenApi/gen).

Several times in this document, I've mentioned that the XML documentation feature is implemented as a source generator. How does all this work?

The `XmlCommentGenerator` extracts XML comments from two sources:

* XML documentation files passed as `AdditionalFiles` via a `ParseXmlFile` implementation
* XML comments from the target assembly's own code via a `ParseCompilation` implementation

The distinction between these two sources is important. XML documentation files passed as `AdditionalFiles` are static. XML comments from the target assembly come from Roslyn's `XmlDocumentationCommentProvider` which provides enhanced functionality for connecting an XML comment to the compilation symbol's that it is associated with. This has implications for the way `<inheritdoc />` resolution happens in the implementation. We'll get more into this later.


XML comments are parsed into structured `XmlComment` objects with:
* Summary, description, remarks, returns, value sections
* Parameter documentation with name, description, examples
* Response documentation with status codes and descriptions
* Support for examples and deprecated markers

The `XmlComment` class processes XML documentation tags like: `<c>`, `<code>`, `<list>`, `<para>`, `<paramref>`, `<typeparamref>`, `<see>`, and `<seealso>`. For XML documentation tags that use references to other elements, like `<see cref="SomeOtherType">`, the implementation strips out the XML tag and maps the reference to plain text for inclusion in the OpenAPI document.

### Support for `<inheritdoc/>`

`<inheritdoc />` tags present a unique oppurtunity because they indicate that comments must be resolved from a base class or implemented interface. The source generator uses its knowledge of the symbol's present in the compilation to discover base classes and interfaces associated with the symbol a given `<inheritdoc />` is placed on and supports resolving them automatically.

This automatic resolution behavior is currently available for XML documentation comments that exist in the assembly under compilation, and _not_ XML documentation tags that are in referenced projects or packages. In the later scenario, XML documentation comments are only presented as text and there is no trivial strategy for associating the text content to compilation symbols or developing an understanding of the inheritance hierarchy associated with the types.

### Member Identification

The source generator discovers XML comments statically and emits code that will apply them to the document dynamically at runtime. The `MemberKey` class acts as a bridge between compile-time and runtime representations of the same concept. It is a unique identifier for types, methods, and properties that works across:

- Different compilation environments
- Generic types with proper handling of open generics
- Method overloads with parameter signature matching

The `MemberKey` defintion attempts to encode as much information as possible to map a compile-time symbol to its runtime counterpart.

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

1. A cache of XML comments mapped to member identifiers:
   ```csharp
   _cache.Add(new MemberKey(/*...*/), new XmlComment(/*...*/));
   ```

2. OpenAPI transformer implementations:
   - `XmlCommentOperationTransformer` - Applies comments to API operations (methods)
   - `XmlCommentSchemaTransformer` - Applies comments to data models (types)

3. Extension methods that intercept `AddOpenApi()` calls to inject the transformers:
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

### Interception Mechanism

The generator uses the C# compiler's interceptor feature to intercept calls to the `AddOpenApi` method. It:
1. Detects different `AddOpenApi` overloads
2. Generates appropriate interceptor methods for each variant
3. Adds the XML comment transformers to the OpenAPI options

When the interceptor runs, it adds the XML-specific transformers first then applies any transformers the user has registered in their application code. This allows user transformers to inspect metadata that has been automatically set by the source generated transformer implementations.

### Runtime Behavior

When the generated code runs:

1. The XML comment cache is populated on first use with structured comment data
2. The intercepted `AddOpenApi` methods add the transformers to the OpenAPI options
3. During API documentation generation, the transformers:
   - Look up documentation for API methods and apply summaries, descriptions, etc.
   - Apply parameter documentation to OpenAPI parameters
   - Set response descriptions based on XML documentation
   - Include examples when provided in the XML

This allows developers to write standard XML comments in their code and have them automatically appear in the generated OpenAPI documentation without any additional configuration code.

## Frequently Asked Questions

### What is the OpenAPI XML documentation support feature?

The feature automatically extracts XML documentation comments from your code and uses them to populate OpenAPI documentation. This means your API documentation is generated directly from your code comments, keeping them in sync.

### How does the XML documentation support work?

It uses a C# source generator (`XmlCommentGenerator`) that analyzes XML documentation at compile time and injects code that translates these comments into OpenAPI specification metadata.

### Why is this implemented as a source generator?

Source generators allow us to implement AoT-compatible resolution of inheritdoc references in XML comments.

### How do I enable XML documentation in my ASP.NET Core API project?

1. Enable XML documentation in your project file:
   ```xml
   <PropertyGroup>
     <GenerateDocumentationFile>true</GenerateDocumentationFile>
   </PropertyGroup>
   ```

2. Use the `AddOpenApi()` method in your service configuration (no special configuration needed - the source generator handles the rest)

### Do I need to include XML documentation files from referenced assemblies?

Yes, for referenced assemblies with API types. Add them as AdditionalFiles in your project:

```xml
<ItemGroup>
  <AdditionalFiles Include="Path\To\AssemblyDoc.xml" />
</ItemGroup>
```

XML documentation comments from `ProjectReferences` are automatically resolved and don't require additional configuration.

### What XML documentation tags are supported?

- `<summary>` - Used for operation and type descriptions
- `<remarks>` - Used for additional operation details
- `<param>` - Used for parameter descriptions
- `<returns>` - Used for return value descriptions
- `<response>` - Used for HTTP response documentation
- `<example>` - Used for examples in documentation
- `<deprecated>` - Marks operations as deprecated
- `<inheritdoc>` - Inherits documentation from base classes/interfaces

### How do I document HTTP responses?

Use the `<response>` tag with a `code` attribute:
```csharp
/// <response code="200">Success response with data</response>
/// <response code="404">Resource not found</response>
```

### How do I add examples to documentation?

Use the `<example>` tag for types or the `example` attribute for parameters:
```csharp
/// <example>{"name":"Sample","value":42}</example>
/// <param name="id" example="42">The unique identifier</param>
```

### Does the generator support `<inheritdoc/>` tags?

Yes, it fully supports inheriting documentation from *as long as they exist in the compilation assembly*:
- Base classes
- Implemented interfaces
- Base methods for overrides

### How are generic type parameters handled when inheriting documentation?

The source generator substitutes generic type parameters in inherited documentation comments, preserving type references across inheritance boundaries.

### How does the source generator identify and track API members?

It uses the `MemberKey` class to create a unique identifier for each API member that encodes:
- Declaring and property types
- Method names
- Generic types with proper handling of open generics
- Method overloads with parameter signature matching

### Will the XML documentation processing impact my application's runtime performance?

No. The source generator processes XML documentation at compile time and caches the results, with minimal runtime overhead when rendering the OpenAPI documentation. Furthermore, the OpenAPI document can be cache at runtime using output-caching to further optimize performance.

### How does the source generator intercept `AddOpenApi()` calls?

It uses the C# compiler's interceptor feature to detect calls to `AddOpenApi()` and automatically injects the XML documentation transformers.

### What happens when I use different overloads of `AddOpenApi()`?

The source generator detects all standard overloads:
- `AddOpenApi()`
- `AddOpenApi("v1")`
- `AddOpenApi(options => {})`
- `AddOpenApi("v1", options => {})`

Each is intercepted to automatically include the XML documentation transformers. The source generator does not handle overloads where the `documentName` parameter is not a literal string expression. For example, the transformer is not registered in the following scenarios:

```csharp
var documentName = "v1";
builder.Services.AddOpenApi(documentName); // No XML support here
```

## License
[MIT](https://choosealicense.com/licenses/mit/)