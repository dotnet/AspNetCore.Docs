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

* In Visual Studio 
 
* Un-check  **Enable Just  My Code**  in **Tools -> Options -> Debugging -> General**

![image](https://user-images.githubusercontent.com/3605364/31796868-22accaba-b4c7-11e7-8d8c-cb37ef5e8879.png)

* Verify **Enable Source Link support**  is checked.

![image](https://user-images.githubusercontent.com/3605364/31796932-691d53a2-b4c7-11e7-81f1-15ece80c67d0.png)

* Enable **Microsoft Symbol Servers** in **Tool -> Options -> Debugging -> Symbols**

![image](https://user-images.githubusercontent.com/3605364/31797007-b753bb92-b4c7-11e7-982e-530608d8aa04.png)

* See [The 'Suppress JIT optimization on module load' option](https://docs.microsoft.com/en-us/visualstudio/debugger/jit-optimization-and-debugging#the-suppress-jit-optimization-on-module-load-managed-only-option) to disable JIT optimization.
* See [Limitations of the 'Suppress JIT optimization' option](https://docs.microsoft.com/en-us/visualstudio/debugger/jit-optimization-and-debugging#limitations-of-the-suppress-jit-optimization-option) to set `COMPlus_ReadyToRun` to `0`
 
You can step into any ASP.NET Core code and Visual Studio will show you the source code.  For example:

* Set a break point in ` OnGet`  in *Pages\About.cshtml.cs *
* Double click on a line in the **Call Stack**.

![image](https://user-images.githubusercontent.com/3605364/31798032-38eb5a52-b4cd-11e7-9073-cb12414c860a.png)

If you step into CoreFX or CoreCLR code, you will be prompted to find the location of the source code (It has good PDBs, but not sourcelink information).  
 
Note that if you have debugged an app before with the previous version of .NET, you need to delete your `%TEMP%\SymbolCache` directory as it can have old PDBs that are out of date.

See dotnet/core#897 for more details.

See [JIT Optimization and Debugging](https://docs.microsoft.com/en-us/visualstudio/debugger/jit-optimization-and-debugging) for tips on dealing with the optimizations of ASP.NET Core.

## Additional resources

For more information, see the following resources in the Visual Studio documentation:

* <xref:test/hot-reload>
* [Test Execution with Hot Reload](/visualstudio/test/test-execution-with-hot-reload)
