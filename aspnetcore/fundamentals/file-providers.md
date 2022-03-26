---
title: File Providers in ASP.NET Core
author: rick-anderson
description: Learn how ASP.NET Core abstracts file system access through the use of File Providers.
monikerRange: '>= aspnetcore-2.1'
ms.author: riande
ms.custom: mvc
ms.date: 04/06/2020
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: fundamentals/file-providers
---
# File Providers in ASP.NET Core

By [Steve Smith](https://ardalis.com/)

:::moniker range=">= aspnetcore-3.0"

ASP.NET Core abstracts file system access through the use of File Providers. File Providers are used throughout the ASP.NET Core framework. For example:

* <xref:Microsoft.AspNetCore.Hosting.IWebHostEnvironment> exposes the app's [content root](xref:fundamentals/index#content-root) and [web root](xref:fundamentals/index#web-root) as `IFileProvider` types.
* [Static File Middleware](xref:fundamentals/static-files) uses File Providers to locate static files.
* [Razor](xref:mvc/views/razor) uses File Providers to locate pages and views.
* .NET Core tooling uses File Providers and glob patterns to specify which files should be published.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/file-providers/samples) ([how to download](xref:index#how-to-download-a-sample))

## File Provider interfaces

The primary interface is <xref:Microsoft.Extensions.FileProviders.IFileProvider>. `IFileProvider` exposes methods to:

* Obtain file information (<xref:Microsoft.Extensions.FileProviders.IFileInfo>).
* Obtain directory information (<xref:Microsoft.Extensions.FileProviders.IDirectoryContents>).
* Set up change notifications (using an <xref:Microsoft.Extensions.Primitives.IChangeToken>).

`IFileInfo` provides methods and properties for working with files:

* <xref:Microsoft.Extensions.FileProviders.IFileInfo.Exists>
* <xref:Microsoft.Extensions.FileProviders.IFileInfo.IsDirectory>
* <xref:Microsoft.Extensions.FileProviders.IFileInfo.Name>
* <xref:Microsoft.Extensions.FileProviders.IFileInfo.Length> (in bytes)
* <xref:Microsoft.Extensions.FileProviders.IFileInfo.LastModified> date

You can read from the file using the <xref:Microsoft.Extensions.FileProviders.IFileInfo.CreateReadStream%2A?displayProperty=nameWithType> method.

The `FileProviderSample` sample app demonstrates how to configure a File Provider in `Startup.ConfigureServices` for use throughout the app via [dependency injection](xref:fundamentals/dependency-injection).

## File Provider implementations

The following table lists implementations of `IFileProvider`.

| Implementation | Description |
| -------------- | ----------- |
| [Composite File Provider](#composite-file-provider) | Used to provide combined access to files and directories from one or more other providers. |
| [Manifest Embedded File Provider](#manifest-embedded-file-provider) | Used to access files embedded in assemblies. |
| [Physical File Provider](#physical-file-provider) | Used to access the system's physical files. |

### Physical File Provider

The <xref:Microsoft.Extensions.FileProviders.PhysicalFileProvider> provides access to the physical file system. `PhysicalFileProvider` uses the <xref:System.IO.File?displayProperty=fullName> type (for the physical provider) and scopes all paths to a directory and its children. This scoping prevents access to the file system outside of the specified directory and its children. The most common scenario for creating and using a `PhysicalFileProvider` is to request an `IFileProvider` in a constructor through [dependency injection](xref:fundamentals/dependency-injection).

When instantiating this provider directly, an absolute directory path is required and serves as the base path for all requests made using the provider. Glob patterns aren't supported in the directory path.

The following code shows how to use `PhysicalFileProvider` to obtain directory contents and file information:

```csharp
var provider = new PhysicalFileProvider(applicationRoot);
var contents = provider.GetDirectoryContents(string.Empty);
var filePath = Path.Combine("wwwroot", "js", "site.js");
var fileInfo = provider.GetFileInfo(filePath);
```

Types in the preceding example:

* `provider` is an `IFileProvider`.
* `contents` is an `IDirectoryContents`.
* `fileInfo` is an `IFileInfo`.

The File Provider can be used to iterate through the directory specified by `applicationRoot` or call `GetFileInfo` to obtain a file's information. Glob patterns can't be passed to the `GetFileInfo` method. The File Provider has no access outside of the `applicationRoot` directory.

The `FileProviderSample` sample app creates the provider in the `Startup.ConfigureServices` method using <xref:Microsoft.Extensions.Hosting.IHostEnvironment.ContentRootFileProvider?displayProperty=nameWithType>:

```csharp
var physicalProvider = _env.ContentRootFileProvider;
```

### Manifest Embedded File Provider

The <xref:Microsoft.Extensions.FileProviders.ManifestEmbeddedFileProvider> is used to access files embedded within assemblies. The `ManifestEmbeddedFileProvider` uses a manifest compiled into the assembly to reconstruct the original paths of the embedded files.

To generate a manifest of the embedded files:

1. Add the [`Microsoft.Extensions.FileProviders.Embedded`](https://www.nuget.org/packages/Microsoft.Extensions.FileProviders.Embedded) NuGet package to your project.
1. Set the `<GenerateEmbeddedFilesManifest>` property to `true`. Specify the files to embed with [`<EmbeddedResource>`](/dotnet/core/tools/csproj#default-compilation-includes-in-net-core-projects):

    [!code-xml[](file-providers/samples/3.x/FileProviderSample/FileProviderSample.csproj?highlight=5,13)]

Use [glob patterns](#glob-patterns) to specify one or more files to embed into the assembly.

The `FileProviderSample` sample app creates an `ManifestEmbeddedFileProvider` and passes the currently executing assembly to its constructor.

`Startup.cs`:

```csharp
var manifestEmbeddedProvider = 
    new ManifestEmbeddedFileProvider(typeof(Program).Assembly);
```

Additional overloads allow you to:

* Specify a relative file path.
* Scope files to a last modified date.
* Name the embedded resource containing the embedded file manifest.

| Overload | Description |
| -------- | ----------- |
| `ManifestEmbeddedFileProvider(Assembly, String)` | Accepts an optional `root` relative path parameter. Specify the `root` to scope calls to <xref:Microsoft.Extensions.FileProviders.IFileProvider.GetDirectoryContents%2A> to those resources under the provided path. |
| `ManifestEmbeddedFileProvider(Assembly, String, DateTimeOffset)` | Accepts an optional `root` relative path parameter and a `lastModified` date (<xref:System.DateTimeOffset>) parameter. The `lastModified` date scopes the last modification date for the <xref:Microsoft.Extensions.FileProviders.IFileInfo> instances returned by the <xref:Microsoft.Extensions.FileProviders.IFileProvider>. |
| `ManifestEmbeddedFileProvider(Assembly, String, String, DateTimeOffset)` | Accepts an optional `root` relative path, `lastModified` date, and `manifestName` parameters. The `manifestName` represents the name of the embedded resource containing the manifest. |

### Composite File Provider

The <xref:Microsoft.Extensions.FileProviders.CompositeFileProvider> combines `IFileProvider` instances, exposing a single interface for working with files from multiple providers. When creating the `CompositeFileProvider`, pass one or more `IFileProvider` instances to its constructor.

In the `FileProviderSample` sample app, a `PhysicalFileProvider` and a `ManifestEmbeddedFileProvider` provide files to a `CompositeFileProvider` registered in the app's service container. The following code is found in the project's `Startup.ConfigureServices` method:

[!code-csharp[](file-providers/samples/3.x/FileProviderSample/Startup.cs?name=snippet1)]

## Watch for changes

The <xref:Microsoft.Extensions.FileProviders.IFileProvider.Watch%2A?displayProperty=nameWithType> method provides a scenario to watch one or more files or directories for changes. The `Watch` method:

* Accepts a file path string, which can use [glob patterns](#glob-patterns) to specify multiple files.
* Returns an <xref:Microsoft.Extensions.Primitives.IChangeToken>.

The resulting change token exposes:

* <xref:Microsoft.Extensions.Primitives.IChangeToken.HasChanged>: A property that can be inspected to determine if a change has occurred.
* <xref:Microsoft.Extensions.Primitives.IChangeToken.RegisterChangeCallback%2A>: Called when changes are detected to the specified path string. Each change token only calls its associated callback in response to a single change. To enable constant monitoring, use a <xref:System.Threading.Tasks.TaskCompletionSource`1> (shown below) or recreate `IChangeToken` instances in response to changes.

The `WatchConsole` sample app writes a message whenever a `.txt` file in the `TextFiles` directory is modified:

[!code-csharp[](file-providers/samples/3.x/WatchConsole/Program.cs?name=snippet1)]

Some file systems, such as Docker containers and network shares, may not reliably send change notifications. Set the `DOTNET_USE_POLLING_FILE_WATCHER` environment variable to `1` or `true` to poll the file system for changes every four seconds (not configurable).

### Glob patterns

File system paths use wildcard patterns called *glob (or globbing) patterns*. Specify groups of files with these patterns. The two wildcard characters are `*` and `**`:

**`*`**  
Matches anything at the current folder level, any filename, or any file extension. Matches are terminated by `/` and `.` characters in the file path.

**`**`**  
Matches anything across multiple directory levels. Can be used to recursively match many files within a directory hierarchy.

The following table provides common examples of glob patterns.

| Pattern                        | Description |
| ------------------------------ | ----------- |
| `directory/file.txt`           | Matches a specific file in a specific directory.|
| `directory/*.txt`              | Matches all files with `.txt` extension in a specific directory.|
| `directory/*/appsettings.json` | Matches all `appsettings.json` files in directories exactly one level below the `directory` folder.|
| `directory/**/*.txt`           | Matches all files with a `.txt` extension found anywhere under the `directory` folder.|

:::moniker-end

:::moniker range="< aspnetcore-3.0"

ASP.NET Core abstracts file system access through the use of File Providers. File Providers are used throughout the ASP.NET Core framework:

* <xref:Microsoft.Extensions.Hosting.IHostingEnvironment> exposes the app's [content root](xref:fundamentals/index#content-root) and [web root](xref:fundamentals/index#web-root) as `IFileProvider` types.
* [Static File Middleware](xref:fundamentals/static-files) uses File Providers to locate static files.
* [Razor](xref:mvc/views/razor) uses File Providers to locate pages and views.
* .NET Core tooling uses File Providers and glob patterns to specify which files should be published.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/file-providers/samples) ([how to download](xref:index#how-to-download-a-sample))

## File Provider interfaces

The primary interface is <xref:Microsoft.Extensions.FileProviders.IFileProvider>. `IFileProvider` exposes methods to:

* Obtain file information (<xref:Microsoft.Extensions.FileProviders.IFileInfo>).
* Obtain directory information (<xref:Microsoft.Extensions.FileProviders.IDirectoryContents>).
* Set up change notifications (using an <xref:Microsoft.Extensions.Primitives.IChangeToken>).

`IFileInfo` provides methods and properties for working with files:

* <xref:Microsoft.Extensions.FileProviders.IFileInfo.Exists>
* <xref:Microsoft.Extensions.FileProviders.IFileInfo.IsDirectory>
* <xref:Microsoft.Extensions.FileProviders.IFileInfo.Name>
* <xref:Microsoft.Extensions.FileProviders.IFileInfo.Length> (in bytes)
* <xref:Microsoft.Extensions.FileProviders.IFileInfo.LastModified> date

You can read from the file using the [IFileInfo.CreateReadStream](xref:Microsoft.Extensions.FileProviders.IFileInfo.CreateReadStream*) method.

The sample app demonstrates how to configure a File Provider in `Startup.ConfigureServices` for use throughout the app via [dependency injection](xref:fundamentals/dependency-injection).

## File Provider implementations

Three implementations of `IFileProvider` are available.

| Implementation | Description |
| -------------- | ----------- |
| [PhysicalFileProvider](#physicalfileprovider) | The physical provider is used to access the system's physical files. |
| [ManifestEmbeddedFileProvider](#manifestembeddedfileprovider) | The manifest embedded provider is used to access files embedded in assemblies. |
| [CompositeFileProvider](#compositefileprovider) | The composite provider is used to provide combined access to files and directories from one or more other providers. |

### PhysicalFileProvider

The <xref:Microsoft.Extensions.FileProviders.PhysicalFileProvider> provides access to the physical file system. `PhysicalFileProvider` uses the <xref:System.IO.File?displayProperty=fullName> type (for the physical provider) and scopes all paths to a directory and its children. This scoping prevents access to the file system outside of the specified directory and its children. The most common scenario for creating and using a `PhysicalFileProvider` is to request an `IFileProvider` in a constructor through [dependency injection](xref:fundamentals/dependency-injection).

When instantiating this provider directly, a directory path is required and serves as the base path for all requests made using the provider.

The following code shows how to create a `PhysicalFileProvider` and use it to obtain directory contents and file information:

```csharp
var provider = new PhysicalFileProvider(applicationRoot);
var contents = provider.GetDirectoryContents(string.Empty);
var fileInfo = provider.GetFileInfo("wwwroot/js/site.js");
```

Types in the preceding example:

* `provider` is an `IFileProvider`.
* `contents` is an `IDirectoryContents`.
* `fileInfo` is an `IFileInfo`.

The File Provider can be used to iterate through the directory specified by `applicationRoot` or call `GetFileInfo` to obtain a file's information. The File Provider has no access outside of the `applicationRoot` directory.

The sample app creates the provider in the app's `Startup.ConfigureServices` class using [IHostingEnvironment.ContentRootFileProvider](xref:Microsoft.Extensions.Hosting.IHostingEnvironment.ContentRootFileProvider):

```csharp
var physicalProvider = _env.ContentRootFileProvider;
```

### ManifestEmbeddedFileProvider

The <xref:Microsoft.Extensions.FileProviders.ManifestEmbeddedFileProvider> is used to access files embedded within assemblies. The `ManifestEmbeddedFileProvider` uses a manifest compiled into the assembly to reconstruct the original paths of the embedded files.

To generate a manifest of the embedded files, set the `<GenerateEmbeddedFilesManifest>` property to `true`. Specify the files to embed with [&lt;EmbeddedResource&gt;](/dotnet/core/tools/csproj#default-compilation-includes-in-net-core-projects):

[!code-xml[](file-providers/samples/2.x/FileProviderSample/FileProviderSample.csproj?highlight=6,14)]

Use [glob patterns](#glob-patterns) to specify one or more files to embed into the assembly.

The sample app creates an `ManifestEmbeddedFileProvider` and passes the currently executing assembly to its constructor.

`Startup.cs`:

```csharp
var manifestEmbeddedProvider = 
    new ManifestEmbeddedFileProvider(typeof(Program).Assembly);
```

Additional overloads allow you to:

* Specify a relative file path.
* Scope files to a last modified date.
* Name the embedded resource containing the embedded file manifest.

| Overload | Description |
| -------- | ----------- |
| `ManifestEmbeddedFileProvider(Assembly, String)` | Accepts an optional `root` relative path parameter. Specify the `root` to scope calls to <xref:Microsoft.Extensions.FileProviders.IFileProvider.GetDirectoryContents*> to those resources under the provided path. |
| `ManifestEmbeddedFileProvider(Assembly, String, DateTimeOffset)` | Accepts an optional `root` relative path parameter and a `lastModified` date (<xref:System.DateTimeOffset>) parameter. The `lastModified` date scopes the last modification date for the <xref:Microsoft.Extensions.FileProviders.IFileInfo> instances returned by the <xref:Microsoft.Extensions.FileProviders.IFileProvider>. |
| `ManifestEmbeddedFileProvider(Assembly, String, String, DateTimeOffset)` | Accepts an optional `root` relative path, `lastModified` date, and `manifestName` parameters. The `manifestName` represents the name of the embedded resource containing the manifest. |

### CompositeFileProvider

The <xref:Microsoft.Extensions.FileProviders.CompositeFileProvider> combines `IFileProvider` instances, exposing a single interface for working with files from multiple providers. When creating the `CompositeFileProvider`, pass one or more `IFileProvider` instances to its constructor.

In the sample app, a `PhysicalFileProvider` and a `ManifestEmbeddedFileProvider` provide files to a `CompositeFileProvider` registered in the app's service container:

[!code-csharp[](file-providers/samples/2.x/FileProviderSample/Startup.cs?name=snippet1)]

## Watch for changes

The [IFileProvider.Watch](xref:Microsoft.Extensions.FileProviders.IFileProvider.Watch*) method provides a scenario to watch one or more files or directories for changes. `Watch` accepts a path string, which can use [glob patterns](#glob-patterns) to specify multiple files. `Watch` returns an <xref:Microsoft.Extensions.Primitives.IChangeToken>. The change token exposes:

* <xref:Microsoft.Extensions.Primitives.IChangeToken.HasChanged>: A property that can be inspected to determine if a change has occurred.
* <xref:Microsoft.Extensions.Primitives.IChangeToken.RegisterChangeCallback*>: Called when changes are detected to the specified path string. Each change token only calls its associated callback in response to a single change. To enable constant monitoring, use a <xref:System.Threading.Tasks.TaskCompletionSource`1> (shown below) or recreate `IChangeToken` instances in response to changes.

In the sample app, the *WatchConsole* console app is configured to display a message whenever a text file is modified:

[!code-csharp[](file-providers/samples/2.x/WatchConsole/Program.cs?name=snippet1&highlight=1-2,16,19-20)]

Some file systems, such as Docker containers and network shares, may not reliably send change notifications. Set the `DOTNET_USE_POLLING_FILE_WATCHER` environment variable to `1` or `true` to poll the file system for changes every four seconds (not configurable).

## Glob patterns

File system paths use wildcard patterns called *glob (or globbing) patterns*. Specify groups of files with these patterns. The two wildcard characters are `*` and `**`:

**`*`**  
Matches anything at the current folder level, any filename, or any file extension. Matches are terminated by `/` and `.` characters in the file path.

**`**`**  
Matches anything across multiple directory levels. Can be used to recursively match many files within a directory hierarchy.

**Glob pattern examples**

**`directory/file.txt`**  
Matches a specific file in a specific directory.

**`directory/*.txt`**  
Matches all files with *.txt* extension in a specific directory.

**`directory/*/appsettings.json`**  
Matches all `appsettings.json` files in directories exactly one level below the *directory* folder.

**`directory/**/*.txt`**  
Matches all files with *.txt* extension found anywhere under the *directory* folder.

:::moniker-end
