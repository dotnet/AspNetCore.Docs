### Select an environment for build-time OpenAPI document generation

Build-time OpenAPI document generation supports selecting the app environment with the `OpenApiGenerationEnvironment` MSBuild property. The property sets the host's environment for the generation process, equivalent to setting the `ASPNETCORE_ENVIRONMENT` or `DOTNET_ENVIRONMENT` environment variable. Environment-specific configuration and document transformations can therefore affect the generated OpenAPI document without requiring the environment variable to be set before running `dotnet build`.

Set the property in the project file:

```xml
<PropertyGroup>
  <OpenApiGenerationEnvironment>Development</OpenApiGenerationEnvironment>
</PropertyGroup>
```

For more information, see <xref:fundamentals/openapi/aspnetcore-openapi#customize-build-time-document-generation>.

Thank you [@ldsenow](https://github.com/ldsenow) for this contribution!
