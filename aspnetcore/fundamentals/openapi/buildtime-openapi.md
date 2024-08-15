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
<!-- backup writer.sms.author: tdykstra and rick-anderson -->

# Generate OpenAPI documents at build-time

In a typical web apps, OpenAPI documents are generated at run-time and served via an HTTP request to the app server.

Generating OpenAPI documentation during the app's build step can be useful for documentation that is:

- Committed into source control
- Used for spec-based integration testing
- Served statically from the web server

To add support for generating OpenAPI documents at build time, install the [`Microsoft.Extensions.ApiDescription.Server`](https://www.nuget.org/packages/Microsoft.Extensions.ApiDescription.Server) NuGet package:

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

The `Microsoft.Extensions.ApiDescription.Server` package automatically generates the Open API document(s) associated with the app during build and populates them into the app's output directory:

```cli
$ dotnet build
$ cat bin/Debub/net9.0/{ProjectName}.json
```

## Customize build-time document generation

### Modify the output directory of the generated Open API file

By default, the generated OpenAPI document is generated in the app's output directory. To modify the location of the generated file, set the target path in the `OpenApiDocumentsDirectory` property in the project file:

<!-- Original had
   <OpenApiDocumentsDirectory>./</OpenApiDocumentsDirectory>
Which generates misleading error: Missing required option '--project'.
-->

:::code language="xml" source="~/fundamentals/openapi/samples/9.x/BuildTime/csproj/MyTestApi.csproj.txt" id="snippet_1":::

The value of `OpenApiDocumentsDirectory` is resolved relative to the project file. Using the `.` value in the preceding markup generates the OpenAPI document in the same directory as the project file. To generate the OpenAPI document in a different directory, provide the path relative to the project file. In the following example, the OpenAPI document is generated in the `MyOpenApiDocs` directory, which is a sibling directory of the project directory:

:::code language="xml" source="~/fundamentals/openapi/samples/9.x/BuildTime/csproj/MyTestApi.csproj.txt" id="snippet2":::

### Modify the output file name

By default, the generated OpenAPI document has the same name as the app's project file. To modify the name of the generated file, set the `--file-name` argument in the `OpenApiGenerateDocumentsOptions` property:

:::code language="xml" source="~/fundamentals/openapi/samples/9.x/BuildTime/csproj/MyTestApi.csproj.txt" id="snippet_file_name" :::

### Select the OpenAPI document to generate

Some apps may be configured to generate multiple OpenAPI documents, for example:

* For different versions of an API.
* To distinguish between public and internal APIs.

By default, the build-time document generator creates files for all documents that are configured in an app. To generate for a single document only, set the `--document-name` argument in the `OpenApiGenerateDocumentsOptions` property:

:::code language="xml" source="~/fundamentals/openapi/samples/9.x/BuildTime/csproj/MyTestApi.csproj.txt" id="snippet_doc_name":::

## Customize run-time behavior during build-time document generation

The OpenAPI document generation at build-time works by starting the app’s entrypoint with a temporary background server. This is a requirement to produce accurate OpenAPI documents because all information in the OpenAPI document can't be statically analyzed. Because the app's entrypoint is invoked, any logic in the apps' startup will be invoked. This includes code that injects services into the DI container or reads from configuration. In some scenarios, it's necessary to restrict the codepaths that will run when the app's entry point is being invoked from build-time document generation. These scenarios include:

- Not reading from certain configuration strings
- Not registering database-related services

In order to restrict these codepaths from being invoked by the build-time generation pipeline, they can be conditioned behind a check of the entry assembly like so:

```csharp
using System.Reflection;

var builder = WebApplication.CreateBuilder();

if (Assembly.GetEntryAssembly()?.GetName().Name != "GetDocument.Insider")
{
  builders.Services.AddDefaults();
}
```
