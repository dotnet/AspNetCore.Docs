---
title: .NET OpenAPI tool command reference and installation
author: ryanbrandenburg
description: Demonstrates how to use the 'Microsoft.dotnet-openapi' tool to add references to OpenAPI files.
monikerRange: '>= aspnetcore-3.1'
ms.author: rybrande
ms.date: 3/9/2022
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: web-api/Microsoft.dotnet-openapi
---
# .NET OpenAPI tool command reference and installation

[Microsoft.dotnet-openapi](https://www.nuget.org/packages/Microsoft.dotnet-openapi) is a [.NET Core Global Tool](/dotnet/core/tools/global-tools) for managing [OpenAPI](https://github.com/OAI/OpenAPI-Specification) references within a project.

## Installation

To install `Microsoft.dotnet-openapi`, run the following command:

```dotnetcli
dotnet tool install -g Microsoft.dotnet-openapi
```

## Add

Adding an OpenAPI reference using any of the commands on this page adds an `<OpenApiReference />` element similar to the following to the `.csproj` file:

```xml
<OpenApiReference Include="openapi.json" />
```

The preceding reference is required for the app to call the generated client code.

<!-- TODO: Restore after https://github.com/dotnet/AspNetCore/issues/12738
### Add Project

#### Options

| Short option | Long option | Description | Example |
|-------|------|-------|---------|
| -p|--project | The project to operate on. |dotnet openapi add project *--project .\Ref.csproj* ../Ref/ProjRef.csproj |

#### Arguments

|  Argument  | Description | Example |
|-------------|-------------|---------|
| source-file | The source to create a reference from. Must be a project file. |dotnet openapi add project *../Ref/ProjRef.csproj* | -->

### Add File

#### Options

| Short option| Long option| Description | Example |
|-------|------|-------|---------|
| -p|--updateProject | The project to operate on. |dotnet openapi add file *--updateProject .\Ref.csproj* .\OpenAPI.json |
| -c|--code-generator| The code generator to apply to the reference. Options are `NSwagCSharp` and `NSwagTypeScript`. If `--code-generator` is not specified the tooling defaults to `NSwagCSharp`.|dotnet openapi add file .\OpenApi.json --code-generator
| -h|--help|Show help information|dotnet openapi add file --help|

#### Arguments

|  Argument  | Description | Example |
|-------------|-------------|---------|
| source-file | The source to create a reference from. Must be an OpenAPI file. |dotnet openapi add file *.\OpenAPI.json* |

### Add URL

#### Options

| Short option| Long option| Description | Example |
|-------|------|-------------|---------|
| -p|--updateProject | The project to operate on. |dotnet openapi add url *--updateProject .\Ref.csproj* `https://contoso.com/openapi.json` |
| -o|--output-file | Where to place the local copy of the OpenAPI file. |dotnet openapi add url `https://contoso.com/openapi.json` *--output-file myclient.json* |
| -c|--code-generator| The code generator to apply to the reference. Options are `NSwagCSharp` and `NSwagTypeScript`. |dotnet openapi add url `https://contoso.com/openapi.json` --code-generator
| -h|--help|Show help information|dotnet openapi add url --help|

#### Arguments

|  Argument  | Description | Example |
|-------------|-------------|---------|
| source-URL | The source to create a reference from. Must be a URL. |dotnet openapi add url `https://contoso.com/openapi.json` |

## Remove

Removes the OpenAPI reference matching the given filename from the `.csproj` file. When the OpenAPI reference is removed, clients won't be generated. Local `.json` and `.yaml` files are deleted.

### Options

| Short option| Long option| Description| Example |
|-------|------|------------|---------|
| -p|--updateProject | The project to operate on. |dotnet openapi remove *--updateProject .\Ref.csproj* .\OpenAPI.json |
| -h|--help|Show help information|dotnet openapi remove --help|

### Arguments

|  Argument  | Description| Example |
| ------------|------------|---------|
| source-file | The source to remove the reference to. |dotnet openapi remove *.\OpenAPI.json* |

## Refresh

Refreshes the local version of a file that was downloaded using the latest content from the download URL.

### Options

| Short option| Long option| Description | Example |
|-------|------|-------------|---------|
| -p|--updateProject | The project to operate on. | dotnet openapi refresh *--updateProject .\Ref.csproj* `https://contoso.com/openapi.json` |
| -h|--help|Show help information|dotnet openapi refresh --help|

### Arguments

|  Argument  | Description | Example |
| ------------|-------------|---------|
| source-URL | The URL to refresh the reference from. | dotnet openapi refresh `https://contoso.com/openapi.json` |
