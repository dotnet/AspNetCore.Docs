### Improvements to the XML comment generator

XML comment generation handles complex types in .NET 10 better than earlier versions of .NET.

* It produces accurate and complete XML comments for a wider range of types.
* It handles more complex scenarios.
* It gracefully bypasses processing for complex types that cause build errors in earlier versions.

These improvements change the failure mode for certain scenarios from build errors to missing metadata.

In addition, XML doc comment processing can now be configured to access XML comments in other assemblies. This is useful for generating documentation for types that are defined outside the current assembly, such as the `ProblemDetails` type in the `Microsoft.AspNetCore.Http` namespace.

This configuration is done with directives in the project build file. The following example shows how to configure the XML comment generator to access XML comments for types in the `Microsoft.AspNetCore.Http` assembly, which includes the `ProblemDetails` class.

```xml
<Target Name="AddOpenApiDependencies" AfterTargets="ResolveReferences">
  <ItemGroup>
  <!-- Include XML documentation from Microsoft.AspNetCore.Http.Abstractions
    to get metadata for ProblemDetails -->
    <AdditionalFiles
          Include="@(ReferencePath->'
            %(RootDir)%(Directory)%(Filename).xml')"
          Condition="'%(ReferencePath.Filename)' ==
           'Microsoft.AspNetCore.Http.Abstractions'"
          KeepMetadata="Identity;HintPath" />
  </ItemGroup>
</Target>
```

We expect to include XML comments from a selected set of assemblies in the shared framework in future previews to avoid the need for this configuration in most cases.

#### Unified handling of documentation IDs in OpenAPI XML comment generator

XML documentation comments from referenced assemblies are correctly merged even when their documentation IDs include return type suffixes. As a result, all valid XML comments are reliably included in generated OpenAPI documentation, improving documentation accuracy and completeness for APIs using referenced assemblies.  

