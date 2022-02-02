---
title: Debug .NET and ASP.NET Core source code
author: rick-anderson
description: Debug .NET and ASP.NET Core source code
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 2/5/2022
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: test/debug-aspnetcore-source
---
# Debug .NET and ASP.NET Core source code

To debug .NET and ASP.NET Core source code in Visual Studio:

* In **Tools -> Options -> Debugging -> General**, un-check  **Enable Just My Code**.

![Enable Just My Code](~/test/debug-aspnetcore-source/image/justMyCode.png)

* Verify **Enable Source Link support**  is checked.

![Enable Source Link support](~/test/debug-aspnetcore-source/image/sourceLinkSupport.png)

* In **Tool -> Options -> Debugging -> Symbols**, enable **Microsoft Symbol Servers**.

![Microsoft Symbol Server](~/test/debug-aspnetcore-source/image/ms_symbol_servers.png)

* See [The 'Suppress JIT optimization on module load' option](/visualstudio/debugger/jit-optimization-and-debugging#the-suppress-jit-optimization-on-module-load-managed-only-option) to disable JIT optimization.
* See [Limitations of the 'Suppress JIT optimization' option](/visualstudio/debugger/jit-optimization-and-debugging#limitations-of-the-suppress-jit-optimization-option) to set `COMPlus_ReadyToRun` to `0`

When you step into any .NET or ASP.NET Core code, Visual Studio displays the source code.  For example:

* Set a break point in `OnGet` in *Pages/Privacy.cshtml.cs* and select the **Privacy** link.
* Select one of the **Download Source and Continue Debugging** options.

![Step into source](https://user-images.githubusercontent.com/3605364/31798032-38eb5a52-b4cd-11e7-9073-cb12414c860a.png)

The preceding instructions works for basic stepping into functions, but the optimized .NET code often removes local variable and functions. To disable optimizations and allow better source debugging:

* In **Tools -> Options -> Debugging -> General**, enable **Suppress JIT optimization on module load (Managed only)**:
  ![Enable Just My Code](~/test/debug-aspnetcore-source/image/supressJIT.png)
* Add `COMPlus_ReadyToRun=0` to the *Properties/launchSettings.json* file:
  [!code-json[](~/test/debug-aspnetcore-source/code/launchSettings.json?highlight=18,26)]

If you have debugged an app before with the previous version of .NET, delete the `%TEMP%/SymbolCache` directory as it can have old PDBs that are out of date.

## Additional resources

* [JIT Optimization and Debugging](/visualstudio/debugger/jit-optimization-and-debugging)
* <xref:test/hot-reload>
* [Test Execution with Hot Reload](/visualstudio/test/test-execution-with-hot-reload)
