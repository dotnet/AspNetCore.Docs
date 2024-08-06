---
title: ASP.NET Core code generator tool (`aspnet-codegenerator`)
author: tdykstra
description: The ASP.NET Core code generator tool scaffolds ASP.NET Core projects.
monikerRange: '>= aspnetcore-2.1'
ms.author: tdykstra
ms.date: 07/05/2024
uid: fundamentals/tools/dotnet-aspnet-codegenerator
---
# ASP.NET Core code generator tool (`aspnet-codegenerator`)

[!INCLUDE[](~/includes/not-latest-version.md)]

The `dotnet aspnet-codegenerator` command runs the ASP.NET Core scaffolding engine. Running the `dotnet aspnet-codegenerator` command is required to scaffold from the command line or when using Visual Studio Code. The command isn't required to use scaffolding with Visual Studio, which includes the scaffolding engine by default.

## Install and update the code generator tool

Install the [.NET SDK](https://dotnet.microsoft.com/download).

`dotnet aspnet-codegenerator` is a [global tool](/dotnet/core/tools/global-tools) that must be installed. The following command installs the latest stable version of the ASP.NET Core code generator tool:

```dotnetcli
dotnet tool install -g dotnet-aspnet-codegenerator
```

[!INCLUDE[](~/includes/dotnet-tool-install-arch-options.md)]

If the tool is already installed, the following command updates the tool to the latest stable version available from the installed .NET Core SDKs:

```dotnetcli
dotnet tool update -g dotnet-aspnet-codegenerator
```

## Uninstall the code generator tool

It may be necessary to uninstall the ASP.NET Core code generator tool to resolve problems. For example, if you installed a preview version of the tool, uninstall it before installing the released version.

The following commands uninstall the ASP.NET Core code generator tool and install the latest stable version:

```dotnetcli
dotnet tool uninstall -g dotnet-aspnet-codegenerator
dotnet tool install -g dotnet-aspnet-codegenerator
```

## Synopsis

```
dotnet aspnet-codegenerator [arguments] [-b|--build-base-path] [-c|--configuration] [-n|--nuget-package-dir] [--no-build] [-p|--project] [-tfm|--target-framework]
dotnet aspnet-codegenerator [-h|--help]
```

## Description

The `dotnet aspnet-codegenerator` global command runs the ASP.NET Core code generator and scaffolding engine.

## Arguments

`generator`

The code generator to run. The available generators are shown in the following table.

:::moniker range=">= aspnetcore-8.0"

Generator         | Operation
----------------- | ---
`area`            | [Scaffolds an area](xref:mvc/controllers/areas).
`blazor`          | [Scaffolds Blazor create, read, update, delete, and list pages](xref:blazor/components/quickgrid#quickgrid-scaffolder).
`blazor-identity` | Generates Blazor Identity files.
`controller`      | [Scaffolds a controller](xref:tutorials/first-mvc-app/adding-model).
`identity`        | [Scaffolds Identity](xref:security/authentication/scaffold-identity).
`minimalapi`      | Generates an endpoints file (with CRUD API endpoints) given a model and optional database context.
`razorpage`       | [Scaffolds Razor Pages](xref:tutorials/razor-pages/model).
`view`            | [Scaffolds a view](xref:mvc/views/overview).

:::moniker-end

:::moniker range="< aspnetcore-8.0"

Generator         | Operation
----------------- | ---
`area`            | [Scaffolds an area](xref:mvc/controllers/areas).
`controller`      | [Scaffolds a controller](xref:tutorials/first-mvc-app/adding-model).
`identity`        | [Scaffolds Identity](xref:security/authentication/scaffold-identity).
`minimalapi`      | Generates an endpoints file (with CRUD API endpoints) given a model and optional database context.
`razorpage`       | [Scaffolds Razor Pages](xref:tutorials/razor-pages/model).
`view`            | [Scaffolds a view](xref:mvc/views/overview).

:::moniker-end

## Options

`-b|--build-base-path`

The build base path.

`-c|--configuration {Debug|Release}`

Defines the build configuration. The default value is `Debug`.

`-h|--help`

Prints out a short help for the command.

`-n|--nuget-package-dir`

Specifies the NuGet package directory.

`--no-build`

Doesn't build the project before running. Passing `--no-build` also implicitly sets the `--no-restore` flag.

`-p|--project <PATH>`

Specifies the path of the project file to run (folder name or full path). If not specified, the tool defaults to the current directory.

`-tfm|--target-framework`

The target [framework](/dotnet/standard/frameworks) to use.

## Generator options

The following sections detail the options available for the supported generators:

:::moniker range=">= aspnetcore-8.0"

* [Area (`area`)](#area-options)
* [Controller (`controller`)](#controller-options)
* [Blazor (`blazor`)](#blazor-options)
* [Blazor Identity (`blazor-identity`)](#blazor-identity-options)
* [Identity (`identity`)](#identity-options)
* [Minimal API (`minimalapi`)](#minimal-api-options)
* [Razor page (`razorpage`)](#razor-page-options)
* [View (`view`)](#view-options)

:::moniker-end

:::moniker range="< aspnetcore-8.0"

* [Area (`area`)](#area-options)
* [Controller (`controller`)](#controller-options)
* [Identity (`identity`)](#identity-options)
* [Minimal API (`minimalapi`)](#minimal-api-options)
* [Razor page (`razorpage`)](#razor-page-options)
* [View (`view`)](#view-options)

:::moniker-end

### Area options

Usage: `dotnet aspnet-codegenerator area {AREA NAME}`

The `{AREA NAME}` placeholder is the name of the area to generate.

The preceding command generates the following folders:

* `Areas`
  * `{AREA NAME}`
    * `Controllers`
    * `Data`
    * `Models`
    * `Views`

Use the `-h|--help` option for help:

```dotnetcli
dotnet aspnet-codegenerator area -h
```

:::moniker range=">= aspnetcore-8.0"

### Blazor options

Razor components can be individually scaffolded for Blazor apps by specifying the name of the template to use. The supported templates are:

* `Empty`
* `Create`
* `Edit`
* `Delete`
* `Details`
* `List`
* `CRUD`: *CRUD* is an acronym for Create, Read, Update, and Delete. The `CRUD` template produces `Create`, `Edit`, `Delete`, `Details`, and `Index` (`List`) components for the app.

The options for the `blazor` generator are shown in the following table.

Option                           | Description
-------------------------------- | ---
`-dbProvider|--databaseProvider` | Database provider to use. Options include `sqlserver` (default), `sqlite`, `cosmos`, or `postgres`.
`-dc|--dataContext`              | Database context class to use.
`-m|--model`                     | Model class to use.
`-ns|--namespaceName`            | Specify the name of the namespace to use for the generated Endpoints file.
`--relativeFolderPath|-outDir`   | Relative output folder path. If not specified, files are generated in the project folder.

The following example:

* Uses the `Edit` template to generate an `Edit` component (`Edit.razor`) in the `Components/Pages/MoviePages` folder of the app. If the `MoviePages` folder doesn't exist, the tool creates the folder automatically.
* Uses the SQLite database provider.
* Uses `BlazorWebAppMovies.Data.BlazorWebAppMoviesContext` for the database context.
* Uses the `Movie` model.

```dotnetcli
dotnet aspnet-codegenerator blazor Edit -dbProvider sqlite -dc BlazorWebAppMovies.Data.BlazorWebAppMoviesContext -m Movie -outDir Components/Pages
```

Use the `-h|--help` option for help:

```dotnetcli
dotnet aspnet-codegenerator blazor -h
```

<!-- UPDATE 9.0 Uncomment link after
                https://github.com/dotnet/AspNetCore.Docs/pull/32747
                merges. This is tracked by a comment on the
                tutorial PR.

For an example that uses the `blazor` generator, see <xref:blazor/tutorials/movie-database-app/index>.
-->

For more information, see <xref:blazor/components/quickgrid#quickgrid-scaffolder>.

### Blazor Identity options

Scaffold Identity Razor components into a Blazor app with the `blazor-identity` generator.

The options for the `blazor-identity` template are shown in the following table.

Option                           | Description
-------------------------------- | ---
`-dbProvider|--databaseProvider` | Database provider to use. Options include `sqlserver` (default) and `sqlite`.
`-dc|--dataContext`              | Database context class to use.
`-f|--force`                     | Use this option to overwrite existing files.
`-fi|--files`                    | List of semicolon separated files to scaffold. Use the `-lf|--listFiles` option to see the available options.
`-lf|--listFiles`                | Lists the files that can be scaffolded by using the `-fi|--files` option.
`-rn|--rootNamespace`            | Root namespace to use for generating Identity code.
`-u|--userClass`                 | Name of the user class to generate.

Use the `-h|--help` option for help:

```dotnetcli
dotnet aspnet-codegenerator blazor-identity -h
```

:::moniker-end

### Controller options

General options are shown in the following table.

[!INCLUDE[](~/fundamentals/includes/codegenerator-common-args.md)]

The options unique to `controller` are shown in the following table.

Option                             | Description
---------------------------------- | ---
`-actions|--readWriteActions`      | Generate controller with read/write actions without a model.
`-api|--restWithNoViews`           | Generate a controller with REST style API. `noViews` is assumed and any view related options are ignored.
`-async|--useAsyncActions`         | Generate asynchronous controller actions.
`-name|--controllerName`           | Name of the controller.
`-namespace|--controllerNamespace` | Specify the name of the namespace to use for the generated controller.
`-nv|--noViews`                    | Generate **no** views.

Use the `-h|--help` option for help:

```dotnetcli
dotnet aspnet-codegenerator controller -h
```

For an example that uses the `controller` generator, see <xref:tutorials/first-mvc-app/adding-model>.

### Identity options

For more information, see <xref:security/authentication/scaffold-identity>.

### Minimal API options

Scaffold a Minimal API backend with the `minimalapi` template.

The options for `minimalapi` are shown in the following table.

Option                            | Description
--------------------------------- | ---
`-dbProvider|--databaseProvider`  | Database provider to use. Options include `sqlserver` (default), `sqlite`, `cosmos`, or `postgres`.
`-dc|--dataContext`               | Database context class to use.
`-e|--endpoints`                  | Endpoints class to use (not the file name).
`-m|--model`                      | Model class to use.
`-namespace|--endpointsNamespace` | Specify the name of the namespace to use for the generated endpoints file.
`-o|--open`                       | Use this option to enable OpenAPI.
`-outDir|--relativeFolderPath`    | Relative output folder path. If not specified, files are generated in the project folder.
`-sqlite|--useSqlite`             | Flag to specify if the database context should use SQLite instead of SQL Server. |

The following example:

* Generates an endpoints class named `SpeakersEndpoints` with API endpoints that map to database operations using the `ApplicationDbContext` database context class and the `BackEnd.Models.Speaker` model.
* Adds `app.MapSpeakerEndpoints();` to the `Program` file (`Program.cs`) to register the endpoints class.

```dotnetcli
dotnet aspnet-codegenerator minimalapi -dc ApplicationDbContext -e SpeakerEndpoints -m BackEnd.Models.Speaker -o
```

Use the `-h|--help` option for help:

```dotnetcli
dotnet aspnet-codegenerator minimalapi -h
```

### Razor page options

Razor Pages can be individually scaffolded by specifying the name of the new page and the template to use. The supported templates are:

* `Empty`
* `Create`
* `Edit`
* `Delete`
* `Details`
* `List`

Typically, the template and generated file name isn't specified, which creates the following templates:

* `Create`
* `Edit`
* `Delete`
* `Details`
* `List`

General options are shown in the following table.

[!INCLUDE[](~/fundamentals/includes/codegenerator-common-args.md)]

The options unique to `razorpage` are shown in the following table.

Option                       | Description
---------------------------- | ---
`-namespace|--namespaceName` | The name of the namespace to use for the generated `PageModel` class.
`-npm|--noPageModel`         | Don't generate a `PageModel` class for the `Empty` template.
`-partial|--partialView`     | Generate a partial view. Layout options `-l` and `-udl` are ignored if this is specified.

The following example uses the `Edit` template to generate `CustomEditPage.cshtml` and `CustomEditPage.cshtml.cs` in the `Pages/Movies` folder:

```dotnetcli
dotnet aspnet-codegenerator razorpage CustomEditPage Edit -dc RazorPagesMovieContext -m Movie -outDir Pages/Movies
```

Use the `-h|--help` option for help:

```dotnetcli
dotnet aspnet-codegenerator razorpage -h
```

For an example that uses the `razorpage` generator, see <xref:tutorials/razor-pages/model>.

### View options

Views can be individually scaffolded by specifying the name of the view and the template. The supported templates are:

* `Empty`
* `Create`
* `Edit`
* `Delete`
* `Details`
* `List`

General options are shown in the following table.

[!INCLUDE[](~/fundamentals/includes/codegenerator-common-args.md)]

The options unique to `view` are shown in the following table.

Option                             | Description
---------------------------------- | ---
`-namespace|--controllerNamespace` | Specify the name of the namespace to use for the generated controller.
`-partial|--partialView`           | Generate a partial view. Other layout options (`-l` and `-udl`) are ignored if this is specified.

The following example uses the `Edit` template to generate `CustomEditView.cshtml` in the `Views/Movies` folder:

```dotnetcli
dotnet aspnet-codegenerator view CustomEditView Edit -dc MovieContext -m Movie -outDir Views/Movies
```

Use the `-h|--help` option for help:

```dotnetcli
dotnet aspnet-codegenerator view -h
```
