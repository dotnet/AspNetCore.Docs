---
uid: web-pages/overview/routing/creating-readable-urls-in-aspnet-web-pages-sites
title: "Creating Readable URLs in ASP.NET Web Pages (Razor) Sites | Microsoft Docs"
author: tfitzmac
description: "This article describes routing in an ASP.NET Web Pages (Razor) website, and how this lets you use URLs that are more readable and better for SEO. What you'll..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 02/17/2014
ms.topic: article
ms.assetid: a8aac1ac-89de-4415-afe0-97a41c6423d2
ms.technology: dotnet-webpages
ms.prod: .net-framework
msc.legacyurl: /web-pages/overview/routing/creating-readable-urls-in-aspnet-web-pages-sites
msc.type: authoredcontent
---
Creating Readable URLs in ASP.NET Web Pages (Razor) Sites
====================
by [Tom FitzMacken](https://github.com/tfitzmac)

> This article describes routing in an ASP.NET Web Pages (Razor) website, and how this lets you use URLs that are more readable and better for SEO.
> 
> What you'll learn:
> 
> - How ASP.NET uses routing to let you use more readable and searchable URLs.
>   
> 
> ## Software versions used in the tutorial
> 
> 
> - ASP.NET Web Pages (Razor) 3
>   
> 
> This tutorial also works with ASP.NET Web Pages 2.


## About Routing

The URLs for the pages in your site can have an impact on how well the site works. A URL that's &quot;friendly&quot; can make it easier for people to use the site. It can also help with search-engine optimization (SEO) for the site. ASP.NET websites include the ability to use friendly URLs automatically.

ASP.NET lets you create meaningful URLs that describe user actions instead of just pointing to a file on the server. Consider these URLs for a fictional blog:

- `http://www.contoso.com/Blog/blog.cshtml?categories=hardware`
- `http://www.contoso.com//Blog/blog.cshtml?startdate=2009-11-01&enddate=2009-11-30`

Compare those URLs to the following ones:

- `http://www.contoso.com/Blog/categories/hardware/`
- `http://www.contoso.com/Blog/2009/November`

In the first pair, a user would have to know that the blog is displayed using the *blog.cshtml* page, and would then have to construct a query string that gets the right category or date range. The second set of examples is much easier to comprehend and create.

The URLs for the first example also point directly to a specific file (*blog.cshtml*). If for some reason the blog were moved to another folder on the server, or if the blog were rewritten to use a different page, the links would be wrong. The second set of URLs doesn't point to a specific page, so even if the blog implementation or location changes, the URLs would still be valid.

In ASP.NET Web Pages, you can create friendlier URLs like those in the above examples because ASP.NET uses *routing*. Routing creates logical mapping from a URL to a page (or pages) that can fulfill the request. Because the mapping is logical (not physical, to a specific file), routing provides great flexibility in how you define the URLs for your site.

## How Routing Works

When ASP.NET processes a request, it reads the URL to determine how to route it. ASP.NET tries to match individual segments of the URL to files on disk, going from left to right. If there's a match, anything remaining in the URL is passed to the page as *path information*.

Imagine that someone makes a request using this URL:

`http://www.contoso.com/a/b/c`

The search goes like this:

1. Is there a file with the path and name of */a/b/c.cshtml*? If so, run that page and pass no information to it. Otherwise ...
2. Is there a file with the path and name of */a/b.cshtml*? If so, run that page and pass the value `c` to it. Otherwise …
3. Is there a file with the path and name of */a.cshtml*? If so, run that page and pass the value `b/c` to it.

If the search found no exact matches for *.cshtml* files in their specified folders, ASP.NET continues looking for these files in turn:

1. */a/b/c/default.cshtml* (no path information).
2. */a/b/c/index.cshtml* (no path information).

> [!NOTE]
> To be clear, requests for specific pages (that is, requests that include the *.cshtml* filename extension) work just like you'd expect. A request like `http://www.contoso.com/a/b.cshtml` will run the page *b.cshtml* just fine.


Inside a page, you can get the path information via the page's `UrlData` property, which is a dictionary. Imagine that you have a file named *ViewCustomers.cshtml* and your site gets this request:

`http://mysite.com/myWebSite/ViewCustomers/1000`

As described in the rules above, the request will go to your page. Inside the page, you can use code like the following to get and display the path information (in this case, the value &quot;1000&quot;):

[!code-html[Main](creating-readable-urls-in-aspnet-web-pages-sites/samples/sample1.html)]

> [!NOTE]
> Because routing doesn't involve complete file names, there can be ambiguity if you have pages that have the same name but different file-name extensions (for example, *MyPage.cshtml* and *MyPage.html*). In order to avoid problems with routing, it's best to make sure that you don't have pages in your site whose names differ only in their extension.


<a id="Additional_Resources"></a>
## Additional Resources

[WebMatrix - URLs, UrlData and Routing for SEO](http://www.mikesdotnetting.com/Article/165/WebMatrix-URLs-UrlData-and-Routing-for-SEO). This blog entry by Mike Brind provides some additional details on how routing works in ASP.NET Web Pages.