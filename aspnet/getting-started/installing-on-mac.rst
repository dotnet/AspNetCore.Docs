Installing ASP.NET 5 On Mac OS X
================================

By `Daniel Roth`_, `Steve Smith`_, `Rick Anderson`_

.. contents:: Sections:
  :local:
  :depth: 1

Install ASP.NET 5 with Visual Studio Code
-----------------------------------------

The easiest way to get started building applications with ASP.NET 5 is to install the latest version of Visual Studio Code.

#. Install `Mono <http://www.mono-project.com/docs/getting-started/install/mac/>`__ for OS X (required by Visual Studio Code). 
  
#. Install `Visual Studio Code <https://go.microsoft.com/fwlink/?LinkID=534106>`__

#. Install `ASP.NET 5 for Mac OS X <https://go.microsoft.com/fwlink/?LinkId=703940>`__
  
You are all set up and ready to write :doc:`your first ASP.NET 5 application on a Mac </tutorials/your-first-mac-aspnet>`!

Install ASP.NET 5 from the command-line
---------------------------------------

You can also install ASP.NET 5 from the command-line. There are a few steps involved, since we'll need to install and configure the environment in which ASP.NET runs, the :doc:`/dnx/index`. To install DNX, we need one more tool, the .NET Version Manager (DNVM).

Install the .NET Version Manager (DNVM)
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

To install DNVM:

.. This is only necessary if you don't already have a bash profile and the install script will tell you to do this if you need to.
.. #. Open a Terminal.
.. #. Type ``cd ~/`` to go to your home folder.
.. #. Enter ``touch .bash_profile`` to create a new bash profile.


#. Run the following ``curl`` command::

    curl -sSL https://raw.githubusercontent.com/aspnet/Home/dev/dnvminstall.sh | DNX_BRANCH=dev sh && source ~/.dnx/dnvm/dnvm.sh

#. Run ``dnvm list`` to show the DNX versions installed

#. Run ``dnvm`` to get DNVM help

The .NET Version Manager (DNVM) is used to install different versions of the .NET Execution Environment (DNX) on OS X.

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

.. note:: Restoring packages using DNX on Mono may fail with multiple canceled requests. You may be able to work around this issue by setting ``MONO_THREADS_PER_CPU`` to a larger number (2000).

Related Resources
-----------------

- :doc:`/tutorials/your-first-mac-aspnet`
- :doc:`/fundamentals/index`
