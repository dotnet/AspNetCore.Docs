Installing ASP.NET 5 On Mac OS X
================================

By `Steve Smith`_

ASP.NET 5 runs on the .NET Execution Environment (DNX), which is available on multiple platforms, including OS X. This article describes how to install DNX, and therefore ASP.NET 5, on OS X using .NET Core and Mono.

In this article:
	- `Install the .NET Version Manager (DNVM)`_
	- `Install the .NET Execution Environment (DNX)`_
	- `Add NuGet sources`_

Install the .NET Version Manager (DNVM)
---------------------------------------

Use the .NET Version Manager (DNVM) to install different versions of the .NET Execution Environment (DNX) on OS X.

To install DNVM run the following::

    curl -sSL https://raw.githubusercontent.com/aspnet/Home/dev/dnvminstall.sh | DNX_BRANCH=dev sh && source ~/.dnx/dnvm/dnvm.sh
    
Once this step is complete you should be able to run ``dnvm`` and see some help text.

Install the .NET Execution Environment (DNX)
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

The .NET Execution Environment (DNX) is used to build and run .NET projects. Use DNVM to install a DNX for `Mono <http://mono-project.com>`_ or .NET Core (see :doc:`choosing-the-right-dotnet`).

To install DNX for .NET Core run::

    dnvm upgrade -r coreclr

.. note:: .NET Core on OS X is still in early preview. Please refer to the latest `Release Notes <https://github.com/aspnet/home/releases>`__ for known issues and limitations.

To install DNX for Mono run::

    dnvm upgrade -r mono

By default DNVM will install a DNX for Mono if no runtime is specified.

.. note:: To use DNX on Mono you must first `install Mono <http://www.mono-project.com/docs/getting-started/install/mac/>`__ for OS X. Alternatively you can install Mono via `Homebrew <http://brew.sh/>`__.

.. note:: Restoring packages using DNX on Mono may fail with multiple canceled requests. You may be able to work around this issue by setting ``MONO_THREADS_PER_CPU`` to a larger number (ex. 2000).

Add NuGet sources
^^^^^^^^^^^^^^^^^

Now that we have installed DNX and the other tools needed to run an ASP.NET 5 application you can configure additional NuGet package sources to get access to the dev builds of all the ASP.NET 5 packages.

The dev package source is: `https://www.myget.org/F/aspnetvnext/api/v2/`

You specify your package sources through your NuGet.Config file.

Edit: ``~/.config/NuGet/NuGet.Config``

The NuGet.Config file should look something like the following

.. code-block:: xml

    <?xml version="1.0" encoding="utf-8"?>
    <configuration>
      <packageSources>
        <add key="AspNetVNext" value="https://www.myget.org/F/aspnetvnext/api/v2/" />
        <add key="nuget.org" value="https://www.nuget.org/api/v2/" />
      </packageSources>
      <disabledPackageSources />
    </configuration>

You should now be able to restore packages from both the official public feed on https://nuget.org and also from the ASP.NET 5 dev builds.


Summary
-------

ASP.NET 5 is built on the cross-platform .NET Execution Environment (DNX), which can be installed on OS X as well as :doc:`Linux <installing-on-linux>` and :doc:`Windows <installing-on-windows>`. Installing DNX and ASP.NET 5 on OS X takes just a few minutes, using a few simple commands. 

Related Resources
-----------------

- :doc:`/tutorials/your-first-mac-aspnet`

