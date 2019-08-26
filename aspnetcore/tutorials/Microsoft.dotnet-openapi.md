---
title: Develop ASP.NET Core apps using OpenAPI
author: ryanbrandenburg
description: This tutorial demonstrates how to use the 'Microsoft.dotnet-openapi' tool to add references to OpenAPI files 
ms.author: rybrande
ms.date: 08/26/2019
uid: tutorials/Microsoft.dotnet-openapi
---
# Develop ASP.NET Core apps using OpenAPI tools

By Ryan Brandenburg

`Microsoft.dotnet-openapi` is a tool for managing [OpenAPI](https://github.com/OAI/OpenAPI-Specification) references within a project.

## Installation

To install `Microsoft.dotnet-openapi`, run the following command

``` console
dotnet tool install -g Microsoft.dotnet-openapi
``

## Commands

### Add Commands

Adding an OpenAPI reference using any of the commands on this page adds an `<OpenApiReference /> element similar to the following to the *.csproj* file:

```xml
<OpenApiReference Include="openapi.json" />
```

The preceding reference and the code generator specific packages which are added, enables the generated client code being available for use by the app.

<!-- TODO: Restore after https://github.com/aspnet/AspNetCore/issues/12738
 #### Add Project
##### Options
| Short option | Long option | Description | Example |
|-------|------|-------|---------|
| -v|--verbose | Show verbose output. |dotnet openapi add project *-v* ../Ref/ProjRef.csproj |
| -p|--project | The project to operate on. |dotnet openapi add project *--project .\Ref.csproj* ../Ref/ProjRef.csproj |
##### Arguments
|  Argument  | Description | Example |
|-------------|-------------|---------|
| source-file | The source to create a reference from. Must be a project file. |dotnet openapi add project *../Ref/ProjRef.csproj* | -->

#### Add File

##### Options

| Short option| Long option| Description | Example |
|-------|------|-------|---------|
| -v|--verbose | Show verbose output. |dotnet openapi add file *-v* .\OpenAPI.json |
| -p|--updateProject | The project to operate on. |dotnet openapi add file *--updateProject .\Ref.csproj* .\OpenAPI.json |
| -c|--code-generator| The code generator to apply to the reference. Options are "NSwagCSharp" and "NSwagTypeScript". If this is not explicitly provided the tooling will default to NSwagCSharp.|dotnet openapi add file .\OpenApi.json --code-generator

##### Arguments

|  Argument  | Description | Example |
|-------------|-------------|---------|
| source-file | The source to create a reference from. Must be an OpenAPI file. |dotnet openapi add file *.\OpenAPI.json* |

#### Add URL

##### Options

| Short option| Long option| Description | Example |
|-------|------|-------------|---------|
| -v|--verbose | Show verbose output. |dotnet openapi add url *-v* `http://contoso.com/openapi.json` |
| -p|--updateProject | The project to operate on. |dotnet openapi add url *--updateProject .\Ref.csproj* `http://contoso.com/openapi.json` |
| -o|--output-file | Where to place the local copy of the OpenAPI file. |dotnet openapi add url `https://contoso.com/openapi.json` *--output-file myclient.json* |
| -c|--code-generator| The code generator to apply to the reference. Options are "NSwagCSharp" and "NSwagTypeScript". |dotnet openapi add file .\OpenApi.json --code-generator

##### Arguments

|  Argument  | Description | Example |
|-------------|-------------|---------|
| source-URL | The source to create a reference from. Must be a URL. |dotnet openapi add url `https://contoso.com/openapi.json` |

### Remove

This command removes the OpenAPI reference matching the given filename from the *.csproj* file. When the OpenAPI reference is removed, clients won't be generated. Local *.json* and *yaml* files are deleted.

##### Options

| Short option| Long option| Description| Example |
|-------|------|------------|---------|
| -v|--verbose | Show verbose output. |dotnet openapi remove *-v*|
| -p|--updateProject | The project to operate on. |dotnet openapi remove *--updateProject .\Ref.csproj* .\OpenAPI.json |

#### Arguments

|  Argument  | Description| Example |
| ------------|------------|---------|
| source-file | The source to remove the reference to. |dotnet openapi remove *.\OpenAPI.json* |

### Refresh

This command refreshes the local version of a file which was downloaded using a URL using the latest content from that URL.

#### Options

| Short option| Long option| Description | Example |
|-------|------|-------------|---------|
| -v|--verbose | Show verbose output. | dotnet openapi refresh *-v* `https://contoso.com/openapi.json` |
| -p|--updateProject | The project to operate on. | dotnet openapi refresh *--updateProject .\Ref.csproj* `https://contoso.com/openapi.json` |

#### Arguments

|  Argument  | Description | Example |
| ------------|-------------|---------|
| source-URL | The URL to refresh the reference from. | dotnet openapi refresh `https://contoso.com/openapi.json` |
