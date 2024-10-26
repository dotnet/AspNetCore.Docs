---
title: Generate OpenAPI documents at build time
author: captainsafia
description: Learn how to generate OpenAPI documents in your application's build step
ms.author: safia
monikerRange: '>= aspnetcore-6.0'
ms.custom: mvc
ms.date: 8/13/2024
uid: fundamentals/openapi/buildtime-openapi
---

# Generate OpenAPI documents at build-time

In typical web applications, OpenAPI documents are generated at run-time and served via an HTTP request to the application server.

In some scenarios, it's helpful to generate the OpenAPI document during the application's build step. These scenarios include:

- Generating OpenAPI documentation that is committed into source control.
- Generating OpenAPI documentation that is used for spec-based integration testing.
- Generating OpenAPI documentation that is served statically from the web server.

To add support for generating OpenAPI documents at build time, install the `Microsoft.Extensions.ApiDescription.Server` package:

### [Visual Studio](#tab/visual-studio)

Run the following command from the **Package Manager Console**:

 ```powershell
 Install-Package Microsoft.Extensions.ApiDescription.Server -IncludePrerelease
```

### [.NET CLI](#tab/net-cli)

Run the following command in the directory that contains the project file:

```dotnetcli
dotnet add package Microsoft.Extensions.ApiDescription.Server --prerelease
```
---

Upon installation, this package will automatically generate the Open API document(s) associated with the application during build and populate them into the application's output directory.

```cli
$ dotnet build
$ cat bin/Debug/net9.0/{ProjectName}.json
```

## Customizing build-time document generation

### Modifying the output directory of the generated Open API file

By default, the generated OpenAPI document will be emitted to the application's output directory. To modify the location of the emitted file, set the target path in the `OpenApiDocumentsDirectory` property.

```xml
<PropertyGroup>
  <OpenApiDocumentsDirectory>./</OpenApiDocumentsDirectory>
</PropertyGroup>
```

The value of `OpenApiDocumentsDirectory` is resolved relative to the project file. Using the `./` value above will emit the OpenAPI document in the same directory as the project file.

### Modifying the output file name

By default, the generated OpenAPI document will have the same name as the application's project file. To modify the name of the emitted file, set the `--file-name` argument in the `OpenApiGenerateDocumentsOptions` property.

```xml
<PropertyGroup>
  <OpenApiGenerateDocumentsOptions>--file-name my-open-api</OpenApiGenerateDocumentsOptions>
</PropertyGroup>
```

### Selecting the OpenAPI document to generate

Some applications may be configured to emit multiple OpenAPI documents, for various versions of an API or to distinguish between public and internal APIs. By default, the build-time document generator will emit files for all documents that are configured in an application. To only emit for a single document name, set the `--document-name` argument in the `OpenApiGenerateDocumentsOptions` property.

```xml
<PropertyGroup>
  <OpenApiGenerateDocumentsOptions>--document-name v2</OpenApiGenerateDocumentsOptions>
</PropertyGroup>
```

## Customizing run-time behavior during build-time document generation

Under the hood, build-time OpenAPI document generation functions by launching the application's entrypoint with an inert server implementation. This is a requirement to produce accurate OpenAPI documents since all information in the OpenAPI document cannot be statically analyzed. Because the application's entrypoint is invoked, any logic in the applications' startup will be invoked. This includes code that injects services into the DI container or reads from configuration. In some scenarios, it's necessary to restrict the codepaths that will run when the application's entry point is being invoked from build-time document generation. These scenarios include:

- Not reading from certain configuration strings.
- Not registering database-related services.

In order to restrict these codepaths from being invoked by the build-time generation pipeline, they can be conditioned behind a check of the entry assembly like so:

```csharp
using System.Reflection;

var builder = WebApplication.CreateBuilder();

if (Assembly.GetEntryAssembly()?.GetName().Name != "GetDocument.Insider")
{
  builder.Services.AddDefaults();
}
```
