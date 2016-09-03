:version: 1.0.0

File Providers
==============

By `Steve Smith`_

ASP.NET Core abstracts file system access through the use of File Providers.

.. contents:: Sections:
  :local:
  :depth: 1

File Provider Abstractions
--------------------------

File Providers are an abstraction over file systems. The main interface is :dn:iface:`~Microsoft.Extensions.FileProviders.IFileProvider`. ``IFileProvider`` exposes methods to get file information (:dn:iface:`~Microsoft.Extensions.FileProviders.IFileInfo`), directory information (:dn:iface:`~Microsoft.Extensions.FileProviders.IDirectoryContents`), and to set up change notifications (using an :dn:iface:`~Microsoft.Extensions.FileProviders.IChangeToken`). These types wrap the ``System.IO.File`` type, but also scope all paths to a directory and its children.

File Provider Implementations
-----------------------------

Physical

Embedded (for assembly resources)

Composite (aggregates over multiple providers)

.. note:: Some file systems, such as Docker containers and network chares, may not reliably send change notifications. Set the ``DOTNET_USE_POLLINGFILEWATCHER`` environment variable to ``1`` or ``true`` to poll the file system for changes every 4 seconds.

Globbing Patterns
-----------------

File system paths use wilcard patterns called *globbing patterns*. These simple patterns can be used to specify groups of files. The two wildcard characters are ``*`` and ``**``.

``*``
    Matches anything at the current folder level, or any filename, or any file extension. Matches are terminated by ``/`` and ``.`` characters in the file path.

``**``
    Matches anything across multiple directory levels. Can be used to recursively match many files within a directory hierarchy.

Globbing Pattern Examples
^^^^^^^^^^^^^^^^^^^^^^^^^

``directory/file.txt``
    Matches a specific file in a specific directory.

``directory/*.txt``
    Matches all files with ``.txt`` extension in a specific directory.

``directory/**/*.txt``
    Matches all files with ``.txt`` extension found anywhere under the ``directory`` directory.

File Provider Usage
-------------------

Several parts of ASP.NET Core utilize file providers. IHostingEnvironment exposes the app's content root and web root as ``IFileProvider`` types. The static files middleware uses file providers to locate static files. Razor makes heavy use of ``IFileProvider`` in locating views. Dotnet's publish functionality uses file providers and globbing patterns to specify which files should be published.

If your ASP.NET Core app requires file system access, you can request an instance of ``IFileProvider`` through dependency injection, and then use its methods to perform the access. Following this convention will produce a more loosely-coupled, testable app than working directly with concrete file system implementation types.

