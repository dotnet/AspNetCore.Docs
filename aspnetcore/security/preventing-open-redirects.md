---
title: Preventing Open Redirect Attacks in an ASP.NET Core app | Microsoft Docs
author: ardalis
description: Shows how to prevent open redirect attacks against an ASP.NET Core app
keywords: ASP.NET Core, Security, Open Redirect Attack
ms.author: riande
manager: wpickett
ms.date: 06/27/2017
ms.topic: article
ms.assetid: 4604e563-e91a-4ecd-b7ed-00b3f1eee2b5
ms.technology: aspnet
ms.prod: asp.net-core
uid: security/preventing-open-redirects
---
# Preventing Open Redirect Attacks in an ASP.NET Core app

ASP.NET Core has built-in functionality to help protect apps from open redirect (also known as open redirection) attacks. This article describes:

- What is an open redirect attack?
- Protecting against open redirect attacks

## What is an open redirect attack?

A common pattern in web applications, especially when a login is required, is to specify a redirect URL through the querystring. In this way, an unauthorized user attempting to access a particular resource can be redirected to a login page with their intended destination included in the URL string. Once they successfully authenticate, the user can be redirected to the URL they had originally requested. However, since the destination URL is simply specified in the querystring of the request, a malicious user could tamper with the querystring, allowing the site to redirect the user to an external, malicious URL. This technique is called an open redirect (or redirection) attack.

### An example attack

A malicious user could develop an attack intended to allow them access to a user's credentials or information your app manages. To begin the attack, they convince the user to click a link to your site's login page, with a `returnUrl` querystring value added to the URL. For example, the [NerdDinner.com](http://nerddinner.com) sample application (written for ASP.NET MVC) includes such a login page here: ``http://nerddinner.com/Account/LogOn?returnUrl=/Home/About``.

If you navigate to the link above and log in, you should be redirected to the site's [About page](http://nerddinner.com/Home/About). Imagine an attack designed to gain access to a user's credentials. The attacker would create a page that matched the look of the target app, and would most likely use a similar domain name as well (e.g. nerddiner.com, with a single 'n'). Then the user might be redirected to a page requesting them to change their password, using a URL like this: ``http://nerddinner.com/Account/LogOn?returnUrl=http://nerddiner.com/Account/ChangePassword``. This forged page lives on the attacker's site, where an unsuspecting user may enter their current site password as part of the change password process. After the first attempt, the attacker might redirect the user back to the original app so the user thinks the operation was successful, and **now the attacker has the user's app credentials**!

When developing web applications, you must always treat user-provided data as untrustworthy. This definitely includes querystring data. If your application has functionality that redirects the user based on the contents of the URL, you should ensure that such redirects are only done locally within your app (or to a known URL, not any URL that may be supplied in the querystring).

## Protecting against open redirect attacks

