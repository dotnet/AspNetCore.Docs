Installing ASP.NET 5 On Mac OS X
================================

By `Steve Smith`_, `Daniel Roth`_

ASP.NET 5 runs on the .NET Execution Environment (DNX), which is available on multiple platforms, including OS X. This article describes how to install DNX, and therefore ASP.NET 5, on OS X using .NET Core and Mono.

In this article:
  - `Install the .NET Version Manager (DNVM)`_
  - `Install the .NET Execution Environment (DNX)`_

Install the .NET Version Manager (DNVM)
---------------------------------------

Use the .NET Version Manager (DNVM) to install different versions of the .NET Execution Environment (DNX) on OS X.

To install DNVM run the following::

    curl -sSL https://raw.githubusercontent.com/aspnet/Home/dev/dnvminstall.sh | DNX_BRANCH=dev sh && source ~/.dnx/dnvm/dnvm.sh
    
Once this step is complete you should be able to run ``dnvm`` and see some help text.

Install the .NET Execution Environment (DNX)
--------------------------------------------

The .NET Execution Environment (DNX) is used to build and run .NET projects. Use DNVM to install DNX for `Mono <http://mono-project.com>`_ or .NET Core (see :doc:`choosing-the-right-dotnet`).

**To install DNX for .NET Core:**

1. Install the DNX prerequisites using `Homebrew <http://brew.sh/>`__::

    brew update
    brew install icu4c

2. Use DNVM to install DNX for .NET Core::

    dnvm upgrade -r coreclr

.. note:: .NET Core on OS X is still in early preview. Please refer to the latest `Release Notes <https://github.com/aspnet/home/releases>`__ for known issues and limitations.

**To install DNX for Mono:**

1. Install `Mono <http://www.mono-project.com/docs/getting-started/install/mac/>`__ for OS X. Alternatively you can install Mono via `Homebrew <http://brew.sh/>`__.

2. Use DNVM to install DNX for Mono::

    dnvm upgrade -r mono

By default DNVM will install DNX for Mono if no runtime is specified.

.. note:: Restoring packages using DNX on Mono may fail with multiple canceled requests. You may be able to work around this issue by setting ``MONO_THREADS_PER_CPU`` to a larger number (ex. 2000).

Summary
-------

ASP.NET 5 is built on the cross-platform .NET Execution Environment (DNX), which can be installed on OS X as well as :doc:`Linux <installing-on-linux>` and :doc:`Windows <installing-on-windows>`. Installing DNX and ASP.NET 5 on OS X takes just a few minutes, using a few simple commands. You're now  ready to build :doc:`your first ASP.NET application </tutorials/your-first-mac-aspnet>`!

Related Resources
-----------------

- :doc:`/tutorials/your-first-mac-aspnet`
- :doc:`/fundamentals/index`
