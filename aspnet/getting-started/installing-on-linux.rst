Installing ASP.NET 5 On Linux
=============================

By `Daniel Roth`_

ASP.NET 5 runs on the .NET Execution Environment (DNX), which is available on multiple platforms, including Linux. This article describes how to install DNX, and therefore ASP.NET 5, on Linux using .NET Core and Mono.

In this article:
  - `Installing on Debian, Ubuntu and derivatives`_
  - `Installing on CentOS, Fedora and derivatives`_
  - `Using Docker`_

Installing on Debian, Ubuntu and derivatives
--------------------------------------------

The following instructions were tested using Ubuntu 14.04.

Install the .NET Version Manager (DNVM)
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

Use the .NET Version Manager (DNVM) to install different versions of the .NET Execution Environment (DNX) on Linux.

1. Install ``unzip`` and ``curl`` if you don't already have them::

    sudo apt-get install unzip curl

2. Download and install DNVM::

    curl -sSL https://raw.githubusercontent.com/aspnet/Home/dev/dnvminstall.sh | DNX_BRANCH=dev sh && source ~/.dnx/dnvm/dnvm.sh
    
Once this step is complete you should be able to run ``dnvm`` and see some help text.

Install the .NET Execution Environment (DNX)
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

The .NET Execution Environment (DNX) is used to build and run .NET projects. Use DNVM to install DNX for `Mono <http://mono-project.com>`_ or .NET Core (see :doc:`choosing-the-right-dotnet`).

**To install DNX for .NET Core:**

1. Install the DNX prerequisites::

    sudo apt-get install libunwind8 gettext libssl-dev libcurl3-dev zlib1g libicu-dev

2. Use DNVM to install DNX for .NET Core::

    dnvm upgrade -r coreclr

.. note:: .NET Core on Linux is still in early preview. Please refer to the latest `Release Notes <https://github.com/aspnet/home/releases>`__ for known issues and limitations.

**To install DNX for Mono:**

1. Install `Mono <http://www.mono-project.com/docs/getting-started/install/linux/#debian-ubuntu-and-derivatives>`__ via the ``mono-complete`` package.

2. Ensure that the ``ca-certificates-mono`` package is also installed as `noted <http://www.mono-project.com/docs/getting-started/install/linux/#notes>`__ in the Mono installation instructions.

3. Use DNVM to install DNX for Mono::

    dnvm upgrade -r mono

By default DNVM will install DNX for Mono if no runtime is specified.

.. note:: Restoring packages using DNX on Mono may fail with multiple canceled requests. You may be able to work around this issue by setting ``MONO_THREADS_PER_CPU`` to a larger number (ex. 2000).

Install libuv
^^^^^^^^^^^^^

`Libuv <https://github.com/libuv/libuv>`_ is a multi-platform asynchronous IO library that is used by :ref:`kestrel`, a cross-platform HTTP server for hosting ASP.NET 5 web applications.

To build libuv you should do the following::

    sudo apt-get install make automake libtool curl
    curl -sSL https://github.com/libuv/libuv/archive/v1.4.2.tar.gz | sudo tar zxfv - -C /usr/local/src
    cd /usr/local/src/libuv-1.4.2
    sudo sh autogen.sh
    sudo ./configure
    sudo make 
    sudo make install
    sudo rm -rf /usr/local/src/libuv-1.4.2 && cd ~/
    sudo ldconfig

.. note::

    ``make install`` puts ``libuv.so.1`` in ``/usr/local/lib``, in the above commands ```ldconfig`` is used to update ``ld.so.cache`` so that ``dlopen`` (see ``man dlopen``) can load it. If you are getting libuv some other way or not running ``make install`` then you need to ensure that dlopen is capable of loading ``libuv.so.1``.

Installing on CentOS, Fedora and derivatives
--------------------------------------------

The following instructions were tested using CentOS 7.

Install the .NET Version Manager (DNVM)
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

Use the .NET Version Manager (DNVM) to install different versions of the .NET Execution Environment (DNX) on Linux.

1. Install ``unzip`` if you don't already have it::

    sudo yum install unzip

2. Download and install DNVM::

    curl -sSL https://raw.githubusercontent.com/aspnet/Home/dev/dnvminstall.sh | DNX_BRANCH=dev sh && source ~/.dnx/dnvm/dnvm.sh

Once this step is complete you should be able to run ``dnvm`` and see some help text.

Install the .NET Execution Environment (DNX)
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

The .NET Execution Environment (DNX) is used to build and run .NET projects. Use DNVM to install DNX for `Mono <http://mono-project.com>`_ (see :doc:`choosing-the-right-dotnet`).

