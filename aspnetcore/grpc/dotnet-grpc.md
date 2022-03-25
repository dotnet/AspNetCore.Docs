---
title: Manage Protobuf references with dotnet-grpc
author: jamesnk
description: Learn about adding, updating, removing, and listing Protobuf references with the dotnet-grpc global tool.
monikerRange: '>= aspnetcore-3.0'
ms.author: jamesnk
ms.date: 10/17/2019
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: grpc/dotnet-grpc
---
# Manage Protobuf references with dotnet-grpc

`dotnet-grpc` is a .NET Core Global Tool for managing [Protobuf (`.proto`)](xref:grpc/basics#proto-file) references within a .NET gRPC project. The tool can be used to add, refresh, remove, and list Protobuf references.

## Installation

To install the `dotnet-grpc` [.NET Core Global Tool](/dotnet/core/tools/global-tools), run the following command:

```dotnetcli
dotnet tool install -g dotnet-grpc
```

## Add references

`dotnet-grpc` can be used to add Protobuf references as `<Protobuf />` items to the `.csproj` file:

```xml
<Protobuf Include="Protos\greet.proto" GrpcServices="Server" />
```

The Protobuf references are used to generate the C# client and/or server assets. The `dotnet-grpc` tool can:

* Create a Protobuf reference from local files on disk.
* Create a Protobuf reference from a remote file specified by a URL.
* Ensure the correct gRPC package dependencies are added to the project.

For example, the `Grpc.AspNetCore` package is added to a web app. `Grpc.AspNetCore` contains gRPC server and client libraries and tooling support. Alternatively, the `Grpc.Net.Client`, `Grpc.Tools` and `Google.Protobuf` packages, which contain only the gRPC client libraries and tooling support, are added to a Console app.

### Add file

The `add-file` command is used to add local files on disk as Protobuf references. The file paths provided:

* Can be relative to the current directory or absolute paths.
* May contain wild cards for pattern-based file [globbing](https://wikipedia.org/wiki/Glob_(programming)).

If any files are outside the project directory, a `Link` element is added to display the file under the folder `Protos` in Visual Studio.

### Usage

```dotnetcli
dotnet-grpc add-file [options] <files>...
```

#### Arguments

| Argument | Description |
|-|-|
| files | The protobuf file references. These can be a path to glob for local protobuf files. |

#### Options

| Short option | Long option | Description |
|-|-|-|
| -p | --project | The path to the project file to operate on. If a file is not specified, the command searches the current directory for one.
| -s | --services | The type of gRPC services that should be generated. If `Default` is specified, `Both` is used for Web projects and `Client` is used for non-Web projects. Accepted values are `Both`, `Client`, `Default`, `None`, `Server`.
| -i | --additional-import-dirs | Additional directories to be used when resolving imports for the protobuf files. This is a semicolon separated list of paths.
| | --access | The access modifier to use for the generated C# classes. The default value is `Public`. Accepted values are `Internal` and `Public`.

### Add URL

The `add-url` command is used to add a remote file specified by an source URL as Protobuf reference. A file path must be provided to specify where to download the remote file. The file path can be relative to the current directory or an absolute path. If the file path is outside the project directory, a `Link` element is added to display the file under the virtual folder `Protos` in Visual Studio.

### Usage

```dotnetcli
dotnet-grpc add-url [options] <url>
```

#### Arguments

| Argument | Description |
|-|-|
| url | The URL to a remote protobuf file. |

#### Options

| Short option | Long option | Description |
|-|-|-|
| -o | --output | Specifies the download path for the remote protobuf file. This is a required option.
| -p | --project | The path to the project file to operate on. If a file is not specified, the command searches the current directory for one.
| -s | --services | The type of gRPC services that should be generated. If `Default` is specified, `Both` is used for Web projects and `Client` is used for non-Web projects. Accepted values are `Both`, `Client`, `Default`, `None`, `Server`.
| -i | --additional-import-dirs | Additional directories to be used when resolving imports for the protobuf files. This is a semicolon separated list of paths.
| | --access | The access modifier to use for the generated C# classes. Default value is `Public`. Accepted values are `Internal` and `Public`.

## Remove

The `remove` command is used to remove Protobuf references from the `.csproj` file. The command accepts path arguments and source URLs as arguments. The tool:

* Only removes the Protobuf reference.
* Does not delete the `.proto` file, even if it was originally downloaded from a remote URL.

### Usage

```dotnetcli
dotnet-grpc remove [options] <references>...
```

### Arguments

| Argument | Description |
|-|-|
| references | The URLs or file paths of the protobuf references to remove. |

### Options

| Short option | Long option | Description |
|-|-|-|
| -p | --project | The path to the project file to operate on. If a file is not specified, the command searches the current directory for one.

## Refresh

The `refresh` command is used to update a remote reference with the latest content from the source URL. Both the download file path and the source URL can be used to specify the reference to be updated. Note:

* The hashes of the file contents are compared to determine whether the local file should be updated.
* No timestamp information is compared.

The tool always replaces the local file with the remote file if an update is needed.

### Usage

```dotnetcli
dotnet-grpc refresh [options] [<references>...]
```

### Arguments

| Argument | Description |
|-|-|
| references | The URLs or file paths to remote protobuf references that should be updated. Leave this argument empty to refresh all remote references. |

### Options

| Short option | Long option | Description |
|-|-|-|
| -p | --project | The path to the project file to operate on. If a file is not specified, the command searches the current directory for one.
| | --dry-run | Outputs a list of files that would be updated without downloading any new content.

## List

The `list` command is used to display all the Protobuf references in the project file. If all values of a column are default values, the column may be omitted.

### Usage

```dotnetcli
dotnet-grpc list [options]
```

### Options

| Short option | Long option | Description |
|-|-|-|
| -p | --project | The path to the project file to operate on. If a file is not specified, the command searches the current directory for one.

## Additional resources

* <xref:grpc/index>
* <xref:grpc/basics>
* <xref:grpc/aspnetcore>
