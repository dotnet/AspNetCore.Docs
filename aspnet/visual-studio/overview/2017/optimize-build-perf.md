---
uid: visual-studio/overview/2017/optimize-build-perf
title: Optimize build performance for solution
author: tfitzmac
description: Optimize build performance for solution
ms.author: riande
ms.date: 08/22/2018
msc.type: authoredcontent
---

# Optimize build performance for solution
Visual Studio 2017 15.8 and later added a new menu item under **Build > ASP.NET Compilation > Optimize Build Performance for Solution**.

![screenshot of the new menu item](optimize-build-perf/_static/optimize-build-performance-for-solution.png)

ASP.NET compiles its views at runtime, which means your ASP.NET project carries with it a copy of the compiler. However, on a developer machine when the copy of the compiler doesn't match Visual Studio's copy, your build performance is impacted on the order of 1-3 seconds per incremental build. This feature will update your project's copy of the compiler to match Visual Studio's which should speed up incremental builds.

This is applicable to ASP.NET Framework projects only, it does not apply to ASP.NET Core.
