.. _dnx-overview:

DNX Overview
====================================

By `Daniel Roth`_

What is the .NET Execution Environment?
---------------------------------------------

The .NET Execution Environment (DNX) is a software development kit (SDK) and runtime environment that has everything you need to build and run .NET applications for Windows, Mac and Linux. It provides a host process, CLR hosting logic and managed entry point discovery.  DNX was built for running cross-platform ASP.NET Web applications, but it can run other types of .NET applications, too, such as cross-platform console apps.

Why build DNX?
--------------

**Cross-platform .NET development** DNX provides a consistent development and execution environment across multiple platforms (Windows, Mac and Linux) and across different .NET flavors (.NET Framework, .NET Core and Mono).
With DNX you can develop your application on one platform and run it on a different platform as long as you have a compatible DNX installed on that platform. You can also contribute to DNX projects using your development platform and tools of choice.

**Build for .NET Core** DNX dramatically simplifies the work needed to develop cross-platform applications using .NET Core. It takes care of hosting the CLR, handling dependencies and bootstrapping your application. You can easily define projects and solutions using a lightweight JSON format (*project.json*), build your projects and publish them for distribution.

**Package ecosystem** Package managers have completely changed the face of modern software development and DNX makes it easy to create and consume packages. DNX provides tools for installing, creating and managing NuGet packages. DNX projects simplify building NuGet packages by cross-compiling for multiple target frameworks and can output NuGet packages directly. You can reference NuGet packages directly from your projects and transitive dependencies are handled for you. You can also build and install development tools as packages for your project and globally on a machine.

**Open source friendly** DNX makes it easy to work with open source projects. With DNX projects you can easily replace an existing dependency with its source code and let DNX compile it in-memory at runtime. You can then debug the source and modify it without having to modify the rest of your application.

.. _dnx-concept-projects:

Projects
--------

A DNX project is a folder with a *project.json* file. The name of the project is the folder name. You use DNX projects to build NuGet packages. The *project.json* file defines your package metadata, your project dependencies and which frameworks you want to build for:

.. literalinclude:: /../common/samples/ClassLibrary1/src/ClassLibrary1/project.json
  :linenos:
  :language: json

All the files in the folder are by default part of the project unless explicitly excluded in *project.json*.

You can also define commands as part of your project that can be executed (see :ref:`dnx-concept-commands`).

You specify which frameworks you want to build for under the "frameworks" property. DNX will cross-compile for each specified framework and create the corresponding lib folder in the built NuGet package.

You can use the .NET Development Utility (DNU) to build, package and publish DNX projects. Building a project produces the binary outputs for the project. Packaging produces a NuGet package that can be uploaded to a package feed (for example, http://nuget.org) and then consumed. Publishing collects all required runtime artifacts (the required DNX and packages) into a single folder so that it can be deployed as an application.

For more details on working with DNX projects see :doc:`/dnx/projects`.

.. _dnx-concept-dependencies:

Dependencies
-------------------

Dependencies in DNX consist of a name and a version number. Version numbers should follow `Semantic Versioning <http://semver.org>`_. Typically dependencies refer to an installed NuGet package or to another DNX project. Project references are resolved using peer folders to the current project or  project paths specified using a *global.json* file at the solution level:

.. literalinclude:: /../common/samples/ClassLibrary1/global.json
  :linenos:
  :language: json

The *global.json* file also defines the minimum DNX version ("sdk" version) needed to build the project.

Dependencies are transitive in that you only need to specify your top level dependencies. DNX will handle resolving the entire dependency graph for you using the installed NuGet packages. Project references are resolved at runtime by building the referenced project in memory. This means you have the full flexibility to deploy your DNX application as package binaries or as source code.

.. _dnx-concept-packages-and-feeds:

Packages and feeds
---------------------------

For package dependencies to resolve they must first be installed. You can use DNU to install a new package into an existing project or to restore all package dependencies for an existing project. The following command downloads and installs all packages that are listed in the *project.json* file::

    dnu restore

Packages are restored using the configured set of package feeds. You configure the available package feeds using `NuGet configuration files (NuGet.config) <http://docs.nuget.org/consume/nuget-config-file>`_.

.. _dnx-concept-commands:

Commands
--------

A command is a named execution of a .NET entry point with specific arguments. You can define commands in your *project.json* file:

.. literalinclude:: /../common/samples/WebApplication1/src/WebApplication1/project.json
  :linenos:
  :language: json
  :lines: 31-34
  :dedent: 2

You can then use DNX to execute the commands defined by your project, like this::

    dnx . web

Commands can  be built and distributed as NuGet packages. You can then use DNU to install commands globally on a machine::

    dnu commands install MyCommand

For more information on using and creating commands see :doc:`/dnx/commands`.

.. _dnx-concept-apphost:

Application Host
----------------

The DNX application host is typically the first managed entry point invoked by DNX and is responsible for handling dependency resolution, parsing *project.json*, providing additional services and invoking the application entry point.

Alternatively, you can have DNX invoke your application's entry point directly. Doing so requires that your application be fully built and all dependencies located in a single directory. Using DNX without using the DNX Application Host is not common.

The DNX application host provides a set of services to applications through dependency injection (for example, `IServiceProvider`, `IApplicationEnvironment` and `ILoggerFactory`). Application host services can be injected in the constructor of the class for your `Main` entry point or as additional method parameters to your `Main` entry point.

.. _dnx-concept-compile-modules:

Compile Modules
---------------

Compile modules are an extensibility point that let you participate in the DNX compilation process. You implement a compile module by implementing the `ICompileModule <https://github.com/aspnet/dnx/blob/dev/src/Microsoft.Framework.Runtime.Roslyn.Interfaces/ICompileModule.cs>`_ interface and putting your compile module in a compiler/preprocess or compiler/postprocess in your project.

DNX Version Manager
-------------------

You can install multiple DNX versions and flavors on your machine. To install and manage different DNX versions and flavors you use the .NET Version Manager (DNVM). DNVM lets you list the different DNX versions and flavors on your machine, install new ones and switch the active DNX.

See :doc:`/getting-started/index` for instructions on how to acquire and install DNVM for your platform.

