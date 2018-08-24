---
title: Use the LibMan command-line interface (CLI) with ASP.NET Core
author: scottaddie
description: Learn how to use the LibMan command-line interface (CLI) in an ASP.NET Core project.
ms.author: scaddie
ms.custom: mvc
ms.date: 08/23/2018
uid: client-side/libman/libman-cli
---
# Use the LibMan command-line interface (CLI) with ASP.NET Core

By [Scott Addie](https://twitter.com/Scott_Addie)

The [LibMan](xref:client-side/libman/index) CLI is a cross-platform tool that's supported everywhere .NET Core is supported.

## Prerequisites

* [!INCLUDE [2.1-SDK](../../includes/2.1-SDK.md)]

## Installation

To install the LibMan CLI, run the following command:

```console
dotnet tool install -g Microsoft.Web.LibraryManager.Cli
```

A [.NET Core Global Tool](/dotnet/core/tools/global-tools#install-a-global-tool) is installed from the [Microsoft.Web.LibraryManager.Cli](https://www.nuget.org/packages/Microsoft.Web.LibraryManager.Cli/) NuGet package.

To install the LibMan CLI from a specific NuGet package source, run the following command:

```console
dotnet tool install -g Microsoft.Web.LibraryManager.Cli --version 1.0.94-g606058a278 --add-source C:\Temp\
```

In the preceding example, a .NET Core Global Tool is installed from the local machine's *C:\Temp\Microsoft.Web.LibraryManager.Cli.1.0.94-g606058a278.nupkg* file.

To verify proper installation of the CLI, run the following command:

```console
libman
```

## Initialize LibMan in the project

### Synopsis

```console
libman init [--verbosity] [-p|--default-provider] [-d|--default-destination]
libman init <-h|--help>
```

### Options

The following options can be appended to the `libman init` command:

[!INCLUDE [standard-cli-options](../../includes/libman-cli/standard-cli-options.md)]

`-p|--default-provider <PROVIDER>`

The provider to use if no provider is defined for a given library. Replace `<PROVIDER>` with one of the following values:

* `cdnjs`
* `filesystem`
* `unpkg`

`-d|--default-destination <PATH>`

The path, relative to the current directory, to install library files if no destination is defined for a given library.

### Example

To create a *libman.json* file in an ASP.NET Core project:

* Navigate to the project root.
* Run the following command:
  
  ```console
  libman init
  ```

* Type the name of the default provider to be used, or press `Enter` to use the default CDNJS provider. Valid values include:

  * `cdnjs`
  * `filesystem`
  * `unpkg`

A *libman.json* file is added to the project root with the following contents:

```json
{
  "version": "1.0",
  "defaultProvider": "cdnjs",
  "libraries": []
}
```

## Add library files

The `libman install` command initializes a *libman.json* file if one doesn't exist.

### Synopsis

```console
libman install <LIBRARY_NAME> [-p|--provider] [-d|--destination] [--files]
libman install <-h|--help>
```

### Options

The following options can be appended to the `libman install` command:

[!INCLUDE [standard-cli-options](../../includes/libman-cli/standard-cli-options.md)]

`-p|--provider <PROVIDER>`

The provider to use. Replace `<PROVIDER>` with one of the following values:

* `cdnjs`
* `filesystem`
* `unpkg`

If not specified, the default provider is used. If no `defaultProvider` property is specified in *libman.json*, this option is required.

`-d|--destination <PATH>`

The location to install the library. If not specified, the default location is used. If no `defaultDestination` property is specified in *libman.json*, this option is required.

`--files <FILE>`

The name of the file to be installed from the specified library. If not specified, all files from the library are installed. Provide one `--files` option for each file to be installed.

### Examples

To install all files from the latest version of jQuery:

```console
libman install jquery
```

To install all files from jQuery version 3.2.1:

```console
libman install jquery@3.2.1
```

To install the latest jQuery version's *jquery.min.js* file to the *wwwroot\scripts\jquery* folder using the CDNJS provider:

```console
libman install jquery --provider cdnjs --destination wwwroot\scripts\jquery --files jquery.min.js
```

To install the *calendar.js* and *calendar.css* files from *C:\temp\contosoCalendar\* using the file system provider:

```console
libman install C:\temp\contosoCalendar\ --provider filesystem --files calendar.js --files calendar.css
```

## Restore library files

The `libman restore` command installs library files defined in *libman.json*. The following rules apply:

* If no *libman.json* file exists in the project root, an error is returned.
* If a library specifies a provider, the `defaultProvider` property in *libman.json* is ignored.
* If a library specifies a destination, the `defaultDestination` property in *libman.json* is ignored.

### Synopsis

```console
libman restore
libman restore <-h|--help>
```

### Options

The following options can be appended to the `libman restore` command:

[!INCLUDE [standard-cli-options](../../includes/libman-cli/standard-cli-options.md)]

### Example

To restore the library files defined in *libman.json*, run the following command from the project root:

```console
libman restore
```

## Delete library files

The `libman clean` command deletes library files previously restored with the LibMan CLI. Folders that become empty after this operation are deleted.

### Synopsis

```console
libman clean
libman clean <-h|--help>
```

### Options

The following options can be appended to the `libman clean` command:

[!INCLUDE [standard-cli-options](../../includes/libman-cli/standard-cli-options.md)]

### Example

To delete library files installed with LibMan, without removing the files' associated configurations from *libman.json*:

```console
libman clean
```

## Uninstall library files

The `libman uninstall` command:

* Deletes all files associated with the specified library from the destination in *libman.json*.
* Removes the associated library configuration from *libman.json*.

An error occurs when:

* No *libman.json* file exists in the project root.
* The specified library doesn't exist.

If more than one library with the same name is installed, you're prompted to choose one.

### Synopsis

```console
libman uninstall <LIBRARY>
libman uninstall <-h|--help>
```

### Options

The following options can be appended to the `libman uninstall` command:

[!INCLUDE [standard-cli-options](../../includes/libman-cli/standard-cli-options.md)]

### Examples

Imagine a *libman.json* file containing the following:

[!code-json[samples/LibManSample/libman.json]]

To uninstall jQuery, either of the following commands succeed:

```console
libman uninstall jquery
```

```console
libman uninstall jquery@3.3.1
```

<!-- TODO: how do I uninstall a filesystem library? -->

## Update library version

The `libman update` command updates a library installed via LibMan to the specified version.

An error occurs when:

* No *libman.json* file exists in the project root.
* The specified library doesn't exist.

If more than one library with the same name is installed, you're prompted to choose one.

### Synopsis

```console
libman update <LIBRARY> [-pre] [--to] [--verbosity]
libman update <-h|--help>
```

### Options

The following options can be appended to the `libman update` command:

[!INCLUDE [standard-cli-options](../../includes/libman-cli/standard-cli-options.md)]

`-pre`

Indicates the latest pre-release version of the library to download.

`--to <VERSION>`

The version to which the library should be updated.

### Examples

To update jQuery to the latest version:

```console
libman update jquery
```

To update jQuery to version 3.3.1:

```console
libman update jquery --to 3.3.1
```

To update jQuery to the latest pre-release version:

```console
libman update jquery -pre
```

## Manage library cache

### Synopsis

```console
libman cache clean
libman cache list [--files] [--libraries]
libman cache <-h|--help>
```

### Options

The following options can be appended to the `libman cache` command:

[!INCLUDE [standard-cli-options](../../includes/libman-cli/standard-cli-options.md)]

`--files`



`--libraries`


### Example

To view the library cache:

```console
libman cache list
```

Output similar to the following is displayed:

```console
Cache contents:
---------------
unpkg:
    bootstrap
    knockout
    react
    vue
filesystem:
    (empty)
cdnjs:
    bootstrap
    bootstrap-rtl
    font-awesome
    jquery
    knockout
    lodash.js
    react
    react-bootstrap
    twitter-bootstrap
```

## Additional resources

* [Install a Global Tool](/dotnet/core/tools/global-tools#install-a-global-tool)
* <xref:client-side/libman/libman-vs>
* [LibMan GitHub repository](https://github.com/aspnet/LibraryManager)
