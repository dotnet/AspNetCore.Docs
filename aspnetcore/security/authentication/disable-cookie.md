---
title: Disable automatic cookie authentication in ASP.NET Core
author: John0King
description: Disable automatic cookie authentication in ASP.NET Core
ms.author: riande
ms.date: 5/22/2019
uid: security/authentication/disable-cookie
---
# Disable automatic cookie authentication in ASP.NET Core

By [John King](https://github.com/John0King)

Use one of the following approaches to disable automatic cookie authentication:

* Send an HTTP header or query string called `X-Requested-With` with a value of `XMLHttpRequest`
Handle the various `CookieAuthenticationEvents` methods to do a custom check for whether it's an AJAX request