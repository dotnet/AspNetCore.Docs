---
uid: web-pages/overview/releases/whats-new-in-aspnet-web-pages-32
title: "What's New in ASP.NET Web Pages 3.2 | Microsoft Docs"
author: microsoft
description: ""
ms.author: aspnetcontent
manager: wpickett
ms.date: 06/30/2014
ms.topic: article
ms.assetid: a652beff-8e6b-48ad-bfe4-3703f7ccf0a5
ms.technology: dotnet-webpages
ms.prod: .net-framework
msc.legacyurl: /web-pages/overview/releases/whats-new-in-aspnet-web-pages-32
msc.type: authoredcontent
---
What's New in ASP.NET Web Pages 3.2
====================
by [Microsoft](https://github.com/microsoft)

This topic describes what's new for ASP.NET Web Pages 3.2, Web Pages 3.2.2 and [Web Pages 3.2.3 beta1](https://blogs.msdn.com/b/webdev/archive/2014/12/17/asp-net-mvc-5-2-3-web-pages-5-2-3-and-web-api-5-2-3-beta-releases.aspx)

## ASP.Net Web Pages 3.2

This release fixes a bug and introduces one new feature.

## Download

The runtime features are released as NuGet packages on the NuGet gallery. All the runtime packages follow the [Semantic Versioning](http://semver.org/) specification. The ASP.NET Web Pages 3.2 package has the following version: &ldquo;3.2.0&rdquo;. You can install or update these packages through [NuGet](http://www.nuget.org/packages/Microsoft.AspNet.WebPages/). The release also includes corresponding localized packages on NuGet.

You can install or update to the released NuGet packages by using the NuGet Package Manager Console:

[!code-console[Main](whats-new-in-aspnet-web-pages-32/samples/sample1.cmd)]

## New Feature and Bug Fix

We fixed one bug and made one minor feature enhancement in this release. You can find the query for the same [here](https://aspnetwebstack.codeplex.com/workitem/list/advanced?keyword=&amp;status=Closed&amp;type=All&amp;priority=All&amp;release=v5.2%20RC|v5.2%20RTM&amp;assignedTo=All&amp;component=Web%20Pages%2FRazor&amp;sortField=Id&amp;sortDirection=Descending&amp;page=0&amp;reasonClosed=Fixed).

## ASP.Net Web Pages 3.2.2

This release rolls-up the change in the [ASP.Net Web Pages 3.2.1 Beta release](https://blogs.msdn.com/b/webdev/archive/2014/07/28/announcing-the-beta-release-of-web-pages-3-2-1.aspx) which provides a significant performance improvement in rendering large razor pages. See[Codeplex Issue 585](https://aspnetwebstack.codeplex.com/workitem/585). This release aligns with the MVC 5.2.2 packages which will now depend on this version.

We worked with the MSN team on rendering large pages. When pages render over 80 Kilobytes of data, we end up with objects on the large object heap. When multiple layers of layouts are used this effect can be multiplied.

The result on the server is extra CPU usage, longer retention of memory, and even long pauses during [Gen 2 cleanup](https://msdn.microsoft.com/en-us/library/ms973837.aspx) in the garbage collector.

Below is a table demonstrating the results of analyzing a [perfview](https://channel9.msdn.com/Series/PerfView-Tutorial) for a run. The CPU is held constant at about 68%, while large pages are being rendered. The table shows that the number of Generation 2 collections has been almost completely eliminated, and the result is higher request rate and a considerable reduction in pauses due to garbage collection.

| **Area** | **Before (3.2)** | **After (3.2.1)** | **Delta %** |
| --- | --- | --- | --- |
| Total request (count) | 26,986 | 32,591 | <font style="background-color: #4bacc6">20.80%</font> |
| Trace duration (seconds) | 196.20 | 198.60 | 1.20% |
| Request/second | 137.53 | 164.10 | <font style="background-color: #4bacc6">19.30%</font> |
| CPU Load | 68.80% | 68.50% |  -0.40% |
| GC CPU Samples | 124,323 | 17,543 | <font style="background-color: #4bacc6">-85.90%</font> |
| Total allocations (count) | 55,357,146 | 57,222,949 | 3.40% |
| Total GC Pause (samples) | 15,091 | 8,515 | <font style="background-color: #4bacc6">-43.60%</font> |
| Gen0 GC (count) | 403 | 1,216 | 201.70% |
| Gen1 GC (count) | 290 | 367 | 26.60% |
| Gen2 GC (count) | 229 | 2 | <font style="background-color: #00ff00">-99.10%</font> |
| CPU / request (samples/req) | 19.73 | 16.47 | -16.50% |

| Color coding: | <font style="background-color: #00ff00">Core Improvement</font> | <font style="background-color: #4bacc6">Positive impact on performance</font> |
| --- | --- | --- |

## ASP.Net Web Pages 3.2.3 beta1

This release contains only bug fixes. You can use [this query](https://aspnetwebstack.codeplex.com/workitem/list/advanced?keyword=&amp;status=Closed&amp;type=All&amp;priority=All&amp;release=v5.2.3%20Beta&amp;assignedTo=All&amp;component=Web%20Pages%2FRazor&amp;sortField=LastUpdatedDate&amp;sortDirection=Descending&amp;page=0&amp;reasonClosed=Fixed) to see the list of issues fixed in this release.