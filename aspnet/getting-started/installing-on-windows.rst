Installing ASP.NET 5 On Windows
===============================

By `Steve Smith`_, `Daniel Roth`_

This article describes how to install ASP.NET 5 on Windows, showing both standalone installation as well as installation with Visual Studio 2015. 

In this article:
  - `Install ASP.NET with Visual Studio`_
  - `Install ASP.NET Standalone`_

Install ASP.NET with Visual Studio
----------------------------------

The easiest way to get started building applications with ASP.NET 5 is to install the latest version of Visual Studio 2015 (including the freely available Community edition). Visual Studio is an Integrated Development Environment (IDE), which means it's not just an editor, but also has many of the tools you need to build applications, in this case ASP.NET 5 web applications. 

1. Install `Visual Studio 2015 <http://go.microsoft.com/fwlink/?LinkId=532606>`__
2. Install the latest `ASP.NET 5 preview (Beta7) <http://go.microsoft.com/fwlink/?LinkId=623894>`_

When installing Visual Studio 2015, you'll want to be sure to specify that you want to install the Microsoft Web Developer Tools.

.. image:: installing-on-windows/_static/web-dev-tools.png

Once Visual Studio is installed, follow the instructions on the Download Center page for installing the latest `ASP.NET 5 preview (Beta7)`_.

Install ASP.NET Standalone
--------------------------

Visual Studio isn't the only way to install ASP.NET, and installing an IDE may not be appropriate in some scenarios. You can also install ASP.NET on its own from a command prompt. There are a few steps involved, since we'll need to install and configure the environment in which ASP.NET runs, known as the .NET Execution Environment (DNX). To install DNX, we need one more tool, the .NET Version Manager (DNVM).

Install the .NET Version Manager (DNVM)
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

Use .NET Version Manager to install different versions of the .NET Execution Environment (DNX). 

To install DNVM open a command prompt and run the following::

    @powershell -NoProfile -ExecutionPolicy unrestricted -Command "&{$Branch='dev';iex ((new-object net.webclient).DownloadString('https://raw.githubusercontent.com/aspnet/Home/dev/dnvminstall.ps1'))}"

Once this step is complete you should be able to run ``dnvm`` and see some help text.

Install the .NET Execution Environment (DNX)
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

The .NET Execution Environment (DNX) is used to build and run .NET projects. Use DNVM to install DNX for the full .NET Framework or for .NET Core (see :doc:`choosing-the-right-dotnet`).

To install DNX for .NET Core run::

  dnvm upgrade -r coreclr

To install DNX for the full .NET Framework run::

  dnvm upgrade -r clr

By default DNVM will install DNX for the full .NET Framework if no runtime is specified.

Summary
-------

You can install ASP.NET 5 on Windows either as a standalone installation, or as part of Visual Studio 2015. In either case, installation is straightforward. You're now ready to build :doc:`your first ASP.NET application </tutorials/your-first-aspnet-application>`!

Related Resources
^^^^^^^^^^^^^^^^^

- :doc:`/tutorials/your-first-aspnet-application`
- :doc:`/fundamentals/index`

