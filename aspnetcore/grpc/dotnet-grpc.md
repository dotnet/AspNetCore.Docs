---
title: Manage Protobuf references with dotnet-grpc
author: juntaoluo
description: Learn about adding, updating, removing and listing Protobuf references with the dotnet-grpc global tool.
monikerRange: '>= aspnetcore-3.0'
ms.author: johluo
ms.date: 09/24/2019
uid: grpc/dotnet-grpc
---
# Manage Protobuf references with dotnet-grpc

By [John Luo](https://github.com/juntaoluo)

`dotnet-grpc` is a .NET Core global tool for managing Protobuf references within a .NET gRPC project. The tool can be used to add, refresh, remove and list Protobuf references.

## Installation

To install `dotnet-grpc` [.NET Core Global Tool](/dotnet/core/tools/global-tools), run the following command:

```console
dotnet tool install -g dotnet-grpc
```

## Add References

The global tool can be used to add Protobuf references as `<Protobuf />` items to the *.csproj* file:

```xml
<Protobuf Include="..\Proto\count.proto" GrpcServices="Server" Link="Protos\count.proto" />
```

The Protobuf references are used to generate the C# client and/or server assets. The tool can be used to create a Protobuf reference from local file(s) on disk or a remote file specified by an URL. The tool will also ensure the correct gRPC package dependencies are added to the project. For example, the `Grpc.AspNetCore` package, which contains gRPC server and client libraries as well as tooling support, will be added to a Web app. Alternatively, the `Grpc.Net.Client`, `Grpc.Tools` and `Google.Protobuf` packages, which contains only the gRPC client libraries and tooling support, will be added to a Console app.

### Add File

The `add-file` command is used to add local file(s) on disk as Protobuf reference(s). The file path(s) provided can be relative to the current directory or absolute paths and may contain wild cards for pattern based file globbing. If any file(s) are outside the project directory, a `Link` element will be added to display the file under the folder `Protos` in Visual Studio.

### Usage

```console
dotnet grpc add-file [options] <files>...
```

#### Arguments

| Argument | Description |
|-|-|
| files | The protobuf file reference(s). These can be a path to glob for local protobuf file(s). |

#### Options

| Short option | Long option | Description |
|-|-|-|
| -p | --project | The path to the project file to operate on. If a file is not specified, the command will search the current directory for one.
| -s | --services | The type of gRPC services that should be generated. If Default is specified, Both will be used for Web projects and Client will be used for non-Web projects. Accepted values are Both, Client, Default, None, Server.
| -i | --additional-import-dirs | Additional directories to be used when resolving imports for the protobuf files. This is a semicolon separated list of paths.
| | --access | The access modifier to use for the generated C# classes. Default value is Public. Accepted values are Internal and Public.

### Add URL

The `add-url` command is used to add a remote file specified by an source URL as Protobuf reference. A file path must be provided to specify where to download the remote file and it can be relative to the current directory or an absolute path. If the file path is outside the project directory, a `Link` element will be added to display the file under the virtual folder `Protos` in Visual Studio. 

### Usage

```console
dotnet-grpc add-url [options] <url>
```

#### Arguments

| Argument | Description |
|-|-|
| url | The URL to a remote protobuf file. |


#### Options

| Short option | Long option | Description |
|-|-|-|
| -o | --output | Specify the download path for the remote protobuf file. This is a required option.
| -p | --project | The path to the project file to operate on. If a file is not specified, the command will search the current directory for one.
| -s | --services | The type of gRPC services that should be generated. If Default is specified, Both will be used for Web projects and Client will be used for non-Web projects. Accepted values are Both, Client, Default, None, Server.
| -i | --additional-import-dirs | Additional directories to be used when resolving imports for the protobuf files. This is a semicolon separated list of paths.
| | --access | The access modifier to use for the generated C# classes. Default value is Public. Accepted values are Internal and Public.

## Remove

The `remove` command is used to remove Protobuf references from the *.csproj* file. The command accepts path(s) arguments and source URL as arguments. Note that the tool only removes the Protobuf reference but the actual *.proto* file is not deleted, even if it were originally downloaded from a remote URL.

### Usage

```console
dotnet-grpc remove [options] <references>...
```

### Arguments

| Argument | Description |
|-|-|
| references | The URL(s) or file path(s) of the protobuf references to remove. |

### Options

| Short option | Long option | Description |
|-|-|-|
| -p | --project | The path to the project file to operate on. If a file is not specified, the command will search the current directory for one.

## Refresh

The `refresh` command is used to update a remote reference with the latest content from the source URL. Both the download file path and the source URL can be used to specify the reference to be updated. Note that the hashes of the file contents is compared to determine whether the local file should be updated and no timestamp information is compared. The tool will always replace the the local file with the remote file if an update is needed.

### Usage

```console
dotnet-grpc refresh [options] [<references>...]
```

### Arguments

| Argument | Description |
|-|-|
| references | The URL(s) or file path(s) to remote protobuf references(s) that should be updated. Leave this argument empty to refresh all remote references. |

### Options

| Short option | Long option | Description |
|-|-|-|
| -p | --project | The path to the project file to operate on. If a file is not specified, the command will search the current directory for one.
| | --dry-run | Output a list of file(s) that will be updated without downloading any new content.

## Refresh

The `list` command is used to diplay all the Protobuf references in the project file. Note that if all values of a column are default values, the column may not be omitted.

### Usage

```console
dotnet-grpc list [options]
```

### Options

| Short option | Long option | Description |
|-|-|-|
| -p | --project | The path to the project file to operate on. If a file is not specified, the command will search the current directory for one.

## Additional resources

* <xref:grpc/index>
* <xref:grpc/basics>
* <xref:grpc/aspnetcore>
