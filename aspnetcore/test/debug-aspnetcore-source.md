---
title: Debug .NET and ASP.NET Core source code with Visual Studio
author: rick-anderson
description: Debug .NET and ASP.NET Core source code with Visual Studio
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 3/5/2022
uid: test/debug-aspnetcore-source
---
# Debug .NET and ASP.NET Core source code with Visual Studio

To debug .NET and ASP.NET Core source code in Visual Studio:

* In **Tools -> Options -> Debugging -> General**, un-check  **Enable Just My Code**.

  ![Enable Just My Code](~/test/debug-aspnetcore-source/image/justMyCode.png)

* Verify **Enable Source Link support**  is checked.

  ![Enable Source Link support](~/test/debug-aspnetcore-source/image/sourceLinkSupport.png)

* In **Tool -> Options -> Debugging -> Symbols**, enable **Microsoft Symbol Servers**.

  ![Microsoft Symbol Server](~/test/debug-aspnetcore-source/image/ms_symbol_servers.png)

When you step into any .NET or ASP.NET Core code, Visual Studio displays the source code.  For example:

* Set a break point in `OnGet` in `Pages/Privacy.cshtml.cs` and select the **Privacy** link.
* Select one of the **Download Source and Continue Debugging** options.

  ![Source Link Will Download](~/test/debug-aspnetcore-source/image/download.png)

The preceding instructions work for basic stepping into functions, but the optimized .NET code often removes local variables and functions. To disable optimizations and allow better source debugging:

* In **Tools -> Options -> Debugging -> General**, enable **Suppress JIT optimization on module load (Managed only)**:
  ![Suppress JIT optimization on module load](~/test/debug-aspnetcore-source/image/supressJIT.png)
* Add the environment variable and value `COMPlus_ReadyToRun=0` to the `Properties/launchSettings.json` file:
  [!code-json[](~/test/debug-aspnetcore-source/code/launchSettings.json?highlight=18,26)]

If you have debugged an app before with the previous version of .NET, delete the `%TEMP%/SymbolCache` directory as it can have old PDBs that are out of date.

## Debugging .NET Core on Unix over SSH

* [Debugging .NET Core on Unix over SSH](https://devblogs.microsoft.com/devops/debugging-net-core-on-unix-over-ssh/)
* [Debugging ASP Core on Linux with Visual Studio 2017](https://devblogs.microsoft.com/premier-developer/debugging-asp-core-on-linux-with-visual-studio-2017/)

## Additional resources

* [JIT Optimization and Debugging](/visualstudio/debugger/jit-optimization-and-debugging)
* [Limitations of the 'Suppress JIT optimization' option](/visualstudio/debugger/jit-optimization-and-debugging#limitations-of-the-suppress-jit-optimization-option) To set `COMPlus_ReadyToRun` to `0`
* <xref:test/hot-reload>
* [Test Execution with Hot Reload](/visualstudio/test/test-execution-with-hot-reload)
