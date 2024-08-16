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

In typical web apps, OpenAPI documents are generated at run-time and served via an HTTP request to the app server.

Generating OpenAPI documentation during the app's build step can be useful for documentation that is:

- Committed into source control.
- Used for spec-based integration testing.
- Served statically from the web server.

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

The `Microsoft.Extensions.ApiDescription.Server` package automatically generates the Open API document(s) associated with the app during build and places them in the app's `obj` directory:

Consider a template created API app named `MyTestApi`:

### [Visual Studio](#tab/visual-studio)

The Output tab in Visual Studio when building the app includes information similar to the following:

```text
1>Generating document named 'v1'.
1>Writing document named 'v1' to 'MyProjectPath/obj/MyTestApi.json'.
```

### [.NET CLI](#tab/net-cli)

The following commands build the app and display the generated OpenAPI document:

```cli
$ dotnet build
$ cat obj/MyTestApi.json
```

---

The generated `obj/{MyProjectName}.json` file contains the [OpenAPI version, title,  endpoints, and more](https://learn.openapis.org/specification/structure.html). The first few lines of `obj/MyTestApi.json` file:

:::code language="json" source="~/fundamentals/openapi/samples/9.x/BuildTime/csproj/MyTestApi.json" range="1-15" highlight="4-5":::

## Customize build-time document generation

Build-time document generation can be customized with properties added to the project file. [dotnet](/dotnet/core/tools/) parses the `ApiDescription.Server` properties in the project file and provides the property and values as arguments to the build-time document generator. The following properties are available and explained in the following sections:

:::code language="xml" source="~/fundamentals/openapi/samples/9.x/BuildTime/csproj/MyTestApi.csproj.php" id="snippet_all" highlight="2-4":::

### Modify the output directory of the generated Open API file

By default, the generated OpenAPI document is generated in the `obj` directory. The value of the `OpenApiDocumentsDirectory` property:

* Sets the location of the generated file.
* Is resolved relative to the project file.

The following example generates the OpenAPI document in the same directory as the project file:

:::code language="xml" source="~/fundamentals/openapi/samples/9.x/BuildTime/csproj/MyTestApi.csproj.php" id="snippet_1" highlight="2":::

In the following example, the OpenAPI document is generated in the `MyOpenApiDocs` directory, which is a sibling directory to the project directory:

:::code language="xml" source="~/fundamentals/openapi/samples/9.x/BuildTime/csproj/MyTestApi.csproj.php" id="snippet2" highlight="2":::

### Modify the output file name

By default, the generated OpenAPI document has the same name as the app's project file. To modify the name of the generated file, set the `--file-name` argument in the `OpenApiGenerateDocumentsOptions` property:

:::code language="xml" source="~/fundamentals/openapi/samples/9.x/BuildTime/csproj/MyTestApi.csproj.php" id="snippet_file_name" highlight="2":::

The preceding markup configures creation of the `obj/my-open-api.json` file.

### Select the OpenAPI document to generate

Some apps may be configured to generate multiple OpenAPI documents, for example:

* For different versions of an API.
* To distinguish between public and internal APIs.

By default, the build-time document generator creates files for all documents that are configured in an app. To generate for a single document only, set the `--document-name` argument in the `OpenApiGenerateDocumentsOptions` property:

:::code language="xml" source="~/fundamentals/openapi/samples/9.x/BuildTime/csproj/MyTestApi.csproj.php" id="snippet_doc_name":::

<!--
What's the equivalent of 
 app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Public API v1");
        c.SwaggerEndpoint("/swagger/v2/swagger.json", "Internal API v2");
    });
-->

## Customize run-time behavior during build-time document generation

OpenAPI document generation at build-time works by starting the app’s entry point with a temporary background server. This approach is necessary to produce accurate OpenAPI documents, as not all information can be statically analyzed. When the app’s entry point is invoked, any logic in the app’s startup is executed, including code that injects services into the DI container or reads from configuration.

In some scenarios, it's important to restrict certain code paths when the app's entry point is invoked during build-time document generation. These scenarios include:

- Not reading from specific configuration strings.
- Not registering database-related services.

To prevent these code paths from being invoked by the build-time generation pipeline, they can be conditioned behind a check of the entry assembly:

:::code language="csharp" source="~/fundamentals/openapi/samples/9.x/BuildTime/Skip.cs" id="snippet_1" highlight="7-12":::

## OpenAPI document cleanup

Then generated OpenAPI documents are not cleaned up by `dotnet clean` or **Build > Clean Solution** in Visual Studio. To remove the generated OpenAPI documents, delete the `obj` directory or the directory specified by the `OpenApiDocumentsDirectory` property.
