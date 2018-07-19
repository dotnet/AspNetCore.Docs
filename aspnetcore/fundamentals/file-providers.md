---
title: File providers in ASP.NET Core
author: guardrex
description: Learn how ASP.NET Core abstracts file system access through the use of File Providers.
ms.author: riande
ms.date: 07/23/2018
uid: fundamentals/file-providers
---
# File Providers in ASP.NET Core

By [Steve Smith](https://ardalis.com/) and [Luke Latham](https://github.com/guardrex)

ASP.NET Core abstracts file system access through the use of File Providers. File Providers are used throughout the ASP.NET Core framework:

* [IHostingEnvironment](/dotnet/api/microsoft.extensions.hosting.ihostingenvironment) exposes the app's content root and web root as `IFileProvider` types.
* [Static Files Middleware](xref:fundamentals/static-files) uses File Providers to locate static files.
* [Razor](xref:mvc/views/razor) uses File Providers to locate pages and views.
* .NET Core tooling uses File Providers and glob patterns to specify which files should be published.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/file-providers/samples) ([how to download](xref:tutorials/index#how-to-download-a-sample))

## File Provider interfaces

The primary interface is [IFileProvider](/dotnet/api/microsoft.extensions.fileproviders.ifileprovider). `IFileProvider` exposes methods to:

* Obtain file information ([IFileInfo](/dotnet/api/microsoft.extensions.fileproviders.ifileinfo)).
* Obtain directory information ([IDirectoryContents](/dotnet/api/microsoft.extensions.fileproviders.idirectorycontents)).
* Set up change notifications (using an [IChangeToken](/dotnet/api/microsoft.extensions.primitives.ichangetoken)).

`IFileInfo` provides methods and properties for working with files:

* [Exists](/dotnet/api/microsoft.extensions.fileproviders.ifileinfo.exists)
* [IsDirectory](/dotnet/api/microsoft.extensions.fileproviders.ifileinfo.isdirectory)
* [Name](/dotnet/api/microsoft.extensions.fileproviders.ifileinfo.name)
* [Length](/dotnet/api/microsoft.extensions.fileproviders.ifileinfo.length) (in bytes)
* [LastModified](/dotnet/api/microsoft.extensions.fileproviders.ifileinfo.lastmodified) date

You can read from the file using the [IFileInfo.CreateReadStream](/dotnet/api/microsoft.extensions.fileproviders.ifileinfo.createreadstream) method.

The sample app shows how to configure a File Provider in `Startup.ConfigureServices` for use throughout the app via [dependency injection](xref:fundamentals/dependency-injection).

## File Provider implementations

Three implementations of `IFileProvider` are available.

| Implementation | Description |
| -------------- | ----------- |
| [PhysicalFileProvider](#physicalfileprovider) | The physical provider is used to access the system's physical files. |
| [EmbeddedFileProvider](#embeddedfileprovider) | The embedded provider is used to access files embedded in assemblies. |
| [CompositeFileProvider](#compositefileprovider) | The composite provider is used to provide combined access to files and directories from one or more other providers. |

### PhysicalFileProvider

The [PhysicalFileProvider](/dotnet/api/microsoft.extensions.fileproviders.physicalfileprovider) provides access to the physical file system. `PhysicalFileProvider` uses the [System.IO.File](/dotnet/api/system.io.file) type (for the physical provider) and scopes all paths to a directory and its children. This scoping prevents access to the file system outside of the specified directory and its children. When instantiating this provider, a directory path is required and serves as the base path for all requests made using the provider. You can instantiate a `PhysicalFileProvider` provider directly, or you can request an `IFileProvider` in a page model/controller or a service's constructor through [dependency injection](xref:fundamentals/dependency-injection).

**Static types**

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

The File Provider can be used to iterate through the `applicationRoot` directory or call `GetFileInfo` to obtain a file's information. The File Provider has no access outside of the `applicationRoot` directory.

The sample app creates the provider in the app's `Startup.ConfigureServices` class using [IHostingEnvironment.ContentRootFileProvider](/dotnet/api/microsoft.extensions.hosting.ihostingenvironment.contentrootfileprovider):

```csharp
var physicalProvider = _env.ContentRootFileProvider;
```

**Obtain File Provider types with dependency injection**

Inject the provider into any class constructor and assign it to a local field. Use the field throughout the class's methods to access files.

::: moniker range=">= aspnetcore-2.0"

In the sample app, the `IndexModel` class receives an `IFileProvider` instance to obtain directory contents for the app's base path.

*Pages/Index.cshtml.cs*:

[!code-csharp[](file-providers/samples/2.x/FileProviderSample/Pages/Index.cshtml.cs?name=snippet1)]

The `IDirectoryContents` are iterated in the page.

*Pages/Index.cshtml*:

[!code-cshtml[](file-providers/samples/2.x/FileProviderSample/Pages/Index.cshtml?name=snippet1)]

::: moniker-end

::: moniker range="< aspnetcore-2.0"

In the sample app, the `HomeController` class receives an `IFileProvider` instance to obtain directory contents for the app's base path.

*Controllers/HomeController.cs*:

[!code-csharp[](file-providers/samples/1.x/FileProviderSample/Controllers/HomeController.cs?name=snippet1)]

The `IDirectoryContents` are iterated in the view.

*Views/Home/Index.cshtml*:

[!code-cshtml[](file-providers/samples/1.x/FileProviderSample/Views/Home/Index.cshtml?name=snippet1)]

::: moniker-end

### EmbeddedFileProvider

The [EmbeddedFileProvider](/dotnet/api/microsoft.extensions.fileproviders.embeddedfileprovider) is used to access files embedded within assemblies. In .NET Core, files are embedded into an assembly with the [&lt;EmbeddedResource&gt;](/dotnet/core/tools/csproj#default-compilation-includes-in-net-core-projects) element in the project file:

```xml
<ItemGroup>
  <EmbeddedResource Include="Resource.txt" CopyToOutputDirectory="PreserveNewest" />
</ItemGroup>
```

Use [glob patterns](#glob-patterns) to specify one or more files to embed into the assembly.

The sample app creates an `EmbeddedFileProvider` and passes the currently executing assembly to its constructor.

*Startup.cs*:

```csharp
var embeddedProvider = new EmbeddedFileProvider(Assembly.GetEntryAssembly());
```

Embedded resources don't expose directories. Rather, the path to the resource (via its namespace) is embedded in its filename using `.` separators. In the sample app, the `baseNamespace` is `FileProviderSample.`.

The [EmbeddedFileProvider(Assembly, String)](/dotnet/api/microsoft.extensions.fileproviders.embeddedfileprovider.-ctor?view=aspnetcore-2.1#Microsoft_Extensions_FileProviders_EmbeddedFileProvider__ctor_System_Reflection_Assembly_) constructor accepts an optional `baseNamespace` parameter. Specifying the base namespace scopes calls to [GetDirectoryContents](/dotnet/api/microsoft.extensions.fileproviders.ifileprovider.getdirectorycontents) to those resources under the provided namespace.

### CompositeFileProvider

The [CompositeFileProvider](/dotnet/api/microsoft.extensions.fileproviders.compositefileprovider) combines `IFileProvider` instances, exposing a single interface for working with files from multiple providers. When creating the `CompositeFileProvider`, pass one or more `IFileProvider` instances to its constructor.

In the sample app, a `PhysicalFileProvider` and an `EmbeddedFileProvider` provide files to a `CompositeFileProvider` that's registered in the app's service container:

::: moniker range=">= aspnetcore-2.0"

[!code-csharp[](file-providers/samples/2.x/FileProviderSample/Startup.cs?name=snippet1)]

::: moniker-end

::: moniker range="< aspnetcore-2.0"

[!code-csharp[](file-providers/samples/1.x/FileProviderSample/Startup.cs?name=snippet1)]

::: moniker-end

## Watch for changes

The [IFileProvider.Watch](/dotnet/api/microsoft.extensions.fileproviders.ifileprovider.watch) method provides a scenario to watch one or more files or directories for changes. `Watch` accepts a path string, which can use [glob patterns](#glob-patterns) to specify multiple files. `Watch` returns an [IChangeToken](/dotnet/api/microsoft.extensions.primitives.ichangetoken). The change token exposes:

* [HasChanged](/dotnet/api/microsoft.extensions.primitives.ichangetoken.haschanged): A property that can be inspected to determine if a change has occurred.
* [RegisterChangeCallback](/dotnet/api/microsoft.extensions.primitives.ichangetoken.registerchangecallback): Called when changes are detected to the specified path string. Each change token only calls its associated callback in response to a single change. To enable constant monitoring, use a [TaskCompletionSource](/dotnet/api/system.threading.tasks.taskcompletionsource-1) (shown below) or recreate `IChangeToken` instances in response to changes.

In the sample app, the *WatchConsole* console app is configured to display a message whenever a text file is modified:

::: moniker range=">= aspnetcore-2.0"

[!code-csharp[](file-providers/samples/2.x/WatchConsole/Program.cs?name=snippet1&highlight=1-2,16,19-20)]

::: moniker-end

::: moniker range="< aspnetcore-2.0"

[!code-csharp[](file-providers/samples/1.x/WatchConsole/Program.cs?name=snippet1&highlight=1-2,16,19-20)]

::: moniker-end

Some file systems, such as Docker containers and network shares, may not reliably send change notifications. Set the `DOTNET_USE_POLLINGFILEWATCHER` environment variable to `1` or `true` to poll the file system for changes every four seconds.

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
Matches all files with `.txt` extension in a specific directory.

**`directory/*/appsettings.json`**  
Matches all `appsettings.json` files in directories exactly one level below the `directory` folder.

**`directory/**/*.txt`**  
Matches all files with `.txt` extension found anywhere under the `directory` folder.
