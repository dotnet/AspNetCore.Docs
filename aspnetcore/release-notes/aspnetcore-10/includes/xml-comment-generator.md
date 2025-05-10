## Improvements to XML comment generator

<!-- https://github.com/dotnet/aspnetcore/pull/61145 -->

<!-- it should throw fewer build errors now.
- It should also work with the Identity API XML comments but I haven't verified that.
  - Maybe update docs about failure mode. -->

The XML comment generator has been enhanced to better handle complex types. In conjunction, the generator now gracefully bypasses processing for complex types that previously caused build errors. Taken together, these changes improve the robustness of XML comment generation but change the failure mode for certain scenarios from build errors to missing metadata.

In addition, XML doc comment processing can now be configured to access XML comments in other assemblies. This is useful for generating documentation for types that are defined outside the current assembly, such as the `ProblemDetails` type in the `Microsoft.AspNetCore.Http` namespace.

This configuration is done with directives in the project build file. The following example shows how to configure the XML comment generator to access XML comments for types in the `Microsoft.AspNetCore.Http` assembly, which includes the `ProblemDetails` class.

```xml
<Target Name="AddOpenApiDependencies" AfterTargets="ResolveReferences">
  <ItemGroup>
    <!-- Include XML documentation from Microsoft.AspNetCore.Http.Abstractions to get metadata for ProblemDetails -->
    <AdditionalFiles
          Include="@(ReferencePath->'%(RootDir)%(Directory)%(Filename).xml')"
          Condition="'%(ReferencePath.Filename)' == 'Microsoft.AspNetCore.Http.Abstractions'"
          KeepMetadata="Identity;HintPath" />
  </ItemGroup>
</Target>
```

We expect to include XML comments from a selected set of assemblies in the shared framework in future previews, to avoid the need for this configuration in most cases.
<!--[!INCLUDE[](~/release-notes/aspnetcore-10/includes/xml-comment-generation.md)] -->
