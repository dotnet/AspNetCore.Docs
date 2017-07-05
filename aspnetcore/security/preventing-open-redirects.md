---
title: Preventing Open Redirect Attacks in an ASP.NET Core app | Microsoft Docs
author: ardalis
description: Shows how to prevent open redirect attacks against an ASP.NET Core app
keywords: ASP.NET Core, Security, Open Redirect Attack
ms.author: riande
manager: wpickett
ms.date: 07/7/2017
ms.topic: article
ms.assetid: 4604e563-e91a-4ecd-b7ed-00b3f1eee2b5
ms.technology: aspnet
ms.prod: asp.net-core
uid: security/preventing-open-redirects
---
# Preventing Open Redirect Attacks in an ASP.NET Core app

A web app that redirects to a URL that is specified via the request such as the querystring or form data can potentially be tampered with to redirect users to an external, malicious URL. This tampering is called an open redirection attack.

Whenever your application logic redirects to a specified URL, you must verify that the redirection URL hasn't been tampered with. ASP.NET Core has built-in functionality to help protect apps from open redirect (also known as open redirection) attacks.

## What is an open redirect attack?

Web applications frequently redirect users to a login page when they access resources that require authentication. The redirection typlically includes a `returnUrl` querystring parameter so that the user can be returned to the originally requested URL after they have successfully logged in. After the user authenticates, they are redirected to the URL they had originally requested.

Because the destination URL is specified in the querystring of the request, a malicious user could tamper with the querystring. A tampered querystring could allow the site to redirect the user to an external, malicious site. This technique is called an open redirect (or redirection) attack.


### An example attack

A malicious user could develop an attack intended to allow the malicious user access to a user's credentials or sensitive information on your app. To begin the attack, they convince the user to click a link to your site's login page, with a `returnUrl` querystring value added to the URL. For example, the [NerdDinner.com](http://nerddinner.com) sample application (written for ASP.NET MVC) includes such a login page here: ``http://nerddinner.com/Account/LogOn?returnUrl=/Home/About``.

If you navigate to the preceding link and log in, you are redirected to the site's [About page](http://nerddinner.com/Home/About). Imagine an attack designed to gain access to a user's credentials. The attacker creates a page that matches the look of the target app. The malicious site might use a similar domain name (for example, nerddiner.com, with a single 'n'). The attacker lures a user to navigate to the site and log in, using a URL like this: ``http://nerddinner.com/Account/LogOn?returnUrl=http://nerddiner.com/Account/LogOn``. After successfully logging in, the user sees the page reload and they are prompted to log in agin. The user will likely believe their first attempt to log in failed, and try again. The attacker stores the user's credentials, and redirects them back to their original site. 

![Open Redirection Attack Process](preventing-open-redirects/_static/open-redirection-attack-process.png)

## Protecting against open redirect attacks

When developing web applications, treat all user-provided data as untrustworthy. If your application has functionality that redirects the user based on the contents of the URL,  ensure that such redirects are only done locally within your app (or to a known URL, not any URL that may be supplied in the querystring). 

Use the [IsLocalUrl](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.mvc.iurlhelper#Microsoft_AspNetCore_Mvc_IUrlHelper_IsLocalUrl_System_String_) method to test URLs before redirecting:

The following example shows how to check whether a URL is local before redirecting.

```
private IActionResult RedirectToLocal(string returnUrl)
{
    if (Url.IsLocalUrl(returnUrl))
    {
        return Redirect(returnUrl);
    }
    else
    {
        return RedirectToAction(nameof(HomeController.Index), "Home");
    }
}
```

The `IsLocalUrl` method protects users from being inadvertently redirected to a malicious site. You can log the details of the URL that was provided when a non-local URL is supplied in a situation where you expected a local URL. Logging redirect URLs may help in diagnosing redirection attacks.
