### Populate XML doc comments into OpenAPI document

ASP.NET Core OpenAPI document generation wlll now include metadata from XML doc comments on on method, class, and member definitions in the OpenAPI document. You must enable XML doc comments in your project file to use this feature. You can do this by adding the following property to your project file:

```xml
  <PropertyGroup>
    <GenerateDocumentationFile>true</GenerateDocumentationFile>
  </PropertyGroup>
```

At build-time, the OpenAPI package will leverage a source generator to discover XML comments in the current application assembly and any project references and emit source code to insert them into the document via an OpenAPI document transformer.

Note that the C# build process does not capture XML doc comments placed on lamda expresions, so to use XML doc comments to add metadata to a minimal API endpoint, you must define the endpoint handler as a method, put the XML doc comments on the method, and then reference that method from the `MapXXX` method. For example, to use XML doc comments to add metadata to a minimal API endpoint originally defined as a lambda expression:

```csharp
app.MapGet("/hello", (string name) =>$"Hello, {name}!");
```

change the `MapGet` call to reference a method

```csharp
app.MapGet("/hello", Hello);
```

Then define the `Hello` method with XML doc comments:

```csharp
static partial class Program
{
    /// <summary>
    /// Sends a greeting.
    /// </summary>
    /// <remarks>
    /// Greeting a person by their name.
    /// </remarks>
    /// <param name="name">The name of the person to greet.</param>
    /// <returns>A greeting.</returns>
    public static string Hello(string name)
    {
        return $"Hello, {name}!";
    }
}
```

Here the `Hello` method is added to the `Program` class, but you can add it to any class in your project.

The example above illustrates the `<summary>`, `<remarks>`, and `<param>` XML doc comments.
For more information about XML doc comments, including all the supported tags, see the [C# documentation](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/recommended-tags).

Since the core functionality is provided via a source generator, it can be disabled by adding the following MSBuild to your project file.

```
<ItemGroup>
  <PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="10.0.0-preview.2.*" GeneratePathProperty="true" />
</ItemGroup>

<Target Name="DisableCompileTimeOpenApiXmlGenerator" BeforeTargets="CoreCompile">
  <ItemGroup>
    <Analyzer Remove="$(PkgMicrosoft_AspNetCore_OpenApi)/analyzers/dotnet/cs/Microsoft.AspNetCore.OpenApi.SourceGenerators.dll" />
  </ItemGroup>
</Target>
```

The source generator process XML files included in the `AdditionalFiles` property. To add (or remove), sources modify the property as follows:

```
<Target Name="AddXmlSources" BeforeTargets="CoreCompile">
  <ItemGroup>
    <AdditionalFiles Include="$(PkgSome_Package/lib/net10.0/Some.Package.xml" />
  </ItemGroup>
</Target>
```