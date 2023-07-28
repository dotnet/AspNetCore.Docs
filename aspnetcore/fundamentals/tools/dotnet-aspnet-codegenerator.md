---
title: dotnet aspnet-codegenerator command
author: rick-anderson
description: The dotnet aspnet-codegenerator command scaffolds ASP.NET Core projects.
monikerRange: '>= aspnetcore-2.1'
ms.author: riande
ms.date: 12/05/2022
uid: fundamentals/tools/dotnet-aspnet-codegenerator
---

# dotnet aspnet-codegenerator

By [Rick Anderson](https://twitter.com/RickAndMSFT)

`dotnet aspnet-codegenerator` - Runs the ASP.NET Core scaffolding engine. `dotnet aspnet-codegenerator` is only required to scaffold from the command line, it's not needed to use scaffolding with Visual Studio.

## Install and update aspnet-codegenerator

Install the [.NET SDK](https://dotnet.microsoft.com/download).

`dotnet aspnet-codegenerator` is a [global tool](/dotnet/core/tools/global-tools) that must be installed. The following command installs the latest stable version of the `dotnet aspnet-codegenerator` tool:

```dotnetcli
dotnet tool install -g dotnet-aspnet-codegenerator
```

[!INCLUDE[](~/includes/dotnet-tool-install-arch-options.md)]

The following command updates `dotnet aspnet-codegenerator` to the latest stable version available from the installed .NET Core SDKs:

```dotnetcli
dotnet tool update -g dotnet-aspnet-codegenerator
```

## Uninstall aspnet-codegenerator

It may be necessary to uninstall the `aspnet-codegenerator` to resolve problems. For example, if you installed a preview version of `aspnet-codegenerator`, uninstall it before installing the released version.

The following commands uninstall the `dotnet aspnet-codegenerator` tool and installs the latest stable version:

```dotnetcli
dotnet tool uninstall -g dotnet-aspnet-codegenerator
dotnet tool install -g dotnet-aspnet-codegenerator
```

## Synopsis

```
dotnet aspnet-codegenerator [arguments] [-p|--project] [-n|--nuget-package-dir] [-c|--configuration] [-tfm|--target-framework] [-b|--build-base-path] [--no-build] 
dotnet aspnet-codegenerator [-h|--help]
```

## Description

The `dotnet aspnet-codegenerator` global command runs the ASP.NET Core code generator and scaffolding engine.

## Arguments

`generator`

The code generator to run. The following generators are available:

| Generator  | Operation                                                            |
| ---------- | -------------------------------------------------------------------- |
| area       | [Scaffolds an Area](xref:mvc/controllers/areas)                      |
| controller | [Scaffolds a controller](xref:tutorials/first-mvc-app/adding-model)  |
| identity   | [Scaffolds Identity](xref:security/authentication/scaffold-identity) |
| razorpage  | [Scaffolds Razor Pages](xref:tutorials/razor-pages/model)            |
| view       | [Scaffolds a view](xref:mvc/views/overview)                          |

## Options

`-n|--nuget-package-dir`

Specifies the NuGet package directory.

`-c|--configuration {Debug|Release}`

Defines the build configuration. The default value is `Debug`.

`-tfm|--target-framework`

Target [Framework](/dotnet/standard/frameworks) to use. For example, `net46`.

`-b|--build-base-path`

The build base path.

`-h|--help`

Prints out a short help for the command.

`--no-build`

Doesn't build the project before running. It also implicitly sets the `--no-restore` flag.

`-p|--project <PATH>`

Specifies the path of the project file to run (folder name or full path). If not specified, it defaults to the current directory.

## Generator options

The following sections detail the options available for the supported generators:

* Area
* Controller
* Identity  
* Razorpage
* View

<a name="area"></a>

### Area options

This tool is intended for ASP.NET Core web projects with controllers and views. It's not intended for Razor Pages apps.

Usage: `dotnet aspnet-codegenerator area AreaNameToGenerate`

The preceding command generates the following folders:

* *Areas*
  * *AreaNameToGenerate*
    * *Controllers*
    * *Data*
    * *Models*
    * *Views*

<a name="ctl"></a>

### Controller options

The following table lists options for  `aspnet-codegenerator` `razorpage`, `controller` and `view`:

[!INCLUDE [aspnet-codegenerator-args-md.md](~/includes/aspnet-codegenerator-args-md.md)]

The following table lists options unique to  `aspnet-codegenerator controller`:

| Option                         | Description                                                                                               |
| ------------------------------ | --------------------------------------------------------------------------------------------------------- |
| --controllerName or -name      | Name of the controller.                                                                                   |
| --useAsyncActions or -async    | Generate async controller actions.                                                                        |
| --noViews or -nv               | Generate **no** views.                                                                                    |
| --restWithNoViews or -api      | Generate a Controller with REST style API. `noViews` is assumed and any view related options are ignored. |
| --readWriteActions or -actions | Generate controller with read/write actions without a model.                                              |

Use the `-h` switch for help on the `aspnet-codegenerator controller` command:

```dotnetcli
dotnet aspnet-codegenerator controller -h
```

See [Scaffold the movie model](xref:tutorials/first-mvc-app/adding-model) for an example of `dotnet aspnet-codegenerator controller`.

### Razorpage

<a name="rp"></a>

Razor Pages can be individually scaffolded by specifying the name of the new page and the template to use. The supported templates are:

* `Empty`
* `Create`
* `Edit`
* `Delete`
* `Details`
* `List`

For example, the following command uses the Edit template to generate `MyEdit.cshtml` and `MyEdit.cshtml.cs`:

```dotnetcli
dotnet aspnet-codegenerator razorpage MyEdit Edit -m Movie -dc RazorPagesMovieContext -outDir Pages/Movies
```

Typically, the template and generated file name is not specified, and the following templates are created:

* `Create`
* `Edit`
* `Delete`
* `Details`
* `List`

The following table lists options for  `aspnet-codegenerator` `razorpage`, `controller` and `view`:

[!INCLUDE [aspnet-codegenerator-args-md.md](~/includes/aspnet-codegenerator-args-md.md)]

The following table lists options unique to  `aspnet-codegenerator razorpage`:

| Option                        | Description                                                                           |
| ----------------------------- | ------------------------------------------------------------------------------------- |
| --namespaceName or -namespace | The name of the namespace to use for the generated PageModel                          |
| --partialView or -partial     | Generate a partial view. Layout options -l and -udl are ignored if this is specified. |
| --noPageModel or -npm         | Switch to not generate a PageModel class for Empty template                           |

Use the `-h` switch for help on the `aspnet-codegenerator razorpage` command:

```dotnetcli
dotnet aspnet-codegenerator razorpage -h
```

See [Scaffold the movie model](xref:tutorials/razor-pages/model) for an example of `dotnet aspnet-codegenerator razorpage`.

### View

Views can be individually scaffolded by specifying the name of the view and the template to use. The supported templates are:

* `Empty`
* `Create`
* `Edit`
* `Delete`
* `Details`
* `List`

For example, the following command uses the Edit template to generate `MyEdit.cshtml`:

```dotnetcli
dotnet aspnet-codegenerator view MyEdit Edit -m Movie -dc MovieContext -outDir Views/Movies
```

The following table lists options for  `aspnet-codegenerator` `razorpage`, `controller` and `view`:

[!INCLUDE [aspnet-codegenerator-args-md.md](~/includes/aspnet-codegenerator-args-md.md)]

The following table lists options unique to  `aspnet-codegenerator view`:

| Option                        | Description                                                                           |
| ----------------------------- | ------------------------------------------------------------------------------------- |
| --controllerNamespace or -namespace | Specify the name of the namespace to use for the generated controller |
| --partialView or -partial | Generate a partial view, other layout options (-l and -udl) are ignored if this is specified |

Use the `-h` switch for help on the `aspnet-codegenerator view` command:

```dotnetcli
dotnet aspnet-codegenerator view -h
```

### Identity

See [Scaffold Identity](xref:security/authentication/scaffold-identity)
