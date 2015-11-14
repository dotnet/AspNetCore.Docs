Installing ASP.NET 5 On Mac OS X
================================

By `Steve Smith`_, `Daniel Roth`_

.. contents:: In this article
  :local:
  :depth: 1

Install ASP.NET 5 with Visual Studio Code
-----------------------------------------

The easiest way to get started building applications with ASP.NET 5 is to install the latest version of Visual Studio Code.

1. Install `Visual Studio Code <https://go.microsoft.com/fwlink/?LinkID=534107>`__

2. Install `ASP.NET 5 for Mac OS X <http://go.microsoft.com/fwlink/?LinkId=703940>`__
  
You are all set up and ready to write :doc:`your first ASP.NET 5 application on a Mac </tutorials/your-first-mac-aspnet>`!

Install ASP.NET 5 from the command-line
---------------------------------------

You can also install ASP.NET 5 from the command-line. There are a few steps involved, since we'll need to install and configure the environment in which ASP.NET runs, the :doc:`/dnx/index`. To install DNX, we need one more tool, the .NET Version Manager (DNVM).

Install the .NET Version Manager (DNVM)
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

Use the .NET Version Manager (DNVM) to install different versions of the .NET Execution Environment (DNX) on OS X.

To install DNVM run the following::

  curl -sSL https://raw.githubusercontent.com/aspnet/Home/dev/dnvminstall.sh | DNX_BRANCH=dev sh && source ~/.dnx/dnvm/dnvm.sh

Once this step is complete you should be able to run ``dnvm`` and see some help text.

Install the .NET Execution Environment (DNX)
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

The .NET Execution Environment (DNX) is used to build and run .NET projects. Use DNVM to install DNX for `Mono <http://mono-project.com>`_ or .NET Core (see :doc:`choosing-the-right-dotnet`).

**To install DNX for .NET Core:**

1. Use DNVM to install DNX for .NET Core::

    dnvm upgrade -r coreclr

**To install DNX for Mono:**

1. Install `Mono <http://www.mono-project.com/docs/getting-started/install/mac/>`__ for OS X. Alternatively you can install Mono via `Homebrew <http://brew.sh/>`__.

2. Use DNVM to install DNX for Mono::

    dnvm upgrade -r mono

By default DNVM will install DNX for Mono if no runtime is specified.

.. note:: Restoring packages using DNX on Mono may fail with multiple canceled requests. You may be able to work around this issue by setting ``MONO_THREADS_PER_CPU`` to a larger number (ex. 2000).

Related Resources
-----------------

- :doc:`/tutorials/your-first-mac-aspnet`
- :doc:`/fundamentals/index`