.. note:: DNX support for .NET Core is not available for CentOS, Fedora and derivative in this release, but will be enabled in a future release.

**To install DNX for Mono:**

1. Install `Mono <http://www.mono-project.com/docs/getting-started/install/linux/#centos-fedora-and-derivatives>`__ via the ``mono-complete`` package.

2. Ensure that the ``ca-certificates-mono`` package is also installed as `noted <http://www.mono-project.com/docs/getting-started/install/linux/#notes>`__ in the Mono installation instructions.

3. Use DNVM to install DNX for Mono::

    dnvm upgrade -r mono

By default DNVM will install DNX for Mono if no runtime is specified.

.. note:: Restoring packages using DNX on Mono may fail with multiple canceled requests. You may be able to work around this issue by setting ``MONO_THREADS_PER_CPU`` to a larger number (ex. 2000).

Install Libuv
^^^^^^^^^^^^^

`Libuv <https://github.com/libuv/libuv>`_ is a multi-platform asynchronous IO library that is used by :ref:`kestrel`, a cross-platform HTTP server for hosting ASP.NET 5 web applications.

To build libuv you should do the following::

    sudo yum install automake libtool wget
    wget http://dist.libuv.org/dist/v1.4.2/libuv-v1.4.2.tar.gz
    tar -zxf libuv-v1.4.2.tar.gz
    cd libuv-v1.4.2
    sudo sh autogen.sh
    sudo ./configure
    sudo make
    sudo make check
    sudo make install
    ln -s /usr/lib64/libdl.so.2 /usr/lib64/libdl
    ln -s /usr/local/lib/libuv.so /usr/lib64/libuv.so.1

Using Docker
------------

The following instructions were tested with Docker 1.8.3 and Ubuntu 14.04.

Install Docker
^^^^^^^^^^^^^^

Instructions on how to install Docker can be found in the `Docker Documentation <https://docs.docker.com/installation/>`_.

Create a Container
^^^^^^^^^^^^^^^^^^

Inside your application folder, you create a ``Dockerfile`` which should looks something like this::

    # Base of your container
    FROM microsoft/aspnet:latest

    # Copy the project into folder and then restore packages
    COPY . /app
    WORKDIR /app
    RUN ["dnu","restore"]

    # Open this port in the container
    EXPOSE 5000
    # Start application
    ENTRYPOINT ["dnx","-p","project.json", "web"]

You also have a choice to use CoreCLR or Mono. At this time the ``microsoft/aspnet:latest`` repository is based on Mono. You can use the `Microsoft Docker Hub <https://hub.docker.com/r/microsoft/aspnet/>`_ to pick a different base running either an older version or CoreCLR.

Run a Container
^^^^^^^^^^^^^^^

When you have an application, you can build and run your container using the following commands::

    docker build -t yourapplication .
    docker run -t -d -p 8080:5000 yourapplication

Summary
-------

ASP.NET 5 is built on the cross-platform .NET Execution Environment (DNX), which can be installed on Linux as well as :doc:`Mac <installing-on-mac>` and :doc:`Windows <installing-on-windows>`. Installing DNX and ASP.NET 5 on Linux takes just a few minutes, using a few simple commands. You're now  ready to build :doc:`your first ASP.NET application </tutorials/your-first-mac-aspnet>`!

Related Resources
-----------------

- :doc:`/tutorials/your-first-mac-aspnet`
- :doc:`/fundamentals/index`
