.. _dotnet-watch:

Developing ASP.NET Core applications using dotnet watch
=======================================================

By `Victor Hurdugaci`_

Introduction
------------

``dotnet watch`` is a development time tool that runs a ``dotnet`` command when source files change. It can be used to compile, run tests, or publish when code changes.

In this tutorial we'll use an existing WebApi application that calculates the sum and product of two numbers to demonstrate the use cases of ``dotnet watch``. The sample application contains an intentional bug that we'll fix as part of this tutorial.

Getting started
---------------

Start by downloading `the sample application <https://github.com/aspnet/Docs/tree/master/aspnet/tutorials/dotnet-watch/sample>`__. It contains two projects, ``WebApp`` (a web application) and ``WebAppTests`` (unit tests for the web application)

In a console, open the folder where you downloaded the sample application and run:

1.  ``dotnet restore``
2.  ``cd WebApp``
3.  ``dotnet run``

The console output will show messages similar to the ones below, indicating that the application is now running and waiting for requests:

.. code-block:: bash

  $ dotnet run
  Project WebApp (.NETCoreApp,Version=v1.0) will be compiled because inputs were modified
  Compiling WebApp for .NETCoreApp,Version=v1.0

  Compilation succeeded.
    0 Warning(s)
    0 Error(s)

  Time elapsed 00:00:02.6049991

  Hosting environment: Production
  Content root path: /Users/user/dev/aspnet/Docs/aspnet/tutorials/dotnet-watch/sample/WebApp
  Now listening on: http://localhost:5000
  Application started. Press Ctrl+C to shut down.

In a web browser, navigate to ``http://localhost:5000/api/math/sum?a=4&b=5`` and you should see the result ``9``.

If you navigate to ``http://localhost:5000/api/math/product?a=4&b=5`` instead, you'd expect to get the result ``20``. Instead, you get ``9`` again.

We'll fix that.

Adding ``dotnet watch`` to a project
------------------------------------

1. Add ``Microsoft.DotNet.Watcher.Tools`` to the ``tools`` section of the *WebApp/project.json* file as in the example below:

.. literalinclude:: dotnet-watch/sample/WebAppTests/project.json
   :language: javascript
   :lines: 21-23
   :emphasize-lines: 2
   :dedent: 2

2. Run ``dotnet restore``.

The console output will show messages similar to the ones below:

.. code-block:: bash

  log  : Restoring packages for /Users/user/dev/aspnet/Docs/aspnet/tutorials/dotnet-watch/sample/WebApp/project.json...
  log  : Restoring packages for tool 'Microsoft.DotNet.Watcher.Tools' in /Users/user/dev/aspnet/Docs/aspnet/tutorials/dotnet-watch/sample/WebApp/project.json...
  log  : Installing Microsoft.DotNet.Watcher.Core 1.0.0-preview2-final.
  log  : Installing Microsoft.DotNet.Watcher.Tools 1.0.0-preview2-final.

Running ``dotnet`` commands using ``dotnet watch``
--------------------------------------------------

Any ``dotnet`` command can be run with  ``dotnet watch``:  For example:

========================================= ======================================
Command                                   Command with watch
========================================= ======================================
``dotnet run``                            ``dotnet watch run``
``dotnet run -f net451``                  ``dotnet watch run -f net451``
``dotnet run -f net451 -- --arg1``        ``dotnet watch run -f net451 -- --arg1``
``dotnet test``                           ``dotnet watch test``
========================================= ======================================

To run ``WebApp`` using the watcher, run ``dotnet watch run`` in the ``WebApp`` folder. The console output will show messages similar to the ones below, indicating that ``dotnet watch`` is now watching code files:

.. code-block:: bash

  user$ dotnet watch run
  [DotNetWatcher] info: Running dotnet with the following arguments: run
  [DotNetWatcher] info: dotnet process id: 39746
  Project WebApp (.NETCoreApp,Version=v1.0) was previously compiled. Skipping compilation.
  Hosting environment: Production
  Content root path: /Users/user/dev/aspnet/Docs/aspnet/tutorials/dotnet-watch/sample/WebApp
  Now listening on: http://localhost:5000
  Application started. Press Ctrl+C to shut down.

Making changes with ``dotnet watch``
------------------------------------

Make sure ``dotnet watch`` is running.

Let's fix the bug that we discovered when we tried to compute the product of two number.

Open *WebApp/Controllers/MathController.cs*.

We've intentionally introduced a bug in the code.

