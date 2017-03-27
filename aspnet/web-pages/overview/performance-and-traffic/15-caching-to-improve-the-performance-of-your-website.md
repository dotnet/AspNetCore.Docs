---
uid: web-pages/overview/performance-and-traffic/15-caching-to-improve-the-performance-of-your-website
title: "Caching Data in an ASP.NET Web Pages (Razor) Site for Better Performance | Microsoft Docs"
author: tfitzmac
description: "You can speed up your website by having it store - that is, cache - the results of data that ordinarily would take considerable time to retrieve or process a..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 02/14/2014
ms.topic: article
ms.assetid: 961e525b-7700-469e-8a68-d7010b6fb68c
ms.technology: dotnet-webpages
ms.prod: .net-framework
msc.legacyurl: /web-pages/overview/performance-and-traffic/15-caching-to-improve-the-performance-of-your-website
msc.type: authoredcontent
---
Caching Data in an ASP.NET Web Pages (Razor) Site for Better Performance
====================
by [Tom FitzMacken](https://github.com/tfitzmac)

> This article explains how to use a helper to cache information for faster performance in an ASP.NET Web Pages (Razor) website. You can speed up your website by having it store &#8212; that is, cache &#8212; the results of data that ordinarily would take considerable time to retrieve or process and that does not change often.
> 
> **What you'll learn:** 
> 
> - How to use caching to improve the responsiveness of your website.
> 
> These are the ASP.NET features introduced in the article:
> 
> - The `WebCache` helper.
>   
> 
> ## Software versions used in the tutorial
> 
> 
> - ASP.NET Web Pages (Razor) 3
>   
> 
> This tutorial also works with ASP.NET Web Pages 2.


Every time someone requests a page from your site, the web server has to do some work in order to fulfill the request. For some of your pages, the server might have to perform tasks that take a (comparatively) long time, such as retrieving data from a database. Even if these tasks don't take long in absolute terms, if your site experiences a lot of traffic, a whole series of individual requests that cause the web server to perform the complicated or slow task can add up to a lot of work. This can ultimately affect the performance of the site.

One way to improve the performance of your website in circumstances like this is to cache data. If your site gets repeated requests for the same information, and the information does not need to be modified for each person, and it's not time sensitive, instead of re-fetching or recalculating it, you can fetch the data once and then store the results. The next time a request comes in for that information, you just get it out of the cache.

In general, you cache information that doesn't change frequently. When you put information in the cache, it's stored in memory on the web server. You can specify how long it should be cached, from seconds to days. When the caching period expires, the information is automatically removed from the cache.

> [!NOTE]
> Entries in the cache might be removed for reasons other than that they've expired. For example, the web server might temporarily run low on memory, and one way it can reclaim memory is by throwing entries out of the cache. As you'll see, even if you've put information into the cache, you have to check to be sure it's still there when you need it.


Imagine your website has a page that displays the current temperature and weather forecast. To get this type of information, you might send a request to an external service. Since this information doesn't change much (within a two-hour time period, for example) and since external calls require time and bandwidth, it's a good candidate for caching.

## Adding Caching to a Page

ASP.NET includes a `WebCache` helper that makes it easy to add caching to your site and add data to the cache. In this procedure, you'll create a page that caches the current time. This isn't a real-world example, since the current time is something that does change often, and that moreover isn't complex to calculate. However, it's a good way to illustrate caching in action.

1. Add a new page named *WebCache.cshtml* to the website.
2. Add the following code and markup to the page:

    [!code-cshtml[Main](15-caching-to-improve-the-performance-of-your-website/samples/sample1.cshtml)]

    When you cache data, you put it into the cache using a name this is unique across the website. In this case, you'll use a cache entry named `CachedTime`. This is the `cacheItemKey` shown in the code example.

    The code first reads the `CachedTime` cache entry. If a value is returned (that is, if the cache entry isn't null), the code just sets the value of the time variable to the cache data.

    However, if the cache entry doesn't exist (that is, it's null), the code sets the time value, adds it to the cache, and sets an expiration value to one minute. After one minute, the cache entry is discarded. (The default expiration value for an item in the cache is 20 minutes.) The command `WebCache.Set(cacheItemKey, time, 1, false)` shows how to add the current time value to the cache and set its expiration to 1 minute. Setting the *slidingExpiration* parameter to `false` means the expiration time is not renewed each time it is requested. It will expire exactly 1 minute after it was originally added to the cache. If you set this value to `true` the 1 minute expiration time is reset each time the value is requested from the cache.

    This code illustrates the pattern you should always use when you cache data. Before you get something out of the cache, always check first whether the `WebCache.Get` method has returned null. Remember that the cache entry might have expired or might have been removed for some other reason, so any given entry is never guaranteed to be in the cache.
3. Run *WebCache.cshtml* in a browser. (Make sure the page is selected in the **Files** workspace before you run it.) The first time you request the page, the time data isn't in the cache, and the code has to add the time value to the cache.

    ![cache-1](15-caching-to-improve-the-performance-of-your-website/_static/image1.jpg)
4. Refresh *WebCache.cshtml* in the browser. This time, the time data is in the cache. Notice that the time hasn't changed since the last time you viewed the page.

    ![cache-2](15-caching-to-improve-the-performance-of-your-website/_static/image2.jpg)
5. Wait one minute for the cache to be emptied, and then refresh the page. The page again indicates that the time data wasn't found in the cache, and the updated time is added to the cache.

<a id="Additional_Resources"></a>
## Additional Resources


- [Displaying Data in a Chart](https://go.microsoft.com/fwlink/?LinkId=202895)
- [WebCache API reference](https://msdn.microsoft.com/en-us/library/system.web.helpers.webcache(v=vs.99).aspx) (MSDN)