.. literalinclude:: dotnet-watch/sample/WebApp/Controllers/MathController.cs
   :language: c#
   :lines: 12-17
   :emphasize-lines: 5
   :dedent: 4

Fix the code by replacing ``a + b`` with ``a * b``.

Save the file. The console output will show messages similar to the ones below, indicating that ``dotnet watch`` detected a file change and restarted the application.


.. code-block:: bash

  [DotNetWatcher] info: File changed: /Users/user/dev/aspnet/Docs/aspnet/tutorials/dotnet-watch/sample/WebApp/Controllers/MathController.cs
  [DotNetWatcher] info: Running dotnet with the following arguments: run
  [DotNetWatcher] info: dotnet process id: 39940
  Project WebApp (.NETCoreApp,Version=v1.0) will be compiled because inputs were modified
  Compiling WebApp for .NETCoreApp,Version=v1.0
  Compilation succeeded.
    0 Warning(s)
    0 Error(s)
  Time elapsed 00:00:03.3312829

  Hosting environment: Production
  Content root path: /Users/user/dev/aspnet/Docs/aspnet/tutorials/dotnet-watch/sample/WebApp
  Now listening on: http://localhost:5000
  Application started. Press Ctrl+C to shut down.

Verify ``http://localhost:5000/api/math/product?a=4&b=5`` returns the correct result.

Running tests using ``dotnet watch``
------------------------------------

The file watcher can run other ``dotnet`` commands like ``test`` or ``publish``.

1. Open the ``WebAppTests`` folder that already has ``dotnet watch`` in *project.json*.
2. Run ``dotnet watch test``.

If you previously fixed the bug in the ``MathController`` then you'll see an output similar to the one below, otherwise you'll see a test failure:

.. code-block:: bash

  WebAppTests user$ dotnet watch test
  [DotNetWatcher] info: Running dotnet with the following arguments: test
  [DotNetWatcher] info: dotnet process id: 40193
  Project WebApp (.NETCoreApp,Version=v1.0) was previously compiled. Skipping compilation.
  Project WebAppTests (.NETCoreApp,Version=v1.0) was previously compiled. Skipping compilation.
  xUnit.net .NET CLI test runner (64-bit .NET Core osx.10.11-x64)
    Discovering: WebAppTests
    Discovered:  WebAppTests
    Starting:    WebAppTests
    Finished:    WebAppTests
  === TEST EXECUTION SUMMARY ===
     WebAppTests  Total: 2, Errors: 0, Failed: 0, Skipped: 0, Time: 0.259s
  SUMMARY: Total: 1 targets, Passed: 1, Failed: 0.
  [DotNetWatcher] info: dotnet exit code: 0
  [DotNetWatcher] info: Waiting for a file to change before restarting dotnet...

Once all the tests run, the watcher will indicate that it's waiting for a file to change before restarting ``dotnet test``.

3. Open the controller file in *WebApp/Controllers/MathController.cs* and change some code. If you haven't fixed the product bug, do it now. Save the file.

``dotnet watch`` will detect the file change and rerun the tests. The console output will show messages similar to the one below:

.. code-block:: bash

  [DotNetWatcher] info: File changed: /Users/user/dev/aspnet/Docs/aspnet/tutorials/dotnet-watch/sample/WebApp/Controllers/MathController.cs
  [DotNetWatcher] info: Running dotnet with the following arguments: test
  [DotNetWatcher] info: dotnet process id: 40233
  Project WebApp (.NETCoreApp,Version=v1.0) will be compiled because inputs were modified
  Compiling WebApp for .NETCoreApp,Version=v1.0
  Compilation succeeded.
    0 Warning(s)
    0 Error(s)
  Time elapsed 00:00:03.2127590
  Project WebAppTests (.NETCoreApp,Version=v1.0) will be compiled because dependencies changed
  Compiling WebAppTests for .NETCoreApp,Version=v1.0
  Compilation succeeded.
    0 Warning(s)
    0 Error(s)
  Time elapsed 00:00:02.1204052

  xUnit.net .NET CLI test runner (64-bit .NET Core osx.10.11-x64)
    Discovering: WebAppTests
    Discovered:  WebAppTests
    Starting:    WebAppTests
    Finished:    WebAppTests
  === TEST EXECUTION SUMMARY ===
     WebAppTests  Total: 2, Errors: 0, Failed: 0, Skipped: 0, Time: 0.260s
  SUMMARY: Total: 1 targets, Passed: 1, Failed: 0.
  [DotNetWatcher] info: dotnet exit code: 0
  [DotNetWatcher] info: Waiting for a file to change before restarting dotnet...